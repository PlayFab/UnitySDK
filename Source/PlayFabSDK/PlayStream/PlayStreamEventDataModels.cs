#if ENABLE_PLAYFABPLAYSTREAM_API
using System;

namespace PlayFab.PlayStreamModels
{
    /// <summary>
    /// This event is triggered when a character consumes an item frmo their inventory
    /// </summary>
    [PlayStreamEvent("character_consumed_item", "character", "com.playfab")]
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

    [PlayStreamEvent("player_inventory_item_added", "player", "com.playfab")]
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

    [PlayStreamEvent("player_virtual_currency_balance_changed", "player", "com.playfab")]
    public class PlayerVirtualCurrencyBalanceChanged : EventBase
    {
        public string VirtualCurrencyName;

        public int VirtualCurrencyBalance;

        public int VirtualCurrencyPreviousBalance;

        public string OrderId;

        public string TitleId;
    }
}

#endif
