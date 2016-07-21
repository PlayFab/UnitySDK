#if ENABLE_PLAYSTREAM_REALTIME

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PlayFab.Realtime.Event
{
    public abstract class EventBase
    {
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
        public DateTime? Timestamp;
        public Dictionary<string, object> CustomTags;
    }
}

#endif
