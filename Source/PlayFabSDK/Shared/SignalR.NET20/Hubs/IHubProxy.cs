#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using SignalR.Client._20.Transports;

namespace SignalR.Client._20.Hubs
{
    public interface IHubProxy
    {
        object this[string name] { get; set; }

        Subscription Subscribe(string eventName);

        EventSignal<object> Invoke(string method, params object[] args);

        EventSignal<T> Invoke<T>(string method, params object[] args);
    }
}

#endif