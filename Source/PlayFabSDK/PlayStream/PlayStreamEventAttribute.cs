#if ENABLE_PLAYFABPLAYSTREAM_API
using System;

namespace PlayFab.PlayStreamModels
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class PlayStreamEventAttribute : Attribute
    {
        public string EventName { get; private set; }

        public string EntityType { get; private set; }
        
        public string EventNamespace { get; private set; }

        public PlayStreamEventAttribute(string eventName)
        {
            EventName = eventName;
            EntityType = "player";
            EventNamespace = "com.playfab";
        }

        public PlayStreamEventAttribute(string eventName, string entityType)
        {
            EventName = eventName;
            EntityType = entityType;
            EventNamespace = "com.playfab";
        }

        public PlayStreamEventAttribute(string eventName, string entityType, string eventNamespace)
        {
            EventName = eventName;
            EntityType = entityType;
            EventNamespace = eventNamespace;
        }
    }

}
#endif
