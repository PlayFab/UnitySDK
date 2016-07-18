#if ENABLE_PLAYSTREAM_REALTIME
using System;

namespace PlayFab.Realtime.Event
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EventNameAttribute : Attribute
    {
        public string EventName { get; set; }

        public EventNameAttribute(string eventName)
        {
            EventName = eventName;
        }
    }

}
#endif
