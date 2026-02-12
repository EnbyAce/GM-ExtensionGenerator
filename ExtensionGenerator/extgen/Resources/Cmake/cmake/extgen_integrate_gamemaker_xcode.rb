#!/usr/bin/env ruby
# frozen_string_literal: true

require "optparse"
require "xcodeproj"

args = {}
OptionParser.new do |o|
  o.on("--gm PATH") { |v| args[:gm] = v }
  o.on("--gm-target NAME") { |v| args[:gm_target] = v }
  o.on("--ext PATH") { |v| args[:ext] = v }
  o.on("--ext-target NAME") { |v| args[:ext_target] = v }
end.parse!

def abort_msg(msg)
  $stderr.puts(msg)
  exit(2)
end

abort_msg("Missing --gm") unless args[:gm] && !args[:gm].empty?
abort_msg("Missing --ext") unless args[:ext] && !args[:ext].empty?
abort_msg("Missing --ext-target") unless args[:ext_target] && !args[:ext_target].empty?

gm_path  = File.expand_path(args[:gm])
ext_path = File.expand_path(args[:ext])

abort_msg("GM .xcodeproj not found: #{gm_path}") unless File.exist?(gm_path)
abort_msg("Extension .xcodeproj not found: #{ext_path}") unless File.exist?(ext_path)

gm_proj = Xcodeproj::Project.open(gm_path)
ext_proj = Xcodeproj::Project.open(ext_path)

ext_target = ext_proj.targets.find { |t| t.name == args[:ext_target] }
abort_msg("Extension target not found: #{args[:ext_target]}") unless ext_target

# CMake static lib product should be lib<name>.a
product_ref = ext_target.product_reference
abort_msg("Extension target has no product reference") unless product_ref
expected_lib = "lib#{args[:ext_target]}.a"
if product_ref.path != expected_lib
  # Not fatal, but warn: different product name than expected
  puts "WARN: extension product is '#{product_ref.path}', expected '#{expected_lib}'"
end

# Find or choose GM app target
gm_app_target =
  if args[:gm_target] && !args[:gm_target].empty?
    gm_proj.targets.find { |t| t.name == args[:gm_target] }
  else
    # Prefer application product type
    gm_proj.targets.find { |t| (t.product_type || "").include?("application") } || gm_proj.targets.first
  end

abort_msg("Could not find GameMaker app target") unless gm_app_target

# 1) Ensure subproject reference exists in GM project
subproj_ref = gm_proj.files.find { |f| f.path == ext_path }
unless subproj_ref
  subproj_ref = gm_proj.new_file(ext_path)
  puts "Added subproject reference: #{ext_path}"
end

# 2) Ensure “Products” group exists for subprojects (common Xcode shape)
products_group = gm_proj.products_group

# 3) Create proxy objects so GM project can “see” lib<name>.a from the subproject
#    This is the correct cross-project linking method.

# ContainerItemProxy ties to the *subproject* target product
container_proxy = gm_proj.objects.find do |obj|
  obj.isa == "PBXContainerItemProxy" &&
    obj.container_portal == subproj_ref.uuid &&
    obj.remote_info == ext_target.name
end

unless container_proxy
  container_proxy = gm_proj.new(Xcodeproj::Project::Object::PBXContainerItemProxy)
  container_proxy.container_portal = subproj_ref.uuid
  container_proxy.proxy_type = 2
  container_proxy.remote_global_id_string = ext_target.uuid
  container_proxy.remote_info = ext_target.name
  puts "Created PBXContainerItemProxy for #{ext_target.name}"
end

# ReferenceProxy represents lib*.a in GM project (points to container proxy)
ref_proxy = gm_proj.objects.find do |obj|
  obj.isa == "PBXReferenceProxy" &&
    obj.path == product_ref.path &&
    obj.remote_ref == container_proxy
end

unless ref_proxy
  ref_proxy = gm_proj.new(Xcodeproj::Project::Object::PBXReferenceProxy)
  ref_proxy.path = product_ref.path
  ref_proxy.file_type = "archive.ar"
  ref_proxy.source_tree = "BUILT_PRODUCTS_DIR"
  ref_proxy.remote_ref = container_proxy
  puts "Created PBXReferenceProxy for #{product_ref.path}"
end

# Put proxy into Products group (idempotent)
unless products_group.children.include?(ref_proxy)
  products_group.children << ref_proxy
  puts "Added #{product_ref.path} to Products group"
end

# 4) Link the proxy in the GM app target “Frameworks” phase
frameworks_phase = gm_app_target.frameworks_build_phase
already_linked = frameworks_phase.files_references.any? { |r| r == ref_proxy }

unless already_linked
  frameworks_phase.add_file_reference(ref_proxy, true)
  puts "Linked #{product_ref.path} into target #{gm_app_target.name}"
end

gm_proj.save
puts "OK: Integrated #{product_ref.path} from #{File.basename(ext_path)} into #{gm_app_target.name}"
