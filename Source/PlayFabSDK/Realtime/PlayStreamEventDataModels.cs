#if ENABLE_PLAYSTREAM_REALTIME
using System;
using System.Runtime.CompilerServices;

namespace PlayFab.Realtime.Event
{
    /// <summary>
    /// This event is triggered when a character consumes an item frmo their inventory
    /// </summary>
    [EventName("character_consumed_item")]
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

    [EventName("player_inventory_item_added")]
    public class PlayerInventoryItemAddedEvent : EventBase
    {
        public string InstanceId;

        public string ItemId;

        public string Displayname;

        public string Class;

        public string CatalogVersion;

        public DateTime? Expiration;

        public uint? RemainingUses;

        public string Annotation;

        public string CouponCode;

        public string[] BundleContents;

        public string TitleId;
    }
}

#endif
