using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Client.Events;
using AltV.Net.Elements.Args;

namespace AltV.Net.Client
{
    public partial class Alt
    {
        public static event TickDelegate OnTick
        {
            add => CoreImpl.TickEventHandler.Add(value);
            remove => CoreImpl.TickEventHandler.Remove(value);
        }

        public static event ConsoleCommandDelegate OnConsoleCommand
        {
            add => CoreImpl.ConsoleCommandEventHandler.Add(value);
            remove => CoreImpl.ConsoleCommandEventHandler.Remove(value);
        }

        public static event PlayerSpawnDelegate OnPlayerSpawn
        {
            add => CoreImpl.SpawnEventHandler.Add(value);
            remove => CoreImpl.SpawnEventHandler.Remove(value);
        }

        public static event PlayerDisconnectDelegate OnPlayerDisconnect
        {
            add => CoreImpl.DisconnectEventHandler.Add(value);
            remove => CoreImpl.DisconnectEventHandler.Remove(value);
        }

        public static event PlayerEnterVehicleDelegate OnPlayerEnterVehicle
        {
            add => CoreImpl.EnterVehicleEventHandler.Add(value);
            remove => CoreImpl.EnterVehicleEventHandler.Remove(value);
        }

        public static event GameEntityCreateDelegate OnGameEntityCreate
        {
            add => CoreImpl.GameEntityCreateEventHandler.Add(value);
            remove => CoreImpl.GameEntityCreateEventHandler.Remove(value);
        }

        public static event GameEntityDestroyDelegate OnGameEntityDestroy
        {
            add => CoreImpl.GameEntityDestroyEventHandler.Add(value);
            remove => CoreImpl.GameEntityDestroyEventHandler.Remove(value);
        }

        public static event AnyResourceErrorDelegate OnAnyResourceError
        {
            add => CoreImpl.AnyResourceErrorEventHandler.Add(value);
            remove => CoreImpl.AnyResourceErrorEventHandler.Remove(value);
        }

        public static event AnyResourceStartDelegate OnAnyResourceStart
        {
            add => CoreImpl.AnyResourceStartEventHandler.Add(value);
            remove => CoreImpl.AnyResourceStartEventHandler.Remove(value);
        }

        public static event AnyResourceStopDelegate OnAnyResourceStop
        {
            add => CoreImpl.AnyResourceStopEventHandler.Add(value);
            remove => CoreImpl.AnyResourceStopEventHandler.Remove(value);
        }

        public static event KeyUpDelegate OnKeyUp
        {
            add => CoreImpl.KeyUpEventHandler.Add(value);
            remove => CoreImpl.KeyUpEventHandler.Remove(value);
        }

        public static event KeyDownDelegate OnKeyDown
        {
            add => CoreImpl.KeyDownEventHandler.Add(value);
            remove => CoreImpl.KeyDownEventHandler.Remove(value);
        }

        public static event ConnectionCompleteDelegate OnConnectionComplete
        {
            add => CoreImpl.ConnectionCompleteEventHandler.Add(value);
            remove => CoreImpl.ConnectionCompleteEventHandler.Remove(value);
        }

        public static event PlayerChangeVehicleSeatDelegate OnPlayerChangeVehicleSeat
        {
            add => CoreImpl.PlayerChangeVehicleSeatEventHandler.Add(value);
            remove => CoreImpl.PlayerChangeVehicleSeatEventHandler.Remove(value);
        }

        public static event PlayerLeaveVehicleDelegate OnPlayerLeaveVehicle
        {
            add => CoreImpl.PlayerLeaveVehicleEventHandler.Add(value);
            remove => CoreImpl.PlayerLeaveVehicleEventHandler.Remove(value);
        }

        public static event PlayerWeaponShootDelegate OnPlayerWeaponShoot
        {
            add => CoreImpl.PlayerWeaponShootEventHandler.Add(value);
            remove => CoreImpl.PlayerWeaponShootEventHandler.Remove(value);
        }

        public static event PlayerWeaponChangeDelegate OnPlayerWeaponChange
        {
            add => CoreImpl.PlayerWeaponChangeEventHandler.Add(value);
            remove => CoreImpl.PlayerWeaponChangeEventHandler.Remove(value);
        }

        public static event GlobalMetaChangeDelegate OnGlobalMetaChange
        {
            add => CoreImpl.GlobalMetaChangeEventHandler.Add(value);
            remove => CoreImpl.GlobalMetaChangeEventHandler.Remove(value);
        }

        public static event GlobalSyncedMetaChangeDelegate OnGlobalSyncedMetaChange
        {
            add => CoreImpl.GlobalSyncedMetaChangeEventHandler.Add(value);
            remove => CoreImpl.GlobalSyncedMetaChangeEventHandler.Remove(value);
        }

        public static event LocalMetaChangeDelegate OnLocalMetaChange
        {
            add => CoreImpl.LocalMetaChangeEventHandler.Add(value);
            remove => CoreImpl.LocalMetaChangeEventHandler.Remove(value);
        }

        public static event StreamSyncedMetaChangeDelegate OnStreamSyncedMetaChange
        {
            add => CoreImpl.StreamSyncedMetaChangeEventHandler.Add(value);
            remove => CoreImpl.StreamSyncedMetaChangeEventHandler.Remove(value);
        }

        public static event SyncedMetaChangeDelegate OnSyncedMetaChange
        {
            add => CoreImpl.SyncedMetaChangeEventHandler.Add(value);
            remove => CoreImpl.SyncedMetaChangeEventHandler.Remove(value);
        }

        public static event TaskChangeDelegate OnTaskChange
        {
            add => CoreImpl.TaskChangeEventHandler.Add(value);
            remove => CoreImpl.TaskChangeEventHandler.Remove(value);
        }

        public static event WindowResolutionChangeDelegate OnWindowResolutionChange
        {
            add => CoreImpl.WindowResolutionChangeEventHandler.Add(value);
            remove => CoreImpl.WindowResolutionChangeEventHandler.Remove(value);
        }

        public static event WindowFocusChangeDelegate OnWindowFocusChange
        {
            add => CoreImpl.WindowFocusChangeEventHandler.Add(value);
            remove => CoreImpl.WindowFocusChangeEventHandler.Remove(value);
        }

        public static event RemoveEntityDelegate OnRemoveEntity
        {
            add => CoreImpl.RemoveEntityEventHandler.Add(value);
            remove => CoreImpl.RemoveEntityEventHandler.Remove(value);
        }

        public static event NetOwnerChangeDelegate OnNetOwnerChange
        {
            add => CoreImpl.NetOwnerChangeEventHandler.Add(value);
            remove => CoreImpl.NetOwnerChangeEventHandler.Remove(value);
        }

        public static event PlayerChangeAnimationDelegate OnPLayerChangeAnimation
        {
            add => CoreImpl.PlayerChangeAnimationEventHandler.Add(value);
            remove => CoreImpl.PlayerChangeAnimationEventHandler.Remove(value);
        }

        public static event PlayerChangeInteriorDelegate OnPlayerChangeInterior
        {
            add => CoreImpl.PlayerChangeInteriorEventHandler.Add(value);
            remove => CoreImpl.PlayerChangeInteriorEventHandler.Remove(value);
        }

        public static event WeaponDamageDelegate OnWeaponDamage
        {
            add => CoreImpl.WeaponDamageEventHandler.Add(value);
            remove => CoreImpl.WeaponDamageEventHandler.Remove(value);
        }

        public static event WorldObjectPositionChangeDelegate OnWorldObjectPositionChange
        {
            add => CoreImpl.WorldObjectPositionChangeEventHandler.Add(value);
            remove => CoreImpl.WorldObjectPositionChangeEventHandler.Remove(value);
        }

        public static event WorldObjectStreamInDelegate OnWorldObjectStreamIn
        {
            add => CoreImpl.WorldObjectStreamInEventHandler.Add(value);
            remove => CoreImpl.WorldObjectStreamInEventHandler.Remove(value);
        }

        public static event WorldObjectStreamOutDelegate OnWorldObjectStreamOut
        {
            add => CoreImpl.WorldObjectStreamOutEventHandler.Add(value);
            remove => CoreImpl.WorldObjectStreamOutEventHandler.Remove(value);
        }

        public static event ColShapeDelegate OnColShape
        {
            add => CoreImpl.ColShapeEventHandler.Add(value);
            remove => CoreImpl.ColShapeEventHandler.Remove(value);
        }

        public static event CheckpointDelegate OnCheckpoint
        {
            add => CoreImpl.CheckpointEventHandler.Add(value);
            remove => CoreImpl.CheckpointEventHandler.Remove(value);
        }

        public static event MetaChangeDelegate OnMetaChange
        {
            add => CoreImpl.MetaChangeEventHandler.Add(value);
            remove => CoreImpl.MetaChangeEventHandler.Remove(value);
        }


        public static event PlayerStartEnterVehicleDelegate OnPlayerStartEnterVehicle
        {
            add => CoreImpl.PlayerStartEnterVehicleEventHandler.Add(value);
            remove => CoreImpl.PlayerStartEnterVehicleEventHandler.Remove(value);
        }


        public static event PlayerStartLeaveVehicleDelegate OnPlayerStartLeaveVehicle
        {
            add => CoreImpl.PlayerStartLeaveVehicleEventHandler.Add(value);
            remove => CoreImpl.PlayerStartLeaveVehicleEventHandler.Remove(value);
        }


        public static event EntityHitEntityDelegate OnEntityHitEntity
        {
            add => CoreImpl.EntityHitEntityEventHandler.Add(value);
            remove => CoreImpl.EntityHitEntityEventHandler.Remove(value);
        }


        public static event PlayerBulletHitDelegate OnPlayerBulletHit
        {
            add => CoreImpl.PlayerBulletHitEventHandler.Add(value);
            remove => CoreImpl.PlayerBulletHitEventHandler.Remove(value);
        }

        public static event VoiceConnectionDelegate OnVoiceConnection
        {
            add => CoreImpl.VoiceConnectionEventHandler.Add(value);
            remove => CoreImpl.VoiceConnectionEventHandler.Remove(value);
        }

        public static event ScriptRPCAnswerDelegate OnScriptRPCAnswer
        {
            add => CoreImpl.ScriptRPCAnswerHandler.Add(value);
            remove => CoreImpl.ScriptRPCAnswerHandler.Remove(value);
        }

        public static event ScriptRPCDelegate OnScriptRPC
        {
            add => CoreImpl.ScriptRPCHandler.Add(value);
            remove => CoreImpl.ScriptRPCHandler.Remove(value);
        }

        public static Function OnServer(string eventName, Function function) => CoreImpl.AddServerEventListener(eventName, function);

        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3>(string eventName, Action<T1, T2, T3> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2>(string eventName, Action<T1, T2> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1>(string eventName, Action<T1> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer(string eventName, Action function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2, T3>(string eventName, Func<T1, T2, T3> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1, T2>(string eventName, Func<T1, T2> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static Function OnServer<T1>(string eventName, Func<T1> function) => CoreImpl.AddServerEventListener(eventName, Function.Create(Core, function));
        public static bool OffServer(string eventName, Function function) => CoreImpl.RemoveServerEventListener(eventName, function);

        public static Function OnClient(string eventName, Function function) => CoreImpl.AddClientEventListener(eventName, function);
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3>(string eventName, Action<T1, T2, T3> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2>(string eventName, Action<T1, T2> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1>(string eventName, Action<T1> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient(string eventName, Action function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7, T8>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6, T7>(string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5, T6>(string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4, T5>(string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3, T4>(string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2, T3>(string eventName, Func<T1, T2, T3> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1, T2>(string eventName, Func<T1, T2> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static Function OnClient<T1>(string eventName, Func<T1> function) => CoreImpl.AddClientEventListener(eventName, Function.Create(Core, function));
        public static bool OffClient(string eventName, Function function) => CoreImpl.RemoveClientEventListener(eventName, function);

        #region WebView

        public static Function On(this IWebView webView, string eventName, Function function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, function);
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) =>
            CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) =>
            CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) =>
            CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5>(this IWebView webView, string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4>(this IWebView webView, string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3>(this IWebView webView, string eventName, Action<T1, T2, T3> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2>(this IWebView webView, string eventName, Action<T1, T2> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1>(this IWebView webView, string eventName, Action<T1> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On(this IWebView webView, string eventName, Action function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) =>
            CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) =>
            CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5>(this IWebView webView, string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4>(this IWebView webView, string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3>(this IWebView webView, string eventName, Func<T1, T2, T3> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2>(this IWebView webView, string eventName, Func<T1, T2> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1>(this IWebView webView, string eventName, Func<T1> function) => CoreImpl.AddWebViewEventListener(webView.WebViewNativePointer, eventName, Function.Create(Core, function));
        public static bool Off(this IWebView webView, string eventName, Function function) => CoreImpl.RemoveWebViewEventListener(webView.WebViewNativePointer, eventName, function);

        #endregion

        #region RmlElement

        public static Function OnRmlEvent(this IRmlElement rmlElement, string eventName, Action<Dictionary<string, MValueConst>> function) => CoreImpl.AddRmlElementEventListener(rmlElement.RmlElementNativePointer, eventName, Function.Create(Core, function));
        public static bool OffRmlEvent(this IRmlElement rmlElement, string eventName, Function function) => CoreImpl.RemoveRmlElementEventListener(rmlElement.RmlElementNativePointer, eventName, function);
        #endregion

        #region Websocket

        public static Function On(this IWebSocketClient webSocketClient, string eventName, Function function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, function);
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2, T3> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2>(this IWebSocketClient webSocketClient, string eventName, Action<T1, T2> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1>(this IWebSocketClient webSocketClient, string eventName, Action<T1> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On(this IWebSocketClient webSocketClient, string eventName, Action function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) =>
            CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2, T3> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2>(this IWebSocketClient webSocketClient, string eventName, Func<T1, T2> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1>(this IWebSocketClient webSocketClient, string eventName, Func<T1> function) => CoreImpl.AddWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, Function.Create(Core, function));
        public static bool Off(this IWebSocketClient webSocketClient, string eventName, Function function) => CoreImpl.RemoveWebSocketEventListener(webSocketClient.WebSocketClientNativePointer, eventName, function);

        #endregion

        #region Audio

        public static Function On(this IAudio audio, string eventName, Function function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, function);
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) =>
            CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) =>
            CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) =>
            CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5>(this IAudio audio, string eventName, Action<T1, T2, T3, T4, T5> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4>(this IAudio audio, string eventName, Action<T1, T2, T3, T4> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3>(this IAudio audio, string eventName, Action<T1, T2, T3> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2>(this IAudio audio, string eventName, Action<T1, T2> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1>(this IAudio audio, string eventName, Action<T1> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On(this IAudio audio, string eventName, Action function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> function) =>
            CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> function) =>
            CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7, T8>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7, T8> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6, T7>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6, T7> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5, T6>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5, T6> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4, T5>(this IAudio audio, string eventName, Func<T1, T2, T3, T4, T5> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3, T4>(this IAudio audio, string eventName, Func<T1, T2, T3, T4> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2, T3>(this IAudio audio, string eventName, Func<T1, T2, T3> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1, T2>(this IAudio audio, string eventName, Func<T1, T2> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static Function On<T1>(this IAudio audio, string eventName, Func<T1> function) => CoreImpl.AddAudioEventListener(audio.AudioNativePointer, eventName, Function.Create(Core, function));
        public static bool Off(this IAudio audio, string eventName, Function function) => CoreImpl.RemoveAudioEventListener(audio.AudioNativePointer, eventName, function);

        #endregion
    }
}