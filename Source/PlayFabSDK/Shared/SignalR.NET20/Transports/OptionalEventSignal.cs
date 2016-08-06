#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
namespace SignalR.Client._20.Transports
{
    public class OptionalEventSignal<T> : EventSignal<T>
    {
        protected override void handleNoEventHandler()
        {
        }
    }
}

#endif