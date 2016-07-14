#if ENABLE_PLAYFABADMIN_API
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.AdminModels
{
    [Serializable]
    public class AddNewsRequest
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
    public class AddServerBuildRequest
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
    public class AddUserVirtualCurrencyRequest
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
    public class AddVirtualCurrencyTypesRequest
    {

        /// <summary>
        /// List of virtual currencies and their initial deposits (the amount a user is granted when signing in for the first time) to the title
        /// </summary>
        public List<VirtualCurrencyData> VirtualCurrencies { get; set;}
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
    public class CreatePlayerStatisticDefinitionRequest
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
    public class DeleteContentRequest
    {

        /// <summary>
        /// Key of the content item to be deleted
        /// </summary>
        public string Key { get; set;}
    }

    [Serializable]
    public class DeleteUsersRequest
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
    public class GetCatalogItemsRequest
    {

        /// <summary>
        /// Which catalog is being requested.
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
    public class GetCloudScriptRevisionRequest
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
    public class GetCloudScriptVersionsRequest
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
    public class GetContentListRequest
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
    public class GetContentUploadUrlRequest
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
    public class GetDataReportRequest
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
    public class GetMatchmakerGameInfoRequest
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
    public class GetMatchmakerGameModesRequest
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
    public class GetPlayerStatisticDefinitionsRequest
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
    public class GetPlayerStatisticVersionsRequest
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
    public class GetPublisherDataRequest
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
    public class GetRandomResultTablesRequest : PlayFabResultCommon
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
    public class GetServerBuildInfoRequest
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
    public class GetServerBuildUploadURLRequest
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
    public class GetStoreItemsRequest
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
    }

    [Serializable]
    public class GetTitleDataRequest
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
    public class GetUserDataRequest
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
    public class GetUserInventoryRequest
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
    public class GrantItemsToUsersRequest
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
    public class IncrementPlayerStatisticVersionRequest
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
    /// A unique instance of an item in a user's inventory
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
    public class ListBuildsRequest
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
    public class ListVirtualCurrencyTypesRequest
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

    [Serializable]
    public class LookupUserAccountInfoRequest
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
    public class ModifyMatchmakerGameModesRequest
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
    public class ModifyServerBuildRequest
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

    [Serializable]
    public class RandomResultTable : PlayFabResultCommon
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
    public class RandomResultTableListing : PlayFabResultCommon
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
    public class RemoveServerBuildRequest
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
    public class ResetCharacterStatisticsRequest
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
    public class ResetUsersRequest
    {

        /// <summary>
        /// Array of users to reset
        /// </summary>
        public List<UserCredentials> Users { get; set;}
    }

    [Serializable]
    public class ResetUserStatisticsRequest
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
    public class ResultTableNode : PlayFabResultCommon
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
    public class RevokeInventoryItemRequest
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
    public class SendAccountRecoveryEmailRequest
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
    public class SetPublishedRevisionRequest
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
    public class SetPublisherDataRequest
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
    public class SetTitleDataRequest
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
    public class SetupPushNotificationRequest
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
        /// unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the catalog
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}

        /// <summary>
        /// override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices { get; set;}
    }

    [Serializable]
    public class SubtractUserVirtualCurrencyRequest
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

    [Serializable]
    public class UpdateCatalogItemsRequest
    {

        /// <summary>
        /// Which catalog is being updated
        /// </summary>
        public string CatalogVersion { get; set;}

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
    public class UpdateCloudScriptRequest
    {

        /// <summary>
        /// Deprecated - unused
        /// </summary>
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
    public class UpdatePlayerStatisticDefinitionRequest
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
    public class UpdateRandomResultTablesRequest : PlayFabResultCommon
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
    public class UpdateStoreItemsRequest
    {

        /// <summary>
        /// catalog version of the store to update. Use default catalog version if null
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// unqiue identifier for the store which is to be updated
        /// </summary>
        public string StoreId { get; set;}

        /// <summary>
        /// array of store items - references to catalog items, with specific pricing - to be added
        /// </summary>
        public List<StoreItem> Store { get; set;}
    }

    [Serializable]
    public class UpdateStoreItemsResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class UpdateUserDataRequest
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
    public class UpdateUserInternalDataRequest
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
    public class UpdateUserTitleDisplayNameRequest
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
        /// User-supplied data for this user data key.
        /// </summary>
        public string Value { get; set;}

        /// <summary>
        /// Timestamp indicating when this data was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set;}

        /// <summary>
        /// Permissions on this data key.
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
        /// unique two-character identifier for this currency type (e.g.: "CC", "GC")
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