#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using System.Net;
using SignalR.Client._20.Http;
using SignalR.Client._20.Transports;
using PlayFab.Json;

namespace SignalR.Client._20
{
    public interface IConnection
    {
        bool IsActive { get; }
        string MessageId { get; set; }
        Func<string> Sending { get; set; }
        IEnumerable<string> Groups { get; set; }
        IDictionary<string, object> Items { get; }
        string ConnectionId { get; }
        string Url { get; }
        string QueryString { get; }
        string ConnectionToken { get; }
        string GroupsToken { get; }

        ICredentials Credentials { get; set; }
        CookieContainer CookieContainer { get; set; }

        event Action Closed;
        event Action<Exception> Error;
        event Action<string> Received;

        void Stop();
        EventSignal<object> Send(string data);
        EventSignal<T> Send<T>(string data);

        void OnReceived(JsonObject data);
        void OnError(Exception ex);
        void OnReconnected();
        void PrepareRequest(IRequest request);
    }
}

#endif