#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using SignalR.Client._20.Http;
using SignalR.Client._20.Transports;
using System.IO;

namespace SignalR.Client._20.Infrastructure
{
    internal class StreamState
    {
        public Stream Stream { get; set; }
        public byte[] Buffer { get; set; }
        public EventSignal<CallbackDetail<int>> Response { get; set; }
    }
}

#endif