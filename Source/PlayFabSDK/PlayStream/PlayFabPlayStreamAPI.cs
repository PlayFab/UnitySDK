#if ENABLE_PLAYFABPLAYSTREAM_API
using System;
using System.Collections.Generic;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// <para />APIs which provide PlayStream events subscription services - invoke subscription of Actions in PlayStream on GameManager, listen to specific types of PlayStream events.
    /// <para />Server only: NEVER use it on client.
    /// </summary>
    public static class PlayFabPlayStreamAPI
    {
        #region Private Events

        private static event Action OnSubscribed;
        private static event Action<SubscriptionError> OnFailed;

        #endregion

        public static event Action OnReconnected;
        public static event Action<string> OnReceived;
        public static event Action<Exception> OnError;
        public static event Action OnDisconnected;

        public static event Action<PlayStreamNotification> OnPlayStreamEvents;

        /// <summary>
        /// Start the SignalR connection asynchronously and subscribe to PlayStream events.
        /// </summary>
        public static void Start(Action onSubscribed = null, Action<SubscriptionError> onFailed = null)
        {
            OnSubscribed += onSubscribed;
            OnFailed += onFailed;
            PlayFabHttp.InitializeSignalR("http://playstreamlive.playfab.com/signalr", "EventStreamsHub", OnConnectedCallback, OnReceivedCallback, OnReconnectedCallback, OnDisconnectedCallback, OnErrorCallback);
        }

        /// <summary>
        /// Sends a disconnect request to the server and stop the SignalR connection.
        /// </summary>
        public static void Stop()
        {
            PlayFabHttp.StopSignalR();
        }

        #region Connection Callbacks

        private static void OnConnectedCallback()
        {
            PlayFabHttp.SubscribeSignalR("notifyNewMessage", OnPlayStreamNotificationCallback);
            PlayFabHttp.SubscribeSignalR("notifySubscriptionError", OnSubscriptionErrorCallback);
            PlayFabHttp.SubscribeSignalR("notifySubscriptionSuccess", OnSubscriptionSuccessCallback);
            PlayFabHttp.InvokeSignalR("SubscribeToQueue", null, PlayFabSettings.TitleId, PlayFabSettings.DeveloperSecretKey, "", false);
        }

        private static void OnPlayStreamNotificationCallback(object[] data)
        {
            var notif = Json.JsonWrapper.DeserializeObject<PlayStreamNotification>(data[0].ToString());
            if (OnPlayStreamEvents != null)
            {
                OnPlayStreamEvents(notif);
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
