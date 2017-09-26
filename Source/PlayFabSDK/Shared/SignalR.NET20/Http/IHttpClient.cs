#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using SignalR.Client._20.Transports;

namespace SignalR.Client._20.Http
{
    public interface IHttpClient
    {
        EventSignal<IResponse> GetAsync(string url, Action<IRequest> prepareRequest);

        EventSignal<IResponse> PostAsync(string url, Action<IRequest> prepareRequest, Dictionary<string, string> postData);
    }
}

#endif