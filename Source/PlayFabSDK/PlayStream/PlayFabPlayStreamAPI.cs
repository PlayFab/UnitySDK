#if ENABLE_PLAYFABPLAYSTREAM_API

using System;
using System.Collections.Generic;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// <para />APIs which provide realtime PlayStream events subscription services - invoke subscription of Actions in PlayStream on GameManager, listen to specific types of PlayStream events.
    /// <para />Should be only used in GameServer
    /// </summary>
    public static class PlayFabPlayStreamAPI
    {
        #region Private

        private const string ConnectionUrl = "http://playstreamlive.playfab.com/signalr";
        private const string HubName = "EventStreamsHub";
        private const string SubscribeToQueueInvocation = "SubscribeToQueue";
        private const string OnReceivedNewMessageCallback = "notifyNewMessage";
        private const string OnReceiveSubscriptionErrorCallback = "notifySubscriptionError";
        private const string OnReceiveSubscriptionSuccessCallback = "notifySubscriptionSuccess";

        private static bool _isConnected = false;

        private static event Action<string> OnReceiveSubscriptionError;
        private static event Action OnReceiveSubscriptionSuccess;
        #endregion

        public static event Action OnConnected;
        public static event Action OnConnectionFailed;
        public static event Action OnReconnected;
        public static event Action<string> OnReceived;
        public static event Action<Exception> OnError;
        public static event Action OnDisconnected;

        public static event Action<PlayStreamNotification> OnPlayStreamEvents;

        /// <summary>
        /// Start the realtime connection asynchronously.
        /// </summary>
        public static void Start()
        {
            if (_isConnected) return;
            PlayFabHttp.InitializeRealtime(ConnectionUrl, HubName, null, _onConnectedCallback, _onReceivedCallback, _onReconnectedCallback, _onDisconnectedCallback, _onErrorCallback);
        }

        /// <summary>
        /// Sends a disconnect request to the server and stop the transport.
        /// </summary>
        public static void Stop()
        {
            PlayFabHttp.StopRealtime();
        }

        /// <summary>
        /// <para />Invoke a subscription request to signal the server to start streaming playstream events for this title.
        /// <para />To define an Action that sends PlayStream events to clients, go to https://developer.playfab.com/en-us/[your_title]/event-actions
        /// </summary>
        /// <param name="errorCallback">=</param>
        public static void RequestEvents(Action<SubscriptionResponse> errorCallback = null)
        {
            if (!_isConnected)
            {
                return;
            }

            // parameters: Name of method on server, completion callback, titleId, dev secret key, playerId (empty to listen to all events for this title), should backfill last 10 events
            // Don't change this
            PlayFabHttp.InvokeRealtime(SubscribeToQueueInvocation, null, PlayFabSettings.TitleId, PlayFabSettings.DeveloperSecretKey, "", false);

            if (errorCallback == null)
            {
                return;
            }

            OnReceiveSubscriptionError += result =>
            {
                if (string.IsNullOrEmpty(result))
                {
                    errorCallback(SubscriptionResponse.FailWithUnexpected(""));
                }
                else
                {
                    switch (result)
                    {
                        case "Invalid Title Secret Key!":
                            errorCallback(SubscriptionResponse.InvalidSecretKey);
                            break;
                        default:
                            errorCallback(SubscriptionResponse.FailWithUnexpected(result));
                            break;
                    }
                }
            };

            OnReceiveSubscriptionSuccess += () =>
            {
                errorCallback(SubscriptionResponse.Ok);
            };
        }

        ///// <summary>
        ///// Event callback when received PlayStream events from server.
        ///// </summary>
        ///// <param name="callback"></param>
        //public static void Subscribe(Action<PlayStreamNotification> callback)
        //{
        //    if (string.IsNullOrEmpty(eventName))
        //    {
        //        var attrs = typeof(TEvent).GetCustomAttributes(typeof(PlayStreamEventAttribute), false);
        //        if (attrs.Length != 0)
        //            eventName = ((PlayStreamEventAttribute)attrs[0]).EventName;
        //        else
        //        {
        //            eventName = typeof(TEvent).Name;
        //            Debug.LogError("PlayStreamEventAttribute on " + eventName + " not found");
        //            return;
        //        }
        //    }

        //    var newCallback = new Action<PlayStreamNotification>(notification =>
        //    {
        //        try
        //        {
        //            callback(notification.ReadEvent<TEvent>());
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.LogException(e);
        //        }
        //    });
        //}

        #region Private

        /// <summary>
        /// <para /> Automatically subscribed to the server when connection is established
        /// </summary>
        private static void SubscribeToServer()
        {
            PlayFabHttp.SubscribeRealtime(OnReceiveSubscriptionErrorCallback, data =>
            {
                var message = data[0] as string;
                if (OnReceiveSubscriptionError != null)
                {
                    OnReceiveSubscriptionError(message);
                }
            });

            PlayFabHttp.SubscribeRealtime(OnReceiveSubscriptionSuccessCallback, data =>
            {
                var message = data[0] as string;
                if (OnReceiveSubscriptionSuccess != null)
                {
                    OnReceiveSubscriptionSuccess();
                }

            });

            PlayFabHttp.SubscribeRealtime(OnReceivedNewMessageCallback, OnPlayStreamNotificationDataReceived);
        }

        /// <summary>
        /// A callback 
        /// </summary>
        /// <param name="data"></param>
        private static void OnPlayStreamNotificationDataReceived(object[] data)
        {
            var notif = Json.PlayFabSimpleJson.DeserializeObject<PlayStreamNotification>(data[0].ToString());
            if (OnPlayStreamEvents != null)
            {
                OnPlayStreamEvents(notif);
            }
        }

        #region Connection Callbacks

        private static void _onConnectedCallback()
        {
            _isConnected = true;
            SubscribeToServer();
            if (OnConnected != null)
            {
                OnConnected();
            }
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

        #endregion

    }

    /// <summary>
    /// <para />The server message wrapper for PlayStream events. 
    /// <para />Should be used to deserialize EventObject into its appropriate types by EventName, TntityType, and EventNamespace. Do not modify.
    /// </summary>
    public sealed class PlayStreamNotification
    {
        //metadata sent by server
        public string EventName;
        public string EntityType;
        public string EventNamespace;
        public string PlayerId;
        public string TitleId;

        public PlayStreamEvent EventObject;
        public PlayerProfile Profile;
        public List<object> TriggerResults;
        public List<object> SegmentMatchResults;

        public class PlayStreamEvent
        {
            public object EventData;
            public object InternalState;
        }

        public class PlayerProfile
        {
            public string PlayerId;
            public string TitleId;
            public object DisplayName;
            public string Origination;
            public object Created;
            public object LastLogin;
            public object BannedUntil;
            public Dictionary<string, int> Statistics;
            public Dictionary<string, int> VirtualCurrencyBalances;
            public List<object> AdCampaignAttributions;
            public List<object> PushNotificationRegistrations;
            public List<LinkedAccount> LinkedAccounts;

            public class LinkedAccount
            {
                public string Platform;
                public string PlatformUserId;
            }
        }
    }

    /// <summary>
    /// The response from the server when sending PlayStream subscription request.
    /// </summary>
    public struct SubscriptionResponse
    {
        public StatusCode Status;
        public string Message;

        public enum StatusCode
        {
            Ok,
            Unexpected,
            InvalidSecretKey
        }

        public static SubscriptionResponse Ok
        {
            get
            {
                return new SubscriptionResponse() { Message = null, Status = StatusCode.Ok };
            }
        }

        public static SubscriptionResponse InvalidSecretKey
        {
            get
            {
                return new SubscriptionResponse() { Message = "Invalid Token", Status = StatusCode.InvalidSecretKey };
            }
        }

        public static SubscriptionResponse FailWithUnexpected(string message)
        {
            return new SubscriptionResponse() { Message = message, Status = StatusCode.Unexpected };

        }
    }
}

#endif
