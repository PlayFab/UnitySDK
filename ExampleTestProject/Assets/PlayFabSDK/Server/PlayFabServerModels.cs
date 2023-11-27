#if ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.ServerModels
{
    [Serializable]
    public class AdCampaignAttribution : PlayFabBaseModel
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
    public class AddCharacterVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Amount to be added to the character balance of the specified virtual currency. Maximum VC balance is Int32
        /// (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be incremented.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;
    }

    [Serializable]
    public class AddFriendRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Email address of the user being added.
        /// </summary>
        public string FriendEmail;
        /// <summary>
        /// The PlayFab identifier of the user being added.
        /// </summary>
        public string FriendPlayFabId;
        /// <summary>
        /// Title-specific display name of the user to being added.
        /// </summary>
        public string FriendTitleDisplayName;
        /// <summary>
        /// The PlayFab username of the user being added
        /// </summary>
        public string FriendUsername;
        /// <summary>
        /// PlayFab identifier of the player to add a new friend.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class AddGenericIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Generic service identifier to add to the player account.
        /// </summary>
        public GenericServiceId GenericId;
        /// <summary>
        /// PlayFabId of the user to link.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// This API will trigger a player_tag_added event and add a tag with the given TagName and PlayFabID to the corresponding
    /// player profile. TagName can be used for segmentation and it is limited to 256 characters. Also there is a limit on the
    /// number of tags a title can have.
    /// </summary>
    [Serializable]
    public class AddPlayerTagRequest : PlayFabRequestCommon
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
    public class AddUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647).
        /// Any increase over this value will be discarded.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be increased.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency;
    }

    [Serializable]
    public class AdvancedPushPlatformMsg : PlayFabBaseModel
    {
        /// <summary>
        /// Stops GoogleCloudMessaging notifications from including both notification and data properties and instead only sends the
        /// data property.
        /// </summary>
        public bool? GCMDataOnly;
        /// <summary>
        /// The Json the platform should receive.
        /// </summary>
        public string Json;
        /// <summary>
        /// The platform that should receive the Json.
        /// </summary>
        public PushNotificationPlatform Platform;
    }

    /// <summary>
    /// Note that data returned may be Personally Identifying Information (PII), such as email address, and so care should be
    /// taken in how this data is stored and managed. Since this call will always return the relevant information for users who
    /// have accessed the title, the recommendation is to not store this data locally.
    /// </summary>
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
        /// Indicates if token was expired at request time.
        /// </summary>
        public bool? IsSessionTicketExpired;
        /// <summary>
        /// Account info for the user whose session ticket was supplied.
        /// </summary>
        public UserAccountInfo UserInfo;
    }

    [Serializable]
    public class AwardSteamAchievementItem : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Steam achievement name.
        /// </summary>
        public string AchievementName;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class BanInfo : PlayFabBaseModel
    {
        /// <summary>
        /// The active state of this ban. Expired bans may still have this value set to true but they will have no effect.
        /// </summary>
        public bool Active;
        /// <summary>
        /// The unique Ban Id associated with this ban.
        /// </summary>
        public string BanId;
        /// <summary>
        /// The time when this ban was applied.
        /// </summary>
        public DateTime? Created;
        /// <summary>
        /// The time when this ban expires. Permanent bans do not have expiration date.
        /// </summary>
        public DateTime? Expires;
        /// <summary>
        /// The IP address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string IPAddress;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The reason why this ban was applied.
        /// </summary>
        public string Reason;
    }

    /// <summary>
    /// Represents a single ban request.
    /// </summary>
    [Serializable]
    public class BanRequest : PlayFabBaseModel
    {
        /// <summary>
        /// The duration in hours for the ban. Leave this blank for a permanent ban.
        /// </summary>
        public uint? DurationInHours;
        /// <summary>
        /// IP address to be banned. May affect multiple players.
        /// </summary>
        public string IPAddress;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The reason for this ban. Maximum 140 characters.
        /// </summary>
        public string Reason;
    }

    /// <summary>
    /// The existence of each user will not be verified. When banning by IP or MAC address, multiple players may be affected, so
    /// use this feature with caution. Returns information about the new bans.
    /// </summary>
    [Serializable]
    public class BanUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of ban requests to be applied. Maximum 100.
        /// </summary>
        public List<BanRequest> Bans;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
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

    public enum ChurnRiskLevel
    {
        NoData,
        LowRisk,
        MediumRisk,
        HighRisk
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class ContactEmailInfo : PlayFabBaseModel
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

    public enum ContinentCode
    {
        AF,
        AN,
        AS,
        EU,
        NA,
        OC,
        SA,
        Unknown
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
        ZW,
        Unknown
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

    /// <summary>
    /// This function will delete the specified character from the list allowed by the user, and will also delete any inventory
    /// or VC currently held by that character. It will NOT delete any statistics associated for this character, in order to
    /// preserve leaderboard integrity.
    /// </summary>
    [Serializable]
    public class DeleteCharacterFromUserRequest : PlayFabRequestCommon
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// If true, the character's inventory will be transferred up to the owning user; otherwise, this request will purge those
        /// items.
        /// </summary>
        public bool SaveCharacterInventory;
    }

    [Serializable]
    public class DeleteCharacterFromUserResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Deletes all data associated with the player, including statistics, custom data, inventory, purchases, virtual currency
    /// balances, characters and shared group memberships. Removes the player from all leaderboards and player search indexes.
    /// Does not delete PlayStream event history associated with the player. Does not delete the publisher user account that
    /// created the player in the title nor associated data such as username, password, email address, account linkages, or
    /// friends list. Note, this API queues the player for deletion and returns immediately. It may take several minutes or more
    /// before all player data is fully deleted. Until the player data is fully deleted, attempts to recreate the player with
    /// the same user account in the same title will fail with the 'AccountDeleted' error. This API must be enabled for use as
    /// an option in the game manager website. It is disabled by default.
    /// </summary>
    [Serializable]
    public class DeletePlayerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class DeletePlayerResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Represents the request to delete a push notification template.
    /// </summary>
    [Serializable]
    public class DeletePushNotificationTemplateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Id of the push notification template to be deleted.
        /// </summary>
        public string PushNotificationTemplateId;
    }

    [Serializable]
    public class DeletePushNotificationTemplateResult : PlayFabResultCommon
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
    public class EvaluateRandomResultTableRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specifies the catalog version that should be used to evaluate the Random Result Table. If unspecified, uses
        /// default/primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The unique identifier of the Random Result Table to use.
        /// </summary>
        public string TableId;
    }

    /// <summary>
    /// Note that if the Random Result Table contains no entries, or does not exist for the catalog specified (the Primary
    /// catalog if one is not specified), an InvalidDropTable error will be returned.
    /// </summary>
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
    public class ExecuteCloudScriptServerRequest : PlayFabRequestCommon
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
        /// The unique user identifier for the player on whose behalf the script is being run
        /// </summary>
        public string PlayFabId;
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

    public enum ExternalFriendSources
    {
        None,
        Steam,
        Facebook,
        Xbox,
        Psn,
        All
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
        /// Available PlayStation :tm: Network information, if the user and PlayFab friend are both connected to PlayStation :tm:
        /// Network.
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

    public enum GenericErrorCodes
    {
        Success,
        UnkownError,
        InvalidParams,
        AccountNotFound,
        AccountBanned,
        InvalidUsernameOrPassword,
        InvalidTitleId,
        InvalidEmailAddress,
        EmailAddressNotAvailable,
        InvalidUsername,
        InvalidPassword,
        UsernameNotAvailable,
        InvalidSteamTicket,
        AccountAlreadyLinked,
        LinkedAccountAlreadyClaimed,
        InvalidFacebookToken,
        AccountNotLinked,
        FailedByPaymentProvider,
        CouponCodeNotFound,
        InvalidContainerItem,
        ContainerNotOwned,
        KeyNotOwned,
        InvalidItemIdInTable,
        InvalidReceipt,
        ReceiptAlreadyUsed,
        ReceiptCancelled,
        GameNotFound,
        GameModeNotFound,
        InvalidGoogleToken,
        UserIsNotPartOfDeveloper,
        InvalidTitleForDeveloper,
        TitleNameConflicts,
        UserisNotValid,
        ValueAlreadyExists,
        BuildNotFound,
        PlayerNotInGame,
        InvalidTicket,
        InvalidDeveloper,
        InvalidOrderInfo,
        RegistrationIncomplete,
        InvalidPlatform,
        UnknownError,
        SteamApplicationNotOwned,
        WrongSteamAccount,
        TitleNotActivated,
        RegistrationSessionNotFound,
        NoSuchMod,
        FileNotFound,
        DuplicateEmail,
        ItemNotFound,
        ItemNotOwned,
        ItemNotRecycleable,
        ItemNotAffordable,
        InvalidVirtualCurrency,
        WrongVirtualCurrency,
        WrongPrice,
        NonPositiveValue,
        InvalidRegion,
        RegionAtCapacity,
        ServerFailedToStart,
        NameNotAvailable,
        InsufficientFunds,
        InvalidDeviceID,
        InvalidPushNotificationToken,
        NoRemainingUses,
        InvalidPaymentProvider,
        PurchaseInitializationFailure,
        DuplicateUsername,
        InvalidBuyerInfo,
        NoGameModeParamsSet,
        BodyTooLarge,
        ReservedWordInBody,
        InvalidTypeInBody,
        InvalidRequest,
        ReservedEventName,
        InvalidUserStatistics,
        NotAuthenticated,
        StreamAlreadyExists,
        ErrorCreatingStream,
        StreamNotFound,
        InvalidAccount,
        PurchaseDoesNotExist,
        InvalidPurchaseTransactionStatus,
        APINotEnabledForGameClientAccess,
        NoPushNotificationARNForTitle,
        BuildAlreadyExists,
        BuildPackageDoesNotExist,
        CustomAnalyticsEventsNotEnabledForTitle,
        InvalidSharedGroupId,
        NotAuthorized,
        MissingTitleGoogleProperties,
        InvalidItemProperties,
        InvalidPSNAuthCode,
        InvalidItemId,
        PushNotEnabledForAccount,
        PushServiceError,
        ReceiptDoesNotContainInAppItems,
        ReceiptContainsMultipleInAppItems,
        InvalidBundleID,
        JavascriptException,
        InvalidSessionTicket,
        UnableToConnectToDatabase,
        InternalServerError,
        InvalidReportDate,
        ReportNotAvailable,
        DatabaseThroughputExceeded,
        InvalidGameTicket,
        ExpiredGameTicket,
        GameTicketDoesNotMatchLobby,
        LinkedDeviceAlreadyClaimed,
        DeviceAlreadyLinked,
        DeviceNotLinked,
        PartialFailure,
        PublisherNotSet,
        ServiceUnavailable,
        VersionNotFound,
        RevisionNotFound,
        InvalidPublisherId,
        DownstreamServiceUnavailable,
        APINotIncludedInTitleUsageTier,
        DAULimitExceeded,
        APIRequestLimitExceeded,
        InvalidAPIEndpoint,
        BuildNotAvailable,
        ConcurrentEditError,
        ContentNotFound,
        CharacterNotFound,
        CloudScriptNotFound,
        ContentQuotaExceeded,
        InvalidCharacterStatistics,
        PhotonNotEnabledForTitle,
        PhotonApplicationNotFound,
        PhotonApplicationNotAssociatedWithTitle,
        InvalidEmailOrPassword,
        FacebookAPIError,
        InvalidContentType,
        KeyLengthExceeded,
        DataLengthExceeded,
        TooManyKeys,
        FreeTierCannotHaveVirtualCurrency,
        MissingAmazonSharedKey,
        AmazonValidationError,
        InvalidPSNIssuerId,
        PSNInaccessible,
        ExpiredAuthToken,
        FailedToGetEntitlements,
        FailedToConsumeEntitlement,
        TradeAcceptingUserNotAllowed,
        TradeInventoryItemIsAssignedToCharacter,
        TradeInventoryItemIsBundle,
        TradeStatusNotValidForCancelling,
        TradeStatusNotValidForAccepting,
        TradeDoesNotExist,
        TradeCancelled,
        TradeAlreadyFilled,
        TradeWaitForStatusTimeout,
        TradeInventoryItemExpired,
        TradeMissingOfferedAndAcceptedItems,
        TradeAcceptedItemIsBundle,
        TradeAcceptedItemIsStackable,
        TradeInventoryItemInvalidStatus,
        TradeAcceptedCatalogItemInvalid,
        TradeAllowedUsersInvalid,
        TradeInventoryItemDoesNotExist,
        TradeInventoryItemIsConsumed,
        TradeInventoryItemIsStackable,
        TradeAcceptedItemsMismatch,
        InvalidKongregateToken,
        FeatureNotConfiguredForTitle,
        NoMatchingCatalogItemForReceipt,
        InvalidCurrencyCode,
        NoRealMoneyPriceForCatalogItem,
        TradeInventoryItemIsNotTradable,
        TradeAcceptedCatalogItemIsNotTradable,
        UsersAlreadyFriends,
        LinkedIdentifierAlreadyClaimed,
        CustomIdNotLinked,
        TotalDataSizeExceeded,
        DeleteKeyConflict,
        InvalidXboxLiveToken,
        ExpiredXboxLiveToken,
        ResettableStatisticVersionRequired,
        NotAuthorizedByTitle,
        NoPartnerEnabled,
        InvalidPartnerResponse,
        APINotEnabledForGameServerAccess,
        StatisticNotFound,
        StatisticNameConflict,
        StatisticVersionClosedForWrites,
        StatisticVersionInvalid,
        APIClientRequestRateLimitExceeded,
        InvalidJSONContent,
        InvalidDropTable,
        StatisticVersionAlreadyIncrementedForScheduledInterval,
        StatisticCountLimitExceeded,
        StatisticVersionIncrementRateExceeded,
        ContainerKeyInvalid,
        CloudScriptExecutionTimeLimitExceeded,
        NoWritePermissionsForEvent,
        CloudScriptFunctionArgumentSizeExceeded,
        CloudScriptAPIRequestCountExceeded,
        CloudScriptAPIRequestError,
        CloudScriptHTTPRequestError,
        InsufficientGuildRole,
        GuildNotFound,
        OverLimit,
        EventNotFound,
        InvalidEventField,
        InvalidEventName,
        CatalogNotConfigured,
        OperationNotSupportedForPlatform,
        SegmentNotFound,
        StoreNotFound,
        InvalidStatisticName,
        TitleNotQualifiedForLimit,
        InvalidServiceLimitLevel,
        ServiceLimitLevelInTransition,
        CouponAlreadyRedeemed,
        GameServerBuildSizeLimitExceeded,
        GameServerBuildCountLimitExceeded,
        VirtualCurrencyCountLimitExceeded,
        VirtualCurrencyCodeExists,
        TitleNewsItemCountLimitExceeded,
        InvalidTwitchToken,
        TwitchResponseError,
        ProfaneDisplayName,
        UserAlreadyAdded,
        InvalidVirtualCurrencyCode,
        VirtualCurrencyCannotBeDeleted,
        IdentifierAlreadyClaimed,
        IdentifierNotLinked,
        InvalidContinuationToken,
        ExpiredContinuationToken,
        InvalidSegment,
        InvalidSessionId,
        SessionLogNotFound,
        InvalidSearchTerm,
        TwoFactorAuthenticationTokenRequired,
        GameServerHostCountLimitExceeded,
        PlayerTagCountLimitExceeded,
        RequestAlreadyRunning,
        ActionGroupNotFound,
        MaximumSegmentBulkActionJobsRunning,
        NoActionsOnPlayersInSegmentJob,
        DuplicateStatisticName,
        ScheduledTaskNameConflict,
        ScheduledTaskCreateConflict,
        InvalidScheduledTaskName,
        InvalidTaskSchedule,
        SteamNotEnabledForTitle,
        LimitNotAnUpgradeOption,
        NoSecretKeyEnabledForCloudScript,
        TaskNotFound,
        TaskInstanceNotFound,
        InvalidIdentityProviderId,
        MisconfiguredIdentityProvider,
        InvalidScheduledTaskType,
        BillingInformationRequired,
        LimitedEditionItemUnavailable,
        InvalidAdPlacementAndReward,
        AllAdPlacementViewsAlreadyConsumed,
        GoogleOAuthNotConfiguredForTitle,
        GoogleOAuthError,
        UserNotFriend,
        InvalidSignature,
        InvalidPublicKey,
        GoogleOAuthNoIdTokenIncludedInResponse,
        StatisticUpdateInProgress,
        LeaderboardVersionNotAvailable,
        StatisticAlreadyHasPrizeTable,
        PrizeTableHasOverlappingRanks,
        PrizeTableHasMissingRanks,
        PrizeTableRankStartsAtZero,
        InvalidStatistic,
        ExpressionParseFailure,
        ExpressionInvokeFailure,
        ExpressionTooLong,
        DataUpdateRateExceeded,
        RestrictedEmailDomain,
        EncryptionKeyDisabled,
        EncryptionKeyMissing,
        EncryptionKeyBroken,
        NoSharedSecretKeyConfigured,
        SecretKeyNotFound,
        PlayerSecretAlreadyConfigured,
        APIRequestsDisabledForTitle,
        InvalidSharedSecretKey,
        PrizeTableHasNoRanks,
        ProfileDoesNotExist,
        ContentS3OriginBucketNotConfigured,
        InvalidEnvironmentForReceipt,
        EncryptedRequestNotAllowed,
        SignedRequestNotAllowed,
        RequestViewConstraintParamsNotAllowed,
        BadPartnerConfiguration,
        XboxBPCertificateFailure,
        XboxXASSExchangeFailure,
        InvalidEntityId,
        StatisticValueAggregationOverflow,
        EmailMessageFromAddressIsMissing,
        EmailMessageToAddressIsMissing,
        SmtpServerAuthenticationError,
        SmtpServerLimitExceeded,
        SmtpServerInsufficientStorage,
        SmtpServerCommunicationError,
        SmtpServerGeneralFailure,
        EmailClientTimeout,
        EmailClientCanceledTask,
        EmailTemplateMissing,
        InvalidHostForTitleId,
        EmailConfirmationTokenDoesNotExist,
        EmailConfirmationTokenExpired,
        AccountDeleted,
        PlayerSecretNotConfigured,
        InvalidSignatureTime,
        NoContactEmailAddressFound,
        InvalidAuthToken,
        AuthTokenDoesNotExist,
        AuthTokenExpired,
        AuthTokenAlreadyUsedToResetPassword,
        MembershipNameTooLong,
        MembershipNotFound,
        GoogleServiceAccountInvalid,
        GoogleServiceAccountParseFailure,
        EntityTokenMissing,
        EntityTokenInvalid,
        EntityTokenExpired,
        EntityTokenRevoked,
        InvalidProductForSubscription,
        XboxInaccessible,
        SubscriptionAlreadyTaken,
        SmtpAddonNotEnabled,
        APIConcurrentRequestLimitExceeded,
        XboxRejectedXSTSExchangeRequest,
        VariableNotDefined,
        TemplateVersionNotDefined,
        FileTooLarge,
        TitleDeleted,
        TitleContainsUserAccounts,
        TitleDeletionPlayerCleanupFailure,
        EntityFileOperationPending,
        NoEntityFileOperationPending,
        EntityProfileVersionMismatch,
        TemplateVersionTooOld,
        MembershipDefinitionInUse,
        PaymentPageNotConfigured,
        FailedLoginAttemptRateLimitExceeded,
        EntityBlockedByGroup,
        RoleDoesNotExist,
        EntityIsAlreadyMember,
        DuplicateRoleId,
        GroupInvitationNotFound,
        GroupApplicationNotFound,
        OutstandingInvitationAcceptedInstead,
        OutstandingApplicationAcceptedInstead,
        RoleIsGroupDefaultMember,
        RoleIsGroupAdmin,
        RoleNameNotAvailable,
        GroupNameNotAvailable,
        EmailReportAlreadySent,
        EmailReportRecipientBlacklisted,
        EventNamespaceNotAllowed,
        EventEntityNotAllowed,
        InvalidEntityType,
        NullTokenResultFromAad,
        InvalidTokenResultFromAad,
        NoValidCertificateForAad,
        InvalidCertificateForAad,
        DuplicateDropTableId,
        MultiplayerServerError,
        MultiplayerServerTooManyRequests,
        MultiplayerServerNoContent,
        MultiplayerServerBadRequest,
        MultiplayerServerUnauthorized,
        MultiplayerServerForbidden,
        MultiplayerServerNotFound,
        MultiplayerServerConflict,
        MultiplayerServerInternalServerError,
        MultiplayerServerUnavailable,
        ExplicitContentDetected,
        PIIContentDetected,
        InvalidScheduledTaskParameter,
        PerEntityEventRateLimitExceeded,
        TitleDefaultLanguageNotSet,
        EmailTemplateMissingDefaultVersion,
        FacebookInstantGamesIdNotLinked,
        InvalidFacebookInstantGamesSignature,
        FacebookInstantGamesAuthNotConfiguredForTitle,
        EntityProfileConstraintValidationFailed,
        TelemetryIngestionKeyPending,
        TelemetryIngestionKeyNotFound,
        StatisticChildNameInvalid,
        DataIntegrityError,
        VirtualCurrencyCannotBeSetToOlderVersion,
        VirtualCurrencyMustBeWithinIntegerRange,
        EmailTemplateInvalidSyntax,
        EmailTemplateMissingCallback,
        PushNotificationTemplateInvalidPayload,
        InvalidLocalizedPushNotificationLanguage,
        MissingLocalizedPushNotificationMessage,
        PushNotificationTemplateMissingPlatformPayload,
        PushNotificationTemplatePayloadContainsInvalidJson,
        PushNotificationTemplateContainsInvalidIosPayload,
        PushNotificationTemplateContainsInvalidAndroidPayload,
        PushNotificationTemplateIosPayloadMissingNotificationBody,
        PushNotificationTemplateAndroidPayloadMissingNotificationBody,
        PushNotificationTemplateNotFound,
        PushNotificationTemplateMissingDefaultVersion,
        PushNotificationTemplateInvalidSyntax,
        PushNotificationTemplateNoCustomPayloadForV1,
        NoLeaderboardForStatistic,
        TitleNewsMissingDefaultLanguage,
        TitleNewsNotFound,
        TitleNewsDuplicateLanguage,
        TitleNewsMissingTitleOrBody,
        TitleNewsInvalidLanguage,
        EmailRecipientBlacklisted,
        InvalidGameCenterAuthRequest,
        GameCenterAuthenticationFailed,
        CannotEnablePartiesForTitle,
        PartyError,
        PartyRequests,
        PartyNoContent,
        PartyBadRequest,
        PartyUnauthorized,
        PartyForbidden,
        PartyNotFound,
        PartyConflict,
        PartyInternalServerError,
        PartyUnavailable,
        PartyTooManyRequests,
        PushNotificationTemplateMissingName,
        CannotEnableMultiplayerServersForTitle,
        WriteAttemptedDuringExport,
        MultiplayerServerTitleQuotaCoresExceeded,
        AutomationRuleNotFound,
        EntityAPIKeyLimitExceeded,
        EntityAPIKeyNotFound,
        EntityAPIKeyOrSecretInvalid,
        EconomyServiceUnavailable,
        EconomyServiceInternalError,
        QueryRateLimitExceeded,
        EntityAPIKeyCreationDisabledForEntity,
        ForbiddenByEntityPolicy,
        UpdateInventoryRateLimitExceeded,
        StudioCreationRateLimited,
        StudioCreationInProgress,
        DuplicateStudioName,
        StudioNotFound,
        StudioDeleted,
        StudioDeactivated,
        StudioActivated,
        TitleCreationRateLimited,
        TitleCreationInProgress,
        DuplicateTitleName,
        TitleActivationRateLimited,
        TitleActivationInProgress,
        TitleDeactivated,
        TitleActivated,
        CloudScriptAzureFunctionsExecutionTimeLimitExceeded,
        CloudScriptAzureFunctionsArgumentSizeExceeded,
        CloudScriptAzureFunctionsReturnSizeExceeded,
        CloudScriptAzureFunctionsHTTPRequestError,
        VirtualCurrencyBetaGetError,
        VirtualCurrencyBetaCreateError,
        VirtualCurrencyBetaInitialDepositSaveError,
        VirtualCurrencyBetaSaveError,
        VirtualCurrencyBetaDeleteError,
        VirtualCurrencyBetaRestoreError,
        VirtualCurrencyBetaSaveConflict,
        VirtualCurrencyBetaUpdateError,
        InsightsManagementDatabaseNotFound,
        InsightsManagementOperationNotFound,
        InsightsManagementErrorPendingOperationExists,
        InsightsManagementSetPerformanceLevelInvalidParameter,
        InsightsManagementSetStorageRetentionInvalidParameter,
        InsightsManagementGetStorageUsageInvalidParameter,
        InsightsManagementGetOperationStatusInvalidParameter,
        DuplicatePurchaseTransactionId,
        EvaluationModePlayerCountExceeded,
        GetPlayersInSegmentRateLimitExceeded,
        CloudScriptFunctionNameSizeExceeded,
        PaidInsightsFeaturesNotEnabled,
        CloudScriptAzureFunctionsQueueRequestError,
        EvaluationModeTitleCountExceeded,
        InsightsManagementTitleNotInFlight,
        LimitNotFound,
        LimitNotAvailableViaAPI,
        InsightsManagementSetStorageRetentionBelowMinimum,
        InsightsManagementSetStorageRetentionAboveMaximum,
        AppleNotEnabledForTitle,
        InsightsManagementNewActiveEventExportLimitInvalid,
        InsightsManagementSetPerformanceRateLimited,
        PartyRequestsThrottledFromRateLimiter,
        XboxServiceTooManyRequests,
        NintendoSwitchNotEnabledForTitle,
        RequestMultiplayerServersThrottledFromRateLimiter,
        TitleDataOverrideNotFound,
        DuplicateKeys,
        WasNotCreatedWithCloudRoot,
        LegacyMultiplayerServersDeprecated,
        VirtualCurrencyCurrentlyUnavailable,
        SteamUserNotFound,
        ElasticSearchOperationFailed,
        NotImplemented,
        PublisherNotFound,
        PublisherDeleted,
        ApiDisabledForMigration,
        ResourceNameUpdateNotAllowed,
        ApiNotEnabledForTitle,
        DuplicateTitleNameForPublisher,
        AzureTitleCreationInProgress,
        TitleConstraintsPublisherDeletion,
        InvalidPlayerAccountPoolId,
        PlayerAccountPoolNotFound,
        PlayerAccountPoolDeleted,
        TitleCleanupInProgress,
        AzureResourceConcurrentOperationInProgress,
        TitlePublisherUpdateNotAllowed,
        AzureResourceManagerNotSupportedInStamp,
        ApiNotIncludedInAzurePlayFabFeatureSet,
        GoogleServiceAccountFailedAuth,
        GoogleAPIServiceUnavailable,
        GoogleAPIServiceUnknownError,
        NoValidIdentityForAad,
        PlayerIdentityLinkNotFound,
        PhotonApplicationIdAlreadyInUse,
        CloudScriptUnableToDeleteProductionRevision,
        CustomIdNotFound,
        AutomationInvalidInput,
        AutomationInvalidRuleName,
        AutomationRuleAlreadyExists,
        AutomationRuleLimitExceeded,
        InvalidGooglePlayGamesServerAuthCode,
        PlayStreamConnectionFailed,
        InvalidEventContents,
        InsightsV1Deprecated,
        AnalysisSubscriptionNotFound,
        AnalysisSubscriptionFailed,
        AnalysisSubscriptionFoundAlready,
        AnalysisSubscriptionManagementInvalidInput,
        InvalidGameCenterId,
        InvalidNintendoSwitchAccountId,
        EntityAPIKeysNotSupported,
        IpAddressBanned,
        EntityLineageBanned,
        NamespaceMismatch,
        InvalidServiceConfiguration,
        InvalidNamespaceMismatch,
        LeaderboardColumnLengthMismatch,
        InvalidStatisticScore,
        LeaderboardColumnsNotSpecified,
        MatchmakingEntityInvalid,
        MatchmakingPlayerAttributesInvalid,
        MatchmakingQueueNotFound,
        MatchmakingMatchNotFound,
        MatchmakingTicketNotFound,
        MatchmakingAlreadyJoinedTicket,
        MatchmakingTicketAlreadyCompleted,
        MatchmakingQueueConfigInvalid,
        MatchmakingMemberProfileInvalid,
        NintendoSwitchDeviceIdNotLinked,
        MatchmakingNotEnabled,
        MatchmakingPlayerAttributesTooLarge,
        MatchmakingNumberOfPlayersInTicketTooLarge,
        MatchmakingAttributeInvalid,
        MatchmakingPlayerHasNotJoinedTicket,
        MatchmakingRateLimitExceeded,
        MatchmakingTicketMembershipLimitExceeded,
        MatchmakingUnauthorized,
        MatchmakingQueueLimitExceeded,
        MatchmakingRequestTypeMismatch,
        MatchmakingBadRequest,
        PubSubFeatureNotEnabledForTitle,
        PubSubTooManyRequests,
        PubSubConnectionNotFoundForEntity,
        PubSubConnectionHandleInvalid,
        PubSubSubscriptionLimitExceeded,
        TitleConfigNotFound,
        TitleConfigUpdateConflict,
        TitleConfigSerializationError,
        CatalogApiNotImplemented,
        CatalogEntityInvalid,
        CatalogTitleIdMissing,
        CatalogPlayerIdMissing,
        CatalogClientIdentityInvalid,
        CatalogOneOrMoreFilesInvalid,
        CatalogItemMetadataInvalid,
        CatalogItemIdInvalid,
        CatalogSearchParameterInvalid,
        CatalogFeatureDisabled,
        CatalogConfigInvalid,
        CatalogItemTypeInvalid,
        CatalogBadRequest,
        CatalogTooManyRequests,
        ExportInvalidStatusUpdate,
        ExportInvalidPrefix,
        ExportBlobContainerDoesNotExist,
        ExportNotFound,
        ExportCouldNotUpdate,
        ExportInvalidStorageType,
        ExportAmazonBucketDoesNotExist,
        ExportInvalidBlobStorage,
        ExportKustoException,
        ExportKustoConnectionFailed,
        ExportUnknownError,
        ExportCantEditPendingExport,
        ExportLimitExports,
        ExportLimitEvents,
        ExportInvalidPartitionStatusModification,
        ExportCouldNotCreate,
        ExportNoBackingDatabaseFound,
        ExportCouldNotDelete,
        ExportCannotDetermineEventQuery,
        ExportInvalidQuerySchemaModification,
        ExportQuerySchemaMissingRequiredColumns,
        ExportCannotParseQuery,
        ExportControlCommandsNotAllowed,
        ExportQueryMissingTableReference,
        ExportInsightsV1Deprecated,
        ExplorerBasicInvalidQueryName,
        ExplorerBasicInvalidQueryDescription,
        ExplorerBasicInvalidQueryConditions,
        ExplorerBasicInvalidQueryStartDate,
        ExplorerBasicInvalidQueryEndDate,
        ExplorerBasicInvalidQueryGroupBy,
        ExplorerBasicInvalidQueryAggregateType,
        ExplorerBasicInvalidQueryAggregateProperty,
        ExplorerBasicLoadQueriesError,
        ExplorerBasicLoadQueryError,
        ExplorerBasicCreateQueryError,
        ExplorerBasicDeleteQueryError,
        ExplorerBasicUpdateQueryError,
        ExplorerBasicSavedQueriesLimit,
        ExplorerBasicSavedQueryNotFound,
        TenantShardMapperShardNotFound,
        TitleNotEnabledForParty,
        PartyVersionNotFound,
        MultiplayerServerBuildReferencedByMatchmakingQueue,
        MultiplayerServerBuildReferencedByBuildAlias,
        MultiplayerServerBuildAliasReferencedByMatchmakingQueue,
        PartySerializationError,
        ExperimentationExperimentStopped,
        ExperimentationExperimentRunning,
        ExperimentationExperimentNotFound,
        ExperimentationExperimentNeverStarted,
        ExperimentationExperimentDeleted,
        ExperimentationClientTimeout,
        ExperimentationInvalidVariantConfiguration,
        ExperimentationInvalidVariableConfiguration,
        ExperimentInvalidId,
        ExperimentationNoScorecard,
        ExperimentationTreatmentAssignmentFailed,
        ExperimentationTreatmentAssignmentDisabled,
        ExperimentationInvalidDuration,
        ExperimentationMaxExperimentsReached,
        ExperimentationExperimentSchedulingInProgress,
        ExperimentationInvalidEndDate,
        ExperimentationInvalidStartDate,
        ExperimentationMaxDurationExceeded,
        ExperimentationExclusionGroupNotFound,
        ExperimentationExclusionGroupInsufficientCapacity,
        ExperimentationExclusionGroupCannotDelete,
        ExperimentationExclusionGroupInvalidTrafficAllocation,
        ExperimentationExclusionGroupInvalidName,
        MaxActionDepthExceeded,
        TitleNotOnUpdatedPricingPlan,
        SegmentManagementTitleNotInFlight,
        SegmentManagementNoExpressionTree,
        SegmentManagementTriggerActionCountOverLimit,
        SegmentManagementSegmentCountOverLimit,
        SegmentManagementInvalidSegmentId,
        SegmentManagementInvalidInput,
        SegmentManagementInvalidSegmentName,
        DeleteSegmentRateLimitExceeded,
        CreateSegmentRateLimitExceeded,
        UpdateSegmentRateLimitExceeded,
        GetSegmentsRateLimitExceeded,
        AsyncExportNotInFlight,
        AsyncExportNotFound,
        AsyncExportRateLimitExceeded,
        AnalyticsSegmentCountOverLimit,
        SnapshotNotFound,
        InventoryApiNotImplemented,
        LobbyDoesNotExist,
        LobbyRateLimitExceeded,
        LobbyPlayerAlreadyJoined,
        LobbyNotJoinable,
        LobbyMemberCannotRejoin,
        LobbyCurrentPlayersMoreThanMaxPlayers,
        LobbyPlayerNotPresent,
        LobbyBadRequest,
        LobbyPlayerMaxLobbyLimitExceeded,
        LobbyNewOwnerMustBeConnected,
        LobbyCurrentOwnerStillConnected,
        LobbyMemberIsNotOwner,
        LobbyServerMismatch,
        LobbyServerNotFound,
        LobbyDifferentServerAlreadyJoined,
        LobbyServerAlreadyJoined,
        LobbyIsNotClientOwned,
        LobbyDoesNotUseConnections,
        EventSamplingInvalidRatio,
        EventSamplingInvalidEventNamespace,
        EventSamplingInvalidEventName,
        EventSamplingRatioNotFound,
        TelemetryKeyNotFound,
        TelemetryKeyInvalidName,
        TelemetryKeyAlreadyExists,
        TelemetryKeyInvalid,
        TelemetryKeyCountOverLimit,
        TelemetryKeyDeactivated,
        TelemetryKeyLongInsightsRetentionNotAllowed,
        EventSinkConnectionInvalid,
        EventSinkConnectionUnauthorized,
        EventSinkRegionInvalid,
        EventSinkLimitExceeded,
        EventSinkSasTokenInvalid,
        EventSinkNotFound,
        EventSinkNameInvalid,
        EventSinkSasTokenPermissionInvalid,
        EventSinkSecretInvalid,
        EventSinkTenantNotFound,
        EventSinkAadNotFound,
        EventSinkDatabaseNotFound,
        EventSinkTitleUnauthorized,
        OperationCanceled,
        InvalidDisplayNameRandomSuffixLength,
        AllowNonUniquePlayerDisplayNamesDisableNotAllowed,
        PartitionedEventInvalid,
        PartitionedEventCountOverLimit,
        ManageEventNamespaceInvalid,
        ManageEventNameInvalid,
        ManagedEventNotFound,
        ManageEventsInvalidRatio,
        ManagedEventInvalid,
        PlayerCustomPropertiesPropertyNameTooLong,
        PlayerCustomPropertiesPropertyNameIsInvalid,
        PlayerCustomPropertiesStringPropertyValueTooLong,
        PlayerCustomPropertiesValueIsInvalidType,
        PlayerCustomPropertiesVersionMismatch,
        PlayerCustomPropertiesPropertyCountTooHigh,
        PlayerCustomPropertiesDuplicatePropertyName,
        PlayerCustomPropertiesPropertyDoesNotExist,
        AddonAlreadyExists,
        AddonDoesntExist,
        CopilotDisabled,
        CopilotInvalidRequest,
        TrueSkillUnauthorized
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

    /// <summary>
    /// Request has no paramaters.
    /// </summary>
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

    /// <summary>
    /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned will only contain
    /// the data specific to the indicated Keys. Otherwise, the full set of custom user data will be returned.
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
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

    /// <summary>
    /// Character statistics are similar to user statistics in that they are numeric values which may only be updated by a
    /// server operation, in order to minimize the opportunity for unauthorized changes. In addition to being available for use
    /// by the title, the statistics are used for all leaderboard operations in PlayFab.
    /// </summary>
    [Serializable]
    public class GetCharacterStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetCharacterStatisticsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier of the character for the statistics.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Character statistics for the requested user.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics;
        /// <summary>
        /// PlayFab unique identifier of the user whose character statistics are being returned.
        /// </summary>
        public string PlayFabId;
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
    public class GetFriendLeaderboardRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates which other platforms' friends should be included in the response. In HTTP, it is represented as a
        /// comma-separated list of platforms.
        /// </summary>
        public ExternalFriendSources? ExternalPlatformFriends;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
        /// <summary>
        /// The player whose friend leaderboard to get
        /// </summary>
        public string PlayFabId;
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
        /// Indicates which other platforms' friends should be included in the response. In HTTP, it is represented as a
        /// comma-separated list of platforms.
        /// </summary>
        public ExternalFriendSources? ExternalPlatformFriends;
        /// <summary>
        /// PlayFab identifier of the player whose friend list to get.
        /// </summary>
        public string PlayFabId;
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
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class GetLeaderboardAroundUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
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
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
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
    public class GetLeaderboardAroundUserResult : PlayFabResultCommon
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount;
        /// <summary>
        /// If non-null, this determines which properties of the resulting player profiles to return. For API calls from the client,
        /// only the allowed client profile properties for the title may be requested. These allowed properties are configured in
        /// the Game Manager "Client Profile Options" tab in the "Settings" section.
        /// </summary>
        public PlayerProfileViewConstraints ProfileConstraints;
        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition;
        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// The version of the leaderboard to get.
        /// </summary>
        public int? Version;
    }

    /// <summary>
    /// Note that the Position of the user in the results is for the overall leaderboard.
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
        /// PlayFabId of the user whose data will be returned
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
    public class GetPlayerSegmentsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of segments the requested player currently belongs to.
        /// </summary>
        public List<GetSegmentResult> Segments;
    }

    /// <summary>
    /// Initial request must contain at least a Segment ID. Subsequent requests must contain the Segment ID as well as the
    /// Continuation Token. Failure to send the Continuation Token will result in a new player segment list being generated.
    /// Each time the Continuation Token is passed in the length of the Total Seconds to Live is refreshed. If too much time
    /// passes between requests to the point that a subsequent request is past the Total Seconds to Live an error will be
    /// returned and paging will be terminated. This API is resource intensive and should not be used in scenarios which might
    /// generate high request volumes. Only one request to this API at a time should be made per title. Concurrent requests to
    /// the API may be rejected with the APIConcurrentRequestLimitExceeded error.
    /// </summary>
    [Serializable]
    public class GetPlayersInSegmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Continuation token if retrieving subsequent pages of results.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If set to true, the profiles are loaded asynchronously and the response will include a continuation token and
        /// approximate profile count until the first batch of profiles is loaded. Use this parameter to help avoid network
        /// timeouts.
        /// </summary>
        public bool? GetProfilesAsync;
        /// <summary>
        /// Maximum is 10,000. The value 0 will prevent loading any profiles and return only the count of profiles matching this
        /// segment.
        /// </summary>
        public uint? MaxBatchSize;
        /// <summary>
        /// Number of seconds to keep the continuation token active. After token expiration it is not possible to continue paging
        /// results. Default is 300 (5 minutes). Maximum is 5,400 (90 minutes).
        /// </summary>
        public uint? SecondsToLive;
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string SegmentId;
    }

    [Serializable]
    public class GetPlayersInSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Continuation token to use to retrieve subsequent pages of results. If token returns null there are no more results.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Array of player profiles in this segment.
        /// </summary>
        public List<PlayerProfile> PlayerProfiles;
        /// <summary>
        /// Count of profiles matching this segment.
        /// </summary>
        public int ProfilesInSegment;
    }

    [Serializable]
    public class GetPlayersSegmentsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetPlayerStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// user for whom statistics are being requested
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// statistics to return
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
    public class GetPlayFabIDsFromFacebookIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Facebook identifiers for which the title needs to get PlayFab identifiers. The array cannot exceed 2,000
        /// in length.
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
        /// Array of unique Facebook Instant Games identifiers for which the title needs to get PlayFab identifiers. The array
        /// cannot exceed 25 in length.
        /// </summary>
        public List<string> FacebookInstantGamesIds;
    }

    /// <summary>
    /// For Facebook Instant Games identifiers which have not been linked to PlayFab accounts, null will be returned.
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
    public class GetPlayFabIDsFromNintendoServiceAccountIdsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Nintendo Switch Account identifiers for which the title needs to get PlayFab identifiers. The array
        /// cannot exceed 2,000 in length.
        /// </summary>
        public List<string> NintendoAccountIds;
    }

    /// <summary>
    /// For Nintendo Service Account identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromNintendoServiceAccountIdsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of Nintendo Switch Service Account identifiers to PlayFab identifiers.
        /// </summary>
        public List<NintendoServiceAccountPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromNintendoSwitchDeviceIdsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Nintendo Switch Device identifiers for which the title needs to get PlayFab identifiers. The array
        /// cannot exceed 2,000 in length.
        /// </summary>
        public List<string> NintendoSwitchDeviceIds;
    }

    /// <summary>
    /// For Nintendo Switch Device identifiers which have not been linked to PlayFab accounts, null will be returned.
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
        /// Id of the PlayStation :tm: Network issuer environment. If null, defaults to production environment.
        /// </summary>
        public int? IssuerId;
        /// <summary>
        /// Array of unique PlayStation :tm: Network identifiers for which the title needs to get PlayFab identifiers. The array
        /// cannot exceed 2,000 in length.
        /// </summary>
        public List<string> PSNAccountIDs;
    }

    /// <summary>
    /// For PlayStation :tm: Network identifiers which have not been linked to PlayFab accounts, null will be returned.
    /// </summary>
    [Serializable]
    public class GetPlayFabIDsFromPSNAccountIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of PlayStation :tm: Network identifiers to PlayFab identifiers.
        /// </summary>
        public List<PSNAccountPlayFabIdPair> Data;
    }

    [Serializable]
    public class GetPlayFabIDsFromSteamIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique Steam identifiers (Steam profile IDs) for which the title needs to get PlayFab identifiers. The array
        /// cannot exceed 2,000 in length.
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
        /// Array of unique Twitch identifiers (Twitch's _id) for which the title needs to get PlayFab identifiers. The array cannot
        /// exceed 2,000 in length.
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
        /// Array of unique Xbox Live account identifiers for which the title needs to get PlayFab identifiers. The array cannot
        /// exceed 2,000 in length.
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
        /// Mapping of Xbox Live identifiers to PlayFab identifiers.
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
    public class GetRandomResultTablesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specifies the catalog version that should be used to retrieve the Random Result Tables. If unspecified, uses
        /// default/primary catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The unique identifier of the Random Result Table to use.
        /// </summary>
        public List<string> TableIDs;
    }

    /// <summary>
    /// Note that if a specified Random Result Table contains no entries, or does not exist in the catalog, an InvalidDropTable
    /// error will be returned.
    /// </summary>
    [Serializable]
    public class GetRandomResultTablesResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of random result tables currently available
        /// </summary>
        public Dictionary<string,RandomResultTableListing> Tables;
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
    public class GetServerCustomIDsFromPlayFabIDsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of unique PlayFab player identifiers for which the title needs to get server custom identifiers. Cannot contain
        /// more than 25 identifiers.
        /// </summary>
        public List<string> PlayFabIDs;
    }

    /// <summary>
    /// For a PlayFab account that isn't associated with a server custom identity, ServerCustomId will be null.
    /// </summary>
    [Serializable]
    public class GetServerCustomIDsFromPlayFabIDsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Mapping of server custom player identifiers to PlayFab identifiers.
        /// </summary>
        public List<ServerCustomIDPlayFabIDPair> Data;
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
    public class GetStoreItemsServerRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version to store items from. Use default catalog version if null
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Optional identifier for the player to use in requesting the store information - if used, segment overrides will be
        /// applied
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unqiue identifier for the store which is being requested
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
    /// build. If an override label is specified in the request, the overrides are applied automatically and returned with the
    /// title data. Note that there may up to a minute delay in between updating title data and this API call returning the
    /// newest value.
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
        /// Array of localized news items.
        /// </summary>
        public List<TitleNewsItem> News;
    }

    /// <summary>
    /// This API allows for access to details regarding a user in the PlayFab service, usually for purposes of customer support.
    /// Note that data returned may be Personally Identifying Information (PII), such as email address, and so care should be
    /// taken in how this data is stored and managed. Since this call will always return the relevant information for users who
    /// have accessed the title, the recommendation is to not store this data locally.
    /// </summary>
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

    /// <summary>
    /// Get all bans for a user, including inactive and expired bans.
    /// </summary>
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

    /// <summary>
    /// Data is stored as JSON key-value pairs. If the Keys parameter is provided, the data object returned will only contain
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
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
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
        /// <summary>
        /// PlayFab unique identifier of the user whose custom data is being returned.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// All items currently in the user inventory will be returned, irrespective of how they were acquired (via purchasing,
    /// grants, coupons, etc.). Items that are expired, fully consumed, or are no longer valid are not considered to be in the
    /// user's current inventory, and so will not be not included.
    /// </summary>
    [Serializable]
    public class GetUserInventoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetUserInventoryResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of inventory items belonging to the user.
        /// </summary>
        public List<ItemInstance> Inventory;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Array of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency;
        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes;
    }

    /// <summary>
    /// Grants a character to the user of the type and name specified in the request.
    /// </summary>
    [Serializable]
    public class GrantCharacterToUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Non-unique display name of the character being granted (1-40 characters in length).
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// Type of the character being granted; statistics can be sliced based on this value.
        /// </summary>
        public string CharacterType;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    /// Result of granting an item to a user. Note, to retrieve additional information for an item such as Tags, Description
    /// that are the same across all instances of the item, a call to GetCatalogItems is required. The ItemID of can be matched
    /// to a catalog entry, which contains the additional information. Also note that Custom Data is only set when the User's
    /// specific instance has updated the CustomData via a call to UpdateUserInventoryItemCustomData. Other fields such as
    /// UnitPrice and UnitCurrency are only set when the item was granted via a purchase.
    /// </summary>
    [Serializable]
    public class GrantedItemInstance : PlayFabBaseModel
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
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate;
        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses;
        /// <summary>
        /// Result of this operation.
        /// </summary>
        public bool Result;
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

    /// <summary>
    /// This function directly adds inventory items to the character's inventories. As a result of this operations, the user
    /// will not be charged any transaction fee, regardless of the inventory item catalog definition. Please note that the
    /// processing time for inventory grants and purchases increases fractionally the more items are in the inventory, and the
    /// more items are in the grant/purchase operation.
    /// </summary>
    [Serializable]
    public class GrantItemsToCharacterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Catalog version from which items are to be granted.
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
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GrantItemsToCharacterResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;
    }

    /// <summary>
    /// This function directly adds inventory items to the user's inventories. As a result of this operations, the user will not
    /// be charged any transaction fee, regardless of the inventory item catalog definition. Please note that the processing
    /// time for inventory grants and purchases increases fractionally the more items are in the inventory, and the more items
    /// are in the grant/purchase operation.
    /// </summary>
    [Serializable]
    public class GrantItemsToUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// Please note that the order of the items in the response may not match the order of items in the request.
    /// </summary>
    [Serializable]
    public class GrantItemsToUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;
    }

    /// <summary>
    /// This function directly adds inventory items to user inventories. As a result of this operations, the user will not be
    /// charged any transaction fee, regardless of the inventory item catalog definition. Please note that the processing time
    /// for inventory grants and purchases increases fractionally the more items are in the inventory, and the more items are in
    /// the grant/purchase operation.
    /// </summary>
    [Serializable]
    public class GrantItemsToUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Array of items to grant and the users to whom the items are to be granted.
        /// </summary>
        public List<ItemGrant> ItemGrants;
    }

    /// <summary>
    /// Please note that the order of the items in the response may not match the order of items in the request.
    /// </summary>
    [Serializable]
    public class GrantItemsToUsersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults;
    }

    [Serializable]
    public class ItemGrant : PlayFabBaseModel
    {
        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may
        /// not begin with a '!' character or be null.
        /// </summary>
        public Dictionary<string,string> Data;
        /// <summary>
        /// Unique identifier of the catalog item to be granted to the user.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values into Data due to language
        /// constraints. Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class LinkNintendoServiceAccountSubjectRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to a specific Nintendo Service Account, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The Nintendo Service Account subject or id to link to the PlayFab user.
        /// </summary>
        public string Subject;
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class LinkNintendoSwitchDeviceIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkPSNAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Authentication code provided by the PlayStation :tm: Network.
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
        /// Id of the PlayStation :tm: Network issuer environment. If null, defaults to production environment.
        /// </summary>
        public int? IssuerId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Redirect URI supplied to PlayStation :tm: Network when requesting an auth code
        /// </summary>
        public string RedirectUri;
    }

    [Serializable]
    public class LinkPSNAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkPSNIdRequest : PlayFabRequestCommon
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
        /// Id of the PlayStation :tm: Network issuer environment. If null, defaults to production environment.
        /// </summary>
        public int? IssuerId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Id of the PlayStation :tm: Network user.
        /// </summary>
        public string PSNUserId;
    }

    [Serializable]
    public class LinkPSNIdResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkServerCustomIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// If another user is already linked to the custom ID, unlink the other user and re-link.
        /// </summary>
        public bool? ForceLink;
        /// <summary>
        /// Unique PlayFab identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique server custom identifier for this player.
        /// </summary>
        public string ServerCustomId;
    }

    [Serializable]
    public class LinkServerCustomIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class LinkSteamIdRequest : PlayFabRequestCommon
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
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Xbox Live identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamId;
    }

    [Serializable]
    public class LinkSteamIdResult : PlayFabResultCommon
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
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Xbox Live identifier.
        /// </summary>
        public string PlayFabId;
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

    /// <summary>
    /// Contains the localized push notification content.
    /// </summary>
    [Serializable]
    public class LocalizedPushNotificationProperties : PlayFabBaseModel
    {
        /// <summary>
        /// Message of the localized push notification template.
        /// </summary>
        public string Message;
        /// <summary>
        /// Subject of the localized push notification template.
        /// </summary>
        public string Subject;
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
        NintendoSwitchAccount,
        GooglePlayGames
    }

    [Serializable]
    public class LoginWithServerCustomIdRequest : PlayFabRequestCommon
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
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// The backend server identifier for this player.
        /// </summary>
        public string ServerCustomId;
    }

    /// <summary>
    /// If this is the first time a user has signed in with the Steam ID and CreateAccount is set to true, a new PlayFab account
    /// will be created and linked to the Steam account. In this case, no email or username will be associated with the PlayFab
    /// account. Otherwise, if no PlayFab account is linked to the Steam account, an error indicating this will be returned, so
    /// that the title can guide the user through creation of a PlayFab account. Steam users that are not logged into the Steam
    /// Client app will only have their Steam username synced, other data, such as currency and country will not be available
    /// until they login while the Client is open.
    /// </summary>
    [Serializable]
    public class LoginWithSteamIdRequest : PlayFabRequestCommon
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
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamId;
    }

    /// <summary>
    /// If this is the first time a user has signed in with the Xbox ID and CreateAccount is set to true, a new PlayFab account
    /// will be created and linked to the Xbox Live account. In this case, no email or username will be associated with the
    /// PlayFab account. Otherwise, if no PlayFab account is linked to the Xbox Live account, an error indicating this will be
    /// returned, so that the title can guide the user through creation of a PlayFab account.
    /// </summary>
    [Serializable]
    public class LoginWithXboxIdRequest : PlayFabRequestCommon
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
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
        /// <summary>
        /// The id of Xbox Live sandbox.
        /// </summary>
        public string Sandbox;
        /// <summary>
        /// Unique Xbox identifier for a user.
        /// </summary>
        public string XboxId;
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
        /// Flags for which pieces of info to return for the user.
        /// </summary>
        public GetPlayerCombinedInfoRequestParams InfoRequestParameters;
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
    public class ModifyCharacterVirtualCurrencyResult : PlayFabResultCommon
    {
        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance;
        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency;
    }

    /// <summary>
    /// This function can both add and remove uses of an inventory item. If the number of uses drops below zero, the item will
    /// be removed from active inventory.
    /// </summary>
    [Serializable]
    public class ModifyItemUsesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique instance identifier of the item to be modified.
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// PlayFab unique identifier of the user whose item is being modified.
        /// </summary>
        public string PlayFabId;
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
    /// Transfers an item from a character to another character that is owned by the same user. This will remove the item from
    /// the character's inventory (until and unless it is moved back), and will enable the other character to make use of the
    /// item instead.
    /// </summary>
    [Serializable]
    public class MoveItemToCharacterFromCharacterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the character that currently has the item.
        /// </summary>
        public string GivingCharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique identifier of the character that will be receiving the item.
        /// </summary>
        public string ReceivingCharacterId;
    }

    [Serializable]
    public class MoveItemToCharacterFromCharacterResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Transfers an item from a user to a character she owns. This will remove the item from the user's inventory (until and
    /// unless it is moved back), and will enable the character to make use of the item instead.
    /// </summary>
    [Serializable]
    public class MoveItemToCharacterFromUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class MoveItemToCharacterFromUserResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Transfers an item from a character to the owning user. This will remove the item from the character's inventory (until
    /// and unless it is moved back), and will enable the user to make use of the item instead.
    /// </summary>
    [Serializable]
    public class MoveItemToUserFromCharacterRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class MoveItemToUserFromCharacterResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class NintendoServiceAccountPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique Nintendo Switch Service Account identifier for a user.
        /// </summary>
        public string NintendoServiceAccountId;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Nintendo Switch Service Account
        /// identifier.
        /// </summary>
        public string PlayFabId;
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
    public class PlayerLinkedAccount : PlayFabBaseModel
    {
        /// <summary>
        /// Linked account's email
        /// </summary>
        public string Email;
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
    }

    [Serializable]
    public class PlayerLocation : PlayFabBaseModel
    {
        /// <summary>
        /// City of the player's geographic location.
        /// </summary>
        public string City;
        /// <summary>
        /// The two-character continent code for this location
        /// </summary>
        public ContinentCode ContinentCode;
        /// <summary>
        /// The two-character ISO 3166-1 country code for the country associated with the location
        /// </summary>
        public CountryCode CountryCode;
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
    public class PlayerProfile : PlayFabBaseModel
    {
        /// <summary>
        /// Array of ad campaigns player has been attributed to
        /// </summary>
        public List<AdCampaignAttribution> AdCampaignAttributions;
        /// <summary>
        /// Image URL of the player's avatar.
        /// </summary>
        public string AvatarUrl;
        /// <summary>
        /// Banned until UTC Date. If permanent ban this is set for 20 years after the original ban date.
        /// </summary>
        public DateTime? BannedUntil;
        /// <summary>
        /// The prediction of the player to churn within the next seven days.
        /// </summary>
        public ChurnRiskLevel? ChurnPrediction;
        /// <summary>
        /// Array of contact email addresses associated with the player
        /// </summary>
        public List<ContactEmailInfo> ContactEmailAddresses;
        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created;
        /// <summary>
        /// Player Display Name
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// Last login
        /// </summary>
        public DateTime? LastLogin;
        /// <summary>
        /// Array of third party accounts linked to this player
        /// </summary>
        public List<PlayerLinkedAccount> LinkedAccounts;
        /// <summary>
        /// Dictionary of player's locations by type.
        /// </summary>
        public Dictionary<string,PlayerLocation> Locations;
        /// <summary>
        /// Player account origination
        /// </summary>
        public LoginIdentityProvider? Origination;
        /// <summary>
        /// List of player variants for experimentation
        /// </summary>
        public List<string> PlayerExperimentVariants;
        /// <summary>
        /// PlayFab Player ID
        /// </summary>
        public string PlayerId;
        /// <summary>
        /// Array of player statistics
        /// </summary>
        public List<PlayerStatistic> PlayerStatistics;
        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId;
        /// <summary>
        /// Array of configured push notification end points
        /// </summary>
        public List<PushNotificationRegistration> PushNotificationRegistrations;
        /// <summary>
        /// Dictionary of player's statistics using only the latest version's value
        /// </summary>
        public Dictionary<string,int> Statistics;
        /// <summary>
        /// List of player's tags for segmentation.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// Title ID this profile applies to
        /// </summary>
        public string TitleId;
        /// <summary>
        /// A sum of player's total purchases in USD across all currencies.
        /// </summary>
        public uint? TotalValueToDateInUSD;
        /// <summary>
        /// Dictionary of player's total purchases by currency.
        /// </summary>
        public Dictionary<string,uint> ValuesToDate;
        /// <summary>
        /// Dictionary of player's virtual currency balances
        /// </summary>
        public Dictionary<string,int> VirtualCurrencyBalances;
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
    public class PlayerStatistic : PlayFabBaseModel
    {
        /// <summary>
        /// Statistic ID
        /// </summary>
        public string Id;
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name;
        /// <summary>
        /// Current statistic value
        /// </summary>
        public int StatisticValue;
        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int StatisticVersion;
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
    public class PSNAccountPlayFabIdPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the PlayStation :tm: Network
        /// identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique PlayStation :tm: Network identifier for a user.
        /// </summary>
        public string PSNAccountId;
    }

    [Serializable]
    public class PushNotificationPackage : PlayFabBaseModel
    {
        /// <summary>
        /// Numerical badge to display on App icon (iOS only)
        /// </summary>
        public int Badge;
        /// <summary>
        /// This must be a JSON formatted object. For use with developer-created custom Push Notification plugins
        /// </summary>
        public string CustomData;
        /// <summary>
        /// Icon file to display with the message (Not supported for iOS)
        /// </summary>
        public string Icon;
        /// <summary>
        /// Content of the message (all platforms)
        /// </summary>
        public string Message;
        /// <summary>
        /// Sound file to play with the message (all platforms)
        /// </summary>
        public string Sound;
        /// <summary>
        /// Title/Subject of the message. Not supported for iOS
        /// </summary>
        public string Title;
    }

    public enum PushNotificationPlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    [Serializable]
    public class PushNotificationRegistration : PlayFabBaseModel
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

    [Serializable]
    public class RandomResultTableListing : PlayFabBaseModel
    {
        /// <summary>
        /// Catalog version this table is associated with
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Child nodes that indicate what kind of drop table item this actually is.
        /// </summary>
        public List<ResultTableNode> Nodes;
        /// <summary>
        /// Unique name for this drop table
        /// </summary>
        public string TableId;
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
        /// Catalog version of the coupon.
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    public class RemoveGenericIDRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Generic service identifier to be removed from the player.
        /// </summary>
        public GenericServiceId GenericId;
        /// <summary>
        /// PlayFabId of the user to remove.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// This API will trigger a player_tag_removed event and remove a tag with the given TagName and PlayFabID from the
    /// corresponding player profile. TagName can be used for segmentation and it is limited to 256 characters
    /// </summary>
    [Serializable]
    public class RemovePlayerTagRequest : PlayFabRequestCommon
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

    [Serializable]
    public class ReportPlayerServerRequest : PlayFabRequestCommon
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
        /// <summary>
        /// PlayFabId of the reporting player.
        /// </summary>
        public string ReporterId;
    }

    /// <summary>
    /// Players are currently limited to five reports per day. Attempts by a single user account to submit reports beyond five
    /// will result in Updated being returned as false.
    /// </summary>
    [Serializable]
    public class ReportPlayerServerResult : PlayFabResultCommon
    {
        /// <summary>
        /// The number of remaining reports which may be filed today by this reporting player.
        /// </summary>
        public int SubmissionsRemaining;
    }

    [Serializable]
    public class ResultTableNode : PlayFabBaseModel
    {
        /// <summary>
        /// Either an ItemId, or the TableId of another random result table
        /// </summary>
        public string ResultItem;
        /// <summary>
        /// Whether this entry in the table is an item or a link to another table
        /// </summary>
        public ResultTableNodeType ResultItemType;
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

    /// <summary>
    /// Setting the active state of all non-expired bans for a user to Inactive. Expired bans with an Active state will be
    /// ignored, however. Returns information about applied updates only.
    /// </summary>
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

    /// <summary>
    /// Setting the active state of all bans requested to Inactive regardless of whether that ban has already expired. BanIds
    /// that do not exist will be skipped. Returns information about applied updates only.
    /// </summary>
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
    public class RevokeInventoryItem : PlayFabBaseModel
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// In cases where the inventory item in question is a "crate", and the items it contained have already been dispensed, this
    /// will not revoke access or otherwise remove the items which were dispensed.
    /// </summary>
    [Serializable]
    public class RevokeInventoryItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// In cases where the inventory item in question is a "crate", and the items it contained have already been dispensed, this
    /// will not revoke access or otherwise remove the items which were dispensed.
    /// </summary>
    [Serializable]
    public class RevokeInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of player items to revoke, between 1 and 25 items.
        /// </summary>
        public List<RevokeInventoryItem> Items;
    }

    [Serializable]
    public class RevokeInventoryItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Collection of any errors that occurred during processing.
        /// </summary>
        public List<RevokeItemError> Errors;
    }

    [Serializable]
    public class RevokeInventoryResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class RevokeItemError : PlayFabBaseModel
    {
        /// <summary>
        /// Specific error that was encountered.
        /// </summary>
        public GenericErrorCodes? Error;
        /// <summary>
        /// Item information that failed to be revoked.
        /// </summary>
        public RevokeInventoryItem Item;
    }

    /// <summary>
    /// Represents the save push notification template request.
    /// </summary>
    [Serializable]
    public class SavePushNotificationTemplateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Android JSON for the notification template.
        /// </summary>
        public string AndroidPayload;
        /// <summary>
        /// Id of the push notification template.
        /// </summary>
        public string Id;
        /// <summary>
        /// IOS JSON for the notification template.
        /// </summary>
        public string IOSPayload;
        /// <summary>
        /// Dictionary of localized push notification templates with the language as the key.
        /// </summary>
        public Dictionary<string,LocalizedPushNotificationProperties> LocalizedPushNotificationTemplates;
        /// <summary>
        /// Name of the push notification template.
        /// </summary>
        public string Name;
    }

    /// <summary>
    /// Represents the save push notification template result.
    /// </summary>
    [Serializable]
    public class SavePushNotificationTemplateResult : PlayFabResultCommon
    {
        /// <summary>
        /// Id of the push notification template that was saved.
        /// </summary>
        public string PushNotificationTemplateId;
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
    /// PlayFab accounts which have valid email address or username will be able to receive a password reset email using this
    /// API.The email sent must be an account recovery email template. The username or email can be passed in to send the email
    /// </summary>
    [Serializable]
    public class SendCustomAccountRecoveryEmailRequest : PlayFabRequestCommon
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
        /// The user's username requesting an account recovery.
        /// </summary>
        public string Username;
    }

    [Serializable]
    public class SendCustomAccountRecoveryEmailResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Sends an email for only players that have contact emails associated with them. Takes in an email template ID
    /// specifyingthe email template to send.
    /// </summary>
    [Serializable]
    public class SendEmailFromTemplateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The email template id of the email template to send.
        /// </summary>
        public string EmailTemplateId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class SendEmailFromTemplateResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Represents the request for sending a push notification template to a recipient.
    /// </summary>
    [Serializable]
    public class SendPushNotificationFromTemplateRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Id of the push notification template.
        /// </summary>
        public string PushNotificationTemplateId;
        /// <summary>
        /// PlayFabId of the push notification recipient.
        /// </summary>
        public string Recipient;
    }

    [Serializable]
    public class SendPushNotificationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Allows you to provide precisely formatted json to target devices. This is an advanced feature, allowing you to deliver
        /// to custom plugin logic, fields, or functionality not natively supported by PlayFab.
        /// </summary>
        public List<AdvancedPushPlatformMsg> AdvancedPlatformDelivery;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Text of message to send.
        /// </summary>
        public string Message;
        /// <summary>
        /// Defines all possible push attributes like message, title, icon, etc. Some parameters are device specific - please see
        /// the PushNotificationPackage documentation for details.
        /// </summary>
        public PushNotificationPackage Package;
        /// <summary>
        /// PlayFabId of the recipient of the push notification.
        /// </summary>
        public string Recipient;
        /// <summary>
        /// Subject of message to send (may not be displayed in all platforms)
        /// </summary>
        public string Subject;
        /// <summary>
        /// Target Platforms that should receive the Message or Package. If omitted, we will send to all available platforms.
        /// </summary>
        public List<PushNotificationPlatform> TargetPlatforms;
    }

    [Serializable]
    public class SendPushNotificationResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ServerCustomIDPlayFabIDPair : PlayFabBaseModel
    {
        /// <summary>
        /// Unique PlayFab identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique server custom identifier for this player.
        /// </summary>
        public string ServerCustomId;
    }

    [Serializable]
    public class ServerLoginResult : PlayFabResultCommon
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
        /// PlayFab identifier of the player whose friend is to be updated.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Array of tags to set on the friend account.
        /// </summary>
        public List<string> Tags;
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
        /// Player secret that is used to verify API request signatures (Enterprise Only).
        /// </summary>
        public string PlayerSecret;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class SetPlayerSecretResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// This API is designed to store publisher-specific values which can be read, but not written to, by the client. This data
    /// is shared across all titles assigned to a particular publisher, and can be used for cross-game coordination. Only titles
    /// assigned to a publisher can use this API. This operation is additive. If a Key does not exist in the current dataset, it
    /// will be added with the specified Value. If it already exists, the Value for that key will be overwritten with the new
    /// Value. For more information email helloplayfab@microsoft.com
    /// </summary>
    [Serializable]
    public class SetPublisherDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same
        /// name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
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

    /// <summary>
    /// This API is designed to store title specific values which can be read, but not written to, by the client. For example, a
    /// developer could choose to store values which modify the user experience, such as enemy spawn rates, weapon strengths,
    /// movement speeds, etc. This allows a developer to update the title without the need to create, test, and ship a new
    /// build. This operation is additive. If a Key does not exist in the current dataset, it will be added with the specified
    /// Value. If it already exists, the Value for that key will be overwritten with the new Value.
    /// </summary>
    [Serializable]
    public class SetTitleDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same
        /// name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
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
    public class SharedGroupDataRecord : PlayFabBaseModel
    {
        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated;
        /// <summary>
        /// PlayFabId of the user to last update this value.
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

    [Serializable]
    public class SubtractCharacterVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount;
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency;
    }

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
        /// PlayFab unique identifier of the user whose virtual currency balance is to be decreased.
        /// </summary>
        public string PlayFabId;
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
        /// News item body.
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
    public class UnlinkNintendoServiceAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class UnlinkNintendoSwitchDeviceIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkPSNAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class UnlinkPSNAccountResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkServerCustomIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab identifier.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique server custom identifier for this player.
        /// </summary>
        public string ServerCustomId;
    }

    [Serializable]
    public class UnlinkServerCustomIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkSteamIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam account.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class UnlinkSteamIdResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UnlinkXboxAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Xbox Live identifier.
        /// </summary>
        public string PlayFabId;
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// The items and vc found within the container. These will be added and stacked in your inventory as appropriate.
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// Represents a single update ban request.
    /// </summary>
    [Serializable]
    public class UpdateBanRequest : PlayFabBaseModel
    {
        /// <summary>
        /// The updated active state for the ban. Null for no change.
        /// </summary>
        public bool? Active;
        /// <summary>
        /// The id of the ban to be updated.
        /// </summary>
        public string BanId;
        /// <summary>
        /// The updated expiration date for the ban. Null for no change.
        /// </summary>
        public DateTime? Expires;
        /// <summary>
        /// The updated IP address for the ban. Null for no change.
        /// </summary>
        public string IPAddress;
        /// <summary>
        /// Whether to make this ban permanent. Set to true to make this ban permanent. This will not modify Active state.
        /// </summary>
        public bool? Permanent;
        /// <summary>
        /// The updated reason for the ban to be updated. Maximum 140 characters. Null for no change.
        /// </summary>
        public string Reason;
    }

    /// <summary>
    /// For each ban, only updates the values that are set. Leave any value to null for no change. If a ban could not be found,
    /// the rest are still applied. Returns information about applied updates only.
    /// </summary>
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

    /// <summary>
    /// This function performs an additive update of the arbitrary JSON object containing the custom data for the user. In
    /// updating the custom data object, keys which already exist in the object will have their values overwritten, while keys
    /// with null values will be removed. No other key-value pairs will be changed apart from those specified in the call.
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
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    /// Character statistics are similar to user statistics in that they are numeric values which may only be updated by a
    /// server operation, in order to minimize the opportunity for unauthorized changes. In addition to being available for use
    /// by the title, the statistics are used for all leaderboard operations in PlayFab.
    /// </summary>
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
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class UpdateCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// This operation is additive. Statistics not currently defined will be added, while those already defined will be updated
    /// with the given values. All other user statistics will remain unchanged.
    /// </summary>
    [Serializable]
    public class UpdatePlayerStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Indicates whether the statistics provided should be set, regardless of the aggregation method set on the statistic.
        /// Default is false.
        /// </summary>
        public bool? ForceUpdate;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    /// This function performs an additive update of the arbitrary JSON object containing the custom data for the user. In
    /// updating the custom data object, keys which already exist in the object will have their values overwritten, while keys
    /// with null values will be removed. No other key-value pairs will be changed apart from those specified in the call.
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
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        public UserDataPermission? Permission;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
    /// This function performs an additive update of the arbitrary JSON object containing the custom data for the user. In
    /// updating the custom data object, keys which already exist in the object will have their values overwritten, keys with
    /// null values will be removed. No other key-value pairs will be changed apart from those specified in the call.
    /// </summary>
    [Serializable]
    public class UpdateUserInternalDataRequest : PlayFabRequestCommon
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    /// <summary>
    /// This function performs an additive update of the arbitrary JSON object containing the custom data for the item instance
    /// which belongs to the specified user. In updating the custom data object, keys which already exist in the object will
    /// have their values overwritten, while keys with null values will be removed. No other key-value pairs will be changed
    /// apart from those specified in the call.
    /// </summary>
    [Serializable]
    public class UpdateUserInventoryItemDataRequest : PlayFabRequestCommon
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
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId;
        /// <summary>
        /// Optional list of Data-keys to remove from UserData. Some SDKs cannot insert null-values into Data due to language
        /// constraints. Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
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
        /// User Google Play Games account information, if a Google Play Games account has been linked
        /// </summary>
        public UserGooglePlayGamesInfo GooglePlayGamesInfo;
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
        /// User PlayStation :tm: Network account information, if a PlayStation :tm: Network account has been linked
        /// </summary>
        public UserPsnInfo PsnInfo;
        /// <summary>
        /// Server Custom ID information, if a server custom ID has been assigned
        /// </summary>
        public UserServerCustomIdInfo ServerCustomIdInfo;
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
    public class UserGooglePlayGamesInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Avatar image url of the Google Play Games player
        /// </summary>
        public string GooglePlayGamesPlayerAvatarImageUrl;
        /// <summary>
        /// Display name of the Google Play Games player
        /// </summary>
        public string GooglePlayGamesPlayerDisplayName;
        /// <summary>
        /// Google Play Games player ID
        /// </summary>
        public string GooglePlayGamesPlayerId;
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
        NintendoSwitchAccount,
        GooglePlayGames
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
        /// PlayStation :tm: Network account ID
        /// </summary>
        public string PsnAccountId;
        /// <summary>
        /// PlayStation :tm: Network online ID
        /// </summary>
        public string PsnOnlineId;
    }

    [Serializable]
    public class UserServerCustomIdInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Custom ID
        /// </summary>
        public string CustomId;
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
        /// <summary>
        /// XBox user sandbox
        /// </summary>
        public string XboxUserSandbox;
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
    /// This API is designed to write a multitude of different event types into PlayStream. It supports a flexible JSON schema,
    /// which allowsfor arbitrary key-value pairs to describe any character-based event. The created event will be locked to the
    /// authenticated title.
    /// </summary>
    [Serializable]
    public class WriteServerCharacterEventRequest : PlayFabRequestCommon
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The time (in UTC) associated with this event. The value defaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
    }

    /// <summary>
    /// This API is designed to write a multitude of different event types into PlayStream. It supports a flexible JSON schema,
    /// which allowsfor arbitrary key-value pairs to describe any player-based event. The created event will be locked to the
    /// authenticated title.
    /// </summary>
    [Serializable]
    public class WriteServerPlayerEventRequest : PlayFabRequestCommon
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The time (in UTC) associated with this event. The value defaults to the current time.
        /// </summary>
        public DateTime? Timestamp;
    }

    /// <summary>
    /// This API is designed to write a multitude of different event types into PlayStream. It supports a flexible JSON schema,
    /// which allowsfor arbitrary key-value pairs to describe any title-based event. The created event will be locked to the
    /// authenticated title.
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
