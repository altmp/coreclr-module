#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include <altv-cpp-api/types/IConnectionInfo.h>
#include <altv-cpp-api/events/CMetaDataChangeEvent.h>
#include <altv-cpp-api/events/CSyncedMetaDataChangeEvent.h>
#include <altv-cpp-api/events/CVehicleDestroyEvent.h>
#include <altv-cpp-api/events/CFireEvent.h>
#include <altv-cpp-api/events/CStartProjectileEvent.h>
#include <altv-cpp-api/events/CPlayerWeaponChangeEvent.h>
#include <altv-cpp-api/events/CNetOwnerChangeEvent.h>
#include <altv-cpp-api/events/CVehicleAttachEvent.h>
#include <altv-cpp-api/events/CVehicleDetachEvent.h>
#include <altv-cpp-api/events/CPlayerEnteringVehicleEvent.h>

#ifdef _WIN32
#define RESOURCES_PATH "\\resources\\"
#define ASSEMBLY_PATH "\\assembly.cfg"
#else
#define RESOURCES_PATH "/resources/"
#define ASSEMBLY_PATH "/assembly.cfg"
#endif

#ifdef _WIN32
#include <iostream>
#include <stdio.h>
#include <direct.h>
#else

#include <unistd.h>

#endif

#include "CoreClr.h"
#include "../src/altv-c-api/position.h"
#include "../src/altv-c-api/rgba.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef alt::MValueConst* (* MValueFunctionCallback)(alt::MValueConst* [], long size);

class CustomInvoker : public alt::IMValueFunction::Impl {
public:
    MValueFunctionCallback mValueFunctionCallback;

    explicit CustomInvoker(MValueFunctionCallback mValueFunctionCallback) {
        this->mValueFunctionCallback = mValueFunctionCallback;
    }

    alt::MValue Call(alt::MValueArgs args) const override {
        uint64_t size = args.GetSize();
        if (size == 0) {
            alt::MValueConst* resultConstPtr = mValueFunctionCallback(nullptr, 0);
            alt::MValue result = *((alt::MValue*) resultConstPtr);
            return result;
        } else {
#ifdef _WIN32
            auto constArgs = new alt::MValueConst* [size];
#else
            alt::MValueConst* constArgs[size];
#endif
            for (uint64_t i = 0; i < size; i++) {
                constArgs[i] = &args[i];
            }
            alt::MValueConst* resultConstPtr = mValueFunctionCallback(constArgs, size);
#ifdef _WIN32
            delete[] constArgs;
#endif
            alt::MValue result = *((alt::MValue*) resultConstPtr);
            return result;
        }
    }
};

struct ClrConnectionInfo {
    char* name = nullptr;
    uint64_t socialId = 0;
    uint64_t hwidHash = 0;
    uint64_t hwidExHash = 0;
    char* authToken = nullptr;
    bool isDebug = 0;
    char* branch = nullptr;
    uint32_t build = 0;
    char* cdnUrl = nullptr;
    uint64_t passwordHash = 0;

    ClrConnectionInfo() = default;

    ClrConnectionInfo(alt::IConnectionInfo* info) :
    socialId(info->GetSocialId()), hwidHash(info->GetHwIdHash()), hwidExHash(info->GetHwIdExHash()),
    isDebug(info->GetIsDebug()),
    build(info->GetBuild()), passwordHash(info->GetPasswordHash()) {
        name = new char[info->GetName().length() + 1];
        strcpy(name, info->GetName().c_str());

        authToken = new char[info->GetAuthToken().length() + 1];
        strcpy(authToken, info->GetAuthToken().c_str());

        branch = new char[info->GetBranch().length() + 1];
        strcpy(branch, info->GetBranch().c_str());

        cdnUrl = new char[info->GetCdnUrl().length() + 1];
        strcpy(cdnUrl, info->GetCdnUrl().c_str());
    }

    void dealloc() const {
        delete[] name;
        delete[] authToken;
        delete[] branch;
        delete[] cdnUrl;
    }
};

typedef void (* MainDelegate_t)(alt::ICore* server, alt::IResource* resource, const char* resourceName,
                                const char* entryPoint);

typedef void (* TickDelegate_t)();

typedef void (* ServerEventDelegate_t)(const char* name, alt::MValueConst** args, uint64_t size);

typedef void (* CheckpointDelegate_t)(alt::ICheckpoint* checkpoint, void* entity, alt::IBaseObject::Type type,
                                      bool state);

typedef void (* ClientEventDelegate_t)(alt::IPlayer* player, const char* name, alt::MValueConst** args, uint64_t);

typedef void (* PlayerConnectDelegate_t)(alt::IPlayer* player, uint16_t playerId, const char* reason);

typedef void (* PlayerBeforeConnectDelegate_t)(const alt::CEvent* event, ClrConnectionInfo* connectionInfo, const char* reason);

typedef void (* ResourceEventDelegate_t)(alt::IResource* resource);

typedef void (* PlayerDamageDelegate_t)(alt::IPlayer* player, void* attacker,
                                        alt::IBaseObject::Type attackerType, uint16_t attackerId, uint32_t weapon,
                                        uint16_t healthDamage, uint16_t armourDamage);

typedef void (* PlayerDeathDelegate_t)(alt::IPlayer* player, void* killer, alt::IBaseObject::Type killerType,
                                       uint32_t weapon);

typedef void (* PlayerDisconnectDelegate_t)(alt::IPlayer* player, const char* reason);

typedef void (* PlayerRemoveDelegate_t)(alt::IPlayer* player);

typedef void (* VehicleRemoveDelegate_t)(alt::IVehicle* vehicle);

typedef void (* PlayerChangeVehicleSeatDelegate_t)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t oldSeat,
                                                   uint8_t newSeat);

typedef void (* PlayerEnterVehicleDelegate_t)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t seat);

typedef void (* PlayerEnteringVehicleDelegate_t)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t seat);

typedef void (* PlayerLeaveVehicleDelegate_t)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t seat);

typedef void (* StopDelegate_t)();

typedef void (* CreatePlayerDelegate_t)(alt::IPlayer* player, uint16_t id);

typedef void (* RemovePlayerDelegate_t)(alt::IPlayer* player);

typedef void (* CreateVehicleDelegate_t)(alt::IVehicle* vehicle, uint16_t id);

typedef void (* RemoveVehicleDelegate_t)(alt::IVehicle* vehicle);

typedef void (* CreateBlipDelegate_t)(alt::IBlip* blip);

typedef void (* RemoveBlipDelegate_t)(alt::IBlip* blip);

typedef void (* CreateCheckpointDelegate_t)(alt::ICheckpoint* checkpoint);

typedef void (* RemoveCheckpointDelegate_t)(alt::ICheckpoint* checkpoint);

typedef void (* CreateVoiceChannelDelegate_t)(alt::IVoiceChannel* channel);

typedef void (* RemoveVoiceChannelDelegate_t)(alt::IVoiceChannel* channel);

typedef void (* CreateColShapeDelegate_t)(alt::IColShape* colShape);

typedef void (* RemoveColShapeDelegate_t)(alt::IColShape* colShape);

typedef void (* ConsoleCommandDelegate_t)(const char* name, const char* args[], int argsSize);

typedef void (* MetaChangeDelegate_t)(void* entity, alt::IBaseObject::Type type, const char* key,
                                      alt::MValueConst* value);

typedef void (* ColShapeDelegate_t)(void* colShape, void* entity, alt::IBaseObject::Type baseObjectType,
                                    bool state);

typedef void (* WeaponDamageDelegate_t)(const alt::CEvent* event, alt::IPlayer* source, void* target,
                                        alt::IBaseObject::Type targetBaseObjectType,
                                        uint32_t weaponHash, uint16_t damageValue, position_t shotOffset,
                                        alt::CWeaponDamageEvent::BodyPart bodyPart);

typedef void (* ExplosionDelegate_t)(const alt::CEvent* event, alt::IPlayer* source,
                                     alt::CExplosionEvent::ExplosionType explosionType,
                                     position_t position, uint32_t explosionFX, void* targetEntity,
                                     alt::IBaseObject::Type targetType);

typedef void (* VehicleDestroyDelegate_t)(alt::IVehicle* vehicle);

typedef void (* FireDelegate_t)(const alt::CEvent* event, alt::IPlayer* source, alt::CFireEvent::FireInfo fires[],
                                int fireSize);

typedef void (* StartProjectileDelegate_t)(const alt::CEvent* event, alt::IPlayer* source, position_t startPosition,
                                           position_t direction,
                                           uint32_t ammoHash, uint32_t weaponHash);

typedef void (* PlayerWeaponChangeDelegate_t)(const alt::CEvent* event, alt::IPlayer* target, uint32_t oldWeapon,
                                              uint32_t newWeapon);

typedef void (* NetOwnerChangeDelegate_t)(const alt::CEvent* event, void* target, alt::IBaseObject::Type targetType, alt::IPlayer* oldNetOwner, alt::IPlayer* newNetOwner);

typedef void (* VehicleAttachDelegate_t)(const alt::CEvent* event, alt::IVehicle* target, alt::IVehicle* attached);

typedef void (* VehicleDetachDelegate_t)(const alt::CEvent* event, alt::IVehicle* target, alt::IVehicle* detached);

typedef void (* VehicleDamageDelegate_t)(const alt::CEvent* event, alt::IVehicle* target, void* attacker, alt::IBaseObject::Type attackerBaseObjectType,
    uint32_t bodyHealthDamage, uint32_t additionalBodyHealthDamage, uint32_t engineHealthDamage, uint32_t petrolTankDamage, uint32_t weaponHash);

class CSharpResourceImpl : public alt::IResource::Impl {
    bool OnEvent(const alt::CEvent* ev) override;

    void OnTick() override;

    bool Start() override;

    bool Stop() override;

    void OnCreateBaseObject(alt::Ref<alt::IBaseObject> object) override;

    void OnRemoveBaseObject(alt::Ref<alt::IBaseObject> object) override;

    static void* GetBaseObjectPointer(alt::IBaseObject* baseObject);

    static void* GetEntityPointer(alt::IEntity* entity);

    static alt::IBaseObject::Type GetEntityType(alt::IEntity* entity);

    void ResetDelegates();

public:
    CSharpResourceImpl(alt::ICore* server, CoreClr* coreClr, alt::IResource* resource);

    ~CSharpResourceImpl() override;

    bool MakeClient(alt::IResource::CreationInfo* info, alt::Array<alt::String> files) override;

    CheckpointDelegate_t OnCheckpointDelegate = nullptr;

    ClientEventDelegate_t OnClientEventDelegate = nullptr;

    PlayerConnectDelegate_t OnPlayerConnectDelegate = nullptr;

    PlayerBeforeConnectDelegate_t OnPlayerBeforeConnectDelegate = nullptr;

    ResourceEventDelegate_t OnResourceStartDelegate = nullptr;

    ResourceEventDelegate_t OnResourceStopDelegate = nullptr;

    ResourceEventDelegate_t OnResourceErrorDelegate = nullptr;

    PlayerDamageDelegate_t OnPlayerDamageDelegate = nullptr;

    PlayerDeathDelegate_t OnPlayerDeathDelegate = nullptr;

    ExplosionDelegate_t OnExplosionDelegate = nullptr;

    WeaponDamageDelegate_t OnWeaponDamageDelegate = nullptr;

    PlayerDisconnectDelegate_t OnPlayerDisconnectDelegate = nullptr;

    PlayerRemoveDelegate_t OnPlayerRemoveDelegate = nullptr;

    VehicleRemoveDelegate_t OnVehicleRemoveDelegate = nullptr;

    ServerEventDelegate_t OnServerEventDelegate = nullptr;

    PlayerChangeVehicleSeatDelegate_t OnPlayerChangeVehicleSeatDelegate = nullptr;

    PlayerEnterVehicleDelegate_t OnPlayerEnterVehicleDelegate = nullptr;

    PlayerEnteringVehicleDelegate_t OnPlayerEnteringVehicleDelegate = nullptr;

    PlayerLeaveVehicleDelegate_t OnPlayerLeaveVehicleDelegate = nullptr;

    StopDelegate_t OnStopDelegate = nullptr;

    MainDelegate_t MainDelegate = nullptr;

    TickDelegate_t OnTickDelegate = nullptr;

    CreatePlayerDelegate_t OnCreatePlayerDelegate = nullptr;

    RemovePlayerDelegate_t OnRemovePlayerDelegate = nullptr;

    CreateVehicleDelegate_t OnCreateVehicleDelegate = nullptr;

    RemoveVehicleDelegate_t OnRemoveVehicleDelegate = nullptr;

    CreateBlipDelegate_t OnCreateBlipDelegate = nullptr;

    RemoveBlipDelegate_t OnRemoveBlipDelegate = nullptr;

    CreateCheckpointDelegate_t OnCreateCheckpointDelegate = nullptr;

    RemoveCheckpointDelegate_t OnRemoveCheckpointDelegate = nullptr;

    CreateVoiceChannelDelegate_t OnCreateVoiceChannelDelegate = nullptr;

    RemoveVoiceChannelDelegate_t OnRemoveVoiceChannelDelegate = nullptr;

    ConsoleCommandDelegate_t OnConsoleCommandDelegate = nullptr;

    MetaChangeDelegate_t OnMetaChangeDelegate = nullptr;

    MetaChangeDelegate_t OnSyncedMetaChangeDelegate = nullptr;

    CreateColShapeDelegate_t OnCreateColShapeDelegate = nullptr;

    RemoveColShapeDelegate_t OnRemoveColShapeDelegate = nullptr;

    ColShapeDelegate_t OnColShapeDelegate = nullptr;

    VehicleDestroyDelegate_t OnVehicleDestroyDelegate = nullptr;

    FireDelegate_t OnFireDelegate = nullptr;

    StartProjectileDelegate_t OnStartProjectileDelegate = nullptr;

    PlayerWeaponChangeDelegate_t OnPlayerWeaponChangeDelegate = nullptr;

    NetOwnerChangeDelegate_t OnNetOwnerChangeDelegate = nullptr;

    VehicleAttachDelegate_t OnVehicleAttachDelegate = nullptr;

    VehicleDetachDelegate_t OnVehicleDetachDelegate = nullptr;

    VehicleDamageDelegate_t OnVehicleDamageDelegate = nullptr;

    alt::Array<CustomInvoker*>* invokers;
    CoreClr* coreClr;
    alt::ICore* server;
    alt::IResource* resource;
};

class BaseObjectWeakReference : public alt::IWeakRef {

public:
    alt::Ref<alt::IBaseObject> baseObjectRef;
    CSharpResourceImpl* cSharpResource;

    BaseObjectWeakReference(alt::Ref<alt::IBaseObject> baseObjectRef, CSharpResourceImpl* cSharpResource) {
        this->baseObjectRef = baseObjectRef;
        this->cSharpResource = cSharpResource;
    }

    void OnDestroy() override {
        auto object = this->baseObjectRef.Get();
        if (object != nullptr) {
            switch (object->GetType()) {
                case alt::IBaseObject::Type::PLAYER:
                    this->cSharpResource->OnRemovePlayerDelegate(dynamic_cast<alt::IPlayer*>(object));
                    break;
                case alt::IBaseObject::Type::VEHICLE:
                    this->cSharpResource->OnRemoveVehicleDelegate(dynamic_cast<alt::IVehicle*>(object));
                    break;
                case alt::IBaseObject::Type::BLIP:
                    this->cSharpResource->OnRemoveBlipDelegate(dynamic_cast<alt::IBlip*>(object));
                    break;
                case alt::IBaseObject::Type::VOICE_CHANNEL:
                    this->cSharpResource->OnRemoveVoiceChannelDelegate(dynamic_cast<alt::IVoiceChannel*>(object));
                    break;
                case alt::IBaseObject::Type::COLSHAPE:
                    this->cSharpResource->OnRemoveColShapeDelegate(dynamic_cast<alt::IColShape*>(object));
                    break;
                case alt::IBaseObject::Type::CHECKPOINT:
                    this->cSharpResource->OnRemoveCheckpointDelegate(dynamic_cast<alt::ICheckpoint*>(object));
                    break;
            }
        }
        delete this;
    }
};

EXPORT void CSharpResourceImpl_SetMainDelegate(CSharpResourceImpl* resource,
                                               MainDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetStopDelegate(CSharpResourceImpl* resource,
                                               StopDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetTickDelegate(CSharpResourceImpl* resource,
                                               TickDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetServerEventDelegate(CSharpResourceImpl* resource,
                                                      ServerEventDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCheckpointDelegate(CSharpResourceImpl* resource,
                                                     CheckpointDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetClientEventDelegate(CSharpResourceImpl* resource,
                                                      ClientEventDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerDamageDelegate(CSharpResourceImpl* resource,
                                                       PlayerDamageDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerConnectDelegate(CSharpResourceImpl* resource,
                                                        PlayerConnectDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerBeforeConnectDelegate(CSharpResourceImpl* resource,
                                                        PlayerBeforeConnectDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetResourceStartDelegate(CSharpResourceImpl* resource,
                                                        ResourceEventDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetResourceStopDelegate(CSharpResourceImpl* resource,
                                                       ResourceEventDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetResourceErrorDelegate(CSharpResourceImpl* resource,
                                                        ResourceEventDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerDeathDelegate(CSharpResourceImpl* resource,
                                                      PlayerDeathDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetExplosionDelegate(CSharpResourceImpl* resource,
                                                    ExplosionDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetWeaponDamageDelegate(CSharpResourceImpl* resource,
                                                       WeaponDamageDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerDisconnectDelegate(CSharpResourceImpl* resource,
                                                           PlayerDisconnectDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerRemoveDelegate(CSharpResourceImpl* resource,
                                                       PlayerRemoveDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetVehicleRemoveDelegate(CSharpResourceImpl* resource,
                                                        VehicleRemoveDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(CSharpResourceImpl* resource,
                                                                  PlayerChangeVehicleSeatDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerEnterVehicleDelegate(CSharpResourceImpl* resource,
                                                             PlayerEnterVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerEnteringVehicleDelegate(CSharpResourceImpl* resource,
                                                                PlayerEnteringVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(CSharpResourceImpl* resource,
                                                             PlayerLeaveVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreatePlayerDelegate(CSharpResourceImpl* resource,
                                                       CreatePlayerDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemovePlayerDelegate(CSharpResourceImpl* resource,
                                                       RemovePlayerDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateVehicleDelegate(CSharpResourceImpl* resource,
                                                        CreateVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,
                                                        RemoveVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateBlipDelegate(CSharpResourceImpl* resource,
                                                     CreateBlipDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveBlipDelegate(CSharpResourceImpl* resource,
                                                     RemoveBlipDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateCheckpointDelegate(CSharpResourceImpl* resource,
                                                           CreateCheckpointDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveCheckpointDelegate(CSharpResourceImpl* resource,
                                                           RemoveCheckpointDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                             CreateVoiceChannelDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                             RemoveVoiceChannelDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetConsoleCommandDelegate(CSharpResourceImpl* resource,
                                                         ConsoleCommandDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetMetaChangeDelegate(CSharpResourceImpl* resource,
                                                     MetaChangeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetSyncedMetaChangeDelegate(CSharpResourceImpl* resource,
                                                           MetaChangeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateColShapeDelegate(CSharpResourceImpl* resource,
                                                         CreateColShapeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveColShapeDelegate(CSharpResourceImpl* resource,
                                                         RemoveColShapeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetColShapeDelegate(CSharpResourceImpl* resource,
                                                   ColShapeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetVehicleDestroyDelegate(CSharpResourceImpl* resource,
                                                         VehicleDestroyDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetFireDelegate(CSharpResourceImpl* resource,
                                               FireDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetStartProjectileDelegate(CSharpResourceImpl* resource,
                                                          StartProjectileDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerWeaponChangeDelegate(CSharpResourceImpl* resource,
                                                             PlayerWeaponChangeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetNetOwnerChangeDelegate(CSharpResourceImpl* resource,
                                                         NetOwnerChangeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetVehicleAttachDelegate(CSharpResourceImpl* resource,
                                                 VehicleAttachDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetVehicleDetachDelegate(CSharpResourceImpl* resource,
                                                 VehicleDetachDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetVehicleDamageDelegate(CSharpResourceImpl* resource,
    VehicleDamageDelegate_t delegate);
