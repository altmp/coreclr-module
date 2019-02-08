#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/IResource.h>
#include <altv-cpp-api/IServer.h>
#include <altv-cpp-api/events/CPlayerConnectEvent.h>
#include <altv-cpp-api/events/CPlayerDamageEvent.h>
#include <altv-cpp-api/events/CPlayerDeadEvent.h>
#include <altv-cpp-api/events/CPlayerDisconnectEvent.h>
#include <altv-cpp-api/events/CRemoveEntityEvent.h>
#include <altv-cpp-api/events/CServerScriptEvent.h>
#include <altv-cpp-api/events/CVehicleChangeSeatEvent.h>
#include <altv-cpp-api/events/CVehicleEnterEvent.h>
#include <altv-cpp-api/events/CVehicleLeaveEvent.h>

#ifdef _WIN32
#define RESOURCES_PATH "\\resources\\"
#else
#define RESOURCES_PATH "/resources/"
#endif

#ifdef _WIN32
#include <direct.h>
#define GetCurrentDir _getcwd
#else
#include <unistd.h>
#define GetCurrentDir getcwd
#endif

//#include "clrHost.h"

/*#include <iostream>

#ifdef _WIN32
#include <windows.h>
#else
#include <stdlib.h>
#include <dlfcn.h>
#include <dirent.h>
#include <sys/stat.h>
#endif*/


#ifdef _WIN32
#include <iostream>
#include <stdio.h>
#include <direct.h>
#else
#include <unistd.h>
#endif
#include "CoreClr.h"
#ifdef __clang__
#pragma clang diagnostic pop
#endif

class CSharpResource : public alt::IResource
{
    bool OnEvent(const alt::CEvent *ev) override;
    void OnTick() override;
    bool Start() override;
    bool Stop() override;

  private:
    alt::IServer *server;

  public:
    CSharpResource(alt::IServer *server, CoreClr *coreClr, alt::IResource::CreationInfo *info);
    ~CSharpResource();
    void (*OnCheckpointDelegate)(alt::ICheckpoint *checkpoint, alt::IEntity *entity, bool state);
    void (*OnClientEventDelegate)(alt::IPlayer *player, const char *name, alt::Array<alt::MValue> *args);
    void (*OnPlayerConnectDelegate)(alt::IPlayer *player, const char *reason);
    void (*OnPlayerDamageDelegate)(alt::IPlayer *player, alt::IEntity* attacker, uint32_t weapon, uint8_t damage);
    void (*OnPlayerDeadDelegate)(alt::IPlayer *player, alt::IEntity* killer, uint32_t weapon);
    void (*OnPlayerDisconnectDelegate)(alt::IPlayer *player, const char *reason);
    void (*OnEntityRemoveDelegate)(alt::IEntity *entity);
    void (*OnServerEventDelegate)(const char *name, alt::Array<alt::MValue> *args);
    void (*OnVehicleChangeSeatDelegate)(alt::IVehicle* vehicle, alt::IPlayer *player, int8_t oldSeat, int8_t newSeat);
    void (*OnVehicleEnterDelegate)(alt::IVehicle* vehicle, alt::IPlayer *player, int8_t seat);
    void (*OnVehicleLeaveDelegate)(alt::IVehicle* vehicle, alt::IPlayer *player, int8_t seat);
    void (*OnStopDelegate)();
    void (*MainDelegate)(alt::IServer *server, const char* resourceName, const char* entryPoint);
    void *runtimeHost;
    unsigned int domainId;
};
