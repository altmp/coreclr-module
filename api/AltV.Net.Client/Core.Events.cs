using System.Numerics;
using System.Reflection;
using AltV.Net.CApi.ClientEvents;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Events;
using AltV.Net.Client.Extensions;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Events;

namespace AltV.Net.Client
{
    public partial class Core
    {
        private Dictionary<string, List<Function>> ServerEventBus = new();
        private Dictionary<string, List<Function>> ClientEventBus = new();


        public virtual IEnumerable<string> GetRegisteredClientEvents()
        {
            return ClientEventBus.Keys;
        }

        public virtual IEnumerable<string> GetRegisteredServerEvents()
        {
            return ServerEventBus.Keys;
        }
        private Dictionary<IntPtr, Dictionary<string, List<Function>>> WebViewEventBus = new();
        private Dictionary<IntPtr, Dictionary<string, List<Function>>> AudioEventBus = new();
        private Dictionary<IntPtr, Dictionary<string, List<Function>>> RmlElementEventBus = new();
        private Dictionary<IntPtr, Dictionary<string, List<Function>>> WebSocketEventBus = new();

        internal readonly IEventHandler<TickDelegate> TickEventHandler =
            new HashSetEventHandler<TickDelegate>();

        internal readonly IEventHandler<ConsoleCommandDelegate> ConsoleCommandEventHandler =
            new HashSetEventHandler<ConsoleCommandDelegate>(EventType.CONSOLE_COMMAND_EVENT);

        internal readonly IEventHandler<PlayerSpawnDelegate> SpawnEventHandler =
            new HashSetEventHandler<PlayerSpawnDelegate>(EventType.SPAWNED);

        internal readonly IEventHandler<PlayerDisconnectDelegate> DisconnectEventHandler =
            new HashSetEventHandler<PlayerDisconnectDelegate>(EventType.DISCONNECT_EVENT);

        internal readonly IEventHandler<GameEntityCreateDelegate> GameEntityCreateEventHandler =
            new HashSetEventHandler<GameEntityCreateDelegate>(EventType.GAME_ENTITY_CREATE);

        internal readonly IEventHandler<GameEntityDestroyDelegate> GameEntityDestroyEventHandler =
            new HashSetEventHandler<GameEntityDestroyDelegate>(EventType.GAME_ENTITY_DESTROY);

        internal readonly IEventHandler<PlayerEnterVehicleDelegate> EnterVehicleEventHandler =
            new HashSetEventHandler<PlayerEnterVehicleDelegate>(EventType.PLAYER_ENTER_VEHICLE);

        internal readonly IEventHandler<AnyResourceErrorDelegate> AnyResourceErrorEventHandler =
            new HashSetEventHandler<AnyResourceErrorDelegate>(EventType.RESOURCE_ERROR);

        internal readonly IEventHandler<AnyResourceStartDelegate> AnyResourceStartEventHandler =
            new HashSetEventHandler<AnyResourceStartDelegate>(EventType.RESOURCE_START);

        internal readonly IEventHandler<AnyResourceStopDelegate> AnyResourceStopEventHandler =
            new HashSetEventHandler<AnyResourceStopDelegate>(EventType.RESOURCE_STOP);

        internal readonly IEventHandler<KeyUpDelegate> KeyUpEventHandler =
            new HashSetEventHandler<KeyUpDelegate>(EventType.KEYBOARD_EVENT);

        internal readonly IEventHandler<KeyDownDelegate> KeyDownEventHandler =
            new HashSetEventHandler<KeyDownDelegate>(EventType.KEYBOARD_EVENT);

        internal readonly IEventHandler<ConnectionCompleteDelegate> ConnectionCompleteEventHandler =
            new HashSetEventHandler<ConnectionCompleteDelegate>(EventType.CONNECTION_COMPLETE);

        internal readonly IEventHandler<PlayerChangeVehicleSeatDelegate> PlayerChangeVehicleSeatEventHandler =
            new HashSetEventHandler<PlayerChangeVehicleSeatDelegate>(EventType.PLAYER_CHANGE_VEHICLE_SEAT);

        internal readonly IEventHandler<PlayerLeaveVehicleDelegate> PlayerLeaveVehicleEventHandler =
            new HashSetEventHandler<PlayerLeaveVehicleDelegate>(EventType.PLAYER_LEAVE_VEHICLE);

        internal readonly IEventHandler<GlobalMetaChangeDelegate> GlobalMetaChangeEventHandler =
            new HashSetEventHandler<GlobalMetaChangeDelegate>(EventType.GLOBAL_META_CHANGE);

        internal readonly IEventHandler<GlobalSyncedMetaChangeDelegate> GlobalSyncedMetaChangeEventHandler =
            new HashSetEventHandler<GlobalSyncedMetaChangeDelegate>(EventType.GLOBAL_SYNCED_META_CHANGE);

        internal readonly IEventHandler<LocalMetaChangeDelegate> LocalMetaChangeEventHandler =
            new HashSetEventHandler<LocalMetaChangeDelegate>(EventType.LOCAL_SYNCED_META_CHANGE);

        internal readonly IEventHandler<StreamSyncedMetaChangeDelegate> StreamSyncedMetaChangeEventHandler =
            new HashSetEventHandler<StreamSyncedMetaChangeDelegate>(EventType.STREAM_SYNCED_META_CHANGE);

        internal readonly IEventHandler<SyncedMetaChangeDelegate> SyncedMetaChangeEventHandler =
            new HashSetEventHandler<SyncedMetaChangeDelegate>(EventType.SYNCED_META_CHANGE);

        internal readonly IEventHandler<TaskChangeDelegate> TaskChangeEventHandler =
            new HashSetEventHandler<TaskChangeDelegate>(EventType.TASK_CHANGE);

        internal readonly IEventHandler<WindowResolutionChangeDelegate> WindowResolutionChangeEventHandler =
            new HashSetEventHandler<WindowResolutionChangeDelegate>(EventType.WINDOW_RESOLUTION_CHANGE);

        internal readonly IEventHandler<WindowFocusChangeDelegate> WindowFocusChangeEventHandler =
            new HashSetEventHandler<WindowFocusChangeDelegate>(EventType.WINDOW_FOCUS_CHANGE);

        internal readonly IEventHandler<RemoveEntityDelegate> RemoveEntityEventHandler =
            new HashSetEventHandler<RemoveEntityDelegate>();

        internal readonly IEventHandler<NetOwnerChangeDelegate> NetOwnerChangeEventHandler =
            new HashSetEventHandler<NetOwnerChangeDelegate>(EventType.NETOWNER_CHANGE);

        internal readonly IEventHandler<PlayerChangeAnimationDelegate> PlayerChangeAnimationEventHandler =
            new HashSetEventHandler<PlayerChangeAnimationDelegate>(EventType.PLAYER_CHANGE_ANIMATION_EVENT);

        internal readonly IEventHandler<PlayerChangeInteriorDelegate> PlayerChangeInteriorEventHandler =
            new HashSetEventHandler<PlayerChangeInteriorDelegate>(EventType.PLAYER_CHANGE_INTERIOR_EVENT);

        internal readonly IEventHandler<PlayerWeaponShootDelegate> PlayerWeaponShootEventHandler =
            new HashSetEventHandler<PlayerWeaponShootDelegate>(EventType.PLAYER_WEAPON_SHOOT_EVENT);

        internal readonly IEventHandler<PlayerWeaponChangeDelegate> PlayerWeaponChangeEventHandler =
            new HashSetEventHandler<PlayerWeaponChangeDelegate>(EventType.PLAYER_WEAPON_CHANGE);

        internal readonly IEventHandler<WeaponDamageDelegate> WeaponDamageEventHandler =
            new HashSetEventHandler<WeaponDamageDelegate>(EventType.WEAPON_DAMAGE_EVENT);

        internal readonly IEventHandler<WorldObjectPositionChangeDelegate> WorldObjectPositionChangeEventHandler =
            new HashSetEventHandler<WorldObjectPositionChangeDelegate>(EventType.WORLD_OBJECT_POSITION_CHANGE);

        internal readonly IEventHandler<WorldObjectStreamInDelegate> WorldObjectStreamInEventHandler =
            new HashSetEventHandler<WorldObjectStreamInDelegate>(EventType.WORLD_OBJECT_STREAM_IN);

        internal readonly IEventHandler<WorldObjectStreamOutDelegate> WorldObjectStreamOutEventHandler =
            new HashSetEventHandler<WorldObjectStreamOutDelegate>(EventType.WORLD_OBJECT_STREAM_OUT);

        internal readonly IEventHandler<ColShapeDelegate> ColShapeEventHandler =
            new HashSetEventHandler<ColShapeDelegate>(EventType.COLSHAPE_EVENT);

        internal readonly IEventHandler<CheckpointDelegate> CheckpointEventHandler =
            new HashSetEventHandler<CheckpointDelegate>(EventType.COLSHAPE_EVENT);

        internal readonly IEventHandler<MetaChangeDelegate> MetaChangeEventHandler =
            new HashSetEventHandler<MetaChangeDelegate>(EventType.META_CHANGE);

        internal readonly IEventHandler<PlayerStartEnterVehicleDelegate> PlayerStartEnterVehicleEventHandler =
            new HashSetEventHandler<PlayerStartEnterVehicleDelegate>(EventType.PLAYER_START_ENTER_VEHICLE);

        internal readonly IEventHandler<PlayerStartLeaveVehicleDelegate> PlayerStartLeaveVehicleEventHandler =
            new HashSetEventHandler<PlayerStartLeaveVehicleDelegate>(EventType.PLAYER_START_LEAVE_VEHICLE);

        internal readonly IEventHandler<EntityHitEntityDelegate> EntityHitEntityEventHandler =
            new HashSetEventHandler<EntityHitEntityDelegate>(EventType.ENTITY_HIT_ENTITY);

        internal readonly IEventHandler<PlayerBulletHitDelegate> PlayerBulletHitEventHandler =
            new HashSetEventHandler<PlayerBulletHitDelegate>(EventType.PLAYER_BULLET_HIT_EVENT);

        internal readonly IEventHandler<VoiceConnectionDelegate> VoiceConnectionEventHandler =
            new HashSetEventHandler<VoiceConnectionDelegate>(EventType.VOICE_CONNECTION_EVENT);

        internal readonly IEventHandler<ScriptRPCDelegate> ScriptRPCHandler =
            new HashSetEventHandler<ScriptRPCDelegate>(EventType.SCRIPT_RPC_EVENT);

        internal readonly IEventHandler<ScriptRPCAnswerDelegate> ScriptRPCAnswerHandler =
            new HashSetEventHandler<ScriptRPCAnswerDelegate>(EventType.SCRIPT_RPC_ANSWER_EVENT);


        public void OnServerEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);

            if (!ServerEventBus.ContainsKey(name)) return;
            foreach (var function in ServerEventBus[name])
            {
                function.CallCatching(mValues, $"server event {name} handler");
            }
        }

        public void OnClientEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);

            if (!ClientEventBus.ContainsKey(name)) return;
            foreach (var function in ClientEventBus[name])
            {
                function.CallCatching(mValues, $"client event {name} handler");
            }
        }

        public void OnWebViewEvent(IntPtr webViewPtr, string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);
            if (!WebViewEventBus.ContainsKey(webViewPtr)) return;
            WebViewEventBus.TryGetValue(webViewPtr, out var handlers);
            if (handlers == null) return;
            if (!handlers.ContainsKey(name)) return;
            foreach (var function in handlers[name])
            {
                function.CallCatching(mValues, $"web view event {name} handler");
            }
        }

        public void OnRmlElementEvent(IntPtr rmlElementPtr, string name, IntPtr pointer)
        {
            var mValue = new MValueConst(this, pointer);
            if (mValue.type != MValueConst.Type.Dict)
            {
                LogInfo("OnRmlElementEvent: Args are not dict");
                return;
            }
            if (!RmlElementEventBus.ContainsKey(rmlElementPtr)) return;
            RmlElementEventBus.TryGetValue(rmlElementPtr, out var handlers);
            if (handlers == null) return;
            if (!handlers.ContainsKey(name)) return;
            foreach (var function in handlers[name])
            {
                function.InvokeNoResult(new object[] {mValue.GetDictionary()});
            }
        }

        public void OnWebSocketEvent(IntPtr webSocketPtr, string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);
            if (!WebSocketEventBus.ContainsKey(webSocketPtr)) return;
            WebSocketEventBus.TryGetValue(webSocketPtr, out var handlers);
            if (handlers == null) return;
            if (!handlers.ContainsKey(name)) return;
            foreach (var function in handlers[name])
            {
                function.CallCatching(mValues, $"websocket event {name} handler");
            }
        }

        public void OnConsoleCommand(string name, string[] args)
        {
            ConsoleCommandEventHandler.GetEvents().ForEachCatching(fn => fn(name, args), $"event {nameof(OnConsoleCommand)} \"{name}\"");
        }

        public void OnTick()
        {
            TickEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnTick)}");
        }

        public void OnPlayerSpawn()
        {
            SpawnEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnPlayerSpawn)}");
        }

        public void OnPlayerDisconnect()
        {
            DisconnectEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnPlayerDisconnect)}");
        }

        public void OnPlayerEnterVehicle(IntPtr pointer, BaseObjectType type, byte seat)
        {
            var vehicle = (IVehicle)PoolManager.Get(pointer, type);
            if (vehicle is null)
            {
                Console.WriteLine("Invalid vehicle: " + pointer);
                return;
            }

            EnterVehicleEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, seat), $"event {nameof(OnPlayerEnterVehicle)}");
        }

        public void OnGameEntityCreate(IntPtr pointer, BaseObjectType type)
        {
            var baseObject = PoolManager.Get(pointer, type);
            if (baseObject is not IEntity entity)
            {
                Console.WriteLine("Invalid entity: " + pointer + " " + (baseObject == null));
                return;
            }

            GameEntityCreateEventHandler.GetEvents().ForEachCatching(fn => fn(entity), $"event {nameof(OnGameEntityCreate)}");
        }

        public void OnGameEntityDestroy(IntPtr pointer, BaseObjectType type)
        {
            var baseObject = PoolManager.Get(pointer, type);
            if (baseObject is not IEntity entity)
            {
                Console.WriteLine("Invalid entity: " + pointer);
                return;
            }

            GameEntityDestroyEventHandler.GetEvents().ForEachCatching(fn => fn(entity), $"event {nameof(OnGameEntityDestroy)}");
        }

        public void OnAnyResourceError(string name)
        {
            AnyResourceErrorEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnAnyResourceError)} \"{name}\"");
        }

        public void OnAnyResourceStart(string name)
        {
            AnyResourceStartEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnAnyResourceStart)} \"{name}\"");
        }

        public void OnAnyResourceStop(string name)
        {
            AnyResourceStopEventHandler.GetEvents().ForEachCatching(fn => fn(name), $"event {nameof(OnAnyResourceStop)} \"{name}\"");
        }

        public void OnKeyDown(Key key)
        {
            KeyDownEventHandler.GetEvents().ForEachCatching(fn => fn(key), $"event {nameof(OnKeyDown)}");
        }

        public void OnKeyUp(Key key)
        {
            KeyUpEventHandler.GetEvents().ForEachCatching(fn => fn(key), $"event {nameof(OnKeyUp)}");
        }

        public void OnCreateBaseObject(IntPtr baseObject, BaseObjectType type, uint id)
        {
            PoolManager.GetOrCreate(this, baseObject, type, id);
        }

        public void OnRemoveBaseObject(IntPtr baseObject, BaseObjectType type)
        {
            PoolManager.Remove(baseObject, type);
        }

        public void OnConnectionComplete()
        {
            ConnectionCompleteEventHandler.GetEvents().ForEachCatching(fn => fn(), $"event {nameof(OnConnectionComplete)}");
        }

        public void OnGlobalMetaChange(string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            GlobalMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnGlobalMetaChange)}");
        }

        public void OnGlobalSyncedMetaChange(string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            GlobalSyncedMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnGlobalSyncedMetaChange)}");
        }

        public void OnPlayerChangeVehicleSeat(IntPtr vehiclePtr, BaseObjectType type, byte oldSeat, byte newSeat)
        {
            var vehicle = (IVehicle)PoolManager.Get(vehiclePtr, type);
            PlayerChangeVehicleSeatEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, oldSeat, newSeat), $"event {nameof(OnPlayerChangeVehicleSeat)}");
        }
        public void OnPlayerChangeAnimation(IntPtr playerPtr, BaseObjectType type, uint oldDict, uint newDict, uint oldName, uint newName)
        {
            var player = (IPlayer)PoolManager.Get(playerPtr, type);
            if (player == null)
            {
                Alt.LogWarning("OnPlayerChangeAnimation: Invalid player " + playerPtr);
                return;
            }

            PlayerChangeAnimationEventHandler.GetEvents().ForEachCatching(fn => fn(player, oldDict, newDict, oldName, newName), $"event {nameof(OnPlayerChangeAnimation)}");
        }

        public void OnPlayerChangeInterior(IntPtr playerPtr, BaseObjectType type, uint oldIntLoc, uint newIntLoc)
        {
            var player = (IPlayer)PoolManager.Get(playerPtr, type);
            if (player == null)
            {
                Alt.LogWarning("OnPlayerChangeInterior: Invalid player " + playerPtr);
                return;
            }

            PlayerChangeInteriorEventHandler.GetEvents().ForEachCatching(fn => fn(player, oldIntLoc, newIntLoc), $"event {nameof(OnPlayerChangeInterior)}");
        }

        public void OnPlayerWeaponShoot(uint weapon, ushort totalAmmo, ushort ammoInClip)
        {
            PlayerWeaponShootEventHandler.GetEvents().ForEachCatching(fn => fn(weapon, totalAmmo, ammoInClip), $"event {nameof(OnPlayerWeaponShoot)}");
        }

        public void OnPlayerWeaponChange(uint oldWeapon, uint newWeapon)
        {
            PlayerWeaponChangeEventHandler.GetEvents().ForEachCatching(fn => fn(oldWeapon, newWeapon), $"event {nameof(OnPlayerWeaponChange)}");
        }

        public void OnWeaponDamage(IntPtr eventPointer, IntPtr entityPointer,
            BaseObjectType entityType, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart,
            IntPtr sourceEntityPointer, BaseObjectType sourceEntityType)
        {
            var events = WeaponDamageEventHandler.GetEvents();

            var target = (IEntity)PoolManager.Get(entityPointer, entityType);
            var sourceEntity = (IEntity)PoolManager.Get(sourceEntityPointer, sourceEntityType);

            var cancel = false;
            foreach (var @delegate in events)
            {
                try
                {
                    if (!@delegate(target, weapon, damage, shotOffset, bodyPart, sourceEntity))
                    {
                        cancel = true;
                    }
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnWeaponDamage" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnWeaponDamage" + ":" + exception);
                }
            }

            if (cancel)
            {
                unsafe
                {
                    Alt.Core.Library.Shared.Event_Cancel(eventPointer);
                }
            }
        }

        public void OnLocalMetaChange(string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            LocalMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnLocalMetaChange)}");
        }

        public void OnStreamSyncedMetaChange(IntPtr targetPtr, BaseObjectType type, string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var target = PoolManager.Get(targetPtr, type);
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            StreamSyncedMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnStreamSyncedMetaChange)}");
        }

        public void OnSyncedMetaChange(IntPtr targetPtr, BaseObjectType type, string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var target = PoolManager.Get(targetPtr, type);
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            SyncedMetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnSyncedMetaChange)}");
        }

        public void OnTaskChange(int oldTask, int newTask)
        {
            TaskChangeEventHandler.GetEvents().ForEachCatching(fn => fn(oldTask, newTask), $"event {nameof(OnTaskChange)}");
        }

        public void OnWindowFocusChange(byte state)
        {
            WindowFocusChangeEventHandler.GetEvents().ForEachCatching(fn => fn(state != 0), $"event {nameof(OnWindowFocusChange)}");
        }

        public void OnWindowResolutionChange(Vector2 oldRes, Vector2 newRes)
        {
            WindowResolutionChangeEventHandler.GetEvents().ForEachCatching(fn => fn(oldRes, newRes), $"event {nameof(OnWindowResolutionChange)}");
        }

        public void OnNetOwnerChange(IntPtr targetPtr, BaseObjectType type, IntPtr newOwnerPtr, IntPtr oldOwnerPtr)
        {
            var target = (IEntity)PoolManager.Get(targetPtr, type);
            var newOwner = newOwnerPtr == IntPtr.Zero ? null : PoolManager.Player.Get(newOwnerPtr);
            var oldOwner = oldOwnerPtr == IntPtr.Zero ? null : PoolManager.Player.Get(oldOwnerPtr);
            NetOwnerChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, newOwner, oldOwner), $"event {nameof(OnNetOwnerChange)}");
        }

        public void OnWorldObjectPositionChange(IntPtr targetPtr, BaseObjectType type, Position position)
        {
            var target = (IWorldObject)PoolManager.Get(targetPtr, type);

            WorldObjectPositionChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, position), $"event {nameof(OnWorldObjectPositionChange)}");
        }

        public void OnRemoveEntity(IntPtr targetPtr, BaseObjectType type)
        {
            var target = (IEntity)PoolManager.Get(targetPtr, type);
            RemoveEntityEventHandler.GetEvents().ForEachCatching(fn => fn(target), $"event {nameof(OnRemoveEntity)}");
        }

        public void OnPlayerLeaveVehicle(IntPtr vehiclePtr, BaseObjectType type, byte seat)
        {
            var vehicle = (IVehicle)PoolManager.Get(vehiclePtr, type);
            if (vehicle is null)
            {
                Console.WriteLine("Invalid vehicle: " + vehiclePtr);
                return;
            }

            PlayerLeaveVehicleEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, seat), $"event {nameof(OnPlayerLeaveVehicle)}");
        }

        public Function AddServerEventListener(string eventName, Function function)
        {
            if (function is null)
            {
                Alt.LogWarning("Failed to register server event " + eventName + ": function is null");
                return null;
            }
            if (ServerEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new List<Function> {function};
                ServerEventBus[eventName] = eventHandlers;
            }

            return function;
        }

        public Function AddClientEventListener(string eventName, Function function)
        {
            if (function is null)
            {
                Alt.LogWarning("Failed to register client event " + eventName + ": function is null");
                return null;
            }

            if (ClientEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new List<Function> {function};
                ClientEventBus[eventName] = eventHandlers;
            }

            return function;
        }

        public Function AddWebViewEventListener(IntPtr webViewPtr, string name, Function function)
        {
            if (WebViewEventBus.TryGetValue(webViewPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Add(function);
                }
                else
                {
                    eventHandler = new List<Function> {function};
                    eventHandlers[name] = eventHandler;
                }
            }
            else
            {
                eventHandlers = new Dictionary<string, List<Function>> {{name, new List<Function> {function}}};
                WebViewEventBus[webViewPtr] = eventHandlers;
            }
            return function;
        }

        public Function AddAudioEventListener(IntPtr audioPtr, string name, Function function)
        {
            if (AudioEventBus.TryGetValue(audioPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Add(function);
                }
                else
                {
                    eventHandler = new List<Function> {function};
                    eventHandlers[name] = eventHandler;
                }
            }
            else
            {
                eventHandlers = new Dictionary<string, List<Function>> {{name, new List<Function> {function}}};
                AudioEventBus[audioPtr] = eventHandlers;
            }
            return function;
        }

        public Function AddRmlElementEventListener(IntPtr rmlElementPtr, string name, Function function)
        {
            if (RmlElementEventBus.TryGetValue(rmlElementPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Add(function);
                }
                else
                {
                    eventHandler = new List<Function> {function};
                    eventHandlers[name] = eventHandler;
                }
            }
            else
            {
                eventHandlers = new Dictionary<string, List<Function>> {{name, new List<Function> {function}}};
                RmlElementEventBus[rmlElementPtr] = eventHandlers;
            }
            return function;
        }

        public Function AddWebSocketEventListener(IntPtr websocketPtr, string name, Function function)
        {
            if (WebSocketEventBus.TryGetValue(websocketPtr, out var eventHandlers))
            {
                if (eventHandlers.TryGetValue(name, out var eventHandler))
                {
                    eventHandler.Add(function);
                }
                else
                {
                    eventHandler = new List<Function> {function};
                    eventHandlers[name] = eventHandler;
                }
            }
            else
            {
                eventHandlers = new Dictionary<string, List<Function>> {{name, new List<Function> {function}}};
                WebSocketEventBus[websocketPtr] = eventHandlers;
            }
            return function;
        }

        public void OnWorldObjectStreamIn(IntPtr targetPtr, BaseObjectType type)
        {
            var target = (IWorldObject)PoolManager.Get(targetPtr, type);

            WorldObjectStreamInEventHandler.GetEvents().ForEachCatching(fn => fn(target), $"event {nameof(OnWorldObjectStreamIn)}");
        }

        public void OnWorldObjectStreamOut(IntPtr targetPtr, BaseObjectType type)
        {
            var target = (IWorldObject)PoolManager.Get(targetPtr, type);

            WorldObjectStreamOutEventHandler.GetEvents().ForEachCatching(fn => fn(target), $"event {nameof(OnWorldObjectStreamOut)}");
        }

        public void OnColShape(IntPtr colshapepointer, IntPtr targetentitypointer, BaseObjectType entitytype, bool state)
        {
            var colShape = (IColShape)PoolManager.ColShape.Get(colshapepointer);
            var target = (IWorldObject)PoolManager.Get(targetentitypointer, entitytype);

            ColShapeEventHandler.GetEvents().ForEachCatching(fn => fn(colShape, target, state), $"event {nameof(OnColShape)}");
        }

        public void OnCheckpoint(IntPtr colshapepointer, IntPtr targetentitypointer, BaseObjectType entitytype, bool state)
        {
            var checkPoint = (ICheckpoint)PoolManager.Checkpoint.Get(colshapepointer);
            var target = (IWorldObject)PoolManager.Get(targetentitypointer, entitytype);

            CheckpointEventHandler.GetEvents().ForEachCatching(fn => fn(checkPoint, target, state), $"event {nameof(OnCheckpoint)}");
        }

        public void OnMetaChange(IntPtr targetPtr, BaseObjectType type, string key, IntPtr valuePtr, IntPtr oldValuePtr)
        {
            var target = PoolManager.Get(targetPtr, type);
            var value = new MValueConst(this, valuePtr);
            var oldValue = new MValueConst(this, oldValuePtr);
            MetaChangeEventHandler.GetEvents().ForEachCatching(fn => fn(target, key, value.ToObject(), oldValue.ToObject()), $"event {nameof(OnMetaChange)}");
        }

        public void OnPlayerStartEnterVehicle(IntPtr targetpointer, BaseObjectType type, IntPtr playerPointer, BaseObjectType playerType, byte seat)
        {
            var vehicle = (IVehicle)PoolManager.Get(targetpointer, type);
            var player = (IPlayer)PoolManager.Get(playerPointer, playerType);

            PlayerStartEnterVehicleEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, player, seat), $"event {nameof(OnPlayerStartEnterVehicle)}");
        }

        public void OnPlayerStartLeaveVehicle(IntPtr targetpointer, BaseObjectType type, IntPtr playerPointer, BaseObjectType playerType, byte seat)
        {
            var vehicle = (IVehicle)PoolManager.Get(targetpointer, type);
            var player = (IPlayer)PoolManager.Get(playerPointer, playerType);

            PlayerStartLeaveVehicleEventHandler.GetEvents().ForEachCatching(fn => fn(vehicle, player, seat), $"event {nameof(OnPlayerStartLeaveVehicle)}");
        }

        public void OnEntityHitEntity(IntPtr targetpointer, BaseObjectType targettype, IntPtr damagerpointer, BaseObjectType damagertype, uint weaponhash)
        {
            var target = (IEntity)PoolManager.Get(targetpointer, targettype);
            var damager = (IEntity)PoolManager.Get(damagerpointer, damagertype);

            EntityHitEntityEventHandler.GetEvents().ForEachCatching(fn => fn(target, damager, weaponhash), $"event {nameof(OnEntityHitEntity)}");
        }

        public void OnPlayerBulletHit(uint weapon, IntPtr victimPointer, BaseObjectType victimType, Position pos)
        {
            var victim = (IEntity)PoolManager.Get(victimPointer, victimType);

            PlayerBulletHitEventHandler.GetEvents().ForEachCatching(fn => fn(weapon, victim, pos), $"event {nameof(OnPlayerBulletHit)}");
        }

        public void OnVoiceConnection(VoiceConnectionState state)
        {
            VoiceConnectionEventHandler.GetEvents().ForEachCatching(fn => fn(state), $"event {nameof(OnVoiceConnection)}");
        }

        public void OnAudioEvent(IntPtr audioPtr, string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(this, args);
            if (!AudioEventBus.ContainsKey(audioPtr)) return;
            AudioEventBus.TryGetValue(audioPtr, out var handlers);
            if (handlers == null) return;
            if (!handlers.ContainsKey(name)) return;
            foreach (var function in handlers[name])
            {
                function.CallCatching(mValues, $"web view event {name} handler");
            }
        }

        public void OnScriptRPCAnswer(ushort answerid, IntPtr answer, string answerError)
        {
            var mValue = new MValueConst(this, answer);
            ScriptRPCAnswerHandler.GetEvents().ForEachCatching(fn => fn(answerid, mValue, answerError), $"event {nameof(OnScriptRPCAnswer)}");
        }

        public void OnScriptRPC(IntPtr eventpointer, string name, IntPtr[] args, ushort answerid)
        {
            if (!UnansweredClientRpcRequest.Contains(answerid))
            {
                UnansweredClientRpcRequest.Add(answerid);
            }
            var mValues = MValueConst.CreateFrom(this, args);
            var clientScriptRPCEvent = new ScriptRpcEvent(this, eventpointer, answerid, true);
            ScriptRPCHandler.GetEvents().ForEachCatching(fn => fn(clientScriptRPCEvent, name, mValues.Select(x => x.ToObject()).ToArray(), answerid), $"event {nameof(OnScriptRPC)}");

            if (UnansweredClientRpcRequest.Contains(answerid))
            {
                clientScriptRPCEvent.AnswerWithError("Answer not handled");
                UnansweredClientRpcRequest.Remove(answerid);
            }
        }

        public bool RemoveServerEventListener(string name, Function function)
        {
            if (function is null
            || !ServerEventBus.TryGetValue(name, out var eventHandlers))
            {
                return false;
            }
            return eventHandlers.Remove(function);
        }

        public bool RemoveClientEventListener(string name, Function function)
        {
            if (function is null
            || !ClientEventBus.TryGetValue(name, out var eventHandlers))
            {
                return false;
            }
            return eventHandlers.Remove(function);
        }

        public bool RemoveWebViewEventListener(IntPtr webViewPtr, string name, Function function)
        {
            if (function is null
            || !WebViewEventBus.TryGetValue(webViewPtr, out var eventHandlerDictionary)
            || !eventHandlerDictionary.TryGetValue(name, out var eventHandlers))
            {
                return false;
            }
            return eventHandlers.Remove(function);
        }

        public bool RemoveAudioEventListener(IntPtr audioPtr, string name, Function function)
        {
            if (function is null
            || !AudioEventBus.TryGetValue(audioPtr, out var eventHandlerDictionary)
            || !eventHandlerDictionary.TryGetValue(name, out var eventHandlers))
            {
                return false;
            }
            return eventHandlers.Remove(function);
        }

        public bool RemoveRmlElementEventListener(IntPtr rmlElementPtr, string name, Function function)
        {
            if (function is null
            || !RmlElementEventBus.TryGetValue(rmlElementPtr, out var eventHandlerDictionary)
            || !eventHandlerDictionary.TryGetValue(name, out var eventHandlers))
            {
                return false;
            }
            return eventHandlers.Remove(function);
        }

        public bool RemoveWebSocketEventListener(IntPtr webSocketPtr, string name, Function function)
        {
            if (function is null
            || !WebSocketEventBus.TryGetValue(webSocketPtr, out var eventHandlerDictionary)
            || !eventHandlerDictionary.TryGetValue(name, out var eventHandlers))
            {
                return false;
            }
            return eventHandlers.Remove(function);
        }
    }
}