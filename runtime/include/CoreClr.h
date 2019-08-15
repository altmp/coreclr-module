#pragma once

#ifdef _WIN32
#include <Windows.h>
#include <direct.h>
//#include <shlobj_core.h>
#include <shlobj.h>
//#include <libloaderapi.h>
#include "dirent_win.h"
#else

#include <dirent.h>
#include <dlfcn.h>

#endif

// GetCurrentDir
#ifdef _WIN32
#include <direct.h>
#define GetCurrentDir _getcwd
#else
#include <unistd.h>

#include <stdio.h>
#include <sys/types.h>
#include <sys/wait.h>
#define GetCurrentDir getcwd
#endif

// Host name
#ifdef _WIN32
#define HostDll "\AltV.Net.Host.dll"
#else
#define HostDll "/AltV.Net.Host.dll"
#endif

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#include <coreclr/coreclrhost.h>
#include <sys/stat.h>
#include <string.h>

#ifdef _WIN32
#define LIST_SEPARATOR ";"
#define strtok_r strtok_s
#define PATH_SEPARATOR "\\"
#else
#define LIST_SEPARATOR ":"
#define PATH_SEPARATOR "/"
#endif

#define TAIL_CMP_LT -1
#define TAIL_CMP_EQ  0
#define TAIL_CMP_GT +1
#define TAIL_CMP_KO  9

int tail_cmp(char* lhs, char* rhs);

int tail_lt(char* lhs, char* rhs);

int tail_eq(char* lhs, char* rhs);

int tail_gt(char* lhs, char* rhs);

typedef void (* ExecuteResourceDelegate_t)(const char* resourceName, const char* resourceMain, int resourceIndex);

class CoreClr {
public:
    CoreClr(alt::IServer* server);

    ~CoreClr();

    bool GetDelegate(alt::IServer* server, void* runtimeHost, unsigned int domainId, const char* moduleName,
                     const char* classPath, const char* methodName, void** callback);

    alt::Array<alt::String> getTrustedAssemblies(alt::IServer* server, const char* appPath);

    void CreateAppDomain(alt::IServer* server, alt::IResource* resource, const char* appPath, void** runtimeHost,
                         unsigned int* domainId, bool executable, uint64_t resourceIndex, const char* domainName);

    int Execute(alt::IServer* server, alt::IResource* resource, const char* appPath, uint64_t resourceIndex, void** runtimeHost,
                         const unsigned int* domainId);

    void Shutdown(alt::IServer* server, void* runtimeHost,
                  unsigned int domainId);

    void GetPath(alt::IServer* server, const char* defaultPath);

    /**
     * prints out error when error code in known
     * @param server
     * @param errorCode
     * @return true when error code is known
     */
    bool PrintError(alt::IServer* server, int errorCode);

    void CreateManagedHost(alt::IServer* server);

    void ExecuteManagedResource(alt::IServer* server, const char* resourceName, const char* resourceMain, int resourceIndex);

private:
#ifdef _WIN32
    HMODULE _coreClrLib;
#else
    void* _coreClrLib;
#endif
    char* runtimeDirectory;
    coreclr_initialize_ptr _initializeCoreCLR;
    coreclr_shutdown_2_ptr _shutdownCoreCLR;
    coreclr_create_delegate_ptr _createDelegate;
    coreclr_execute_assembly_ptr _executeAssembly;
    void* managedRuntimeHost;
    unsigned int managedDomainId;
    ExecuteResourceDelegate_t ExecuteResourceDelegate;
};
