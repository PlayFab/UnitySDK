#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SignalR.Client._20.Http;
using PlayFab.Json;

namespace SignalR.Client._20.Transports
{
    public abstract class HttpBasedTransport : IClientTransport
    {
        // The receive query strings
        private const string c_receiveQueryStringWithGroups = "?transport={0}&connectionId={1}&messageId={2}&groups={3}&connectionData={4}{5}&connectionToken={6}&groupsToken={7}";
        private const string c_receiveQueryString = "?transport={0}&connectionId={1}&messageId={2}&connectionData={3}{4}&connectionToken={5}";

        private const string c_sendQueryString = "?transport={0}&connectionToken={1}{2}"; // The send query string
        protected readonly string m_transport; // The transport name
        protected const string c_httpRequestKey = "http.Request";
        protected readonly IHttpClient m_httpClient;

        public HttpBasedTransport(IHttpClient httpClient, string transport)
        {
            m_httpClient = httpClient;
            m_transport = transport;
        }

        public EventSignal<NegotiationResponse> Negotiate(IConnection connection)
        {
            return GetNegotiationResponse(m_httpClient, connection);
        }

        internal static EventSignal<NegotiationResponse> GetNegotiationResponse(
            IHttpClient httpClient,
            IConnection connection)
        {
            string _negotiateUrl = connection.Url + "negotiate";

            var _negotiateSignal = new EventSignal<NegotiationResponse>();
            var _signal = httpClient.GetAsync(_negotiateUrl, connection.PrepareRequest);

            _signal.Finished += (sender, e) =>
            {
                string _raw = e.Result.ReadAsString();
                if (_raw == null)
                    throw new InvalidOperationException("Server negotiation failed.");

                _negotiateSignal.OnFinish(PlayFabSimpleJson.DeserializeObject<NegotiationResponse>(_raw));
            };
            return _negotiateSignal;
        }

        public void Start(IConnection connection, string data)
        {
            OnStart(connection, data, () => { }, exception => { throw exception; });
        }

        protected abstract void OnStart(IConnection connection, string data, System.Action initializeCallback, Action<Exception> errorCallback);

        public EventSignal<T> Send<T>(IConnection connection, string data)
        {
            string _url = connection.Url + "send";
            string _customQueryString = GetCustomQueryString(connection);

            _url += String.Format(
                c_sendQueryString,
                m_transport,
                Uri.EscapeDataString(connection.ConnectionToken),
                _customQueryString);

            var _postData = new Dictionary<string, string> {
                { "data", data },
            };

            var _returnSignal = new EventSignal<T>();
            var _postSignal = m_httpClient.PostAsync(_url, connection.PrepareRequest, _postData);

            _postSignal.Finished += (sender, e) =>
            {
                string _raw = e.Result.ReadAsString();

                if (String.IsNullOrEmpty(_raw))
                {
                    _returnSignal.OnFinish(default(T));
                    return;
                }

                _returnSignal.OnFinish(PlayFabSimpleJson.DeserializeObject<T>(_raw));
            };
            return _returnSignal;
        }

        protected string GetReceiveQueryStringWithGroups(IConnection connection, string data)
        {
            return String.Format(
                c_receiveQueryStringWithGroups,
                m_transport,
                Uri.EscapeDataString(connection.ConnectionId),
                Convert.ToString(connection.MessageId),
                GetSerializedGroups(connection),
                data,
                GetCustomQueryString(connection),
                Uri.EscapeDataString(connection.ConnectionToken),
                connection.GroupsToken);
        }

        protected string GetSerializedGroups(IConnection connection)
        {
            return Uri.EscapeDataString(PlayFabSimpleJson.SerializeObject(connection.Groups));
        }

        protected string GetReceiveQueryString(IConnection connection, string data)
        {
            return String.Format(
                c_receiveQueryString,
                m_transport,
                Uri.EscapeDataString(connection.ConnectionId),
                Convert.ToString(connection.MessageId),
                data,
                GetCustomQueryString(connection),
                Uri.EscapeDataString(connection.ConnectionToken));
        }

        protected virtual Action<IRequest> PrepareRequest(IConnection connection)
        {
            return request =>
            {
                // Setup the user agent along with any other defaults
                connection.PrepareRequest(request);
                connection.Items[c_httpRequestKey] = request;
            };
        }

        public static bool IsRequestAborted(Exception exception)
        {
            var _webException = exception as WebException;
            return (_webException != null && _webException.Status == WebExceptionStatus.RequestCanceled);
        }

        public void Stop(IConnection connection)
        {
            var _httpRequest = ConnectionExtensions.GetValue<IRequest>(connection, c_httpRequestKey);
            if (_httpRequest != null)
            {
                try
                {
                    OnBeforeAbort(connection);
                    _httpRequest.Abort();
                }
                catch (NotImplementedException)
                {
                    // If this isn't implemented then do nothing
                }
            }
        }

        protected virtual void OnBeforeAbort(IConnection connection)
        {
        }

        public static void ProcessResponse(IConnection connection, string response, out bool timedOut, out bool disconnected)
        {
            timedOut = false;
            disconnected = false;

            if (String.IsNullOrEmpty(response))
                return;

            if (connection.MessageId == null)
                connection.MessageId = null;

            try
            {
                var _result = PlayFabSimpleJson.DeserializeObject<JsonObject>(response);

                if (!_result.Any())
                    return;

                timedOut = _result.ContainsKey("TimedOut") && bool.Parse(_result["TimedOut"].ToString());
                disconnected = _result.ContainsKey("Disconnect") && bool.Parse(_result["Disconnect"].ToString());

                if (disconnected)
                    return;

                var messages = _result["M"] as JsonArray;

                if (messages != null)
                {
                    foreach (var message in messages)
                    {
                        try
                        {
                            connection.OnReceived((JsonObject)message);
                        }
                        catch (Exception ex)
                        {
                            connection.OnError(ex);
                        }
                    }

                    connection.MessageId = _result.ContainsKey("C") ? _result["C"].ToString() : "";


                    JsonObject transportData = null;
                    object triedData;
                    if (_result.TryGetValue("T", out triedData))
                    {
                        transportData = triedData as JsonObject;
                    }

                    if (transportData != null)
                    {
                        var groups = (JsonArray)transportData["G"];
                        if (groups != null)
                        {
                            var groupList = new List<string>();
                            foreach (var groupFromTransport in groups)
                            {
                                groupList.Add(groupFromTransport.ToString());
                            }
                            connection.Groups = groupList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                connection.OnError(ex);
            }
        }

        private static string GetCustomQueryString(IConnection connection)
        {
            return String.IsNullOrEmpty(connection.QueryString)
                ? ""
                : "&" + connection.QueryString;
        }
    }
}

#endif