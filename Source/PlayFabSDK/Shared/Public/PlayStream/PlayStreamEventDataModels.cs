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

    #region none
    public class EntityCreatedEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
    }
    public class EntityExecutedCloudScriptEventData : PlayStreamEventBase
    {
        public ExecuteCloudScriptResult CloudScriptExecutionResult;
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string FunctionName;
    }
    public class EntityFilesSetEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public List<FileSet> Files;
    }
    public class EntityLoggedInEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
    }
    public class EntityObjectsSetEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public List<ObjectSet> Objects;
    }
    public class GroupCreatedEventData : PlayStreamEventBase
    {
        public string CreatorEntityId;
        public string CreatorEntityType;
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
    }
    public class GroupDeletedEventData : PlayStreamEventBase
    {
        public string DeleterEntityId;
        public string DeleterEntityType;
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
    }
    public class GroupMembersAddedEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public List<Member> Members;
        public string RoleId;
        public string RoleName;
    }
    public class GroupMembersRemovedEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public List<Member> Members;
    }
    public class GroupRoleCreatedEventData : PlayStreamEventBase
    {
        public string CreatorEntityId;
        public string CreatorEntityType;
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public string RoleId;
        public string RoleName;
    }
    public class GroupRoleDeletedEventData : PlayStreamEventBase
    {
        public string DeleterEntityId;
        public string DeleterEntityType;
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public string RoleId;
        public string RoleName;
    }
    public class GroupRoleMembersAddedEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public List<Member> Members;
        public string RoleId;
        public string RoleName;
    }
    public class GroupRoleMembersRemovedEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public List<Member> Members;
        public string RoleId;
        public string RoleName;
    }
    public class GroupRoleUpdatedEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public RolePropertyValues NewValues;
        public RolePropertyValues OldValues;
        public string RoleId;
        public string RoleName;
        public string UpdaterEntityId;
        public string UpdaterEntityType;
    }
    public class GroupUpdatedEventData : PlayStreamEventBase
    {
        public string EntityChain;
        public EntityLineage EntityLineage;
        public string GroupName;
        public GroupPropertyValues NewValues;
        public GroupPropertyValues OldValues;
        public string UpdaterEntityId;
        public string UpdaterEntityType;
    }
    public class StudioCreatedEventData : PlayStreamEventBase
    {
        public string CreatorAuthenticationId;
        public string CreatorPlayFabId;
        public string StudioName;
    }
    public class StudioUserAddedEventData : PlayStreamEventBase
    {
        public string AuthenticationId;
        public AuthenticationProvider? AuthenticationProvider;
        public string AuthenticationProviderId;
        public string Email;
        public string InvitationId;
        public string PlayFabId;
        public List<string> StudioPermissions;
        public Dictionary<string,string> TitlePermissions;
    }
    public class StudioUserInvitedEventData : PlayStreamEventBase
    {
        public AuthenticationProvider? AuthenticationProvider;
        public string AuthenticationProviderId;
        public string Email;
        public DateTime? InvitationExpires;
        public string InvitationId;
        public bool InvitedExistingUser;
        public string InvitorPlayFabId;
        public List<string> StudioPermissions;
        public Dictionary<string,string> TitlePermissions;
    }
    public class StudioUserRemovedEventData : PlayStreamEventBase
    {
        public string AuthenticationId;
        public AuthenticationProvider? AuthenticationProvider;
        public string AuthenticationProviderId;
        public string PlayFabId;
        public List<string> StudioPermissions;
        public Dictionary<string,string> TitlePermissions;
    }
    #endregion none

    #region character
    public class CharacterConsumedItemEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public string ItemId;
        public string ItemInstanceId;
        public string PlayerId;
        public uint PreviousUsesRemaining;
        public string TitleId;
        public uint UsesRemaining;
    }
    public class CharacterCreatedEventData : PlayStreamEventBase
    {
        public string CharacterName;
        public DateTime Created;
        public string PlayerId;
        public string TitleId;
    }
    public class CharacterInventoryItemAddedEventData : PlayStreamEventBase
    {
        public string Annotation;
        public List<string> BundleContents;
        public string CatalogVersion;
        public string Class;
        public string CouponCode;
        public string DisplayName;
        public DateTime? Expiration;
        public string InstanceId;
        public string ItemId;
        public string PlayerId;
        public uint? RemainingUses;
        public string TitleId;
    }
    public class CharacterStatisticChangedEventData : PlayStreamEventBase
    {
        public string PlayerId;
        public string StatisticName;
        public int? StatisticPreviousValue;
        public int StatisticValue;
        public string TitleId;
        public uint Version;
    }
    public class CharacterVCPurchaseEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public string CurrencyCode;
        public string ItemId;
        public string PlayerId;
        public string PurchaseId;
        public int Quantity;
        public string StoreId;
        public string TitleId;
        public uint UnitPrice;
    }
    public class CharacterVirtualCurrencyBalanceChangedEventData : PlayStreamEventBase
    {
        public string OrderId;
        public string PlayerId;
        public string TitleId;
        public int VirtualCurrencyBalance;
        public string VirtualCurrencyName;
        public int VirtualCurrencyPreviousBalance;
    }
    #endregion character

    #region partner
    public class DisplayNameFilteredEventData : PlayStreamEventBase
    {
        public string DisplayName;
        public string PlayerId;
    }
    public class PlayerDisplayNameFilteredEventData : PlayStreamEventBase
    {
        public string DisplayName;
        public string TitleId;
    }
    public class PlayerPhotonSessionAuthenticatedEventData : PlayStreamEventBase
    {
        public string PhotonApplicationId;
        public PhotonServicesEnum? PhotonApplicationType;
        public string TitleId;
    }
    #endregion partner

    #region player
    public class AuthTokenValidatedEventData : PlayStreamEventBase
    {
        public string EmailTemplateId;
        public string TitleId;
        public string Token;
    }
    public class PlayerAdCampaignAttributionEventData : PlayStreamEventBase
    {
        public string CampaignId;
        public string TitleId;
    }
    public class PlayerAdClosedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string AdUnit;
        public string RewardId;
        public string RewardName;
        public string TitleId;
    }
    public class PlayerAddedTitleEventData : PlayStreamEventBase
    {
        public string DisplayName;
        public LoginIdentityProvider? Platform;
        public string PlatformUserId;
        public string TitleId;
    }
    public class PlayerAdEndedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string AdUnit;
        public string RewardId;
        public string RewardName;
        public string TitleId;
    }
    public class PlayerAdOpenedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string AdUnit;
        public string RewardId;
        public string RewardName;
        public string TitleId;
    }
    public class PlayerAdRewardedEventData : PlayStreamEventBase
    {
        public List<string> ActionGroupDebugMessages;
        public string AdPlacementId;
        public string AdPlacementName;
        public string AdUnit;
        public string RewardId;
        public string RewardName;
        public string TitleId;
        public int? ViewsRemainingThisPeriod;
    }
    public class PlayerAdRewardValuedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string AdUnit;
        public double RevenueShare;
        public string RewardId;
        public string RewardName;
        public string TitleId;
    }
    public class PlayerAdStartedEventData : PlayStreamEventBase
    {
        public string AdPlacementId;
        public string AdPlacementName;
        public string AdUnit;
        public string RewardId;
        public string RewardName;
        public string TitleId;
    }
    public class PlayerBannedEventData : PlayStreamEventBase
    {
        public DateTime? BanExpiration;
        public string BanId;
        public string BanReason;
        public bool PermanentBan;
        public string TitleId;
    }
    public class PlayerChangedAvatarEventData : PlayStreamEventBase
    {
        public string ImageUrl;
        public string PreviousImageUrl;
        public string TitleId;
    }
    public class PlayerCompletedPasswordResetEventData : PlayStreamEventBase
    {
        public string CompletedFromIPAddress;
        public DateTime CompletionTimestamp;
        public PasswordResetInitiationSource? InitiatedBy;
        public string InitiatedFromIPAddress;
        public DateTime InitiationTimestamp;
        public DateTime LinkExpiration;
        public string PasswordResetId;
        public string RecoveryEmailAddress;
        public string TitleId;
    }
    public class PlayerConsumedItemEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public string ItemId;
        public string ItemInstanceId;
        public uint PreviousUsesRemaining;
        public string TitleId;
        public uint UsesRemaining;
    }
    public class PlayerCreatedEventData : PlayStreamEventBase
    {
        public DateTime Created;
        public string PublisherId;
        public string TitleId;
    }
    public class PlayerDataExportedEventData : PlayStreamEventBase
    {
        public string ExportDownloadUrl;
        public string JobReceiptId;
        public DateTime RequestTime;
        public string TitleId;
    }
    public class PlayerDisplayNameChangedEventData : PlayStreamEventBase
    {
        public string DisplayName;
        public string PreviousDisplayName;
        public string TitleId;
    }
    public class PlayerExecutedCloudScriptEventData : PlayStreamEventBase
    {
        public ExecuteCloudScriptResult CloudScriptExecutionResult;
        public string FunctionName;
        public string TitleId;
    }
    public class PlayerInventoryItemAddedEventData : PlayStreamEventBase
    {
        public string Annotation;
        public List<string> BundleContents;
        public string CatalogVersion;
        public string Class;
        public string CouponCode;
        public string DisplayName;
        public DateTime? Expiration;
        public string InstanceId;
        public string ItemId;
        public uint? RemainingUses;
        public string TitleId;
    }
    public class PlayerJoinedLobbyEventData : PlayStreamEventBase
    {
        public string GameMode;
        public string LobbyId;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public string ServerHostInstanceId;
        public string ServerIPV6Address;
        public uint ServerPort;
        public string TitleId;
    }
    public class PlayerLeftLobbyEventData : PlayStreamEventBase
    {
        public string GameMode;
        public string LobbyId;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public string ServerHostInstanceId;
        public string ServerIPV6Address;
        public uint ServerPort;
        public string TitleId;
    }
    public class PlayerLinkedAccountEventData : PlayStreamEventBase
    {
        public string Email;
        public LoginIdentityProvider? Origination;
        public string OriginationUserId;
        public string TitleId;
        public string Username;
    }
    public class PlayerLoggedInEventData : PlayStreamEventBase
    {
        public EventLocation Location;
        public LoginIdentityProvider? Platform;
        public string PlatformUserId;
        public string TitleId;
    }
    public class PlayerMatchedWithLobbyEventData : PlayStreamEventBase
    {
        public string GameMode;
        public string LobbyId;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public string ServerHostInstanceId;
        public string ServerIPV6Address;
        public uint ServerPort;
        public string TitleId;
    }
    public class PlayerPasswordResetLinkSentEventData : PlayStreamEventBase
    {
        public PasswordResetInitiationSource? InitiatedBy;
        public string InitiatedFromIPAddress;
        public DateTime LinkExpiration;
        public string PasswordResetId;
        public string RecoveryEmailAddress;
        public string TitleId;
    }
    public class PlayerPayForPurchaseEventData : PlayStreamEventBase
    {
        public string OrderId;
        public string ProviderData;
        public string ProviderName;
        public string ProviderToken;
        public string PurchaseConfirmationPageURL;
        public string PurchaseCurrency;
        public uint PurchasePrice;
        public TransactionStatus? Status;
        public string TitleId;
        public Dictionary<string,int> VirtualCurrencyBalances;
        public Dictionary<string,int> VirtualCurrencyGrants;
    }
    public class PlayerRankedOnLeaderboardVersionEventData : PlayStreamEventBase
    {
        public LeaderboardSource LeaderboardSource;
        public uint Rank;
        public string TitleId;
        public int Value;
        public uint Version;
        public LeaderboardVersionChangeBehavior? VersionChangeBehavior;
    }
    public class PlayerRealMoneyPurchaseEventData : PlayStreamEventBase
    {
        public string OrderId;
        public uint OrderTotal;
        public string PaymentProvider;
        public PaymentType? PaymentType;
        public List<string> PurchasedProduct;
        public string TitleId;
        public Currency? TransactionCurrency;
        public string TransactionId;
        public uint? TransactionTotal;
    }
    public class PlayerReceiptValidationEventData : PlayStreamEventBase
    {
        public string Error;
        public string PaymentProvider;
        public PaymentType? PaymentType;
        public string ReceiptContent;
        public string TitleId;
        public bool Valid;
    }
    public class PlayerRedeemedCouponEventData : PlayStreamEventBase
    {
        public string CouponCode;
        public List<CouponGrantedInventoryItem> GrantedInventoryItems;
        public string TitleId;
    }
    public class PlayerRegisteredPushNotificationsEventData : PlayStreamEventBase
    {
        public string DeviceToken;
        public PushNotificationPlatform? Platform;
        public string TitleId;
    }
    public class PlayerRemovedTitleEventData : PlayStreamEventBase
    {
        public string TitleId;
    }
    public class PlayerReportedAsAbusiveEventData : PlayStreamEventBase
    {
        public string Comment;
        public string ReportedByPlayer;
        public string TitleId;
    }
    public class PlayerSetProfilePropertyEventData : PlayStreamEventBase
    {
        public PlayerProfileProperty? Property;
        public string TitleId;
        public object Value;
    }
    public class PlayerStartPurchaseEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public List<CartItem> Contents;
        public string OrderId;
        public string StoreId;
        public string TitleId;
    }
    public class PlayerStatisticChangedEventData : PlayStreamEventBase
    {
        public StatisticAggregationMethod? AggregationMethod;
        public uint StatisticId;
        public string StatisticName;
        public int? StatisticPreviousValue;
        public int StatisticValue;
        public string TitleId;
        public uint Version;
    }
    public class PlayerStatisticDeletedEventData : PlayStreamEventBase
    {
        public uint StatisticId;
        public string StatisticName;
        public int? StatisticPreviousValue;
        public string TitleId;
        public uint Version;
    }
    public class PlayerTagAddedEventData : PlayStreamEventBase
    {
        public string Namespace;
        public string TagName;
        public string TitleId;
    }
    public class PlayerTagRemovedEventData : PlayStreamEventBase
    {
        public string Namespace;
        public string TagName;
        public string TitleId;
    }
    public class PlayerTriggeredActionExecutedCloudScriptEventData : PlayStreamEventBase
    {
        public ExecuteCloudScriptResult CloudScriptExecutionResult;
        public string FunctionName;
        public string TitleId;
        public object TriggeringEventData;
        public string TriggeringEventName;
        public PlayerProfile TriggeringPlayer;
    }
    public class PlayerUnlinkedAccountEventData : PlayStreamEventBase
    {
        public LoginIdentityProvider? Origination;
        public string OriginationUserId;
        public string TitleId;
    }
    public class PlayerUpdatedContactEmailEventData : PlayStreamEventBase
    {
        public string EmailName;
        public string NewEmailAddress;
        public string PreviousEmailAddress;
        public string TitleId;
    }
    public class PlayerVCPurchaseEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public string CurrencyCode;
        public string ItemId;
        public string PurchaseId;
        public int Quantity;
        public string StoreId;
        public string TitleId;
        public uint UnitPrice;
    }
    public class PlayerVerifiedContactEmailEventData : PlayStreamEventBase
    {
        public string EmailAddress;
        public string EmailName;
        public string TitleId;
    }
    public class PlayerVirtualCurrencyBalanceChangedEventData : PlayStreamEventBase
    {
        public string OrderId;
        public string TitleId;
        public int VirtualCurrencyBalance;
        public string VirtualCurrencyName;
        public int VirtualCurrencyPreviousBalance;
    }
    public class SentEmailEventData : PlayStreamEventBase
    {
        public string Body;
        public string EmailName;
        public string EmailTemplateId;
        public string EmailTemplateName;
        public EmailTemplateType? EmailTemplateType;
        public string ErrorMessage;
        public string ErrorName;
        public string Subject;
        public bool Success;
        public string TitleId;
        public string Token;
    }
    #endregion player

    #region session
    public class GameLobbyEndedEventData : PlayStreamEventBase
    {
        public string GameMode;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public string ServerHostInstanceId;
        public string ServerIPV6Address;
        public uint ServerPort;
        public Dictionary<string,string> Tags;
        public string TitleId;
    }
    public class GameLobbyStartedEventData : PlayStreamEventBase
    {
        public string CustomCommandLineData;
        public string CustomMatchmakerEndpoint;
        public string GameMode;
        public string GameServerData;
        public int? MaxPlayers;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public string ServerHostInstanceId;
        public string ServerIPV6Address;
        public uint ServerPort;
        public Dictionary<string,string> Tags;
        public string TitleId;
    }
    public class GameServerHostStartedEventData : PlayStreamEventBase
    {
        public string InstanceId;
        public string InstanceProvider;
        public string InstanceType;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public string ServerIPV6Address;
        public DateTime StartTime;
        public string TitleId;
    }
    public class GameServerHostStoppedEventData : PlayStreamEventBase
    {
        public string InstanceId;
        public string InstanceProvider;
        public string InstanceType;
        public string Region;
        public string ServerBuildVersion;
        public string ServerHost;
        public string ServerIPV6Address;
        public DateTime StartTime;
        public GameServerHostStopReason? StopReason;
        public DateTime StopTime;
        public string TitleId;
    }
    public class SessionEndedEventData : PlayStreamEventBase
    {
        public bool Crashed;
        public DateTime EndTime;
        public double? KilobytesWritten;
        public double SessionLengthMs;
        public string TitleId;
        public string UserId;
    }
    public class SessionStartedEventData : PlayStreamEventBase
    {
        public string TemporaryWriteUrl;
        public string TitleId;
    }
    #endregion session

    #region title
    public class TitleAbortedTaskEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public string TaskInstanceId;
        public string UserId;
    }
    public class TitleAddedCloudScriptEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public bool Published;
        public int Revision;
        public List<string> ScriptNames;
        public string UserId;
        public int Version;
    }
    public class TitleAddedGameBuildEventData : PlayStreamEventBase
    {
        public string BuildId;
        public string DeveloperId;
        public int MaxGamesPerHost;
        public int MinFreeGameSlots;
        public List<Region> Regions;
        public string UserId;
    }
    public class TitleAPISettingsChangedEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public APISettings PreviousSettingsValues;
        public APISettings SettingsValues;
        public string UserId;
    }
    public class TitleCatalogUpdatedEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public bool Deleted;
        public string DeveloperId;
        public string UserId;
    }
    public class TitleClientRateLimitedEventData : PlayStreamEventBase
    {
        public string AlertEventId;
        public AlertStates? AlertState;
        public string API;
        public string ErrorCode;
        public string GraphUrl;
        public AlertLevel? Level;
    }
    public class TitleCompletedTaskEventData : PlayStreamEventBase
    {
        public DateTime? AbortedAt;
        public bool IsAborted;
        public TaskInstanceStatus? Result;
        public object Summary;
        public string TaskInstanceId;
        public string TaskType;
    }
    public class TitleCreatedTaskEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public NameIdentifier ScheduledTask;
        public string UserId;
    }
    public class TitleDeletedEventData : PlayStreamEventBase
    {
    }
    public class TitleDeletedTaskEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public NameIdentifier ScheduledTask;
        public string UserId;
    }
    public class TitleExceededLimitEventData : PlayStreamEventBase
    {
        public Dictionary<string,object> Details;
        public string LimitDisplayName;
        public string LimitId;
        public double LimitValue;
        public MetricUnit? Unit;
        public double Value;
    }
    public class TitleHighErrorRateEventData : PlayStreamEventBase
    {
        public string AlertEventId;
        public AlertStates? AlertState;
        public string API;
        public string ErrorCode;
        public string GraphUrl;
        public AlertLevel? Level;
    }
    public class TitleHopperConfigUpdatedEventData : PlayStreamEventBase
    {
        public bool Deleted;
        public string DeveloperId;
        public string MatchHopperId;
        public string UserId;
    }
    public class TitleInitiatedPlayerPasswordResetEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public string PasswordResetId;
        public string PlayerId;
        public string PlayerRecoveryEmailAddress;
        public string UserId;
    }
    public class TitleLimitChangedEventData : PlayStreamEventBase
    {
        public string LimitDisplayName;
        public string LimitId;
        public double? PreviousPriceUSD;
        public double? PreviousValue;
        public double? PriceUSD;
        public string TransactionId;
        public MetricUnit? Unit;
        public double? Value;
    }
    public class TitleModifiedGameBuildEventData : PlayStreamEventBase
    {
        public string BuildId;
        public string DeveloperId;
        public int MaxGamesPerHost;
        public int MinFreeGameSlots;
        public List<Region> Regions;
        public string UserId;
    }
    public class TitleNewsUpdatedEventData : PlayStreamEventBase
    {
        public DateTime DateCreated;
        public string NewsId;
        public string NewsTitle;
        public NewsStatus? Status;
    }
    public class TitlePermissionsPolicyChangedEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public string NewPolicy;
        public string PolicyName;
        public string UserId;
    }
    public class TitleProfileViewConstraintsChangedEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public string PreviousProfileViewConstraints;
        public string ProfileType;
        public string ProfileViewConstraints;
        public string UserId;
    }
    public class TitlePublishedCloudScriptEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public int Revision;
        public string UserId;
    }
    public class TitleRequestedLimitChangeEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public string LevelName;
        public string LimitDisplayName;
        public string LimitId;
        public string PreviousLevelName;
        public double? PreviousPriceUSD;
        public double? PreviousValue;
        public double? PriceUSD;
        public string TransactionId;
        public MetricUnit? Unit;
        public string UserId;
        public double? Value;
    }
    public class TitleScheduledCloudScriptExecutedEventData : PlayStreamEventBase
    {
        public ExecuteCloudScriptResult CloudScriptExecutionResult;
        public string FunctionName;
        public NameId ScheduledTask;
    }
    public class TitleSecretKeyEventData : PlayStreamEventBase
    {
        public bool? Deleted;
        public string DeveloperId;
        public bool? Disabled;
        public DateTime? ExpiryDate;
        public string SecretKeyId;
        public string SecretKeyName;
        public string UserId;
    }
    public class TitleStartedTaskEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public object Parameter;
        public string ScheduledByUserId;
        public NameIdentifier ScheduledTask;
        public string TaskInstanceId;
        public string TaskType;
        public string UserId;
    }
    public class TitleStatisticVersionChangedEventData : PlayStreamEventBase
    {
        public StatisticResetIntervalOption? ScheduledResetInterval;
        public DateTime? ScheduledResetTime;
        public string StatisticName;
        public uint StatisticVersion;
    }
    public class TitleStoreUpdatedEventData : PlayStreamEventBase
    {
        public string CatalogVersion;
        public bool Deleted;
        public string DeveloperId;
        public string StoreId;
        public string UserId;
    }
    public class TitleUpdatedTaskEventData : PlayStreamEventBase
    {
        public string DeveloperId;
        public bool HasRenamed;
        public NameIdentifier ScheduledTask;
        public string UserId;
    }
    #endregion title

    public enum OperationTypes
    {
        Created,
        Updated,
        Deleted,
        None
    }

    [Serializable]
    public class FileSet
    {
        /// <summary>
        /// The storage size according to the underlying provider.
        /// </summary>
        public int ByteCount;
        /// <summary>
        /// The checksum according to the underlying provider.
        /// </summary>
        public string Checksum;
        /// <summary>
        /// File that was updated.
        /// </summary>
        public string FileName;
        /// <summary>
        /// The operation that was performed.
        /// </summary>
        public OperationTypes? Operation;
        /// <summary>
        /// The storage size of the old file, if there was one.
        /// </summary>
        public int? PreviousByteCount;
        /// <summary>
        /// The storage size of the old file, if there was one.
        /// </summary>
        public string PreviousChecksum;
        /// <summary>
        /// The old file's unique storage path that was deleted by this operation, if there was one.
        /// </summary>
        public string PreviousStoragePath;
        /// <summary>
        /// The unique storage path for this set operation.
        /// </summary>
        public string StoragePath;
    }

    [Serializable]
    public class EntityLineage
    {
        /// <summary>
        /// The Character Id of the associated entity.
        /// </summary>
        public string CharacterId;
        /// <summary>
        /// The Group Id of the associated entity.
        /// </summary>
        public string GroupId;
        /// <summary>
        /// The Master Player Account Id of the associated entity.
        /// </summary>
        public string MasterPlayerAccountId;
        /// <summary>
        /// The Namespace Id of the associated entity.
        /// </summary>
        public string NamespaceId;
        /// <summary>
        /// The Title Id of the associated entity.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// The Title Player Account Id of the associated entity.
        /// </summary>
        public string TitlePlayerAccountId;
    }

    [Serializable]
    public class LogStatement
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
    public class ScriptExecutionError
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
    public class ExecuteCloudScriptResult
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
    public class Member
    {
        /// <summary>
        /// The identifier for the member entity.
        /// </summary>
        public string EntityId;
        /// <summary>
        /// The type of member entity.
        /// </summary>
        public string EntityType;
    }

    [Serializable]
    public class RolePropertyValues
    {
        public string RoleName;
    }

    [Serializable]
    public class GroupPropertyValues
    {
        public string AdminRoleId;
        public string GroupName;
        public string MemberRoleId;
    }

    [Serializable]
    public class ObjectSet
    {
        /// <summary>
        /// The JSON Object that was last set on the profile.
        /// </summary>
        public object DataObject;
        /// <summary>
        /// The name of this object.
        /// </summary>
        public string Name;
        /// <summary>
        /// The operation that was performed.
        /// </summary>
        public OperationTypes? Operation;
    }

    public enum PlayerProfileProperty
    {
        TotalValueToDateInUSD,
        PlayerValuesToDate
    }

    public enum EmailTemplateType
    {
        AccountRecovery,
        EmailVerification,
        Custom
    }

    public enum AuthenticationProvider
    {
        PlayFab,
        SAML
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
    public class CartItem
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

    public enum GameServerHostStopReason
    {
        Other,
        ExcessCapacity,
        LimitExceeded,
        BuildNotActiveInRegion,
        Unresponsive
    }

    public enum PaymentType
    {
        Purchase,
        ReceiptValidation
    }

    public enum LeaderboardVersionChangeBehavior
    {
        ResetValues
    }

    /// <summary>
    /// Statistic used as the source of leaderboard values.
    /// </summary>
    [Serializable]
    public class StatisticLeaderboardSource
    {
        /// <summary>
        /// Unique ID of the statistic.
        /// </summary>
        public uint StatisticId;
        /// <summary>
        /// Name of the statistic.
        /// </summary>
        public string StatisticName;
    }

    /// <summary>
    /// The source of values for the leaderboard. The properties are mutually exclusive - only one of them will be set and the
    /// rest will be null.
    /// </summary>
    [Serializable]
    public class LeaderboardSource
    {
        /// <summary>
        /// Statistic associated with the leaderboard.
        /// </summary>
        public StatisticLeaderboardSource Statistic;
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

    public enum PasswordResetInitiationSource
    {
        Self,
        Admin
    }

    [Serializable]
    public class CouponGrantedInventoryItem
    {
        /// <summary>
        /// Catalog version of the inventory item.
        /// </summary>
        public string CatalogVersion;
        /// <summary>
        /// Unique instance ID of the inventory item.
        /// </summary>
        public string InstanceId;
        /// <summary>
        /// Catalog item ID of the inventory item.
        /// </summary>
        public string ItemId;
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
    public class PlayerLocation
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
    public class AdCampaignAttribution
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

    public enum PushNotificationPlatform
    {
        ApplePushNotificationService,
        GoogleCloudMessaging
    }

    [Serializable]
    public class PushNotificationRegistration
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
    public class PlayerLinkedAccount
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
    public class PlayerStatistic
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

    public enum EmailVerificationStatus
    {
        Unverified,
        Pending,
        Confirmed
    }

    [Serializable]
    public class ContactEmailInfo
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
    public class PlayerProfile
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

    /// <summary>
    /// Identifier by either name or ID. Note that a name may change due to renaming, or reused after being deleted. ID is
    /// immutable and unique.
    /// </summary>
    [Serializable]
    public class NameIdentifier
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
    public class APISettings
    {
        /// <summary>
        /// Allow game clients to add to virtual currency balances via API.
        /// </summary>
        public bool AllowClientToAddVirtualCurrency;
        /// <summary>
        /// Allow game clients to update statistic values via API.
        /// </summary>
        public bool AllowClientToPostPlayerStatistics;
        /// <summary>
        /// Allow clients to start multiplayer game sessions via API.
        /// </summary>
        public bool AllowClientToStartGames;
        /// <summary>
        /// Allow game clients to subtract from virtual currency balances via API.
        /// </summary>
        public bool AllowClientToSubtractVirtualCurrency;
        /// <summary>
        /// Allow players to choose display names that may be in use by other players, i.e. do not enforce uniqueness of display
        /// names. Note: if this option is enabled, it cannot be disabled later.
        /// </summary>
        public bool AllowNonUniquePlayerDisplayNames;
        /// <summary>
        /// Allow game servers to delete player accounts via API.
        /// </summary>
        public bool AllowServerToDeleteUsers;
        /// <summary>
        /// Disable API access by returning errors to all API requests.
        /// </summary>
        public bool DisableAPIAccess;
        /// <summary>
        /// Display name randomly-generated suffix length.
        /// </summary>
        public int? DisplayNameRandomSuffixLength;
        /// <summary>
        /// Reduce the precision of IP addresses collected from players' devices before they are stored or used to estimate
        /// geographic locations.
        /// </summary>
        public bool EnableClientIPAddressObfuscation;
        /// <summary>
        /// Require JSON format for data values associated with players, characters, inventories, and shared groups.
        /// </summary>
        public bool RequireCustomDataJSONFormat;
        /// <summary>
        /// Multiplayer game sessions are hosted on servers external to PlayFab.
        /// </summary>
        public bool UseExternalGameServerProvider;
        /// <summary>
        /// Use payment provider's sandbox mode (if available) for real-money purchases. This can be useful when testing in-game
        /// purchasing in order to avoid being charged.
        /// </summary>
        public bool UseSandboxPayments;
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

    public enum StatisticAggregationMethod
    {
        Last,
        Min,
        Max,
        Sum
    }

    [Serializable]
    public class EventLocation
    {
        /// <summary>
        /// City of the geographic location.
        /// </summary>
        public string City;
        /// <summary>
        /// Two-character code representing the continent of geographic location.
        /// </summary>
        public ContinentCode? ContinentCode;
        /// <summary>
        /// Two-character ISO 3166-1 code representing the country of the geographic location.
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
        MonthlyActiveUsers,
        EnableDisable
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
        public string Id;
        public string Name;
    }

    public enum PhotonServicesEnum
    {
        Realtime,
        Turnbased,
        Chat
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
    public class PlayStreamEventHistory
    {
        /// <summary>
        /// The ID of the previous event that caused this event to be created by hitting a trigger.
        /// </summary>
        public string ParentEventId;
        /// <summary>
        /// The ID of the trigger that caused this event to be created.
        /// </summary>
        public string ParentTriggerId;
        /// <summary>
        /// If true, then this event was allowed to trigger subsequent events in a trigger.
        /// </summary>
        public bool TriggeredEvents;
    }

}
