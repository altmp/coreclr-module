using AltV.Net.Client.Events;

namespace AltV.Net.Client
{
    internal class NativeConnectionCompleteEventHandler : NativeEventHandler<ConnectionCompleteEventDelegate, ConnectionCompleteEventDelegate>
    {
        private readonly ConnectionCompleteEventDelegate connectionCompleteEventDelegate;

        public NativeConnectionCompleteEventHandler()
        {
            connectionCompleteEventDelegate = new ConnectionCompleteEventDelegate(OnConnectionComplete);
        }

        public void OnConnectionComplete()
        {
            var scriptEventHandler = EventHandlers.First;
            while (scriptEventHandler != null)
            {
                scriptEventHandler.Value();
                scriptEventHandler = scriptEventHandler.Next;
            }
        }

        public override ConnectionCompleteEventDelegate GetNativeEventHandler()
        {
            return connectionCompleteEventDelegate;
        }
    }
}