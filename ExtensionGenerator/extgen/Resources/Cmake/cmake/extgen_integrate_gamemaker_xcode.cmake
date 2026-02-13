# extgen_integrate_gamemaker_xcode.cmake

if(NOT DEFINED EXT_REPO_ROOT OR EXT_REPO_ROOT STREQUAL "")
  message(FATAL_ERROR "EXT_REPO_ROOT is empty (expected repo root path).")
endif()

# --- Locate ruby + bundle ---
find_program(RUBY_EXECUTABLE ruby REQUIRED)
find_program(BUNDLE_EXECUTABLE bundle)

if(NOT BUNDLE_EXECUTABLE)
  message(FATAL_ERROR
    "Bundler (bundle) not found.\n"
    "Install it without sudo:\n"
    "  gem install bundler --user-install\n"
    "Then make sure your user gem bin is on PATH.")
endif()

# --- Where the Gemfile lives (repo) ---
set(_GEMFILE "${EXT_REPO_ROOT}/cmake/Gemfile")
if(NOT EXISTS "${_GEMFILE}")
  message(FATAL_ERROR "Gemfile not found: ${_GEMFILE}")
endif()

# --- Install location (build dir, not source) ---
set(_BUNDLE_DIR "${CMAKE_BINARY_DIR}/bundle")
file(MAKE_DIRECTORY "${_BUNDLE_DIR}")

# --- Bootstrap gems into build dir (NO SUDO) ---
execute_process(
  COMMAND ${CMAKE_COMMAND} -E env
    "BUNDLE_GEMFILE=${_GEMFILE}"
    "BUNDLE_PATH=${_BUNDLE_DIR}"
    "${BUNDLE_EXECUTABLE}" install
      --gemfile "${_GEMFILE}"
      --path "${_BUNDLE_DIR}"
      --quiet
  WORKING_DIRECTORY "${CMAKE_BINARY_DIR}"
  RESULT_VARIABLE _bres
  OUTPUT_VARIABLE _bout
  ERROR_VARIABLE  _berr
)

if(NOT _bres EQUAL 0)
  message(FATAL_ERROR "bundle install failed (${_bres}):\n${_berr}\n${_bout}")
endif()

# --- Run integrator using the bundled gems ---
execute_process(
  COMMAND ${CMAKE_COMMAND} -E env
    "BUNDLE_GEMFILE=${_GEMFILE}"
    "BUNDLE_PATH=${_BUNDLE_DIR}"
    "${BUNDLE_EXECUTABLE}" exec ruby
      "${CMAKE_CURRENT_LIST_DIR}/extgen_integrate_gamemaker_xcode.rb"
        --gm "${EXT_GM_XCODEPROJ}"
        --gm-target "${EXT_GM_APP_TARGET}"
        --ext "${EXT_EXT_XCODEPROJ}"
        --ext-target "${EXT_EXT_TARGET}"
  WORKING_DIRECTORY "${CMAKE_BINARY_DIR}"
  RESULT_VARIABLE _res
  OUTPUT_VARIABLE _out
  ERROR_VARIABLE  _err
)

message(STATUS "${_out}")

if(NOT _res EQUAL 0)
  message(FATAL_ERROR "Integration failed (${_res}):\n${_err}")
endif()