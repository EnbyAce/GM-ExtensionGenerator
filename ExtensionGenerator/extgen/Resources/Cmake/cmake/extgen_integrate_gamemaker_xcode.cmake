# cmake/extgen_integrate_gamemaker_xcode.cmake

if(NOT DEFINED EXT_GM_XCODEPROJ OR EXT_GM_XCODEPROJ STREQUAL "")
  message(FATAL_ERROR "EXT_GM_XCODEPROJ is empty. Set it to your GameMaker .xcodeproj path.")
endif()

if(NOT EXISTS "${EXT_GM_XCODEPROJ}")
  message(FATAL_ERROR "GameMaker .xcodeproj not found: ${EXT_GM_XCODEPROJ}")
endif()

if(NOT DEFINED EXT_EXT_XCODEPROJ OR EXT_EXT_XCODEPROJ STREQUAL "")
  message(FATAL_ERROR "EXT_EXT_XCODEPROJ is empty (expected generated extension .xcodeproj).")
endif()

if(NOT EXISTS "${EXT_EXT_XCODEPROJ}")
  message(FATAL_ERROR "Extension .xcodeproj not found: ${EXT_EXT_XCODEPROJ}. Did you run CMake configure with the Xcode generator?")
endif()

# Require Ruby (macOS has it)
find_program(RUBY_EXECUTABLE ruby REQUIRED)

# Call the ruby integrator
execute_process(
  COMMAND "${RUBY_EXECUTABLE}"
          "${CMAKE_CURRENT_LIST_DIR}/extgen_integrate_gamemaker_xcode.rb"
          "--gm" "${EXT_GM_XCODEPROJ}"
          "--gm-target" "${EXT_GM_APP_TARGET}"
          "--ext" "${EXT_EXT_XCODEPROJ}"
          "--ext-target" "${EXT_EXT_TARGET}"
  RESULT_VARIABLE _res
  OUTPUT_VARIABLE _out
  ERROR_VARIABLE _err
)

message(STATUS "${_out}")

if(NOT _res EQUAL 0)
  message(FATAL_ERROR "Integration failed (${_res}):\n${_err}")
endif()
