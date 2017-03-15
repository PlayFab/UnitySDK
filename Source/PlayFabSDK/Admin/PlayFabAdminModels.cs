#if ENABLE_PLAYFABADMIN_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AdminModels
{
    [Serializable]
    public class AbortTaskInstanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of a task instance that is being aborted.
        /// </summary>
        public string TaskInstanceId;
    }

    [Serializable]
    public class ActionsOnPlayersInSegmentTaskParameter
    {
        /// <summary>
        /// ID of the segment to perform actions on.
        /// </summary>
        public string SegmentId;
        /// <summary>
        /// ID of the action to perform on each player in segment.
        /// </summary>
        public string ActionId;
    }

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
    public class AddNewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Time this news was published. If not set, defaults to now.
        /// </summary>
        public DateTime? Timestamp;
        /// <summary>
        /// Title (headline) of the news item
        /// </summary>
        public string Title;
        /// <summary>
        /// Body text of the news
        /// </summary>
        public string Body;
    }

    [Serializable]
    public class AddNewsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique id of the new news item
        /// </summary>
        public string NewsId;
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
    public class AddServerBuildRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier for the build executable
        /// </summary>
        public string BuildId;
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;
        /// <summary>
        /// server host regions in which this build should be running and available
        /// </summary>
        public List<Region> ActiveRegions;
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;
    }

    [Serializable]
    public class AddServerBuildResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId;
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions;
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;
        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        public GameBuildStatus? Status;
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
    public class AddVirtualCurrencyTypesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of virtual currencies and their initial deposits (the amount a user is granted when signing in for the first time) to the title
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies;
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

    [Serializable]
    public class BlankResult : PlayFabResultCommon
    {
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
    public class CloudScriptFile
    {
        /// <summary>
        /// Name of the javascript file. These names are not used internally by the server, they are only for developer organizational purposes.
        /// </summary>
        public string Filename;
        /// <summary>
        /// Contents of the Cloud Script javascript. Must be string-escaped javascript.
        /// </summary>
        public string FileContents;
    }

    [Serializable]
    public class CloudScriptTaskParameter
    {
        /// <summary>
        /// Name of the CloudScript function to execute.
        /// </summary>
        public string FunctionName;
        /// <summary>
        /// Argument to pass to the CloudScript function.
        /// </summary>
        public object Argument;
    }

    [Serializable]
    public class CloudScriptTaskSummary
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
        /// Result of CloudScript execution
        /// </summary>
        public ExecuteCloudScriptResult Result;
    }

    [Serializable]
    public class CloudScriptVersionStatus
    {
        /// <summary>
        /// Version number
        /// </summary>
        public int Version;
        /// <summary>
        /// Published code revision for this Cloud Script version
        /// </summary>
        public int PublishedRevision;
        /// <summary>
        /// Most recent revision for this Cloud Script version
        /// </summary>
        public int LatestRevision;
    }

    [Serializable]
    public class ContentInfo
    {
        /// <summary>
        /// Key of the content
        /// </summary>
        public string Key;
        /// <summary>
        /// Size of the content in bytes
        /// </summary>
        public uint Size;
        /// <summary>
        /// Last modified time
        /// </summary>
        public DateTime LastModified;
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
    public class CreateActionsOnPlayerSegmentTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Task details related to segment and action
        /// </summary>
        public ActionsOnPlayersInSegmentTaskParameter Parameter;
    }

    [Serializable]
    public class CreateCloudScriptTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Task details related to CloudScript
        /// </summary>
        public CloudScriptTaskParameter Parameter;
    }

    [Serializable]
    public class CreatePlayerStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// interval at which the values of the statistic for all players are reset (resets begin at the next interval boundary)
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval;
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod;
    }

    [Serializable]
    public class CreatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// created statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic;
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
    public class DeleteStoreRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// catalog version of the store to delete. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// unqiue identifier for the store which is to be deleted
        /// </summary>
        public string StoreId;
    }

    [Serializable]
    public class DeleteStoreResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specify either the task ID or the name of task to be deleted.
        /// </summary>
        public NameIdentifier Identifier;
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

    public enum EffectType
    {
        Allow,
        Deny
    }

    [Serializable]
    public class EmptyResult : PlayFabResultCommon
    {
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

    public enum GameBuildStatus
    {
        Available,
        Validating,
        InvalidBuildPackage,
        Processing,
        FailedToProcess
    }

    [Serializable]
    public class GameModeInfo
    {
        /// <summary>
        /// specific game mode type
        /// </summary>
        public string Gamemode;
        /// <summary>
        /// minimum user count required for this Game Server Instance to continue (usually 1)
        /// </summary>
        public uint MinPlayerCount;
        /// <summary>
        /// maximum user count a specific Game Server Instance can support
        /// </summary>
        public uint MaxPlayerCount;
        /// <summary>
        /// whether to start as an open session, meaning that players can matchmake into it (defaults to true)
        /// </summary>
        public bool? StartOpen;
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
    public class GetActionsOnPlayersInSegmentTaskInstanceResult : PlayFabResultCommon
    {
        /// <summary>
        /// Status summary of the actions-on-players-in-segment task instance
        /// </summary>
        public ActionsOnPlayersInSegmentTaskSummary Summary;
        /// <summary>
        /// Parameter of this task instance
        /// </summary>
        public ActionsOnPlayersInSegmentTaskParameter Parameter;
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
    public class GetCloudScriptRevisionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Version number. If left null, defaults to the latest version
        /// </summary>
        public int? Version;
        /// <summary>
        /// Revision number. If left null, defaults to the latest revision
        /// </summary>
        public int? Revision;
    }

    [Serializable]
    public class GetCloudScriptRevisionResult : PlayFabResultCommon
    {
        /// <summary>
        /// Version number.
        /// </summary>
        public int Version;
        /// <summary>
        /// Revision number.
        /// </summary>
        public int Revision;
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
    }

    [Serializable]
    public class GetCloudScriptTaskInstanceResult : PlayFabResultCommon
    {
        /// <summary>
        /// Status summary of the CloudScript task instance
        /// </summary>
        public CloudScriptTaskSummary Summary;
        /// <summary>
        /// Parameter of this task instance
        /// </summary>
        public CloudScriptTaskParameter Parameter;
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
        /// Limits the response to keys that begin with the specified prefix. You can use prefixes to list contents under a folder, or for a specified version, etc.
        /// </summary>
        public string Prefix;
    }

    [Serializable]
    public class GetContentListResult : PlayFabResultCommon
    {
        /// <summary>
        /// Number of content items returned. We currently have a maximum of 1000 items limit.
        /// </summary>
        public int ItemCount;
        /// <summary>
        /// The total size of listed contents in bytes.
        /// </summary>
        public uint TotalSize;
        /// <summary>
        /// List of content items.
        /// </summary>
        public List<ContentInfo> Contents;
    }

    [Serializable]
    public class GetContentUploadUrlRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Key of the content item to upload, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key;
        /// <summary>
        /// A standard MIME type describing the format of the contents. The same MIME type has to be set in the header when uploading the content. If not specified, the MIME type is 'binary/octet-stream' by default.
        /// </summary>
        public string ContentType;
    }

    [Serializable]
    public class GetContentUploadUrlResult : PlayFabResultCommon
    {
        /// <summary>
        /// URL for uploading content via HTTP PUT method. The URL will expire in 1 hour.
        /// </summary>
        public string URL;
    }

    [Serializable]
    public class GetDataReportRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Report name
        /// </summary>
        public string ReportName;
        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Year;
        /// <summary>
        /// Reporting month (UTC)
        /// </summary>
        public int Month;
        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Day;
    }

    [Serializable]
    public class GetDataReportResult : PlayFabResultCommon
    {
        /// <summary>
        /// The URL where the requested report can be downloaded.
        /// </summary>
        public string DownloadUrl;
    }

    [Serializable]
    public class GetMatchmakerGameInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the lobby for which info is being requested
        /// </summary>
        public string LobbyId;
    }

    [Serializable]
    public class GetMatchmakerGameInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier of the lobby 
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// unique identifier of the Game Server Instance for this lobby
        /// </summary>
        public string TitleId;
        /// <summary>
        /// time when the Game Server Instance was created
        /// </summary>
        public DateTime StartTime;
        /// <summary>
        /// time when Game Server Instance is currently scheduled to end
        /// </summary>
        public DateTime? EndTime;
        /// <summary>
        /// game mode for this Game Server Instance
        /// </summary>
        public string Mode;
        /// <summary>
        /// version identifier of the game server executable binary being run
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// region in which the Game Server Instance is running
        /// </summary>
        public Region? Region;
        /// <summary>
        /// array of unique PlayFab identifiers for users currently connected to this Game Server Instance
        /// </summary>
        public List<string> Players;
        /// <summary>
        /// IP address for this Game Server Instance
        /// </summary>
        public string ServerAddress;
        /// <summary>
        /// communication port for this Game Server Instance
        /// </summary>
        public uint ServerPort;
    }

    [Serializable]
    public class GetMatchmakerGameModesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// previously uploaded build version for which game modes are being requested
        /// </summary>
        public string BuildVersion;
    }

    [Serializable]
    public class GetMatchmakerGameModesResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of game modes available for the specified build
        /// </summary>
        public List<GameModeInfo> GameModes;
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
    public class GetPlayerStatisticDefinitionsRequest : PlayFabRequestCommon
    {
    }

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
        /// The statements in the requested policy.
        /// </summary>
        public List<PermissionStatement> Statements;
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
    public class GetServerBuildInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the previously uploaded build executable for which information is being requested
        /// </summary>
        public string BuildId;
    }

    /// <summary>
    /// Information about a particular server build
    /// </summary>
    [Serializable]
    public class GetServerBuildInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId;
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions;
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;
        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        public GameBuildStatus? Status;
        /// <summary>
        /// error message, if any, about this build
        /// </summary>
        public string ErrorMessage;
    }

    [Serializable]
    public class GetServerBuildUploadURLRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the game server build to upload
        /// </summary>
        public string BuildId;
    }

    [Serializable]
    public class GetServerBuildUploadURLResult : PlayFabResultCommon
    {
        /// <summary>
        /// pre-authorized URL for uploading the game server build package
        /// </summary>
        public string URL;
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
    public class GetTaskInstanceRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// ID of the requested task instance.
        /// </summary>
        public string TaskInstanceId;
    }

    [Serializable]
    public class GetTaskInstancesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Name or ID of the task whose instances are being queried. If not specified, return all task instances that satisfy conditions set by other filters.
        /// </summary>
        public NameIdentifier TaskIdentifier;
        /// <summary>
        /// Optional filter for task instances that are of a specific status.
        /// </summary>
        public TaskInstanceStatus? StatusFilter;
        /// <summary>
        /// Optional range-from filter for task instances' StartedAt timestamp.
        /// </summary>
        public DateTime? StartedAtRangeFrom;
        /// <summary>
        /// Optional range-to filter for task instances' StartedAt timestamp.
        /// </summary>
        public DateTime? StartedAtRangeTo;
    }

    [Serializable]
    public class GetTaskInstancesResult : PlayFabResultCommon
    {
        /// <summary>
        /// Basic status summaries of the queried task instances. Empty If no task instances meets the filter criteria. To get detailed status summary, use Get*TaskInstance API according to task type (e.g. GetActionsOnPlayersInSegmentTaskInstance).
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
    public class IncrementPlayerStatisticVersionRequest : PlayFabRequestCommon
    {
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
    public class ListBuildsRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class ListBuildsResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of uploaded game server builds
        /// </summary>
        public List<GetServerBuildInfoResult> Builds;
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
    public class LookupUserAccountInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email;
        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username;
        /// <summary>
        /// Title specific username to match against existing user accounts
        /// </summary>
        public string TitleDisplayName;
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
    public class ModifyMatchmakerGameModesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// previously uploaded build version for which game modes are being specified
        /// </summary>
        public string BuildVersion;
        /// <summary>
        /// array of game modes (Note: this will replace all game modes for the indicated build version)
        /// </summary>
        public List<GameModeInfo> GameModes;
    }

    [Serializable]
    public class ModifyMatchmakerGameModesResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ModifyServerBuildRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the previously uploaded build executable to be updated
        /// </summary>
        public string BuildId;
        /// <summary>
        /// new timestamp
        /// </summary>
        public DateTime? Timestamp;
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions;
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;
    }

    [Serializable]
    public class ModifyServerBuildResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId;
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions;
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost;
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots;
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate;
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath;
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment;
        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        public GameBuildStatus? Status;
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
    public class PermissionStatement
    {
        /// <summary>
        /// The resource this statements effects. The only supported resources look like 'pfrn:api--*' for all apis, or 'pfrn:api--/Client/ConfirmPurchase' for specific apis.
        /// </summary>
        public string Resource;
        /// <summary>
        /// The action this statement effects. The only supported action is 'Execute'.
        /// </summary>
        public string Action;
        /// <summary>
        /// The effect this statement will have. It could be either Allow or Deny
        /// </summary>
        public EffectType Effect;
        /// <summary>
        /// The principal this statement will effect. The only supported principal is '*'.
        /// </summary>
        public string Principal;
        /// <summary>
        /// A comment about the statement. Intended solely for bookeeping and debugging.
        /// </summary>
        public string Comment;
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
    public class PlayerStatisticDefinition
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// current active version of the statistic, incremented each time the statistic resets
        /// </summary>
        public uint CurrentVersion;
        /// <summary>
        /// interval at which the values of the statistic for all players are reset automatically
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval;
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod;
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
        /// <summary>
        /// status of the process of saving player statistic values of the previous version to a downloadable archive
        /// </summary>
        [Obsolete("Use 'Status' instead", false)]
        public StatisticVersionArchivalStatus? ArchivalStatus;
        /// <summary>
        /// status of the statistic version
        /// </summary>
        public StatisticVersionStatus? Status;
        /// <summary>
        /// URL for the downloadable archive of player statistic values, if available
        /// </summary>
        public string ArchiveDownloadUrl;
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
    public class RandomResultTable
    {
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
    public class RefundPurchaseRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique order ID for the purchase in question.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Reason for refund. In the case of Facebook this must match one of their refund or dispute resolution enums (See: https://developers.facebook.com/docs/payments/implementation-guide/handling-disputes-refunds)
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
    public class RemoveServerBuildRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the previously uploaded build executable to be removed
        /// </summary>
        public string BuildId;
    }

    [Serializable]
    public class RemoveServerBuildResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class RemoveVirtualCurrencyTypesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of virtual currencies to delete
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies;
    }

    [Serializable]
    public class ResetCharacterStatisticsRequest : PlayFabRequestCommon
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
    public class ResetCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ResetUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Array of users to reset
        /// </summary>
        public List<UserCredentials> Users;
    }

    [Serializable]
    public class ResetUserStatisticsRequest : PlayFabRequestCommon
    {
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
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Unique order ID for the purchase in question.
        /// </summary>
        public string OrderId;
        /// <summary>
        /// Reason for refund. In the case of Facebook this must match one of their refund or dispute resolution enums (See: https://developers.facebook.com/docs/payments/implementation-guide/handling-disputes-refunds)
        /// </summary>
        public string Reason;
        /// <summary>
        /// Enum for the desired purchase result state after notifying the payment provider. Valid values are Revoke, Reinstate and Manual. Manual will cause no change to the order state.
        /// </summary>
        public ResolutionOutcome Outcome;
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
    public class RunTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Provide either the task ID or the task name to run a task.
        /// </summary>
        public NameIdentifier Identifier;
    }

    [Serializable]
    public class RunTaskResult : PlayFabResultCommon
    {
        /// <summary>
        /// ID of the task instance that is started. This can be used in Get*TaskInstance (e.g. GetCloudScriptTaskInstance) API call to retrieve status for the task instance.
        /// </summary>
        public string TaskInstanceId;
    }

    [Serializable]
    public class ScheduledTask
    {
        /// <summary>
        /// ID of the task
        /// </summary>
        public string TaskId;
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Task type.
        /// </summary>
        public ScheduledTaskType? Type;
        /// <summary>
        /// Task parameter. Different types of task have different parameter structure. See each task type's create API documentation for the details.
        /// </summary>
        public object Parameter;
        /// <summary>
        /// UTC time of last run
        /// </summary>
        public DateTime? LastRunTime;
        /// <summary>
        /// UTC time of next run
        /// </summary>
        public DateTime? NextRunTime;
    }

    public enum ScheduledTaskType
    {
        CloudScript,
        ActionsOnPlayerSegment
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
    }

    [Serializable]
    public class SendAccountRecoveryEmailResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SetPublishedRevisionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Version number
        /// </summary>
        public int Version;
        /// <summary>
        /// Revision to make the current published revision
        /// </summary>
        public int Revision;
    }

    [Serializable]
    public class SetPublishedRevisionResult : PlayFabResultCommon
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
    public class SetupPushNotificationRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// name of the application sending the message (application names must be made up of only uppercase and lowercase ASCII letters, numbers, underscores, hyphens, and periods, and must be between 1 and 256 characters long)
        /// </summary>
        public string Name;
        /// <summary>
        /// supported notification platforms are Apple Push Notification Service (APNS and APNS_SANDBOX) for iOS and Google Cloud Messaging (GCM) for Android
        /// </summary>
        public string Platform;
        /// <summary>
        /// for APNS, this is the PlatformPrincipal (SSL Certificate)
        /// </summary>
        public string Key;
        /// <summary>
        /// Credential is the Private Key for APNS/APNS_SANDBOX, and the API Key for GCM
        /// </summary>
        public string Credential;
        /// <summary>
        /// replace any existing ARN with the newly generated one. If this is set to false, an error will be returned if notifications have already setup for this platform.
        /// </summary>
        public bool OverwriteOldARN;
    }

    [Serializable]
    public class SetupPushNotificationResult : PlayFabResultCommon
    {
        /// <summary>
        /// Amazon Resource Name for the created notification topic.
        /// </summary>
        public string ARN;
    }

    public enum SourceType
    {
        Admin,
        BackEnd,
        GameClient,
        GameServer,
        Partner
    }

    public enum StatisticAggregationMethod
    {
        Last,
        Min,
        Max,
        Sum
    }

    public enum StatisticResetIntervalOption
    {
        Never,
        Hour,
        Day,
        Week,
        Month
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
    public class TaskInstanceBasicSummary
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
    public class UpdateCatalogItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Which catalog is being updated. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Should this catalog be set as the default catalog. Defaults to true. If there is currently no default catalog, this will always set it.
        /// </summary>
        public bool? SetAsDefaultCatalog;
        /// <summary>
        /// Array of catalog items to be submitted. Note that while CatalogItem has a parameter for CatalogVersion, it is not required and ignored in this call.
        /// </summary>
        public List<CatalogItem> Catalog;
    }

    [Serializable]
    public class UpdateCatalogItemsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateCloudScriptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of Cloud Script files to upload to create the new revision. Must have at least one file.
        /// </summary>
        public List<CloudScriptFile> Files;
        /// <summary>
        /// Immediately publish the new revision
        /// </summary>
        public bool Publish;
        /// <summary>
        /// PlayFab user ID of the developer initiating the request.
        /// </summary>
        public string DeveloperPlayFabId;
    }

    [Serializable]
    public class UpdateCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Cloud Script version updated
        /// </summary>
        public int Version;
        /// <summary>
        /// New revision number created
        /// </summary>
        public int Revision;
    }

    [Serializable]
    public class UpdatePlayerStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName;
        /// <summary>
        /// interval at which the values of the statistic for all players are reset (changes are effective at the next occurance of the new interval boundary)
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval;
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod;
    }

    [Serializable]
    public class UpdatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// updated statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic;
    }

    [Serializable]
    public class UpdatePolicyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The name of the policy being updated. Only supported name is 'ApiPolicy'
        /// </summary>
        public string PolicyName;
        /// <summary>
        /// The new statements to include in the policy.
        /// </summary>
        public List<PermissionStatement> Statements;
        /// <summary>
        /// Whether to overwrite or append to the existing policy.
        /// </summary>
        public bool OverwritePolicy;
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

    [Serializable]
    public class UpdateRandomResultTablesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// which catalog is being updated. If null, update the current default catalog version
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that table, while any others will be added to the available set)
        /// </summary>
        public List<RandomResultTable> Tables;
    }

    [Serializable]
    public class UpdateRandomResultTablesResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateStoreItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version of the store to update. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique identifier for the store which is to be updated
        /// </summary>
        public string StoreId;
        /// <summary>
        /// Additional data about the store
        /// </summary>
        public StoreMarketingModel MarketingData;
        /// <summary>
        /// Array of store items - references to catalog items, with specific pricing - to be added
        /// </summary>
        public List<StoreItem> Store;
    }

    [Serializable]
    public class UpdateStoreItemsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateTaskRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specify either the task ID or the name of the task to be updated.
        /// </summary>
        public NameIdentifier Identifier;
        /// <summary>
        /// Name of the task. This is a unique identifier for tasks in the title.
        /// </summary>
        public string Name;
        /// <summary>
        /// Description the task
        /// </summary>
        public string Description;
        /// <summary>
        /// Cron expression for the run schedule of the task. The expression should be in UTC.
        /// </summary>
        public string Schedule;
        /// <summary>
        /// Whether the schedule is active. Inactive schedule will not trigger task execution.
        /// </summary>
        public bool IsActive;
        /// <summary>
        /// Task type.
        /// </summary>
        public ScheduledTaskType Type;
        /// <summary>
        /// Parameter object specific to the task type. See each task type's create API documentation for details.
        /// </summary>
        public object Parameter;
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
    public class UpdateUserTitleDisplayNameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose title specific display name is to be changed
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// new title display name for the user - must be between 3 and 25 characters
        /// </summary>
        public string DisplayName;
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
    public class UserCredentials
    {
        /// <summary>
        /// Username of user to reset
        /// </summary>
        public string Username;
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
    public class VirtualCurrencyData
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
        /// rate at which the currency automatically be added to over time, in units per day (24 hours)
        /// </summary>
        public int? RechargeRate;
        /// <summary>
        /// maximum amount to which the currency will recharge (cannot exceed MaxAmount, but can be less)
        /// </summary>
        public int? RechargeMax;
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
}
#endif
