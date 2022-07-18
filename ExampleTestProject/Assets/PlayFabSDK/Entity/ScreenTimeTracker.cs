#if !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFABCLIENT_API
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayFab.Public
{
    /// <summary>
    /// Interface which can be used to implement class responsible for gathering and sending information about session.
    /// </summary>
    public interface IScreenTimeTracker
    {
        // Unity MonoBehaviour callbacks
        void OnEnable();
        void OnDisable();
        void OnDestroy();
        void OnApplicationQuit();
        void OnApplicationFocus(bool isFocused);

        // Class specific methods
        void ClientSessionStart(string entityId, string entityType, string playFabUserId);
        void Send();
    }

    /// <summary>
    /// Class responsible for gathering and sending information about session, for example: focus duration, device info, etc.
    /// </summary>
    public class ScreenTimeTracker : IScreenTimeTracker
    {
        private Guid focusId;
        private Guid gameSessionID;
        private bool initialFocus = true;
        private bool isSending = false;
        private DateTime focusOffDateTime = DateTime.UtcNow;
        private DateTime focusOnDateTime = DateTime.UtcNow;

        private Queue<EventsModels.EventContents> eventsRequests = new Queue<EventsModels.EventContents>();

        private EventsModels.EntityKey entityKey = new EventsModels.EntityKey();
        private const string eventNamespace = "com.playfab.events.sessions";
        private const int maxBatchSizeInEvents = 10;

        private PlayFabEventsInstanceAPI eventApi;

        public ScreenTimeTracker()
        {
            eventApi = new PlayFabEventsInstanceAPI(PlayFabSettings.staticPlayer);
        }

        private void EnsureSingleGameSessionId()
        {
            if (gameSessionID == Guid.Empty)
            {
                gameSessionID = Guid.NewGuid();
            }
        }

        /// <summary>
        /// Start session, the function responsible for creating SessionID and gathering information about user and device
        /// </summary>
        /// <param name="playFabUserId">Result of the user's login, represent user ID</param>
        public void ClientSessionStart(string entityId, string entityType, string playFabUserId)
        {
            EnsureSingleGameSessionId();

            entityKey.Id = entityId;
            entityKey.Type = entityType;

            EventsModels.EventContents eventInfo = new EventsModels.EventContents();

            eventInfo.Name = "client_session_start";
            eventInfo.EventNamespace = eventNamespace;
            eventInfo.Entity = entityKey;
            eventInfo.OriginalTimestamp = DateTime.UtcNow;

            var payload = new Dictionary<string, object>
                {
                    { "UserID", playFabUserId},
                    { "DeviceType", SystemInfo.deviceType},
                    { "DeviceModel", SystemInfo.deviceModel},
                    { "OS", SystemInfo.operatingSystem },
                    { "ClientSessionID", gameSessionID },
                };

            eventInfo.Payload = payload;
            eventsRequests.Enqueue(eventInfo);

            // Fake a focus-on event at the time of the first login:
            OnApplicationFocus(true);
        }

        /// <summary>
        /// Gather information about user's focus. Calculates interaction durations.
        /// Name mimics MonoBehaviour method, for ease of integration.
        /// </summary>
        /// <param name="isFocused">State of focus</param>
        public void OnApplicationFocus(bool isFocused)
        {
            EnsureSingleGameSessionId();
            EventsModels.EventContents eventInfo = new EventsModels.EventContents();
            DateTime currentUtcDateTime = DateTime.UtcNow;

            eventInfo.Name = "client_focus_change";
            eventInfo.EventNamespace = eventNamespace;
            eventInfo.Entity = entityKey;

            double focusStateDuration = 0.0;

            if (initialFocus)
            {
                focusId = Guid.NewGuid();
            }

            if (isFocused)
            {
                // start counting focus-on time
                focusOnDateTime = currentUtcDateTime;

                // new id per focus
                focusId = Guid.NewGuid();

                if (!initialFocus)
                {
                    focusStateDuration = (currentUtcDateTime - focusOffDateTime).TotalSeconds;

                    // this check safeguards from manual time changes while app is running
                    if (focusStateDuration < 0)
                    {
                        focusStateDuration = 0;
                    }
                }
            }
            else
            {
                focusStateDuration = (currentUtcDateTime - focusOnDateTime).TotalSeconds;

                // this check safeguards from manual time changes while app is running
                if (focusStateDuration < 0)
                {
                    focusStateDuration = 0;
                }

                // start counting focus-off time
                focusOffDateTime = currentUtcDateTime;
            }

            var payload = new Dictionary<string, object> {
                    { "FocusID", focusId },
                    { "FocusState", isFocused },
                    { "FocusStateDuration", focusStateDuration },
                    { "EventTimestamp", currentUtcDateTime },
                    { "ClientSessionID", gameSessionID },
                };

            eventInfo.OriginalTimestamp = currentUtcDateTime;
            eventInfo.Payload = payload;
            eventsRequests.Enqueue(eventInfo);

            initialFocus = false;

            if (!isFocused)
            {
                // Force the eventsRequests queue to empty.
                // If we are losing focus we should make an attempt to push out a focus lost event ASAP
                Send();
            }

        }

        /// <summary>
        /// Sends events to server.
        /// </summary>
        public void Send()
        {
            if (PlayFabSettings.staticPlayer.IsClientLoggedIn() && (isSending == false))
            {
                isSending = true;

                EventsModels.WriteEventsRequest request = new EventsModels.WriteEventsRequest();
                request.Events = new List<EventsModels.EventContents>();

                while ((eventsRequests.Count > 0) && (request.Events.Count < maxBatchSizeInEvents))
                {
                    EventsModels.EventContents eventInfo = eventsRequests.Dequeue();
                    request.Events.Add(eventInfo);
                }

                if (request.Events.Count > 0)
                {
                    eventApi.WriteEvents(request, EventSentSuccessfulCallback, EventSentErrorCallback);
                }

                isSending = false;
            }
        }

        /// <summary>
        /// Callback to handle successful server interaction.
        /// </summary>
        /// <param name="response">Server response</param>
        private void EventSentSuccessfulCallback(EventsModels.WriteEventsResponse response)
        {
            // add code to work with successful callback
        }

        /// <summary>
        /// Callback to handle unsuccessful server interaction.
        /// </summary>
        /// <param name="response">Server response</param>
        private void EventSentErrorCallback(PlayFabError response)
        {
            Debug.LogWarning("Failed to send session data. Error: " + response.GenerateErrorReport());
        }

        #region Unused MonoBehaviour compatibility  methods
        /// <summary>
        /// Unused
        /// Name mimics MonoBehaviour method, for ease of integration.
        /// </summary>
        public void OnEnable()
        {
            // add code sending events on enable
        }

        /// <summary>
        /// Unused
        /// Name mimics MonoBehaviour method, for ease of integration.
        /// </summary>
        public void OnDisable()
        {
            // add code sending events on disable
        }

        /// <summary>
        /// Unused
        /// Name mimics MonoBehaviour method, for ease of integration.
        /// </summary>
        public void OnDestroy()
        {
            // add code sending events on destroy
        }
        #endregion

        /// <summary>
        /// Trying to send event during game exit. Note: works only on certain platforms.
        /// Name mimics MonoBehaviour method, for ease of integration.
        /// </summary>
        public void OnApplicationQuit()
        {
            // trying to send events during game exit
            Send();
        }
    }
}
#endif
