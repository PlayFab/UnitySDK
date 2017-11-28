#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;
using SignalR.Client._20.Transports;

namespace SignalR.Client._20.Http
{
    public static class IHttpClientExtensions
    {
        public static EventSignal<IResponse> PostAsync(
            IHttpClient client,
            string url,
            Action<IRequest> prepareRequest)
        {
            return client.PostAsync(url, prepareRequest, null);
        }
    }
}

#endif