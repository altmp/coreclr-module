using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.CApi.Exceptions;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared;
using AltV.Net.Shared.Events;

namespace AltV.Net.Client
{
    public class ModuleWrapper
    {
        private static Core _core;
        private static IResource _resource;
        private static IntPtr _resourcePointer;
        private static IntPtr _corePointer;

        private static string DllName;
        public static void MainWithAssembly(Assembly resourceAssembly, IntPtr resourcePointer, IntPtr corePointer, string dllName, Dictionary<ulong, IntPtr> cApiFuncTable)
        {
            DllName = dllName;

            var library = new Library(cApiFuncTable, true);
            var logger = new Logger(library, corePointer);
            Alt.Logger = logger;

            if (library.Outdated)
            {
                Alt.LogWarning("Found mismatching SDK methods. Please update AltV.Net.Client NuGet.");
            }

            unsafe
            {
                if (library.Shared.Core_GetEventTypeSize() != (byte) EventType.SIZE)
                {
                    throw new OutdatedSdkException("EventType", "Event type enum size doesn't match. Please, update the nuget");
                }
                if (library.Shared.Core_GetBaseObjectTypeSize() != (byte) BaseObjectType.Size)
                {
                    throw new OutdatedSdkException("BaseObjectType", "BaseObject type enum size doesn't match. Please, update the nuget");
                }
            }

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            _resourcePointer = resourcePointer;
            _corePointer = corePointer;

            var type = typeof(IResource);
            var resource = resourceAssembly.GetTypes().FirstOrDefault(t => t.IsClass && !t.IsAbstract && type.IsAssignableFrom(t));
            if (resource is null)
            {
                throw new Exception("Cannot find resource");
                return;
            }

            _resource = (IResource) Activator.CreateInstance(resource)!;

            Alt.Logger = _resource.GetLogger(library, corePointer);

            var playerPool = new PlayerPool(_resource.GetPlayerFactory());
            var vehiclePool = new VehiclePool(_resource.GetVehicleFactory());
            var pedPool = new PedPool(_resource.GetPedFactory());
            var blipPool = new BlipPool(_resource.GetBlipFactory());
            var checkpointPool = new CheckpointPool(_resource.GetCheckpointFactory());
            var colShapePool = new ColShapePool(_resource.GetColShapeFactory());
            var audioPool = new AudioPool(_resource.GetAudioFactory());
            var httpClientPool = new HttpClientPool(_resource.GetHttpClientFactory());
            var webSocketClientPool = new WebSocketClientPool(_resource.GetWebSocketClientFactory());
            var webViewPool = new WebViewPool(_resource.GetWebViewFactory());
            var rmlDocumentPool = new RmlDocumentPool(new RmlDocumentFactory());
            var rmlElementPool = new RmlElementPool(new RmlElementFactory());
            var localObjectPool = new LocalObjectPool(_resource.GetLocalObjectFactory());
            var objectPool = new ObjectPool(_resource.GetObjectFactory());
            var virtualEntityPool = new VirtualEntityPool(_resource.GetVirtualEntityFactory());
            var virtualEntityGroupPool = new VirtualEntityGroupPool(_resource.GetVirtualEntityGroupFactory());
            var textLabelPool = new TextLabelPool(_resource.GetTextLabelFactory());
            var nativeResourcePool = new NativeResourcePool(_resource.GetResourceFactory());
            var localVehiclePool = new LocalVehiclePool(_resource.GetLocalVehicleFactory());
            var localPedPool = new LocalPedPool(_resource.GetLocalPedFactory());
            var audioFilterPool = new AudioFilterPool(_resource.GetAudioFilterFactory());
            var audioOutputPool = new AudioOutputPool(_resource.GetAudioOutputFactory());
            var AudioOutputAttachedPool = new AudioOutputAttachedPool(_resource.GetAudioOutputAttachedFactory());
            var AudioOutputFrontendPool = new AudioOutputFrontendPool(_resource.GetAudioOutputFrontendFactory());
            var AudioOutputWorldPool = new AudioOutputWorldPool(_resource.GetAudioOutputWorldFactory());
            var fontPool = new FontPool(_resource.GetFontFactory());
            var markerPool = new MarkerPool(_resource.GetMarkerFactory());
            var baseBaseObjectPool = new PoolManager(playerPool, vehiclePool, pedPool,
                                                     blipPool, checkpointPool, audioPool,
                                                     httpClientPool, webSocketClientPool, webViewPool,
                                                     rmlElementPool, rmlDocumentPool, localObjectPool, objectPool,
                                                     virtualEntityPool, virtualEntityGroupPool,
                                                     textLabelPool, colShapePool, localVehiclePool,
                                                     localPedPool, audioFilterPool, audioOutputPool, AudioOutputFrontendPool, AudioOutputAttachedPool, AudioOutputWorldPool, fontPool, markerPool);
            var timerPool = new TimerPool();

            var natives = _resource.GetNatives(library);

            var client = new Core(
                library,
                corePointer,
                resourcePointer,
                baseBaseObjectPool,
                nativeResourcePool,
                timerPool,
                logger,
                natives
            );

            _core = client;
            Alt.CoreImpl = client;
            AltShared.Core = client;
            Alt.Log("Core initialized");

            _core.GetAllPlayers();
            _core.GetAllVehicles();
            _core.GetAllBlips();
            _core.GetAllCheckpoints();
            _core.GetAllColShapes();
            _core.GetAllMarkers();
            _core.GetAllPeds();
            _core.GetAllLocalObjects();
            _core.GetAllLocalPeds();
            _core.GetAllLocalVehicles();
            _core.GetAllNetworkObjects();
            _core.GetAllTextLabels();
            _core.GetAllVirtualEntities();
            _core.GetAllVirtualEntityGroups();
            _core.GetAllWorldObjects();

            playerPool.InitLocalPlayer(_core);

            _core.Resource.CSharpResourceImpl.SetDelegates();
            Alt.Log("Delegates set");

            _resource.OnStart();
            Alt.Log("Startup finished");
        }

        private static void OnUnhandledException(object _, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            Alt.LogError(e.IsTerminating ? "FATAL EXCEPTION:" : "UNHANDLED EXCEPTION:");
            Alt.LogError(exception?.ToString());
            _resource.OnUnhandledException(e);

            if (!e.IsTerminating) return;
        }

        public static void OnStop()
        {
            AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;

            _resource.OnStop();

            Alt.Log("Stopping timers");
            foreach (var safeTimer in _core.RunningTimers.ToArray())
            {
                safeTimer.Stop();
                safeTimer.Dispose();
            }
            _core.PoolManager.Dispose();

            _core.Resource.CSharpResourceImpl.Dispose();
        }

        public static void OnCreateBaseObject(IntPtr baseObject, BaseObjectType type, uint id)
        {
            _core.OnCreateBaseObject(baseObject, type, id);
        }

        public static void OnRemoveBaseObject(IntPtr baseObject, BaseObjectType type)
        {
            if (type == BaseObjectType.Player)
            {
                _core.OnRemoveEntity(baseObject, BaseObjectType.Player);
            }
            else if (type == BaseObjectType.Vehicle)
            {
                _core.OnRemoveEntity(baseObject, BaseObjectType.Vehicle);
            }
            else if (type == BaseObjectType.Ped)
            {
                _core.OnRemoveEntity(baseObject, BaseObjectType.Ped);
            }

            _core.OnRemoveBaseObject(baseObject, type);
        }

        public static void OnTick()
        {
            _core.TimerPool.Tick(_core.Resource.Name);
            _resource.OnTick();
            _core.OnTick();
        }

        public static void OnPlayerSpawn()
        {
            _core.OnPlayerSpawn();
        }

        public static void OnPlayerDisconnect()
        {
            _core.OnPlayerDisconnect();
        }

        public static void OnPlayerEnterVehicle(IntPtr pointer, BaseObjectType type, byte seat)
        {
            _core.OnPlayerEnterVehicle(pointer, type, seat);
        }

        public static void OnGameEntityCreate(IntPtr pointer, BaseObjectType type)
        {
            _core.OnGameEntityCreate(pointer, type);
        }

        public static void OnGameEntityDestroy(IntPtr pointer, BaseObjectType type)
        {
            _core.OnGameEntityDestroy(pointer, type);
        }

        public static void OnAnyResourceError(string name)
        {
            _core.OnAnyResourceError(name);
        }

        public static void OnAnyResourceStart(string name)
        {
            _core.OnAnyResourceStart(name);
        }

        public static void OnAnyResourceStop(string name)
        {
            _core.OnAnyResourceStop(name);
        }

        public static void OnKeyDown(uint key)
        {
            var consoleKey = (Key) key;
            _core.OnKeyDown(consoleKey);
        }

        public static void OnKeyUp(uint key)
        {
            var consoleKey = (Key) key;
            _core.OnKeyUp(consoleKey);
        }

        public static void OnServerEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnServerEvent(name, args);
        }

        public static void OnClientEvent(string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnClientEvent(name, args);
        }

        public static void OnWebViewEvent(IntPtr webView, string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnWebViewEvent(webView, name, args);
        }

        public static void OnWebSocketEvent(IntPtr webSocket, string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int) size);
            }

            _core.OnWebSocketEvent(webSocket, name, args);
        }

        public static void OnRmlElementEvent(IntPtr rmlElement, string name, IntPtr pointer)
        {
            _core.OnRmlElementEvent(rmlElement, name, pointer);
        }

        public static void OnConsoleCommand(string name,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            string[] args, int _)
        {
            args ??= Array.Empty<string>();
            _core.OnConsoleCommand(name, args);
        }

        public static void OnGlobalMetaChange(string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnGlobalMetaChange(key, value, oldValue);
        }

        public static void OnGlobalSyncedMetaChange(string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnGlobalSyncedMetaChange(key, value, oldValue);
        }

        public static void OnConnectionComplete()
        {
            _core.OnConnectionComplete();
        }

        public static void OnPlayerChangeVehicleSeat(IntPtr vehicle, BaseObjectType type, byte oldSeat, byte newSeat)
        {
            _core.OnPlayerChangeVehicleSeat(vehicle, type, oldSeat, newSeat);
        }

        public static void OnPlayerChangeAnimation(IntPtr player, BaseObjectType type, uint oldDict, uint newDict, uint oldName, uint newName)
        {
            _core.OnPlayerChangeAnimation(player, type, oldDict, newDict, oldName, newName);
        }

        public static void OnPlayerChangeInterior(IntPtr player, BaseObjectType type, uint oldIntLoc, uint newIntLoc)
        {
            _core.OnPlayerChangeInterior(player, type, oldIntLoc, newIntLoc);
        }

        public static void OnPlayerWeaponShoot(uint weapon, ushort totalAmmo, ushort ammoInClip)
        {
            _core.OnPlayerWeaponShoot(weapon, totalAmmo, ammoInClip);
        }

        public static void OnPlayerWeaponChange(uint oldWeapon, uint newWeapon)
        {
            _core.OnPlayerWeaponChange(oldWeapon, newWeapon);
        }

        public static void OnWeaponDamage(IntPtr eventPointer, IntPtr entityPointer,
            BaseObjectType entityType, uint weapon, ushort damage, Position shotOffset, BodyPart bodyPart,
            IntPtr sourceEntityPointer, BaseObjectType sourceEntityType)
        {
            _core.OnWeaponDamage(eventPointer, entityPointer, entityType, weapon, damage, shotOffset, bodyPart, sourceEntityPointer, sourceEntityType);
        }

        public static void OnLocalMetaChange(string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnLocalMetaChange(key, value, oldValue);
        }

        public static void OnStreamSyncedMetaChange(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnStreamSyncedMetaChange(target, type, key, value, oldValue);
        }

        public static void OnSyncedMetaChange(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldValue)
        {
            _core.OnSyncedMetaChange(target, type, key, value, oldValue);
        }

        public static void OnTaskChange(int oldTask, int newTask)
        {
            _core.OnTaskChange(oldTask, newTask);
        }

        public static void OnWindowFocusChange(byte state)
        {
            _core.OnWindowFocusChange(state);
        }

        public static void OnWindowResolutionChange(Vector2 oldRes, Vector2 newRes)
        {
            _core.OnWindowResolutionChange(oldRes, newRes);
        }

        public static void OnNetOwnerChange(IntPtr target, BaseObjectType type, IntPtr newOwner, IntPtr oldOwner)
        {
            var playerPool = _core.PoolManager.Player.GetAllEntities().Select(x => x.PlayerNativePointer);
            _core.OnNetOwnerChange(target, type, newOwner, oldOwner);
        }

        public static void OnWorldObjectPositionChange(IntPtr target, BaseObjectType type, Position position)
        {
            _core.OnWorldObjectPositionChange(target, type, position);
        }

        public static void OnPlayerLeaveVehicle(IntPtr vehicle, BaseObjectType type, byte seat)
        {
            _core.OnPlayerLeaveVehicle(vehicle, type, seat);
        }

        public static void OnWorldObjectStreamIn(IntPtr target, BaseObjectType type)
        {
            _core.OnWorldObjectStreamIn(target, type);
        }

        public static void OnWorldObjectStreamOut(IntPtr target, BaseObjectType type)
        {
            _core.OnWorldObjectStreamOut(target, type);
        }

        public static void OnColShape(IntPtr colshapepointer, IntPtr targetentitypointer, BaseObjectType entitytype, byte state)
        {
            _core.OnColShape(colshapepointer, targetentitypointer, entitytype, state == 1);
        }

        public static void OnCheckpoint(IntPtr colshapepointer, IntPtr targetentitypointer, BaseObjectType entitytype, byte state)
        {
            _core.OnCheckpoint(colshapepointer, targetentitypointer, entitytype, state == 1);
        }

        public static void OnMetaChange(IntPtr target, BaseObjectType type, string key, IntPtr value, IntPtr oldvalue)
        {
            _core.OnMetaChange(target, type, key, value, oldvalue);
        }

        public static void OnPlayerStartEnterVehicle(IntPtr targetpointer, BaseObjectType type, IntPtr player, BaseObjectType playerType, byte seat)
        {
            _core.OnPlayerStartEnterVehicle(targetpointer, type, player, playerType, seat);
        }

        public static void OnPlayerStartLeaveVehicle(IntPtr targetpointer, BaseObjectType type, IntPtr player, BaseObjectType playerType, byte seat)
        {
            _core.OnPlayerStartLeaveVehicle(targetpointer, type, player, playerType, seat);
        }

        public static void OnEntityHitEntity(IntPtr targetpointer, BaseObjectType targettype, IntPtr damagerpointer, BaseObjectType damagertype, uint weaponhash)
        {
            _core.OnEntityHitEntity(targetpointer, targettype, damagerpointer, damagertype, weaponhash);
        }

        public static void OnPlayerBulletHit(uint weapon, IntPtr victimpointer, BaseObjectType victimtype, Position pos)
        {
            _core.OnPlayerBulletHit(weapon, victimpointer, victimtype, pos);
        }

        public static void OnVoiceConnection(VoiceConnectionState state)
        {
            _core.OnVoiceConnection(state);
        }

        public static void OnAudioEvent(IntPtr audio, string name, IntPtr pointer, ulong size)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int)size);
            }

            _core.OnAudioEvent(audio, name, args);
        }

        public static void OnScriptRPCAnswer(ushort answerid, IntPtr answer, string answerError)
        {
            _core.OnScriptRPCAnswer(answerid, answer, answerError);
        }

        public static void OnScriptRPC(IntPtr eventpointer, string name, IntPtr pointer, ulong size, ushort answerid)
        {
            var args = new IntPtr[size];
            if (pointer != IntPtr.Zero)
            {
                Marshal.Copy(pointer, args, 0, (int)size);
            }

            _core.OnScriptRPC(eventpointer, name, args, answerid);
        }
    }
}