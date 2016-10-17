using System;
using System.Collections.Generic;

namespace PlayFab.PlayStreamModels
{
    /// <summary>
    /// The base type for all PlayStream events.
    /// See https://api.playfab.com/playstream/docs/PlayStreamEventModels for more information
    /// </summary>
    public abstract class PlayStreamEventBase
    {
        public string Source;
        public string EventId;
        public string EntityId;
        public string EntityType;
        public string EventNamespace;
        public string EventName;
        public DateTime Timestamp;
        public Dictionary<string, string> CustomTags;
        public List<object> History;
        public object Reserved;
    }

    #region character
    public class CharacterConsumedItemEventData : PlayStreamEventBase
    {
        public string ItemId;
        public string ItemInstanceId;
        public string CatalogVersion;
        public uint PreviousUsesRemaining;
        public uint UsesRemaining;
        public string TitleId;
        public string PlayerId;
    }
    public class CharacterCreatedEventData : PlayStreamEventBase
    {
        public DateTime Created;
        public string CharacterName;
        public string TitleId;
        public string PlayerId;
    }
    public class CharacterInventoryItemAddedEventData : PlayStreamEventBase
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
        public List<string> BundleContents;
        public string TitleId;
        public string PlayerId;
    }
    public class CharacterStatisticChangedEventData : PlayStreamEventBase
    {
        public string StatisticName;
        public uint Version;
        public int StatisticValue;
        public int? StatisticPreviousValue;
        public string TitleId;
        public string PlayerId;
    }
    public class CharacterVCPurchaseEventData : PlayStreamEventBase
    {
        public string PurchaseId;
        public string ItemId;
        public string CatalogVersion;
        public string CurrencyCode;
        public int Quantity;
        public uint UnitPrice;
        public string TitleId;
        public string PlayerId;
    }
    public class CharacterVirtualCurrencyBalanceChangedEventData : PlayStreamEventBase
    {
        public string VirtualCurrencyName;
        public int VirtualCurrencyBalance;
        public int VirtualCurrencyPreviousBalance;
        public string OrderId;
        public string TitleId;
        public string PlayerId;
    }
    #endregion character

    #region partner
    public class DisplayNameFilteredEventData : PlayStreamEventBase
    {
        public string PlayerId;
        public string DisplayName;
    }
    #endregion partner

    #region player
    public class PlayerAdCampaignAttributionEventData : PlayStreamEventBase
    {
        public string CampaignId;
        public string TitleId;
    }
    public class PlayerAdClosedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string RewardId;
        public string RewardName;
        public string AdUnit;
        public string TitleId;
    }
    public class PlayerAddedTitleEventData : PlayStreamEventBase
    {
        public LoginIdentityProvider? Platform;
        public string PlatformUserId;
        public string DisplayName;
        public string TitleId;
    }
    public class PlayerAdEndedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string RewardId;
        public string RewardName;
        public string AdUnit;
        public string TitleId;
    }
    public class PlayerAdOpenedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string RewardId;
        public string RewardName;
        public string AdUnit;
        public string TitleId;
    }
    public class PlayerAdRewardedEventData : PlayStreamEventBase
    {
        public int? ViewsRemainingThisPeriod;
        public List<string> ActionGroupDebugMessages;
        public string AdPlacementId;
        public string AdPlacementName;
        public string RewardId;
        public string RewardName;
        public string AdUnit;
        public string TitleId;
    }
    public class PlayerAdRewardValuedEventData : PlayStreamEventBase
    {
        public double RevenueShare;
        public string AdPlacementId;
        public string AdPlacementName;
        public string RewardId;
        public string RewardName;
        public string AdUnit;
        public string TitleId;
    }
    public class PlayerAdStartedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string RewardId;
        public string RewardName;
        public string AdUnit;
        public string TitleId;
    }
    public class PlayerBannedEventData : PlayStreamEventBase
    {
        public DateTime? BanExpiration;
        public bool PermanentBan;
        public string BanId;
        public string BanReason;
        public string TitleId;
    }
    public class PlayerCompletedPasswordResetEventData : PlayStreamEventBase
    {
        public string RecoveryEmailAddress;
        public string PasswordResetId;
        public string InitiatedFromIPAddress;
        public DateTime InitiationTimestamp;
        public PasswordResetInitiationSource? InitiatedBy;
        public DateTime LinkExpiration;
        public string CompletedFromIPAddress;
        public DateTime CompletionTimestamp;
        public string TitleId;
    }
    public class PlayerConsumedItemEventData : PlayStreamEventBase
    {
        public string ItemId;
        public string CatalogVersion;
        public string ItemInstanceId;
        public uint PreviousUsesRemaining;
        public uint UsesRemaining;
        public string TitleId;
    }
    public class PlayerCreatedEventData : PlayStreamEventBase
    {
        public DateTime Created;
        public string PublisherId;
        public string TitleId;
    }
    public class PlayerDisplayNameChangedEventData : PlayStreamEventBase
    {
        public string PreviousDisplayName;
        public string DisplayName;
        public string TitleId;
    }
    public class PlayerExecutedCloudScriptEventData : PlayStreamEventBase
    {
        public string FunctionName;
        public ExecuteCloudScriptResult CloudScriptExecutionResult;
        public string TitleId;
    }
    public class PlayerInventoryItemAddedEventData : PlayStreamEventBase
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
        public List<string> BundleContents;
        public string TitleId;
    }
    public class PlayerJoinedLobbyEventData : PlayStreamEventBase
    {
        public string LobbyId;
        public string GameMode;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public uint ServerPort;
        public string ServerHostInstanceId;
        public string TitleId;
    }
    public class PlayerLeftLobbyEventData : PlayStreamEventBase
    {
        public string LobbyId;
        public string GameMode;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public uint ServerPort;
        public string ServerHostInstanceId;
        public string TitleId;
    }
    public class PlayerLinkedAccountEventData : PlayStreamEventBase
    {
        public LoginIdentityProvider? Origination;
        public string OriginationUserId;
        public string Username;
        public string Email;
        public string TitleId;
    }
    public class PlayerLoggedInEventData : PlayStreamEventBase
    {
        public LoginIdentityProvider? Platform;
        public string PlatformUserId;
        public string TitleId;
    }
    public class PlayerMatchedWithLobbyEventData : PlayStreamEventBase
    {
        public string LobbyId;
        public string GameMode;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public uint ServerPort;
        public string ServerHostInstanceId;
        public string TitleId;
    }
    public class PlayerPasswordResetLinkSentEventData : PlayStreamEventBase
    {
        public string RecoveryEmailAddress;
        public string InitiatedFromIPAddress;
        public PasswordResetInitiationSource? InitiatedBy;
        public string PasswordResetId;
        public DateTime LinkExpiration;
        public string TitleId;
    }
    public class PlayerRealMoneyPurchaseEventData : PlayStreamEventBase
    {
        public string PaymentProvider;
        public PaymentType? PaymentType;
        public uint OrderTotal;
        public uint? TransactionTotal;
        public Currency? TransactionCurrency;
        public string OrderId;
        public string TitleId;
    }
    public class PlayerRedeemedCouponEventData : PlayStreamEventBase
    {
        public string CouponCode;
        public List<CouponGrantedInventoryItem> GrantedInventoryItems;
        public string TitleId;
    }
    public class PlayerRegisteredPushNotificationsEventData : PlayStreamEventBase
    {
        public PushNotificationPlatform? Platform;
        public string DeviceToken;
        public string TitleId;
    }
    public class PlayerReportedAsAbusiveEventData : PlayStreamEventBase
    {
        public string ReportedByPlayer;
        public string Comment;
        public string TitleId;
    }
    public class PlayerStatisticChangedEventData : PlayStreamEventBase
    {
        public string StatisticName;
        public uint StatisticId;
        public uint Version;
        public int StatisticValue;
        public int? StatisticPreviousValue;
        public StatisticAggregationMethod? AggregationMethod;
        public string TitleId;
    }
    public class PlayerStatisticDeletedEventData : PlayStreamEventBase
    {
        public string StatisticName;
        public uint StatisticId;
        public uint Version;
        public int? StatisticPreviousValue;
        public string TitleId;
    }
    public class PlayerTagAddedEventData : PlayStreamEventBase
    {
        public string TagName;
        public string Namespace;
        public string TitleId;
    }
    public class PlayerTagRemovedEventData : PlayStreamEventBase
    {
        public string TagName;
        public string Namespace;
        public string TitleId;
    }
    public class PlayerTriggeredActionExecutedCloudScriptEventData : PlayStreamEventBase
    {
        public string FunctionName;
        public ExecuteCloudScriptResult CloudScriptExecutionResult;
        public object TriggeringEventData;
        public string TriggeringEventName;
        public PlayerProfile TriggeringPlayer;
        public string TitleId;
    }
    public class PlayerUnlinkedAccountEventData : PlayStreamEventBase
    {
        public LoginIdentityProvider? Origination;
        public string OriginationUserId;
        public string TitleId;
    }
    public class PlayerVCPurchaseEventData : PlayStreamEventBase
    {
        public string PurchaseId;
        public string ItemId;
        public string CatalogVersion;
        public string CurrencyCode;
        public int Quantity;
        public uint UnitPrice;
        public string TitleId;
    }
    public class PlayerVirtualCurrencyBalanceChangedEventData : PlayStreamEventBase
    {
        public string VirtualCurrencyName;
        public int VirtualCurrencyBalance;
        public int VirtualCurrencyPreviousBalance;
        public string OrderId;
        public string TitleId;
    }
    #endregion player

    #region session
    public class GameLobbyEndedEventData : PlayStreamEventBase
    {
        public string TitleId;
        public string GameMode;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public uint ServerPort;
        public string ServerHostInstanceId;
        public Dictionary<string,string> Tags;
    }
    public class GameLobbyStartedEventData : PlayStreamEventBase
    {
        public string GameServerData;
        public string CustomCommandLineData;
        public string CustomMatchmakerEndpoint;
        public int? MaxPlayers;
        public string TitleId;
        public string GameMode;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public uint ServerPort;
        public string ServerHostInstanceId;
        public Dictionary<string,string> Tags;
    }
    public class SessionEndedEventData : PlayStreamEventBase
    {
        public DateTime EndTime;
        public string UserId;
        public double? KilobytesWritten;
        public double SessionLengthMs;
        public bool Crashed;
        public string TitleId;
    }
    public class SessionStartedEventData : PlayStreamEventBase
    {
        public string TemporaryWriteUrl;
        public string TitleId;
    }
    #endregion session

    #region title
    public class TitleAddedCloudScriptEventData : PlayStreamEventBase
    {
        public int Version;
        public int Revision;
        public bool Published;
        public List<string> ScriptNames;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleAddedGameBuildEventData : PlayStreamEventBase
    {
        public string BuildId;
        public List<Region> Regions;
        public int MinFreeGameSlots;
        public int MaxGamesPerHost;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleAPISettingsChangedEventData : PlayStreamEventBase
    {
        public APISettings PreviousSettingsValues;
        public APISettings SettingsValues;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleCatalogUpdatedEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public bool Deleted;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleClientRateLimitedEventData : PlayStreamEventBase
    {
        public string GraphUrl;
        public string AlertEventId;
        public string API;
        public string ErrorCode;
        public AlertLevel? Level;
        public AlertStates? AlertState;
    }
    public class TitleExceededLimitEventData : PlayStreamEventBase
    {
        public string LimitId;
        public string LimitDisplayName;
        public MetricUnit? Unit;
        public double LimitValue;
        public double Value;
        public Dictionary<string,object> Details;
    }
    public class TitleHighErrorRateEventData : PlayStreamEventBase
    {
        public string GraphUrl;
        public string AlertEventId;
        public string API;
        public string ErrorCode;
        public AlertLevel? Level;
        public AlertStates? AlertState;
    }
    public class TitleInitiatedPlayerPasswordResetEventData : PlayStreamEventBase
    {
        public string PlayerId;
        public string PlayerRecoveryEmailAddress;
        public string PasswordResetId;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleLimitChangedEventData : PlayStreamEventBase
    {
        public string LimitId;
        public string LimitDisplayName;
        public MetricUnit? Unit;
        public string TransactionId;
        public double? PreviousPriceUSD;
        public double? PreviousValue;
        public double? PriceUSD;
        public double? Value;
    }
    public class TitleModifiedGameBuildEventData : PlayStreamEventBase
    {
        public string BuildId;
        public List<Region> Regions;
        public int MinFreeGameSlots;
        public int MaxGamesPerHost;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleNewsUpdatedEventData : PlayStreamEventBase
    {
        public string NewsId;
        public string NewsTitle;
        public DateTime DateCreated;
        public NewsStatus? Status;
    }
    public class TitlePublishedCloudScriptEventData : PlayStreamEventBase
    {
        public int Revision;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleRequestedLimitChangeEventData : PlayStreamEventBase
    {
        public string LimitId;
        public string LimitDisplayName;
        public MetricUnit? Unit;
        public string TransactionId;
        public string PreviousLevelName;
        public double? PreviousPriceUSD;
        public double? PreviousValue;
        public string LevelName;
        public double? PriceUSD;
        public double? Value;
        public string UserId;
        public string DeveloperId;
    }
    public class TitleScheduledCloudScriptExecutedEventData : PlayStreamEventBase
    {
        public NameId ScheduledTask;
        public string FunctionName;
        public ExecuteCloudScriptResult CloudScriptExecutionResult;
    }
    public class TitleStatisticVersionChangedEventData : PlayStreamEventBase
    {
        public string StatisticName;
        public uint StatisticVersion;
        public StatisticResetIntervalOption? ScheduledResetInterval;
        public DateTime? ScheduledResetTime;
    }
    public class TitleStoreUpdatedEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public string StoreId;
        public bool Deleted;
        public string UserId;
        public string DeveloperId;
    }
    #endregion title

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

    public enum PasswordResetInitiationSource
    {
        Self,
        Admin
    }

    [Serializable]
    public class CouponGrantedInventoryItem
    {
        /// <summary>
        /// Unique instance ID of the inventory item.
        /// </summary>
        public string InstanceId;
        /// <summary>
        /// Catalog item ID of the inventory item.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// Catalog version of the inventory item.
        /// </summary>
        public string CatalogVersion;
    }

    public enum PaymentType
    {
        Purchase,
        ReceiptValidation
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
    public class ExecuteCloudScriptResult
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
    public class APISettings
    {
        /// <summary>
        /// Allow game clients to add to virtual currency balances via API.
        /// </summary>
        public bool AllowClientToAddVirtualCurrency;
        /// <summary>
        /// Allow game clients to subtract from virtual currency balances via API.
        /// </summary>
        public bool AllowClientToSubtractVirtualCurrency;
        /// <summary>
        /// Allow game clients to update statistic values via API.
        /// </summary>
        public bool AllowClientToPostPlayerStatistics;
        /// <summary>
        /// Allow clients to start multiplayer game sessions via API.
        /// </summary>
        public bool AllowClientToStartGames;
        /// <summary>
        /// Allow game servers to delete player accounts via API.
        /// </summary>
        public bool AllowServerToDeleteUsers;
        /// <summary>
        /// Use payment provider's sandbox mode (if available) for real-money purchases. This can be useful when testing in-game purchasing in order to avoid being charged.
        /// </summary>
        public bool UseSandboxPayments;
        /// <summary>
        /// Multiplayer game sessions are hosted on servers external to PlayFab.
        /// </summary>
        public bool UseExternalGameServerProvider;
        /// <summary>
        /// Allow players to choose display names that may be in use by other players, i.e. do not enforce uniqueness of display names. Note: if this option is enabled, it cannot be disabled later.
        /// </summary>
        public bool AllowNonUniquePlayerDisplayNames;
    }

    public enum StatisticAggregationMethod
    {
        Last,
        Min,
        Max,
        Sum
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

    public enum AlertLevel
    {
        Warn,
        Alert,
        Critical
    }

    public enum AlertStates
    {
        Triggered,
        Recovered,
        ReTriggered
    }

    public enum NewsStatus
    {
        None,
        Unpublished,
        Published,
        Archived
    }

    public enum MetricUnit
    {
        Value,
        Count,
        Percent,
        Milliseconds,
        Seconds,
        Hours,
        Days,
        Bits,
        Bytes,
        Kilobytes,
        Megabytes,
        Gigabytes,
        Terabytes,
        Bytes_Per_Second,
        MonthlyActiveUsers
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
    public class NameId
    {
        public string Name;
        public string Id;
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
    public class PlayStreamEventHistory
    {
        /// <summary>
        /// The ID of the trigger that caused this event to be created.
        /// </summary>
        public string ParentTriggerId;
        /// <summary>
        /// The ID of the previous event that caused this event to be created by hitting a trigger.
        /// </summary>
        public string ParentEventId;
        /// <summary>
        /// If true, then this event was allowed to trigger subsequent events in a trigger.
        /// </summary>
        public bool TriggeredEvents;
    }

}
