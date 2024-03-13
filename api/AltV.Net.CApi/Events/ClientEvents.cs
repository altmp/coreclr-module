using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.CApi.ClientEvents
{
    public delegate void TickModuleDelegate();

    public delegate void ClientEventModuleDelegate(string name, IntPtr args, ulong size);
    public delegate void ServerEventModuleDelegate(string name, IntPtr args, ulong size);
    public delegate void WebViewEventModuleDelegate(IntPtr webView, string name, IntPtr args, ulong size);
    public delegate void RmlEventModuleDelegate(IntPtr rmlElement, string name, IntPtr args);
    public delegate void WebSocketEventModuleDelegate(IntPtr webSocket, string name, IntPtr args, ulong size);
    public delegate void AudioEventModuleDelegate(IntPtr audio, string name, IntPtr args, ulong size);
    public delegate void ConsoleCommandModuleDelegate(string name, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] string[] args, int argsSize);

    public delegate void PlayerSpawnModuleDelegate();
    public delegate void PlayerDisconnectModuleDelegate();
    public delegate void PlayerEnterVehicleModuleDelegate(IntPtr baseObject, BaseObjectType type, byte seat);
    public delegate void PlayerLeaveVehicleModuleDelegate(IntPtr baseObject, BaseObjectType type, byte seat);
    public delegate void PlayerChangeVehicleSeatModuleDelegate(IntPtr pointer, BaseObjectType type, byte oldSeat, byte newSeat);
    public delegate void PlayerChangeAnimationModuleDelegate(IntPtr pointer, BaseObjectType type, uint oldDict, uint newDict, uint oldName, uint newName);
    public delegate void PlayerChangeInteriorModuleDelegate(IntPtr pointer, BaseObjectType type, uint oldIntLoc, uint newIntLoc);
    public delegate void PlayerWeaponShootModuleDelegate(uint weapon, ushort totalAmmo, ushort ammoInClip);
    public delegate void PlayerWeaponChangeModuleDelegate(uint oldWeapon, uint newWeapon);

    public delegate void GameEntityCreateModuleDelegate(IntPtr pointer, BaseObjectType type);
    public delegate void GameEntityDestroyModuleDelegate(IntPtr pointer, BaseObjectType type);

    public delegate void AnyResourceErrorModuleDelegate(string name);
    public delegate void AnyResourceStartModuleDelegate(string name);
    public delegate void AnyResourceStopModuleDelegate(string name);

    public delegate void KeyDownModuleDelegate(uint key);
    public delegate void KeyUpModuleDelegate(uint key);

    public delegate void ScreenshotResultModuleDelegate(IntPtr strPtr);
    public delegate void HttpResponseModuleDelegate(int statusCode, string body, IntPtr headerKeys, IntPtr headerValues, int headerSize);

    public delegate void ConnectionCompleteModuleDelegate();

    public delegate void GlobalMetaChangeModuleDelegate(string key, IntPtr value, IntPtr oldValue);
    public delegate void GlobalSyncedMetaChangeModuleDelegate(string key, IntPtr value, IntPtr oldValue);

    public delegate void LocalMetaChangeModuleDelegate(string key, IntPtr value, IntPtr oldValue);
    public delegate void StreamSyncedMetaChangeModuleDelegate(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue);
    public delegate void SyncedMetaChangeModuleDelegate(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue);
    public delegate void MetaChangeModuleDelegate(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue);

    public delegate void TaskChangeModuleDelegate(int oldTask, int newTask);

    public delegate void WindowFocusChangeModuleDelegate(byte state);
    public delegate void WindowResolutionChangeModuleDelegate(Vector2 oldResolution, Vector2 newResolution);

    public delegate void WorldObjectPositionChangeModuleDelegate(IntPtr target, BaseObjectType type, Position oldPosition);
    public delegate void WorldObjectStreamInModuleDelegate(IntPtr target, BaseObjectType type);
    public delegate void WorldObjectStreamOutModuleDelegate(IntPtr target, BaseObjectType type);


    public delegate void NetOwnerChangeModuleDelegate(IntPtr target, BaseObjectType type, IntPtr newOwner, IntPtr oldOwner);

    public delegate void DiscordOAuth2TokenResultModuleDelegate(byte success, string token);

    public delegate void WeaponDamageModuleDelegate(IntPtr eventPointer, IntPtr entityPointer,
        BaseObjectType entityType, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart, IntPtr sourceEntityPointer,
        BaseObjectType sourceEntityType);

    public delegate void CreateBaseObjectModuleDelegate(IntPtr baseObject, BaseObjectType type, uint id);

    public delegate void RemoveBaseObjectModuleDelegate(IntPtr baseObject, BaseObjectType type);

    public delegate void ColShapeModuleDelegate(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
        byte state);
    public delegate void CheckpointModuleDelegate(IntPtr colShapePointer, IntPtr targetEntityPointer, BaseObjectType entityType,
        byte state);

    public delegate void EntityHitEntityModuleDelegate(IntPtr targetPointer, BaseObjectType targetType, IntPtr damagerPointer,
        BaseObjectType damagerType, uint weaponHash);

    public delegate void PlayerStartEnterVehicleModuleDelegate(IntPtr targetPointer, BaseObjectType type, IntPtr player, BaseObjectType playerType, byte seat);
    public delegate void PlayerStartLeaveVehicleModuleDelegate(IntPtr targetPointer, BaseObjectType type, IntPtr player, BaseObjectType playerType, byte seat);

    public delegate void PlayerBulletHitModuleDelegate(uint weapon, IntPtr victimPointer, BaseObjectType victimType,
        Position pos);

    public delegate void VoiceConnectionModuleDelegate(VoiceConnectionState state);

    public delegate void ScriptRPCModuleDelegate(IntPtr eventPointer, string name, IntPtr args, ulong size, ushort answerId);

    public delegate void ScriptRPCAnswerModuleDelegate(ushort answerId, IntPtr answer,
        string answerError);
}