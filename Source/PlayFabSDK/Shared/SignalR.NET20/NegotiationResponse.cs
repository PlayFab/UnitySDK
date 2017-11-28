#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API

namespace SignalR.Client._20
{
    //[DebuggerDisplay("{ConnectionId} {Url} -> {ProtocolVersion}")]
    public class NegotiationResponse
    {
        public string ConnectionId { get; set; }
        public string Url { get; set; }
        public string ProtocolVersion { get; set; }
        public string ConnectionToken { get; set; }
        public double DisconnectTimeout { get; set; }
        public bool TryWebSockets { get; set; }
        public double? KeepAliveTimeout { get; set; }
        public double TransportConnectTimeout { get; set; }
    }
}

#endif