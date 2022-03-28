#pragma once
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <coreclr/hostfxr.h>
#include <coreclr/coreclr_delegates.h>
#include <utils.h>
#include "altv-cpp-api/ICore.h"

typedef int (* CoreClrDelegate_t)(void* args, int argsLength);

class CoreCLR {
public:
    explicit CoreCLR();

    void start_resource(alt::IResource* resource, alt::ICore* core);
    void stop_resource(alt::IResource* resource);

private:
    HMODULE _coreClrLib;
    hostfxr_initialize_for_runtime_config_fn _initializeFxr = nullptr;
    hostfxr_get_runtime_delegate_fn _getDelegate = nullptr;
    hostfxr_run_app_fn _runApp = nullptr;
    hostfxr_initialize_for_dotnet_command_line_fn _initForCmd = nullptr;
    hostfxr_close_fn _closeFxr = nullptr;
    load_assembly_and_get_function_pointer_fn _loadAssembly = nullptr;

    void initialize_coreclr(const string_t& runtimeconfig_path);
};