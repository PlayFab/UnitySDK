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
        public string ItemId { get; set; }

        public string ItemInstanceId { get; set; }

        public string CatalogVersion { get; set; }

        public uint? PreviousUsesRemaining { get; set; }

        public uint? UsesRemaining { get; set; }

        public string TitleId { get; set; }

        public string PlayerId { get; set; }
        
    }

    [EventName("player_inventory_item_added")]
    public class PlayerInventoryItemAddedEvent : EventBase
    {
        public string InstanceId { get; set; }

        public string ItemId { get; set; }

        public string Displayname { get; set; }

        public string Class { get; set; }

        public string CatalogVersion { get; set; }

        public DateTime? Expiration { get; set; }

        public uint? RemainingUses { get; set; }

        public string Annotation { get; set; }

        public string CouponCode { get; set; }

        public string[] BundleContents { get; set; }

        public string TitleId { get; set; }
    }
}

#endif
