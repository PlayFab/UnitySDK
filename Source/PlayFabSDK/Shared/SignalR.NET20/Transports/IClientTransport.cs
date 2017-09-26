#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
namespace SignalR.Client._20.Transports
{
    public interface IClientTransport
    {
        void Start(IConnection connection, string data);

        EventSignal<T> Send<T>(IConnection connection, string data);

        void Stop(IConnection connection);

        EventSignal<NegotiationResponse> Negotiate(IConnection connection);
    }
}

#endif