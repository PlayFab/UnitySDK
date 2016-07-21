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
    /// To define an Action that sends PlayStream events to clients, go to https://developer.playfab.com/en-us/[your_title]/event-actions
    /// </summary>
    public static class PlayFabRealtimeAPI
    {

        private static readonly string ConnectionUrl = "http://playstreamlive.playfabdev.com/signalr";
        private static readonly string HubName = "SubscriptionHub";
        private const string RegisterFilterRequestName = "RegisterClientSubscriptionFilter";
        private const string UnregisterFilterRequestName = "UnregisterClientSubscriptionFilter";
        private const string OnReceiveEventCallbackChannel = "OnPushClientEvents";

        private static readonly Dictionary<string, Action<RealtimeConnectionResult>> RequestsOfflineCache = new Dictionary<string, Action<RealtimeConnectionResult>>();

        private static bool _isConnected = false;
        private static readonly List<string> SubscribedFilters = new List<string>();
        private static readonly Dictionary<string, Action<PlayStreamNotification>> RegisteredHandlers = new Dictionary<string, Action<PlayStreamNotification>>();

        public static event Action OnConnected;
        public static event Action OnConnectionFailed;
        public static event Action OnDisconnected;

        public static void Start()
        {
            if (_isConnected) return;
            PlayFabHttp.InitializeRealtime(ConnectionUrl, HubName, () =>
            {
                if (OnConnected != null)
                {
                    OnConnected();
                }
                _isConnected = true;
                SetupCallbacks();
                SendBufferedRequests();
            }, () =>
            {
                if (OnConnectionFailed != null)
                {
                    OnConnectionFailed();
                }
            });

            //SignalRController.instance.AuthToken = Token;
            //SignalRController.instance.StartConnection(TimeOut);
            //SignalRController.instance.OnConnected = () =>
            //{
            //    IsConnected = true;
            //    SetupCallbacks();
            //    SendBufferedRequests();

            //    if (OnConnected != null)
            //    {
            //        OnConnected();
            //    }
            //};
            //SignalRController.instance.OnConnectionFailed = () =>
            //{
            //    if (OnConnectionFailed != null)
            //    {
            //        OnConnectionFailed(new RealtimeConnectionResult { Error = RealtimeConnectionResult.ErrorCode.Unexpected, ErrorMessage = "Failed to connect to server", Success = false });
            //    }
            //};

        }

        public static void Stop()
        {
            PlayFabHttp.StopRealtime();
        }

        public static void InvokeSubscriptionRequest(string filterName, Action<RealtimeConnectionResult> callback = null)
        {
            if (!_isConnected)
            {
                AddQueue(filterName, callback);
                return;
            }

            if (SubscribedFilters.Contains(filterName)) return;

            if (string.IsNullOrEmpty(filterName))
            {
                if (callback == null) return;
                callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Empty Params" });
                return;
            }

            PlayFabHttp.InvokeRealtime<string>(RegisterFilterRequestName, result =>
            {
                if (string.IsNullOrEmpty(result))
                {
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to get response", Error = RealtimeConnectionResult.ErrorCode.FailedGettingResponse });
                    }
                    return;
                }

                var serverResponse = PlayFabSimpleJson.DeserializeObject<RealtimeConnectionServerResponse>(result);
                if (serverResponse == null)
                {
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to parse response", Error = RealtimeConnectionResult.ErrorCode.FailedParsingResponse });
                    }
                    return;
                }
                if (serverResponse.Success)
                {
                    SubscribedFilters.Add(filterName);
                    RequestsOfflineCache.Remove(filterName);
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = true, ErrorMessage = "", Error = RealtimeConnectionResult.ErrorCode.Ok });
                    }
                }
                else
                {
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = false, ErrorMessage = serverResponse.Detail, Error = RealtimeConnectionResult.ErrorCode.Unexpected });
                    }
                }
            }, filterName);
        }

        public static void InvokeUnsubscriptionRequest(Action<RealtimeConnectionResult> callback = null)
        {
            // if the connection has not been established, clear the local cache.
            if (!_isConnected)
            {
                RequestsOfflineCache.Clear();
                return;
            }

            if (SubscribedFilters.Count <= 0) return;

            PlayFabHttp.InvokeRealtime<string>(UnregisterFilterRequestName, result =>
            {
                if (string.IsNullOrEmpty(result))
                {
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to get response", Error = RealtimeConnectionResult.ErrorCode.FailedGettingResponse });
                    }
                    return;
                }

                var serverResponse = PlayFabSimpleJson.DeserializeObject<RealtimeConnectionServerResponse>(result);
                if (serverResponse == null)
                {
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to parse response: " + result, Error = RealtimeConnectionResult.ErrorCode.FailedParsingResponse });
                    }
                    return;
                }

                if (serverResponse.Success)
                {
                    SubscribedFilters.Clear();
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = true, ErrorMessage = "", Error = RealtimeConnectionResult.ErrorCode.Ok });
                    }
                }
                else
                {
                    if (callback != null)
                    {
                        callback(new RealtimeConnectionResult { Success = false, ErrorMessage = serverResponse.Detail, Error = RealtimeConnectionResult.ErrorCode.Unexpected });
                    }
                }
            });

        }

        public static void RegisterHandler<TEvent>(Action<TEvent> callback, string eventName = null) where TEvent : EventBase, new()
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

        private static void SetupCallbacks()
        {
            PlayFabHttp.SubscribeRealtime(OnReceiveEventCallbackChannel, data =>
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

        private static void SendBufferedRequests()
        {
            foreach (var variable in RequestsOfflineCache)
            {
                InvokeSubscriptionRequest(variable.Key, variable.Value);
            }
        }

        private static void AddQueue(string filterName, Action<RealtimeConnectionResult> callback)
        {
            if (RequestsOfflineCache.ContainsKey(filterName))
            {
                RequestsOfflineCache[filterName] = callback;
            }
            else
            {
                RequestsOfflineCache.Add(filterName, callback);
            }
        }

        private sealed class RealtimeConnectionServerResponse
        {
            [JsonProperty(PropertyName = "success")]
            public bool Success;

            [JsonProperty(PropertyName = "detail")]
            public string Detail;
        }

        private sealed class PlayStreamNotification
        {

            [JsonProperty(PropertyName = "message")]
            public object RawMessage;

            [JsonProperty(PropertyName = "eventName")]
            public string EventName;

            public TEventData ReadEvent<TEventData>() where TEventData : EventBase
            {
                return PlayFabSimpleJson.DeserializeObject<TEventData>(RawMessage.ToString());
            }

        }
    }

    public class RealtimeConnectionResult
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
