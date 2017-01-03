#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// <para />APIs which allow game servers to subscribe to PlayStream events for a specific title
    /// <para />This API is server only, and should NEVER be used on clients.
    /// </summary>
    public static class PlayFabPlayStreamAPI
    {
        static PlayFabPlayStreamAPI() { }

        /// <summary>
        /// The event when successfully subcribed to PlayStream.
        /// </summary>
        public static event Action OnSubscribed;

        /// <summary>
        /// The event when failed to subcribe events from PlayStream server.
        /// </summary>
        public static event Action<SubscriptionError> OnFailed;

        /// <summary>
        /// <para />This is the event when a PlayStream event is received from the server.
        /// </summary>
        public static event Action<PlayStreamNotification> OnPlayStreamEvent;

#region Connection Status Events

        /// <summary>
        /// The debug event when reconnected to the PlayStream server. 
        /// </summary>
        public static event Action OnReconnected;

        /// <summary>
        /// The debug event when received anything from the PlayStream server. This gives the raw message received from the server and should be used for debug purposes. 
        /// </summary>
        public static event Action<string> OnReceived;

        /// <summary>
        /// The debug event when an error occurs. 
        /// </summary>
        public static event Action<Exception> OnError;

        /// <summary>
        /// The debug event when disconnected from the PlayStream server. 
        /// </summary>
        public static event Action OnDisconnected;

#endregion

        /// <summary>
        /// Start the SignalR connection asynchronously and subscribe to PlayStream events if successfully connected.
        /// Optionally pass an filter id to only be subscribed to specific types of PlayStream events. Event filters can be configured on GameManager.
        /// </summary>
        public static void Start(string eventFilterId = null)
        {
            Action connetionCallback = () =>
            {
                OnConnectedCallback(eventFilterId);
            };
            PlayFabHttp.InitializeSignalR(PlayFabSettings.ProductionEnvironmentPlayStreamUrl, "EventStreamsHub", connetionCallback, OnReceivedCallback, OnReconnectedCallback, OnDisconnectedCallback, OnErrorCallback);
        }

        /// <summary>
        /// Sends a disconnect request to the server and stop the SignalR connection.
        /// </summary>
        public static void Stop()
        {
            PlayFabHttp.StopSignalR();
        }

#region Connection Callbacks

        private static void OnConnectedCallback(string filter)
        {
            PlayFabHttp.SubscribeSignalR("notifyNewMessage", OnPlayStreamNotificationCallback);
            PlayFabHttp.SubscribeSignalR("notifySubscriptionError", OnSubscriptionErrorCallback);
            PlayFabHttp.SubscribeSignalR("notifySubscriptionSuccess", OnSubscriptionSuccessCallback);
            var queueRequest = new
            {
                TitleId = PlayFabSettings.TitleId,
                TitleSecret = PlayFabSettings.DeveloperSecretKey,
                BackFill = false,
                EventFilter = filter
            };
            PlayFabHttp.InvokeSignalR("SubscribeToQueue", null, queueRequest);
        }

        private static void OnPlayStreamNotificationCallback(object[] data)
        {
            var notif = Json.JsonWrapper.DeserializeObject<PlayStreamNotification>(data[0].ToString());
            if (OnPlayStreamEvent != null)
            {
                OnPlayStreamEvent(notif);
            }
        }

        private static void OnSubscriptionErrorCallback(object[] data)
        {
            var message = data[0] as string;
            if (OnFailed != null)
            {
                if (message == "Invalid Title Secret Key!")
                {
                    OnFailed(SubscriptionError.InvalidSecretKey);
                }
                else
                {
                    OnFailed(SubscriptionError.FailWithUnexpected(message));
                }
            }
        }

        private static void OnSubscriptionSuccessCallback(object[] data)
        {
            if (OnSubscribed != null)
            {
                OnSubscribed();
            }
        }

        private static void OnReconnectedCallback()
        {
            if (OnReconnected != null)
            {
                OnReconnected();
            }
        }

        private static void OnReceivedCallback(string msg)
        {
            if (OnReceived != null)
            {
                OnReceived(msg);
            }
        }

        private static void OnErrorCallback(Exception ex)
        {
            var timeoutEx = ex as TimeoutException;
            if (timeoutEx != null)
            {
                if (OnFailed != null)
                {
                    OnFailed(SubscriptionError.ConnectionTimeout);
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

        private static void OnDisconnectedCallback()
        {
            if (OnDisconnected != null)
            {
                OnDisconnected();
            }
        }


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
    /// The error code of PlayStream subscription result.
    /// </summary>
    public struct SubscriptionError
    {
        public ErrorCode Code;
        public string Message;

        public enum ErrorCode
        {
            Unexpected = 400,
            ConnectionTimeout = 401,
            InvalidSecretKey = 402
        }

        public static SubscriptionError ConnectionTimeout
        {
            get
            {
                return new SubscriptionError() { Message = "Connection Timeout", Code = ErrorCode.ConnectionTimeout };
            }
        }

        public static SubscriptionError InvalidSecretKey
        {
            get
            {
                return new SubscriptionError() { Message = "Invalid Secret Key", Code = ErrorCode.InvalidSecretKey };
            }
        }

        public static SubscriptionError FailWithUnexpected(string message)
        {
            return new SubscriptionError() { Message = message, Code = ErrorCode.Unexpected };
        }
    }
}

#endif
