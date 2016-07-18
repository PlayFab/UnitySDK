#if ENABLE_PLAYSTREAM_REALTIME

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PlayFab.Realtime.Event
{
    public abstract class EventBase
    {
        /// <summary>
        /// SourceType is one of a limited set of values that denotes where this event came from in a broad sense.
        /// GameClient/GameServer/Admin imply that it came from our APIs. 'Backend' implies that it came directly from a backend,
        /// either something we generated internally or one of the other backends we support. Partner implies that we received
        /// this event via the Partner API.
        /// </summary>
        //public SourceType? SourceType { get; set; }

        /// <summary>
        /// Source is the specific derivation of where this event came from. Combined with SourceType, it tells you the 
        /// exact origination. For example, SourceType=Backend and Source=PlayFab means we generated the event internally.
        /// SourceType=Partner and Source=Kochava means that Kochava sent us this event. SourceType=Backend and Source=OtherGameCompany
        /// implies that we received this event directly from some other company's backend. This may not always be set, such as in
        /// the case of GameClient/GameServer.
        /// </summary>
        public string Source { get; set; }
        public string EventId { get; set; }
        public string EntityId { get; set; }
        public string EntityType { get; set; }
        public string EventNamespace { get; set; }
        public string EventName { get; set; }
        public DateTime? Timestamp { get; set; }
        public Stack<PlayStreamEventHistory> History { get; set; }
        public object Reserved { get; set; }
        public Dictionary<string, string> CustomTags { get; set; }
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

    [Serializable]
    public class PlayStreamEventHistory
    {
        /// <summary>
        /// The ID of the trigger that caused this event to be created.
        /// </summary>
        public string ParentTriggerId { get; set; }
        
        /// <summary>
        /// The ID of the previous event that caused this event to be created by hitting a trigger.
        /// </summary>
        public string ParentEventId { get; set; }

        /// <summary>
        /// If true, then this event was allowed to trigger subsequent events in a trigger.
        /// </summary>
        public bool TriggeredEvents { get; set; }

    }
}

#endif
