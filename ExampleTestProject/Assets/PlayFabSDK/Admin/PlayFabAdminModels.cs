#if ENABLE_PLAYFABADMIN_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AdminModels
{
    /// <summary>
    /// If the task instance has already completed, there will be no-op.
    /// </summary>
    [Serializable]
    public class AbortTaskInstanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// ID of a task instance that is being aborted.
        /// </summary>
        public string TaskInstanceId;
    }

    /// <summary>
    /// The work to be performed on each entity which can only be of one type.
    /// </summary>
    [Serializable]
    public class Action : PlayFabBaseModel
    {
        /// <summary>
        /// Action content to add inventory item v2
        /// </summary>
        public AddInventoryItemV2Content AddInventoryItemV2Content;
        /// <summary>
        /// Action content to ban player
        /// </summary>
        public BanPlayerContent BanPlayerContent;
        /// <summary>
        /// Action content to delete inventory item v2
        /// </summary>
        public DeleteInventoryItemV2Content DeleteInventoryItemV2Content;
        /// <summary>
        /// Action content to delete player
        /// </summary>
        public DeletePlayerContent DeletePlayerContent;
        /// <summary>
        /// Action content to execute cloud script
        /// </summary>
        public ExecuteCloudScriptContent ExecuteCloudScriptContent;
        /// <summary>
        /// Action content to execute azure function
        /// </summary>
        public ExecuteFunctionContent ExecuteFunctionContent;
        /// <summary>
        /// Action content to grant item
        /// </summary>
        public GrantItemContent GrantItemContent;
        /// <summary>
        /// Action content to grant virtual currency
        /// </summary>
        public GrantVirtualCurrencyContent GrantVirtualCurrencyContent;
        /// <summary>
        /// Action content to increment player statistic
        /// </summary>
        public IncrementPlayerStatisticContent IncrementPlayerStatisticContent;
        /// <summary>
        /// Action content to send push notification
        /// </summary>
        public PushNotificationContent PushNotificationContent;
        /// <summary>
        /// Action content to send email
        /// </summary>
        public SendEmailContent SendEmailContent;
        /// <summary>
        /// Action content to subtract inventory item v2
        /// </summary>
        public SubtractInventoryItemV2Content SubtractInventoryItemV2Content;
    }

    [Serializable]
    public class ActionsOnPlayersInSegmentTaskParameter : PlayFabBaseModel
    {
        /// <summary>
        /// List of actions to perform on each player in a segment. Each action object can contain only one action type.
        /// </summary>
        public List<Action> Actions;
        /// <summary>
        /// ID of the segment to perform actions on.
        /// </summary>
        public string SegmentId;
    }

    [Serializable]
    public class ActionsOnPlayersInSegmentTaskSummary : PlayFabBaseModel
    {
        /// <summary>
        /// UTC timestamp when the task completed.
        /// </summary>
        public DateTime? CompletedAt;
        /// <summary>
        /// Error message for last processing attempt, if an error occured.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// Flag indicating if the error was fatal, if false job will be retried.
        /// </summary>
        public bool? ErrorWasFatal;
        /// <summary>
        /// Estimated time remaining in seconds.
        /// </summary>
        public double? EstimatedSecondsRemaining;
        /// <summary>
        /// Progress represented as percentage.
        /// </summary>
        public double? PercentComplete;
        /// <summary>
        /// If manually scheduled, ID of user who scheduled the task.
        /// </summary>
        public string ScheduledByUserId;
        /// <summary>
        /// UTC timestamp when the task started.
        /// </summary>
        public DateTime StartedAt;
        /// <summary>
        /// Current status of the task instance.
        /// </summary>
        public TaskInstanceStatus? Status;
        /// <summary>
        /// Identifier of the task this instance belongs to.
        /// </summary>
        public NameIdentifier TaskIdentifier;
        /// <summary>
        /// ID of the task instance.
        /// </summary>
        public string TaskInstanceId;
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
    public class AdCampaignSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Campaign id.
        /// </summary>
        public string CampaignId;
        /// <summary>
        /// Campaign source.
        /// </summary>
        public string CampaignSource;
        /// <summary>
        /// Campaign comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
    }

    [Serializable]
    public class AddInventoryItemsV2SegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Amount of the item to be granted to a player
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The collection id for where the item will be granted in the player inventory
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The duration in seconds of the subscription to be granted to a player
        /// </summary>
        public int? DurationInSeconds;
        /// <summary>
        /// The id of item to be granted to the player
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The stack id for where the item will be granted in the player inventory
        /// </summary>
        public string StackId;
    }

    [Serializable]
    public class AddInventoryItemV2Content : PlayFabBaseModel
    {
        /// <summary>
        /// Amount of the item to be granted to a player
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The collection id for where the item will be granted in the player inventory
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The duration in seconds of the subscription to be granted to a player
        /// </summary>
        public int? DurationInSeconds;
        /// <summary>
        /// The id of item to be granted to the player
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The stack id for where the item will be granted in the player inventory
        /// </summary>
        public string StackId;
    }

    [Serializable]
    public class AddLocalizedNewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Localized body text of the news.
        /// </summary>
        public string Body;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Language of the news item.
        /// </summary>
        public string Language;
        /// <summary>
        /// Unique id of the updated news item.
        /// </summary>
        public string NewsId;
        /// <summary>
        /// Localized title (headline) of the news item.
        /// </summary>
        public string Title;
    }

    [Serializable]
    public class AddLocalizedNewsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class AddNewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Default body text of the news.
        /// </summary>
        public string Body;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Time this news was published. If not set, defaults to now.
        /// </summary>
        public DateTime? Timestamp;
        /// <summary>
        /// Default title (headline) of the news item.
        /// </summary>
        public string Title;
    }

    [Serializable]
    public class AddNewsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique id of the new news item
        /// </summary>
        public string NewsId;
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

    /// <summary>
    /// This operation is additive. Any new currencies defined in the array will be added to the set of those available for the
    /// title, while any CurrencyCode identifiers matching existing ones in the game will be overwritten with the new values.
    /// </summary>
    [Serializable]
    public class AddVirtualCurrencyTypesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of virtual currencies and their initial deposits (the amount a user is granted when signing in for the first time)
        /// to the title
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies;
    }

    [Serializable]
    public class AllPlayersSegmentFilter : PlayFabBaseModel
    {
    }

    [Serializable]
    public class ApiCondition : PlayFabBaseModel
    {
        /// <summary>
        /// Require that API calls contain an RSA encrypted payload or signed headers.
        /// </summary>
        public Conditionals? HasSignatureOrEncryption;
    }

    public enum AuthTokenType
    {
        Email
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
        /// <summary>
        /// The family type of the suer that is included in the ban.
        /// </summary>
        public string UserFamilyType;
    }

    [Serializable]
    public class BanPlayerContent : PlayFabBaseModel
    {
        /// <summary>
        /// Duration(in hours) to ban a player. If not provided, the player will be banned permanently.
        /// </summary>
        public int? BanDurationHours;
        /// <summary>
        /// Reason to ban a player
        /// </summary>
        public string BanReason;
    }

    [Serializable]
    public class BanPlayerSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Ban hours duration.
        /// </summary>
        public uint? BanHours;
        /// <summary>
        /// Reason for ban.
        /// </summary>
        public string ReasonForBan;
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
        /// <summary>
        /// The family type of the user that should be included in the ban if applicable. May affect multiple players.
        /// </summary>
        public UserFamilyType? UserFamilyType;
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

    [Serializable]
    public class BlankResult : PlayFabResultCommon
    {
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

    /// <summary>
    /// This returns the total number of these items available.
    /// </summary>
    [Serializable]
    public class CheckLimitedEditionItemAvailabilityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Which catalog is being updated. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The item to check for.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class CheckLimitedEditionItemAvailabilityResult : PlayFabResultCommon
    {
        /// <summary>
        /// The amount of the specified resource remaining.
        /// </summary>
        public int Amount;
    }

    [Serializable]
    public class ChurnPredictionSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Comparison
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// RiskLevel
        /// </summary>
        public ChurnRiskLevel? RiskLevel;
    }

    public enum ChurnRiskLevel
    {
        NoData,
        LowRisk,
        MediumRisk,
        HighRisk
    }

    [Serializable]
    public class CloudScriptFile : PlayFabBaseModel
    {
        /// <summary>
        /// Contents of the Cloud Script javascript. Must be string-escaped javascript.
        /// </summary>
        public string FileContents;
        /// <summary>
        /// Name of the javascript file. These names are not used internally by the server, they are only for developer
        /// organizational purposes.
        /// </summary>
        public string Filename;
    }

    [Serializable]
    public class CloudScriptTaskParameter : PlayFabBaseModel
    {
        /// <summary>
        /// Argument to pass to the CloudScript function.
        /// </summary>
        public object Argument;
        /// <summary>
        /// Name of the CloudScript function to execute.
        /// </summary>
        public string FunctionName;
    }

    [Serializable]
    public class CloudScriptTaskSummary : PlayFabBaseModel
    {
        /// <summary>
        /// UTC timestamp when the task completed.
        /// </summary>
        public DateTime? CompletedAt;
        /// <summary>
        /// Estimated time remaining in seconds.
        /// </summary>
        public double? EstimatedSecondsRemaining;
        /// <summary>
        /// Progress represented as percentage.
        /// </summary>
        public double? PercentComplete;
        /// <summary>
        /// Result of CloudScript execution
        /// </summary>
        public ExecuteCloudScriptResult Result;
        /// <summary>
        /// If manually scheduled, ID of user who scheduled the task.
        /// </summary>
        public string ScheduledByUserId;
        /// <summary>
        /// UTC timestamp when the task started.
        /// </summary>
        public DateTime StartedAt;
        /// <summary>
        /// Current status of the task instance.
        /// </summary>
        public TaskInstanceStatus? Status;
        /// <summary>
        /// Identifier of the task this instance belongs to.
        /// </summary>
        public NameIdentifier TaskIdentifier;
        /// <summary>
        /// ID of the task instance.
        /// </summary>
        public string TaskInstanceId;
    }

    [Serializable]
    public class CloudScriptVersionStatus : PlayFabBaseModel
    {
        /// <summary>
        /// Most recent revision for this Cloud Script version
        /// </summary>
        public int LatestRevision;
        /// <summary>
        /// Published code revision for this Cloud Script version
        /// </summary>
        public int PublishedRevision;
        /// <summary>
        /// Version number
        /// </summary>
        public int Version;
    }

    public enum Conditionals
    {
        Any,
        True,
        False
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

    [Serializable]
    public class ContentInfo : PlayFabBaseModel
    {
        /// <summary>
        /// Key of the content
        /// </summary>
        public string Key;
        /// <summary>
        /// Last modified time
        /// </summary>
        public DateTime LastModified;
        /// <summary>
        /// Size of the content in bytes
        /// </summary>
        public double Size;
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
    /// Task name is unique within a title. Using a task name that's already taken will cause a name conflict error. Too many
    /// create-task requests within a short time will cause a create conflict error.
    /// </summary>
    [Serializable]
    public class CreateActionsOnPlayerSegmentTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Task details related to segment and action
        /// </summary>
        public ActionsOnPlayersInSegmentTaskParameter Parameter;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
    }

    /// <summary>
    /// Task name is unique within a title. Using a task name that's already taken will cause a name conflict error. Too many
    /// create-task requests within a short time will cause a create conflict error.
    /// </summary>
    [Serializable]
    public class CreateCloudScriptTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Task details related to CloudScript
        /// </summary>
        public CloudScriptTaskParameter Parameter;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
    }

    /// <summary>
    /// Task name is unique within a title. Using a task name that's already taken will cause a name conflict error. Too many
    /// create-task requests within a short time will cause a create conflict error.
    /// </summary>
    [Serializable]
    public class CreateInsightsScheduledScalingTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Task details related to Insights Scaling
        /// </summary>
        public InsightsScalingTaskParameter Parameter;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
    }

    [Serializable]
    public class CreateOpenIdConnectionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The client ID given by the ID provider.
        /// </summary>
        public string ClientId;
        /// <summary>
        /// The client secret given by the ID provider.
        /// </summary>
        public string ClientSecret;
        /// <summary>
        /// A name for the connection that identifies it within the title.
        /// </summary>
        public string ConnectionId;
        /// <summary>
        /// Ignore 'nonce' claim in identity tokens.
        /// </summary>
        public bool? IgnoreNonce;
        /// <summary>
        /// The discovery document URL to read issuer information from. This must be the absolute URL to the JSON OpenId
        /// Configuration document and must be accessible from the internet. If you don't know it, try your issuer URL followed by
        /// "/.well-known/openid-configuration". For example, if the issuer is https://example.com, try
        /// https://example.com/.well-known/openid-configuration
        /// </summary>
        public string IssuerDiscoveryUrl;
        /// <summary>
        /// Manually specified information for an OpenID Connect issuer.
        /// </summary>
        public OpenIdIssuerInformation IssuerInformation;
        /// <summary>
        /// Override the issuer name for user indexing and lookup.
        /// </summary>
        public string IssuerOverride;
    }

    /// <summary>
    /// Player Shared Secret Keys are used for the call to Client/GetTitlePublicKey, which exchanges the shared secret for an
    /// RSA CSP blob to be used to encrypt the payload of account creation requests when that API requires a signature header.
    /// </summary>
    [Serializable]
    public class CreatePlayerSharedSecretRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Friendly name for this key
        /// </summary>
        public string FriendlyName;
    }

    [Serializable]
    public class CreatePlayerSharedSecretResult : PlayFabResultCommon
    {
        /// <summary>
        /// The player shared secret to use when calling Client/GetTitlePublicKey
        /// </summary>
        public string SecretKey;
    }

    /// <summary>
    /// Statistics are numeric values, with each statistic in the title also generating a leaderboard. The ResetInterval enables
    /// automatically resetting leaderboards on a specified interval. Upon reset, the statistic updates to a new version with no
    /// values (effectively removing all players from the leaderboard). The previous version's statistic values are also
    /// archived for retrieval, if needed (see GetPlayerStatisticVersions). Statistics not created via a call to
    /// CreatePlayerStatisticDefinition by default have a VersionChangeInterval of Never, meaning they do not reset on a
    /// schedule, but they can be set to do so via a call to UpdatePlayerStatisticDefinition. Once a statistic has been reset
    /// (sometimes referred to as versioned or incremented), the now-previous version can still be written to for up a short,
    /// pre-defined period (currently 10 seconds), to prevent issues with levels completing around the time of the reset. Also,
    /// once reset, the historical statistics for players in the title may be retrieved using the URL specified in the version
    /// information (GetPlayerStatisticVersions). The AggregationMethod determines what action is taken when a new statistic
    /// value is submitted - always update with the new value (Last), use the highest of the old and new values (Max), use the
    /// smallest (Min), or add them together (Sum).
    /// </summary>
    [Serializable]
    public class CreatePlayerStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// interval at which the values of the statistic for all players are reset (resets begin at the next interval boundary)
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval;
    }

    [Serializable]
    public class CreatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// created statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic;
    }

    /// <summary>
    /// Send all the segment details part of CreateSegmentRequest
    /// </summary>
    [Serializable]
    public class CreateSegmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Segment model with all of the segment properties data.
        /// </summary>
        public SegmentModel SegmentModel;
    }

    [Serializable]
    public class CreateSegmentResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// Segment id.
        /// </summary>
        public string SegmentId;
    }

    [Serializable]
    public class CreateTaskResult : PlayFabResultCommon
    {
        /// <summary>
        /// ID of the task
        /// </summary>
        public string TaskId;
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
    public class DeleteContentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Key of the content item to be deleted
        /// </summary>
        public string Key;
    }

    [Serializable]
    public class DeleteInventoryItemsV2SegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// The collection id for where the item will be removed from the player inventory
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The id of item to be removed from the player
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The stack id for where the item will be removed from the player inventory
        /// </summary>
        public string StackId;
    }

    [Serializable]
    public class DeleteInventoryItemV2Content : PlayFabBaseModel
    {
        /// <summary>
        /// The collection id for where the item will be removed from the player inventory
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The id of item to be removed from the player
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The stack id for where the item will be removed from the player inventory
        /// </summary>
        public string StackId;
    }

    /// <summary>
    /// Deletes all data associated with the master player account, including data from all titles the player has played, such
    /// as statistics, custom data, inventory, purchases, virtual currency balances, characters, group memberships, publisher
    /// data, credential data, account linkages, friends list, PlayStream event data, and telemetry event data. Removes the
    /// player from all leaderboards and player search indexes. Note, this API queues the player for deletion and returns a
    /// receipt immediately. Record the receipt ID for future reference. It may take some time before all player data is fully
    /// deleted. Upon completion of the deletion, an email will be sent to the notification email address configured for the
    /// title confirming the deletion. Until the player data is fully deleted, attempts to recreate the player with the same
    /// user account in the same title will fail with the 'AccountDeleted' error. It is highly recommended to know the impact of
    /// the deletion by calling GetPlayedTitleList, before calling this API.
    /// </summary>
    [Serializable]
    public class DeleteMasterPlayerAccountRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Developer created string to identify a user without PlayFab ID
        /// </summary>
        public string MetaData;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class DeleteMasterPlayerAccountResult : PlayFabResultCommon
    {
        /// <summary>
        /// A notification email with this job receipt Id will be sent to the title notification email address when deletion is
        /// complete.
        /// </summary>
        public string JobReceiptId;
        /// <summary>
        /// List of titles from which the player's data will be deleted.
        /// </summary>
        public List<string> TitleIds;
    }

    /// <summary>
    /// Deletes any PlayStream or telemetry event associated with the player from PlayFab. Note, this API queues the data for
    /// asynchronous deletion. It may take some time before the data is deleted.
    /// </summary>
    [Serializable]
    public class DeleteMasterPlayerEventDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class DeleteMasterPlayerEventDataResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// This API lets developers delete a membership subscription.
    /// </summary>
    [Serializable]
    public class DeleteMembershipSubscriptionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Id of the membership to apply the override expiration date to.
        /// </summary>
        public string MembershipId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Id of the subscription that should be deleted from the membership.
        /// </summary>
        public string SubscriptionId;
    }

    [Serializable]
    public class DeleteMembershipSubscriptionResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteOpenIdConnectionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique name of the connection
        /// </summary>
        public string ConnectionId;
    }

    [Serializable]
    public class DeletePlayerContent : PlayFabBaseModel
    {
    }

    /// <summary>
    /// Deletes all data associated with the player, including statistics, custom data, inventory, purchases, virtual currency
    /// balances, characters and shared group memberships. Removes the player from all leaderboards and player search indexes.
    /// Does not delete PlayStream event history associated with the player. Does not delete the publisher user account that
    /// created the player in the title nor associated data such as username, password, email address, account linkages, or
    /// friends list. Note, this API queues the player for deletion and returns immediately. It may take several minutes or more
    /// before all player data is fully deleted. Until the player data is fully deleted, attempts to recreate the player with
    /// the same user account in the same title will fail with the 'AccountDeleted' error.
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

    [Serializable]
    public class DeletePlayerSegmentAction : PlayFabBaseModel
    {
    }

    /// <summary>
    /// Player Shared Secret Keys are used for the call to Client/GetTitlePublicKey, which exchanges the shared secret for an
    /// RSA CSP blob to be used to encrypt the payload of account creation requests when that API requires a signature header.
    /// </summary>
    [Serializable]
    public class DeletePlayerSharedSecretRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The shared secret key to delete
        /// </summary>
        public string SecretKey;
    }

    [Serializable]
    public class DeletePlayerSharedSecretResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeletePlayerStatisticSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Statistic name.
        /// </summary>
        public string StatisticName;
    }

    /// <summary>
    /// Send segment id planning to delete part of DeleteSegmentRequest object
    /// </summary>
    [Serializable]
    public class DeleteSegmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Segment id.
        /// </summary>
        public string SegmentId;
    }

    [Serializable]
    public class DeleteSegmentsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage;
    }

    /// <summary>
    /// This non-reversible operation will permanently delete the requested store.
    /// </summary>
    [Serializable]
    public class DeleteStoreRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// catalog version of the store to delete. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// unqiue identifier for the store which is to be deleted
        /// </summary>
        public string StoreId;
    }

    [Serializable]
    public class DeleteStoreResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// After a task is deleted, for tracking purposes, the task instances belonging to this task will still remain. They will
    /// become orphaned and does not belongs to any task. Executions of any in-progress task instances will continue. If the
    /// task specified does not exist, the deletion is considered a success.
    /// </summary>
    [Serializable]
    public class DeleteTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specify either the task ID or the name of task to be deleted.
        /// </summary>
        public NameIdentifier Identifier;
    }

    /// <summary>
    /// Will delete all the title data associated with the given override label.
    /// </summary>
    [Serializable]
    public class DeleteTitleDataOverrideRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Name of the override.
        /// </summary>
        public string OverrideLabel;
    }

    [Serializable]
    public class DeleteTitleDataOverrideResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Deletes all data associated with the title, including catalog, virtual currencies, leaderboard statistics, Cloud Script
    /// revisions, segment definitions, event rules, tasks, add-ons, secret keys, data encryption keys, and permission policies.
    /// Removes the title from its studio and removes all associated developer roles and permissions. Does not delete PlayStream
    /// event history associated with the title. Note, this API queues the title for deletion and returns immediately. It may
    /// take several hours or more before all title data is fully deleted. All player accounts in the title must be deleted
    /// before deleting the title. If any player accounts exist, the API will return a 'TitleContainsUserAccounts' error. Until
    /// the title data is fully deleted, attempts to call APIs with the title will fail with the 'TitleDeleted' error.
    /// </summary>
    [Serializable]
    public class DeleteTitleRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class DeleteTitleResult : PlayFabResultCommon
    {
    }

    public enum EffectType
    {
        Allow,
        Deny
    }

    [Serializable]
    public class EmailNotificationSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Email template id.
        /// </summary>
        public string EmailTemplateId;
        /// <summary>
        /// Email template name.
        /// </summary>
        public string EmailTemplateName;
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
    public class ExecuteAzureFunctionSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Azure function.
        /// </summary>
        public string AzureFunction;
        /// <summary>
        /// Azure function parameter.
        /// </summary>
        public object FunctionParameter;
        /// <summary>
        /// Generate play stream event.
        /// </summary>
        public bool GenerateFunctionExecutedEvents;
    }

    [Serializable]
    public class ExecuteCloudScriptContent : PlayFabBaseModel
    {
        /// <summary>
        /// Arguments(JSON) to be passed into the cloudscript method
        /// </summary>
        public string CloudScriptMethodArguments;
        /// <summary>
        /// Cloudscript method name
        /// </summary>
        public string CloudScriptMethodName;
        /// <summary>
        /// Publish cloudscript results as playstream event
        /// </summary>
        public bool PublishResultsToPlayStream;
    }

    [Serializable]
    public class ExecuteCloudScriptResult : PlayFabBaseModel
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
    public class ExecuteCloudScriptSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Cloud script function.
        /// </summary>
        public string CloudScriptFunction;
        /// <summary>
        /// Generate play stream event.
        /// </summary>
        public bool CloudScriptPublishResultsToPlayStream;
        /// <summary>
        /// Cloud script function parameter.
        /// </summary>
        public object FunctionParameter;
        /// <summary>
        /// Cloud script function parameter json text.
        /// </summary>
        public string FunctionParameterJson;
    }

    [Serializable]
    public class ExecuteFunctionContent : PlayFabBaseModel
    {
        /// <summary>
        /// Arguments(JSON) to be passed into the cloudscript azure function
        /// </summary>
        public string CloudScriptFunctionArguments;
        /// <summary>
        /// Cloudscript azure function name
        /// </summary>
        public string CloudScriptFunctionName;
        /// <summary>
        /// Publish results from executing the azure function as playstream event
        /// </summary>
        public bool PublishResultsToPlayStream;
    }

    /// <summary>
    /// Exports all data associated with the master player account, including data from all titles the player has played, such
    /// as statistics, custom data, inventory, purchases, virtual currency balances, characters, group memberships, publisher
    /// data, credential data, account linkages, friends list, PlayStream event data, and telemetry event data. Note, this API
    /// queues the player for export and returns a receipt immediately. Record the receipt ID for future reference. It may take
    /// some time before the export is available for download. Upon completion of the export, an email containing the URL to
    /// download the export dump will be sent to the notification email address configured for the title.
    /// </summary>
    [Serializable]
    public class ExportMasterPlayerDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class ExportMasterPlayerDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// An email with this job receipt Id containing the export download link will be sent to the title notification email
        /// address when the export is complete.
        /// </summary>
        public string JobReceiptId;
    }

    /// <summary>
    /// Request must contain the Segment ID
    /// </summary>
    [Serializable]
    public class ExportPlayersInSegmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the requested segment.
        /// </summary>
        public string SegmentId;
    }

    [Serializable]
    public class ExportPlayersInSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier of the export for the requested Segment.
        /// </summary>
        public string ExportId;
        /// <summary>
        /// Unique identifier of the requested Segment.
        /// </summary>
        public string SegmentId;
    }

    [Serializable]
    public class FirstLoginDateSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// First player login date comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// First player login date.
        /// </summary>
        public DateTime LogInDate;
    }

    [Serializable]
    public class FirstLoginTimespanSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// First player login duration comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// First player login duration.
        /// </summary>
        public double DurationInMinutes;
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
        LeaderboardMaxSizeTooLarge,
        InvalidAttributeStatisticsSpecified,
        LeaderboardNotFound,
        TokenSigningKeyNotFound,
        LeaderboardNameConflict,
        LinkedStatisticColumnMismatch,
        NoLinkedStatisticToLeaderboard,
        StatDefinitionAlreadyLinkedToLeaderboard,
        LinkingStatsNotAllowedForEntityType,
        LeaderboardCountLimitExceeded,
        LeaderboardSizeLimitExceeded,
        LeaderboardDefinitionModificationNotAllowedWhileLinked,
        StatisticDefinitionModificationNotAllowedWhileLinked,
        LeaderboardUpdateNotAllowedWhileLinked,
        CloudScriptAzureFunctionsEventHubRequestError,
        ExternalEntityNotAllowedForTier,
        InvalidBaseTimeForInterval,
        EntityTypeMismatchWithStatDefinition,
        SpecifiedVersionLeaderboardNotFound,
        LeaderboardColumnLengthMismatchWithStatDefinition,
        DuplicateColumnNameFound,
        LinkedStatisticColumnNotFound,
        LinkedStatisticColumnRequired,
        MultipleLinkedStatisticsNotAllowed,
        DuplicateLinkedStatisticColumnNameFound,
        AggregationTypeNotAllowedForMultiColumnStatistic,
        MaxQueryableVersionsValueNotAllowedForTier,
        StatisticDefinitionHasNullOrEmptyVersionConfiguration,
        StatisticColumnLengthMismatch,
        InvalidExternalEntityId,
        UpdatingStatisticsUsingTransactionIdNotAvailableForFreeTier,
        TransactionAlreadyApplied,
        ReportDataNotRetrievedSuccessfully,
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
        InvalidCatalogItemConfiguration,
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
        EventSinkInsufficientRoleAssignment,
        EventSinkContainerNotFound,
        EventSinkTenantIdInvalid,
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
        TrueSkillUnauthorized,
        TrueSkillInvalidTitleId,
        TrueSkillInvalidScenarioId,
        TrueSkillInvalidModelId,
        TrueSkillInvalidModelName,
        TrueSkillInvalidPlayerIds,
        TrueSkillInvalidEntityKey,
        TrueSkillInvalidConditionKey,
        TrueSkillInvalidConditionValue,
        TrueSkillInvalidConditionAffinityWeight,
        TrueSkillInvalidEventName,
        TrueSkillMatchResultCreated,
        TrueSkillMatchResultAlreadySubmitted,
        TrueSkillBadPlayerIdInMatchResult,
        TrueSkillInvalidBotIdInMatchResult,
        TrueSkillDuplicatePlayerInMatchResult,
        TrueSkillNoPlayerInMatchResultTeam,
        TrueSkillPlayersInMatchResultExceedingLimit,
        TrueSkillInvalidPreMatchPartyInMatchResult,
        TrueSkillInvalidTimestampInMatchResult,
        TrueSkillStartTimeMissingInMatchResult,
        TrueSkillEndTimeMissingInMatchResult,
        TrueSkillInvalidPlayerSecondsPlayedInMatchResult,
        TrueSkillNoTeamInMatchResult,
        TrueSkillNotEnoughTeamsInMatchResult,
        TrueSkillInvalidRanksInMatchResult,
        TrueSkillNoWinnerInMatchResult,
        TrueSkillMissingRequiredCondition,
        TrueSkillMissingRequiredEvent,
        TrueSkillUnknownEventName,
        TrueSkillInvalidEventCount,
        TrueSkillUnknownConditionKey,
        TrueSkillUnknownConditionValue,
        TrueSkillScenarioConfigDoesNotExist,
        TrueSkillUnknownModelId,
        TrueSkillNoModelInScenario,
        TrueSkillNotSupportedForTitle,
        TrueSkillModelIsNotActive,
        TrueSkillUnauthorizedToQueryOtherPlayerSkills,
        TrueSkillInvalidMaxIterations,
        TrueSkillEndTimeBeforeStartTime,
        TrueSkillInvalidJobId,
        TrueSkillInvalidMetadataId,
        TrueSkillMissingBuildVerison,
        TrueSkillJobAlreadyExists,
        TrueSkillJobNotFound,
        TrueSkillOperationCanceled,
        TrueSkillActiveModelLimitExceeded,
        TrueSkillTotalModelLimitExceeded,
        TrueSkillUnknownInitialModelId,
        TrueSkillUnauthorizedForJob,
        TrueSkillInvalidScenarioName,
        TrueSkillConditionStateIsRequired,
        TrueSkillEventStateIsRequired,
        TrueSkillDuplicateEvent,
        TrueSkillDuplicateCondition,
        TrueSkillInvalidAnomalyThreshold,
        TrueSkillConditionKeyLimitExceeded,
        TrueSkillConditionValuePerKeyLimitExceeded,
        TrueSkillInvalidTimestamp,
        TrueSkillEventLimitExceeded,
        TrueSkillInvalidPlayers,
        TrueSkillTrueSkillPlayerNull,
        TrueSkillInvalidPlayerId,
        TrueSkillInvalidSquadSize,
        TrueSkillConditionSetNotInModel,
        TrueSkillModelStateInvalidForOperation,
        TrueSkillScenarioContainsActiveModel,
        GameSaveManifestNotFound,
        GameSaveManifestVersionAlreadyExists,
        GameSaveConflictUpdatingManifest,
        GameSaveManifestUpdatesNotAllowed,
        GameSaveFileAlreadyExists,
        GameSaveManifestVersionNotFinalized,
        GameSaveUnknownFileInManifest,
        GameSaveFileExceededReportedSize,
        GameSaveFileNotUploaded,
        GameSaveBadRequest,
        GameSaveOperationNotAllowed,
        GameSaveDataStorageQuotaExceeded,
        GameSaveNewerManifestExists,
        StateShareForbidden,
        StateShareTitleNotInFlight,
        StateShareStateNotFound,
        StateShareLinkNotFound,
        StateShareStateRedemptionLimitExceeded,
        StateShareStateRedemptionLimitNotUpdated,
        StateShareCreatedStatesLimitExceeded,
        StateShareIdMissingOrMalformed
    }

    [Serializable]
    public class GetActionsOnPlayersInSegmentTaskInstanceResult : PlayFabResultCommon
    {
        /// <summary>
        /// Parameter of this task instance
        /// </summary>
        public ActionsOnPlayersInSegmentTaskParameter Parameter;
        /// <summary>
        /// Status summary of the actions-on-players-in-segment task instance
        /// </summary>
        public ActionsOnPlayersInSegmentTaskSummary Summary;
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

    [Serializable]
    public class GetCloudScriptRevisionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Revision number. If left null, defaults to the latest revision
        /// </summary>
        public int? Revision;
        /// <summary>
        /// Version number. If left null, defaults to the latest version
        /// </summary>
        public int? Version;
    }

    [Serializable]
    public class GetCloudScriptRevisionResult : PlayFabResultCommon
    {
        /// <summary>
        /// Time this revision was created
        /// </summary>
        public DateTime CreatedAt;
        /// <summary>
        /// List of Cloud Script files in this revision.
        /// </summary>
        public List<CloudScriptFile> Files;
        /// <summary>
        /// True if this is the currently published revision
        /// </summary>
        public bool IsPublished;
        /// <summary>
        /// Revision number.
        /// </summary>
        public int Revision;
        /// <summary>
        /// Version number.
        /// </summary>
        public int Version;
    }

    [Serializable]
    public class GetCloudScriptTaskInstanceResult : PlayFabResultCommon
    {
        /// <summary>
        /// Parameter of this task instance
        /// </summary>
        public CloudScriptTaskParameter Parameter;
        /// <summary>
        /// Status summary of the CloudScript task instance
        /// </summary>
        public CloudScriptTaskSummary Summary;
    }

    [Serializable]
    public class GetCloudScriptVersionsRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetCloudScriptVersionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of versions
        /// </summary>
        public List<CloudScriptVersionStatus> Versions;
    }

    [Serializable]
    public class GetContentListRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Limits the response to keys that begin with the specified prefix. You can use prefixes to list contents under a folder,
        /// or for a specified version, etc.
        /// </summary>
        public string Prefix;
    }

    [Serializable]
    public class GetContentListResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of content items.
        /// </summary>
        public List<ContentInfo> Contents;
        /// <summary>
        /// Number of content items returned. We currently have a maximum of 1000 items limit.
        /// </summary>
        public int ItemCount;
        /// <summary>
        /// The total size of listed contents in bytes.
        /// </summary>
        public uint TotalSize;
    }

    [Serializable]
    public class GetContentUploadUrlRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A standard MIME type describing the format of the contents. The same MIME type has to be set in the header when
        /// uploading the content. If not specified, the MIME type is 'binary/octet-stream' by default.
        /// </summary>
        public string ContentType;
        /// <summary>
        /// Key of the content item to upload, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key;
    }

    [Serializable]
    public class GetContentUploadUrlResult : PlayFabResultCommon
    {
        /// <summary>
        /// URL for uploading content via HTTP PUT method. The URL requires the 'x-ms-blob-type' header to have the value
        /// 'BlockBlob'. The URL will expire in approximately one hour.
        /// </summary>
        public string URL;
    }

    /// <summary>
    /// Gets the download URL for the requested report data (in CSV form). The reports available through this API call are those
    /// available in the Game Manager, in the Analytics->Reports tab.
    /// </summary>
    [Serializable]
    public class GetDataReportRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Day;
        /// <summary>
        /// Reporting month (UTC)
        /// </summary>
        public int Month;
        /// <summary>
        /// Report name
        /// </summary>
        public string ReportName;
        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Year;
    }

    [Serializable]
    public class GetDataReportResult : PlayFabResultCommon
    {
        /// <summary>
        /// The URL where the requested report can be downloaded. This can be any PlayFab generated reports. The full list of
        /// reports can be found at: https://docs.microsoft.com/en-us/gaming/playfab/features/analytics/reports/quickstart.
        /// </summary>
        public string DownloadUrl;
    }

    /// <summary>
    /// Useful for identifying titles of which the player's data will be deleted by DeleteMasterPlayer.
    /// </summary>
    [Serializable]
    public class GetPlayedTitleListRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class GetPlayedTitleListResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of titles the player has played
        /// </summary>
        public List<string> TitleIds;
    }

    /// <summary>
    /// Gets a player ID from an auth token. The token expires after 30 minutes and cannot be used to look up a player when
    /// expired.
    /// </summary>
    [Serializable]
    public class GetPlayerIdFromAuthTokenRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The auth token of the player requesting the password reset.
        /// </summary>
        public string Token;
        /// <summary>
        /// The type of auth token of the player requesting the password reset.
        /// </summary>
        public AuthTokenType TokenType;
    }

    [Serializable]
    public class GetPlayerIdFromAuthTokenResult : PlayFabResultCommon
    {
        /// <summary>
        /// The player ID from the token passed in
        /// </summary>
        public string PlayFabId;
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
    /// Player Shared Secret Keys are used for the call to Client/GetTitlePublicKey, which exchanges the shared secret for an
    /// RSA CSP blob to be used to encrypt the payload of account creation requests when that API requires a signature header.
    /// </summary>
    [Serializable]
    public class GetPlayerSharedSecretsRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetPlayerSharedSecretsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The player shared secret to use when calling Client/GetTitlePublicKey
        /// </summary>
        public List<SharedSecret> SharedSecrets;
    }

    /// <summary>
    /// Request must contain the ExportId
    /// </summary>
    [Serializable]
    public class GetPlayersInSegmentExportRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the export for the requested Segment.
        /// </summary>
        public string ExportId;
    }

    [Serializable]
    public class GetPlayersInSegmentExportResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Url from which the index file can be downloaded.
        /// </summary>
        public string IndexUrl;
        /// <summary>
        /// Shows the current status of the export
        /// </summary>
        public string State;
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
    public class GetPlayerStatisticDefinitionsRequest : PlayFabRequestCommon
    {
    }

    /// <summary>
    /// Statistics are numeric values, with each statistic in the title also generating a leaderboard. The ResetInterval defines
    /// the period of time at which the leaderboard for the statistic will automatically reset. Upon reset, the statistic
    /// updates to a new version with no values (effectively removing all players from the leaderboard). The previous version's
    /// statistic values are also archived for retrieval, if needed (see GetPlayerStatisticVersions). Statistics not created via
    /// a call to CreatePlayerStatisticDefinition by default have a VersionChangeInterval of Never, meaning they do not reset on
    /// a schedule, but they can be set to do so via a call to UpdatePlayerStatisticDefinition. Once a statistic has been reset
    /// (sometimes referred to as versioned or incremented), the previous version can still be written to for up a short,
    /// pre-defined period (currently 10 seconds), to prevent issues with levels completing around the time of the reset. Also,
    /// once reset, the historical statistics for players in the title may be retrieved using the URL specified in the version
    /// information (GetPlayerStatisticVersions). The AggregationMethod defines what action is taken when a new statistic value
    /// is submitted - always update with the new value (Last), use the highest of the old and new values (Max), use the
    /// smallest (Min), or add them together (Sum).
    /// </summary>
    [Serializable]
    public class GetPlayerStatisticDefinitionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// the player statistic definitions for the title
        /// </summary>
        public List<PlayerStatisticDefinition> Statistics;
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

    /// <summary>
    /// Statistics are numeric values, with each statistic in the title also generating a leaderboard. The information returned
    /// in the results defines the state of a specific version of a statistic, including when it was or will become the
    /// currently active version, when it will (or did) become a previous version, and its archival state if it is no longer the
    /// active version. For a statistic which has been reset, once the archival status is Complete, the full set of statistics
    /// for all players in the leaderboard for that version may be retrieved via the ArchiveDownloadUrl. Statistics which have
    /// not been reset (incremented/versioned) will only have a single version which is not scheduled to reset.
    /// </summary>
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

    /// <summary>
    /// Views the requested policy. Today, the only supported policy is 'ApiPolicy'.
    /// </summary>
    [Serializable]
    public class GetPolicyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The name of the policy to read. Only supported name is 'ApiPolicy'.
        /// </summary>
        public string PolicyName;
    }

    [Serializable]
    public class GetPolicyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The name of the policy read.
        /// </summary>
        public string PolicyName;
        /// <summary>
        /// Policy version.
        /// </summary>
        public int PolicyVersion;
        /// <summary>
        /// The statements in the requested policy.
        /// </summary>
        public List<PermissionStatement> Statements;
    }

    /// <summary>
    /// This API is designed to return publisher-specific values which can be read, but not written to, by the client. This data
    /// is shared across all titles assigned to a particular publisher, and can be used for cross-game coordination. Only titles
    /// assigned to a publisher can use this API. For more information email helloplayfab@microsoft.com. This AdminAPI call for
    /// getting title data guarantees no delay in between update and retrieval of newly set data.
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
        /// catalog version to fetch tables from. Use default catalog version if null
        /// </summary>
        public string CatalogVersion;
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

    /// <summary>
    /// Given input segment ids, return list of segments.
    /// </summary>
    [Serializable]
    public class GetSegmentsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Segment ids to filter title segments.
        /// </summary>
        public List<string> SegmentIds;
    }

    [Serializable]
    public class GetSegmentsResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// List of title segments.
        /// </summary>
        public List<SegmentModel> Segments;
    }

    /// <summary>
    /// A store contains an array of references to items defined in the catalog, along with the prices for the item, in both
    /// real world and virtual currencies. These prices act as an override to any prices defined in the catalog. In this way,
    /// the base definitions of the items may be defined in the catalog, with all associated properties, while the pricing can
    /// be set for each store, as needed. This allows for subsets of goods to be defined for different purposes (in order to
    /// simplify showing some, but not all catalog items to users, based upon different characteristics), along with unique
    /// prices. Note that all prices defined in the catalog and store definitions for the item are considered valid, and that a
    /// compromised client can be made to send a request for an item based upon any of these definitions. If no price is
    /// specified in the store for an item, the price set in the catalog should be displayed to the user.
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
    /// The result includes detail information that's specific to a CloudScript task. Only CloudScript tasks configured as "Run
    /// Cloud Script function once" will be retrieved. To get a list of task instances by task, status, or time range, use
    /// GetTaskInstances.
    /// </summary>
    [Serializable]
    public class GetTaskInstanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the requested task instance.
        /// </summary>
        public string TaskInstanceId;
    }

    /// <summary>
    /// Only the most recent 100 task instances are returned, ordered by start time descending. The results are generic basic
    /// information for task instances. To get detail information specific to each task type, use Get*TaskInstance based on its
    /// corresponding task type.
    /// </summary>
    [Serializable]
    public class GetTaskInstancesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Optional range-from filter for task instances' StartedAt timestamp.
        /// </summary>
        public DateTime? StartedAtRangeFrom;
        /// <summary>
        /// Optional range-to filter for task instances' StartedAt timestamp.
        /// </summary>
        public DateTime? StartedAtRangeTo;
        /// <summary>
        /// Optional filter for task instances that are of a specific status.
        /// </summary>
        public TaskInstanceStatus? StatusFilter;
        /// <summary>
        /// Name or ID of the task whose instances are being queried. If not specified, return all task instances that satisfy
        /// conditions set by other filters.
        /// </summary>
        public NameIdentifier TaskIdentifier;
    }

    [Serializable]
    public class GetTaskInstancesResult : PlayFabResultCommon
    {
        /// <summary>
        /// Basic status summaries of the queried task instances. Empty If no task instances meets the filter criteria. To get
        /// detailed status summary, use Get*TaskInstance API according to task type (e.g.
        /// GetActionsOnPlayersInSegmentTaskInstance).
        /// </summary>
        public List<TaskInstanceBasicSummary> Summaries;
    }

    [Serializable]
    public class GetTasksRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Provide either the task ID or the task name to get a specific task. If not specified, return all defined tasks.
        /// </summary>
        public NameIdentifier Identifier;
    }

    [Serializable]
    public class GetTasksResult : PlayFabResultCommon
    {
        /// <summary>
        /// Result tasks. Empty if there is no task found.
        /// </summary>
        public List<ScheduledTask> Tasks;
    }

    /// <summary>
    /// This API method is designed to return title specific values which can be read by the client. For example, a developer
    /// could choose to store values which modify the user experience, such as enemy spawn rates, weapon strengths, movement
    /// speeds, etc. This allows a developer to update the title without the need to create, test, and ship a new build. If an
    /// override label is specified in the request, the overrides are applied automatically and returned with the title data.
    /// Note that due to caching, there may up to a minute delay in between updating title data and a query returning the newest
    /// value.
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
    /// user's current inventory, and so will not be not included. There can be a delay of up to a half a second for inventory
    /// changes to be reflected in the GetUserInventory API response.
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

    [Serializable]
    public class GrantItemContent : PlayFabBaseModel
    {
        /// <summary>
        /// The catalog version of the item to be granted to the player
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The id of item to be granted to the player
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Quantity of the item to be granted to a player
        /// </summary>
        public int ItemQuantity;
    }

    [Serializable]
    public class GrantItemSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Item catalog id.
        /// </summary>
        public string CatelogId;
        /// <summary>
        /// Item id.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Item quantity.
        /// </summary>
        public uint Quantity;
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
    public class GrantVirtualCurrencyContent : PlayFabBaseModel
    {
        /// <summary>
        /// Amount of currency to be granted to a player
        /// </summary>
        public int CurrencyAmount;
        /// <summary>
        /// Code of the currency to be granted to a player
        /// </summary>
        public string CurrencyCode;
    }

    [Serializable]
    public class GrantVirtualCurrencySegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Virtual currency amount.
        /// </summary>
        public int Amount;
        /// <summary>
        /// Virtual currency code.
        /// </summary>
        public string CurrencyCode;
    }

    /// <summary>
    /// This operation will increment the global counter for the number of these items available. This number cannot be
    /// decremented, except by actual grants.
    /// </summary>
    [Serializable]
    public class IncrementLimitedEditionItemAvailabilityRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Amount to increase availability by.
        /// </summary>
        public int Amount;
        /// <summary>
        /// Which catalog is being updated. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The item which needs more availability.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class IncrementLimitedEditionItemAvailabilityResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class IncrementPlayerStatisticContent : PlayFabBaseModel
    {
        /// <summary>
        /// Amount(in whole number) to increase the player statistic by
        /// </summary>
        public int StatisticChangeBy;
        /// <summary>
        /// Name of the player statistic to be incremented
        /// </summary>
        public string StatisticName;
    }

    [Serializable]
    public class IncrementPlayerStatisticSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Increment value.
        /// </summary>
        public int IncrementValue;
        /// <summary>
        /// Statistic name.
        /// </summary>
        public string StatisticName;
    }

    /// <summary>
    /// Statistics are numeric values, with each statistic in the title also generating a leaderboard. When this call is made on
    /// a given statistic, this forces a reset of that statistic. Upon reset, the statistic updates to a new version with no
    /// values (effectively removing all players from the leaderboard). The previous version's statistic values are also
    /// archived for retrieval, if needed (see GetPlayerStatisticVersions). Statistics not created via a call to
    /// CreatePlayerStatisticDefinition by default have a VersionChangeInterval of Never, meaning they do not reset on a
    /// schedule, but they can be set to do so via a call to UpdatePlayerStatisticDefinition. Once a statistic has been reset
    /// (sometimes referred to as versioned or incremented), the now-previous version can still be written to for up a short,
    /// pre-defined period (currently 10 seconds), to prevent issues with levels completing around the time of the reset. Also,
    /// once reset, the historical statistics for players in the title may be retrieved using the URL specified in the version
    /// information (GetPlayerStatisticVersions).
    /// </summary>
    [Serializable]
    public class IncrementPlayerStatisticVersionRequest : PlayFabRequestCommon
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
    public class IncrementPlayerStatisticVersionResult : PlayFabResultCommon
    {
        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public PlayerStatisticVersion StatisticVersion;
    }

    [Serializable]
    public class InsightsScalingTaskParameter : PlayFabBaseModel
    {
        /// <summary>
        /// Insights Performance Level to scale to.
        /// </summary>
        public int Level;
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
    public class LastLoginDateSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Last player login date comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// Last player login date.
        /// </summary>
        public DateTime LogInDate;
    }

    [Serializable]
    public class LastLoginTimespanSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Last player login duration comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// Last player login duration.
        /// </summary>
        public double DurationInMinutes;
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
    public class LinkedUserAccountHasEmailSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Login provider comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// Login provider.
        /// </summary>
        public SegmentLoginIdentityProvider? LoginProvider;
    }

    [Serializable]
    public class LinkedUserAccountSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Login provider.
        /// </summary>
        public SegmentLoginIdentityProvider? LoginProvider;
    }

    [Serializable]
    public class ListOpenIdConnectionRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class ListOpenIdConnectionResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of Open ID Connections
        /// </summary>
        public List<OpenIdConnection> Connections;
    }

    [Serializable]
    public class ListVirtualCurrencyTypesRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class ListVirtualCurrencyTypesResult : PlayFabResultCommon
    {
        /// <summary>
        /// List of virtual currency names defined for this title
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies;
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

    [Serializable]
    public class LocationSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Segment country code.
        /// </summary>
        public SegmentCountryCode? CountryCode;
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
        GooglePlayGames,
        XboxMobileStore,
        King
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

    /// <summary>
    /// This API allows for access to details regarding a user in the PlayFab service, usually for purposes of customer support.
    /// Note that data returned may be Personally Identifying Information (PII), such as email address, and so care should be
    /// taken in how this data is stored and managed. Since this call will always return the relevant information for users who
    /// have accessed the title, the recommendation is to not store this data locally.
    /// </summary>
    [Serializable]
    public class LookupUserAccountInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Title specific username to match against existing user accounts
        /// </summary>
        public string TitleDisplayName;
        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username;
    }

    [Serializable]
    public class LookupUserAccountInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// User info for the user matching the request
        /// </summary>
        public UserAccountInfo UserInfo;
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
    public class OpenIdConnection : PlayFabBaseModel
    {
        /// <summary>
        /// The client ID given by the ID provider.
        /// </summary>
        public string ClientId;
        /// <summary>
        /// The client secret given by the ID provider.
        /// </summary>
        public string ClientSecret;
        /// <summary>
        /// A name for the connection to identify it within the title.
        /// </summary>
        public string ConnectionId;
        /// <summary>
        /// Shows if data about the connection will be loaded from the issuer's discovery document
        /// </summary>
        public bool DiscoverConfiguration;
        /// <summary>
        /// Ignore 'nonce' claim in identity tokens.
        /// </summary>
        public bool? IgnoreNonce;
        /// <summary>
        /// Information for an OpenID Connect provider.
        /// </summary>
        public OpenIdIssuerInformation IssuerInformation;
        /// <summary>
        /// Override the issuer name for user indexing and lookup.
        /// </summary>
        public string IssuerOverride;
    }

    [Serializable]
    public class OpenIdIssuerInformation : PlayFabBaseModel
    {
        /// <summary>
        /// Authorization endpoint URL to direct users to for signin.
        /// </summary>
        public string AuthorizationUrl;
        /// <summary>
        /// The URL of the issuer of the tokens. This must match the exact URL of the issuer field in tokens.
        /// </summary>
        public string Issuer;
        /// <summary>
        /// JSON Web Key Set for validating the signature of tokens.
        /// </summary>
        public object JsonWebKeySet;
        /// <summary>
        /// Token endpoint URL for code verification.
        /// </summary>
        public string TokenUrl;
    }

    [Serializable]
    public class PermissionStatement : PlayFabBaseModel
    {
        /// <summary>
        /// The action this statement effects. The only supported action is 'Execute'.
        /// </summary>
        public string Action;
        /// <summary>
        /// Additional conditions to be applied for API Resources.
        /// </summary>
        public ApiCondition ApiConditions;
        /// <summary>
        /// A comment about the statement. Intended solely for bookkeeping and debugging.
        /// </summary>
        public string Comment;
        /// <summary>
        /// The effect this statement will have. It could be either Allow or Deny
        /// </summary>
        public EffectType Effect;
        /// <summary>
        /// The principal this statement will effect. The only supported principal is '*'.
        /// </summary>
        public string Principal;
        /// <summary>
        /// The resource this statements effects. The only supported resources look like 'pfrn:api--*' for all apis, or
        /// 'pfrn:api--/Client/ConfirmPurchase' for specific apis.
        /// </summary>
        public string Resource;
    }

    [Serializable]
    public class PlayerChurnPredictionSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Comparison
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// RiskLevel
        /// </summary>
        public ChurnRiskLevel? RiskLevel;
    }

    [Serializable]
    public class PlayerChurnPredictionTimeSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Comparison
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// DurationInDays
        /// </summary>
        public double DurationInDays;
    }

    [Serializable]
    public class PlayerChurnPreviousPredictionSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Comparison
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// RiskLevel
        /// </summary>
        public ChurnRiskLevel? RiskLevel;
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
    public class PlayerStatisticDefinition : PlayFabBaseModel
    {
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod;
        /// <summary>
        /// current active version of the statistic, incremented each time the statistic resets
        /// </summary>
        public uint CurrentVersion;
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// interval at which the values of the statistic for all players are reset automatically
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval;
    }

    [Serializable]
    public class PlayerStatisticVersion : PlayFabBaseModel
    {
        /// <summary>
        /// time when the statistic version became active
        /// </summary>
        public DateTime ActivationTime;
        /// <summary>
        /// URL for the downloadable archive of player statistic values, if available
        /// </summary>
        public string ArchiveDownloadUrl;
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
        /// status of the statistic version
        /// </summary>
        public StatisticVersionStatus? Status;
        /// <summary>
        /// version of the statistic
        /// </summary>
        public uint Version;
    }

    [Serializable]
    public class PushNotificationContent : PlayFabBaseModel
    {
        /// <summary>
        /// Text of message to send.
        /// </summary>
        public string Message;
        /// <summary>
        /// Id of the push notification template.
        /// </summary>
        public string PushNotificationTemplateId;
        /// <summary>
        /// Subject of message to send (may not be displayed in all platforms)
        /// </summary>
        public string Subject;
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
    public class PushNotificationSegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Push notification template id.
        /// </summary>
        public string PushNotificationTemplateId;
    }

    [Serializable]
    public class PushNotificationSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Push notification device platform.
        /// </summary>
        public SegmentPushNotificationDevicePlatform? PushNotificationDevicePlatform;
    }

    public enum PushSetupPlatform
    {
        GCM,
        APNS,
        APNS_SANDBOX
    }

    [Serializable]
    public class RandomResultTable : PlayFabBaseModel
    {
        /// <summary>
        /// Child nodes that indicate what kind of drop table item this actually is.
        /// </summary>
        public List<ResultTableNode> Nodes;
        /// <summary>
        /// Unique name for this drop table
        /// </summary>
        public string TableId;
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

    [Serializable]
    public class RefundPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique order ID for the purchase in question.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The Reason parameter should correspond with the payment providers reason field, if they require one such as Facebook. In
        /// the case of Facebook this must match one of their refund or dispute resolution enums (See:
        /// https://developers.facebook.com/docs/payments/implementation-guide/handling-disputes-refunds)
        /// </summary>
        public string Reason;
    }

    [Serializable]
    public class RefundPurchaseResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The order's updated purchase status.
        /// </summary>
        public string PurchaseStatus;
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

    /// <summary>
    /// Virtual currencies to be removed cannot have entries in any catalog nor store for the title. Note that this operation
    /// will not remove player balances for the removed currencies; if a deleted currency is recreated at any point, user
    /// balances will be in an undefined state.
    /// </summary>
    [Serializable]
    public class RemoveVirtualCurrencyTypesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of virtual currencies to delete
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies;
    }

    /// <summary>
    /// Note that this action cannot be un-done. All statistics for this character will be deleted, removing the user from all
    /// leaderboards for the game.
    /// </summary>
    [Serializable]
    public class ResetCharacterStatisticsRequest : PlayFabRequestCommon
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
    }

    [Serializable]
    public class ResetCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Resets a player's password taking in a new password based and validating the user based off of a token sent to the
    /// playerto their email. The token expires after 30 minutes.
    /// </summary>
    [Serializable]
    public class ResetPasswordRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// The new password for the player.
        /// </summary>
        public string Password;
        /// <summary>
        /// The token of the player requesting the password reset.
        /// </summary>
        public string Token;
    }

    [Serializable]
    public class ResetPasswordResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Note that this action cannot be un-done. All statistics for this user will be deleted, removing the user from all
    /// leaderboards for the game.
    /// </summary>
    [Serializable]
    public class ResetUserStatisticsRequest : PlayFabRequestCommon
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
    public class ResetUserStatisticsResult : PlayFabResultCommon
    {
    }

    public enum ResolutionOutcome
    {
        Revoke,
        Reinstate,
        Manual
    }

    [Serializable]
    public class ResolvePurchaseDisputeRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique order ID for the purchase in question.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Enum for the desired purchase result state after notifying the payment provider. Valid values are Revoke, Reinstate and
        /// Manual. Manual will cause no change to the order state.
        /// </summary>
        public ResolutionOutcome Outcome;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// The Reason parameter should correspond with the payment providers reason field, if they require one such as Facebook. In
        /// the case of Facebook this must match one of their refund or dispute resolution enums (See:
        /// https://developers.facebook.com/docs/payments/implementation-guide/handling-disputes-refunds)
        /// </summary>
        public string Reason;
    }

    [Serializable]
    public class ResolvePurchaseDisputeResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The order's updated purchase status.
        /// </summary>
        public string PurchaseStatus;
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
    /// The returned task instance ID can be used to query for task execution status.
    /// </summary>
    [Serializable]
    public class RunTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Provide either the task ID or the task name to run a task.
        /// </summary>
        public NameIdentifier Identifier;
    }

    [Serializable]
    public class RunTaskResult : PlayFabResultCommon
    {
        /// <summary>
        /// ID of the task instance that is started. This can be used in Get*TaskInstance (e.g. GetCloudScriptTaskInstance) API call
        /// to retrieve status for the task instance.
        /// </summary>
        public string TaskInstanceId;
    }

    [Serializable]
    public class ScheduledTask : PlayFabBaseModel
    {
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// UTC time of last run
        /// </summary>
        public DateTime? LastRunTime;
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// UTC time of next run
        /// </summary>
        public DateTime? NextRunTime;
        /// <summary>
        /// Task parameter. Different types of task have different parameter structure. See each task type's create API
        /// documentation for the details.
        /// </summary>
        public object Parameter;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
        /// <summary>
        /// ID of the task
        /// </summary>
        public string TaskId;
        /// <summary>
        /// Task type.
        /// </summary>
        public ScheduledTaskType? Type;
    }

    public enum ScheduledTaskType
    {
        CloudScript,
        ActionsOnPlayerSegment,
        CloudScriptAzureFunctions,
        InsightsScheduledScaling
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

    [Serializable]
    public class SegmentAndDefinition : PlayFabBaseModel
    {
        /// <summary>
        /// Filter property for ad campaign filter.
        /// </summary>
        public AdCampaignSegmentFilter AdCampaignFilter;
        /// <summary>
        /// property for all player filter.
        /// </summary>
        public AllPlayersSegmentFilter AllPlayersFilter;
        /// <summary>
        /// Filter property for player churn risk level.
        /// </summary>
        public ChurnPredictionSegmentFilter ChurnPredictionFilter;
        /// <summary>
        /// Filter property for first login date.
        /// </summary>
        public FirstLoginDateSegmentFilter FirstLoginDateFilter;
        /// <summary>
        /// Filter property for first login timespan.
        /// </summary>
        public FirstLoginTimespanSegmentFilter FirstLoginFilter;
        /// <summary>
        /// Filter property for last login date.
        /// </summary>
        public LastLoginDateSegmentFilter LastLoginDateFilter;
        /// <summary>
        /// Filter property for last login timespan.
        /// </summary>
        public LastLoginTimespanSegmentFilter LastLoginFilter;
        /// <summary>
        /// Filter property for linked in user account.
        /// </summary>
        public LinkedUserAccountSegmentFilter LinkedUserAccountFilter;
        /// <summary>
        /// Filter property for linked in user account has email.
        /// </summary>
        public LinkedUserAccountHasEmailSegmentFilter LinkedUserAccountHasEmailFilter;
        /// <summary>
        /// Filter property for location.
        /// </summary>
        public LocationSegmentFilter LocationFilter;
        /// <summary>
        /// Filter property for current player churn value.
        /// </summary>
        public PlayerChurnPredictionSegmentFilter PlayerChurnPredictionFilter;
        /// <summary>
        /// Filter property for player churn timespan.
        /// </summary>
        public PlayerChurnPredictionTimeSegmentFilter PlayerChurnPredictionTimeFilter;
        /// <summary>
        /// Filter property for previous player churn value.
        /// </summary>
        public PlayerChurnPreviousPredictionSegmentFilter PlayerChurnPreviousPredictionFilter;
        /// <summary>
        /// Filter property for push notification.
        /// </summary>
        public PushNotificationSegmentFilter PushNotificationFilter;
        /// <summary>
        /// Filter property for statistics.
        /// </summary>
        public StatisticSegmentFilter StatisticFilter;
        /// <summary>
        /// Filter property for tags.
        /// </summary>
        public TagSegmentFilter TagFilter;
        /// <summary>
        /// Filter property for total value to date in USD.
        /// </summary>
        public TotalValueToDateInUSDSegmentFilter TotalValueToDateInUSDFilter;
        /// <summary>
        /// Filter property for user origination.
        /// </summary>
        public UserOriginationSegmentFilter UserOriginationFilter;
        /// <summary>
        /// Filter property for value to date.
        /// </summary>
        public ValueToDateSegmentFilter ValueToDateFilter;
        /// <summary>
        /// Filter property for virtual currency.
        /// </summary>
        public VirtualCurrencyBalanceSegmentFilter VirtualCurrencyBalanceFilter;
    }

    public enum SegmentCountryCode
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

    public enum SegmentCurrency
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

    public enum SegmentFilterComparison
    {
        GreaterThan,
        LessThan,
        EqualTo,
        NotEqualTo,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Exists,
        Contains,
        NotContains
    }

    public enum SegmentLoginIdentityProvider
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
    public class SegmentModel : PlayFabBaseModel
    {
        /// <summary>
        /// Segment description.
        /// </summary>
        public string Description;
        /// <summary>
        /// Segment actions for current entered segment players.
        /// </summary>
        public List<SegmentTrigger> EnteredSegmentActions;
        /// <summary>
        /// Segment last updated date time.
        /// </summary>
        public DateTime LastUpdateTime;
        /// <summary>
        /// Segment actions for current left segment players.
        /// </summary>
        public List<SegmentTrigger> LeftSegmentActions;
        /// <summary>
        /// Segment name.
        /// </summary>
        public string Name;
        /// <summary>
        /// Segment id in hex.
        /// </summary>
        public string SegmentId;
        /// <summary>
        /// Segment or definitions. This includes segment and definitions and filters.
        /// </summary>
        public List<SegmentOrDefinition> SegmentOrDefinitions;
    }

    [Serializable]
    public class SegmentOrDefinition : PlayFabBaseModel
    {
        /// <summary>
        /// List of segment and definitions.
        /// </summary>
        public List<SegmentAndDefinition> SegmentAndDefinitions;
    }

    public enum SegmentPushNotificationDevicePlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    [Serializable]
    public class SegmentTrigger : PlayFabBaseModel
    {
        /// <summary>
        /// Add inventory item v2 segment trigger action.
        /// </summary>
        public AddInventoryItemsV2SegmentAction AddInventoryItemsV2Action;
        /// <summary>
        /// Ban player segment trigger action.
        /// </summary>
        public BanPlayerSegmentAction BanPlayerAction;
        /// <summary>
        /// Delete inventory item v2 segment trigger action.
        /// </summary>
        public DeleteInventoryItemsV2SegmentAction DeleteInventoryItemsV2Action;
        /// <summary>
        /// Delete player segment trigger action.
        /// </summary>
        public DeletePlayerSegmentAction DeletePlayerAction;
        /// <summary>
        /// Delete player statistic segment trigger action.
        /// </summary>
        public DeletePlayerStatisticSegmentAction DeletePlayerStatisticAction;
        /// <summary>
        /// Email notification segment trigger action.
        /// </summary>
        public EmailNotificationSegmentAction EmailNotificationAction;
        /// <summary>
        /// Execute azure function segment trigger action.
        /// </summary>
        public ExecuteAzureFunctionSegmentAction ExecuteAzureFunctionAction;
        /// <summary>
        /// Execute cloud script segment trigger action.
        /// </summary>
        public ExecuteCloudScriptSegmentAction ExecuteCloudScriptAction;
        /// <summary>
        /// Grant item segment trigger action.
        /// </summary>
        public GrantItemSegmentAction GrantItemAction;
        /// <summary>
        /// Grant virtual currency segment trigger action.
        /// </summary>
        public GrantVirtualCurrencySegmentAction GrantVirtualCurrencyAction;
        /// <summary>
        /// Increment player statistic segment trigger action.
        /// </summary>
        public IncrementPlayerStatisticSegmentAction IncrementPlayerStatisticAction;
        /// <summary>
        /// Push notification segment trigger action.
        /// </summary>
        public PushNotificationSegmentAction PushNotificationAction;
        /// <summary>
        /// Subtract inventory item v2 segment trigger action.
        /// </summary>
        public SubtractInventoryItemsV2SegmentAction SubtractInventoryItemsV2Action;
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
    }

    [Serializable]
    public class SendAccountRecoveryEmailResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SendEmailContent : PlayFabBaseModel
    {
        /// <summary>
        /// The email template id of the email template to send.
        /// </summary>
        public string EmailTemplateId;
    }

    /// <summary>
    /// This API lets developers set overrides for membership expirations, independent of any subscriptions setting it.
    /// </summary>
    [Serializable]
    public class SetMembershipOverrideRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Expiration time for the membership in DateTime format, will override any subscription expirations.
        /// </summary>
        public DateTime ExpirationTime;
        /// <summary>
        /// Id of the membership to apply the override expiration date to.
        /// </summary>
        public string MembershipId;
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class SetMembershipOverrideResult : PlayFabResultCommon
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

    [Serializable]
    public class SetPublishedRevisionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Revision to make the current published revision
        /// </summary>
        public int Revision;
        /// <summary>
        /// Version number
        /// </summary>
        public int Version;
    }

    [Serializable]
    public class SetPublishedRevisionResult : PlayFabResultCommon
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
    /// Will set the given key values in the specified override or the primary title data based on whether the label is provided
    /// or not.
    /// </summary>
    [Serializable]
    public class SetTitleDataAndOverridesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of titleData key-value pairs to set/delete. Use an empty value to delete an existing key; use a non-empty value to
        /// create/update a key.
        /// </summary>
        public List<TitleDataKeyValue> KeyValues;
        /// <summary>
        /// Name of the override.
        /// </summary>
        public string OverrideLabel;
    }

    [Serializable]
    public class SetTitleDataAndOverridesResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// This operation is additive. If a Key does not exist in the current dataset, it will be added with the specified Value.
    /// If it already exists, the Value for that key will be overwritten with the new Value.
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

    /// <summary>
    /// When using the Apple Push Notification service (APNS) or the development version (APNS_SANDBOX), the APNS Private Key
    /// should be used as the Credential in this call. With Google Cloud Messaging (GCM), the Android API Key should be used.
    /// The current ARN (if one exists) can be overwritten by setting the OverwriteOldARN boolean to true.
    /// </summary>
    [Serializable]
    public class SetupPushNotificationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Credential is the Private Key for APNS/APNS_SANDBOX, and the API Key for GCM
        /// </summary>
        public string Credential;
        /// <summary>
        /// for APNS, this is the PlatformPrincipal (SSL Certificate)
        /// </summary>
        public string Key;
        /// <summary>
        /// This field is deprecated and any usage of this will cause the API to fail.
        /// </summary>
        public string Name;
        /// <summary>
        /// replace any existing ARN with the newly generated one. If this is set to false, an error will be returned if
        /// notifications have already setup for this platform.
        /// </summary>
        public bool OverwriteOldARN;
        /// <summary>
        /// supported notification platforms are Apple Push Notification Service (APNS and APNS_SANDBOX) for iOS and Google Cloud
        /// Messaging (GCM) for Android
        /// </summary>
        public PushSetupPlatform Platform;
    }

    [Serializable]
    public class SetupPushNotificationResult : PlayFabResultCommon
    {
        /// <summary>
        /// Amazon Resource Name for the created notification topic.
        /// </summary>
        public string ARN;
    }

    [Serializable]
    public class SharedSecret : PlayFabBaseModel
    {
        /// <summary>
        /// Flag to indicate if this key is disabled
        /// </summary>
        public bool Disabled;
        /// <summary>
        /// Friendly name for this key
        /// </summary>
        public string FriendlyName;
        /// <summary>
        /// The player shared secret to use when calling Client/GetTitlePublicKey
        /// </summary>
        public string SecretKey;
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

    public enum StatisticAggregationMethod
    {
        Last,
        Min,
        Max,
        Sum
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

    public enum StatisticResetIntervalOption
    {
        Never,
        Hour,
        Day,
        Week,
        Month
    }

    [Serializable]
    public class StatisticSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Statistic filter comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// Statistic filter value.
        /// </summary>
        public string FilterValue;
        /// <summary>
        /// Statistic name.
        /// </summary>
        public string Name;
        /// <summary>
        /// Use current version of statistic?
        /// </summary>
        public bool? UseCurrentVersion;
        /// <summary>
        /// Statistic version.
        /// </summary>
        public int? Version;
    }

    public enum StatisticVersionArchivalStatus
    {
        NotScheduled,
        Scheduled,
        Queued,
        InProgress,
        Complete
    }

    public enum StatisticVersionStatus
    {
        Active,
        SnapshotPending,
        Snapshot,
        ArchivalPending,
        Archived
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
    public class SubtractInventoryItemsV2SegmentAction : PlayFabBaseModel
    {
        /// <summary>
        /// Amount of the item to removed from the player
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The collection id for where the item will be removed from the player inventory
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The duration in seconds to be removed from the subscription in the players inventory
        /// </summary>
        public int? DurationInSeconds;
        /// <summary>
        /// The id of item to be removed from the player
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The stack id for where the item will be removed from the player inventory
        /// </summary>
        public string StackId;
    }

    [Serializable]
    public class SubtractInventoryItemV2Content : PlayFabBaseModel
    {
        /// <summary>
        /// Amount of the item to removed from the player
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The collection id for where the item will be removed from the player inventory
        /// </summary>
        public string CollectionId;
        /// <summary>
        /// The duration in seconds to be removed from the subscription in the players inventory
        /// </summary>
        public int? DurationInSeconds;
        /// <summary>
        /// The id of item to be removed from the player
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The stack id for where the item will be removed from the player inventory
        /// </summary>
        public string StackId;
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

    [Serializable]
    public class TagSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Tag comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// Tag value.
        /// </summary>
        public string TagValue;
    }

    [Serializable]
    public class TaskInstanceBasicSummary : PlayFabBaseModel
    {
        /// <summary>
        /// UTC timestamp when the task completed.
        /// </summary>
        public DateTime? CompletedAt;
        /// <summary>
        /// Error message for last processing attempt, if an error occured.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// Estimated time remaining in seconds.
        /// </summary>
        public double? EstimatedSecondsRemaining;
        /// <summary>
        /// Progress represented as percentage.
        /// </summary>
        public double? PercentComplete;
        /// <summary>
        /// If manually scheduled, ID of user who scheduled the task.
        /// </summary>
        public string ScheduledByUserId;
        /// <summary>
        /// UTC timestamp when the task started.
        /// </summary>
        public DateTime StartedAt;
        /// <summary>
        /// Current status of the task instance.
        /// </summary>
        public TaskInstanceStatus? Status;
        /// <summary>
        /// Identifier of the task this instance belongs to.
        /// </summary>
        public NameIdentifier TaskIdentifier;
        /// <summary>
        /// ID of the task instance.
        /// </summary>
        public string TaskInstanceId;
        /// <summary>
        /// Type of the task.
        /// </summary>
        public ScheduledTaskType? Type;
    }

    public enum TaskInstanceStatus
    {
        Succeeded,
        Starting,
        InProgress,
        Failed,
        Aborted,
        Stalled
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
    public class TitleDataKeyValue : PlayFabBaseModel
    {
        /// <summary>
        /// Key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same
        /// name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key;
        /// <summary>
        /// New value to set. Set to null to remove a value
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class TotalValueToDateInUSDSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Total value to date USD amount.
        /// </summary>
        public string Amount;
        /// <summary>
        /// Total value to date USD comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
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
        /// <summary>
        /// The updated family type of the user that should be included in the ban. Null for no change.
        /// </summary>
        public UserFamilyType? UserFamilyType;
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
    /// When used for SetCatalogItems, this operation is not additive. Using it will cause the indicated catalog version to be
    /// created from scratch. If there is an existing catalog with the version number in question, it will be deleted and
    /// replaced with only the items specified in this call. When used for UpdateCatalogItems, this operation is additive. Items
    /// with ItemId values not currently in the catalog will be added, while those with ItemId values matching items currently
    /// in the catalog will overwrite those items with the given values.
    /// </summary>
    [Serializable]
    public class UpdateCatalogItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of catalog items to be submitted. Note that while CatalogItem has a parameter for CatalogVersion, it is not
        /// required and ignored in this call.
        /// </summary>
        public List<CatalogItem> Catalog;
        /// <summary>
        /// Which catalog is being updated. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Should this catalog be set as the default catalog. Defaults to true. If there is currently no default catalog, this will
        /// always set it.
        /// </summary>
        public bool? SetAsDefaultCatalog;
    }

    [Serializable]
    public class UpdateCatalogItemsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateCloudScriptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// PlayFab user ID of the developer initiating the request.
        /// </summary>
        public string DeveloperPlayFabId;
        /// <summary>
        /// List of Cloud Script files to upload to create the new revision. Must have at least one file.
        /// </summary>
        public List<CloudScriptFile> Files;
        /// <summary>
        /// Immediately publish the new revision
        /// </summary>
        public bool Publish;
    }

    [Serializable]
    public class UpdateCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// New revision number created
        /// </summary>
        public int Revision;
        /// <summary>
        /// Cloud Script version updated
        /// </summary>
        public int Version;
    }

    [Serializable]
    public class UpdateOpenIdConnectionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The client ID given by the ID provider.
        /// </summary>
        public string ClientId;
        /// <summary>
        /// The client secret given by the ID provider.
        /// </summary>
        public string ClientSecret;
        /// <summary>
        /// A name for the connection that identifies it within the title.
        /// </summary>
        public string ConnectionId;
        /// <summary>
        /// Ignore 'nonce' claim in identity tokens.
        /// </summary>
        public bool? IgnoreNonce;
        /// <summary>
        /// The issuer URL or discovery document URL to read issuer information from
        /// </summary>
        public string IssuerDiscoveryUrl;
        /// <summary>
        /// Manually specified information for an OpenID Connect issuer.
        /// </summary>
        public OpenIdIssuerInformation IssuerInformation;
        /// <summary>
        /// Override the issuer name for user indexing and lookup.
        /// </summary>
        public string IssuerOverride;
    }

    /// <summary>
    /// Player Shared Secret Keys are used for the call to Client/GetTitlePublicKey, which exchanges the shared secret for an
    /// RSA CSP blob to be used to encrypt the payload of account creation requests when that API requires a signature header.
    /// </summary>
    [Serializable]
    public class UpdatePlayerSharedSecretRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Disable or Enable this key
        /// </summary>
        public bool Disabled;
        /// <summary>
        /// Friendly name for this key
        /// </summary>
        public string FriendlyName;
        /// <summary>
        /// The shared secret key to update
        /// </summary>
        public string SecretKey;
    }

    [Serializable]
    public class UpdatePlayerSharedSecretResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Statistics are numeric values, with each statistic in the title also generating a leaderboard. The ResetInterval enables
    /// automatically resetting leaderboards on a specified interval. Upon reset, the statistic updates to a new version with no
    /// values (effectively removing all players from the leaderboard). The previous version's statistic values are also
    /// archived for retrieval, if needed (see GetPlayerStatisticVersions). Statistics not created via a call to
    /// CreatePlayerStatisticDefinition by default have a VersionChangeInterval of Never, meaning they do not reset on a
    /// schedule, but they can be set to do so via a call to UpdatePlayerStatisticDefinition. Once a statistic has been reset
    /// (sometimes referred to as versioned or incremented), the now-previous version can still be written to for up a short,
    /// pre-defined period (currently 10 seconds), to prevent issues with levels completing around the time of the reset. Also,
    /// once reset, the historical statistics for players in the title may be retrieved using the URL specified in the version
    /// information (GetPlayerStatisticVersions). The AggregationMethod determines what action is taken when a new statistic
    /// value is submitted - always update with the new value (Last), use the highest of the old and new values (Max), use the
    /// smallest (Min), or add them together (Sum).
    /// </summary>
    [Serializable]
    public class UpdatePlayerStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod;
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// interval at which the values of the statistic for all players are reset (changes are effective at the next occurance of
        /// the new interval boundary)
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval;
    }

    [Serializable]
    public class UpdatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// updated statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic;
    }

    /// <summary>
    /// Updates permissions for your title. Policies affect what is allowed to happen on your title. Your policy is a collection
    /// of statements that, together, govern particular area for your title. Today, the only allowed policy is called
    /// 'ApiPolicy' and it governs what API calls are allowed. To verify that you have the latest version always download the
    /// current policy from GetPolicy before uploading a new policy. PlayFab updates the base policy periodically and will
    /// automatically apply it to the uploaded policy. Overwriting the combined policy blindly may result in unexpected API
    /// errors.
    /// </summary>
    [Serializable]
    public class UpdatePolicyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Whether to overwrite or append to the existing policy.
        /// </summary>
        public bool OverwritePolicy;
        /// <summary>
        /// The name of the policy being updated. Only supported name is 'ApiPolicy'
        /// </summary>
        public string PolicyName;
        /// <summary>
        /// Version of the policy to update. Must be the latest (as returned by GetPolicy).
        /// </summary>
        public int PolicyVersion;
        /// <summary>
        /// The new statements to include in the policy.
        /// </summary>
        public List<PermissionStatement> Statements;
    }

    [Serializable]
    public class UpdatePolicyResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The name of the policy that was updated.
        /// </summary>
        public string PolicyName;
        /// <summary>
        /// The statements included in the new version of the policy.
        /// </summary>
        public List<PermissionStatement> Statements;
    }

    /// <summary>
    /// This operation is additive. Tables with TableId values not currently defined will be added, while those with TableId
    /// values matching Tables currently in the catalog will be overwritten with the given values.
    /// </summary>
    [Serializable]
    public class UpdateRandomResultTablesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// which catalog is being updated. If null, update the current default catalog version
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that
        /// table, while any others will be added to the available set)
        /// </summary>
        public List<RandomResultTable> Tables;
    }

    [Serializable]
    public class UpdateRandomResultTablesResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Update segment properties data which are planning to update
    /// </summary>
    [Serializable]
    public class UpdateSegmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Segment model with all of the segment properties data.
        /// </summary>
        public SegmentModel SegmentModel;
    }

    [Serializable]
    public class UpdateSegmentResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage;
        /// <summary>
        /// Segment id.
        /// </summary>
        public string SegmentId;
    }

    /// <summary>
    /// When used for SetStoreItems, this operation is not additive. Using it will cause the indicated virtual store to be
    /// created from scratch. If there is an existing store with the same storeId, it will be deleted and replaced with only the
    /// items specified in this call. When used for UpdateStoreItems, this operation is additive. Items with ItemId values not
    /// currently in the store will be added, while those with ItemId values matching items currently in the catalog will
    /// overwrite those items with the given values. In both cases, a store contains an array of references to items defined in
    /// the catalog, along with the prices for the item, in both real world and virtual currencies. These prices act as an
    /// override to any prices defined in the catalog. In this way, the base definitions of the items may be defined in the
    /// catalog, with all associated properties, while the pricing can be set for each store, as needed. This allows for subsets
    /// of goods to be defined for different purposes (in order to simplify showing some, but not all catalog items to users,
    /// based upon different characteristics), along with unique prices. Note that all prices defined in the catalog and store
    /// definitions for the item are considered valid, and that a compromised client can be made to send a request for an item
    /// based upon any of these definitions. If no price is specified in the store for an item, the price set in the catalog
    /// should be displayed to the user.
    /// </summary>
    [Serializable]
    public class UpdateStoreItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the store to update. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Additional data about the store
        /// </summary>
        public StoreMarketingModel MarketingData;
        /// <summary>
        /// Array of store items - references to catalog items, with specific pricing - to be added
        /// </summary>
        public List<StoreItem> Store;
        /// <summary>
        /// Unique identifier for the store which is to be updated
        /// </summary>
        public string StoreId;
    }

    [Serializable]
    public class UpdateStoreItemsResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Note that when calling this API, all properties of the task have to be provided, including properties that you do not
    /// want to change. Parameters not specified would be set to default value. If the task name in the update request is new, a
    /// task rename operation will be executed before updating other fields of the task. WARNING: Renaming of a task may break
    /// logics where the task name is used as an identifier.
    /// </summary>
    [Serializable]
    public class UpdateTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Specify either the task ID or the name of the task to be updated.
        /// </summary>
        public NameIdentifier Identifier;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Parameter object specific to the task type. See each task type's create API documentation for details.
        /// </summary>
        public object Parameter;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
        /// <summary>
        /// Task type.
        /// </summary>
        public ScheduledTaskType Type;
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
    /// In addition to the PlayFab username, titles can make use of a DisplayName which is also a unique identifier, but
    /// specific to the title. This allows for unique names which more closely match the theme or genre of a title, for example.
    /// This API enables changing that name, whether due to a customer request, an offensive name choice, etc.
    /// </summary>
    [Serializable]
    public class UpdateUserTitleDisplayNameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The optional custom tags associated with the request (e.g. build number, external trace identifiers, etc.).
        /// </summary>
        public Dictionary<string,string> CustomTags;
        /// <summary>
        /// New title display name for the user - must be between 3 and 25 characters
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// PlayFab unique identifier of the user whose title specific display name is to be changed
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class UpdateUserTitleDisplayNameResult : PlayFabResultCommon
    {
        /// <summary>
        /// current title display name for the user (this will be the original display name if the rename attempt failed)
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

    public enum UserFamilyType
    {
        None,
        Xbox,
        Steam
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
        GooglePlayGames,
        XboxMobileStore,
        King
    }

    [Serializable]
    public class UserOriginationSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// User login provider.
        /// </summary>
        public SegmentLoginIdentityProvider? LoginProvider;
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
    public class ValueToDateSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Value to date amount.
        /// </summary>
        public string Amount;
        /// <summary>
        /// Value to date comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// Currency using for filter.
        /// </summary>
        public SegmentCurrency? Currency;
    }

    [Serializable]
    public class VirtualCurrencyBalanceSegmentFilter : PlayFabBaseModel
    {
        /// <summary>
        /// Total amount.
        /// </summary>
        public int Amount;
        /// <summary>
        /// Amount comparison.
        /// </summary>
        public SegmentFilterComparison? Comparison;
        /// <summary>
        /// Currency code.
        /// </summary>
        public string CurrencyCode;
    }

    [Serializable]
    public class VirtualCurrencyData : PlayFabBaseModel
    {
        /// <summary>
        /// unique two-character identifier for this currency type (e.g.: "CC")
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// friendly name to show in the developer portal, reports, etc.
        /// </summary>
        public string DisplayName;
        /// <summary>
        /// amount to automatically grant users upon first login to the title
        /// </summary>
        public int? InitialDeposit;
        /// <summary>
        /// maximum amount to which the currency will recharge (cannot exceed MaxAmount, but can be less)
        /// </summary>
        public int? RechargeMax;
        /// <summary>
        /// rate at which the currency automatically be added to over time, in units per day (24 hours)
        /// </summary>
        public int? RechargeRate;
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
}
#endif
