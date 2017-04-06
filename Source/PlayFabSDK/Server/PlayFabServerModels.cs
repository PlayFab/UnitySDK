#if ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ServerModels
{
    [Serializable]
    public class ActionsOnPlayersInSegmentTaskSummary
    {
        /// <summary>
        /// ID of the task instance.
        /// </summary>
        public string TaskInstanceId;
        /// <summary>
        /// Identifier of the task this instance belongs to.
        /// </summary>
        public NameIdentifier TaskIdentifier;
        /// <summary>
        /// UTC timestamp when the task started.
        /// </summary>
        public DateTime StartedAt;
        /// <summary>
        /// UTC timestamp when the task completed.
        /// </summary>
        public DateTime? CompletedAt;
        /// <summary>
        /// Current status of the task instance.
        /// </summary>
        public TaskInstanceStatus? Status;
        /// <summary>
        /// Progress represented as percentage.
        /// </summary>
        public double? PercentComplete;
        /// <summary>
        /// Estimated time remaining in seconds.
        /// </summary>
        public double? EstimatedSecondsRemaining;
        /// <summary>
        /// If manually scheduled, ID of user who scheduled the task.
        /// </summary>
        public string ScheduledByUserId;
        /// <summary>
        /// Error message for last processing attempt, if an error occured.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// Flag indicating if the error was fatal, if false job will be retried.
        /// </summary>
        public bool? ErrorWasFatal;
        /// <summary>
        /// Total players in segment when task was started.
        /// </summary>
        public int? TotalPlayersInSegment;
        /// <summary>
        /// Total number of players that have had the actions applied to.
        /// </summary>
        public int? TotalPlayersProcessed;
    }

    [Serializable]
    public class AdCampaignAttribution
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
    public class AddCharacterVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be incremented.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;
        /// <summary>
        /// Amount to be added to the character balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount;
    }

    [Serializable]
    public class AddFriendRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab identifier of the player to add a new friend.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The PlayFab identifier of the user being added.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// The PlayFab username of the user being added
        /// </summary>
        public string FriendUsername;
        /// <summary>
        /// Email address of the user being added.
        /// </summary>
        public string FriendEmail;
        /// <summary>
        /// Title-specific display name of the user to being added.
        /// </summary>
        public string FriendTitleDisplayName;
    }

    [Serializable]
    public class AddPlayerTagRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;
    }

    [Serializable]
    public class AddPlayerTagResult : PlayFabResultCommon
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
    public class AddUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be increased.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;
        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount;
    }

    [Serializable]
    public class AuthenticateSessionTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Session ticket as issued by a PlayFab client login API.
        /// </summary>
        public string SessionTicket;
    }

    [Serializable]
    public class AuthenticateSessionTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// Account info for the user whose session ticket was supplied.
        /// </summary>
        public UserAccountInfo UserInfo;
    }

    [Serializable]
    public class AwardSteamAchievementItem
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique Steam achievement name.
        /// </summary>
        public string AchievementName;
        /// <summary>
        /// Result of the award attempt (only valid on response, not on request).
        /// </summary>
        public bool Result;
    }

    [Serializable]
    public class AwardSteamAchievementRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of achievements to grant and the users to whom they are to be granted.
        /// </summary>
        public List<AwardSteamAchievementItem> Achievements;
    }

    [Serializable]
    public class AwardSteamAchievementResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of achievements granted.
        /// </summary>
        public List<AwardSteamAchievementItem> AchievementResults;
    }

    /// <summary>
    /// Contains information for a ban.
    /// </summary>
    [Serializable]
    public class BanInfo
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The unique Ban Id associated with this ban.
        /// </summary>
        public string BanId;
        /// <summary>
        /// The IP address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string IPAddress;
        /// <summary>
        /// The MAC address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string MACAddress;
        /// <summary>
        /// The time when this ban was applied.
        /// </summary>
        public DateTime? Created;
        /// <summary>
        /// The time when this ban expires. Permanent bans do not have expiration date.
        /// </summary>
        public DateTime? Expires;
        /// <summary>
        /// The reason why this ban was applied.
        /// </summary>
        public string Reason;
        /// <summary>
        /// The active state of this ban. Expired bans may still have this value set to true but they will have no effect.
        /// </summary>
        public bool Active;
    }

    /// <summary>
    /// Represents a single ban request.
    /// </summary>
    [Serializable]
    public class BanRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// IP address to be banned. May affect multiple players.
        /// </summary>
        public string IPAddress;
        /// <summary>
        /// MAC address to be banned. May affect multiple players.
        /// </summary>
        public string MACAddress;
        /// <summary>
        /// The reason for this ban. Maximum 140 characters.
        /// </summary>
        public string Reason;
        /// <summary>
        /// The duration in hours for the ban. Leave this blank for a permanent ban.
        /// </summary>
        public uint? DurationInHours;
    }

    [Serializable]
    public class BanUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of ban requests to be applied. Maximum 100.
        /// </summary>
        public List<BanRequest> Bans;
    }

    [Serializable]
    public class BanUsersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were applied
        /// </summary>
        public List<BanInfo> BanData;
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

    [Serializable]
    public class ConsumeItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class DeleteCharacterFromUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// If true, the character's inventory will be transferred up to the owning user; otherwise, this request will purge those items.
        /// </summary>
        public bool SaveCharacterInventory;
    }

    [Serializable]
    public class DeleteCharacterFromUserResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteSharedGroupRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId;
    }

    [Serializable]
    public class DeleteUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
    }

    [Serializable]
    public class DeleteUsersResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeregisterGameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the Game Server Instance that is being deregistered.
        /// </summary>
        public string LobbyId;
    }

    [Serializable]
    public class DeregisterGameResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class EmptyResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class EvaluateRandomResultTableRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The unique identifier of the Random Result Table to use.
        /// </summary>
        public string TableId;
        /// <summary>
        /// Specifies the catalog version that should be used to evaluate the Random Result Table.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion;
    }

    [Serializable]
    public class EvaluateRandomResultTableResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for the item returned from the Random Result Table evaluation, for the given catalog.
        /// </summary>
        public string ResultItemId;
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
        /// Entries logged during the function execution. These include both entries logged in the function code using log.info() and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public List<LogStatement> Logs;
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
        /// Information about the error, if any, that occured during execution
        /// </summary>
        public ScriptExecutionError Error;
    }

    [Serializable]
    public class ExecuteCloudScriptServerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The unique user identifier for the player on whose behalf the script is being run
        /// </summary>
        public string PlayFabId;
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

    public enum GameInstanceState
    {
        Open,
        Closed
    }

    [Serializable]
    public class GetActionGroupResult : PlayFabResultCommon
    {
        /// <summary>
        /// Action Group name
        /// </summary>
        public string Name;
        /// <summary>
        /// Action Group ID
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class GetAllActionGroupsRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetAllActionGroupsResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of Action Groups.
        /// </summary>
        public List<GetActionGroupResult> ActionGroups;
    }

    [Serializable]
    public class GetAllSegmentsRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetAllSegmentsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of segments for this title.
        /// </summary>
        public List<GetSegmentResult> Segments;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
    }

    [Serializable]
    public class GetCharacterInventoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
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
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
    }

    [Serializable]
    public class GetCharacterStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose character statistics are being returned.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique identifier of the character for the statistics.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Character statistics for the requested user.
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
    public class GetFriendLeaderboardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The player whose friend leaderboard to get
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Statistic used to rank friends for this leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Position in the leaderboard to start this listing (defaults to the first entry).
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends;
        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends;
        /// <summary>
        /// The version of the leaderboard to get, when UseSpecificVersion is true.
        /// </summary>
        public int? Version;
        /// <summary>
        /// If true, uses the specified version. If false, gets the most recent version.
        /// </summary>
        public bool? UseSpecificVersion;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. On client, only ShowDisplayName, ShowStatistics, ShowAvatarUrl are allowed.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
    }

    [Serializable]
    public class GetFriendsListRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab identifier of the player whose friend list to get.
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
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
    public class GetLeaderboardAroundUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. On client, only ShowDisplayName, ShowStatistics, ShowAvatarUrl are allowed.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// The version of the leaderboard to get, when UseSpecificVersion is true.
        /// </summary>
        public int? Version;
        /// <summary>
        /// If true, uses the specified version. If false, gets the most recent version.
        /// </summary>
        public bool? UseSpecificVersion;
    }

    [Serializable]
    public class GetLeaderboardAroundUserResult : PlayFabResultCommon
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
        /// <summary>
        /// If non-null, this determines which properties of the profile to return. If null, playfab will only include display names. On client, only ShowDisplayName, ShowStatistics, ShowAvatarUrl are allowed.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// The version of the leaderboard to get, when UseSpecificVersion is true.
        /// </summary>
        public int? Version;
        /// <summary>
        /// If true, uses the specified version. If false, gets the most recent version.
        /// </summary>
        public bool? UseSpecificVersion;
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
    public class GetPlayerCombinedInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFabId of the user whose data will be returned
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
    public class GetPlayersInSegmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string SegmentId;
        /// <summary>
        /// Number of seconds to keep the continuation token active. After token expiration it is not possible to continue paging results. Default is 300 (5 minutes). Maximum is 1,800 (30 minutes).
        /// </summary>
        public uint? SecondsToLive;
        /// <summary>
        /// Maximum number of profiles to load. Default is 1,000. Maximum is 10,000.
        /// </summary>
        public uint? MaxBatchSize;
        /// <summary>
        /// Continuation token if retrieving subsequent pages of results.
        /// </summary>
        public string ContinuationToken;
    }

    [Serializable]
    public class GetPlayersInSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Count of profiles matching this segment.
        /// </summary>
        public int ProfilesInSegment;
        /// <summary>
        /// Continuation token to use to retrieve subsequent pages of results. If token returns null there are no more results.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Array of player profiles in this segment.
        /// </summary>
        public List<PlayerProfile> PlayerProfiles;
    }

    [Serializable]
    public class GetPlayersSegmentsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetPlayerStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// user for whom statistics are being requested
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// statistics to return
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
        /// PlayFab unique identifier of the user whose statistics are being returned
        /// </summary>
        public string PlayFabId;
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
    public class GetRandomResultTablesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specifies the catalog version that should be used to retrieve the Random Result Tables.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The unique identifier of the Random Result Table to use.
        /// </summary>
        public List<string> TableIDs;
    }

    [Serializable]
    public class GetRandomResultTablesResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of random result tables currently available
        /// </summary>
        public Dictionary<string,RandomResultTableListing> Tables;
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
    public class GetUserAccountInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetUserAccountInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// Account details for the user whose information was requested.
        /// </summary>
        public UserAccountInfo UserInfo;
    }

    [Serializable]
    public class GetUserBansRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetUserBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information about the bans
        /// </summary>
        public List<BanInfo> BanData;
    }

    [Serializable]
    public class GetUserDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class GetUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose custom data is being returned.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data;
    }

    [Serializable]
    public class GetUserInventoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetUserInventoryResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class GrantCharacterToUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Non-unique display name of the character being granted.
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// Type of the character being granted; statistics can be sliced based on this value.
        /// </summary>
        public string CharacterType;
    }

    [Serializable]
    public class GrantCharacterToUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier tagged to this character.
        /// </summary>
        public string CharacterId;
    }

    /// <summary>
    /// Result of granting an item to a user
    /// </summary>
    [Serializable]
    public class GrantedItemInstance
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Result of this operation.
        /// </summary>
        public bool Result;
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
    public class GrantItemsToCharacterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds;
    }

    [Serializable]
    public class GrantItemsToCharacterResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;
    }

    [Serializable]
    public class GrantItemsToUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds;
    }

    [Serializable]
    public class GrantItemsToUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;
    }

    [Serializable]
    public class GrantItemsToUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Array of items to grant and the users to whom the items are to be granted.
        /// </summary>
        public List<ItemGrant> ItemGrants;
    }

    [Serializable]
    public class GrantItemsToUsersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;
    }

    [Serializable]
    public class ItemGrant
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique identifier of the catalog item to be granted to the user.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
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
    public class ModifyCharacterVirtualCurrencyResult : PlayFabResultCommon
    {
        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency;
        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance;
    }

    [Serializable]
    public class ModifyItemUsesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose item is being modified.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique instance identifier of the item to be modified.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Number of uses to add to the item. Can be negative to remove uses.
        /// </summary>
        public int UsesToAdd;
    }

    [Serializable]
    public class ModifyItemUsesResult : PlayFabResultCommon
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

    [Serializable]
    public class MoveItemToCharacterFromCharacterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique identifier of the character that currently has the item.
        /// </summary>
        public string GivingCharacterId;
        /// <summary>
        /// Unique identifier of the character that will be receiving the item.
        /// </summary>
        public string ReceivingCharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
    }

    [Serializable]
    public class MoveItemToCharacterFromCharacterResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class MoveItemToCharacterFromUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
    }

    [Serializable]
    public class MoveItemToCharacterFromUserResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class MoveItemToUserFromCharacterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
    }

    [Serializable]
    public class MoveItemToUserFromCharacterResult : PlayFabResultCommon
    {
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
    public class NotifyMatchmakerPlayerLeftRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the Game Instance the user is leaving.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class NotifyMatchmakerPlayerLeftResult : PlayFabResultCommon
    {
        /// <summary>
        /// State of user leaving the Game Server Instance.
        /// </summary>
        public PlayerConnectionState? PlayerState;
    }

    public enum PlayerConnectionState
    {
        Unassigned,
        Connecting,
        Participating,
        Participated
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
    public class PlayerLinkedAccount
    {
        /// <summary>
        /// Authentication platform
        /// </summary>
        public LoginIdentityProvider? Platform;
        /// <summary>
        /// Platform user identifier
        /// </summary>
        public string PlatformUserId;
        /// <summary>
        /// Linked account's username
        /// </summary>
        public string Username;
        /// <summary>
        /// Linked account's email
        /// </summary>
        public string Email;
    }

    [Serializable]
    public class PlayerLocation
    {
        /// <summary>
        /// The two-character continent code for this location
        /// </summary>
        public ContinentCode ContinentCode;
        /// <summary>
        /// The two-character ISO 3166-1 country code for the country associated with the location
        /// </summary>
        public CountryCode CountryCode;
        /// <summary>
        /// City of the player's geographic location.
        /// </summary>
        public string City;
        /// <summary>
        /// Latitude coordinate of the player's geographic location.
        /// </summary>
        public double? Latitude;
        /// <summary>
        /// Longitude coordinate of the player's geographic location.
        /// </summary>
        public double? Longitude;
    }

    [Serializable]
    public class PlayerProfile
    {
        /// <summary>
        /// PlayFab Player ID
        /// </summary>
        public string PlayerId;
        /// <summary>
        /// Title ID this profile applies to
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Player Display Name
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId;
        /// <summary>
        /// Player account origination
        /// </summary>
        public LoginIdentityProvider? Origination;
        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created;
        /// <summary>
        /// Last login
        /// </summary>
        public DateTime? LastLogin;
        /// <summary>
        /// Banned until UTC Date. If permanent ban this is set for 20 years after the original ban date.
        /// </summary>
        public DateTime? BannedUntil;
        /// <summary>
        /// Image URL of the player's avatar.
        /// </summary>
        public string AvatarUrl;
        /// <summary>
        /// Dictionary of player's statistics using only the latest version's value
        /// </summary>
        public Dictionary<string,int> Statistics;
        /// <summary>
        /// A sum of player's total purchases in USD across all currencies.
        /// </summary>
        public uint? TotalValueToDateInUSD;
        /// <summary>
        /// Dictionary of player's total purchases by currency.
        /// </summary>
        public Dictionary<string,uint> ValuesToDate;
        /// <summary>
        /// List of player's tags for segmentation.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// Dictionary of player's locations by type.
        /// </summary>
        public Dictionary<string,PlayerLocation> Locations;
        /// <summary>
        /// Dictionary of player's virtual currency balances
        /// </summary>
        public Dictionary<string,int> VirtualCurrencyBalances;
        /// <summary>
        /// Array of ad campaigns player has been attributed to
        /// </summary>
        public List<AdCampaignAttribution> AdCampaignAttributions;
        /// <summary>
        /// Array of configured push notification end points
        /// </summary>
        public List<PushNotificationRegistration> PushNotificationRegistrations;
        /// <summary>
        /// Array of third party accounts linked to this player
        /// </summary>
        public List<PlayerLinkedAccount> LinkedAccounts;
        /// <summary>
        /// Array of player statistics
        /// </summary>
        public List<PlayerStatistic> PlayerStatistics;
    }

    [Serializable]
    public class PlayerProfileModel
    {
        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId;
        /// <summary>
        /// Title ID this profile applies to
        /// </summary>
        public string TitleId;
        /// <summary>
        /// PlayFab Player ID
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
        /// Last login
        /// </summary>
        public DateTime? LastLogin;
        /// <summary>
        /// If the player is currently banned, the UTC Date when the ban expires
        /// </summary>
        public DateTime? BannedUntil;
        /// <summary>
        /// List of geographic locations where the player has logged-in
        /// </summary>
        public List<LocationModel> Locations;
        /// <summary>
        /// Player Display Name
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Image URL of the player's avatar
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
        /// List of third party accounts linked to this player
        /// </summary>
        public List<LinkedPlatformAccountModel> LinkedAccounts;
        /// <summary>
        /// List of advertising campaigns the player has been attributed to
        /// </summary>
        public List<AdCampaignAttributionModel> AdCampaignAttributions;
        /// <summary>
        /// A sum of player's total purchases across all real-money currencies, converted to US Dollars equivalent
        /// </summary>
        public uint? TotalValueToDateInUSD;
        /// <summary>
        /// List of player's total lifetime real-money purchases by currency
        /// </summary>
        public List<ValueToDateModel> ValuesToDate;
        /// <summary>
        /// List of player's virtual currency balances
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
        /// Whether to show statistics, the most recent version of each stat. Defaults to false
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
    public class PlayerStatistic
    {
        /// <summary>
        /// Statistic ID
        /// </summary>
        public string Id;
        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int StatisticVersion;
        /// <summary>
        /// Current statistic value
        /// </summary>
        public int StatisticValue;
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name;
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

    public enum PushNotificationPlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    [Serializable]
    public class PushNotificationRegistration
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
    public class RandomResultTableListing
    {
        /// <summary>
        /// Catalog version this table is associated with
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique name for this drop table
        /// </summary>
        public string TableId;
        /// <summary>
        /// Child nodes that indicate what kind of drop table item this actually is.
        /// </summary>
        public List<ResultTableNode> Nodes;
    }

    [Serializable]
    public class RedeemCouponRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Generated coupon code to redeem.
        /// </summary>
        public string CouponCode;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Catalog version of the coupon.
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

    [Serializable]
    public class RedeemMatchmakerTicketRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Server authorization ticket passed back from a call to Matchmake or StartGame.
        /// </summary>
        public string Ticket;
        /// <summary>
        /// Unique identifier of the Game Server Instance that is asking for validation of the authorization ticket.
        /// </summary>
        public string LobbyId;
    }

    [Serializable]
    public class RedeemMatchmakerTicketResult : PlayFabResultCommon
    {
        /// <summary>
        /// Boolean indicating whether the ticket was validated by the PlayFab service.
        /// </summary>
        public bool TicketIsValid;
        /// <summary>
        /// Error value if the ticket was not validated.
        /// </summary>
        public string Error;
        /// <summary>
        /// User account information for the user validated.
        /// </summary>
        public UserAccountInfo UserInfo;
    }

    [Serializable]
    public class RefreshGameServerInstanceHeartbeatRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the Game Server Instance for which the heartbeat is updated.
        /// </summary>
        public string LobbyId;
    }

    [Serializable]
    public class RefreshGameServerInstanceHeartbeatResult : PlayFabResultCommon
    {
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
    public class RegisterGameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// IP address of the Game Server Instance.
        /// </summary>
        public string ServerHost;
        /// <summary>
        /// Port number for communication with the Game Server Instance.
        /// </summary>
        public string ServerPort;
        /// <summary>
        /// Unique identifier of the build running on the Game Server Instance.
        /// </summary>
        public string Build;
        /// <summary>
        /// Region in which the Game Server Instance is running. For matchmaking using non-AWS region names, set this to any AWS region and use Tags (below) to specify your custom region.
        /// </summary>
        public Region Region;
        /// <summary>
        /// Game Mode the Game Server instance is running. Note that this must be defined in the Game Modes tab in the PlayFab Game Manager, along with the Build ID (the same Game Mode can be defined for multiple Build IDs).
        /// </summary>
        public string GameMode;
        /// <summary>
        /// Tags for the Game Server Instance
        /// </summary>
        public Dictionary<string,string> Tags;
    }

    [Serializable]
    public class RegisterGameResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier generated for the Game Server Instance that is registered.
        /// </summary>
        public string LobbyId;
    }

    [Serializable]
    public class RemoveFriendRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab identifier of the friend account which is to be removed.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class RemovePlayerTagRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;
    }

    [Serializable]
    public class RemovePlayerTagResult : PlayFabResultCommon
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
    public class ReportPlayerServerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFabId of the reporting player.
        /// </summary>
        public string ReporterId;
        /// <summary>
        /// PlayFabId of the reported player.
        /// </summary>
        public string ReporteeId;
        /// <summary>
        /// Title player was reported in, optional if report not for specific title.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// Optional additional comment by reporting player.
        /// </summary>
        public string Comment;
    }

    [Serializable]
    public class ReportPlayerServerResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates whether this action completed successfully.
        /// </summary>
        public bool Updated;
        /// <summary>
        /// The number of remaining reports which may be filed today by this reporting player.
        /// </summary>
        public int SubmissionsRemaining;
    }

    [Serializable]
    public class ResultTableNode
    {
        /// <summary>
        /// Whether this entry in the table is an item or a link to another table
        /// </summary>
        public ResultTableNodeType ResultItemType;
        /// <summary>
        /// Either an ItemId, or the TableId of another random result table
        /// </summary>
        public string ResultItem;
        /// <summary>
        /// How likely this is to be rolled - larger numbers add more weight
        /// </summary>
        public int Weight;
    }

    public enum ResultTableNodeType
    {
        ItemId,
        TableId
    }

    [Serializable]
    public class RevokeAllBansForUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class RevokeAllBansForUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were revoked.
        /// </summary>
        public List<BanInfo> BanData;
    }

    [Serializable]
    public class RevokeBansRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Ids of the bans to be revoked. Maximum 100.
        /// </summary>
        public List<string> BanIds;
    }

    [Serializable]
    public class RevokeBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were revoked
        /// </summary>
        public List<BanInfo> BanData;
    }

    [Serializable]
    public class RevokeInventoryItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
    }

    [Serializable]
    public class RevokeInventoryResult : PlayFabResultCommon
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
    public class SendPushNotificationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFabId of the recipient of the push notification.
        /// </summary>
        public string Recipient;
        /// <summary>
        /// Text of message to send.
        /// </summary>
        public string Message;
        /// <summary>
        /// Subject of message to send (may not be displayed in all platforms.
        /// </summary>
        public string Subject;
    }

    [Serializable]
    public class SendPushNotificationResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SetFriendTagsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab identifier of the player whose friend is to be updated.
        /// </summary>
        public string PlayFabId;
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
    public class SetGameServerInstanceDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the Game Instance to be updated, in decimal format.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// Custom data to set for the specified game server instance.
        /// </summary>
        public string GameServerData;
    }

    [Serializable]
    public class SetGameServerInstanceDataResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SetGameServerInstanceStateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the Game Instance to be updated, in decimal format.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// State to set for the specified game server instance.
        /// </summary>
        public GameInstanceState State;
    }

    [Serializable]
    public class SetGameServerInstanceStateResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SetGameServerInstanceTagsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the Game Server Instance to be updated.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// Tags to set for the specified Game Server Instance. Note that this is the complete list of tags to be associated with the Game Server Instance.
        /// </summary>
        public Dictionary<string,string> Tags;
    }

    [Serializable]
    public class SetGameServerInstanceTagsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SetPublisherDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key;
        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class SetPublisherDataResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SetTitleDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key;
        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class SetTitleDataResult : PlayFabResultCommon
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
        /// PlayFabId of the user to last update this value.
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

    [Serializable]
    public class SubtractCharacterVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
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
    public class SubtractUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be decreased.
        /// </summary>
        public string PlayFabId;
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

    public enum TaskInstanceStatus
    {
        Succeeded,
        Starting,
        InProgress,
        Failed,
        Aborted,
        Pending
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
    public class UnlockContainerInstanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Catalog ItemId of the container type to unlock.
        /// </summary>
        public string ContainerItemId;
        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// URL of the avatar image. If empty, it removes the existing avatar URL.
        /// </summary>
        public string ImageUrl;
    }

    /// <summary>
    /// Represents a single update ban request.
    /// </summary>
    [Serializable]
    public class UpdateBanRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The id of the ban to be updated.
        /// </summary>
        public string BanId;
        /// <summary>
        /// The updated reason for the ban to be updated. Maximum 140 characters. Null for no change.
        /// </summary>
        public string Reason;
        /// <summary>
        /// The updated expiration date for the ban. Null for no change.
        /// </summary>
        public DateTime? Expires;
        /// <summary>
        /// The updated IP address for the ban. Null for no change.
        /// </summary>
        public string IPAddress;
        /// <summary>
        /// The updated MAC address for the ban. Null for no change.
        /// </summary>
        public string MACAddress;
        /// <summary>
        /// Whether to make this ban permanent. Set to true to make this ban permanent. This will not modify Active state.
        /// </summary>
        public bool? Permanent;
        /// <summary>
        /// The updated active state for the ban. Null for no change.
        /// </summary>
        public bool? Active;
    }

    [Serializable]
    public class UpdateBansRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of bans to be updated. Maximum 100.
        /// </summary>
        public List<UpdateBanRequest> Bans;
    }

    [Serializable]
    public class UpdateBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were updated
        /// </summary>
        public List<BanInfo> BanData;
    }

    [Serializable]
    public class UpdateCharacterDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Statistics to be updated with the provided values
        /// </summary>
        public List<StatisticUpdate> Statistics;
        /// <summary>
        /// Indicates whether the statistics provided should be set, regardless of the aggregation method set on the statistic. Default is false.
        /// </summary>
        public bool? ForceUpdate;
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
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
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
    public class UpdateUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion;
    }

    [Serializable]
    public class UpdateUserInternalDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
    }

    [Serializable]
    public class UpdateUserInventoryItemDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
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
    public class ValueToDateModel
    {
        /// <summary>
        /// ISO 4217 code of the currency used in the purchases
        /// </summary>
        public string Currency;
        /// <summary>
        /// Total value of the purchases in a whole number of 1/100 monetary units. For example 999 indicates nine dollars and ninety-nine cents when Currency is 'USD')
        /// </summary>
        public uint TotalValue;
        /// <summary>
        /// Total value of the purchases in a string representation of decimal monetary units (e.g. '9.99' indicates nine dollars and ninety-nine cents when Currency is 'USD'))
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
    public class WriteEventResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The unique identifier of the event. The values of this identifier consist of ASCII characters and are not constrained to any particular format.
        /// </summary>
        public string EventId;
    }

    [Serializable]
    public class WriteServerCharacterEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class WriteServerPlayerEventRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
