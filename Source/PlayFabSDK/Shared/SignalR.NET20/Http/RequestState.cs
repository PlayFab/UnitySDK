#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using SignalR.Client._20.Transports;
using System.Net;

namespace SignalR.Client._20.Http
{
    public class RequestState
    {
        public HttpWebRequest Request { get; set; }
        public EventSignal<CallbackDetail<HttpWebResponse>> Response { get; set; }
        public byte[] PostData { get; set; }
    }
}

#endif