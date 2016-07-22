#if ENABLE_PLAYSTREAM_REALTIME

using System;
using System.Collections.Generic;
using PlayFab.Json;
using PlayFab.Internal;
using PlayFab.Realtime.Event;
using UnityEngine;

namespace PlayFab.Realtime
{
    /// <summary>
    /// APIs which provide realtime PlayStream events subscription services - invoke subscription of Actions in PlayStream on GameManager, listen to specific types of PlayStream events.
    /// </summary>
    public static class PlayFabRealtimeAPI
    {

        #region Private

        private const string ConnectionUrl = "http://playstreamlive.playfabdev.com/signalr";
        private const string HubName = "SubscriptionHub";
        private const string RegisterFilterRequestInvocation = "RegisterClientSubscriptionFilter";
        private const string UnregisterFilterRequestInvocation = "UnregisterClientSubscriptionFilter";
        private const string OnInvokedCallbackName = "OnPushClientEvents";

        /// <summary>
        /// A container for all requested subscriptions when the connection has not been established
        /// </summary>
        private static readonly Dictionary<string, Action<SubscriptionRequestResponse>> RequestsOfflineCache = new Dictionary<string, Action<SubscriptionRequestResponse>>();

        private static bool _isConnected = false;
        private static readonly List<string> SubscribedFilters = new List<string>();

        /// <summary>
        /// A dictionary of PlayStream events with their handlers, mapped by the event name
        /// </summary>
        private static readonly Dictionary<string, Action<PlayStreamNotification>> RegisteredHandlers = new Dictionary<string, Action<PlayStreamNotification>>();

        #endregion

        public static event Action OnConnected;
        public static event Action OnConnectionFailed;
        public static event Action OnReconnected;
        public static event Action<string> OnReceived;
        public static event Action<Exception> OnError;
        public static event Action OnDisconnected;

        public static bool IsConnected
        {
            get { return _isConnected; }
        }

        /// <summary>
        /// Start the realtime connection asynchronously.
        /// </summary>
        public static void Start()
        {
            if (_isConnected) return;
            PlayFabHttp.InitializeRealtime(ConnectionUrl, HubName, _onConnectedCallback, _onReceivedCallback, _onReconnectedCallback, _onDisconnectedCallback, _onErrorCallback);
        }

        /// <summary>
        /// Sends a disconnect request to the server and stop the transport.
        /// </summary>
        public static void Stop()
        {
            PlayFabHttp.StopRealtime();
        }

        /// <summary>
        /// <para />Invoke a subscription request to signal the server to start streaming playstream events. The name of the action must be defined on GameManager. 
        /// <para />To define an Action that sends PlayStream events to clients, go to https://developer.playfab.com/en-us/[your_title]/event-actions
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="callback">=</param>
        public static void InvokeSubscriptionRequest(string actionName, Action<SubscriptionRequestResponse> callback = null)
        {
            if (!_isConnected)
            {
                RequestsOfflineCache[actionName] = callback;
                return;
            }

            if (SubscribedFilters.Contains(actionName)) return;

            if (string.IsNullOrEmpty(actionName))
            {
                if (callback == null) return;
                callback(new SubscriptionRequestResponse { Success = false, ErrorMessage = "Empty Params" });
                return;
            }

            PlayFabHttp.InvokeRealtime<string>(RegisterFilterRequestInvocation, result =>
            {
                if (string.IsNullOrEmpty(result))
                {
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = false, ErrorMessage = "Failed to get response", Error = SubscriptionRequestResponse.ErrorCode.FailedGettingResponse });
                    }
                    return;
                }

                var serverResponse = PlayFabSimpleJson.DeserializeObject<RequestResponse>(result);
                if (serverResponse == null)
                {
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = false, ErrorMessage = "Failed to parse response", Error = SubscriptionRequestResponse.ErrorCode.FailedParsingResponse });
                    }
                    return;
                }
                if (serverResponse.Success)
                {
                    SubscribedFilters.Add(actionName);
                    RequestsOfflineCache.Remove(actionName);
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = true, ErrorMessage = "", Error = SubscriptionRequestResponse.ErrorCode.Ok });
                    }
                }
                else
                {
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = false, ErrorMessage = serverResponse.Detail, Error = SubscriptionRequestResponse.ErrorCode.Unexpected });
                    }
                }
            }, actionName);
        }

        /// <summary>
        /// <para />Invoke a request to signal the server to stop sending playstream events.
        /// </summary>
        /// <param name="callback"></param>
        public static void InvokeUnsubscriptionRequest(Action<SubscriptionRequestResponse> callback = null)
        {
            // if the connection has not been established and there are local cache already, clear the local cache.
            if (!_isConnected)
            {
                RequestsOfflineCache.Clear();
                return;
            }

            if (SubscribedFilters.Count <= 0) return;

            PlayFabHttp.InvokeRealtime<string>(UnregisterFilterRequestInvocation, result =>
            {
                if (string.IsNullOrEmpty(result))
                {
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = false, ErrorMessage = "Failed to get response", Error = SubscriptionRequestResponse.ErrorCode.FailedGettingResponse });
                    }
                    return;
                }

                var serverResponse = PlayFabSimpleJson.DeserializeObject<RequestResponse>(result);
                if (serverResponse == null)
                {
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = false, ErrorMessage = "Failed to parse response: " + result, Error = SubscriptionRequestResponse.ErrorCode.FailedParsingResponse });
                    }
                    return;
                }

                if (serverResponse.Success)
                {
                    SubscribedFilters.Clear();
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = true, ErrorMessage = null, Error = SubscriptionRequestResponse.ErrorCode.Ok });
                    }
                }
                else
                {
                    if (callback != null)
                    {
                        callback(new SubscriptionRequestResponse { Success = false, ErrorMessage = serverResponse.Detail, Error = SubscriptionRequestResponse.ErrorCode.Unexpected });
                    }
                }
            });

        }

        /// <summary>
        /// <para />Event Callback when received PlayStream events from server.
        /// <para />To define a custom event, inherit it from PlayFab.Realtime.Events.EventBase and add a name as EventNameAttribute, or pass the name as an optional parameter <paramref name="eventName"/> for it to be properly serialized.
        /// </summary>
        /// <paramref name="callback"/>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="callback"></param>
        /// <param name="eventName"></param>
        public static void Subscribe<TEvent>(Action<TEvent> callback, string eventName = null) where TEvent : EventBase, new()
        {
            if (string.IsNullOrEmpty(eventName))
            {
                var attrs = typeof(TEvent).GetCustomAttributes(typeof(EventNameAttribute), false);
                if (attrs.Length != 0)
                    eventName = ((EventNameAttribute)attrs[0]).EventName;
                else
                {
                    eventName = typeof(TEvent).Name;
                    Debug.LogError("EventNameAttribute on " + eventName + " not found");
                }
            }

            var newCallback = new Action<PlayStreamNotification>(notification =>
            {
                try
                {
                    callback(notification.ReadEvent<TEvent>());
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            });

            if (RegisteredHandlers.ContainsKey(eventName))
            {
                RegisteredHandlers[eventName] += newCallback;
            }
            else
            {
                RegisteredHandlers.Add(eventName, newCallback);
            }

        }

        #region Connection Callbacks

        private static void _onConnectedCallback()
        {
            if (OnConnected != null)
            {
                OnConnected();
            }

            _isConnected = true;
            foreach (var variable in RequestsOfflineCache)
            {
                InvokeSubscriptionRequest(variable.Key, variable.Value);
            }
            SubscribeToServer();
        }

        private static void _onReceivedCallback(string msg)
        {
            if (OnReceived != null)
            {
                OnReceived(msg);
            }
        }

        private static void _onReconnectedCallback()
        {
            if (OnReconnected != null)
            {
                OnReconnected();
            }
        }

        private static void _onDisconnectedCallback()
        {
            if (OnDisconnected != null)
            {
                OnDisconnected();
            }
        }

        private static void _onErrorCallback(Exception ex)
        {
            var timeoutEx = ex as TimeoutException;
            if (timeoutEx != null)
            {
                if (OnDisconnected != null)
                {
                    OnDisconnected();
                }
            }
            else
            {
                if (OnError != null)
                {
                    OnError(ex);
                }
            }
        }

        #endregion

        /// <summary>
        /// <para /> Automatically subscribed to the server when connection is established
        /// </summary>
        private static void SubscribeToServer()
        {
            PlayFabHttp.SubscribeRealtime(OnInvokedCallbackName, data =>
            {
                var notif = PlayFabSimpleJson.DeserializeObject<PlayStreamNotification>(data[0].ToString());

                if (RegisteredHandlers != null)
                {
                    Action<PlayStreamNotification> handler;
                    if (RegisteredHandlers.TryGetValue(notif.EventName, out handler))
                    {
                        handler(notif);
                    }
                }
            });
        }

        /// <summary>
        /// Server response when making event listening requests
        /// </summary>
        private sealed class RequestResponse
        {
            [JsonProperty("success")]
            public bool Success;

            [JsonProperty("detail")]
            public string Detail;
        }

        /// <summary>
        /// The server message wrapper for PlayStream events. It is used to deserialize PlayStream events into appropriate types by eventName
        /// </summary>
        private sealed class PlayStreamNotification
        {

            [JsonProperty("message")]
            public object RawMessage;

            [JsonProperty("eventName")]
            public string EventName;

            public TEventData ReadEvent<TEventData>() where TEventData : EventBase
            {
                return PlayFabSimpleJson.DeserializeObject<TEventData>(RawMessage.ToString());
            }

        }
    }

    public class SubscriptionRequestResponse
    {
        public enum ErrorCode
        {
            Ok = 0,
            Unexpected = 1,
            FailedGettingResponse = 100,
            FailedParsingResponse = 101
        }

        public bool Success;

        public ErrorCode Error;

        public string ErrorMessage;
    }
}

#endif
