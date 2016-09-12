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
    public class PlayerAddedTitleEventData : PlayStreamEventBase
    {
        public LoginIdentityProvider? Platform;
        public string PlatformUserId;
        public string DisplayName;
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
        public string TitleId;
    }
    public class PlayerLeftLobbyEventData : PlayStreamEventBase
    {
        public string LobbyId;
        public string GameMode;
        public string Region;
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
        public string InstanceId { get; set;}
        /// <summary>
        /// Catalog item ID of the inventory item.
        /// </summary>
        public string ItemId { get; set;}
        /// <summary>
        /// Catalog version of the inventory item.
        /// </summary>
        public string CatalogVersion { get; set;}
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
        public string Level { get; set;}
        public string Message { get; set;}
        /// <summary>
        /// Optional object accompanying the message as contextual information
        /// </summary>
        public object Data { get; set;}
    }

    [Serializable]
    public class ScriptExecutionError
    {
        /// <summary>
        /// Error code, such as CloudScriptNotFound, JavascriptException, CloudScriptFunctionArgumentSizeExceeded, CloudScriptAPIRequestCountExceeded, CloudScriptAPIRequestError, or CloudScriptHTTPRequestError
        /// </summary>
        public string Error { get; set;}
        /// <summary>
        /// Details about the error
        /// </summary>
        public string Message { get; set;}
        /// <summary>
        /// Point during the execution of the script at which the error occurred, if any
        /// </summary>
        public string StackTrace { get; set;}
    }

    [Serializable]
    public class ExecuteCloudScriptResult
    {
        /// <summary>
        /// The name of the function that executed
        /// </summary>
        public string FunctionName { get; set;}
        /// <summary>
        /// The revision of the CloudScript that executed
        /// </summary>
        public int Revision { get; set;}
        /// <summary>
        /// The object returned from the CloudScript function, if any
        /// </summary>
        public object FunctionResult { get; set;}
        /// <summary>
        /// Entries logged during the function execution. These include both entries logged in the function code using log.info() and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public List<LogStatement> Logs { get; set;}
        public double ExecutionTimeSeconds { get; set;}
        /// <summary>
        /// Processor time consumed while executing the function. This does not include time spent waiting on API calls or HTTP requests.
        /// </summary>
        public double ProcessorTimeSeconds { get; set;}
        public uint MemoryConsumedBytes { get; set;}
        /// <summary>
        /// Number of PlayFab API requests issued by the CloudScript function
        /// </summary>
        public int APIRequestsIssued { get; set;}
        /// <summary>
        /// Number of external HTTP requests issued by the CloudScript function
        /// </summary>
        public int HttpRequestsIssued { get; set;}
        /// <summary>
        /// Information about the error, if any, that occured during execution
        /// </summary>
        public ScriptExecutionError Error { get; set;}
    }

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

    public enum SourceType
    {
        Admin,
        BackEnd,
        GameClient,
        GameServer,
        Partner,
        Stream
    }

    [Serializable]
    public class PlayStreamEventHistory
    {
        /// <summary>
        /// The ID of the trigger that caused this event to be created.
        /// </summary>
        public string ParentTriggerId { get; set;}
        /// <summary>
        /// The ID of the previous event that caused this event to be created by hitting a trigger.
        /// </summary>
        public string ParentEventId { get; set;}
        /// <summary>
        /// If true, then this event was allowed to trigger subsequent events in a trigger.
        /// </summary>
        public bool TriggeredEvents { get; set;}
    }

}
