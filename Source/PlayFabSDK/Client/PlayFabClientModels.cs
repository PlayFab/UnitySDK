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
        /// Player who opened the trade.
        /// </summary>
        public string OfferingPlayerId;
        /// <summary>
        /// Trade identifier.
        /// </summary>
        public string TradeId;
        /// <summary>
        /// Items from the accepting player's or guild's inventory in exchange for the offered items in the trade. In the case of a gift, this will be null.
        /// </summary>
        public List<string> AcceptedInventoryInstanceIds;
    }

    [Serializable]
    public class AcceptTradeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Details about trade which was just accepted.
        /// </summary>
        public TradeInfo Trade;
    }

    [Serializable]
    public class AdCampaignAttributionModel
    {
        /// <summary>
        /// Attribution network name
        /// </summary>
        public string Platform;
        /// <summary>
        /// Attribution campaign identifier
        /// </summary>
        public string CampaignId;
        /// <summary>
        /// UTC time stamp of attribution
        /// </summary>
        public DateTime AttributedAt;
    }

    [Serializable]
    public class AddFriendRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab identifier of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// PlayFab username of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendUsername;
        /// <summary>
        /// Email address of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendEmail;
        /// <summary>
        /// Title-specific display name of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendTitleDisplayName;
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

    [Serializable]
    public class AddSharedGroupMembersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;
    }

    [Serializable]
    public class AddSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class AddUsernamePasswordRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username;
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
    }

    [Serializable]
    public class AddUsernamePasswordResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username;
    }

    [Serializable]
    public class AddUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;
        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency.
        /// </summary>
        public int Amount;
    }

    [Serializable]
    public class AndroidDevicePushNotificationRegistrationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Registration ID provided by the Google Cloud Messaging service when the title registered to receive push notifications (see the GCM documentation, here: http://developer.android.com/google/gcm/client.html).
        /// </summary>
        public string DeviceToken;
        /// <summary>
        /// If true, send a test push message immediately after sucessful registration. Defaults to false.
        /// </summary>
        public bool? SendPushNotificationConfirmation;
        /// <summary>
        /// Message to display when confirming push notification.
        /// </summary>
        public string ConfirmationMessage;
    }

    [Serializable]
    public class AndroidDevicePushNotificationRegistrationResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class AttributeInstallRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The IdentifierForAdvertisers for iOS Devices.
        /// </summary>
        public string Idfa;
        /// <summary>
        /// The adid for this device.
        /// </summary>
        public string Adid;
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
    public class CartItem
    {
        /// <summary>
        /// Unique identifier for the catalog item.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Class name to which catalog item belongs.
        /// </summary>
        public string ItemClass;
        /// <summary>
        /// Unique instance identifier for this catalog item.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Display name for the catalog item.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Description of the catalog item.
        /// </summary>
        public string Description;
        /// <summary>
        /// Cost of the catalog item for each applicable virtual currency.
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;
        /// <summary>
        /// Cost of the catalog item for each applicable real world currency.
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;
        /// <summary>
        /// Amount of each applicable virtual currency which will be received as a result of purchasing this catalog item.
        /// </summary>
        public Dictionary<string,uint> VCAmount;
    }

    /// <summary>
    /// A purchasable item from the item catalog
    /// </summary>
    [Serializable]
    public class CatalogItem
    {
        /// <summary>
        /// unique identifier for this item
        /// </summary>
        public string ItemId;
        /// <summary>
        /// class to which the item belongs
        /// </summary>
        public string ItemClass;
        /// <summary>
        /// catalog version for this item
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// text name for the item, to show in-game
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// text description of item, to show in-game
        /// </summary>
        public string Description;
        /// <summary>
        /// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;
        /// <summary>
        /// override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;
        /// <summary>
        /// list of item tags
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// game specific custom data
        /// </summary>
        public string CustomData;
        /// <summary>
        /// defines the consumable properties (number of uses, timeout) for the item
        /// </summary>
        public CatalogItemConsumableInfo Consumable;
        /// <summary>
        /// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
        /// </summary>
        public CatalogItemContainerInfo Container;
        /// <summary>
        /// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
        /// </summary>
        public CatalogItemBundleInfo Bundle;
        /// <summary>
        /// if true, then an item instance of this type can be used to grant a character to a user.
        /// </summary>
        public bool CanBecomeCharacter;
        /// <summary>
        /// if true, then only one item instance of this type will exist and its remaininguses will be incremented instead. RemainingUses will cap out at Int32.Max (2,147,483,647). All subsequent increases will be discarded
        /// </summary>
        public bool IsStackable;
        /// <summary>
        /// if true, then an item instance of this type can be traded between players using the trading APIs
        /// </summary>
        public bool IsTradable;
        /// <summary>
        /// URL to the item image. For Facebook purchase to display the image on the item purchase page, this must be set to an HTTP URL.
        /// </summary>
        public string ItemImageUrl;
        /// <summary>
        /// BETA: If true, then only a fixed number can ever be granted.
        /// </summary>
        public bool IsLimitedEdition;
        /// <summary>
        /// If the item has IsLImitedEdition set to true, and this is the first time this ItemId has been defined as a limited edition item, this value determines the total number of instances to allocate for the title. Once this limit has been reached, no more instances of this ItemId can be created, and attempts to purchase or grant it will return a Result of false for that ItemId. If the item has already been defined to have a limited edition count, or if this value is less than zero, it will be ignored.
        /// </summary>
        public int InitialLimitedEditionCount;
    }

    [Serializable]
    public class CatalogItemBundleInfo
    {
        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory when the bundle is added
        /// </summary>
        public List<string> BundledItems;
        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
        /// </summary>
        public List<string> BundledResultTables;
        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the bundle is added
        /// </summary>
        public Dictionary<string,uint> BundledVirtualCurrencies;
    }

    [Serializable]
    public class CatalogItemConsumableInfo
    {
        /// <summary>
        /// number of times this object can be used, after which it will be removed from the player inventory
        /// </summary>
        public uint? UsageCount;
        /// <summary>
        /// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed (recommended minimum value is 5 seconds, as lower values can cause the item to expire before operations depending on this item's details have completed)
        /// </summary>
        public uint? UsagePeriod;
        /// <summary>
        /// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
        /// </summary>
        public string UsagePeriodGroup;
    }

    /// <summary>
    /// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
    /// </summary>
    [Serializable]
    public class CatalogItemContainerInfo
    {
        /// <summary>
        /// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will open the container, adding the contents to the player inventory and currency balances)
        /// </summary>
        public string KeyItemId;
        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
        /// </summary>
        public List<string> ItemContents;
        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
        /// </summary>
        public List<string> ResultTableContents;
        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the container is unlocked
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyContents;
    }

    [Serializable]
    public class CharacterInventory
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
    public class CharacterLeaderboardEntry
    {
        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// PlayFab unique identifier of the character that belongs to the user for this leaderboard entry.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Title-specific display name of the character for this leaderboard entry.
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Name of the character class for this entry.
        /// </summary>
        public string CharacterType;
        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue;
        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position;
    }

    [Serializable]
    public class CharacterResult : PlayFabResultCommon
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
    /// Collection filter to include and/or exclude collections with certain key-value pairs. The filter generates a collection set defined by Includes rules and then remove collections that matches the Excludes rules. A collection is considered matching a rule if the rule describes a subset of the collection. 
    /// </summary>
    [Serializable]
    public class CollectionFilter
    {
        /// <summary>
        /// List of Include rules, with any of which if a collection matches, it is included by the filter, unless it is excluded by one of the Exclude rule
        /// </summary>
        public List<Container_Dictionary_String_String> Includes;
        /// <summary>
        /// List of Exclude rules, with any of which if a collection matches, it is excluded by the filter.
        /// </summary>
        public List<Container_Dictionary_String_String> Excludes;
    }

    [Serializable]
    public class ConfirmPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Purchase order identifier returned from StartPurchase.
        /// </summary>
        public string OrderId;
    }

    [Serializable]
    public class ConfirmPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Date and time of the purchase.
        /// </summary>
        public DateTime PurchaseDate;
        /// <summary>
        /// Array of items purchased.
        /// </summary>
        public List<ItemInstance> Items;
    }

    [Serializable]
    public class ConsumeItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique instance identifier of the item to be consumed.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Number of uses to consume from the item.
        /// </summary>
        public int ConsumeCount;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
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

    /// <summary>
    /// A data container
    /// </summary>
    [Serializable]
    public class Container_Dictionary_String_String
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
        /// Region to check for Game Server Instances.
        /// </summary>
        public Region? Region;
        /// <summary>
        /// Build to match against.
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// Game mode to look for.
        /// </summary>
        public string GameMode;
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
        /// array of games found
        /// </summary>
        public List<GameInfo> Games;
        /// <summary>
        /// total number of players across all servers
        /// </summary>
        public int PlayerCount;
        /// <summary>
        /// number of games running
        /// </summary>
        public int GameCount;
    }

    [Serializable]
    public class EmptyResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ExecuteCloudScriptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The name of the CloudScript function to execute
        /// </summary>
        public string FunctionName;
        /// <summary>
        /// Object that is passed in to the function as the first argument
        /// </summary>
        public object FunctionParameter;
        /// <summary>
        /// Option for which revision of the CloudScript to execute. 'Latest' executes the most recently created revision, 'Live' executes the current live, published revision, and 'Specific' executes the specified revision. The default value is 'Specific', if the SpeificRevision parameter is specified, otherwise it is 'Live'.
        /// </summary>
        public CloudScriptRevisionOption? RevisionSelection;
        /// <summary>
        /// The specivic revision to execute, when RevisionSelection is set to 'Specific'
        /// </summary>
        public int? SpecificRevision;
        /// <summary>
        /// Generate a 'player_executed_cloudscript' PlayStream event containing the results of the function execution and other contextual information. This event will show up in the PlayStream debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent;
    }

    [Serializable]
    public class ExecuteCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// The name of the function that executed
        /// </summary>
        public string FunctionName;
        /// <summary>
        /// The revision of the CloudScript that executed
        /// </summary>
        public int Revision;
        /// <summary>
        /// The object returned from the CloudScript function, if any
        /// </summary>
        public object FunctionResult;
        /// <summary>
        /// Flag indicating if the FunctionResult was too large and was subsequently dropped from this event. This only occurs if the total event size is larger than 350KB.
        /// </summary>
        public bool? FunctionResultTooLarge;
        /// <summary>
        /// Entries logged during the function execution. These include both entries logged in the function code using log.info() and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public List<LogStatement> Logs;
        /// <summary>
        /// Flag indicating if the logs were too large and were subsequently dropped from this event. This only occurs if the total event size is larger than 350KB after the FunctionResult was removed.
        /// </summary>
        public bool? LogsTooLarge;
        public double ExecutionTimeSeconds;
        /// <summary>
        /// Processor time consumed while executing the function. This does not include time spent waiting on API calls or HTTP requests.
        /// </summary>
        public double ProcessorTimeSeconds;
        public uint MemoryConsumedBytes;
        /// <summary>
        /// Number of PlayFab API requests issued by the CloudScript function
        /// </summary>
        public int APIRequestsIssued;
        /// <summary>
        /// Number of external HTTP requests issued by the CloudScript function
        /// </summary>
        public int HttpRequestsIssued;
        /// <summary>
        /// Information about the error, if any, that occurred during execution
        /// </summary>
        public ScriptExecutionError Error;
    }

    [Serializable]
    public class FacebookPlayFabIdPair
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
    public class FriendInfo
    {
        /// <summary>
        /// PlayFab unique identifier for this friend.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// PlayFab unique username for this friend.
        /// </summary>
        public string Username;
        /// <summary>
        /// Title-specific display name for this friend.
        /// </summary>
        public string TitleDisplayName;
        /// <summary>
        /// Tags which have been associated with this friend.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// Unique lobby identifier of the Game Server Instance to which this player is currently connected.
        /// </summary>
        public string CurrentMatchmakerLobbyId;
        /// <summary>
        /// Available Facebook information (if the user and PlayFab friend are also connected in Facebook).
        /// </summary>
        public UserFacebookInfo FacebookInfo;
        /// <summary>
        /// Available Steam information (if the user and PlayFab friend are also connected in Steam).
        /// </summary>
        public UserSteamInfo SteamInfo;
        /// <summary>
        /// Available Game Center information (if the user and PlayFab friend are also connected in Game Center).
        /// </summary>
        public UserGameCenterInfo GameCenterInfo;
    }

    [Serializable]
    public class GameCenterPlayFabIdPair
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
    public class GameInfo
    {
        /// <summary>
        /// region to which this server is associated
        /// </summary>
        public Region? Region;
        /// <summary>
        /// unique lobby identifier for this game server
        /// </summary>
        public string LobbyID;
        /// <summary>
        /// build version this server is running
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// game mode this server is running
        /// </summary>
        public string GameMode;
        /// <summary>
        /// stastic used to match this game in player statistic matchmaking
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// maximum players this server can support
        /// </summary>
        public int? MaxPlayers;
        /// <summary>
        /// array of current player IDs on this server
        /// </summary>
        public List<string> PlayerUserIds;
        /// <summary>
        /// duration in seconds this server has been running
        /// </summary>
        public uint RunTime;
        /// <summary>
        /// game specific string denoting server configuration
        /// </summary>
        public GameInstanceState? GameServerState;
        /// <summary>
        /// game session custom data
        /// </summary>
        public string GameServerData;
        /// <summary>
        /// game session tags
        /// </summary>
        public Dictionary<string,string> Tags;
        /// <summary>
        /// last heartbeat of the game server instance, used in external game server provider mode
        /// </summary>
        public DateTime? LastHeartbeat;
        /// <summary>
        /// IP address of the server
        /// </summary>
        public string ServerHostname;
        /// <summary>
        /// port number to use for non-http communications with the server
        /// </summary>
        public int? ServerPort;
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
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
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
    public class GenericPlayFabIdPair
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
    public class GenericServiceId
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
        /// Unique PlayFab identifier of the user whose info is being requested. Optional, defaults to the authenticated user if no other lookup identifier set.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// PlayFab Username for the account to find (if no PlayFabId is specified).
        /// </summary>
        public string Username;
        /// <summary>
        /// User email address for the account to find (if no Username is specified).
        /// </summary>
        public string Email;
        /// <summary>
        /// Title-specific username for the account to find (if no Email is set). Note that if the non-unique Title Display Names option is enabled for the title, attempts to look up users by Title Display Name will always return AccountNotFound.
        /// </summary>
        public string TitleDisplayName;
    }

    [Serializable]
    public class GetAccountInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// Account information for the local user.
        /// </summary>
        public UserAccountInfo AccountInfo;
    }

    [Serializable]
    public class GetCatalogItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Which catalog is being requested. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
    }

    [Serializable]
    public class GetCatalogItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items which can be purchased.
        /// </summary>
        public List<CatalogItem> Catalog;
    }

    [Serializable]
    public class GetCharacterDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab identifier of the user to load data for. Optional, defaults to yourself if not set.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion;
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
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    [Serializable]
    public class GetCharacterInventoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Used to limit results to only those from a specific catalog version.
        /// </summary>
        public string CatalogVersion;
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
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
    }

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
        /// Key of the content item to fetch, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key;
        /// <summary>
        /// HTTP method to fetch item - GET or HEAD. Use HEAD when only fetching metadata. Default is GET.
        /// </summary>
        public string HttpMethod;
        /// <summary>
        /// True if download through CDN. CDN provides better download bandwidth and time. However, if you want latest, non-cached version of the content, set this to false. Default is true.
        /// </summary>
        public bool? ThruCDN;
    }

    [Serializable]
    public class GetContentDownloadUrlResult : PlayFabResultCommon
    {
        /// <summary>
        /// URL for downloading content via HTTP GET or HEAD method. The URL will expire in 1 hour.
        /// </summary>
        public string URL;
    }

    [Serializable]
    public class GetFriendLeaderboardAroundPlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// PlayFab unique identifier of the user to center the leaderboard around. If null will center on the logged in user.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends;
        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. For API calls from the client, only ShowDisplayName, ShowAvatarUrl are allowed at this time.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetFriendLeaderboardAroundPlayerResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;
        /// <summary>
        /// The version of the leaderboard returned.
        /// </summary>
        public int Version;
        /// <summary>
        /// The time the next scheduled reset will occur. Null if the leaderboard does not reset on a schedule.
        /// </summary>
        public DateTime? NextReset;
    }

    [Serializable]
    public class GetFriendLeaderboardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Statistic used to rank friends for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Position in the leaderboard to start this listing (defaults to the first entry).
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends;
        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. For API calls from the client, only ShowDisplayName, ShowAvatarUrl are allowed at this time.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetFriendsListRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends;
        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends;
    }

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
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
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
    }

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
        /// PlayFab unique identifier of the user to center the leaderboard around. If null will center on the logged in user.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. For API calls from the client, only ShowDisplayName, ShowAvatarUrl are allowed at this time.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetLeaderboardAroundPlayerResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;
        /// <summary>
        /// The version of the leaderboard returned.
        /// </summary>
        public int Version;
        /// <summary>
        /// The time the next scheduled reset will occur. Null if the leaderboard does not reset on a schedule.
        /// </summary>
        public DateTime? NextReset;
    }

    [Serializable]
    public class GetLeaderboardForUsersCharactersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
    }

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
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Position in the leaderboard to start this listing (defaults to the first entry).
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. For API calls from the client, only ShowDisplayName, ShowAvatarUrl are allowed at this time.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetLeaderboardResult : PlayFabResultCommon
    {
        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard;
        /// <summary>
        /// The version of the leaderboard returned.
        /// </summary>
        public int Version;
        /// <summary>
        /// The time the next scheduled reset will occur. Null if the leaderboard does not reset on a schedule.
        /// </summary>
        public DateTime? NextReset;
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
        /// PlayFabId of the user whose data will be returned. If not filled included, we return the data for the calling player. 
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class GetPlayerCombinedInfoRequestParams
    {
        /// <summary>
        /// Whether to get the player's account Info. Defaults to false
        /// </summary>
        public bool GetUserAccountInfo;
        /// <summary>
        /// Whether to get the player's inventory. Defaults to false
        /// </summary>
        public bool GetUserInventory;
        /// <summary>
        /// Whether to get the player's virtual currency balances. Defaults to false
        /// </summary>
        public bool GetUserVirtualCurrency;
        /// <summary>
        /// Whether to get the player's custom data. Defaults to false
        /// </summary>
        public bool GetUserData;
        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetUserData is false
        /// </summary>
        public List<string> UserDataKeys;
        /// <summary>
        /// Whether to get the player's read only data. Defaults to false
        /// </summary>
        public bool GetUserReadOnlyData;
        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetUserReadOnlyData is false
        /// </summary>
        public List<string> UserReadOnlyDataKeys;
        /// <summary>
        /// Whether to get character inventories. Defaults to false.
        /// </summary>
        public bool GetCharacterInventories;
        /// <summary>
        /// Whether to get the list of characters. Defaults to false.
        /// </summary>
        public bool GetCharacterList;
        /// <summary>
        /// Whether to get title data. Defaults to false.
        /// </summary>
        public bool GetTitleData;
        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys. Has no effect if GetTitleData is false
        /// </summary>
        public List<string> TitleDataKeys;
        /// <summary>
        /// Whether to get player statistics. Defaults to false.
        /// </summary>
        public bool GetPlayerStatistics;
        /// <summary>
        /// Specific statistics to retrieve. Leave null to get all keys. Has no effect if GetPlayerStatistics is false
        /// </summary>
        public List<string> PlayerStatisticNames;
        /// <summary>
        /// Whether to get player profile. Defaults to false.
        /// </summary>
        public bool GetPlayerProfile;
        /// <summary>
        /// Specifies the properties to return from the player profile. Defaults to returning the player's display name.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetPlayerCombinedInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Results for requested info.
        /// </summary>
        public GetPlayerCombinedInfoResultPayload InfoResultPayload;
    }

    [Serializable]
    public class GetPlayerCombinedInfoResultPayload
    {
        /// <summary>
        /// Account information for the user. This is always retrieved.
        /// </summary>
        public UserAccountInfo AccountInfo;
        /// <summary>
        /// Array of inventory items in the user's current inventory.
        /// </summary>
        public List<ItemInstance> UserInventory;
        /// <summary>
        /// Dictionary of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> UserVirtualCurrency;
        /// <summary>
        /// Dictionary of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> UserVirtualCurrencyRechargeTimes;
        /// <summary>
        /// User specific custom data.
        /// </summary>
        public Dictionary<string,UserDataRecord> UserData;
        /// <summary>
        /// The version of the UserData that was returned.
        /// </summary>
        public uint UserDataVersion;
        /// <summary>
        /// User specific read-only data.
        /// </summary>
        public Dictionary<string,UserDataRecord> UserReadOnlyData;
        /// <summary>
        /// The version of the Read-Only UserData that was returned.
        /// </summary>
        public uint UserReadOnlyDataVersion;
        /// <summary>
        /// List of characters for the user.
        /// </summary>
        public List<CharacterResult> CharacterList;
        /// <summary>
        /// Inventories for each character for the user.
        /// </summary>
        public List<CharacterInventory> CharacterInventories;
        /// <summary>
        /// Title data for this title.
        /// </summary>
        public Dictionary<string,string> TitleData;
        /// <summary>
        /// List of statistics for this player.
        /// </summary>
        public List<StatisticValue> PlayerStatistics;
        /// <summary>
        /// The profile of the players. This profile is not guaranteed to be up-to-date. For a new player, this profile will not exist.
        /// </summary>
        public PlayerProfileModel PlayerProfile;
    }

    [Serializable]
    public class GetPlayerProfileRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. For API calls from the client, only ShowDisplayName, ShowAvatarUrl are allowed at this time.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetPlayerProfileResult : PlayFabResultCommon
    {
        /// <summary>
        /// The profile of the player. This profile is not guaranteed to be up-to-date. For a new player, this profile will not exist.
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
        /// statistics to return (current version will be returned for each)
        /// </summary>
        public List<string> StatisticNames;
        /// <summary>
        /// statistics to return, if StatisticNames is not set (only statistics which have a version matching that provided will be returned)
        /// </summary>
        public List<StatisticNameVersion> StatisticNameVersions;
    }

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

    [Serializable]
    public class GetPlayerTagsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Optional namespace to filter results by
        /// </summary>
        public string Namespace;
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
        /// The trades for this player which are currently available to be accepted.
        /// </summary>
        public List<TradeInfo> OpenedTrades;
        /// <summary>
        /// History of trades which this player has accepted.
        /// </summary>
        public List<TradeInfo> AcceptedTrades;
    }

    [Serializable]
    public class GetPlayFabIDsFromFacebookIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Facebook identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> FacebookIDs;
    }

    [Serializable]
    public class GetPlayFabIDsFromFacebookIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Facebook identifiers to PlayFab identifiers.
        /// </summary>
        public List<FacebookPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromGameCenterIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Game Center identifiers (the Player Identifier) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> GameCenterIDs;
    }

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
        /// Array of unique generic service identifiers for which the title needs to get PlayFab identifiers. Currently limited to a maximum of 10 in a single request.
        /// </summary>
        public List<GenericServiceId> GenericIDs;
    }

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

    [Serializable]
    public class GetPlayFabIDsFromKongregateIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Kongregate identifiers to PlayFab identifiers.
        /// </summary>
        public List<KongregatePlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromSteamIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Steam identifiers (Steam profile IDs) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> SteamStringIDs;
    }

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

    [Serializable]
    public class GetPlayFabIDsFromTwitchIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Twitch identifiers to PlayFab identifiers.
        /// </summary>
        public List<TwitchPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPublisherDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        ///  array of keys to get back data from the Publisher data blob, set by the admin tools
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
        /// Provider transaction ID (If not VC)
        /// </summary>
        public string TransactionId;
        /// <summary>
        /// PlayFab transaction status
        /// </summary>
        public string TransactionStatus;
        /// <summary>
        /// Date and time of the purchase.
        /// </summary>
        public DateTime PurchaseDate;
    }

    [Serializable]
    public class GetSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string Id;
        /// <summary>
        /// Segment name.
        /// </summary>
        public string Name;
        /// <summary>
        /// Identifier of the segments AB Test, if it is attached to one.
        /// </summary>
        public string ABTestParent;
    }

    [Serializable]
    public class GetSharedGroupDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
        /// <summary>
        /// Specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned).
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// If true, return the list of all members of the shared group.
        /// </summary>
        public bool? GetMembers;
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

    [Serializable]
    public class GetStoreItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// catalog version to store items from. Use default catalog version if null
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
        /// Array of items which can be purchased from this store.
        /// </summary>
        public List<StoreItem> Store;
        /// <summary>
        /// How the store was last updated (Admin or a third party).
        /// </summary>
        public SourceType? Source;
        /// <summary>
        /// The base catalog that this store is a part of.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The ID of this store.
        /// </summary>
        public string StoreId;
        /// <summary>
        /// Additional data about the store.
        /// </summary>
        public StoreMarketingModel MarketingData;
    }

    [Serializable]
    public class GetTimeRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetTimeResult : PlayFabResultCommon
    {
        /// <summary>
        /// Current server time when the request was received, in UTC
        /// </summary>
        public DateTime Time;
    }

    [Serializable]
    public class GetTitleDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specific keys to search for in the title data (leave null to get all keys)
        /// </summary>
        public List<string> Keys;
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

    [Serializable]
    public class GetTitlePublicKeyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
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

    [Serializable]
    public class GetUserDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys.
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// Unique PlayFab identifier of the user to load data for. Optional, defaults to yourself if not set. When specified to a PlayFab id of another player, then this will only return public keys for that account.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion;
    }

    [Serializable]
    public class GetUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data;
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    [Serializable]
    public class GetUserInventoryRequest : PlayFabRequestCommon
    {
    }

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
    public class GetWindowsHelloChallengeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// SHA256 hash of the PublicKey generated by Windows Hello.
        /// </summary>
        public string PublicKeyHint;
    }

    [Serializable]
    public class GetWindowsHelloChallengeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Server generated challenge to be signed by the user.
        /// </summary>
        public string Challenge;
    }

    [Serializable]
    public class GooglePlayFabIdPair
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

    [Serializable]
    public class GrantCharacterToUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Catalog item identifier of the item in the user's inventory that corresponds to the character in the catalog to be created.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Non-unique display name of the character being granted (1-20 characters in length).
        /// </summary>
        public string CharacterName;
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
    /// A unique instance of an item in a user's inventory. Note, to retrieve additional information for an item instance (such as Tags, Description, or Custom Data that are set on the root catalog item), a call to GetCatalogItems is required. The Item ID of the instance can then be matched to a catalog entry, which contains the additional information. Also note that Custom Data is only set here from a call to UpdateUserInventoryItemCustomData.
    /// </summary>
    [Serializable]
    public class ItemInstance
    {
        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass;
        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate;
        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration;
        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses;
        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy;
        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
        /// </summary>
        public string BundleParent;
        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Currency type for the cost of the catalog item.
        /// </summary>
        public string UnitCurrency;
        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice;
        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents;
        /// <summary>
        /// A set of custom key-value pairs on the inventory item.
        /// </summary>
        public Dictionary<string,string> CustomData;
    }

    [Serializable]
    public class ItemPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique ItemId of the item to purchase.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// How many of this item to purchase.
        /// </summary>
        public uint Quantity;
        /// <summary>
        /// Title-specific text concerning this purchase.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Items to be upgraded as a result of this purchase (upgraded items are hidden, as they are "replaced" by the new items).
        /// </summary>
        public List<string> UpgradeFromItems;
    }

    [Serializable]
    public class KongregatePlayFabIdPair
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
        /// Android device identifier for the user's device.
        /// </summary>
        public string AndroidDeviceId;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string AndroidDevice;
        /// <summary>
        /// If another user is already linked to the device, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkAndroidDeviceIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkCustomIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom unique identifier for the user, generated by the title.
        /// </summary>
        public string CustomId;
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
    public class LinkedPlatformAccountModel
    {
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
        /// <summary>
        /// Linked account email of the user on the platform, if available
        /// </summary>
        public string Email;
    }

    [Serializable]
    public class LinkFacebookAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier from Facebook for the user.
        /// </summary>
        public string AccessToken;
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
    public class LinkGameCenterAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Game Center identifier for the player account to be linked.
        /// </summary>
        public string GameCenterId;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkGameCenterAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkGoogleAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Server authentication code obtained on the client by calling getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access) from Google Play for the user.
        /// </summary>
        public string ServerAuthCode;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkGoogleAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkIOSDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string DeviceModel;
        /// <summary>
        /// If another user is already linked to the device, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkIOSDeviceIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkKongregateAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Numeric user ID assigned by Kongregate
        /// </summary>
        public string KongregateId;
        /// <summary>
        /// Valid session auth ticket issued by Kongregate
        /// </summary>
        public string AuthTicket;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkKongregateAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkSteamAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08").
        /// </summary>
        public string SteamTicket;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
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
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkTwitchAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkWindowsHelloAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Player's user named used by Windows Hello.
        /// </summary>
        public string UserName;
        /// <summary>
        /// PublicKey generated by Windows Hello.
        /// </summary>
        public string PublicKey;
        /// <summary>
        /// Device name.
        /// </summary>
        public string DeviceName;
        /// <summary>
        /// If another user is already linked to the account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
    }

    [Serializable]
    public class LinkWindowsHelloAccountResponse : PlayFabResultCommon
    {
    }

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
    public class LocationModel
    {
        /// <summary>
        /// The two-character continent code for this location
        /// </summary>
        public ContinentCode? ContinentCode;
        /// <summary>
        /// The two-character ISO 3166-1 country code for the country associated with the location
        /// </summary>
        public CountryCode? CountryCode;
        /// <summary>
        /// City name.
        /// </summary>
        public string City;
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
        WindowsHello
    }

    [Serializable]
    public class LoginResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique token authorizing the user and game at the server level, for the current session.
        /// </summary>
        public string SessionTicket;
        /// <summary>
        /// Player's unique PlayFabId.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// True if the account was newly created on this login.
        /// </summary>
        public bool NewlyCreated;
        /// <summary>
        /// Settings specific to this user.
        /// </summary>
        public UserSettings SettingsForUser;
        /// <summary>
        /// The time of this user's previous login. If there was no previous login, then it's DateTime.MinValue
        /// </summary>
        public DateTime? LastLoginTime;
        /// <summary>
        /// Results for requested info.
        /// </summary>
        public GetPlayerCombinedInfoResultPayload InfoResultPayload;
    }

    [Serializable]
    public class LoginWithAndroidDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Android device identifier for the user's device.
        /// </summary>
        public string AndroidDeviceId;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string AndroidDevice;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithCustomIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom unique identifier for the user, generated by the title.
        /// </summary>
        public string CustomId;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithEmailAddressRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Email address for the account.
        /// </summary>
        public string Email;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

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
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithGameCenterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique Game Center player id.
        /// </summary>
        public string PlayerId;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithGoogleAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// OAuth 2.0 server authentication code obtained on the client by calling the getServerAuthCode() (https://developers.google.com/identity/sign-in/android/offline-access) Google client API.
        /// </summary>
        public string ServerAuthCode;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithIOSDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId;
        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS;
        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string DeviceModel;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithKongregateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Numeric user ID assigned by Kongregate
        /// </summary>
        public string KongregateId;
        /// <summary>
        /// Token issued by Kongregate's client API for the user.
        /// </summary>
        public string AuthTicket;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
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
    public class LoginWithPlayFabRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// PlayFab username for the account.
        /// </summary>
        public string Username;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithSteamRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08").
        /// </summary>
        public string SteamTicket;
        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this ID.
        /// </summary>
        public bool? CreateAccount;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

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
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LoginWithWindowsHelloRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// The signed response from the user for the Challenge.
        /// </summary>
        public string ChallengeSignature;
        /// <summary>
        /// SHA256 hash of the PublicKey generated by Windows Hello.
        /// </summary>
        public string PublicKeyHint;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class LogStatement
    {
        /// <summary>
        /// 'Debug', 'Info', or 'Error'
        /// </summary>
        public string Level;
        public string Message;
        /// <summary>
        /// Optional object accompanying the message as contextual information
        /// </summary>
        public object Data;
    }

    [Serializable]
    public class MatchmakeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Build version to match against. [Note: Required if LobbyId is not specified]
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// Region to match make against. [Note: Required if LobbyId is not specified]
        /// </summary>
        public Region? Region;
        /// <summary>
        /// Game mode to match make against. [Note: Required if LobbyId is not specified]
        /// </summary>
        public string GameMode;
        /// <summary>
        /// Lobby identifier to match make against. This is used to select a specific Game Server Instance.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// Player statistic to use in finding a match. May be null for no stat-based matching.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Character to use for stats based matching. Leave null to use account stats.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Start a game session if one with an open slot is not found. Defaults to true.
        /// </summary>
        public bool? StartNewIfNoneFound;
        /// <summary>
        /// Filter to include and/or exclude Game Server Instances associated with certain Tags
        /// </summary>
        public CollectionFilter TagFilter;
    }

    [Serializable]
    public class MatchmakeResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique lobby identifier of the server matched
        /// </summary>
        public string LobbyID;
        /// <summary>
        /// IP address of the server
        /// </summary>
        public string ServerHostname;
        /// <summary>
        /// port number to use for non-http communications with the server
        /// </summary>
        public int? ServerPort;
        /// <summary>
        /// server authorization ticket (used by RedeemMatchmakerTicket to validate user insertion into the game)
        /// </summary>
        public string Ticket;
        /// <summary>
        /// timestamp for when the server will expire, if applicable
        /// </summary>
        public string Expires;
        /// <summary>
        /// time in milliseconds the application is configured to wait on matchmaking results
        /// </summary>
        public int? PollWaitTimeMS;
        /// <summary>
        /// result of match making process
        /// </summary>
        public MatchmakeStatus? Status;
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
    public class ModifyUserVirtualCurrencyResult : PlayFabResultCommon
    {
        /// <summary>
        /// User currency was subtracted from.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency;
        /// <summary>
        /// Amount added or subtracted from the user's virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int BalanceChange;
        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance;
    }

    /// <summary>
    /// Identifier by either name or ID. Note that a name may change due to renaming, or reused after being deleted. ID is immutable and unique.
    /// </summary>
    [Serializable]
    public class NameIdentifier
    {
        public string Name;
        public string Id;
    }

    [Serializable]
    public class OpenTradeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Player inventory items offered for trade. If not set, the trade is effectively a gift request
        /// </summary>
        public List<string> OfferedInventoryInstanceIds;
        /// <summary>
        /// Catalog items accepted for the trade. If not set, the trade is effectively a gift.
        /// </summary>
        public List<string> RequestedCatalogItemIds;
        /// <summary>
        /// Players who are allowed to accept the trade. If null, the trade may be accepted by any player. If empty, the trade may not be accepted by any player.
        /// </summary>
        public List<string> AllowedPlayerIds;
    }

    [Serializable]
    public class OpenTradeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The information about the trade that was just opened.
        /// </summary>
        public TradeInfo Trade;
    }

    [Serializable]
    public class PayForPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Purchase order identifier returned from StartPurchase.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Payment provider to use to fund the purchase.
        /// </summary>
        public string ProviderName;
        /// <summary>
        /// Currency to use to fund the purchase.
        /// </summary>
        public string Currency;
        /// <summary>
        /// Payment provider transaction identifier. Required for Facebook Payments.
        /// </summary>
        public string ProviderTransactionId;
    }

    [Serializable]
    public class PayForPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Status of the transaction.
        /// </summary>
        public TransactionStatus? Status;
        /// <summary>
        /// Virtual currency cost of the transaction.
        /// </summary>
        public Dictionary<string,int> VCAmount;
        /// <summary>
        /// Real world currency for the transaction.
        /// </summary>
        public string PurchaseCurrency;
        /// <summary>
        /// Real world cost of the transaction.
        /// </summary>
        public uint PurchasePrice;
        /// <summary>
        /// Local credit applied to the transaction (provider specific).
        /// </summary>
        public uint CreditApplied;
        /// <summary>
        /// Provider used for the transaction.
        /// </summary>
        public string ProviderData;
        /// <summary>
        /// URL to the purchase provider page that details the purchase.
        /// </summary>
        public string PurchaseConfirmationPageURL;
        /// <summary>
        /// Current virtual currency totals for the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency;
        /// <summary>
        /// A token generated by the provider to authenticate the request (provider-specific).
        /// </summary>
        public string ProviderToken;
    }

    [Serializable]
    public class PaymentOption
    {
        /// <summary>
        /// Specific currency to use to fund the purchase.
        /// </summary>
        public string Currency;
        /// <summary>
        /// Name of the purchase provider for this option.
        /// </summary>
        public string ProviderName;
        /// <summary>
        /// Amount of the specified currency needed for the purchase.
        /// </summary>
        public uint Price;
        /// <summary>
        /// Amount of existing credit the user has with the provider.
        /// </summary>
        public uint StoreCredit;
    }

    [Serializable]
    public class PlayerLeaderboardEntry
    {
        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue;
        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position;
        /// <summary>
        /// The profile of the user, if requested.
        /// </summary>
        public PlayerProfileModel Profile;
    }

    [Serializable]
    public class PlayerProfileModel
    {
        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId;
        /// <summary>
        /// Title ID this player profile applies to
        /// </summary>
        public string TitleId;
        /// <summary>
        /// PlayFab player account unique identifier
        /// </summary>
        public string PlayerId;
        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created;
        /// <summary>
        /// Player account origination
        /// </summary>
        public LoginIdentityProvider? Origination;
        /// <summary>
        /// UTC time when the player most recently logged in to the title
        /// </summary>
        public DateTime? LastLogin;
        /// <summary>
        /// If the player is currently banned, the UTC Date when the ban expires
        /// </summary>
        public DateTime? BannedUntil;
        /// <summary>
        /// List of geographic locations from which the player has logged in to the title
        /// </summary>
        public List<LocationModel> Locations;
        /// <summary>
        /// Player display name
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// URL of the player's avatar image
        /// </summary>
        public string AvatarUrl;
        /// <summary>
        /// List of player's tags for segmentation
        /// </summary>
        public List<TagModel> Tags;
        /// <summary>
        /// List of configured end points registered for sending the player push notifications
        /// </summary>
        public List<PushNotificationRegistrationModel> PushNotificationRegistrations;
        /// <summary>
        /// List of all authentication systems linked to this player account
        /// </summary>
        public List<LinkedPlatformAccountModel> LinkedAccounts;
        /// <summary>
        /// List of advertising campaigns the player has been attributed to
        /// </summary>
        public List<AdCampaignAttributionModel> AdCampaignAttributions;
        /// <summary>
        /// Sum of the player's purchases made with real-money currencies, converted to US dollars equivalent and represented as a whole number of cents (1/100 USD).              For example, 999 indicates nine dollars and ninety-nine cents.
        /// </summary>
        public uint? TotalValueToDateInUSD;
        /// <summary>
        /// List of the player's lifetime purchase totals, summed by real-money currency
        /// </summary>
        public List<ValueToDateModel> ValuesToDate;
        /// <summary>
        /// List of the player's virtual currency balances
        /// </summary>
        public List<VirtualCurrencyBalanceModel> VirtualCurrencyBalances;
        /// <summary>
        /// List of leaderboard statistic values for the player
        /// </summary>
        public List<StatisticModel> Statistics;
    }

    [Serializable]
    public class PlayerProfileViewConstraints
    {
        /// <summary>
        /// Whether to show the display name. Defaults to false
        /// </summary>
        public bool ShowDisplayName;
        /// <summary>
        /// Whether to show the created date. Defaults to false
        /// </summary>
        public bool ShowCreated;
        /// <summary>
        /// Whether to show origination. Defaults to false
        /// </summary>
        public bool ShowOrigination;
        /// <summary>
        /// Whether to show the last login time. Defaults to false
        /// </summary>
        public bool ShowLastLogin;
        /// <summary>
        /// Whether to show the banned until time. Defaults to false
        /// </summary>
        public bool ShowBannedUntil;
        /// <summary>
        /// Reserved for future development
        /// </summary>
        public bool ShowStatistics;
        /// <summary>
        /// Whether to show campaign attributions. Defaults to false
        /// </summary>
        public bool ShowCampaignAttributions;
        /// <summary>
        /// Whether to show push notification registrations. Defaults to false
        /// </summary>
        public bool ShowPushNotificationRegistrations;
        /// <summary>
        /// Whether to show the linked accounts. Defaults to false
        /// </summary>
        public bool ShowLinkedAccounts;
        /// <summary>
        /// Whether to show the total value to date in usd. Defaults to false
        /// </summary>
        public bool ShowTotalValueToDateInUsd;
        /// <summary>
        /// Whether to show the values to date. Defaults to false
        /// </summary>
        public bool ShowValuesToDate;
        /// <summary>
        /// Whether to show tags. Defaults to false
        /// </summary>
        public bool ShowTags;
        /// <summary>
        /// Whether to show player's locations. Defaults to false
        /// </summary>
        public bool ShowLocations;
        /// <summary>
        /// Whether to show player's avatar URL. Defaults to false
        /// </summary>
        public bool ShowAvatarUrl;
    }

    [Serializable]
    public class PlayerStatisticVersion
    {
        /// <summary>
        /// name of the statistic when the version became active
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// version of the statistic
        /// </summary>
        public uint Version;
        /// <summary>
        /// time at which the statistic version was scheduled to become active, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledActivationTime;
        /// <summary>
        /// time when the statistic version became active
        /// </summary>
        public DateTime ActivationTime;
        /// <summary>
        /// time at which the statistic version was scheduled to become inactive, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledDeactivationTime;
        /// <summary>
        /// time when the statistic version became inactive due to statistic version incrementing
        /// </summary>
        public DateTime? DeactivationTime;
    }

    [Serializable]
    public class PurchaseItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the item to purchase.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Virtual currency to use to purchase the item.
        /// </summary>
        public string VirtualCurrency;
        /// <summary>
        /// Price the client expects to pay for the item (in case a new catalog or store was uploaded, with new prices).
        /// </summary>
        public int Price;
        /// <summary>
        /// Catalog version for the items to be purchased (defaults to most recent version.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Store to buy this item through. If not set, prices default to those in the catalog.
        /// </summary>
        public string StoreId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
    }

    [Serializable]
    public class PurchaseItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Details for the items purchased.
        /// </summary>
        public List<ItemInstance> Items;
    }

    public enum PushNotificationPlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    [Serializable]
    public class PushNotificationRegistrationModel
    {
        /// <summary>
        /// Push notification platform
        /// </summary>
        public PushNotificationPlatform? Platform;
        /// <summary>
        /// Notification configured endpoint
        /// </summary>
        public string NotificationEndpointARN;
    }

    [Serializable]
    public class RedeemCouponRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Generated coupon code to redeem.
        /// </summary>
        public string CouponCode;
        /// <summary>
        /// Catalog version of the coupon. If null, uses the default catalog
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Optional identifier for the Character that should receive the item. If null, item is added to the player
        /// </summary>
        public string CharacterId;
    }

    [Serializable]
    public class RedeemCouponResult : PlayFabResultCommon
    {
        /// <summary>
        /// Items granted to the player as a result of redeeming the coupon.
        /// </summary>
        public List<ItemInstance> GrantedItems;
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
    public class RegionInfo
    {
        /// <summary>
        /// unique identifier for the region
        /// </summary>
        public Region? Region;
        /// <summary>
        /// name of the region
        /// </summary>
        public string Name;
        /// <summary>
        /// indicates whether the server specified is available in this region
        /// </summary>
        public bool Available;
        /// <summary>
        /// url to ping to get roundtrip time
        /// </summary>
        public string PingUrl;
    }

    [Serializable]
    public class RegisterForIOSPushNotificationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique token generated by the Apple Push Notification service when the title registered to receive push notifications.
        /// </summary>
        public string DeviceToken;
        /// <summary>
        /// If true, send a test push message immediately after sucessful registration. Defaults to false.
        /// </summary>
        public bool? SendPushNotificationConfirmation;
        /// <summary>
        /// Message to display when confirming push notification.
        /// </summary>
        public string ConfirmationMessage;
    }

    [Serializable]
    public class RegisterForIOSPushNotificationResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class RegisterPlayFabUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username;
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password;
        /// <summary>
        /// An optional parameter that specifies whether both the username and email parameters are required. If true, both parameters are required; if false, the user must supply either the username or email parameter. The default value is true.
        /// </summary>
        public bool? RequireBothUsernameAndEmail;
        /// <summary>
        /// An optional parameter for setting the display name for this title (3-25 characters).
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
    }

    [Serializable]
    public class RegisterPlayFabUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier for this newly created account.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique token identifying the user and game at the server level, for the current session.
        /// </summary>
        public string SessionTicket;
        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username;
        /// <summary>
        /// Settings specific to this user.
        /// </summary>
        public UserSettings SettingsForUser;
    }

    [Serializable]
    public class RegisterWithWindowsHelloRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Player's user name used by Windows Hello.
        /// </summary>
        public string UserName;
        /// <summary>
        /// PublicKey generated by Windows Hello.
        /// </summary>
        public string PublicKey;
        /// <summary>
        /// Device name.
        /// </summary>
        public string DeviceName;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
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
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;
    }

    [Serializable]
    public class RemoveSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ReportPlayerClientRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab identifier of the reported player.
        /// </summary>
        public string ReporteeId;
        /// <summary>
        /// Optional additional comment by reporting player.
        /// </summary>
        public string Comment;
    }

    [Serializable]
    public class ReportPlayerClientResult : PlayFabResultCommon
    {
        /// <summary>
        /// Deprecated: Always true
        /// </summary>
        [Obsolete("No longer available", false)]
        public bool? Updated;
        /// <summary>
        /// The number of remaining reports which may be filed today.
        /// </summary>
        public int SubmissionsRemaining;
    }

    [Serializable]
    public class RestoreIOSPurchasesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Base64 encoded receipt data, passed back by the App Store as a result of a successful purchase.
        /// </summary>
        public string ReceiptData;
    }

    [Serializable]
    public class RestoreIOSPurchasesResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ScriptExecutionError
    {
        /// <summary>
        /// Error code, such as CloudScriptNotFound, JavascriptException, CloudScriptFunctionArgumentSizeExceeded, CloudScriptAPIRequestCountExceeded, CloudScriptAPIRequestError, or CloudScriptHTTPRequestError
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

    [Serializable]
    public class SendAccountRecoveryEmailRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class SendAccountRecoveryEmailResult : PlayFabResultCommon
    {
    }

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

    [Serializable]
    public class SetPlayerSecretRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Base64 encoded body that is encrypted with the Title's public RSA key (Enterprise Only).
        /// </summary>
        public string EncryptedRequest;
    }

    [Serializable]
    public class SetPlayerSecretResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SharedGroupDataRecord
    {
        /// <summary>
        /// Data stored for the specified group data key.
        /// </summary>
        public string Value;
        /// <summary>
        /// Unique PlayFab identifier of the user to last update this value.
        /// </summary>
        public string LastUpdatedBy;
        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated;
        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only members of the group (private).
        /// </summary>
        public UserDataPermission? Permission;
    }

    public enum SourceType
    {
        Admin,
        BackEnd,
        GameClient,
        GameServer,
        Partner
    }

    [Serializable]
    public class StartGameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// version information for the build of the game server which is to be started
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// the region to associate this server with for match filtering
        /// </summary>
        public Region Region;
        /// <summary>
        /// the title-defined game mode this server is to be running (defaults to 0 if there is only one mode)
        /// </summary>
        public string GameMode;
        /// <summary>
        /// player statistic for others to use in finding this game. May be null for no stat-based matching
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// character to use for stats based matching. Leave null to use account stats
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// custom command line argument when starting game server process
        /// </summary>
        public string CustomCommandLineData;
    }

    [Serializable]
    public class StartGameResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for the lobby of the server started
        /// </summary>
        public string LobbyID;
        /// <summary>
        /// server IP address
        /// </summary>
        public string ServerHostname;
        /// <summary>
        /// port on the server to be used for communication
        /// </summary>
        public int? ServerPort;
        /// <summary>
        /// unique identifier for the server
        /// </summary>
        public string Ticket;
        /// <summary>
        /// timestamp for when the server should expire, if applicable
        /// </summary>
        public string Expires;
        /// <summary>
        /// password required to log into the server
        /// </summary>
        public string Password;
    }

    [Serializable]
    public class StartPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version for the items to be purchased. Defaults to most recent catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Store through which to purchase items. If not set, prices will be pulled from the catalog itself.
        /// </summary>
        public string StoreId;
        /// <summary>
        /// Array of items to purchase.
        /// </summary>
        public List<ItemPurchaseRequest> Items;
    }

    [Serializable]
    public class StartPurchaseResult : PlayFabResultCommon
    {
        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Cart items to be purchased.
        /// </summary>
        public List<CartItem> Contents;
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
    public class StatisticModel
    {
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name;
        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int Version;
        /// <summary>
        /// Statistic value
        /// </summary>
        public int Value;
    }

    [Serializable]
    public class StatisticNameVersion
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
    public class StatisticUpdate
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded. Null when setting the statistic value for the first time.
        /// </summary>
        public uint? Version;
        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value;
    }

    [Serializable]
    public class StatisticValue
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
    public class SteamPlayFabIdPair
    {
        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamStringId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam identifier.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// A store entry that list a catalog item at a particular price
    /// </summary>
    [Serializable]
    public class StoreItem
    {
        /// <summary>
        /// Unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the catalog
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Override prices for this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices;
        /// <summary>
        /// Override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices;
        /// <summary>
        /// Store specific custom data. The data only exists as part of this store; it is not transferred to item instances
        /// </summary>
        public object CustomData;
        /// <summary>
        /// Intended display position for this item. Note that 0 is the first position
        /// </summary>
        public uint? DisplayPosition;
    }

    /// <summary>
    /// Marketing data about a specific store
    /// </summary>
    [Serializable]
    public class StoreMarketingModel
    {
        /// <summary>
        /// Display name of a store as it will appear to users.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Tagline for a store.
        /// </summary>
        public string Description;
        /// <summary>
        /// Custom data about a store.
        /// </summary>
        public object Metadata;
    }

    [Serializable]
    public class SubtractUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency;
        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount;
    }

    [Serializable]
    public class TagModel
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
    public class TitleNewsItem
    {
        /// <summary>
        /// Date and time when the news items was posted.
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// Unique identifier of news item.
        /// </summary>
        public string NewsId;
        /// <summary>
        /// Title of the news item.
        /// </summary>
        public string Title;
        /// <summary>
        /// News item text.
        /// </summary>
        public string Body;
    }

    [Serializable]
    public class TradeInfo
    {
        /// <summary>
        /// Describes the current state of this trade.
        /// </summary>
        public TradeStatus? Status;
        /// <summary>
        /// The identifier for this trade.
        /// </summary>
        public string TradeId;
        /// <summary>
        /// The PlayFabId for the offering player.
        /// </summary>
        public string OfferingPlayerId;
        /// <summary>
        /// The itemInstance Ids that are being offered.
        /// </summary>
        public List<string> OfferedInventoryInstanceIds;
        /// <summary>
        /// The catalogItem Ids of the item instances being offered.
        /// </summary>
        public List<string> OfferedCatalogItemIds;
        /// <summary>
        /// The catalogItem Ids requested in exchange.
        /// </summary>
        public List<string> RequestedCatalogItemIds;
        /// <summary>
        /// An optional list of players allowed to complete this trade.  If null, anybody can complete the trade.
        /// </summary>
        public List<string> AllowedPlayerIds;
        /// <summary>
        /// The PlayFab ID of the player who accepted the trade. If null, no one has accepted the trade.
        /// </summary>
        public string AcceptedPlayerId;
        /// <summary>
        /// Item instances from the accepting player that are used to fulfill the trade. If null, no one has accepted the trade.
        /// </summary>
        public List<string> AcceptedInventoryInstanceIds;
        /// <summary>
        /// The UTC time when this trade was created.
        /// </summary>
        public DateTime? OpenedAt;
        /// <summary>
        /// If set, The UTC time when this trade was fulfilled.
        /// </summary>
        public DateTime? FilledAt;
        /// <summary>
        /// If set, The UTC time when this trade was canceled.
        /// </summary>
        public DateTime? CancelledAt;
        /// <summary>
        /// If set, The UTC time when this trade was made invalid.
        /// </summary>
        public DateTime? InvalidatedAt;
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
    public class TwitchPlayFabIdPair
    {
        /// <summary>
        /// Unique Twitch identifier for a user.
        /// </summary>
        public string TwitchId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Twitch identifier.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class UnlinkAndroidDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Android device identifier for the user's device. If not specified, the most recently signed in Android Device ID will be used.
        /// </summary>
        public string AndroidDeviceId;
    }

    [Serializable]
    public class UnlinkAndroidDeviceIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkCustomIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Custom unique identifier for the user, generated by the title. If not specified, the most recently signed in Custom ID will be used.
        /// </summary>
        public string CustomId;
    }

    [Serializable]
    public class UnlinkCustomIDResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkFacebookAccountRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class UnlinkFacebookAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkGameCenterAccountRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class UnlinkGameCenterAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkGoogleAccountRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class UnlinkGoogleAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkIOSDeviceIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Vendor-specific iOS identifier for the user's device. If not specified, the most recently signed in iOS Device ID will be used.
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
    }

    [Serializable]
    public class UnlinkKongregateAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkSteamAccountRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class UnlinkSteamAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkTwitchAccountRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class UnlinkTwitchAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkWindowsHelloAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// SHA256 hash of the PublicKey generated by Windows Hello.
        /// </summary>
        public string PublicKeyHint;
    }

    [Serializable]
    public class UnlinkWindowsHelloAccountResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlockContainerInstanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// ItemInstanceId of the container to unlock.
        /// </summary>
        public string ContainerItemInstanceId;
        /// <summary>
        /// ItemInstanceId of the key that will be consumed by unlocking this container.  If the container requires a key, this parameter is required.
        /// </summary>
        public string KeyItemInstanceId;
        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses catalog associated with the item instance.
        /// </summary>
        public string CatalogVersion;
    }

    [Serializable]
    public class UnlockContainerItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog ItemId of the container type to unlock.
        /// </summary>
        public string ContainerItemId;
        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
    }

    [Serializable]
    public class UnlockContainerItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique instance identifier of the container unlocked.
        /// </summary>
        public string UnlockedItemInstanceId;
        /// <summary>
        /// Unique instance identifier of the key used to unlock the container, if applicable.
        /// </summary>
        public string UnlockedWithItemInstanceId;
        /// <summary>
        /// Items granted to the player as a result of unlocking the container.
        /// </summary>
        public List<ItemInstance> GrantedItems;
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

    [Serializable]
    public class UpdateCharacterDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
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
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    [Serializable]
    public class UpdateCharacterStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Statistics to be updated with the provided values.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics;
    }

    [Serializable]
    public class UpdateCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdatePlayerStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Statistics to be updated with the provided values
        /// </summary>
        public List<StatisticUpdate> Statistics;
    }

    [Serializable]
    public class UpdatePlayerStatisticsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateSharedGroupDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
        /// <summary>
        /// Permission to be applied to all user data keys in this request.
        /// </summary>
        public UserDataPermission? Permission;
    }

    [Serializable]
    public class UpdateSharedGroupDataResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateUserDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set. This is used for requests by one player for information about another player; those requests will only return Public keys.
        /// </summary>
        public UserDataPermission? Permission;
    }

    [Serializable]
    public class UpdateUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    [Serializable]
    public class UpdateUserTitleDisplayNameRequest : PlayFabRequestCommon
    {
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
    public class UserAccountInfo
    {
        /// <summary>
        /// Unique identifier for the user account
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Timestamp indicating when the user account was created
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// User account name in the PlayFab service
        /// </summary>
        public string Username;
        /// <summary>
        /// Title-specific information for the user account
        /// </summary>
        public UserTitleInfo TitleInfo;
        /// <summary>
        /// Personal information for the user which is considered more sensitive
        /// </summary>
        public UserPrivateAccountInfo PrivateInfo;
        /// <summary>
        /// User Facebook information, if a Facebook account has been linked
        /// </summary>
        public UserFacebookInfo FacebookInfo;
        /// <summary>
        /// User Steam information, if a Steam account has been linked
        /// </summary>
        public UserSteamInfo SteamInfo;
        /// <summary>
        /// User Gamecenter information, if a Gamecenter account has been linked
        /// </summary>
        public UserGameCenterInfo GameCenterInfo;
        /// <summary>
        /// User iOS device information, if an iOS device has been linked
        /// </summary>
        public UserIosDeviceInfo IosDeviceInfo;
        /// <summary>
        /// User Android device information, if an Android device has been linked
        /// </summary>
        public UserAndroidDeviceInfo AndroidDeviceInfo;
        /// <summary>
        /// User Kongregate account information, if a Kongregate account has been linked
        /// </summary>
        public UserKongregateInfo KongregateInfo;
        /// <summary>
        /// User Twitch account information, if a Twitch account has been linked
        /// </summary>
        public UserTwitchInfo TwitchInfo;
        /// <summary>
        /// User PSN account information, if a PSN account has been linked
        /// </summary>
        public UserPsnInfo PsnInfo;
        /// <summary>
        /// User Google account information, if a Google account has been linked
        /// </summary>
        public UserGoogleInfo GoogleInfo;
        /// <summary>
        /// User XBox account information, if a XBox account has been linked
        /// </summary>
        public UserXboxInfo XboxInfo;
        /// <summary>
        /// Custom ID information, if a custom ID has been assigned
        /// </summary>
        public UserCustomIdInfo CustomIdInfo;
    }

    [Serializable]
    public class UserAndroidDeviceInfo
    {
        /// <summary>
        /// Android device ID
        /// </summary>
        public string AndroidDeviceId;
    }

    [Serializable]
    public class UserCustomIdInfo
    {
        /// <summary>
        /// Custom ID
        /// </summary>
        public string CustomId;
    }

    /// <summary>
    /// Indicates whether a given data key is private (readable only by the player) or public (readable by all players). When a player makes a GetUserData request about another player, only keys marked Public will be returned.
    /// </summary>
    public enum UserDataPermission
    {
        Private,
        Public
    }

    [Serializable]
    public class UserDataRecord
    {
        /// <summary>
        /// Data stored for the specified user data key.
        /// </summary>
        public string Value;
        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated;
        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only the user (private). This is used for GetUserData requests being made by one player about another player.
        /// </summary>
        public UserDataPermission? Permission;
    }

    [Serializable]
    public class UserFacebookInfo
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
    public class UserGameCenterInfo
    {
        /// <summary>
        /// Gamecenter identifier
        /// </summary>
        public string GameCenterId;
    }

    [Serializable]
    public class UserGoogleInfo
    {
        /// <summary>
        /// Google ID
        /// </summary>
        public string GoogleId;
        /// <summary>
        /// Email address of the Google account
        /// </summary>
        public string GoogleEmail;
        /// <summary>
        /// Locale of the Google account
        /// </summary>
        public string GoogleLocale;
        /// <summary>
        /// Gender information of the Google account
        /// </summary>
        public string GoogleGender;
    }

    [Serializable]
    public class UserIosDeviceInfo
    {
        /// <summary>
        /// iOS device ID
        /// </summary>
        public string IosDeviceId;
    }

    [Serializable]
    public class UserKongregateInfo
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
        WindowsHello
    }

    [Serializable]
    public class UserPrivateAccountInfo
    {
        /// <summary>
        /// user email address
        /// </summary>
        public string Email;
    }

    [Serializable]
    public class UserPsnInfo
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
    public class UserSettings
    {
        /// <summary>
        /// Boolean for whether this player is eligible for ad tracking.
        /// </summary>
        public bool NeedsAttribution;
    }

    [Serializable]
    public class UserSteamInfo
    {
        /// <summary>
        /// Steam identifier
        /// </summary>
        public string SteamId;
        /// <summary>
        /// the country in which the player resides, from Steam data
        /// </summary>
        public string SteamCountry;
        /// <summary>
        /// currency type set in the user Steam account
        /// </summary>
        public Currency? SteamCurrency;
        /// <summary>
        /// what stage of game ownership the user is listed as being in, from Steam
        /// </summary>
        public TitleActivationStatus? SteamActivationStatus;
    }

    [Serializable]
    public class UserTitleInfo
    {
        /// <summary>
        /// name of the user, as it is displayed in-game
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// source by which the user first joined the game, if known
        /// </summary>
        public UserOrigination? Origination;
        /// <summary>
        /// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
        /// </summary>
        public DateTime Created;
        /// <summary>
        /// timestamp for the last user login for this title
        /// </summary>
        public DateTime? LastLogin;
        /// <summary>
        /// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
        /// </summary>
        public DateTime? FirstLogin;
        /// <summary>
        /// boolean indicating whether or not the user is currently banned for a title
        /// </summary>
        public bool? isBanned;
        /// <summary>
        /// URL to the player's avatar.
        /// </summary>
        public string AvatarUrl;
    }

    [Serializable]
    public class UserTwitchInfo
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
    public class UserXboxInfo
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
        /// ReceiptId returned by the Amazon App Store in-app purchase API
        /// </summary>
        public string ReceiptId;
        /// <summary>
        /// AmazonId of the user making the purchase as returned by the Amazon App Store in-app purchase API
        /// </summary>
        public string UserId;
        /// <summary>
        /// Catalog version to use when granting receipt item. If null, defaults to primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Currency used for the purchase.
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// Amount of the stated currency paid for the object.
        /// </summary>
        public int PurchasePrice;
    }

    [Serializable]
    public class ValidateAmazonReceiptResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ValidateGooglePlayPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Original JSON string returned by the Google Play IAB API.
        /// </summary>
        public string ReceiptJson;
        /// <summary>
        /// Signature returned by the Google Play IAB API.
        /// </summary>
        public string Signature;
        /// <summary>
        /// Currency used for the purchase.
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// Amount of the stated currency paid for the object.
        /// </summary>
        public uint? PurchasePrice;
    }

    [Serializable]
    public class ValidateGooglePlayPurchaseResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ValidateIOSReceiptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Base64 encoded receipt data, passed back by the App Store as a result of a successful purchase.
        /// </summary>
        public string ReceiptData;
        /// <summary>
        /// Currency used for the purchase.
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// Amount of the stated currency paid for the object.
        /// </summary>
        public int PurchasePrice;
    }

    [Serializable]
    public class ValidateIOSReceiptResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ValidateWindowsReceiptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// XML Receipt returned by the Windows App Store in-app purchase API
        /// </summary>
        public string Receipt;
        /// <summary>
        /// Catalog version to use when granting receipt item. If null, defaults to primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Currency used for the purchase.
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// Amount of the stated currency paid for the object.
        /// </summary>
        public uint PurchasePrice;
    }

    [Serializable]
    public class ValidateWindowsReceiptResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ValueToDateModel
    {
        /// <summary>
        /// ISO 4217 code of the currency used in the purchases
        /// </summary>
        public string Currency;
        /// <summary>
        /// Total value of the purchases in a whole number of 1/100 monetary units. For example, 999 indicates nine dollars and ninety-nine cents when Currency is 'USD')
        /// </summary>
        public uint TotalValue;
        /// <summary>
        /// Total value of the purchases in a string representation of decimal monetary units. For example, '9.99' indicates nine dollars and ninety-nine cents when Currency is 'USD'.
        /// </summary>
        public string TotalValueAsDecimal;
    }

    [Serializable]
    public class VirtualCurrencyBalanceModel
    {
        /// <summary>
        /// Name of the virtual currency
        /// </summary>
        public string Currency;
        /// <summary>
        /// Balance of the virtual currency
        /// </summary>
        public int TotalValue;
    }

    [Serializable]
    public class VirtualCurrencyRechargeTime
    {
        /// <summary>
        /// Time remaining (in seconds) before the next recharge increment of the virtual currency.
        /// </summary>
        public int SecondsToRecharge;
        /// <summary>
        /// Server timestamp in UTC indicating the next time the virtual currency will be incremented.
        /// </summary>
        public DateTime RechargeTime;
        /// <summary>
        /// Maximum value to which the regenerating currency will automatically increment. Note that it can exceed this value through use of the AddUserVirtualCurrency API call. However, it will not regenerate automatically until it has fallen below this value.
        /// </summary>
        public int RechargeMax;
    }

    [Serializable]
    public class WriteClientCharacterEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;
        /// <summary>
        /// The time (in UTC) associated with this event. The value dafaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
        /// <summary>
        /// Custom event properties. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;
    }

    [Serializable]
    public class WriteClientPlayerEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;
        /// <summary>
        /// The time (in UTC) associated with this event. The value dafaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
        /// <summary>
        /// Custom data properties associated with the event. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;
    }

    [Serializable]
    public class WriteEventResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The unique identifier of the event. The values of this identifier consist of ASCII characters and are not constrained to any particular format.
        /// </summary>
        public string EventId;
    }

    [Serializable]
    public class WriteTitleEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The name of the event, within the namespace scoped to the title. The naming convention is up to the caller, but it commonly follows the subject_verb_object pattern (e.g. player_logged_in).
        /// </summary>
        public string EventName;
        /// <summary>
        /// The time (in UTC) associated with this event. The value dafaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
        /// <summary>
        /// Custom event properties. Each property consists of a name (string) and a value (JSON object).
        /// </summary>
        public Dictionary<string,object> Body;
    }
}
#endif
