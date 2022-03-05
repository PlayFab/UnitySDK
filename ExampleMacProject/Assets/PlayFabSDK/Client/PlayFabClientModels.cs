#if !DISABLE_PLAYFABCLIENT_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ClientModels
{
    [Serializable]
    public class AcceptTradeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Items from the accepting player's inventory in exchange for the offered items in the trade. In the case of a gift, this
        /// will be null.
        /// </summary>
        public List<string> AcceptedInventoryInstanceIds;
        /// <summary>
        /// Player who opened the trade.
        /// </summary>
        public string OfferingPlayerId;
        /// <summary>
        /// Trade identifier.
        /// </summary>
        public string TradeId;
    }

    [Serializable]
    public class AcceptTradeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Details about trade which was just accepted.
        /// </summary>
        public TradeInfo Trade;
    }

    public enum AdActivity
    {
        Opened,
        Closed,
        Start,
        End
    }

    [Serializable]
    public class AdCampaignAttributionModel : PlayFabBaseModel
    {
        /// <summary>
        /// UTC time stamp of attribution
        /// </summary>
        public DateTime AttributedAt;
        /// <summary>
        /// Attribution campaign identifier
        /// </summary>
        public string CampaignId;
        /// <summary>
        /// Attribution network name
        /// </summary>
        public string Platform;
    }

    [Serializable]
    public class AddFriendRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Email address of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendEmail;
        /// <summary>
        /// PlayFab identifier of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// Title-specific display name of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendTitleDisplayName;
        /// <summary>
        /// PlayFab username of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendUsername;
    }

    [Serializable]
    public class AddFriendResult : PlayFabResultCommon
    {
        /// <summary>
        /// True if the friend request was processed successfully.
        /// </summary>
        public bool Created;
    }

    [Serializable]
    public class AddGenericIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Generic service identifier to add to the player account.
        /// </summary>
        public GenericServiceId GenericId;
    }

    [Serializable]
    public class AddGenericIDResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// This API adds a contact email to the player's profile. If the player's profile already contains a contact email, it will
    /// update the contact email to the email address specified.
    /// </summary>
    [Serializable]
    public class AddOrUpdateContactEmailRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The new contact email to associate with the player.
        /// </summary>
        public string EmailAddress;
    }

    [Serializable]
    public class AddOrUpdateContactEmailResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class AddSharedGroupMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
    }

    [Serializable]
    public class AddSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class AddUsernamePasswordRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// Each account must have a unique username and email address in the PlayFab service. Once created, the account may be
    /// associated with additional accounts (Steam, Facebook, Game Center, etc.), allowing for added social network lists and
    /// achievements systems. This can also be used to provide a recovery method if the user loses their original means of
    /// access.
    /// </summary>
    [Serializable]
    public class AddUsernamePasswordResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// This API must be enabled for use as an option in the game manager website. It is disabled by default.
    /// </summary>
    [Serializable]
    public class AddUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;
    }

    /// <summary>
    /// A single ad placement details including placement and reward information
    /// </summary>
    [Serializable]
    public class AdPlacementDetails : PlayFabBaseModel
    {
        /// <summary>
        /// Placement unique ID
        /// </summary>
        public string PlacementId;
        /// <summary>
        /// Placement name
        /// </summary>
        public string PlacementName;
        /// <summary>
        /// If placement has viewing limits indicates how many views are left
        /// </summary>
        public int? PlacementViewsRemaining;
        /// <summary>
        /// If placement has viewing limits indicates when they will next reset
        /// </summary>
        public double? PlacementViewsResetMinutes;
        /// <summary>
        /// Optional URL to a reward asset
        /// </summary>
        public string RewardAssetUrl;
        /// <summary>
        /// Reward description
        /// </summary>
        public string RewardDescription;
        /// <summary>
        /// Reward unique ID
        /// </summary>
        public string RewardId;
        /// <summary>
        /// Reward name
        /// </summary>
        public string RewardName;
    }

    /// <summary>
    /// Details for each item granted
    /// </summary>
    [Serializable]
    public class AdRewardItemGranted : PlayFabBaseModel
    {
        /// <summary>
        /// Catalog ID
        /// </summary>
        public string CatalogId;
        /// <summary>
        /// Catalog item display name
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Inventory instance ID
        /// </summary>
        public string InstanceId;
        /// <summary>
        /// Item ID
        /// </summary>
        public string ItemId;
    }

    /// <summary>
    /// Details on what was granted to the player
    /// </summary>
    [Serializable]
    public class AdRewardResults : PlayFabBaseModel
    {
        /// <summary>
        /// Array of the items granted to the player
        /// </summary>
        public List<AdRewardItemGranted> GrantedItems;
        /// <summary>
        /// Dictionary of virtual currencies that were granted to the player
        /// </summary>
        public Dictionary<string,int> GrantedVirtualCurrencies;
        /// <summary>
        /// Dictionary of statistics that were modified for the player
        /// </summary>
        public Dictionary<string,int> IncrementedStatistics;
    }

    /// <summary>
    /// More information can be found on configuring your game for the Google Cloud Messaging service in the Google developer
    /// documentation, here: http://developer.android.com/google/gcm/client.html. The steps to configure and send Push
    /// Notifications is described in the PlayFab tutorials, here:
    /// https://docs.microsoft.com/gaming/playfab/features/engagement/push-notifications/quickstart.
    /// </summary>
    [Serializable]
    public class AndroidDevicePushNotificationRegistrationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Message to display when confirming push notification.
        /// </summary>
        public string ConfirmationMessage;
        /// <summary>
        /// Registration ID provided by the Google Cloud Messaging service when the title registered to receive push notifications
        /// (see the GCM documentation, here: http://developer.android.com/google/gcm/client.html).
        /// </summary>
        public string DeviceToken;
        /// <summary>
        /// If true, send a test push message immediately after sucessful registration. Defaults to false.
        /// </summary>
        public bool? SendPushNotificationConfirmation;
    }

    [Serializable]
    public class AndroidDevicePushNotificationRegistrationResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// If you have an ad attribution partner enabled, this will post an install to their service to track the device. It uses
    /// the given device id to match based on clicks on ads.
    /// </summary>
    [Serializable]
    public class AttributeInstallRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The adid for this device.
        /// </summary>
        public string Adid;
        /// <summary>
        /// The IdentifierForAdvertisers for iOS Devices.
        /// </summary>
        public string Idfa;
    }

    [Serializable]
    public class AttributeInstallResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class CancelTradeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Trade identifier.
        /// </summary>
        public string TradeId;
    }

    [Serializable]
    public class CancelTradeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Details about trade which was just canceled.
        /// </summary>
        public TradeInfo Trade;
    }

    [Serializable]
    public class CartItem : PlayFabBaseModel
    {
        /// <summary>
        /// Description of the catalog item.
        /// </summary>
        public string Description;
        /// <summary>
        /// Display name for the catalog item.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Class name to which catalog item belongs.
        /// </summary>
        public string ItemClass;
        /// <summary>
        /// Unique identifier for the catalog item.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Unique instance identifier for this catalog item.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Cost of the catalog item for each applicable real world currency.
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;
        /// <summary>
        /// Amount of each applicable virtual currency which will be received as a result of purchasing this catalog item.
        /// </summary>
        public Dictionary<string,uint> VCAmount;
        /// <summary>
        /// Cost of the catalog item for each applicable virtual currency.
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;
    }

    /// <summary>
    /// A purchasable item from the item catalog
    /// </summary>
    [Serializable]
    public class CatalogItem : PlayFabBaseModel
    {
        /// <summary>
        /// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables
        /// and virtual currencies
        /// </summary>
        public CatalogItemBundleInfo Bundle;
        /// <summary>
        /// if true, then an item instance of this type can be used to grant a character to a user.
        /// </summary>
        public bool CanBecomeCharacter;
        /// <summary>
        /// catalog version for this item
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// defines the consumable properties (number of uses, timeout) for the item
        /// </summary>
        public CatalogItemConsumableInfo Consumable;
        /// <summary>
        /// defines the container properties for the item - what items it contains, including random drop tables and virtual
        /// currencies, and what item (if any) is required to open it via the UnlockContainerItem API
        /// </summary>
        public CatalogItemContainerInfo Container;
        /// <summary>
        /// game specific custom data
        /// </summary>
        public string CustomData;
        /// <summary>
        /// text description of item, to show in-game
        /// </summary>
        public string Description;
        /// <summary>
        /// text name for the item, to show in-game
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// If the item has IsLImitedEdition set to true, and this is the first time this ItemId has been defined as a limited
        /// edition item, this value determines the total number of instances to allocate for the title. Once this limit has been
        /// reached, no more instances of this ItemId can be created, and attempts to purchase or grant it will return a Result of
        /// false for that ItemId. If the item has already been defined to have a limited edition count, or if this value is less
        /// than zero, it will be ignored.
        /// </summary>
        public int InitialLimitedEditionCount;
        /// <summary>
        /// BETA: If true, then only a fixed number can ever be granted.
        /// </summary>
        public bool IsLimitedEdition;
        /// <summary>
        /// if true, then only one item instance of this type will exist and its remaininguses will be incremented instead.
        /// RemainingUses will cap out at Int32.Max (2,147,483,647). All subsequent increases will be discarded
        /// </summary>
        public bool IsStackable;
        /// <summary>
        /// if true, then an item instance of this type can be traded between players using the trading APIs
        /// </summary>
        public bool IsTradable;
        /// <summary>
        /// class to which the item belongs
        /// </summary>
        public string ItemClass;
        /// <summary>
        /// unique identifier for this item
        /// </summary>
        public string ItemId;
        /// <summary>
        /// URL to the item image. For Facebook purchase to display the image on the item purchase page, this must be set to an HTTP
        /// URL.
        /// </summary>
        public string ItemImageUrl;
        /// <summary>
        /// override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;
        /// <summary>
        /// list of item tags
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;
    }

    [Serializable]
    public class CatalogItemBundleInfo : PlayFabBaseModel
    {
        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory when the bundle is added
        /// </summary>
        public List<string> BundledItems;
        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and
        /// add the relevant items to the player inventory when the bundle is added)
        /// </summary>
        public List<string> BundledResultTables;
        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the bundle is added
        /// </summary>
        public Dictionary<string,uint> BundledVirtualCurrencies;
    }

    [Serializable]
    public class CatalogItemConsumableInfo : PlayFabBaseModel
    {
        /// <summary>
        /// number of times this object can be used, after which it will be removed from the player inventory
        /// </summary>
        public uint? UsageCount;
        /// <summary>
        /// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
        /// (recommended minimum value is 5 seconds, as lower values can cause the item to expire before operations depending on
        /// this item's details have completed)
        /// </summary>
        public uint? UsagePeriod;
        /// <summary>
        /// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values
        /// added together, and share the result - when that period has elapsed, all the items in the group will be removed
        /// </summary>
        public string UsagePeriodGroup;
    }

    /// <summary>
    /// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is
    /// added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be
    /// anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is
    /// unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog
    /// defintiions, unless the intent is for the player to be able to re-use them infinitely.
    /// </summary>
    [Serializable]
    public class CatalogItemContainerInfo : PlayFabBaseModel
    {
        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
        /// </summary>
        public List<string> ItemContents;
        /// <summary>
        /// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will
        /// open the container, adding the contents to the player inventory and currency balances)
        /// </summary>
        public string KeyItemId;
        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables
        /// will be resolved and add the relevant items to the player inventory)
        /// </summary>
        public List<string> ResultTableContents;
        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the container is unlocked
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyContents;
    }

    [Serializable]
    public class CharacterInventory : PlayFabBaseModel
    {
        /// <summary>
        /// The id of this character.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The inventory of this character.
        /// </summary>
        public List<ItemInstance> Inventory;
    }

    [Serializable]
    public class CharacterLeaderboardEntry : PlayFabBaseModel
    {
        /// <summary>
        /// PlayFab unique identifier of the character that belongs to the user for this leaderboard entry.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Title-specific display name of the character for this leaderboard entry.
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// Name of the character class for this entry.
        /// </summary>
        public string CharacterType;
        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position;
        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue;
    }

    [Serializable]
    public class CharacterResult : PlayFabBaseModel
    {
        /// <summary>
        /// The id for this character on this player.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The name of this character.
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// The type-string that was given to this character on creation.
        /// </summary>
        public string CharacterType;
    }

    public enum CloudScriptRevisionOption
    {
        Live,
        Latest,
        Specific
    }

    /// <summary>
    /// Collection filter to include and/or exclude collections with certain key-value pairs. The filter generates a collection
    /// set defined by Includes rules and then remove collections that matches the Excludes rules. A collection is considered
    /// matching a rule if the rule describes a subset of the collection.
    /// </summary>
    [Serializable]
    public class CollectionFilter : PlayFabBaseModel
    {
        /// <summary>
        /// List of Exclude rules, with any of which if a collection matches, it is excluded by the filter.
        /// </summary>
        public List<Container_Dictionary_String_String> Excludes;
        /// <summary>
        /// List of Include rules, with any of which if a collection matches, it is included by the filter, unless it is excluded by
        /// one of the Exclude rule
        /// </summary>
        public List<Container_Dictionary_String_String> Includes;
    }

    /// <summary>
    /// The final step in the purchasing process, this API finalizes the purchase with the payment provider, where applicable,
    /// adding virtual goods to the player inventory (including random drop table resolution and recursive addition of bundled
    /// items) and adjusting virtual currency balances for funds used or added. Note that this is a pull operation, and should
    /// be polled regularly when a purchase is in progress. Please note that the processing time for inventory grants and
    /// purchases increases fractionally the more items are in the inventory, and the more items are in the grant/purchase
    /// operation.
    /// </summary>
    [Serializable]
    public class ConfirmPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Purchase order identifier returned from StartPurchase.
        /// </summary>
        public string OrderId;
    }

    /// <summary>
    /// When the FailedByPaymentProvider error is returned, it's important to check the ProviderErrorCode, ProviderErrorMessage,
    /// and ProviderErrorDetails to understand the specific reason the payment was rejected, as in some rare cases, this may
    /// mean that the provider hasn't completed some operation required to finalize the purchase.
    /// </summary>
    [Serializable]
    public class ConfirmPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items purchased.
        /// </summary>
        public List<ItemInstance> Items;
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Date and time of the purchase.
        /// </summary>
        public DateTime PurchaseDate;
    }

    [Serializable]
    public class ConsumeItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Number of uses to consume from the item.
        /// </summary>
        public int ConsumeCount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique instance identifier of the item to be consumed.
        /// </summary>
        public string ItemInstanceId;
    }

    [Serializable]
    public class ConsumeItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique instance identifier of the item with uses consumed.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Number of uses remaining on the item.
        /// </summary>
        public int RemainingUses;
    }

    [Serializable]
    public class ConsumeMicrosoftStoreEntitlementsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version to use
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Marketplace specific payload containing details to fetch in app purchase transactions
        /// </summary>
        public MicrosoftStorePayload MarketplaceSpecificData;
    }

    [Serializable]
    public class ConsumeMicrosoftStoreEntitlementsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Details for the items purchased.
        /// </summary>
        public List<ItemInstance> Items;
    }

    [Serializable]
    public class ConsumePS5EntitlementsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version to use
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Marketplace specific payload containing details to fetch in app purchase transactions
        /// </summary>
        public PlayStation5Payload MarketplaceSpecificData;
    }

    [Serializable]
    public class ConsumePS5EntitlementsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Details for the items purchased.
        /// </summary>
        public List<ItemInstance> Items;
    }

    [Serializable]
    public class ConsumePSNEntitlementsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Which catalog to match granted entitlements against. If null, defaults to title default catalog
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Id of the PSN service label to consume entitlements from
        /// </summary>
        public int ServiceLabel;
    }

    [Serializable]
    public class ConsumePSNEntitlementsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to the player as a result of consuming entitlements.
        /// </summary>
        public List<ItemInstance> ItemsGranted;
    }

    [Serializable]
    public class ConsumeXboxEntitlementsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version to use
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Token provided by the Xbox Live SDK/XDK method GetTokenAndSignatureAsync("POST", "https://playfabapi.com/", "").
        /// </summary>
        public string XboxToken;
    }

    [Serializable]
    public class ConsumeXboxEntitlementsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Details for the items purchased.
        /// </summary>
        public List<ItemInstance> Items;
    }

    [Serializable]
    public class ContactEmailInfoModel : PlayFabBaseModel
    {
        /// <summary>
        /// The email address
        /// </summary>
        public string EmailAddress;
        /// <summary>
        /// The name of the email info data
        /// </summary>
        public string Name;
        /// <summary>
        /// The verification status of the email
        /// </summary>
        public EmailVerificationStatus? VerificationStatus;
    }

    /// <summary>
    /// A data container
    /// </summary>
    [Serializable]
    public class Container_Dictionary_String_String : PlayFabBaseModel
    {
        /// <summary>
        /// Content of data
        /// </summary>
        public Dictionary<string,string> Data;
    }

    public enum ContinentCode
    {
        AF,
        AN,
        AS,
        EU,
        NA,
        OC,
        SA
    }

    public enum CountryCode
    {
        AF,
        AX,
        AL,
        DZ,
        AS,
        AD,
        AO,
        AI,
        AQ,
        AG,
        AR,
        AM,
        AW,
        AU,
        AT,
        AZ,
        BS,
        BH,
        BD,
        BB,
        BY,
        BE,
        BZ,
        BJ,
        BM,
        BT,
        BO,
        BQ,
        BA,
        BW,
        BV,
        BR,
        IO,
        BN,
        BG,
        BF,
        BI,
        KH,
        CM,
        CA,
        CV,
        KY,
        CF,
        TD,
        CL,
        CN,
        CX,
        CC,
        CO,
        KM,
        CG,
        CD,
        CK,
        CR,
        CI,
        HR,
        CU,
        CW,
        CY,
        CZ,
        DK,
        DJ,
        DM,
        DO,
        EC,
        EG,
        SV,
        GQ,
        ER,
        EE,
        ET,
        FK,
        FO,
        FJ,
        FI,
        FR,
        GF,
        PF,
        TF,
        GA,
        GM,
        GE,
        DE,
        GH,
        GI,
        GR,
        GL,
        GD,
        GP,
        GU,
        GT,
        GG,
        GN,
        GW,
        GY,
        HT,
        HM,
        VA,
        HN,
        HK,
        HU,
        IS,
        IN,
        ID,
        IR,
        IQ,
        IE,
        IM,
        IL,
        IT,
        JM,
        JP,
        JE,
        JO,
        KZ,
        KE,
        KI,
        KP,
        KR,
        KW,
        KG,
        LA,
        LV,
        LB,
        LS,
        LR,
        LY,
        LI,
        LT,
        LU,
        MO,
        MK,
        MG,
        MW,
        MY,
        MV,
        ML,
        MT,
        MH,
        MQ,
        MR,
        MU,
        YT,
        MX,
        FM,
        MD,
        MC,
        MN,
        ME,
        MS,
        MA,
        MZ,
        MM,
        NA,
        NR,
        NP,
        NL,
        NC,
        NZ,
        NI,
        NE,
        NG,
        NU,
        NF,
        MP,
        NO,
        OM,
        PK,
        PW,
        PS,
        PA,
        PG,
        PY,
        PE,
        PH,
        PN,
        PL,
        PT,
        PR,
        QA,
        RE,
        RO,
        RU,
        RW,
        BL,
        SH,
        KN,
        LC,
        MF,
        PM,
        VC,
        WS,
        SM,
        ST,
        SA,
        SN,
        RS,
        SC,
        SL,
        SG,
        SX,
        SK,
        SI,
        SB,
        SO,
        ZA,
        GS,
        SS,
        ES,
        LK,
        SD,
        SR,
        SJ,
        SZ,
        SE,
        CH,
        SY,
        TW,
        TJ,
        TZ,
        TH,
        TL,
        TG,
        TK,
        TO,
        TT,
        TN,
        TR,
        TM,
        TC,
        TV,
        UG,
        UA,
        AE,
        GB,
        US,
        UM,
        UY,
        UZ,
        VU,
        VE,
        VN,
        VG,
        VI,
        WF,
        EH,
        YE,
        ZM,
        ZW
    }

    /// <summary>
    /// If SharedGroupId is specified, the service will attempt to create a group with that identifier, and will return an error
    /// if it is already in use. If no SharedGroupId is specified, a random identifier will be assigned.
    /// </summary>
    [Serializable]
    public class CreateSharedGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the shared group (a random identifier will be assigned, if one is not specified).
        /// </summary>
        public string SharedGroupId;
    }

    [Serializable]
    public class CreateSharedGroupResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
    }

    public enum Currency
    {
        AED,
        AFN,
        ALL,
        AMD,
        ANG,
        AOA,
        ARS,
        AUD,
        AWG,
        AZN,
        BAM,
        BBD,
        BDT,
        BGN,
        BHD,
        BIF,
        BMD,
        BND,
        BOB,
        BRL,
        BSD,
        BTN,
        BWP,
        BYR,
        BZD,
        CAD,
        CDF,
        CHF,
        CLP,
        CNY,
        COP,
        CRC,
        CUC,
        CUP,
        CVE,
        CZK,
        DJF,
        DKK,
        DOP,
        DZD,
        EGP,
        ERN,
        ETB,
        EUR,
        FJD,
        FKP,
        GBP,
        GEL,
        GGP,
        GHS,
        GIP,
        GMD,
        GNF,
        GTQ,
        GYD,
        HKD,
        HNL,
        HRK,
        HTG,
        HUF,
        IDR,
        ILS,
        IMP,
        INR,
        IQD,
        IRR,
        ISK,
        JEP,
        JMD,
        JOD,
        JPY,
        KES,
        KGS,
        KHR,
        KMF,
        KPW,
        KRW,
        KWD,
        KYD,
        KZT,
        LAK,
        LBP,
        LKR,
        LRD,
        LSL,
        LYD,
        MAD,
        MDL,
        MGA,
        MKD,
        MMK,
        MNT,
        MOP,
        MRO,
        MUR,
        MVR,
        MWK,
        MXN,
        MYR,
        MZN,
        NAD,
        NGN,
        NIO,
        NOK,
        NPR,
        NZD,
        OMR,
        PAB,
        PEN,
        PGK,
        PHP,
        PKR,
        PLN,
        PYG,
        QAR,
        RON,
        RSD,
        RUB,
        RWF,
        SAR,
        SBD,
        SCR,
        SDG,
        SEK,
        SGD,
        SHP,
        SLL,
        SOS,
        SPL,
        SRD,
        STD,
        SVC,
        SYP,
        SZL,
        THB,
        TJS,
        TMT,
        TND,
        TOP,
        TRY,
        TTD,
        TVD,
        TWD,
        TZS,
        UAH,
        UGX,
        USD,
        UYU,
        UZS,
        VEF,
        VND,
        VUV,
        WST,
        XAF,
        XCD,
        XDR,
        XOF,
        XPF,
        YER,
        ZAR,
        ZMW,
        ZWD
    }

    [Serializable]
    public class CurrentGamesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Build to match against.
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// Game mode to look for.
        /// </summary>
        public string GameMode;
        /// <summary>
        /// Region to check for Game Server Instances.
        /// </summary>
        public Region? Region;
        /// <summary>
        /// Statistic name to find statistic-based matches.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Filter to include and/or exclude Game Server Instances associated with certain tags.
        /// </summary>
        public CollectionFilter TagFilter;
    }

    [Serializable]
    public class CurrentGamesResult : PlayFabResultCommon
    {
        /// <summary>
        /// number of games running
        /// </summary>
        public int GameCount;
        /// <summary>
        /// array of games found
        /// </summary>
        public List<GameInfo> Games;
        /// <summary>
        /// total number of players across all servers
        /// </summary>
        public int PlayerCount;
    }

    /// <summary>
    /// Any arbitrary information collected by the device
    /// </summary>
    [Serializable]
    public class DeviceInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Information posted to the PlayStream Event. Currently arbitrary, and specific to the environment sending it.
        /// </summary>
        public Dictionary<string,object> Info;
    }

    public enum EmailVerificationStatus
    {
        Unverified,
        Pending,
        Confirmed
    }

    [Serializable]
    public class EmptyResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class EmptyResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Combined entity type and ID structure which uniquely identifies a single entity.
    /// </summary>
    [Serializable]
    public class EntityKey : PlayFabBaseModel
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id;
        /// <summary>
        /// Entity type. See https://docs.microsoft.com/gaming/playfab/features/data/entities/available-built-in-entity-types
        /// </summary>
        public string Type;
    }

    [Serializable]
    public class EntityTokenResponse : PlayFabBaseModel
    {
        /// <summary>
        /// The entity id and type.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The token used to set X-EntityToken for all entity based API calls.
        /// </summary>
        public string EntityToken;
        /// <summary>
        /// The time the token will expire, if it is an expiring token, in UTC.
        /// </summary>
        public DateTime? TokenExpiration;
    }

    [Serializable]
    public class ExecuteCloudScriptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the CloudScript function to execute
        /// </summary>
        public string FunctionName;
        /// <summary>
        /// Object that is passed in to the function as the first argument
        /// </summary>
        public object FunctionParameter;
        /// <summary>
        /// Generate a 'player_executed_cloudscript' PlayStream event containing the results of the function execution and other
        /// contextual information. This event will show up in the PlayStream debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent;
        /// <summary>
        /// Option for which revision of the CloudScript to execute. 'Latest' executes the most recently created revision, 'Live'
        /// executes the current live, published revision, and 'Specific' executes the specified revision. The default value is
        /// 'Specific', if the SpeificRevision parameter is specified, otherwise it is 'Live'.
        /// </summary>
        public CloudScriptRevisionOption? RevisionSelection;
        /// <summary>
        /// The specivic revision to execute, when RevisionSelection is set to 'Specific'
        /// </summary>
        public int? SpecificRevision;
    }

    [Serializable]
    public class ExecuteCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Number of PlayFab API requests issued by the CloudScript function
        /// </summary>
        public int APIRequestsIssued;
        /// <summary>
        /// Information about the error, if any, that occurred during execution
        /// </summary>
        public ScriptExecutionError Error;
        public double ExecutionTimeSeconds;
        /// <summary>
        /// The name of the function that executed
        /// </summary>
        public string FunctionName;
        /// <summary>
        /// The object returned from the CloudScript function, if any
        /// </summary>
        public object FunctionResult;
        /// <summary>
        /// Flag indicating if the FunctionResult was too large and was subsequently dropped from this event. This only occurs if
        /// the total event size is larger than 350KB.
        /// </summary>
        public bool? FunctionResultTooLarge;
        /// <summary>
        /// Number of external HTTP requests issued by the CloudScript function
        /// </summary>
        public int HttpRequestsIssued;
        /// <summary>
        /// Entries logged during the function execution. These include both entries logged in the function code using log.info()
        /// and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public List<LogStatement> Logs;
        /// <summary>
        /// Flag indicating if the logs were too large and were subsequently dropped from this event. This only occurs if the total
        /// event size is larger than 350KB after the FunctionResult was removed.
        /// </summary>
        public bool? LogsTooLarge;
        public uint MemoryConsumedBytes;
        /// <summary>
        /// Processor time consumed while executing the function. This does not include time spent waiting on API calls or HTTP
        /// requests.
        /// </summary>
        public double ProcessorTimeSeconds;
        /// <summary>
        /// The revision of the CloudScript that executed
        /// </summary>
        public int Revision;
    }

    [Serializable]
    public class FacebookInstantGamesPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Facebook Instant Games identifier for a user.
        /// </summary>
        public string FacebookInstantGamesId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook Instant Games identifier.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class FacebookPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Facebook identifier for a user.
        /// </summary>
        public string FacebookId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook identifier.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class FriendInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Available Facebook information (if the user and PlayFab friend are also connected in Facebook).
        /// </summary>
        public UserFacebookInfo FacebookInfo;
        /// <summary>
        /// PlayFab unique identifier for this friend.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// Available Game Center information (if the user and PlayFab friend are also connected in Game Center).
        /// </summary>
        public UserGameCenterInfo GameCenterInfo;
        /// <summary>
        /// The profile of the user, if requested.
        /// </summary>
        public PlayerProfileModel Profile;
        /// <summary>
        /// Available PSN information, if the user and PlayFab friend are both connected to PSN.
        /// </summary>
        public UserPsnInfo PSNInfo;
        /// <summary>
        /// Available Steam information (if the user and PlayFab friend are also connected in Steam).
        /// </summary>
        public UserSteamInfo SteamInfo;
        /// <summary>
        /// Tags which have been associated with this friend.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// Title-specific display name for this friend.
        /// </summary>
        public string TitleDisplayName;
        /// <summary>
        /// PlayFab unique username for this friend.
        /// </summary>
        public string Username;
        /// <summary>
        /// Available Xbox information, if the user and PlayFab friend are both connected to Xbox Live.
        /// </summary>
        public UserXboxInfo XboxInfo;
    }

    [Serializable]
    public class GameCenterPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Game Center identifier for a user.
        /// </summary>
        public string GameCenterId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Game Center identifier.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GameInfo : PlayFabBaseModel
    {
        /// <summary>
        /// build version this server is running
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// game mode this server is running
        /// </summary>
        public string GameMode;
        /// <summary>
        /// game session custom data
        /// </summary>
        public string GameServerData;
        /// <summary>
        /// game specific string denoting server configuration
        /// </summary>
        public GameInstanceState? GameServerStateEnum;
        /// <summary>
        /// last heartbeat of the game server instance, used in external game server provider mode
        /// </summary>
        public DateTime? LastHeartbeat;
        /// <summary>
        /// unique lobby identifier for this game server
        /// </summary>
        public string LobbyID;
        /// <summary>
        /// maximum players this server can support
        /// </summary>
        public int? MaxPlayers;
        /// <summary>
        /// array of current player IDs on this server
        /// </summary>
        public List<string> PlayerUserIds;
        /// <summary>
        /// region to which this server is associated
        /// </summary>
        public Region? Region;
        /// <summary>
        /// duration in seconds this server has been running
        /// </summary>
        public uint RunTime;
        /// <summary>
        /// IPV4 address of the server
        /// </summary>
        public string ServerIPV4Address;
        /// <summary>
        /// IPV6 address of the server
        /// </summary>
        public string ServerIPV6Address;
        /// <summary>
        /// port number to use for non-http communications with the server
        /// </summary>
        public int? ServerPort;
        /// <summary>
        /// Public DNS name (if any) of the server
        /// </summary>
        public string ServerPublicDNSName;
        /// <summary>
        /// stastic used to match this game in player statistic matchmaking
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// game session tags
        /// </summary>
        public Dictionary<string,string> Tags;
    }

    public enum GameInstanceState
    {
        Open,
        Closed
    }

    [Serializable]
    public class GameServerRegionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// version of game server for which stats are being requested
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class GameServerRegionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of regions found matching the request parameters
        /// </summary>
        public List<RegionInfo> Regions;
    }

    [Serializable]
    public class GenericPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique generic service identifier for a user.
        /// </summary>
        public GenericServiceId GenericId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the given generic identifier.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GenericServiceId : PlayFabBaseModel
    {
        /// <summary>
        /// Name of the service for which the player has a unique identifier.
        /// </summary>
        public string ServiceName;
        /// <summary>
        /// Unique identifier of the player in that service.
        /// </summary>
        public string UserId;
    }

    [Serializable]
    public class GetAccountInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// User email address for the account to find (if no Username is specified).
        /// </summary>
        public string Email;
        /// <summary>
        /// Unique PlayFab identifier of the user whose info is being requested. Optional, defaults to the authenticated user if no
        /// other lookup identifier set.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Title-specific username for the account to find (if no Email is set). Note that if the non-unique Title Display Names
        /// option is enabled for the title, attempts to look up users by Title Display Name will always return AccountNotFound.
        /// </summary>
        public string TitleDisplayName;
        /// <summary>
        /// PlayFab Username for the account to find (if no PlayFabId is specified).
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// This API retrieves details regarding the player in the PlayFab service. Note that when this call is used to retrieve
    /// data about another player (not the one signed into the local client), some data, such as Personally Identifying
    /// Information (PII), will be omitted for privacy reasons or to comply with the requirements of the platform belongs to.
    /// The user account returned will be based on the identifier provided in priority order: PlayFabId, Username, Email, then
    /// TitleDisplayName. If no identifier is specified, the currently signed in user's information will be returned.
    /// </summary>
    [Serializable]
    public class GetAccountInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// Account information for the local user.
        /// </summary>
        public UserAccountInfo AccountInfo;
    }

    /// <summary>
    /// Using an AppId to return a list of valid ad placements for a player.
    /// </summary>
    [Serializable]
    public class GetAdPlacementsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The current AppId to use
        /// </summary>
        public string AppId;
        /// <summary>
        /// Using the name or unique identifier, filter the result for get a specific placement.
        /// </summary>
        public NameIdentifier Identifier;
    }

    /// <summary>
    /// Array of AdPlacementDetails
    /// </summary>
    [Serializable]
    public class GetAdPlacementsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of results
        /// </summary>
        public List<AdPlacementDetails> AdPlacements;
    }

    [Serializable]
    public class GetCatalogItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Which catalog is being requested. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
    }

    /// <summary>
    /// If CatalogVersion is not specified, only inventory items associated with the most recent version of the catalog will be
    /// returned.
    /// </summary>
    [Serializable]
    public class GetCatalogItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items which can be purchased.
        /// </summary>
        public List<CatalogItem> Catalog;
    }

    /// <summary>
    /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned will only contain
    /// the data specific to the indicated Keys. Otherwise, the full set of custom character data will be returned.
    /// </summary>
    [Serializable]
    public class GetCharacterDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the
        /// version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion;
        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// Unique PlayFab identifier of the user to load data for. Optional, defaults to yourself if not set.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetCharacterDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data;
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of
        /// data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    /// <summary>
    /// All items currently in the character inventory will be returned, irrespective of how they were acquired (via purchasing,
    /// grants, coupons, etc.). Items that are expired, fully consumed, or are no longer valid are not considered to be in the
    /// user's current inventory, and so will not be not included. Also returns their virtual currency balances.
    /// </summary>
    [Serializable]
    public class GetCharacterInventoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Used to limit results to only those from a specific catalog version.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class GetCharacterInventoryResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier of the character for this inventory.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Array of inventory items belonging to the character.
        /// </summary>
        public List<ItemInstance> Inventory;
        /// <summary>
        /// Array of virtual currency balance(s) belonging to the character.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency;
        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes;
    }

    [Serializable]
    public class GetCharacterLeaderboardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
    }

    /// <summary>
    /// Note that the Position of the character in the results is for the overall leaderboard.
    /// </summary>
    [Serializable]
    public class GetCharacterLeaderboardResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard;
    }

    [Serializable]
    public class GetCharacterStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
    }

    /// <summary>
    /// In addition to being available for use by the title, the statistics are used for all leaderboard operations in PlayFab.
    /// </summary>
    [Serializable]
    public class GetCharacterStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The requested character statistics.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics;
    }

    [Serializable]
    public class GetContentDownloadUrlRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// HTTP method to fetch item - GET or HEAD. Use HEAD when only fetching metadata. Default is GET.
        /// </summary>
        public string HttpMethod;
        /// <summary>
        /// Key of the content item to fetch, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key;
        /// <summary>
        /// True to download through CDN. CDN provides higher download bandwidth and lower latency. However, if you want the latest,
        /// non-cached version of the content during development, set this to false. Default is true.
        /// </summary>
        public bool? ThruCDN;
    }

    [Serializable]
    public class GetContentDownloadUrlResult : PlayFabResultCommon
    {
        /// <summary>
        /// URL for downloading content via HTTP GET or HEAD method. The URL will expire in approximately one hour.
        /// </summary>
        public string URL;
    }

    [Serializable]
    public class GetFriendLeaderboardAroundPlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends;
        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// PlayFab unique identifier of the user to center the leaderboard around. If null will center on the logged in user.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// If non-null, this determines which properties of the resulting player profiles to return. For API calls from the client,
        /// only the allowed client profile properties for the title may be requested. These allowed properties are configured in
        /// the Game Manager "Client Profile Options" tab in the "Settings" section.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
        /// <summary>
        /// Xbox token if Xbox friends should be included. Requires Xbox be configured on PlayFab.
        /// </summary>
        public string XboxToken;
    }

    /// <summary>
    /// Note: When calling 'GetLeaderboardAround...' APIs, the position of the user defaults to 0 when the user does not have
    /// the corresponding statistic.If Facebook friends are included, make sure the access token from previous LoginWithFacebook
    /// call is still valid and not expired. If Xbox Live friends are included, make sure the access token from the previous
    /// LoginWithXbox call is still valid and not expired.
    /// </summary>
    [Serializable]
    public class GetFriendLeaderboardAroundPlayerResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;
        /// <summary>
        /// The time the next scheduled reset will occur. Null if the leaderboard does not reset on a schedule.
        /// </summary>
        public DateTime? NextReset;
        /// <summary>
        /// The version of the leaderboard returned.
        /// </summary>
        public int Version;
    }

    [Serializable]
    public class GetFriendLeaderboardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends;
        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// If non-null, this determines which properties of the resulting player profiles to return. For API calls from the client,
        /// only the allowed client profile properties for the title may be requested. These allowed properties are configured in
        /// the Game Manager "Client Profile Options" tab in the "Settings" section.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// Position in the leaderboard to start this listing (defaults to the first entry).
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Statistic used to rank friends for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
        /// <summary>
        /// Xbox token if Xbox friends should be included. Requires Xbox be configured on PlayFab.
        /// </summary>
        public string XboxToken;
    }

    [Serializable]
    public class GetFriendsListRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends;
        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends;
        /// <summary>
        /// If non-null, this determines which properties of the resulting player profiles to return. For API calls from the client,
        /// only the allowed client profile properties for the title may be requested. These allowed properties are configured in
        /// the Game Manager "Client Profile Options" tab in the "Settings" section.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// Xbox token if Xbox friends should be included. Requires Xbox be configured on PlayFab.
        /// </summary>
        public string XboxToken;
    }

    /// <summary>
    /// If any additional services are queried for the user's friends, those friends who also have a PlayFab account registered
    /// for the title will be returned in the results. For Facebook, user has to have logged into the title's Facebook app
    /// recently, and only friends who also plays this game will be included. For Xbox Live, user has to have logged into the
    /// Xbox Live recently, and only friends who also play this game will be included.
    /// </summary>
    [Serializable]
    public class GetFriendsListResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of friends found.
        /// </summary>
        public List<FriendInfo> Friends;
    }

    [Serializable]
    public class GetLeaderboardAroundCharacterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character on which to center the leaderboard.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
    }

    /// <summary>
    /// Note: When calling 'GetLeaderboardAround...' APIs, the position of the character defaults to 0 when the character does
    /// not have the corresponding statistic.
    /// </summary>
    [Serializable]
    public class GetLeaderboardAroundCharacterResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard;
    }

    [Serializable]
    public class GetLeaderboardAroundPlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// PlayFab unique identifier of the user to center the leaderboard around. If null will center on the logged in user.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// If non-null, this determines which properties of the resulting player profiles to return. For API calls from the client,
        /// only the allowed client profile properties for the title may be requested. These allowed properties are configured in
        /// the Game Manager "Client Profile Options" tab in the "Settings" section.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
    }

    /// <summary>
    /// Note: When calling 'GetLeaderboardAround...' APIs, the position of the user defaults to 0 when the user does not have
    /// the corresponding statistic.
    /// </summary>
    [Serializable]
    public class GetLeaderboardAroundPlayerResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;
        /// <summary>
        /// The time the next scheduled reset will occur. Null if the leaderboard does not reset on a schedule.
        /// </summary>
        public DateTime? NextReset;
        /// <summary>
        /// The version of the leaderboard returned.
        /// </summary>
        public int Version;
    }

    [Serializable]
    public class GetLeaderboardForUsersCharactersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
    }

    /// <summary>
    /// NOTE: The position of the character in the results is relative to the other characters for that specific user. This mean
    /// the values will always be between 0 and one less than the number of characters returned regardless of the size of the
    /// actual leaderboard.
    /// </summary>
    [Serializable]
    public class GetLeaderboardForUsersCharactersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard;
    }

    [Serializable]
    public class GetLeaderboardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// If non-null, this determines which properties of the resulting player profiles to return. For API calls from the client,
        /// only the allowed client profile properties for the title may be requested. These allowed properties are configured in
        /// the Game Manager "Client Profile Options" tab in the "Settings" section.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// Position in the leaderboard to start this listing (defaults to the first entry).
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
    }

    /// <summary>
    /// Note that the Position of the user in the results is for the overall leaderboard. If Facebook friends are included, make
    /// sure the access token from previous LoginWithFacebook call is still valid and not expired. If Xbox Live friends are
    /// included, make sure the access token from the previous LoginWithXbox call is still valid and not expired.
    /// </summary>
    [Serializable]
    public class GetLeaderboardResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;
        /// <summary>
        /// The time the next scheduled reset will occur. Null if the leaderboard does not reset on a schedule.
        /// </summary>
        public DateTime? NextReset;
        /// <summary>
        /// The version of the leaderboard returned.
        /// </summary>
        public int Version;
    }

    [Serializable]
    public class GetPaymentTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The name of service to provide the payment token. Allowed Values are: xsolla
        /// </summary>
        public string TokenProvider;
    }

    [Serializable]
    public class GetPaymentTokenResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab's purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// The token from provider.
        /// </summary>
        public string ProviderToken;
    }

    [Serializable]
    public class GetPhotonAuthenticationTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The Photon applicationId for the game you wish to log into.
        /// </summary>
        public string PhotonApplicationId;
    }

    [Serializable]
    public class GetPhotonAuthenticationTokenResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Photon authentication token for this game-session.
        /// </summary>
        public string PhotonCustomAuthenticationToken;
    }

    [Serializable]
    public class GetPlayerCombinedInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// PlayFabId of the user whose data will be returned. If not filled included, we return the data for the calling player.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetPlayerCombinedInfoRequestParams : PlayFabBaseModel
    {
        /// <summary>
        /// Whether to get character inventories. Defaults to false.
        /// </summary>
        public bool GetCharacterInventories;
        /// <summary>
        /// Whether to get the list of characters. Defaults to false.
        /// </summary>
        public bool GetCharacterList;
        /// <summary>
        /// Whether to get player profile. Defaults to false. Has no effect for a new player.
        /// </summary>
        public bool GetPlayerProfile;
        /// <summary>
        /// Whether to get player statistics. Defaults to false.
        /// </summary>
        public bool GetPlayerStatistics;
        /// <summary>
        /// Whether to get title data. Defaults to false.
        /// </summary>
        public bool GetTitleData;
        /// <summary>
        /// Whether to get the player's account Info. Defaults to false
        /// </summary>
        public bool GetUserAccountInfo;
        /// <summary>
        /// Whether to get the player's custom data. Defaults to false
        /// </summary>
        public bool GetUserData;
        /// <summary>
        /// Whether to get the player's inventory. Defaults to false
        /// </summary>
        public bool GetUserInventory;
        /// <summary>
        /// Whether to get the player's read only data. Defaults to false
        /// </summary>
        public bool GetUserReadOnlyData;
        /// <summary>
        /// Whether to get the player's virtual currency balances. Defaults to false
        /// </summary>
        public bool GetUserVirtualCurrency;
        /// <summary>
        /// Specific statistics to retrieve. Leave null to get all keys. Has no effect if GetPlayerStatistics is false
        /// </summary>
        public List<string> PlayerStatisticNames;
        /// <summary>
        /// Specifies the properties to return from the player profile. Defaults to returning the player's display name.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetTitleData is false
        /// </summary>
        public List<string> TitleDataKeys;
        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetUserData is false
        /// </summary>
        public List<string> UserDataKeys;
        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetUserReadOnlyData is
        /// false
        /// </summary>
        public List<string> UserReadOnlyDataKeys;
    }

    /// <summary>
    /// Returns whatever info is requested in the response for the user. If no user is explicitly requested this defaults to the
    /// authenticated user. If the user is the same as the requester, PII (like email address, facebook id) is returned if
    /// available. Otherwise, only public information is returned. All parameters default to false.
    /// </summary>
    [Serializable]
    public class GetPlayerCombinedInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// Results for requested info.
        /// </summary>
        public GetPlayerCombinedInfoResultPayload InfoResultPayload;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetPlayerCombinedInfoResultPayload : PlayFabBaseModel
    {
        /// <summary>
        /// Account information for the user. This is always retrieved.
        /// </summary>
        public UserAccountInfo AccountInfo;
        /// <summary>
        /// Inventories for each character for the user.
        /// </summary>
        public List<CharacterInventory> CharacterInventories;
        /// <summary>
        /// List of characters for the user.
        /// </summary>
        public List<CharacterResult> CharacterList;
        /// <summary>
        /// The profile of the players. This profile is not guaranteed to be up-to-date. For a new player, this profile will not
        /// exist.
        /// </summary>
        public PlayerProfileModel PlayerProfile;
        /// <summary>
        /// List of statistics for this player.
        /// </summary>
        public List<StatisticValue> PlayerStatistics;
        /// <summary>
        /// Title data for this title.
        /// </summary>
        public Dictionary<string,string> TitleData;
        /// <summary>
        /// User specific custom data.
        /// </summary>
        public Dictionary<string,UserDataRecord> UserData;
        /// <summary>
        /// The version of the UserData that was returned.
        /// </summary>
        public uint UserDataVersion;
        /// <summary>
        /// Array of inventory items in the user's current inventory.
        /// </summary>
        public List<ItemInstance> UserInventory;
        /// <summary>
        /// User specific read-only data.
        /// </summary>
        public Dictionary<string,UserDataRecord> UserReadOnlyData;
        /// <summary>
        /// The version of the Read-Only UserData that was returned.
        /// </summary>
        public uint UserReadOnlyDataVersion;
        /// <summary>
        /// Dictionary of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> UserVirtualCurrency;
        /// <summary>
        /// Dictionary of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> UserVirtualCurrencyRechargeTimes;
    }

    /// <summary>
    /// This API allows for access to details regarding a user in the PlayFab service, usually for purposes of customer support.
    /// Note that data returned may be Personally Identifying Information (PII), such as email address, and so care should be
    /// taken in how this data is stored and managed. Since this call will always return the relevant information for users who
    /// have accessed the title, the recommendation is to not store this data locally.
    /// </summary>
    [Serializable]
    public class GetPlayerProfileRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// If non-null, this determines which properties of the resulting player profiles to return. For API calls from the client,
        /// only the allowed client profile properties for the title may be requested. These allowed properties are configured in
        /// the Game Manager "Client Profile Options" tab in the "Settings" section.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetPlayerProfileResult : PlayFabResultCommon
    {
        /// <summary>
        /// The profile of the player. This profile is not guaranteed to be up-to-date. For a new player, this profile will not
        /// exist.
        /// </summary>
        public PlayerProfileModel PlayerProfile;
    }

    [Serializable]
    public class GetPlayerSegmentsRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetPlayerSegmentsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of segments the requested player currently belongs to.
        /// </summary>
        public List<GetSegmentResult> Segments;
    }

    [Serializable]
    public class GetPlayerStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// statistics to return (current version will be returned for each)
        /// </summary>
        public List<string> StatisticNames;
        /// <summary>
        /// statistics to return, if StatisticNames is not set (only statistics which have a version matching that provided will be
        /// returned)
        /// </summary>
        public List<StatisticNameVersion> StatisticNameVersions;
    }

    /// <summary>
    /// In addition to being available for use by the title, the statistics are used for all leaderboard operations in PlayFab.
    /// </summary>
    [Serializable]
    public class GetPlayerStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// User statistics for the requested user.
        /// </summary>
        public List<StatisticValue> Statistics;
    }

    [Serializable]
    public class GetPlayerStatisticVersionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
    }

    [Serializable]
    public class GetPlayerStatisticVersionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public List<PlayerStatisticVersion> StatisticVersions;
    }

    /// <summary>
    /// This API will return a list of canonical tags which includes both namespace and tag's name. If namespace is not
    /// provided, the result is a list of all canonical tags. TagName can be used for segmentation and Namespace is limited to
    /// 128 characters.
    /// </summary>
    [Serializable]
    public class GetPlayerTagsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Optional namespace to filter results by
        /// </summary>
        public string Namespace;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetPlayerTagsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Canonical tags (including namespace and tag's name) for the requested user
        /// </summary>
        public List<string> Tags;
    }

    [Serializable]
    public class GetPlayerTradesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Returns only trades with the given status. If null, returns all trades.
        /// </summary>
        public TradeStatus? StatusFilter;
    }

    [Serializable]
    public class GetPlayerTradesResponse : PlayFabResultCommon
    {
        /// <summary>
        /// History of trades which this player has accepted.
        /// </summary>
        public List<TradeInfo> AcceptedTrades;
        /// <summary>
        /// The trades for this player which are currently available to be accepted.
        /// </summary>
        public List<TradeInfo> OpenedTrades;
    }

    [Serializable]
    public class GetPlayFabIDsFromFacebookIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Facebook identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> FacebookIDs;
    }

    /// <summary>
    /// For Facebook identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromFacebookIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Facebook identifiers to PlayFab identifiers.
        /// </summary>
        public List<FacebookPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromFacebookInstantGamesIdsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Facebook Instant Games identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> FacebookInstantGamesIds;
    }

    /// <summary>
    /// For Facebook Instant Game identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromFacebookInstantGamesIdsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Facebook Instant Games identifiers to PlayFab identifiers.
        /// </summary>
        public List<FacebookInstantGamesPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromGameCenterIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Game Center identifiers (the Player Identifier) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> GameCenterIDs;
    }

    /// <summary>
    /// For Game Center identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromGameCenterIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Game Center identifiers to PlayFab identifiers.
        /// </summary>
        public List<GameCenterPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromGenericIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique generic service identifiers for which the title needs to get PlayFab identifiers. Currently limited to a
        /// maximum of 10 in a single request.
        /// </summary>
        public List<GenericServiceId> GenericIDs;
    }

    /// <summary>
    /// For generic service identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromGenericIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of generic service identifiers to PlayFab identifiers.
        /// </summary>
        public List<GenericPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromGoogleIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Google identifiers (Google+ user IDs) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> GoogleIDs;
    }

    /// <summary>
    /// For Google identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromGoogleIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Google identifiers to PlayFab identifiers.
        /// </summary>
        public List<GooglePlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromKongregateIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Kongregate identifiers (Kongregate's user_id) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> KongregateIDs;
    }

    /// <summary>
    /// For Kongregate identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromKongregateIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Kongregate identifiers to PlayFab identifiers.
        /// </summary>
        public List<KongregatePlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Nintendo Switch Device identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> NintendoSwitchDeviceIds;
    }

    /// <summary>
    /// For Nintendo Switch identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromNintendoSwitchDeviceIdsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Nintendo Switch Device identifiers to PlayFab identifiers.
        /// </summary>
        public List<NintendoSwitchPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromPSNAccountIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Id of the PSN issuer environment. If null, defaults to production environment.
        /// </summary>
        public int? IssuerId;
        /// <summary>
        /// Array of unique PlayStation Network identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> PSNAccountIDs;
    }

    /// <summary>
    /// For PlayStation Network identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromPSNAccountIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of PlayStation Network identifiers to PlayFab identifiers.
        /// </summary>
        public List<PSNAccountPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromSteamIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Steam identifiers (Steam profile IDs) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> SteamStringIDs;
    }

    /// <summary>
    /// For Steam identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromSteamIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Steam identifiers to PlayFab identifiers.
        /// </summary>
        public List<SteamPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromTwitchIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Twitch identifiers (Twitch's _id) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> TwitchIds;
    }

    /// <summary>
    /// For Twitch identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromTwitchIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Twitch identifiers to PlayFab identifiers.
        /// </summary>
        public List<TwitchPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromXboxLiveIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The ID of Xbox Live sandbox.
        /// </summary>
        public string Sandbox;
        /// <summary>
        /// Array of unique Xbox Live account identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> XboxLiveAccountIDs;
    }

    /// <summary>
    /// For XboxLive identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromXboxLiveIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of PlayStation Network identifiers to PlayFab identifiers.
        /// </summary>
        public List<XboxLiveAccountPlayFabIdPair> Data;
    }

    /// <summary>
    /// This API is designed to return publisher-specific values which can be read, but not written to, by the client. This data
    /// is shared across all titles assigned to a particular publisher, and can be used for cross-game coordination. Only titles
    /// assigned to a publisher can use this API. For more information email helloplayfab@microsoft.com. Note that there may up
    /// to a minute delay in between updating title data and this API call returning the newest value.
    /// </summary>
    [Serializable]
    public class GetPublisherDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// array of keys to get back data from the Publisher data blob, set by the admin tools
        /// </summary>
        public List<string> Keys;
    }

    [Serializable]
    public class GetPublisherDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data;
    }

    [Serializable]
    public class GetPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
    }

    [Serializable]
    public class GetPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Payment provider used for transaction (If not VC)
        /// </summary>
        public string PaymentProvider;
        /// <summary>
        /// Date and time of the purchase.
        /// </summary>
        public DateTime PurchaseDate;
        /// <summary>
        /// Provider transaction ID (If not VC)
        /// </summary>
        public string TransactionId;
        /// <summary>
        /// PlayFab transaction status
        /// </summary>
        public string TransactionStatus;
    }

    [Serializable]
    public class GetSegmentResult : PlayFabBaseModel
    {
        /// <summary>
        /// Identifier of the segments AB Test, if it is attached to one.
        /// </summary>
        public string ABTestParent;
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string Id;
        /// <summary>
        /// Segment name.
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class GetSharedGroupDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// If true, return the list of all members of the shared group.
        /// </summary>
        public bool? GetMembers;
        /// <summary>
        /// Specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array
        /// indicates that no keys should be returned).
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
    }

    [Serializable]
    public class GetSharedGroupDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Data for the requested keys.
        /// </summary>
        public Dictionary<string,SharedGroupDataRecord> Data;
        /// <summary>
        /// List of PlayFabId identifiers for the members of this group, if requested.
        /// </summary>
        public List<string> Members;
    }

    /// <summary>
    /// A store contains an array of references to items defined in one or more catalog versions of the game, along with the
    /// prices for the item, in both real world and virtual currencies. These prices act as an override to any prices defined in
    /// the catalog. In this way, the base definitions of the items may be defined in the catalog, with all associated
    /// properties, while the pricing can be set for each store, as needed. This allows for subsets of goods to be defined for
    /// different purposes (in order to simplify showing some, but not all catalog items to users, based upon different
    /// characteristics), along with unique prices. Note that all prices defined in the catalog and store definitions for the
    /// item are considered valid, and that a compromised client can be made to send a request for an item based upon any of
    /// these definitions. If no price is specified in the store for an item, the price set in the catalog should be displayed
    /// to the user.
    /// </summary>
    [Serializable]
    public class GetStoreItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version to store items from. Use default catalog version if null
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unqiue identifier for the store which is being requested.
        /// </summary>
        public string StoreId;
    }

    [Serializable]
    public class GetStoreItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The base catalog that this store is a part of.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Additional data about the store.
        /// </summary>
        public StoreMarketingModel MarketingData;
        /// <summary>
        /// How the store was last updated (Admin or a third party).
        /// </summary>
        public SourceType? Source;
        /// <summary>
        /// Array of items which can be purchased from this store.
        /// </summary>
        public List<StoreItem> Store;
        /// <summary>
        /// The ID of this store.
        /// </summary>
        public string StoreId;
    }

    /// <summary>
    /// This query retrieves the current time from one of the servers in PlayFab. Please note that due to clock drift between
    /// servers, there is a potential variance of up to 5 seconds.
    /// </summary>
    [Serializable]
    public class GetTimeRequest : PlayFabRequestCommon
    {
    }

    /// <summary>
    /// Time is always returned as Coordinated Universal Time (UTC).
    /// </summary>
    [Serializable]
    public class GetTimeResult : PlayFabResultCommon
    {
        /// <summary>
        /// Current server time when the request was received, in UTC
        /// </summary>
        public DateTime Time;
    }

    /// <summary>
    /// This API is designed to return title specific values which can be read, but not written to, by the client. For example,
    /// a developer could choose to store values which modify the user experience, such as enemy spawn rates, weapon strengths,
    /// movement speeds, etc. This allows a developer to update the title without the need to create, test, and ship a new
    /// build. If the player belongs to an experiment variant that uses title data overrides, the overrides are applied
    /// automatically and returned with the title data. Note that there may up to a minute delay in between updating title data
    /// and this API call returning the newest value.
    /// </summary>
    [Serializable]
    public class GetTitleDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specific keys to search for in the title data (leave null to get all keys)
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// Optional field that specifies the name of an override. This value is ignored when used by the game client; otherwise,
        /// the overrides are applied automatically to the title data.
        /// </summary>
        public string OverrideLabel;
    }

    [Serializable]
    public class GetTitleDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data;
    }

    [Serializable]
    public class GetTitleNewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Limits the results to the last n entries. Defaults to 10 if not set.
        /// </summary>
        public int? Count;
    }

    [Serializable]
    public class GetTitleNewsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of news items.
        /// </summary>
        public List<TitleNewsItem> News;
    }

    /// <summary>
    /// An RSA CSP blob to be used to encrypt the payload of account creation requests when that API requires a signature
    /// header. For example if Client/LoginWithCustomId requires signature headers but the player does not have an account yet
    /// follow these steps: 1) Call Client/GetTitlePublicKey with one of the title's shared secrets. 2) Convert the Base64
    /// encoded CSP blob to a byte array and create an RSA signing object. 3) Encrypt the UTF8 encoded JSON body of the
    /// registration request and place the Base64 encoded result into the EncryptedRequest and with the TitleId field, all other
    /// fields can be left empty when performing the API request. 4) Client receives authentication token as normal. Future
    /// requests to LoginWithCustomId will require the X-PlayFab-Signature header.
    /// </summary>
    [Serializable]
    public class GetTitlePublicKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// The shared secret key for this title
        /// </summary>
        public string TitleSharedSecret;
    }

    [Serializable]
    public class GetTitlePublicKeyResult : PlayFabResultCommon
    {
        /// <summary>
        /// Base64 encoded RSA CSP byte array blob containing the title's public RSA key
        /// </summary>
        public string RSAPublicKey;
    }

    [Serializable]
    public class GetTradeStatusRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Player who opened trade.
        /// </summary>
        public string OfferingPlayerId;
        /// <summary>
        /// Trade identifier as returned by OpenTradeOffer.
        /// </summary>
        public string TradeId;
    }

    [Serializable]
    public class GetTradeStatusResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Information about the requested trade.
        /// </summary>
        public TradeInfo Trade;
    }

    /// <summary>
    /// Data is stored as JSON key-value pairs. Every time the data is updated via any source, the version counter is
    /// incremented. If the Version parameter is provided, then this call will only return data if the current version on the
    /// system is greater than the value provided. If the Keys parameter is provided, the data object returned will only contain
    /// the data specific to the indicated Keys. Otherwise, the full set of custom user data will be returned.
    /// </summary>
    [Serializable]
    public class GetUserDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the
        /// version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion;
        /// <summary>
        /// List of unique keys to load from.
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// Unique PlayFab identifier of the user to load data for. Optional, defaults to yourself if not set. When specified to a
        /// PlayFab id of another player, then this will only return public keys for that account.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data;
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of
        /// data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    [Serializable]
    public class GetUserInventoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// All items currently in the user inventory will be returned, irrespective of how they were acquired (via purchasing,
    /// grants, coupons, etc.). Items that are expired, fully consumed, or are no longer valid are not considered to be in the
    /// user's current inventory, and so will not be not included.
    /// </summary>
    [Serializable]
    public class GetUserInventoryResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of inventory items belonging to the user.
        /// </summary>
        public List<ItemInstance> Inventory;
        /// <summary>
        /// Array of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency;
        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes;
    }

    [Serializable]
    public class GooglePlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Google identifier for a user.
        /// </summary>
        public string GoogleId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Google identifier.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// Grants a character to the user of the type specified by the item ID. The user must already have an instance of this item
    /// in their inventory in order to allow character creation. This item can come from a purchase or grant, which must be done
    /// before calling to create the character.
    /// </summary>
    [Serializable]
    public class GrantCharacterToUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Non-unique display name of the character being granted (1-40 characters in length).
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Catalog item identifier of the item in the user's inventory that corresponds to the character in the catalog to be
        /// created.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class GrantCharacterToUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier tagged to this character.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Type of character that was created.
        /// </summary>
        public string CharacterType;
        /// <summary>
        /// Indicates whether this character was created successfully.
        /// </summary>
        public bool Result;
    }

    /// <summary>
    /// A unique instance of an item in a user's inventory. Note, to retrieve additional information for an item such as Tags,
    /// Description that are the same across all instances of the item, a call to GetCatalogItems is required. The ItemID of can
    /// be matched to a catalog entry, which contains the additional information. Also note that Custom Data is only set when
    /// the User's specific instance has updated the CustomData via a call to UpdateUserInventoryItemCustomData. Other fields
    /// such as UnitPrice and UnitCurrency are only set when the item was granted via a purchase.
    /// </summary>
    [Serializable]
    public class ItemInstance : PlayFabBaseModel
    {
        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents;
        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or
        /// container.
        /// </summary>
        public string BundleParent;
        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// A set of custom key-value pairs on the instance of the inventory item, which is not to be confused with the catalog
        /// item's custom data.
        /// </summary>
        public Dictionary<string,string> CustomData;
        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration;
        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass;
        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate;
        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses;
        /// <summary>
        /// Currency type for the cost of the catalog item. Not available when granting items.
        /// </summary>
        public string UnitCurrency;
        /// <summary>
        /// Cost of the catalog item in the given currency. Not available when granting items.
        /// </summary>
        public uint UnitPrice;
        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy;
    }

    [Serializable]
    public class ItemPurchaseRequest : PlayFabBaseModel
    {
        /// <summary>
        /// Title-specific text concerning this purchase.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Unique ItemId of the item to purchase.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// How many of this item to purchase. Min 1, maximum 25.
        /// </summary>
        public uint Quantity;
        /// <summary>
        /// Items to be upgraded as a result of this purchase (upgraded items are hidden, as they are "replaced" by the new items).
        /// </summary>
        public List<string> UpgradeFromItems;
    }

    [Serializable]
    public class KongregatePlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Kongregate identifier for a user.
        /// </summary>
        public string KongregateId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Kongregate identifier.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class LinkAndroidDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string AndroidDevice;
        /// <summary>
        /// Android device identifier for the user's device.
        /// </summary>
        public string AndroidDeviceId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the device, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
    }

    [Serializable]
    public class LinkAndroidDeviceIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to a specific Apple account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in the authorization
        /// credential payload. Used to validate the request and find the user ID (Apple subject) to link with.
        /// </summary>
        public string IdentityToken;
    }

    [Serializable]
    public class LinkCustomIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom unique identifier for the user, generated by the title.
        /// </summary>
        public string CustomId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the custom ID, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkCustomIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkedPlatformAccountModel : PlayFabBaseModel
    {
        /// <summary>
        /// Linked account email of the user on the platform, if available
        /// </summary>
        public string Email;
        /// <summary>
        /// Authentication platform
        /// </summary>
        public LoginIdentityProvider? Platform;
        /// <summary>
        /// Unique account identifier of the user on the platform
        /// </summary>
        public string PlatformUserId;
        /// <summary>
        /// Linked account username of the user on the platform, if available
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// Facebook sign-in is accomplished using the Facebook User Access Token. More information on the Token can be found in the
    /// Facebook developer documentation (https://developers.facebook.com/docs/facebook-login/access-tokens/). In Unity, for
    /// example, the Token is available as AccessToken in the Facebook SDK ScriptableObject FB. Note that titles should never
    /// re-use the same Facebook applications between PlayFab Title IDs, as Facebook provides unique user IDs per application
    /// and doing so can result in issues with the Facebook ID for the user in their PlayFab account information. If you must
    /// re-use an application in a new PlayFab Title ID, please be sure to first unlink all accounts from Facebook, or delete
    /// all users in the first Title ID.
    /// </summary>
    [Serializable]
    public class LinkFacebookAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier from Facebook for the user.
        /// </summary>
        public string AccessToken;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkFacebookAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkFacebookInstantGamesIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Facebook Instant Games signature for the user.
        /// </summary>
        public string FacebookInstantGamesSignature;
        /// <summary>
        /// If another user is already linked to the Facebook Instant Games ID, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkFacebookInstantGamesIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkGameCenterAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link. If the current user is already
        /// linked, link both accounts
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Game Center identifier for the player account to be linked.
        /// </summary>
        public string GameCenterId;
        /// <summary>
        /// The URL for the public encryption key that will be used to verify the signature.
        /// </summary>
        public string PublicKeyUrl;
        /// <summary>
        /// A random value used to compute the hash and keep it randomized.
        /// </summary>
        public string Salt;
        /// <summary>
        /// The verification signature of the authentication payload.
        /// </summary>
        public string Signature;
        /// <summary>
        /// The integer representation of date and time that the signature was created on. PlayFab will reject authentication
        /// signatures not within 10 minutes of the server's current time.
        /// </summary>
        public string Timestamp;
    }

    [Serializable]
    public class LinkGameCenterAccountResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Google sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google sign-in for Android APIs on
    /// the device and passing it to this API.
    /// </summary>
    [Serializable]
    public class LinkGoogleAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link. If the current user is already
        /// linked, link both accounts
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Server authentication code obtained on the client by calling getServerAuthCode()
        /// (https://developers.google.com/identity/sign-in/android/offline-access) from Google Play for the user.
        /// </summary>
        public string ServerAuthCode;
    }

    [Serializable]
    public class LinkGoogleAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkIOSDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId;
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string DeviceModel;
        /// <summary>
        /// If another user is already linked to the device, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
    }

    [Serializable]
    public class LinkIOSDeviceIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkKongregateAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Valid session auth ticket issued by Kongregate
        /// </summary>
        public string AuthTicket;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Numeric user ID assigned by Kongregate
        /// </summary>
        public string KongregateId;
    }

    [Serializable]
    public class LinkKongregateAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkNintendoServiceAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to a specific Nintendo Switch account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// The JSON Web token (JWT) returned by Nintendo after login. Used to validate the request and find the user ID (Nintendo
        /// Switch subject) to link with.
        /// </summary>
        public string IdentityToken;
    }

    [Serializable]
    public class LinkNintendoSwitchDeviceIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the Nintendo Switch Device ID, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Nintendo Switch unique identifier for the user's device.
        /// </summary>
        public string NintendoSwitchDeviceId;
    }

    [Serializable]
    public class LinkNintendoSwitchDeviceIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkOpenIdConnectRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A name that identifies which configured OpenID Connect provider relationship to use. Maximum 100 characters.
        /// </summary>
        public string ConnectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to a specific OpenId Connect user, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// The JSON Web token (JWT) returned by the identity provider after login. Represented as the id_token field in the
        /// identity provider's response. Used to validate the request and find the user ID (OpenID Connect subject) to link with.
        /// </summary>
        public string IdToken;
    }

    [Serializable]
    public class LinkPSNAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Authentication code provided by the PlayStation Network.
        /// </summary>
        public string AuthCode;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Id of the PSN issuer environment. If null, defaults to production environment.
        /// </summary>
        public int? IssuerId;
        /// <summary>
        /// Redirect URI supplied to PSN when requesting an auth code
        /// </summary>
        public string RedirectUri;
    }

    [Serializable]
    public class LinkPSNAccountResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Steam authentication is accomplished with the Steam Session Ticket. More information on the Ticket can be found in the
    /// Steamworks SDK, here: https://partner.steamgames.com/documentation/auth (requires sign-in). NOTE: For Steam
    /// authentication to work, the title must be configured with the Steam Application ID and Publisher Key in the PlayFab Game
    /// Manager (under Properties). Information on creating a Publisher Key (referred to as the Secret Key in PlayFab) for your
    /// title can be found here: https://partner.steamgames.com/documentation/webapi#publisherkey.
    /// </summary>
    [Serializable]
    public class LinkSteamAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte
        /// 0x08 should become "08").
        /// </summary>
        public string SteamTicket;
    }

    [Serializable]
    public class LinkSteamAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkTwitchAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Valid token issued by Twitch
        /// </summary>
        public string AccessToken;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkTwitchAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkXboxAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Token provided by the Xbox Live SDK/XDK method GetTokenAndSignatureAsync("POST", "https://playfabapi.com/", "").
        /// </summary>
        public string XboxToken;
    }

    [Serializable]
    public class LinkXboxAccountResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Returns a list of every character that currently belongs to a user.
    /// </summary>
    [Serializable]
    public class ListUsersCharactersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class ListUsersCharactersResult : PlayFabResultCommon
    {
        /// <summary>
        /// The requested list of characters.
        /// </summary>
        public List<CharacterResult> Characters;
    }

    [Serializable]
    public class LocationModel : PlayFabBaseModel
    {
        /// <summary>
        /// City name.
        /// </summary>
        public string City;
        /// <summary>
        /// The two-character continent code for this location
        /// </summary>
        public ContinentCode? ContinentCode;
        /// <summary>
        /// The two-character ISO 3166-1 country code for the country associated with the location
        /// </summary>
        public CountryCode? CountryCode;
        /// <summary>
        /// Latitude coordinate of the geographic location.
        /// </summary>
        public double? Latitude;
        /// <summary>
        /// Longitude coordinate of the geographic location.
        /// </summary>
        public double? Longitude;
    }

    public enum LoginIdentityProvider
    {
        Unknown,
        PlayFab,
        Custom,
        GameCenter,
        GooglePlay,
        Steam,
        XBoxLive,
        PSN,
        Kongregate,
        Facebook,
        IOSDevice,
        AndroidDevice,
        Twitch,
        WindowsHello,
        GameServer,
        CustomServer,
        NintendoSwitch,
        FacebookInstantGames,
        OpenIdConnect,
        Apple,
        NintendoSwitchAccount
    }

    [Serializable]
    public class LoginResult : PlayFabLoginResultCommon
    {
        /// <summary>
        /// If LoginTitlePlayerAccountEntity flag is set on the login request the title_player_account will also be logged in and
        /// returned.
        /// </summary>
        public EntityTokenResponse EntityToken;
        /// <summary>
        /// Results for requested info.
        /// </summary>
        public GetPlayerCombinedInfoResultPayload InfoResultPayload;
        /// <summary>
        /// The time of this user's previous login. If there was no previous login, then it's DateTime.MinValue
        /// </summary>
        public DateTime? LastLoginTime;
        /// <summary>
        /// True if the account was newly created on this login.
        /// </summary>
        public bool NewlyCreated;
        /// <summary>
        /// Player's unique PlayFabId.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique token authorizing the user and game at the server level, for the current session.
        /// </summary>
        public string SessionTicket;
        /// <summary>
        /// Settings specific to this user.
        /// </summary>
        public UserSettings SettingsForUser;
        /// <summary>
        /// The experimentation treatments for this user at the time of login.
        /// </summary>
        public TreatmentAssignment TreatmentAssignment;
    }

    /// <summary>
    /// On Android devices, the recommendation is to use the Settings.Secure.ANDROID_ID as the AndroidDeviceId, as described in
    /// this blog post (http://android-developers.blogspot.com/2011/03/identifying-app-installations.html). More information on
    /// this identifier can be found in the Android documentation
    /// (http://developer.android.com/reference/android/provider/Settings.Secure.html). If this is the first time a user has
    /// signed in with the Android device and CreateAccount is set to true, a new PlayFab account will be created and linked to
    /// the Android device ID. In this case, no email or username will be associated with the PlayFab account. Otherwise, if no
    /// PlayFab account is linked to the Android device, an error indicating this will be returned, so that the title can guide
    /// the user through creation of a PlayFab account. Please note that while multiple devices of this type can be linked to a
    /// single user account, only the one most recently used to login (or most recently linked) will be reflected in the user's
    /// account information. We will be updating to show all linked devices in a future release.
    /// </summary>
    [Serializable]
    public class LoginWithAndroidDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string AndroidDevice;
        /// <summary>
        /// Android device identifier for the user's device.
        /// </summary>
        public string AndroidDeviceId;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class LoginWithAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// The JSON Web token (JWT) returned by Apple after login. Represented as the identityToken field in the authorization
        /// credential payload.
        /// </summary>
        public string IdentityToken;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// It is highly recommended that developers ensure that it is extremely unlikely that a customer could generate an ID which
    /// is already in use by another customer. If this is the first time a user has signed in with the Custom ID and
    /// CreateAccount is set to true, a new PlayFab account will be created and linked to the Custom ID. In this case, no email
    /// or username will be associated with the PlayFab account. Otherwise, if no PlayFab account is linked to the Custom ID, an
    /// error indicating this will be returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    [Serializable]
    public class LoginWithCustomIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Custom unique identifier for the user, generated by the title.
        /// </summary>
        public string CustomId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// Email address and password lengths are provided for information purposes. The server will validate that data passed in
    /// conforms to the field definition and report errors appropriately. It is recommended that developers not perform this
    /// validation locally, so that future updates do not require client updates.
    /// </summary>
    [Serializable]
    public class LoginWithEmailAddressRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Email address for the account.
        /// </summary>
        public string Email;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class LoginWithFacebookInstantGamesIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Facebook Instant Games signature for the user.
        /// </summary>
        public string FacebookInstantGamesSignature;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// Facebook sign-in is accomplished using the Facebook User Access Token. More information on the Token can be found in the
    /// Facebook developer documentation (https://developers.facebook.com/docs/facebook-login/access-tokens/). In Unity, for
    /// example, the Token is available as AccessToken in the Facebook SDK ScriptableObject FB. If this is the first time a user
    /// has signed in with the Facebook account and CreateAccount is set to true, a new PlayFab account will be created and
    /// linked to the provided account's Facebook ID. In this case, no email or username will be associated with the PlayFab
    /// account. Otherwise, if no PlayFab account is linked to the Facebook account, an error indicating this will be returned,
    /// so that the title can guide the user through creation of a PlayFab account. Note that titles should never re-use the
    /// same Facebook applications between PlayFab Title IDs, as Facebook provides unique user IDs per application and doing so
    /// can result in issues with the Facebook ID for the user in their PlayFab account information. If you must re-use an
    /// application in a new PlayFab Title ID, please be sure to first unlink all accounts from Facebook, or delete all users in
    /// the first Title ID.
    /// </summary>
    [Serializable]
    public class LoginWithFacebookRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier from Facebook for the user.
        /// </summary>
        public string AccessToken;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// The Game Center player identifier
    /// (https://developer.apple.com/library/ios/documentation/Accounts/Reference/ACAccountClassRef/index.html#//apple_ref/occ/instp/ACAccount/identifier)
    /// is a generated string which is stored on the local device. As with device identifiers, care must be taken to never
    /// expose a player's Game Center identifier to end users, as that could result in a user's account being compromised. If
    /// this is the first time a user has signed in with Game Center and CreateAccount is set to true, a new PlayFab account
    /// will be created and linked to the Game Center identifier. In this case, no email or username will be associated with the
    /// PlayFab account. Otherwise, if no PlayFab account is linked to the Game Center account, an error indicating this will be
    /// returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    [Serializable]
    public class LoginWithGameCenterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Unique Game Center player id.
        /// </summary>
        public string PlayerId;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// The URL for the public encryption key that will be used to verify the signature.
        /// </summary>
        public string PublicKeyUrl;
        /// <summary>
        /// A random value used to compute the hash and keep it randomized.
        /// </summary>
        public string Salt;
        /// <summary>
        /// The verification signature of the authentication payload.
        /// </summary>
        public string Signature;
        /// <summary>
        /// The integer representation of date and time that the signature was created on. PlayFab will reject authentication
        /// signatures not within 10 minutes of the server's current time.
        /// </summary>
        public string Timestamp;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// Google sign-in is accomplished by obtaining a Google OAuth 2.0 credential using the Google sign-in for Android APIs on
    /// the device and passing it to this API. If this is the first time a user has signed in with the Google account and
    /// CreateAccount is set to true, a new PlayFab account will be created and linked to the Google account. Otherwise, if no
    /// PlayFab account is linked to the Google account, an error indicating this will be returned, so that the title can guide
    /// the user through creation of a PlayFab account. The current (recommended) method for obtaining a Google account
    /// credential in an Android application is to call GoogleSignInAccount.getServerAuthCode() and send the auth code as the
    /// ServerAuthCode parameter of this API. Before doing this, you must create an OAuth 2.0 web application client ID in the
    /// Google API Console and configure its client ID and secret in the PlayFab Game Manager Google Add-on for your title. This
    /// method does not require prompting of the user for additional Google account permissions, resulting in a user experience
    /// with the least possible friction. For more information about obtaining the server auth code, see
    /// https://developers.google.com/identity/sign-in/android/offline-access. The previous (deprecated) method was to obtain an
    /// OAuth access token by calling GetAccessToken() on the client and passing it as the AccessToken parameter to this API.
    /// for the with the Google OAuth 2.0 Access Token. More information on this change can be found in the Google developer
    /// documentation (https://android-developers.googleblog.com/2016/01/play-games-permissions-are-changing-in.html).
    /// </summary>
    [Serializable]
    public class LoginWithGoogleAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// OAuth 2.0 server authentication code obtained on the client by calling the getServerAuthCode()
        /// (https://developers.google.com/identity/sign-in/android/offline-access) Google client API.
        /// </summary>
        public string ServerAuthCode;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// On iOS devices, the identifierForVendor
    /// (https://developer.apple.com/library/ios/documentation/UIKit/Reference/UIDevice_Class/index.html#//apple_ref/occ/instp/UIDevice/identifierForVendor)
    /// must be used as the DeviceId, as the UIDevice uniqueIdentifier has been deprecated as of iOS 5, and use of the
    /// advertisingIdentifier for this purpose will result in failure of Apple's certification process. If this is the first
    /// time a user has signed in with the iOS device and CreateAccount is set to true, a new PlayFab account will be created
    /// and linked to the vendor-specific iOS device ID. In this case, no email or username will be associated with the PlayFab
    /// account. Otherwise, if no PlayFab account is linked to the iOS device, an error indicating this will be returned, so
    /// that the title can guide the user through creation of a PlayFab account. Please note that while multiple devices of this
    /// type can be linked to a single user account, only the one most recently used to login (or most recently linked) will be
    /// reflected in the user's account information. We will be updating to show all linked devices in a future release.
    /// </summary>
    [Serializable]
    public class LoginWithIOSDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId;
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string DeviceModel;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// More details regarding Kongregate and their game authentication system can be found at
    /// http://developers.kongregate.com/docs/virtual-goods/authentication. Developers must provide the Kongregate user ID and
    /// auth token that are generated using the Kongregate client library. PlayFab will combine these identifiers with the
    /// title's unique Kongregate app ID to log the player into the Kongregate system. If CreateAccount is set to true and there
    /// is not already a user matched to this Kongregate ID, then PlayFab will create a new account for this user and link the
    /// ID. In this case, no email or username will be associated with the PlayFab account. If there is already a different
    /// PlayFab user linked with this account, then an error will be returned.
    /// </summary>
    [Serializable]
    public class LoginWithKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Token issued by Kongregate's client API for the user.
        /// </summary>
        public string AuthTicket;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Numeric user ID assigned by Kongregate
        /// </summary>
        public string KongregateId;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class LoginWithNintendoServiceAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// The JSON Web token (JWT) returned by Nintendo after login.
        /// </summary>
        public string IdentityToken;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class LoginWithNintendoSwitchDeviceIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Nintendo Switch unique identifier for the user's device.
        /// </summary>
        public string NintendoSwitchDeviceId;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class LoginWithOpenIdConnectRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A name that identifies which configured OpenID Connect provider relationship to use. Maximum 100 characters.
        /// </summary>
        public string ConnectionId;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// The JSON Web token (JWT) returned by the identity provider after login. Represented as the id_token field in the
        /// identity provider's response.
        /// </summary>
        public string IdToken;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// Username and password lengths are provided for information purposes. The server will validate that data passed in
    /// conforms to the field definition and report errors appropriately. It is recommended that developers not perform this
    /// validation locally, so that future updates to the username or password do not require client updates.
    /// </summary>
    [Serializable]
    public class LoginWithPlayFabRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// PlayFab username for the account.
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// If this is the first time a user has signed in with the PlayStation Network account and CreateAccount is set to true, a
    /// new PlayFab account will be created and linked to the PSN account. In this case, no email or username will be associated
    /// with the PlayFab account. Otherwise, if no PlayFab account is linked to the PSN account, an error indicating this will
    /// be returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    [Serializable]
    public class LoginWithPSNRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Auth code provided by the PSN OAuth provider.
        /// </summary>
        public string AuthCode;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Id of the PSN issuer environment. If null, defaults to production environment.
        /// </summary>
        public int? IssuerId;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Redirect URI supplied to PSN when requesting an auth code
        /// </summary>
        public string RedirectUri;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// Steam sign-in is accomplished with the Steam Session Ticket. More information on the Ticket can be found in the
    /// Steamworks SDK, here: https://partner.steamgames.com/documentation/auth (requires sign-in). NOTE: For Steam
    /// authentication to work, the title must be configured with the Steam Application ID and Web API Key in the PlayFab Game
    /// Manager (under Steam in the Add-ons Marketplace). You can obtain a Web API Key from the Permissions page of any Group
    /// associated with your App ID in the Steamworks site. If this is the first time a user has signed in with the Steam
    /// account and CreateAccount is set to true, a new PlayFab account will be created and linked to the provided account's
    /// Steam ID. In this case, no email or username will be associated with the PlayFab account. Otherwise, if no PlayFab
    /// account is linked to the Steam account, an error indicating this will be returned, so that the title can guide the user
    /// through creation of a PlayFab account.
    /// </summary>
    [Serializable]
    public class LoginWithSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte
        /// 0x08 should become "08").
        /// </summary>
        public string SteamTicket;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// More details regarding Twitch and their authentication system can be found at
    /// https://github.com/justintv/Twitch-API/blob/master/authentication.md. Developers must provide the Twitch access token
    /// that is generated using one of the Twitch authentication flows. PlayFab will use the title's unique Twitch Client ID to
    /// authenticate the token and log in to the PlayFab system. If CreateAccount is set to true and there is not already a user
    /// matched to the Twitch username that generated the token, then PlayFab will create a new account for this user and link
    /// the ID. In this case, no email or username will be associated with the PlayFab account. If there is already a different
    /// PlayFab user linked with this account, then an error will be returned.
    /// </summary>
    [Serializable]
    public class LoginWithTwitchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Token issued by Twitch's API for the user.
        /// </summary>
        public string AccessToken;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    /// <summary>
    /// If this is the first time a user has signed in with the Xbox Live account and CreateAccount is set to true, a new
    /// PlayFab account will be created and linked to the Xbox Live account. In this case, no email or username will be
    /// associated with the PlayFab account. Otherwise, if no PlayFab account is linked to the Xbox Live account, an error
    /// indicating this will be returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    [Serializable]
    public class LoginWithXboxRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Token provided by the Xbox Live SDK/XDK method GetTokenAndSignatureAsync("POST", "https://playfabapi.com/", "").
        /// </summary>
        public string XboxToken;
    }

    [Serializable]
    public class LogStatement : PlayFabBaseModel
    {
        /// <summary>
        /// Optional object accompanying the message as contextual information
        /// </summary>
        public object Data;
        /// <summary>
        /// 'Debug', 'Info', or 'Error'
        /// </summary>
        public string Level;
        public string Message;
    }

    [Serializable]
    public class MatchmakeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Build version to match against. [Note: Required if LobbyId is not specified]
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// Character to use for stats based matching. Leave null to use account stats.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Game mode to match make against. [Note: Required if LobbyId is not specified]
        /// </summary>
        public string GameMode;
        /// <summary>
        /// Lobby identifier to match make against. This is used to select a specific Game Server Instance.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// Region to match make against. [Note: Required if LobbyId is not specified]
        /// </summary>
        public Region? Region;
        /// <summary>
        /// Start a game session if one with an open slot is not found. Defaults to true.
        /// </summary>
        public bool? StartNewIfNoneFound;
        /// <summary>
        /// Player statistic to use in finding a match. May be null for no stat-based matching.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Filter to include and/or exclude Game Server Instances associated with certain Tags
        /// </summary>
        public CollectionFilter TagFilter;
    }

    [Serializable]
    public class MatchmakeResult : PlayFabResultCommon
    {
        /// <summary>
        /// timestamp for when the server will expire, if applicable
        /// </summary>
        public string Expires;
        /// <summary>
        /// unique lobby identifier of the server matched
        /// </summary>
        public string LobbyID;
        /// <summary>
        /// time in milliseconds the application is configured to wait on matchmaking results
        /// </summary>
        public int? PollWaitTimeMS;
        /// <summary>
        /// IPV4 address of the server
        /// </summary>
        public string ServerIPV4Address;
        /// <summary>
        /// IPV6 address of the server
        /// </summary>
        public string ServerIPV6Address;
        /// <summary>
        /// port number to use for non-http communications with the server
        /// </summary>
        public int? ServerPort;
        /// <summary>
        /// Public DNS name (if any) of the server
        /// </summary>
        public string ServerPublicDNSName;
        /// <summary>
        /// result of match making process
        /// </summary>
        public MatchmakeStatus? Status;
        /// <summary>
        /// server authorization ticket (used by RedeemMatchmakerTicket to validate user insertion into the game)
        /// </summary>
        public string Ticket;
    }

    public enum MatchmakeStatus
    {
        Complete,
        Waiting,
        GameNotFound,
        NoAvailableSlots,
        SessionClosed
    }

    [Serializable]
    public class MembershipModel : PlayFabBaseModel
    {
        /// <summary>
        /// Whether this membership is active. That is, whether the MembershipExpiration time has been reached.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// The time this membership expires
        /// </summary>
        public DateTime MembershipExpiration;
        /// <summary>
        /// The id of the membership
        /// </summary>
        public string MembershipId;
        /// <summary>
        /// Membership expirations can be explicitly overridden (via game manager or the admin api). If this membership has been
        /// overridden, this will be the new expiration time.
        /// </summary>
        public DateTime? OverrideExpiration;
        /// <summary>
        /// The list of subscriptions that this player has for this membership
        /// </summary>
        public List<SubscriptionModel> Subscriptions;
    }

    [Serializable]
    public class MicrosoftStorePayload : PlayFabBaseModel
    {
        /// <summary>
        /// Microsoft store ID key. This is optional. Alternatively you can use XboxToken
        /// </summary>
        public string CollectionsMsIdKey;
        /// <summary>
        /// If collectionsMsIdKey is provided, this will verify the user id in the collectionsMsIdKey is the same.
        /// </summary>
        public string UserId;
        /// <summary>
        /// Token provided by the Xbox Live SDK/XDK method GetTokenAndSignatureAsync("POST", "https://playfabapi.com/", ""). This is
        /// optional. Alternatively can use CollectionsMsIdKey
        /// </summary>
        public string XboxToken;
    }

    [Serializable]
    public class ModifyUserVirtualCurrencyResult : PlayFabResultCommon
    {
        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance;
        /// <summary>
        /// Amount added or subtracted from the user's virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase
        /// over this value will be discarded.
        /// </summary>
        public int BalanceChange;
        /// <summary>
        /// User currency was subtracted from.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency;
    }

    /// <summary>
    /// Identifier by either name or ID. Note that a name may change due to renaming, or reused after being deleted. ID is
    /// immutable and unique.
    /// </summary>
    [Serializable]
    public class NameIdentifier : PlayFabBaseModel
    {
        /// <summary>
        /// Id Identifier, if present
        /// </summary>
        public string Id;
        /// <summary>
        /// Name Identifier, if present
        /// </summary>
        public string Name;
    }

    [Serializable]
    public class NintendoSwitchPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Nintendo Switch Device identifier for a user.
        /// </summary>
        public string NintendoSwitchDeviceId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Nintendo Switch Device identifier.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class OpenTradeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Players who are allowed to accept the trade. If null, the trade may be accepted by any player. If empty, the trade may
        /// not be accepted by any player.
        /// </summary>
        public List<string> AllowedPlayerIds;
        /// <summary>
        /// Player inventory items offered for trade. If not set, the trade is effectively a gift request
        /// </summary>
        public List<string> OfferedInventoryInstanceIds;
        /// <summary>
        /// Catalog items accepted for the trade. If not set, the trade is effectively a gift.
        /// </summary>
        public List<string> RequestedCatalogItemIds;
    }

    [Serializable]
    public class OpenTradeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The information about the trade that was just opened.
        /// </summary>
        public TradeInfo Trade;
    }

    /// <summary>
    /// This is the second step in the purchasing process, initiating the purchase transaction with the payment provider (if
    /// applicable). For payment provider scenarios, the title should next present the user with the payment provider'sinterface
    /// for payment. Once the player has completed the payment with the provider, the title should call ConfirmPurchase
    /// tofinalize the process and add the appropriate items to the player inventory.
    /// </summary>
    [Serializable]
    public class PayForPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Currency to use to fund the purchase.
        /// </summary>
        public string Currency;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Purchase order identifier returned from StartPurchase.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Payment provider to use to fund the purchase.
        /// </summary>
        public string ProviderName;
        /// <summary>
        /// Payment provider transaction identifier. Required for Facebook Payments.
        /// </summary>
        public string ProviderTransactionId;
    }

    /// <summary>
    /// For web-based payment providers, this operation returns the URL to which the user should be directed inorder to approve
    /// the purchase. Items added to the user inventory as a result of this operation will be marked as unconfirmed.
    /// </summary>
    [Serializable]
    public class PayForPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Local credit applied to the transaction (provider specific).
        /// </summary>
        public uint CreditApplied;
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Provider used for the transaction.
        /// </summary>
        public string ProviderData;
        /// <summary>
        /// A token generated by the provider to authenticate the request (provider-specific).
        /// </summary>
        public string ProviderToken;
        /// <summary>
        /// URL to the purchase provider page that details the purchase.
        /// </summary>
        public string PurchaseConfirmationPageURL;
        /// <summary>
        /// Currency for the transaction, may be a virtual currency or real money.
        /// </summary>
        public string PurchaseCurrency;
        /// <summary>
        /// Cost of the transaction.
        /// </summary>
        public uint PurchasePrice;
        /// <summary>
        /// Status of the transaction.
        /// </summary>
        public TransactionStatus? Status;
        /// <summary>
        /// Virtual currencies granted by the transaction, if any.
        /// </summary>
        public Dictionary<string,int> VCAmount;
        /// <summary>
        /// Current virtual currency balances for the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency;
    }

    [Serializable]
    public class PaymentOption : PlayFabBaseModel
    {
        /// <summary>
        /// Specific currency to use to fund the purchase.
        /// </summary>
        public string Currency;
        /// <summary>
        /// Amount of the specified currency needed for the purchase.
        /// </summary>
        public uint Price;
        /// <summary>
        /// Name of the purchase provider for this option.
        /// </summary>
        public string ProviderName;
        /// <summary>
        /// Amount of existing credit the user has with the provider.
        /// </summary>
        public uint StoreCredit;
    }

    [Serializable]
    public class PlayerLeaderboardEntry : PlayFabBaseModel
    {
        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position;
        /// <summary>
        /// The profile of the user, if requested.
        /// </summary>
        public PlayerProfileModel Profile;
        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue;
    }

    [Serializable]
    public class PlayerProfileModel : PlayFabBaseModel
    {
        /// <summary>
        /// List of advertising campaigns the player has been attributed to
        /// </summary>
        public List<AdCampaignAttributionModel> AdCampaignAttributions;
        /// <summary>
        /// URL of the player's avatar image
        /// </summary>
        public string AvatarUrl;
        /// <summary>
        /// If the player is currently banned, the UTC Date when the ban expires
        /// </summary>
        public DateTime? BannedUntil;
        /// <summary>
        /// List of all contact email info associated with the player account
        /// </summary>
        public List<ContactEmailInfoModel> ContactEmailAddresses;
        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created;
        /// <summary>
        /// Player display name
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// List of experiment variants for the player. Note that these variants are not guaranteed to be up-to-date when returned
        /// during login because the player profile is updated only after login. Instead, use the LoginResult.TreatmentAssignment
        /// property during login to get the correct variants and variables.
        /// </summary>
        public List<string> ExperimentVariants;
        /// <summary>
        /// UTC time when the player most recently logged in to the title
        /// </summary>
        public DateTime? LastLogin;
        /// <summary>
        /// List of all authentication systems linked to this player account
        /// </summary>
        public List<LinkedPlatformAccountModel> LinkedAccounts;
        /// <summary>
        /// List of geographic locations from which the player has logged in to the title
        /// </summary>
        public List<LocationModel> Locations;
        /// <summary>
        /// List of memberships for the player, along with whether are expired.
        /// </summary>
        public List<MembershipModel> Memberships;
        /// <summary>
        /// Player account origination
        /// </summary>
        public LoginIdentityProvider? Origination;
        /// <summary>
        /// PlayFab player account unique identifier
        /// </summary>
        public string PlayerId;
        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId;
        /// <summary>
        /// List of configured end points registered for sending the player push notifications
        /// </summary>
        public List<PushNotificationRegistrationModel> PushNotificationRegistrations;
        /// <summary>
        /// List of leaderboard statistic values for the player
        /// </summary>
        public List<StatisticModel> Statistics;
        /// <summary>
        /// List of player's tags for segmentation
        /// </summary>
        public List<TagModel> Tags;
        /// <summary>
        /// Title ID this player profile applies to
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Sum of the player's purchases made with real-money currencies, converted to US dollars equivalent and represented as a
        /// whole number of cents (1/100 USD). For example, 999 indicates nine dollars and ninety-nine cents.
        /// </summary>
        public uint? TotalValueToDateInUSD;
        /// <summary>
        /// List of the player's lifetime purchase totals, summed by real-money currency
        /// </summary>
        public List<ValueToDateModel> ValuesToDate;
    }

    [Serializable]
    public class PlayerProfileViewConstraints : PlayFabBaseModel
    {
        /// <summary>
        /// Whether to show player's avatar URL. Defaults to false
        /// </summary>
        public bool ShowAvatarUrl;
        /// <summary>
        /// Whether to show the banned until time. Defaults to false
        /// </summary>
        public bool ShowBannedUntil;
        /// <summary>
        /// Whether to show campaign attributions. Defaults to false
        /// </summary>
        public bool ShowCampaignAttributions;
        /// <summary>
        /// Whether to show contact email addresses. Defaults to false
        /// </summary>
        public bool ShowContactEmailAddresses;
        /// <summary>
        /// Whether to show the created date. Defaults to false
        /// </summary>
        public bool ShowCreated;
        /// <summary>
        /// Whether to show the display name. Defaults to false
        /// </summary>
        public bool ShowDisplayName;
        /// <summary>
        /// Whether to show player's experiment variants. Defaults to false
        /// </summary>
        public bool ShowExperimentVariants;
        /// <summary>
        /// Whether to show the last login time. Defaults to false
        /// </summary>
        public bool ShowLastLogin;
        /// <summary>
        /// Whether to show the linked accounts. Defaults to false
        /// </summary>
        public bool ShowLinkedAccounts;
        /// <summary>
        /// Whether to show player's locations. Defaults to false
        /// </summary>
        public bool ShowLocations;
        /// <summary>
        /// Whether to show player's membership information. Defaults to false
        /// </summary>
        public bool ShowMemberships;
        /// <summary>
        /// Whether to show origination. Defaults to false
        /// </summary>
        public bool ShowOrigination;
        /// <summary>
        /// Whether to show push notification registrations. Defaults to false
        /// </summary>
        public bool ShowPushNotificationRegistrations;
        /// <summary>
        /// Reserved for future development
        /// </summary>
        public bool ShowStatistics;
        /// <summary>
        /// Whether to show tags. Defaults to false
        /// </summary>
        public bool ShowTags;
        /// <summary>
        /// Whether to show the total value to date in usd. Defaults to false
        /// </summary>
        public bool ShowTotalValueToDateInUsd;
        /// <summary>
        /// Whether to show the values to date. Defaults to false
        /// </summary>
        public bool ShowValuesToDate;
    }

    [Serializable]
    public class PlayerStatisticVersion : PlayFabBaseModel
    {
        /// <summary>
        /// time when the statistic version became active
        /// </summary>
        public DateTime ActivationTime;
        /// <summary>
        /// time when the statistic version became inactive due to statistic version incrementing
        /// </summary>
        public DateTime? DeactivationTime;
        /// <summary>
        /// time at which the statistic version was scheduled to become active, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledActivationTime;
        /// <summary>
        /// time at which the statistic version was scheduled to become inactive, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledDeactivationTime;
        /// <summary>
        /// name of the statistic when the version became active
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// version of the statistic
        /// </summary>
        public uint Version;
    }

    [Serializable]
    public class PlayStation5Payload : PlayFabBaseModel
    {
        /// <summary>
        /// An optional list of entitlement ids to query against PSN
        /// </summary>
        public List<string> Ids;
        /// <summary>
        /// Id of the PSN service label to consume entitlements from
        /// </summary>
        public string ServiceLabel;
    }

    [Serializable]
    public class PSNAccountPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the PlayStation Network identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayStation Network identifier for a user.
        /// </summary>
        public string PSNAccountId;
    }

    /// <summary>
    /// Please note that the processing time for inventory grants and purchases increases fractionally the more items are in the
    /// inventory, and the more items are in the grant/purchase operation (with each item in a bundle being a distinct add).
    /// </summary>
    [Serializable]
    public class PurchaseItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version for the items to be purchased (defaults to most recent version.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique identifier of the item to purchase.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Price the client expects to pay for the item (in case a new catalog or store was uploaded, with new prices).
        /// </summary>
        public int Price;
        /// <summary>
        /// Store to buy this item through. If not set, prices default to those in the catalog.
        /// </summary>
        public string StoreId;
        /// <summary>
        /// Virtual currency to use to purchase the item.
        /// </summary>
        public string VirtualCurrency;
    }

    [Serializable]
    public class PurchaseItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Details for the items purchased.
        /// </summary>
        public List<ItemInstance> Items;
    }

    [Serializable]
    public class PurchaseReceiptFulfillment : PlayFabBaseModel
    {
        /// <summary>
        /// Items granted to the player in fulfillment of the validated receipt.
        /// </summary>
        public List<ItemInstance> FulfilledItems;
        /// <summary>
        /// Source of the payment price information for the recorded purchase transaction. A value of 'Request' indicates that the
        /// price specified in the request was used, whereas a value of 'Catalog' indicates that the real-money price of the catalog
        /// item matching the product ID in the validated receipt transaction and the currency specified in the request (defaulting
        /// to USD) was used.
        /// </summary>
        public string RecordedPriceSource;
        /// <summary>
        /// Currency used to purchase the items (ISO 4217 currency code).
        /// </summary>
        public string RecordedTransactionCurrency;
        /// <summary>
        /// Amount of the stated currency paid for the items, in centesimal units
        /// </summary>
        public uint? RecordedTransactionTotal;
    }

    public enum PushNotificationPlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    [Serializable]
    public class PushNotificationRegistrationModel : PlayFabBaseModel
    {
        /// <summary>
        /// Notification configured endpoint
        /// </summary>
        public string NotificationEndpointARN;
        /// <summary>
        /// Push notification platform
        /// </summary>
        public PushNotificationPlatform? Platform;
    }

    /// <summary>
    /// Coupon codes can be created for any item, or set of items, in the catalog for the title. This operation causes the
    /// coupon to be consumed, and the specific items to be awarded to the user. Attempting to re-use an already consumed code,
    /// or a code which has not yet been created in the service, will result in an error.
    /// </summary>
    [Serializable]
    public class RedeemCouponRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the coupon. If null, uses the default catalog
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Optional identifier for the Character that should receive the item. If null, item is added to the player
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Generated coupon code to redeem.
        /// </summary>
        public string CouponCode;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class RedeemCouponResult : PlayFabResultCommon
    {
        /// <summary>
        /// Items granted to the player as a result of redeeming the coupon.
        /// </summary>
        public List<ItemInstance> GrantedItems;
    }

    [Serializable]
    public class RefreshPSNAuthTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Auth code returned by PSN OAuth system.
        /// </summary>
        public string AuthCode;
        /// <summary>
        /// Id of the PSN issuer environment. If null, defaults to production environment.
        /// </summary>
        public int? IssuerId;
        /// <summary>
        /// Redirect URI supplied to PSN when requesting an auth code
        /// </summary>
        public string RedirectUri;
    }

    public enum Region
    {
        USCentral,
        USEast,
        EUWest,
        Singapore,
        Japan,
        Brazil,
        Australia
    }

    [Serializable]
    public class RegionInfo : PlayFabBaseModel
    {
        /// <summary>
        /// indicates whether the server specified is available in this region
        /// </summary>
        public bool Available;
        /// <summary>
        /// name of the region
        /// </summary>
        public string Name;
        /// <summary>
        /// url to ping to get roundtrip time
        /// </summary>
        public string PingUrl;
        /// <summary>
        /// unique identifier for the region
        /// </summary>
        public Region? Region;
    }

    /// <summary>
    /// The steps to configure and send Push Notifications is described in the PlayFab tutorials, here:
    /// https://docs.microsoft.com/gaming/playfab/features/engagement/push-notifications/quickstart
    /// </summary>
    [Serializable]
    public class RegisterForIOSPushNotificationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Message to display when confirming push notification.
        /// </summary>
        public string ConfirmationMessage;
        /// <summary>
        /// Unique token generated by the Apple Push Notification service when the title registered to receive push notifications.
        /// </summary>
        public string DeviceToken;
        /// <summary>
        /// If true, send a test push message immediately after sucessful registration. Defaults to false.
        /// </summary>
        public bool? SendPushNotificationConfirmation;
    }

    [Serializable]
    public class RegisterForIOSPushNotificationResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class RegisterPlayFabUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// An optional parameter for setting the display name for this title (3-25 characters).
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// An optional parameter that specifies whether both the username and email parameters are required. If true, both
        /// parameters are required; if false, the user must supply either the username or email parameter. The default value is
        /// true.
        /// </summary>
        public bool? RequireBothUsernameAndEmail;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// Each account must have a unique email address in the PlayFab service. Once created, the account may be associated with
    /// additional accounts (Steam, Facebook, Game Center, etc.), allowing for added social network lists and achievements
    /// systems.
    /// </summary>
    [Serializable]
    public class RegisterPlayFabUserResult : PlayFabLoginResultCommon
    {
        /// <summary>
        /// If LoginTitlePlayerAccountEntity flag is set on the login request the title_player_account will also be logged in and
        /// returned.
        /// </summary>
        public EntityTokenResponse EntityToken;
        /// <summary>
        /// PlayFab unique identifier for this newly created account.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique token identifying the user and game at the server level, for the current session.
        /// </summary>
        public string SessionTicket;
        /// <summary>
        /// Settings specific to this user.
        /// </summary>
        public UserSettings SettingsForUser;
        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username;
    }

    /// <summary>
    /// This API removes an existing contact email from the player's profile.
    /// </summary>
    [Serializable]
    public class RemoveContactEmailRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class RemoveContactEmailResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class RemoveFriendRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab identifier of the friend account which is to be removed.
        /// </summary>
        public string FriendPlayFabId;
    }

    [Serializable]
    public class RemoveFriendResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class RemoveGenericIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Generic service identifier to be removed from the player.
        /// </summary>
        public GenericServiceId GenericId;
    }

    [Serializable]
    public class RemoveGenericIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class RemoveSharedGroupMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
    }

    [Serializable]
    public class RemoveSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Report ad activity
    /// </summary>
    [Serializable]
    public class ReportAdActivityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Type of activity, may be Opened, Closed, Start or End
        /// </summary>
        public AdActivity Activity;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique ID of the placement to report for
        /// </summary>
        public string PlacementId;
        /// <summary>
        /// Unique ID of the reward the player was offered
        /// </summary>
        public string RewardId;
    }

    /// <summary>
    /// Report ad activity response has no body
    /// </summary>
    [Serializable]
    public class ReportAdActivityResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ReportPlayerClientRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional additional comment by reporting player.
        /// </summary>
        public string Comment;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab identifier of the reported player.
        /// </summary>
        public string ReporteeId;
    }

    /// <summary>
    /// Players are currently limited to five reports per day. Attempts by a single user account to submit reports beyond five
    /// will result in Updated being returned as false.
    /// </summary>
    [Serializable]
    public class ReportPlayerClientResult : PlayFabResultCommon
    {
        /// <summary>
        /// The number of remaining reports which may be filed today.
        /// </summary>
        public int SubmissionsRemaining;
    }

    /// <summary>
    /// The title should obtain a refresh receipt via restoreCompletedTransactions in the SKPaymentQueue of the Apple StoreKit
    /// and pass that in to this call. The resultant receipt contains new receipt instances for all non-consumable goods
    /// previously purchased by the user. This API call iterates through every purchase in the receipt and restores the items if
    /// they still exist in the catalog and can be validated.
    /// </summary>
    [Serializable]
    public class RestoreIOSPurchasesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the restored items. If null, defaults to primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Base64 encoded receipt data, passed back by the App Store as a result of a successful purchase.
        /// </summary>
        public string ReceiptData;
    }

    /// <summary>
    /// Once verified, the valid items will be restored into the user's inventory. This result should be used for immediate
    /// updates to the local client game state as opposed to the GetUserInventory API which can have an up to half second delay.
    /// </summary>
    [Serializable]
    public class RestoreIOSPurchasesResult : PlayFabResultCommon
    {
        /// <summary>
        /// Fulfilled inventory items and recorded purchases in fulfillment of the validated receipt transactions.
        /// </summary>
        public List<PurchaseReceiptFulfillment> Fulfillments;
    }

    /// <summary>
    /// Details on which placement and reward to perform a grant on
    /// </summary>
    [Serializable]
    public class RewardAdActivityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Placement unique ID
        /// </summary>
        public string PlacementId;
        /// <summary>
        /// Reward unique ID
        /// </summary>
        public string RewardId;
    }

    /// <summary>
    /// Result for rewarding an ad activity
    /// </summary>
    [Serializable]
    public class RewardAdActivityResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayStream Event ID that was generated by this reward (all subsequent events are associated with this event identifier)
        /// </summary>
        public string AdActivityEventId;
        /// <summary>
        /// Debug results from the grants
        /// </summary>
        public List<string> DebugResults;
        /// <summary>
        /// Id of the placement the reward was for
        /// </summary>
        public string PlacementId;
        /// <summary>
        /// Name of the placement the reward was for
        /// </summary>
        public string PlacementName;
        /// <summary>
        /// If placement has viewing limits indicates how many views are left
        /// </summary>
        public int? PlacementViewsRemaining;
        /// <summary>
        /// If placement has viewing limits indicates when they will next reset
        /// </summary>
        public double? PlacementViewsResetMinutes;
        /// <summary>
        /// Reward results
        /// </summary>
        public AdRewardResults RewardResults;
    }

    [Serializable]
    public class ScriptExecutionError : PlayFabBaseModel
    {
        /// <summary>
        /// Error code, such as CloudScriptNotFound, JavascriptException, CloudScriptFunctionArgumentSizeExceeded,
        /// CloudScriptAPIRequestCountExceeded, CloudScriptAPIRequestError, or CloudScriptHTTPRequestError
        /// </summary>
        public string Error;
        /// <summary>
        /// Details about the error
        /// </summary>
        public string Message;
        /// <summary>
        /// Point during the execution of the script at which the error occurred, if any
        /// </summary>
        public string StackTrace;
    }

    /// <summary>
    /// If the account in question is a "temporary" account (for example, one that was created via a call to
    /// LoginFromIOSDeviceID), thisfunction will have no effect. Only PlayFab accounts which have valid email addresses will be
    /// able to receive a password reset email using this API.
    /// </summary>
    [Serializable]
    public class SendAccountRecoveryEmailRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// The email template id of the account recovery email template to send.
        /// </summary>
        public string EmailTemplateId;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a
        /// title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class SendAccountRecoveryEmailResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// This operation is not additive. It will completely replace the tag list for the specified user. Please note that only
    /// users in the PlayFab friends list can be assigned tags. Attempting to set a tag on a friend only included in the friends
    /// list from a social site integration (such as Facebook or Steam) will return the AccountNotFound error.
    /// </summary>
    [Serializable]
    public class SetFriendTagsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab identifier of the friend account to which the tag(s) should be applied.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// Array of tags to set on the friend account.
        /// </summary>
        public List<string> Tags;
    }

    [Serializable]
    public class SetFriendTagsResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// APIs that require signatures require that the player have a configured Player Secret Key that is used to sign all
    /// requests. Players that don't have a secret will be blocked from making API calls until it is configured. To create a
    /// signature header add a SHA256 hashed string containing UTF8 encoded JSON body as it will be sent to the server, the
    /// current time in UTC formatted to ISO 8601, and the players secret formatted as 'body.date.secret'. Place the resulting
    /// hash into the header X-PlayFab-Signature, along with a header X-PlayFab-Timestamp of the same UTC timestamp used in the
    /// signature.
    /// </summary>
    [Serializable]
    public class SetPlayerSecretRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
    }

    [Serializable]
    public class SetPlayerSecretResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SharedGroupDataRecord : PlayFabBaseModel
    {
        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated;
        /// <summary>
        /// Unique PlayFab identifier of the user to last update this value.
        /// </summary>
        public string LastUpdatedBy;
        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only members of the group (private).
        /// </summary>
        public UserDataPermission? Permission;
        /// <summary>
        /// Data stored for the specified group data key.
        /// </summary>
        public string Value;
    }

    public enum SourceType
    {
        Admin,
        BackEnd,
        GameClient,
        GameServer,
        Partner,
        Custom,
        API
    }

    /// <summary>
    /// This is the first step in the purchasing process. For security purposes, once the order (or "cart") has been created,
    /// additional inventory objects may no longer be added. In addition, inventory objects will be locked to the current
    /// prices, regardless of any subsequent changes at the catalog level which may occur during the next two steps.
    /// </summary>
    [Serializable]
    public class StartPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version for the items to be purchased. Defaults to most recent catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Array of items to purchase.
        /// </summary>
        public List<ItemPurchaseRequest> Items;
        /// <summary>
        /// Store through which to purchase items. If not set, prices will be pulled from the catalog itself.
        /// </summary>
        public string StoreId;
    }

    [Serializable]
    public class StartPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Cart items to be purchased.
        /// </summary>
        public List<CartItem> Contents;
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Available methods by which the user can pay.
        /// </summary>
        public List<PaymentOption> PaymentOptions;
        /// <summary>
        /// Current virtual currency totals for the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrencyBalances;
    }

    [Serializable]
    public class StatisticModel : PlayFabBaseModel
    {
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name;
        /// <summary>
        /// Statistic value
        /// </summary>
        public int Value;
        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int Version;
    }

    [Serializable]
    public class StatisticNameVersion : PlayFabBaseModel
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// the version of the statistic to be returned
        /// </summary>
        public uint Version;
    }

    [Serializable]
    public class StatisticUpdate : PlayFabBaseModel
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value;
        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded. Null when
        /// setting the statistic value for the first time.
        /// </summary>
        public uint? Version;
    }

    [Serializable]
    public class StatisticValue : PlayFabBaseModel
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value;
        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded
        /// </summary>
        public uint Version;
    }

    [Serializable]
    public class SteamPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamStringId;
    }

    /// <summary>
    /// A store entry that list a catalog item at a particular price
    /// </summary>
    [Serializable]
    public class StoreItem : PlayFabBaseModel
    {
        /// <summary>
        /// Store specific custom data. The data only exists as part of this store; it is not transferred to item instances
        /// </summary>
        public object CustomData;
        /// <summary>
        /// Intended display position for this item. Note that 0 is the first position
        /// </summary>
        public uint? DisplayPosition;
        /// <summary>
        /// Unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the
        /// catalog
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;
        /// <summary>
        /// Override prices for this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;
    }

    /// <summary>
    /// Marketing data about a specific store
    /// </summary>
    [Serializable]
    public class StoreMarketingModel : PlayFabBaseModel
    {
        /// <summary>
        /// Tagline for a store.
        /// </summary>
        public string Description;
        /// <summary>
        /// Display name of a store as it will appear to users.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Custom data about a store.
        /// </summary>
        public object Metadata;
    }

    [Serializable]
    public class SubscriptionModel : PlayFabBaseModel
    {
        /// <summary>
        /// When this subscription expires.
        /// </summary>
        public DateTime Expiration;
        /// <summary>
        /// The time the subscription was orignially purchased
        /// </summary>
        public DateTime InitialSubscriptionTime;
        /// <summary>
        /// Whether this subscription is currently active. That is, if Expiration > now.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// The status of this subscription, according to the subscription provider.
        /// </summary>
        public SubscriptionProviderStatus? Status;
        /// <summary>
        /// The id for this subscription
        /// </summary>
        public string SubscriptionId;
        /// <summary>
        /// The item id for this subscription from the primary catalog
        /// </summary>
        public string SubscriptionItemId;
        /// <summary>
        /// The provider for this subscription. Apple or Google Play are supported today.
        /// </summary>
        public string SubscriptionProvider;
    }

    public enum SubscriptionProviderStatus
    {
        NoError,
        Cancelled,
        UnknownError,
        BillingError,
        ProductUnavailable,
        CustomerDidNotAcceptPriceChange,
        FreeTrial,
        PaymentPending
    }

    /// <summary>
    /// This API must be enabled for use as an option in the game manager website. It is disabled by default.
    /// </summary>
    [Serializable]
    public class SubtractUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency;
    }

    [Serializable]
    public class TagModel : PlayFabBaseModel
    {
        /// <summary>
        /// Full value of the tag, including namespace
        /// </summary>
        public string TagValue;
    }

    public enum TitleActivationStatus
    {
        None,
        ActivatedTitleKey,
        PendingSteam,
        ActivatedSteam,
        RevokedSteam
    }

    [Serializable]
    public class TitleNewsItem : PlayFabBaseModel
    {
        /// <summary>
        /// News item text.
        /// </summary>
        public string Body;
        /// <summary>
        /// Unique identifier of news item.
        /// </summary>
        public string NewsId;
        /// <summary>
        /// Date and time when the news item was posted.
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// Title of the news item.
        /// </summary>
        public string Title;
    }

    [Serializable]
    public class TradeInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Item instances from the accepting player that are used to fulfill the trade. If null, no one has accepted the trade.
        /// </summary>
        public List<string> AcceptedInventoryInstanceIds;
        /// <summary>
        /// The PlayFab ID of the player who accepted the trade. If null, no one has accepted the trade.
        /// </summary>
        public string AcceptedPlayerId;
        /// <summary>
        /// An optional list of players allowed to complete this trade. If null, anybody can complete the trade.
        /// </summary>
        public List<string> AllowedPlayerIds;
        /// <summary>
        /// If set, The UTC time when this trade was canceled.
        /// </summary>
        public DateTime? CancelledAt;
        /// <summary>
        /// If set, The UTC time when this trade was fulfilled.
        /// </summary>
        public DateTime? FilledAt;
        /// <summary>
        /// If set, The UTC time when this trade was made invalid.
        /// </summary>
        public DateTime? InvalidatedAt;
        /// <summary>
        /// The catalogItem Ids of the item instances being offered.
        /// </summary>
        public List<string> OfferedCatalogItemIds;
        /// <summary>
        /// The itemInstance Ids that are being offered.
        /// </summary>
        public List<string> OfferedInventoryInstanceIds;
        /// <summary>
        /// The PlayFabId for the offering player.
        /// </summary>
        public string OfferingPlayerId;
        /// <summary>
        /// The UTC time when this trade was created.
        /// </summary>
        public DateTime? OpenedAt;
        /// <summary>
        /// The catalogItem Ids requested in exchange.
        /// </summary>
        public List<string> RequestedCatalogItemIds;
        /// <summary>
        /// Describes the current state of this trade.
        /// </summary>
        public TradeStatus? Status;
        /// <summary>
        /// The identifier for this trade.
        /// </summary>
        public string TradeId;
    }

    public enum TradeStatus
    {
        Invalid,
        Opening,
        Open,
        Accepting,
        Accepted,
        Filled,
        Cancelled
    }

    public enum TransactionStatus
    {
        CreateCart,
        Init,
        Approved,
        Succeeded,
        FailedByProvider,
        DisputePending,
        RefundPending,
        Refunded,
        RefundFailed,
        ChargedBack,
        FailedByUber,
        FailedByPlayFab,
        Revoked,
        TradePending,
        Traded,
        Upgraded,
        StackPending,
        Stacked,
        Other,
        Failed
    }

    [Serializable]
    public class TreatmentAssignment : PlayFabBaseModel
    {
        /// <summary>
        /// List of the experiment variables.
        /// </summary>
        public List<Variable> Variables;
        /// <summary>
        /// List of the experiment variants.
        /// </summary>
        public List<string> Variants;
    }

    [Serializable]
    public class TwitchPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Twitch identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique Twitch identifier for a user.
        /// </summary>
        public string TwitchId;
    }

    [Serializable]
    public class UnlinkAndroidDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Android device identifier for the user's device. If not specified, the most recently signed in Android Device ID will be
        /// used.
        /// </summary>
        public string AndroidDeviceId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkAndroidDeviceIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkAppleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkCustomIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom unique identifier for the user, generated by the title. If not specified, the most recently signed in Custom ID
        /// will be used.
        /// </summary>
        public string CustomId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkCustomIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkFacebookAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkFacebookAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkFacebookInstantGamesIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Facebook Instant Games identifier for the user. If not specified, the most recently signed in ID will be used.
        /// </summary>
        public string FacebookInstantGamesId;
    }

    [Serializable]
    public class UnlinkFacebookInstantGamesIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkGameCenterAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkGameCenterAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkGoogleAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkGoogleAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkIOSDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Vendor-specific iOS identifier for the user's device. If not specified, the most recently signed in iOS Device ID will
        /// be used.
        /// </summary>
        public string DeviceId;
    }

    [Serializable]
    public class UnlinkIOSDeviceIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkKongregateAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkKongregateAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkNintendoServiceAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkNintendoSwitchDeviceIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Nintendo Switch Device identifier for the user. If not specified, the most recently signed in device ID will be used.
        /// </summary>
        public string NintendoSwitchDeviceId;
    }

    [Serializable]
    public class UnlinkNintendoSwitchDeviceIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkOpenIdConnectRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A name that identifies which configured OpenID Connect provider relationship to use. Maximum 100 characters.
        /// </summary>
        public string ConnectionId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkPSNAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkPSNAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkSteamAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkSteamAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkTwitchAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Valid token issued by Twitch. Used to specify which twitch account to unlink from the profile. By default it uses the
        /// one that is present on the profile.
        /// </summary>
        public string AccessToken;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkTwitchAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkXboxAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UnlinkXboxAccountResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Specify the container and optionally the catalogVersion for the container to open
    /// </summary>
    [Serializable]
    public class UnlockContainerInstanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents. If unspecified, uses catalog
        /// associated with the item instance.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// ItemInstanceId of the container to unlock.
        /// </summary>
        public string ContainerItemInstanceId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// ItemInstanceId of the key that will be consumed by unlocking this container. If the container requires a key, this
        /// parameter is required.
        /// </summary>
        public string KeyItemInstanceId;
    }

    /// <summary>
    /// Specify the type of container to open and optionally the catalogVersion for the container to open
    /// </summary>
    [Serializable]
    public class UnlockContainerItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents. If unspecified, uses default/primary
        /// catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Catalog ItemId of the container type to unlock.
        /// </summary>
        public string ContainerItemId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    /// <summary>
    /// The items and vc found within the container. These will be added and stacked in the appropriate inventory.
    /// </summary>
    [Serializable]
    public class UnlockContainerItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Items granted to the player as a result of unlocking the container.
        /// </summary>
        public List<ItemInstance> GrantedItems;
        /// <summary>
        /// Unique instance identifier of the container unlocked.
        /// </summary>
        public string UnlockedItemInstanceId;
        /// <summary>
        /// Unique instance identifier of the key used to unlock the container, if applicable.
        /// </summary>
        public string UnlockedWithItemInstanceId;
        /// <summary>
        /// Virtual currency granted to the player as a result of unlocking the container.
        /// </summary>
        public Dictionary<string,uint> VirtualCurrency;
    }

    [Serializable]
    public class UpdateAvatarUrlRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// URL of the avatar image. If empty, it removes the existing avatar URL.
        /// </summary>
        public string ImageUrl;
    }

    /// <summary>
    /// This function performs an additive update of the arbitrary strings containing the custom data for the character. In
    /// updating the custom data object, keys which already exist in the object will have their values overwritten, while keys
    /// with null values will be removed. New keys will be added, with the given values. No other key-value pairs will be
    /// changed apart from those specified in the call.
    /// </summary>
    [Serializable]
    public class UpdateCharacterDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may
        /// not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values into Data due to language
        /// constraints. Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        public UserDataPermission? Permission;
    }

    [Serializable]
    public class UpdateCharacterDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of
        /// data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    /// <summary>
    /// Enable this option with the 'Allow Client to Post Player Statistics' option in PlayFab GameManager for your title.
    /// However, this is not best practice, as this data will no longer be safely controlled by the server. This operation is
    /// additive. Character Statistics not currently defined will be added, while those already defined will be updated with the
    /// given values. All other user statistics will remain unchanged. Character statistics are used by the
    /// character-leaderboard apis, and accessible for custom game-logic.
    /// </summary>
    [Serializable]
    public class UpdateCharacterStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Statistics to be updated with the provided values, in the Key(string), Value(int) pattern.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
    }

    [Serializable]
    public class UpdateCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Enable this option with the 'Allow Client to Post Player Statistics' option in PlayFab GameManager for your title.
    /// However, this is not best practice, as this data will no longer be safely controlled by the server. This operation is
    /// additive. Statistics not currently defined will be added, while those already defined will be updated with the given
    /// values. All other user statistics will remain unchanged. Note that if the statistic is intended to have a reset period,
    /// the UpdatePlayerStatisticDefinition API call can be used to define that reset period. Once a statistic has been
    /// versioned (reset), the now-previous version can still be written to for up a short, pre-defined period (currently 10
    /// seconds), using the Version parameter in this call.
    /// </summary>
    [Serializable]
    public class UpdatePlayerStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Statistics to be updated with the provided values
        /// </summary>
        public List<StatisticUpdate> Statistics;
    }

    [Serializable]
    public class UpdatePlayerStatisticsResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Note that in the case of multiple calls to write to the same shared group data keys, the last write received by the
    /// PlayFab service will determine the value available to subsequent read operations. For scenarios requiring coordination
    /// of data updates, it is recommended that titles make use of user data with read permission set to public, or a
    /// combination of user data and shared group data.
    /// </summary>
    [Serializable]
    public class UpdateSharedGroupDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may
        /// not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values into Data due to language
        /// constraints. Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
        /// <summary>
        /// Permission to be applied to all user data keys in this request.
        /// </summary>
        public UserDataPermission? Permission;
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
    }

    [Serializable]
    public class UpdateSharedGroupDataResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// This function performs an additive update of the arbitrary strings containing the custom data for the user. In updating
    /// the custom data object, keys which already exist in the object will have their values overwritten, while keys with null
    /// values will be removed. New keys will be added, with the given values. No other key-value pairs will be changed apart
    /// from those specified in the call.
    /// </summary>
    [Serializable]
    public class UpdateUserDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may
        /// not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values into Data due to language
        /// constraints. Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set. This is used
        /// for requests by one player for information about another player; those requests will only return Public keys.
        /// </summary>
        public UserDataPermission? Permission;
    }

    [Serializable]
    public class UpdateUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of
        /// data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    /// <summary>
    /// In addition to the PlayFab username, titles can make use of a DisplayName which is also a unique identifier, but
    /// specific to the title. This allows for unique names which more closely match the theme or genre of a title, for example.
    /// </summary>
    [Serializable]
    public class UpdateUserTitleDisplayNameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// New title display name for the user - must be between 3 and 25 characters.
        /// </summary>
        public string DisplayName;
    }

    [Serializable]
    public class UpdateUserTitleDisplayNameResult : PlayFabResultCommon
    {
        /// <summary>
        /// Current title display name for the user (this will be the original display name if the rename attempt failed).
        /// </summary>
        public string DisplayName;
    }

    [Serializable]
    public class UserAccountInfo : PlayFabBaseModel
    {
        /// <summary>
        /// User Android device information, if an Android device has been linked
        /// </summary>
        public UserAndroidDeviceInfo AndroidDeviceInfo;
        /// <summary>
        /// Sign in with Apple account information, if an Apple account has been linked
        /// </summary>
        public UserAppleIdInfo AppleAccountInfo;
        /// <summary>
        /// Timestamp indicating when the user account was created
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// Custom ID information, if a custom ID has been assigned
        /// </summary>
        public UserCustomIdInfo CustomIdInfo;
        /// <summary>
        /// User Facebook information, if a Facebook account has been linked
        /// </summary>
        public UserFacebookInfo FacebookInfo;
        /// <summary>
        /// Facebook Instant Games account information, if a Facebook Instant Games account has been linked
        /// </summary>
        public UserFacebookInstantGamesIdInfo FacebookInstantGamesIdInfo;
        /// <summary>
        /// User Gamecenter information, if a Gamecenter account has been linked
        /// </summary>
        public UserGameCenterInfo GameCenterInfo;
        /// <summary>
        /// User Google account information, if a Google account has been linked
        /// </summary>
        public UserGoogleInfo GoogleInfo;
        /// <summary>
        /// User iOS device information, if an iOS device has been linked
        /// </summary>
        public UserIosDeviceInfo IosDeviceInfo;
        /// <summary>
        /// User Kongregate account information, if a Kongregate account has been linked
        /// </summary>
        public UserKongregateInfo KongregateInfo;
        /// <summary>
        /// Nintendo Switch account information, if a Nintendo Switch account has been linked
        /// </summary>
        public UserNintendoSwitchAccountIdInfo NintendoSwitchAccountInfo;
        /// <summary>
        /// Nintendo Switch device information, if a Nintendo Switch device has been linked
        /// </summary>
        public UserNintendoSwitchDeviceIdInfo NintendoSwitchDeviceIdInfo;
        /// <summary>
        /// OpenID Connect information, if any OpenID Connect accounts have been linked
        /// </summary>
        public List<UserOpenIdInfo> OpenIdInfo;
        /// <summary>
        /// Unique identifier for the user account
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Personal information for the user which is considered more sensitive
        /// </summary>
        public UserPrivateAccountInfo PrivateInfo;
        /// <summary>
        /// User PSN account information, if a PSN account has been linked
        /// </summary>
        public UserPsnInfo PsnInfo;
        /// <summary>
        /// User Steam information, if a Steam account has been linked
        /// </summary>
        public UserSteamInfo SteamInfo;
        /// <summary>
        /// Title-specific information for the user account
        /// </summary>
        public UserTitleInfo TitleInfo;
        /// <summary>
        /// User Twitch account information, if a Twitch account has been linked
        /// </summary>
        public UserTwitchInfo TwitchInfo;
        /// <summary>
        /// User account name in the PlayFab service
        /// </summary>
        public string Username;
        /// <summary>
        /// User XBox account information, if a XBox account has been linked
        /// </summary>
        public UserXboxInfo XboxInfo;
    }

    [Serializable]
    public class UserAndroidDeviceInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Android device ID
        /// </summary>
        public string AndroidDeviceId;
    }

    [Serializable]
    public class UserAppleIdInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Apple subject ID
        /// </summary>
        public string AppleSubjectId;
    }

    [Serializable]
    public class UserCustomIdInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Custom ID
        /// </summary>
        public string CustomId;
    }

    /// <summary>
    /// Indicates whether a given data key is private (readable only by the player) or public (readable by all players). When a
    /// player makes a GetUserData request about another player, only keys marked Public will be returned.
    /// </summary>
    public enum UserDataPermission
    {
        Private,
        Public
    }

    [Serializable]
    public class UserDataRecord : PlayFabBaseModel
    {
        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated;
        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only the user (private). This is used for GetUserData
        /// requests being made by one player about another player.
        /// </summary>
        public UserDataPermission? Permission;
        /// <summary>
        /// Data stored for the specified user data key.
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class UserFacebookInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Facebook identifier
        /// </summary>
        public string FacebookId;
        /// <summary>
        /// Facebook full name
        /// </summary>
        public string FullName;
    }

    [Serializable]
    public class UserFacebookInstantGamesIdInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Facebook Instant Games ID
        /// </summary>
        public string FacebookInstantGamesId;
    }

    [Serializable]
    public class UserGameCenterInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Gamecenter identifier
        /// </summary>
        public string GameCenterId;
    }

    [Serializable]
    public class UserGoogleInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Email address of the Google account
        /// </summary>
        public string GoogleEmail;
        /// <summary>
        /// Gender information of the Google account
        /// </summary>
        public string GoogleGender;
        /// <summary>
        /// Google ID
        /// </summary>
        public string GoogleId;
        /// <summary>
        /// Locale of the Google account
        /// </summary>
        public string GoogleLocale;
        /// <summary>
        /// Name of the Google account user
        /// </summary>
        public string GoogleName;
    }

    [Serializable]
    public class UserIosDeviceInfo : PlayFabBaseModel
    {
        /// <summary>
        /// iOS device ID
        /// </summary>
        public string IosDeviceId;
    }

    [Serializable]
    public class UserKongregateInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Kongregate ID
        /// </summary>
        public string KongregateId;
        /// <summary>
        /// Kongregate Username
        /// </summary>
        public string KongregateName;
    }

    [Serializable]
    public class UserNintendoSwitchAccountIdInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Nintendo Switch account subject ID
        /// </summary>
        public string NintendoSwitchAccountSubjectId;
    }

    [Serializable]
    public class UserNintendoSwitchDeviceIdInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Nintendo Switch Device ID
        /// </summary>
        public string NintendoSwitchDeviceId;
    }

    [Serializable]
    public class UserOpenIdInfo : PlayFabBaseModel
    {
        /// <summary>
        /// OpenID Connection ID
        /// </summary>
        public string ConnectionId;
        /// <summary>
        /// OpenID Issuer
        /// </summary>
        public string Issuer;
        /// <summary>
        /// OpenID Subject
        /// </summary>
        public string Subject;
    }

    public enum UserOrigination
    {
        Organic,
        Steam,
        Google,
        Amazon,
        Facebook,
        Kongregate,
        GamersFirst,
        Unknown,
        IOS,
        LoadTest,
        Android,
        PSN,
        GameCenter,
        CustomId,
        XboxLive,
        Parse,
        Twitch,
        ServerCustomId,
        NintendoSwitchDeviceId,
        FacebookInstantGamesId,
        OpenIdConnect,
        Apple,
        NintendoSwitchAccount
    }

    [Serializable]
    public class UserPrivateAccountInfo : PlayFabBaseModel
    {
        /// <summary>
        /// user email address
        /// </summary>
        public string Email;
    }

    [Serializable]
    public class UserPsnInfo : PlayFabBaseModel
    {
        /// <summary>
        /// PSN account ID
        /// </summary>
        public string PsnAccountId;
        /// <summary>
        /// PSN online ID
        /// </summary>
        public string PsnOnlineId;
    }

    [Serializable]
    public class UserSettings : PlayFabBaseModel
    {
        /// <summary>
        /// Boolean for whether this player is eligible for gathering device info.
        /// </summary>
        public bool GatherDeviceInfo;
        /// <summary>
        /// Boolean for whether this player should report OnFocus play-time tracking.
        /// </summary>
        public bool GatherFocusInfo;
        /// <summary>
        /// Boolean for whether this player is eligible for ad tracking.
        /// </summary>
        public bool NeedsAttribution;
    }

    [Serializable]
    public class UserSteamInfo : PlayFabBaseModel
    {
        /// <summary>
        /// what stage of game ownership the user is listed as being in, from Steam
        /// </summary>
        public TitleActivationStatus? SteamActivationStatus;
        /// <summary>
        /// the country in which the player resides, from Steam data
        /// </summary>
        public string SteamCountry;
        /// <summary>
        /// currency type set in the user Steam account
        /// </summary>
        public Currency? SteamCurrency;
        /// <summary>
        /// Steam identifier
        /// </summary>
        public string SteamId;
        /// <summary>
        /// Steam display name
        /// </summary>
        public string SteamName;
    }

    [Serializable]
    public class UserTitleInfo : PlayFabBaseModel
    {
        /// <summary>
        /// URL to the player's avatar.
        /// </summary>
        public string AvatarUrl;
        /// <summary>
        /// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user
        /// first registered with PlayFab)
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// name of the user, as it is displayed in-game
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other
        /// events, such as issuing a beta key to the user, can associate the title to the user)
        /// </summary>
        public DateTime? FirstLogin;
        /// <summary>
        /// boolean indicating whether or not the user is currently banned for a title
        /// </summary>
        public bool? isBanned;
        /// <summary>
        /// timestamp for the last user login for this title
        /// </summary>
        public DateTime? LastLogin;
        /// <summary>
        /// source by which the user first joined the game, if known
        /// </summary>
        public UserOrigination? Origination;
        /// <summary>
        /// Title player account entity for this user
        /// </summary>
        public EntityKey TitlePlayerAccount;
    }

    [Serializable]
    public class UserTwitchInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Twitch ID
        /// </summary>
        public string TwitchId;
        /// <summary>
        /// Twitch Username
        /// </summary>
        public string TwitchUserName;
    }

    [Serializable]
    public class UserXboxInfo : PlayFabBaseModel
    {
        /// <summary>
        /// XBox user ID
        /// </summary>
        public string XboxUserId;
    }

    [Serializable]
    public class ValidateAmazonReceiptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the fulfilled items. If null, defaults to the primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Currency used to pay for the purchase (ISO 4217 currency code).
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Amount of the stated currency paid, in centesimal units.
        /// </summary>
        public int PurchasePrice;
        /// <summary>
        /// ReceiptId returned by the Amazon App Store in-app purchase API
        /// </summary>
        public string ReceiptId;
        /// <summary>
        /// AmazonId of the user making the purchase as returned by the Amazon App Store in-app purchase API
        /// </summary>
        public string UserId;
    }

    /// <summary>
    /// Once verified, the catalog item matching the Amazon item name will be added to the user's inventory. This result should
    /// be used for immediate updates to the local client game state as opposed to the GetUserInventory API which can have an up
    /// to half second delay.
    /// </summary>
    [Serializable]
    public class ValidateAmazonReceiptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Fulfilled inventory items and recorded purchases in fulfillment of the validated receipt transactions.
        /// </summary>
        public List<PurchaseReceiptFulfillment> Fulfillments;
    }

    /// <summary>
    /// The packageName and productId are defined in the GooglePlay store. The productId must match the ItemId of the inventory
    /// item in the PlayFab catalog for the title. This enables the PlayFab service to securely validate that the purchase is
    /// for the correct item, in order to prevent uses from passing valid receipts as being for more expensive items (passing a
    /// receipt for a 99-cent purchase as being for a $19.99 purchase, for example). Each receipt may be validated only once to
    /// avoid granting the same item over and over from a single purchase.
    /// </summary>
    [Serializable]
    public class ValidateGooglePlayPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the fulfilled items. If null, defaults to the primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Currency used to pay for the purchase (ISO 4217 currency code).
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Amount of the stated currency paid, in centesimal units.
        /// </summary>
        public uint? PurchasePrice;
        /// <summary>
        /// Original JSON string returned by the Google Play IAB API.
        /// </summary>
        public string ReceiptJson;
        /// <summary>
        /// Signature returned by the Google Play IAB API.
        /// </summary>
        public string Signature;
    }

    /// <summary>
    /// Once verified, the catalog item (ItemId) matching the GooglePlay store item (productId) will be added to the user's
    /// inventory. This result should be used for immediate updates to the local client game state as opposed to the
    /// GetUserInventory API which can have an up to half second delay.
    /// </summary>
    [Serializable]
    public class ValidateGooglePlayPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Fulfilled inventory items and recorded purchases in fulfillment of the validated receipt transactions.
        /// </summary>
        public List<PurchaseReceiptFulfillment> Fulfillments;
    }

    /// <summary>
    /// The CurrencyCode and PurchasePrice must match the price which was set up for the item in the Apple store. In addition,
    /// The ItemId of the inventory in the PlayFab Catalog must match the Product ID as it was set up in the Apple store. This
    /// enables the PlayFab service to securely validate that the purchase is for the correct item, in order to prevent uses
    /// from passing valid receipts as being for more expensive items (passing a receipt for a 99-cent purchase as being for a
    /// $19.99 purchase, for example).
    /// </summary>
    [Serializable]
    public class ValidateIOSReceiptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the fulfilled items. If null, defaults to the primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Currency used to pay for the purchase (ISO 4217 currency code).
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Amount of the stated currency paid, in centesimal units.
        /// </summary>
        public int PurchasePrice;
        /// <summary>
        /// Base64 encoded receipt data, passed back by the App Store as a result of a successful purchase.
        /// </summary>
        public string ReceiptData;
    }

    /// <summary>
    /// Once verified, the catalog item matching the iTunes item name will be added to the user's inventory. This result should
    /// be used for immediate updates to the local client game state as opposed to the GetUserInventory API which can have an up
    /// to half second delay.
    /// </summary>
    [Serializable]
    public class ValidateIOSReceiptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Fulfilled inventory items and recorded purchases in fulfillment of the validated receipt transactions.
        /// </summary>
        public List<PurchaseReceiptFulfillment> Fulfillments;
    }

    [Serializable]
    public class ValidateWindowsReceiptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the fulfilled items. If null, defaults to the primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Currency used to pay for the purchase (ISO 4217 currency code).
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Amount of the stated currency paid, in centesimal units.
        /// </summary>
        public uint PurchasePrice;
        /// <summary>
        /// XML Receipt returned by the Windows App Store in-app purchase API
        /// </summary>
        public string Receipt;
    }

    /// <summary>
    /// Once verified, the catalog item matching the Product name will be added to the user's inventory. This result should be
    /// used for immediate updates to the local client game state as opposed to the GetUserInventory API which can have an up to
    /// half second delay.
    /// </summary>
    [Serializable]
    public class ValidateWindowsReceiptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Fulfilled inventory items and recorded purchases in fulfillment of the validated receipt transactions.
        /// </summary>
        public List<PurchaseReceiptFulfillment> Fulfillments;
    }

    [Serializable]
    public class ValueToDateModel : PlayFabBaseModel
    {
        /// <summary>
        /// ISO 4217 code of the currency used in the purchases
        /// </summary>
        public string Currency;
        /// <summary>
        /// Total value of the purchases in a whole number of 1/100 monetary units. For example, 999 indicates nine dollars and
        /// ninety-nine cents when Currency is 'USD')
        /// </summary>
        public uint TotalValue;
        /// <summary>
        /// Total value of the purchases in a string representation of decimal monetary units. For example, '9.99' indicates nine
        /// dollars and ninety-nine cents when Currency is 'USD'.
        /// </summary>
        public string TotalValueAsDecimal;
    }

    [Serializable]
    public class Variable : PlayFabBaseModel
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        public string Name;
        /// <summary>
        /// Value of the variable.
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class VirtualCurrencyRechargeTime : PlayFabBaseModel
    {
        /// <summary>
        /// Maximum value to which the regenerating currency will automatically increment. Note that it can exceed this value
        /// through use of the AddUserVirtualCurrency API call. However, it will not regenerate automatically until it has fallen
        /// below this value.
        /// </summary>
        public int RechargeMax;
        /// <summary>
        /// Server timestamp in UTC indicating the next time the virtual currency will be incremented.
        /// </summary>
        public DateTime RechargeTime;
        /// <summary>
        /// Time remaining (in seconds) before the next recharge increment of the virtual currency.
        /// </summary>
        public int SecondsToRecharge;
    }

    /// <summary>
    /// This API is designed to write a multitude of different client-defined events into PlayStream. It supports a flexible
    /// JSON schema, which allowsfor arbitrary key-value pairs to describe any character-based event. The created event will be
    /// locked to the authenticated title and player.
    /// </summary>
    [Serializable]
    public class WriteClientCharacterEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom event properties. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it
        /// commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;
        /// <summary>
        /// The time (in UTC) associated with this event. The value defaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
    }

    /// <summary>
    /// This API is designed to write a multitude of different event types into PlayStream. It supports a flexible JSON schema,
    /// which allowsfor arbitrary key-value pairs to describe any player-based event. The created event will be locked to the
    /// authenticated title and player.
    /// </summary>
    [Serializable]
    public class WriteClientPlayerEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom data properties associated with the event. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it
        /// commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;
        /// <summary>
        /// The time (in UTC) associated with this event. The value defaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
    }

    [Serializable]
    public class WriteEventResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The unique identifier of the event. The values of this identifier consist of ASCII characters and are not constrained to
        /// any particular format.
        /// </summary>
        public string EventId;
    }

    /// <summary>
    /// This API is designed to write a multitude of different client-defined events into PlayStream. It supports a flexible
    /// JSON schema, which allowsfor arbitrary key-value pairs to describe any title-based event. The created event will be
    /// locked to the authenticated title.
    /// </summary>
    [Serializable]
    public class WriteTitleEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom event properties. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it
        /// commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;
        /// <summary>
        /// The time (in UTC) associated with this event. The value defaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
    }

    [Serializable]
    public class XboxLiveAccountPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Xbox Live identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique Xbox Live identifier for a user.
        /// </summary>
        public string XboxLiveAccountId;
    }
}
#endif
