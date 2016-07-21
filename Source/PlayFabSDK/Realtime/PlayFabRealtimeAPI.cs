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
    /// APIs which provide the full range of PlayFab features available to the client - authentication, account and data management, inventory, friends, matchmaking, reporting, and platform-specific functionality
    /// </summary>
    public static class PlayFabRealtimeAPI
    {
        private const string RegisterFilterRequestName = "RegisterClientSubscriptionFilter";
        private const string UnregisterFilterRequestName = "UnregisterClientSubscriptionFilter";
        private const string OnReceiveEventCallbackChannel = "OnPushClientEvents";

        private static readonly Dictionary<string, Action<RealtimeConnectionResult>> InvokeBuffer = new Dictionary<string, Action<RealtimeConnectionResult>>();
        private static readonly List<string> SubscribedFilters = new List<string>();

        private static readonly Dictionary<string, Action<PlayStreamNotification>> eventHandlers = new Dictionary<string, Action<PlayStreamNotification>>();

        public static event Action OnConnected;
        public static event Action OnConnectionFailed;
        public static event Action OnDisconnected;

        private static bool IsConnected = false;
        
        public static void Start()
        {
            if (IsConnected) return;
            PlayFabHttp.InitializeRealtime(() =>
            {
                if (OnConnected != null)
                {
                    OnConnected();
                }

                SetupCallbacks();

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

        private static void SetupCallbacks()
        {
            SignalRController.instance.Subscribe(OnReceiveEventCallbackChannel, data =>
            {
                var notif = PlayFabSimpleJson.DeserializeObject<PlayStreamNotification>(data[0].ToString());

                if (eventHandlers != null)
                {
                    Action<PlayStreamNotification> handler;
                    if (eventHandlers.TryGetValue(notif.EventName, out handler))
                    {
                        handler(notif);
                    }
                }
            });
            SignalRController.instance.OnClosed(OnDisconnected);
        }

        private static void SendBufferedRequests()
        {
            foreach (var variable in InvokeBuffer)
            {
                Subscribe(variable.Key, variable.Value);
            }
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

            if (eventHandlers.ContainsKey(eventName))
            {
                eventHandlers[eventName] += newCallback;
            }
            else
            {
                eventHandlers.Add(eventName, newCallback);
            }

        }

        public static void StopConnection()
        {
            SignalRController.instance.StopConnetion();
        }

        public static void Subscribe(string filterName, Action<RealtimeConnectionResult> callback = null)
        {
            if (!IsConnected)
            {
                AddQueue(filterName, callback);
                return;
            }

            if (SubscribedFilters.Contains(filterName)) return;

            if (string.IsNullOrEmpty(filterName))
            {
                if (callback == null) return;
                callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Empty Params" });
                Debug.LogError("Request name cannot be null!");
                return;
            }

            SignalRController.instance.Invoke<string>(RegisterFilterRequestName, result =>
            {
                if (callback == null) return;
                if (string.IsNullOrEmpty(result))
                {
                    callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to get response", Error = RealtimeConnectionResult.ErrorCode.FailedGettingResponse });
                    return;
                }

                var serverResponse = PlayFabSimpleJson.DeserializeObject<RealtimeConnectionServerResponse>(result);
                if (serverResponse == null)
                {
                    callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to parse response", Error = RealtimeConnectionResult.ErrorCode.FailedParsingResponse });
                    return;
                }

                if (serverResponse.Success)
                {
                    SubscribedFilters.Add(filterName);
                    InvokeBuffer.Remove(filterName);
                    callback(new RealtimeConnectionResult { Success = true, ErrorMessage = "", Error = RealtimeConnectionResult.ErrorCode.Ok });
                }
                else
                {
                    callback(new RealtimeConnectionResult { Success = false, ErrorMessage = serverResponse.Detail, Error = RealtimeConnectionResult.ErrorCode.Unexpected });
                }
            }, filterName);
        }

        public static void Unsubscribe(Action<RealtimeConnectionResult> callback = null)
        {
            if (!IsConnected)
            {
                InvokeBuffer.Clear();
                return;
            }

            if (SubscribedFilters.Count <= 0) return;

            SignalRController.instance.Invoke<string>(UnregisterFilterRequestName, result =>
            {
                if (callback == null) return;
                if (string.IsNullOrEmpty(result))
                {
                    callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to get response", Error = RealtimeConnectionResult.ErrorCode.FailedGettingResponse });
                    return;
                }

                var serverResponse = PlayFabSimpleJson.DeserializeObject<RealtimeConnectionServerResponse>(result);
                if (serverResponse == null)
                {
                    callback(new RealtimeConnectionResult { Success = false, ErrorMessage = "Failed to parse response", Error = RealtimeConnectionResult.ErrorCode.FailedParsingResponse });
                    return;
                }

                if (serverResponse.Success)
                {
                    SubscribedFilters.Clear();
                    callback(new RealtimeConnectionResult { Success = true, ErrorMessage = "", Error = RealtimeConnectionResult.ErrorCode.Ok });
                }
                else
                {
                    callback(new RealtimeConnectionResult { Success = false, ErrorMessage = serverResponse.Detail, Error = RealtimeConnectionResult.ErrorCode.Unexpected });
                }
            });
        }

        private static void AddQueue(string filterName, Action<RealtimeConnectionResult> callback)
        {
            if (InvokeBuffer.ContainsKey(filterName))
            {
                InvokeBuffer[filterName] = callback;
            }
            else
            {
                InvokeBuffer.Add(filterName, callback);
            }
        }

        private sealed class RealtimeConnectionServerResponse
        {
            [JsonProperty(PropertyName = "success")]
            public bool Success { get; set; }

            [JsonProperty(PropertyName = "detail")]
            public string Detail { get; set; }
        }

        private sealed class PlayStreamNotification
        {

            [JsonProperty(PropertyName = "message")]
            public object RawMessage { get; set; }

            [JsonProperty(PropertyName = "eventName")]
            public string EventName { get; set; }

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
