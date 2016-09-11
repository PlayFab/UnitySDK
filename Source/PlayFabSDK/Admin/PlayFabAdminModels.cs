#if ENABLE_PLAYFABADMIN_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AdminModels
{
    [Serializable]
    public class AdCampaignAttribution
    {
        /// <summary>
        /// Attribution network name
        /// </summary>
        public string Platform { get; set;}
        /// <summary>
        /// Attribution campaign identifier
        /// </summary>
        public string CampaignId { get; set;}
        /// <summary>
        /// UTC time stamp of attribution
        /// </summary>
        public DateTime AttributedAt { get; set;}
    }

    [Serializable]
    public class AddNewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Time this news was published. If not set, defaults to now.
        /// </summary>
        public DateTime? Timestamp { get; set;}
        /// <summary>
        /// Title (headline) of the news item
        /// </summary>
        public string Title { get; set;}
        /// <summary>
        /// Body text of the news
        /// </summary>
        public string Body { get; set;}
    }

    [Serializable]
    public class AddNewsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique id of the new news item
        /// </summary>
        public string NewsId { get; set;}
    }

    [Serializable]
    public class AddPlayerTagRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName { get; set;}
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
        public string BuildId { get; set;}
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate { get; set;}
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath { get; set;}
        /// <summary>
        /// server host regions in which this build should be running and available
        /// </summary>
        public List<Region> ActiveRegions { get; set;}
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment { get; set;}
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost { get; set;}
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots { get; set;}
    }

    [Serializable]
    public class AddServerBuildResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId { get; set;}
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions { get; set;}
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost { get; set;}
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots { get; set;}
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate { get; set;}
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath { get; set;}
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment { get; set;}
        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp { get; set;}
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId { get; set;}
        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        public GameBuildStatus? Status { get; set;}
    }

    [Serializable]
    public class AddUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be increased.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency { get; set;}
        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount { get; set;}
    }

    [Serializable]
    public class AddVirtualCurrencyTypesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of virtual currencies and their initial deposits (the amount a user is granted when signing in for the first time) to the title
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies { get; set;}
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
        public string PlayFabId { get; set;}
        /// <summary>
        /// The unique Ban Id associated with this ban.
        /// </summary>
        public string BanId { get; set;}
        /// <summary>
        /// The IP address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string IPAddress { get; set;}
        /// <summary>
        /// The MAC address on which the ban was applied. May affect multiple players.
        /// </summary>
        public string MACAddress { get; set;}
        /// <summary>
        /// The time when this ban was applied.
        /// </summary>
        public DateTime? Created { get; set;}
        /// <summary>
        /// The time when this ban expires. Permanent bans do not have expiration date.
        /// </summary>
        public DateTime? Expires { get; set;}
        /// <summary>
        /// The reason why this ban was applied.
        /// </summary>
        public string Reason { get; set;}
        /// <summary>
        /// The active state of this ban. Expired bans may still have this value set to true but they will have no effect.
        /// </summary>
        public bool Active { get; set;}
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
        public string PlayFabId { get; set;}
        /// <summary>
        /// IP address to be banned. May affect multiple players.
        /// </summary>
        public string IPAddress { get; set;}
        /// <summary>
        /// MAC address to be banned. May affect multiple players.
        /// </summary>
        public string MACAddress { get; set;}
        /// <summary>
        /// The reason for this ban. Maximum 140 characters.
        /// </summary>
        public string Reason { get; set;}
        /// <summary>
        /// The duration in hours for the ban. Leave this blank for a permanent ban.
        /// </summary>
        public uint? DurationInHours { get; set;}
    }

    [Serializable]
    public class BanUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of ban requests to be applied. Maximum 100.
        /// </summary>
        public List<BanRequest> Bans { get; set;}
    }

    [Serializable]
    public class BanUsersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were applied
        /// </summary>
        public List<BanInfo> BanData { get; set;}
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
        public string ItemId { get; set;}
        /// <summary>
        /// class to which the item belongs
        /// </summary>
        public string ItemClass { get; set;}
        /// <summary>
        /// catalog version for this item
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// text name for the item, to show in-game
        /// </summary>
        public string DisplayName { get; set;}
        /// <summary>
        /// text description of item, to show in-game
        /// </summary>
        public string Description { get; set;}
        /// <summary>
        /// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
        /// <summary>
        /// override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices { get; set;}
        /// <summary>
        /// list of item tags
        /// </summary>
        public List<string> Tags { get; set;}
        /// <summary>
        /// game specific custom data
        /// </summary>
        public string CustomData { get; set;}
        /// <summary>
        /// defines the consumable properties (number of uses, timeout) for the item
        /// </summary>
        public CatalogItemConsumableInfo Consumable { get; set;}
        /// <summary>
        /// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
        /// </summary>
        public CatalogItemContainerInfo Container { get; set;}
        /// <summary>
        /// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
        /// </summary>
        public CatalogItemBundleInfo Bundle { get; set;}
        /// <summary>
        /// if true, then an item instance of this type can be used to grant a character to a user.
        /// </summary>
        public bool CanBecomeCharacter { get; set;}
        /// <summary>
        /// if true, then only one item instance of this type will exist and its remaininguses will be incremented instead. RemainingUses will cap out at Int32.Max (2,147,483,647). All subsequent increases will be discarded
        /// </summary>
        public bool IsStackable { get; set;}
        /// <summary>
        /// if true, then an item instance of this type can be traded between players using the trading APIs
        /// </summary>
        public bool IsTradable { get; set;}
        /// <summary>
        /// URL to the item image. For Facebook purchase to display the image on the item purchase page, this must be set to an HTTP URL.
        /// </summary>
        public string ItemImageUrl { get; set;}
        /// <summary>
        /// BETA: If true, then only a fixed number can ever be granted.
        /// </summary>
        public bool IsLimitedEdition { get; set;}
        /// <summary>
        /// BETA: If IsLImitedEdition is true, then this determines amount of the item initially available. Note that this fieldis ignored if the catalog item already existed in this catalog, or the field is less than 1.
        /// </summary>
        public int InitialLimitedEditionCount { get; set;}
    }

    [Serializable]
    public class CatalogItemBundleInfo
    {
        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory when the bundle is added
        /// </summary>
        public List<string> BundledItems { get; set;}
        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
        /// </summary>
        public List<string> BundledResultTables { get; set;}
        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the bundle is added
        /// </summary>
        public Dictionary<string,uint> BundledVirtualCurrencies { get; set;}
    }

    [Serializable]
    public class CatalogItemConsumableInfo
    {
        /// <summary>
        /// number of times this object can be used, after which it will be removed from the player inventory
        /// </summary>
        public uint? UsageCount { get; set;}
        /// <summary>
        /// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
        /// </summary>
        public uint? UsagePeriod { get; set;}
        /// <summary>
        /// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
        /// </summary>
        public string UsagePeriodGroup { get; set;}
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
        public string KeyItemId { get; set;}
        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
        /// </summary>
        public List<string> ItemContents { get; set;}
        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
        /// </summary>
        public List<string> ResultTableContents { get; set;}
        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the container is unlocked
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyContents { get; set;}
    }

    [Serializable]
    public class CloudScriptFile
    {
        /// <summary>
        /// Name of the javascript file. These names are not used internally by the server, they are only for developer organizational purposes.
        /// </summary>
        public string Filename { get; set;}
        /// <summary>
        /// Contents of the Cloud Script javascript. Must be string-escaped javascript.
        /// </summary>
        public string FileContents { get; set;}
    }

    [Serializable]
    public class CloudScriptVersionStatus
    {
        /// <summary>
        /// Version number
        /// </summary>
        public int Version { get; set;}
        /// <summary>
        /// Published code revision for this Cloud Script version
        /// </summary>
        public int PublishedRevision { get; set;}
        /// <summary>
        /// Most recent revision for this Cloud Script version
        /// </summary>
        public int LatestRevision { get; set;}
    }

    [Serializable]
    public class ContentInfo
    {
        /// <summary>
        /// Key of the content
        /// </summary>
        public string Key { get; set;}
        /// <summary>
        /// Size of the content in bytes
        /// </summary>
        public uint Size { get; set;}
        /// <summary>
        /// Last modified time
        /// </summary>
        public DateTime LastModified { get; set;}
    }

    [Serializable]
    public class CreatePlayerStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}
        /// <summary>
        /// interval at which the values of the statistic for all players are reset (resets begin at the next interval boundary)
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval { get; set;}
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod { get; set;}
    }

    [Serializable]
    public class CreatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// created statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic { get; set;}
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
        public string Key { get; set;}
    }

    [Serializable]
    public class DeleteStoreRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// catalog version of the store to delete. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// unqiue identifier for the store which is to be deleted
        /// </summary>
        public string StoreId { get; set;}
    }

    [Serializable]
    public class DeleteStoreResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class DeleteUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds { get; set;}
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId { get; set;}
    }

    [Serializable]
    public class DeleteUsersResult : PlayFabResultCommon
    {
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
        public string Gamemode { get; set;}
        /// <summary>
        /// minimum user count required for this Game Server Instance to continue (usually 1)
        /// </summary>
        public uint MinPlayerCount { get; set;}
        /// <summary>
        /// maximum user count a specific Game Server Instance can support
        /// </summary>
        public uint MaxPlayerCount { get; set;}
        /// <summary>
        /// whether to start as an open session, meaning that players can matchmake into it (defaults to true)
        /// </summary>
        public bool? StartOpen { get; set;}
    }

    [Serializable]
    public class GetActionGroupResult : PlayFabResultCommon
    {
        /// <summary>
        /// Action Group name
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// Action Group ID
        /// </summary>
        public string Id { get; set;}
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
        public List<GetActionGroupResult> ActionGroups { get; set;}
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
        public List<GetSegmentResult> Segments { get; set;}
    }

    [Serializable]
    public class GetCatalogItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Which catalog is being requested. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    [Serializable]
    public class GetCatalogItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items which can be purchased.
        /// </summary>
        public List<CatalogItem> Catalog { get; set;}
    }

    [Serializable]
    public class GetCloudScriptRevisionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Version number. If left null, defaults to the latest version
        /// </summary>
        public int? Version { get; set;}
        /// <summary>
        /// Revision number. If left null, defaults to the latest revision
        /// </summary>
        public int? Revision { get; set;}
    }

    [Serializable]
    public class GetCloudScriptRevisionResult : PlayFabResultCommon
    {
        /// <summary>
        /// Version number.
        /// </summary>
        public int Version { get; set;}
        /// <summary>
        /// Revision number.
        /// </summary>
        public int Revision { get; set;}
        /// <summary>
        /// Time this revision was created
        /// </summary>
        public DateTime CreatedAt { get; set;}
        /// <summary>
        /// List of Cloud Script files in this revision.
        /// </summary>
        public List<CloudScriptFile> Files { get; set;}
        /// <summary>
        /// True if this is the currently published revision
        /// </summary>
        public bool IsPublished { get; set;}
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
        public List<CloudScriptVersionStatus> Versions { get; set;}
    }

    [Serializable]
    public class GetContentListRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Limits the response to keys that begin with the specified prefix. You can use prefixes to list contents under a folder, or for a specified version, etc.
        /// </summary>
        public string Prefix { get; set;}
    }

    [Serializable]
    public class GetContentListResult : PlayFabResultCommon
    {
        /// <summary>
        /// Number of content items returned. We currently have a maximum of 1000 items limit.
        /// </summary>
        public int ItemCount { get; set;}
        /// <summary>
        /// The total size of listed contents in bytes.
        /// </summary>
        public uint TotalSize { get; set;}
        /// <summary>
        /// List of content items.
        /// </summary>
        public List<ContentInfo> Contents { get; set;}
    }

    [Serializable]
    public class GetContentUploadUrlRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Key of the content item to upload, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key { get; set;}
        /// <summary>
        /// A standard MIME type describing the format of the contents. The same MIME type has to be set in the header when uploading the content. If not specified, the MIME type is 'binary/octet-stream' by default.
        /// </summary>
        public string ContentType { get; set;}
    }

    [Serializable]
    public class GetContentUploadUrlResult : PlayFabResultCommon
    {
        /// <summary>
        /// URL for uploading content via HTTP PUT method. The URL will expire in 1 hour.
        /// </summary>
        public string URL { get; set;}
    }

    [Serializable]
    public class GetDataReportRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Report name
        /// </summary>
        public string ReportName { get; set;}
        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Year { get; set;}
        /// <summary>
        /// Reporting month (UTC)
        /// </summary>
        public int Month { get; set;}
        /// <summary>
        /// Reporting year (UTC)
        /// </summary>
        public int Day { get; set;}
    }

    [Serializable]
    public class GetDataReportResult : PlayFabResultCommon
    {
        /// <summary>
        /// The URL where the requested report can be downloaded.
        /// </summary>
        public string DownloadUrl { get; set;}
    }

    [Serializable]
    public class GetMatchmakerGameInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the lobby for which info is being requested
        /// </summary>
        public string LobbyId { get; set;}
    }

    [Serializable]
    public class GetMatchmakerGameInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier of the lobby 
        /// </summary>
        public string LobbyId { get; set;}
        /// <summary>
        /// unique identifier of the Game Server Instance for this lobby
        /// </summary>
        public string TitleId { get; set;}
        /// <summary>
        /// time when the Game Server Instance was created
        /// </summary>
        public DateTime StartTime { get; set;}
        /// <summary>
        /// time when Game Server Instance is currently scheduled to end
        /// </summary>
        public DateTime? EndTime { get; set;}
        /// <summary>
        /// game mode for this Game Server Instance
        /// </summary>
        public string Mode { get; set;}
        /// <summary>
        /// version identifier of the game server executable binary being run
        /// </summary>
        public string BuildVersion { get; set;}
        /// <summary>
        /// region in which the Game Server Instance is running
        /// </summary>
        public Region? Region { get; set;}
        /// <summary>
        /// array of unique PlayFab identifiers for users currently connected to this Game Server Instance
        /// </summary>
        public List<string> Players { get; set;}
        /// <summary>
        /// IP address for this Game Server Instance
        /// </summary>
        public string ServerAddress { get; set;}
        /// <summary>
        /// communication port for this Game Server Instance
        /// </summary>
        public uint ServerPort { get; set;}
    }

    [Serializable]
    public class GetMatchmakerGameModesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// previously uploaded build version for which game modes are being requested
        /// </summary>
        public string BuildVersion { get; set;}
    }

    [Serializable]
    public class GetMatchmakerGameModesResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of game modes available for the specified build
        /// </summary>
        public List<GameModeInfo> GameModes { get; set;}
    }

    [Serializable]
    public class GetPlayerSegmentsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of segments the requested player currently belongs to.
        /// </summary>
        public List<GetSegmentResult> Segments { get; set;}
    }

    [Serializable]
    public class GetPlayersInSegmentRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string SegmentId { get; set;}
        /// <summary>
        /// Number of seconds to keep the continuation token active. After token expiration it is not possible to continue paging results. Default is 300 (5 minutes). Maximum is 1,800 (30 minutes).
        /// </summary>
        public uint? SecondsToLive { get; set;}
        /// <summary>
        /// Maximum number of profiles to load. Default is 1,000. Maximum is 10,000.
        /// </summary>
        public uint? MaxBatchSize { get; set;}
        /// <summary>
        /// Continuation token if retrieving subsequent pages of results.
        /// </summary>
        public string ContinuationToken { get; set;}
    }

    [Serializable]
    public class GetPlayersInSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Count of profiles matching this segment.
        /// </summary>
        public int ProfilesInSegment { get; set;}
        /// <summary>
        /// Continuation token to use to retrieve subsequent pages of results. If token returns null there are no more results.
        /// </summary>
        public string ContinuationToken { get; set;}
        /// <summary>
        /// Array of player profiles in this segment.
        /// </summary>
        public List<PlayerProfile> PlayerProfiles { get; set;}
    }

    [Serializable]
    public class GetPlayersSegmentsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
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
        public List<PlayerStatisticDefinition> Statistics { get; set;}
    }

    [Serializable]
    public class GetPlayerStatisticVersionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}
    }

    [Serializable]
    public class GetPlayerStatisticVersionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public List<PlayerStatisticVersion> StatisticVersions { get; set;}
    }

    [Serializable]
    public class GetPlayerTagsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Optional namespace to filter results by
        /// </summary>
        public string Namespace { get; set;}
    }

    [Serializable]
    public class GetPlayerTagsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Canonical tags (including namespace and tag's name) for the requested user
        /// </summary>
        public List<string> Tags { get; set;}
    }

    [Serializable]
    public class GetPublisherDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        ///  array of keys to get back data from the Publisher data blob, set by the admin tools
        /// </summary>
        public List<string> Keys { get; set;}
    }

    [Serializable]
    public class GetPublisherDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
    }

    [Serializable]
    public class GetRandomResultTablesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// catalog version to fetch tables from. Use default catalog version if null
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    [Serializable]
    public class GetRandomResultTablesResult : PlayFabResultCommon
    {
        /// <summary>
        /// array of random result tables currently available
        /// </summary>
        public Dictionary<string,RandomResultTableListing> Tables { get; set;}
    }

    [Serializable]
    public class GetSegmentResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string Id { get; set;}
        /// <summary>
        /// Segment name.
        /// </summary>
        public string Name { get; set;}
        /// <summary>
        /// Identifier of the segments AB Test, if it is attached to one.
        /// </summary>
        public string ABTestParent { get; set;}
    }

    [Serializable]
    public class GetServerBuildInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the previously uploaded build executable for which information is being requested
        /// </summary>
        public string BuildId { get; set;}
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
        public string BuildId { get; set;}
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions { get; set;}
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost { get; set;}
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots { get; set;}
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment { get; set;}
        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp { get; set;}
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId { get; set;}
        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        public GameBuildStatus? Status { get; set;}
        /// <summary>
        /// error message, if any, about this build
        /// </summary>
        public string ErrorMessage { get; set;}
    }

    [Serializable]
    public class GetServerBuildUploadURLRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique identifier of the game server build to upload
        /// </summary>
        public string BuildId { get; set;}
    }

    [Serializable]
    public class GetServerBuildUploadURLResult : PlayFabResultCommon
    {
        /// <summary>
        /// pre-authorized URL for uploading the game server build package
        /// </summary>
        public string URL { get; set;}
    }

    [Serializable]
    public class GetStoreItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// catalog version to store items from. Use default catalog version if null
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// Unqiue identifier for the store which is being requested.
        /// </summary>
        public string StoreId { get; set;}
    }

    [Serializable]
    public class GetStoreItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items which can be purchased from this store.
        /// </summary>
        public List<StoreItem> Store { get; set;}
        /// <summary>
        /// How the store was last updated (Admin or a third party).
        /// </summary>
        public SourceType? Source { get; set;}
        /// <summary>
        /// The base catalog that this store is a part of.
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// The ID of this store.
        /// </summary>
        public string StoreId { get; set;}
        /// <summary>
        /// Additional data about the store.
        /// </summary>
        public StoreMarketingModel MarketingData { get; set;}
    }

    [Serializable]
    public class GetTitleDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Specific keys to search for in the title data (leave null to get all keys)
        /// </summary>
        public List<string> Keys { get; set;}
    }

    [Serializable]
    public class GetTitleDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
    }

    [Serializable]
    public class GetUserBansRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    [Serializable]
    public class GetUserBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information about the bans
        /// </summary>
        public List<BanInfo> BanData { get; set;}
    }

    [Serializable]
    public class GetUserDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys { get; set;}
        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public uint? IfChangedFromDataVersion { get; set;}
    }

    [Serializable]
    public class GetUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose custom data is being returned.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data { get; set;}
    }

    [Serializable]
    public class GetUserInventoryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    [Serializable]
    public class GetUserInventoryResult : PlayFabResultCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Array of inventory items belonging to the user.
        /// </summary>
        public List<ItemInstance> Inventory { get; set;}
        /// <summary>
        /// Array of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency { get; set;}
        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes { get; set;}
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
        public string PlayFabId { get; set;}
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
        /// <summary>
        /// Result of this operation.
        /// </summary>
        public bool Result { get; set;}
        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId { get; set;}
        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId { get; set;}
        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass { get; set;}
        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate { get; set;}
        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration { get; set;}
        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses { get; set;}
        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy { get; set;}
        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation { get; set;}
        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
        /// </summary>
        public string BundleParent { get; set;}
        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName { get; set;}
        /// <summary>
        /// Currency type for the cost of the catalog item.
        /// </summary>
        public string UnitCurrency { get; set;}
        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice { get; set;}
        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents { get; set;}
        /// <summary>
        /// A set of custom key-value pairs on the inventory item.
        /// </summary>
        public Dictionary<string,string> CustomData { get; set;}
    }

    [Serializable]
    public class GrantItemsToUsersRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// Array of items to grant and the users to whom the items are to be granted.
        /// </summary>
        public List<ItemGrant> ItemGrants { get; set;}
    }

    [Serializable]
    public class GrantItemsToUsersResult : PlayFabResultCommon
    {
        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults { get; set;}
    }

    [Serializable]
    public class IncrementPlayerStatisticVersionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}
    }

    [Serializable]
    public class IncrementPlayerStatisticVersionResult : PlayFabResultCommon
    {
        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public PlayerStatisticVersion StatisticVersion { get; set;}
    }

    [Serializable]
    public class ItemGrant
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Unique identifier of the catalog item to be granted to the user.
        /// </summary>
        public string ItemId { get; set;}
        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation { get; set;}
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}
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
        public string ItemId { get; set;}
        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId { get; set;}
        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass { get; set;}
        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate { get; set;}
        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration { get; set;}
        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses { get; set;}
        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy { get; set;}
        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation { get; set;}
        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
        /// </summary>
        public string BundleParent { get; set;}
        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName { get; set;}
        /// <summary>
        /// Currency type for the cost of the catalog item.
        /// </summary>
        public string UnitCurrency { get; set;}
        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice { get; set;}
        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents { get; set;}
        /// <summary>
        /// A set of custom key-value pairs on the inventory item.
        /// </summary>
        public Dictionary<string,string> CustomData { get; set;}
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
        public List<GetServerBuildInfoResult> Builds { get; set;}
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
        public List<VirtualCurrencyData> VirtualCurrencies { get; set;}
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
        Twitch
    }

    [Serializable]
    public class LookupUserAccountInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email { get; set;}
        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username { get; set;}
        /// <summary>
        /// Title specific username to match against existing user accounts
        /// </summary>
        public string TitleDisplayName { get; set;}
    }

    [Serializable]
    public class LookupUserAccountInfoResult : PlayFabResultCommon
    {
        /// <summary>
        /// User info for the user matching the request
        /// </summary>
        public UserAccountInfo UserInfo { get; set;}
    }

    [Serializable]
    public class ModifyMatchmakerGameModesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// previously uploaded build version for which game modes are being specified
        /// </summary>
        public string BuildVersion { get; set;}
        /// <summary>
        /// array of game modes (Note: this will replace all game modes for the indicated build version)
        /// </summary>
        public List<GameModeInfo> GameModes { get; set;}
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
        public string BuildId { get; set;}
        /// <summary>
        /// new timestamp
        /// </summary>
        public DateTime? Timestamp { get; set;}
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions { get; set;}
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost { get; set;}
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots { get; set;}
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate { get; set;}
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath { get; set;}
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment { get; set;}
    }

    [Serializable]
    public class ModifyServerBuildResult : PlayFabResultCommon
    {
        /// <summary>
        /// unique identifier for this build executable
        /// </summary>
        public string BuildId { get; set;}
        /// <summary>
        /// array of regions where this build can used, when it is active
        /// </summary>
        public List<Region> ActiveRegions { get; set;}
        /// <summary>
        /// maximum number of game server instances that can run on a single host machine
        /// </summary>
        public int MaxGamesPerHost { get; set;}
        /// <summary>
        /// minimum capacity of additional game server instances that can be started before the autoscaling service starts new host machines (given the number of current running host machines and game server instances)
        /// </summary>
        public int MinFreeGameSlots { get; set;}
        /// <summary>
        /// appended to the end of the command line when starting game servers
        /// </summary>
        public string CommandLineTemplate { get; set;}
        /// <summary>
        /// path to the game server executable. Defaults to gameserver.exe
        /// </summary>
        public string ExecutablePath { get; set;}
        /// <summary>
        /// developer comment(s) for this build
        /// </summary>
        public string Comment { get; set;}
        /// <summary>
        /// time this build was last modified (or uploaded, if this build has never been modified)
        /// </summary>
        public DateTime Timestamp { get; set;}
        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected.
        /// </summary>
        public string TitleId { get; set;}
        /// <summary>
        /// the current status of the build validation and processing steps
        /// </summary>
        public GameBuildStatus? Status { get; set;}
    }

    [Serializable]
    public class ModifyUserVirtualCurrencyResult : PlayFabResultCommon
    {
        /// <summary>
        /// User currency was subtracted from.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency { get; set;}
        /// <summary>
        /// Amount added or subtracted from the user's virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int BalanceChange { get; set;}
        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance { get; set;}
    }

    [Serializable]
    public class PlayerLinkedAccount
    {
        /// <summary>
        /// Authentication platform
        /// </summary>
        public LoginIdentityProvider? Platform { get; set;}
        /// <summary>
        /// Platform user identifier
        /// </summary>
        public string PlatformUserId { get; set;}
        /// <summary>
        /// Linked account's username
        /// </summary>
        public string Username { get; set;}
        /// <summary>
        /// Linked account's email
        /// </summary>
        public string Email { get; set;}
    }

    [Serializable]
    public class PlayerProfile
    {
        /// <summary>
        /// PlayFab Player ID
        /// </summary>
        public string PlayerId { get; set;}
        /// <summary>
        /// Title ID this profile applies to
        /// </summary>
        public string TitleId { get; set;}
        /// <summary>
        /// Player Display Name
        /// </summary>
        public string DisplayName { get; set;}
        /// <summary>
        /// Publisher this player belongs to
        /// </summary>
        public string PublisherId { get; set;}
        /// <summary>
        /// Player account origination
        /// </summary>
        public LoginIdentityProvider? Origination { get; set;}
        /// <summary>
        /// Player record created
        /// </summary>
        public DateTime? Created { get; set;}
        /// <summary>
        /// Last login
        /// </summary>
        public DateTime? LastLogin { get; set;}
        /// <summary>
        /// Banned until UTC Date. If permanent ban this is set for 20 years after the original ban date.
        /// </summary>
        public DateTime? BannedUntil { get; set;}
        /// <summary>
        /// Dictionary of player's statistics using only the latest version's value
        /// </summary>
        public Dictionary<string,int> Statistics { get; set;}
        /// <summary>
        /// A sum of player's total purchases in USD across all currencies.
        /// </summary>
        public uint? TotalValueToDateInUSD { get; set;}
        /// <summary>
        /// Dictionary of player's total purchases by currency.
        /// </summary>
        public Dictionary<string,uint> ValuesToDate { get; set;}
        /// <summary>
        /// List of player's tags for segmentation.
        /// </summary>
        public List<string> Tags { get; set;}
        /// <summary>
        /// Dictionary of player's virtual currency balances
        /// </summary>
        public Dictionary<string,int> VirtualCurrencyBalances { get; set;}
        /// <summary>
        /// Array of ad campaigns player has been attributed to
        /// </summary>
        public List<AdCampaignAttribution> AdCampaignAttributions { get; set;}
        /// <summary>
        /// Array of configured push notification end points
        /// </summary>
        public List<PushNotificationRegistration> PushNotificationRegistrations { get; set;}
        /// <summary>
        /// Array of third party accounts linked to this player
        /// </summary>
        public List<PlayerLinkedAccount> LinkedAccounts { get; set;}
        /// <summary>
        /// Array of player statistics
        /// </summary>
        public List<PlayerStatistic> PlayerStatistics { get; set;}
    }

    [Serializable]
    public class PlayerStatistic
    {
        /// <summary>
        /// Statistic ID
        /// </summary>
        public string Id { get; set;}
        /// <summary>
        /// Statistic version (0 if not a versioned statistic)
        /// </summary>
        public int StatisticVersion { get; set;}
        /// <summary>
        /// Current statistic value
        /// </summary>
        public int StatisticValue { get; set;}
        /// <summary>
        /// Statistic name
        /// </summary>
        public string Name { get; set;}
    }

    [Serializable]
    public class PlayerStatisticDefinition
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}
        /// <summary>
        /// current active version of the statistic, incremented each time the statistic resets
        /// </summary>
        public uint CurrentVersion { get; set;}
        /// <summary>
        /// interval at which the values of the statistic for all players are reset automatically
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval { get; set;}
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod { get; set;}
    }

    [Serializable]
    public class PlayerStatisticVersion
    {
        /// <summary>
        /// name of the statistic when the version became active
        /// </summary>
        public string StatisticName { get; set;}
        /// <summary>
        /// version of the statistic
        /// </summary>
        public uint Version { get; set;}
        /// <summary>
        /// time at which the statistic version was scheduled to become active, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledActivationTime { get; set;}
        /// <summary>
        /// time when the statistic version became active
        /// </summary>
        public DateTime ActivationTime { get; set;}
        /// <summary>
        /// time at which the statistic version was scheduled to become inactive, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledDeactivationTime { get; set;}
        /// <summary>
        /// time when the statistic version became inactive due to statistic version incrementing
        /// </summary>
        public DateTime? DeactivationTime { get; set;}
        /// <summary>
        /// status of the process of saving player statistic values of the previous version to a downloadable archive
        /// </summary>
        public StatisticVersionArchivalStatus? ArchivalStatus { get; set;}
        /// <summary>
        /// URL for the downloadable archive of player statistic values, if available
        /// </summary>
        public string ArchiveDownloadUrl { get; set;}
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
        public PushNotificationPlatform? Platform { get; set;}
        /// <summary>
        /// Notification configured endpoint
        /// </summary>
        public string NotificationEndpointARN { get; set;}
    }

    [Serializable]
    public class RandomResultTable
    {
        /// <summary>
        /// Unique name for this drop table
        /// </summary>
        public string TableId { get; set;}
        /// <summary>
        /// Child nodes that indicate what kind of drop table item this actually is.
        /// </summary>
        public List<ResultTableNode> Nodes { get; set;}
    }

    [Serializable]
    public class RandomResultTableListing
    {
        /// <summary>
        /// Catalog version this table is associated with
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// Unique name for this drop table
        /// </summary>
        public string TableId { get; set;}
        /// <summary>
        /// Child nodes that indicate what kind of drop table item this actually is.
        /// </summary>
        public List<ResultTableNode> Nodes { get; set;}
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
        public string PlayFabId { get; set;}
        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName { get; set;}
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
        public string BuildId { get; set;}
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
        public List<VirtualCurrencyData> VirtualCurrencies { get; set;}
    }

    [Serializable]
    public class ResetCharacterStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
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
        public List<UserCredentials> Users { get; set;}
    }

    [Serializable]
    public class ResetUserStatisticsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    [Serializable]
    public class ResetUserStatisticsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class ResultTableNode
    {
        /// <summary>
        /// Whether this entry in the table is an item or a link to another table
        /// </summary>
        public ResultTableNodeType ResultItemType { get; set;}
        /// <summary>
        /// Either an ItemId, or the TableId of another random result table
        /// </summary>
        public string ResultItem { get; set;}
        /// <summary>
        /// How likely this is to be rolled - larger numbers add more weight
        /// </summary>
        public int Weight { get; set;}
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
        public string PlayFabId { get; set;}
    }

    [Serializable]
    public class RevokeAllBansForUserResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were revoked.
        /// </summary>
        public List<BanInfo> BanData { get; set;}
    }

    [Serializable]
    public class RevokeBansRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Ids of the bans to be revoked. Maximum 100.
        /// </summary>
        public List<string> BanIds { get; set;}
    }

    [Serializable]
    public class RevokeBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were revoked
        /// </summary>
        public List<BanInfo> BanData { get; set;}
    }

    [Serializable]
    public class RevokeInventoryItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId { get; set;}
    }

    [Serializable]
    public class RevokeInventoryResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class SendAccountRecoveryEmailRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email { get; set;}
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
        public int Version { get; set;}
        /// <summary>
        /// Revision to make the current published revision
        /// </summary>
        public int Revision { get; set;}
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
        public string Key { get; set;}
        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value { get; set;}
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
        public string Key { get; set;}
        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value { get; set;}
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
        public string Name { get; set;}
        /// <summary>
        /// supported notification platforms are Apple Push Notification Service (APNS and APNS_SANDBOX) for iOS and Google Cloud Messaging (GCM) for Android
        /// </summary>
        public string Platform { get; set;}
        /// <summary>
        /// for APNS, this is the PlatformPrincipal (SSL Certificate)
        /// </summary>
        public string Key { get; set;}
        /// <summary>
        /// Credential is the Private Key for APNS/APNS_SANDBOX, and the API Key for GCM
        /// </summary>
        public string Credential { get; set;}
        /// <summary>
        /// replace any existing ARN with the newly generated one. If this is set to false, an error will be returned if notifications have already setup for this platform.
        /// </summary>
        public bool OverwriteOldARN { get; set;}
    }

    [Serializable]
    public class SetupPushNotificationResult : PlayFabResultCommon
    {
        /// <summary>
        /// Amazon Resource Name for the created notification topic.
        /// </summary>
        public string ARN { get; set;}
    }

    public enum SourceType
    {
        Admin,
        BackEnd,
        GameClient,
        GameServer,
        Partner,
        Stream
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

    /// <summary>
    /// A store entry that list a catalog item at a particular price
    /// </summary>
    [Serializable]
    public class StoreItem
    {
        /// <summary>
        /// Unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the catalog
        /// </summary>
        public string ItemId { get; set;}
        /// <summary>
        /// Override prices for this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
        /// <summary>
        /// Override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices { get; set;}
        /// <summary>
        /// Store specific custom data. The data only exists as part of this store; it is not transferred to item instances
        /// </summary>
        public object CustomData { get; set;}
        /// <summary>
        /// Intended display position for this item. Note that 0 is the first position
        /// </summary>
        public uint? DisplayPosition { get; set;}
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
        public string DisplayName { get; set;}
        /// <summary>
        /// Tagline for a store.
        /// </summary>
        public string Description { get; set;}
        /// <summary>
        /// Custom data about a store.
        /// </summary>
        public object Metadata { get; set;}
    }

    [Serializable]
    public class SubtractUserVirtualCurrencyRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be decreased.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency { get; set;}
        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount { get; set;}
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
        public string BanId { get; set;}
        /// <summary>
        /// The updated reason for the ban to be updated. Maximum 140 characters. Null for no change.
        /// </summary>
        public string Reason { get; set;}
        /// <summary>
        /// The updated expiration date for the ban. Null for no change.
        /// </summary>
        public DateTime? Expires { get; set;}
        /// <summary>
        /// The updated IP address for the ban. Null for no change.
        /// </summary>
        public string IPAddress { get; set;}
        /// <summary>
        /// The updated MAC address for the ban. Null for no change.
        /// </summary>
        public string MACAddress { get; set;}
        /// <summary>
        /// Whether to make this ban permanent. Set to true to make this ban permanent. This will not modify Active state.
        /// </summary>
        public bool? Permanent { get; set;}
        /// <summary>
        /// The updated active state for the ban. Null for no change.
        /// </summary>
        public bool? Active { get; set;}
    }

    [Serializable]
    public class UpdateBansRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// List of bans to be updated. Maximum 100.
        /// </summary>
        public List<UpdateBanRequest> Bans { get; set;}
    }

    [Serializable]
    public class UpdateBansResult : PlayFabResultCommon
    {
        /// <summary>
        /// Information on the bans that were updated
        /// </summary>
        public List<BanInfo> BanData { get; set;}
    }

    [Serializable]
    public class UpdateCatalogItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Which catalog is being updated. If null, uses the default catalog.
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// Should this catalog be set as the default catalog. Defaults to true. If there is currently no default catalog, this will always set it.
        /// </summary>
        public bool? SetAsDefaultCatalog { get; set;}
        /// <summary>
        /// Array of catalog items to be submitted. Note that while CatalogItem has a parameter for CatalogVersion, it is not required and ignored in this call.
        /// </summary>
        public List<CatalogItem> Catalog { get; set;}
    }

    [Serializable]
    public class UpdateCatalogItemsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateCloudScriptRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Deprecated - Do not use
        /// </summary>
        [Obsolete("No longer available", true)]
        public int? Version { get; set;}
        /// <summary>
        /// List of Cloud Script files to upload to create the new revision. Must have at least one file.
        /// </summary>
        public List<CloudScriptFile> Files { get; set;}
        /// <summary>
        /// Immediately publish the new revision
        /// </summary>
        public bool Publish { get; set;}
        /// <summary>
        /// PlayFab user ID of the developer initiating the request.
        /// </summary>
        public string DeveloperPlayFabId { get; set;}
    }

    [Serializable]
    public class UpdateCloudScriptResult : PlayFabResultCommon
    {
        /// <summary>
        /// Cloud Script version updated
        /// </summary>
        public int Version { get; set;}
        /// <summary>
        /// New revision number created
        /// </summary>
        public int Revision { get; set;}
    }

    [Serializable]
    public class UpdatePlayerStatisticDefinitionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}
        /// <summary>
        /// interval at which the values of the statistic for all players are reset (changes are effective at the next occurance of the new interval boundary)
        /// </summary>
        public StatisticResetIntervalOption? VersionChangeInterval { get; set;}
        /// <summary>
        /// the aggregation method to use in updating the statistic (defaults to last)
        /// </summary>
        public StatisticAggregationMethod? AggregationMethod { get; set;}
    }

    [Serializable]
    public class UpdatePlayerStatisticDefinitionResult : PlayFabResultCommon
    {
        /// <summary>
        /// updated statistic definition
        /// </summary>
        public PlayerStatisticDefinition Statistic { get; set;}
    }

    [Serializable]
    public class UpdateRandomResultTablesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// which catalog is being updated. If null, update the current default catalog version
        /// </summary>
        public string CatalogVersion { get; set;}
        /// <summary>
        /// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that table, while any others will be added to the available set)
        /// </summary>
        public List<RandomResultTable> Tables { get; set;}
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
        public string CatalogVersion { get; set;}
        /// <summary>
        /// Unique identifier for the store which is to be updated
        /// </summary>
        public string StoreId { get; set;}
        /// <summary>
        /// Additional data about the store
        /// </summary>
        public StoreMarketingModel MarketingData { get; set;}
        /// <summary>
        /// Array of store items - references to catalog items, with specific pricing - to be added
        /// </summary>
        public List<StoreItem> Store { get; set;}
    }

    [Serializable]
    public class UpdateStoreItemsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateUserDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}
        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    [Serializable]
    public class UpdateUserDataResult : PlayFabResultCommon
    {
        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
    }

    [Serializable]
    public class UpdateUserInternalDataRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}
    }

    [Serializable]
    public class UpdateUserTitleDisplayNameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose title specific display name is to be changed
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// new title display name for the user - must be between 3 and 25 characters
        /// </summary>
        public string DisplayName { get; set;}
    }

    [Serializable]
    public class UpdateUserTitleDisplayNameResult : PlayFabResultCommon
    {
        /// <summary>
        /// current title display name for the user (this will be the original display name if the rename attempt failed)
        /// </summary>
        public string DisplayName { get; set;}
    }

    [Serializable]
    public class UserAccountInfo
    {
        /// <summary>
        /// Unique identifier for the user account
        /// </summary>
        public string PlayFabId { get; set;}
        /// <summary>
        /// Timestamp indicating when the user account was created
        /// </summary>
        public DateTime Created { get; set;}
        /// <summary>
        /// User account name in the PlayFab service
        /// </summary>
        public string Username { get; set;}
        /// <summary>
        /// Title-specific information for the user account
        /// </summary>
        public UserTitleInfo TitleInfo { get; set;}
        /// <summary>
        /// Personal information for the user which is considered more sensitive
        /// </summary>
        public UserPrivateAccountInfo PrivateInfo { get; set;}
        /// <summary>
        /// User Facebook information, if a Facebook account has been linked
        /// </summary>
        public UserFacebookInfo FacebookInfo { get; set;}
        /// <summary>
        /// User Steam information, if a Steam account has been linked
        /// </summary>
        public UserSteamInfo SteamInfo { get; set;}
        /// <summary>
        /// User Gamecenter information, if a Gamecenter account has been linked
        /// </summary>
        public UserGameCenterInfo GameCenterInfo { get; set;}
        /// <summary>
        /// User iOS device information, if an iOS device has been linked
        /// </summary>
        public UserIosDeviceInfo IosDeviceInfo { get; set;}
        /// <summary>
        /// User Android device information, if an Android device has been linked
        /// </summary>
        public UserAndroidDeviceInfo AndroidDeviceInfo { get; set;}
        /// <summary>
        /// User Kongregate account information, if a Kongregate account has been linked
        /// </summary>
        public UserKongregateInfo KongregateInfo { get; set;}
        /// <summary>
        /// User Twitch account information, if a Twitch account has been linked
        /// </summary>
        public UserTwitchInfo TwitchInfo { get; set;}
        /// <summary>
        /// User PSN account information, if a PSN account has been linked
        /// </summary>
        public UserPsnInfo PsnInfo { get; set;}
        /// <summary>
        /// User Google account information, if a Google account has been linked
        /// </summary>
        public UserGoogleInfo GoogleInfo { get; set;}
        /// <summary>
        /// User XBox account information, if a XBox account has been linked
        /// </summary>
        public UserXboxInfo XboxInfo { get; set;}
        /// <summary>
        /// Custom ID information, if a custom ID has been assigned
        /// </summary>
        public UserCustomIdInfo CustomIdInfo { get; set;}
    }

    [Serializable]
    public class UserAndroidDeviceInfo
    {
        /// <summary>
        /// Android device ID
        /// </summary>
        public string AndroidDeviceId { get; set;}
    }

    [Serializable]
    public class UserCredentials
    {
        /// <summary>
        /// Username of user to reset
        /// </summary>
        public string Username { get; set;}
        /// <summary>
        /// Password for the PlayFab account (6-100 characters)
        /// </summary>
        public string Password { get; set;}
    }

    [Serializable]
    public class UserCustomIdInfo
    {
        /// <summary>
        /// Custom ID
        /// </summary>
        public string CustomId { get; set;}
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
        public string Value { get; set;}
        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set;}
        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only the user (private). This is used for GetUserData requests being made by one player about another player.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    [Serializable]
    public class UserFacebookInfo
    {
        /// <summary>
        /// Facebook identifier
        /// </summary>
        public string FacebookId { get; set;}
        /// <summary>
        /// Facebook full name
        /// </summary>
        public string FullName { get; set;}
    }

    [Serializable]
    public class UserGameCenterInfo
    {
        /// <summary>
        /// Gamecenter identifier
        /// </summary>
        public string GameCenterId { get; set;}
    }

    [Serializable]
    public class UserGoogleInfo
    {
        /// <summary>
        /// Google ID
        /// </summary>
        public string GoogleId { get; set;}
        /// <summary>
        /// Email address of the Google account
        /// </summary>
        public string GoogleEmail { get; set;}
        /// <summary>
        /// Locale of the Google account
        /// </summary>
        public string GoogleLocale { get; set;}
        /// <summary>
        /// Gender information of the Google account
        /// </summary>
        public string GoogleGender { get; set;}
    }

    [Serializable]
    public class UserIosDeviceInfo
    {
        /// <summary>
        /// iOS device ID
        /// </summary>
        public string IosDeviceId { get; set;}
    }

    [Serializable]
    public class UserKongregateInfo
    {
        /// <summary>
        /// Kongregate ID
        /// </summary>
        public string KongregateId { get; set;}
        /// <summary>
        /// Kongregate Username
        /// </summary>
        public string KongregateName { get; set;}
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
        Twitch
    }

    [Serializable]
    public class UserPrivateAccountInfo
    {
        /// <summary>
        /// user email address
        /// </summary>
        public string Email { get; set;}
    }

    [Serializable]
    public class UserPsnInfo
    {
        /// <summary>
        /// PSN account ID
        /// </summary>
        public string PsnAccountId { get; set;}
        /// <summary>
        /// PSN online ID
        /// </summary>
        public string PsnOnlineId { get; set;}
    }

    [Serializable]
    public class UserSteamInfo
    {
        /// <summary>
        /// Steam identifier
        /// </summary>
        public string SteamId { get; set;}
        /// <summary>
        /// the country in which the player resides, from Steam data
        /// </summary>
        public string SteamCountry { get; set;}
        /// <summary>
        /// currency type set in the user Steam account
        /// </summary>
        public Currency? SteamCurrency { get; set;}
        /// <summary>
        /// what stage of game ownership the user is listed as being in, from Steam
        /// </summary>
        public TitleActivationStatus? SteamActivationStatus { get; set;}
    }

    [Serializable]
    public class UserTitleInfo
    {
        /// <summary>
        /// name of the user, as it is displayed in-game
        /// </summary>
        public string DisplayName { get; set;}
        /// <summary>
        /// source by which the user first joined the game, if known
        /// </summary>
        public UserOrigination? Origination { get; set;}
        /// <summary>
        /// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
        /// </summary>
        public DateTime Created { get; set;}
        /// <summary>
        /// timestamp for the last user login for this title
        /// </summary>
        public DateTime? LastLogin { get; set;}
        /// <summary>
        /// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
        /// </summary>
        public DateTime? FirstLogin { get; set;}
        /// <summary>
        /// boolean indicating whether or not the user is currently banned for a title
        /// </summary>
        public bool? isBanned { get; set;}
    }

    [Serializable]
    public class UserTwitchInfo
    {
        /// <summary>
        /// Twitch ID
        /// </summary>
        public string TwitchId { get; set;}
        /// <summary>
        /// Twitch Username
        /// </summary>
        public string TwitchUserName { get; set;}
    }

    [Serializable]
    public class UserXboxInfo
    {
        /// <summary>
        /// XBox user ID
        /// </summary>
        public string XboxUserId { get; set;}
    }

    [Serializable]
    public class VirtualCurrencyData
    {
        /// <summary>
        /// unique one- or two-character identifier for this currency type (e.g.: "CC", "G")
        /// </summary>
        public string CurrencyCode { get; set;}
        /// <summary>
        /// friendly name to show in the developer portal, reports, etc.
        /// </summary>
        public string DisplayName { get; set;}
        /// <summary>
        /// amount to automatically grant users upon first login to the title
        /// </summary>
        public int? InitialDeposit { get; set;}
        /// <summary>
        /// rate at which the currency automatically be added to over time, in units per day (24 hours)
        /// </summary>
        public int? RechargeRate { get; set;}
        /// <summary>
        /// maximum amount to which the currency will recharge (cannot exceed MaxAmount, but can be less)
        /// </summary>
        public int? RechargeMax { get; set;}
    }

    [Serializable]
    public class VirtualCurrencyRechargeTime
    {
        /// <summary>
        /// Time remaining (in seconds) before the next recharge increment of the virtual currency.
        /// </summary>
        public int SecondsToRecharge { get; set;}
        /// <summary>
        /// Server timestamp in UTC indicating the next time the virtual currency will be incremented.
        /// </summary>
        public DateTime RechargeTime { get; set;}
        /// <summary>
        /// Maximum value to which the regenerating currency will automatically increment. Note that it can exceed this value through use of the AddUserVirtualCurrency API call. However, it will not regenerate automatically until it has fallen below this value.
        /// </summary>
        public int RechargeMax { get; set;}
    }
}
#endif
