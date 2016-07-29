using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    /// <summary>
    /// The base type for all PlayStream events.
    /// See https://api.playfab.com/playstream/docs/PlayStreamEventModels for more information
    /// </summary>
    public abstract class EventBase
    {
        public string Source;
        public string EventId;
        public string EntityId;
        public string EntityType;
        public string EventNamespace;
        public string EventName;
        public DateTime Timestamp;
        public Dictionary<string, string> CustomTags;
        public List<object> History;
        public object Reserved;

    }

    public class CharacterConsumedItemEvent : EventBase
    {
        public string ItemId;
        public string ItemInstanceId;
        public string CatalogVersion;
        public uint? PreviousUsesRemaining;
        public uint? UsesRemaining;
        public string TitleId;
        public string PlayerId;
    }

    public class PlayerInventoryItemAddedEvent : EventBase
    {
        public string InstanceId;
        public string ItemId;
        public string DisplayName;
        public string Class;
        public string CatalogVersion;
        public DateTime? Expiration;
        public uint? RemainingUses;
        public string Annotation;
        public string CouponCode;
        public string[] BundleContents;
        public string TitleId;
    }

    public class PlayerVirtualCurrencyBalanceChanged : EventBase
    {
        public string VirtualCurrencyName;
        public int VirtualCurrencyBalance;
        public int VirtualCurrencyPreviousBalance;
        public string OrderId;
        public string TitleId;
    }
}
