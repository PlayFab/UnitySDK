#if ENABLE_PLAYFABPLAYSTREAM_API

using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    public abstract class EventBase
    {
        /// <summary>
        /// SourceType is one of a limited set of values that denotes where this event came from in a broad sense.
        /// GameClient/GameServer/Admin imply that it came from our APIs. 'Backend' implies that it came directly from a backend,
        /// either something we generated internally or one of the other backends we support. Partner implies that we received
        /// this event via the Partner API.
        /// </summary>
        SourceType SourceType { get; set; }

        /// <summary>
        /// Source is the specific derivation of where this event came from. Combined with SourceType, it tells you the 
        /// exact origination. For example, SourceType=Backend and Source=PlayFab means we generated the event internally.
        /// SourceType=Partner and Source=Kochava means that Kochava sent us this event. SourceType=Backend and Source=OtherGameCompany
        /// implies that we received this event directly from some other company's backend. This may not always be set, such as in
        /// the case of GameClient/GameServer.
        /// </summary>
        public string Source;

        public string EventId;
        public string EntityId;
        public string EntityType;
        public string EventNamespace;
        public string EventName;
        public DateTime Timestamp;
        public Dictionary<string, string> CustomTags;
        public List<PlayStreamEventHistory> History;
        public object Reserved;
    }

    public class PlayStreamEventHistory
    {
        /// <summary>
        /// The ID of the trigger that caused this event to be created.
        /// </summary>
        public string ParentTriggerId;

        /// <summary>
        /// The ID of the previous event that caused this event to be created by hitting a trigger.
        /// </summary>
        public string ParentEventId;

        /// <summary>
        /// If true, then this event was allowed to trigger subsequent events in a trigger.
        /// </summary>
        public bool TriggeredEvents;

    }

    public enum SourceType
    {
        Admin,
        BackEnd,
        GameClient,
        GameServer,
        Partner,
        Stream
    }
}

#endif
