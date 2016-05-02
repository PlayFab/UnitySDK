using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.ClientModels
{
    public class AcceptTradeRequest
    {

        /// <summary>
        /// Player who opened the trade.
        /// </summary>
        public string OfferingPlayerId { get; set;}

        /// <summary>
        /// Trade identifier.
        /// </summary>
        public string TradeId { get; set;}

        /// <summary>
        /// Items from the accepting player's or guild's inventory in exchange for the offered items in the trade. In the case of a gift, this will be null.
        /// </summary>
        public List<string> AcceptedInventoryInstanceIds { get; set;}
    }

    public class AcceptTradeResponse : PlayFabResultCommon
    {

        /// <summary>
        /// Details about trade which was just accepted.
        /// </summary>
        public TradeInfo Trade { get; set;}
    }

    public class AddFriendRequest
    {

        /// <summary>
        /// PlayFab identifier of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendPlayFabId { get; set;}

        /// <summary>
        /// PlayFab username of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendUsername { get; set;}

        /// <summary>
        /// Email address of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendEmail { get; set;}

        /// <summary>
        /// Title-specific display name of the user to attempt to add to the local user's friend list.
        /// </summary>
        public string FriendTitleDisplayName { get; set;}
    }

    public class AddFriendResult : PlayFabResultCommon
    {

        /// <summary>
        /// True if the friend request was processed successfully.
        /// </summary>
        public bool Created { get; set;}
    }

    public class AddSharedGroupMembersRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds { get; set;}
    }

    public class AddSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    public class AddUsernamePasswordRequest
    {

        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email { get; set;}

        /// <summary>
        /// Password for the PlayFab account (6-30 characters)
        /// </summary>
        public string Password { get; set;}
    }

    public class AddUsernamePasswordResult : PlayFabResultCommon
    {

        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username { get; set;}
    }

    public class AddUserVirtualCurrencyRequest
    {

        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency.
        /// </summary>
        public int Amount { get; set;}
    }

    public class AndroidDevicePushNotificationRegistrationRequest
    {

        /// <summary>
        /// Registration ID provided by the Google Cloud Messaging service when the title registered to receive push notifications (see the GCM documentation, here: http://developer.android.com/google/gcm/client.html).
        /// </summary>
        public string DeviceToken { get; set;}

        /// <summary>
        /// If true, send a test push message immediately after sucessful registration. Defaults to false.
        /// </summary>
        public bool? SendPushNotificationConfirmation { get; set;}

        /// <summary>
        /// Message to display when confirming push notification.
        /// </summary>
        public string ConfirmationMessage { get; set;}
    }

    public class AndroidDevicePushNotificationRegistrationResult : PlayFabResultCommon
    {
    }

    public class AttributeInstallRequest
    {

        /// <summary>
        /// The IdentifierForAdvertisers for iOS Devices.
        /// </summary>
        public string Idfa { get; set;}

        /// <summary>
        /// The Android Id for this Android device.
        /// </summary>
        public string Android_Id { get; set;}
    }

    public class AttributeInstallResult : PlayFabResultCommon
    {
    }

    public class CancelTradeRequest
    {

        /// <summary>
        /// Trade identifier.
        /// </summary>
        public string TradeId { get; set;}
    }

    public class CancelTradeResponse : PlayFabResultCommon
    {

        /// <summary>
        /// Details about trade which was just canceled.
        /// </summary>
        public TradeInfo Trade { get; set;}
    }

    public class CartItem
    {

        /// <summary>
        /// Unique identifier for the catalog item.
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// Class name to which catalog item belongs.
        /// </summary>
        public string ItemClass { get; set;}

        /// <summary>
        /// Unique instance identifier for this catalog item.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Display name for the catalog item.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// Description of the catalog item.
        /// </summary>
        public string Description { get; set;}

        /// <summary>
        /// Cost of the catalog item for each applicable virtual currency.
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}

        /// <summary>
        /// Cost of the catalog item for each applicable real world currency.
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices { get; set;}

        /// <summary>
        /// Amount of each applicable virtual currency which will be received as a result of purchasing this catalog item.
        /// </summary>
        public Dictionary<string,uint> VCAmount { get; set;}
    }

    /// <summary>
    /// A purchasable item from the item catalog
    /// </summary>
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

    public class CharacterLeaderboardEntry
    {

        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// PlayFab unique identifier of the character that belongs to the user for this leaderboard entry.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Title-specific display name of the character for this leaderboard entry.
        /// </summary>
        public string CharacterName { get; set;}

        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// Name of the character class for this entry.
        /// </summary>
        public string CharacterType { get; set;}

        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue { get; set;}

        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position { get; set;}
    }

    public class CharacterResult : PlayFabResultCommon
    {

        /// <summary>
        /// The id for this character on this player.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// The name of this character.
        /// </summary>
        public string CharacterName { get; set;}

        /// <summary>
        /// The type-string that was given to this character on creation.
        /// </summary>
        public string CharacterType { get; set;}
    }

    public enum CloudScriptRevisionOption
    {
        Live,
        Latest,
        Specific
    }

    public class ConfirmPurchaseRequest
    {

        /// <summary>
        /// Purchase order identifier returned from StartPurchase.
        /// </summary>
        public string OrderId { get; set;}
    }

    public class ConfirmPurchaseResult : PlayFabResultCommon
    {

        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId { get; set;}

        /// <summary>
        /// Date and time of the purchase.
        /// </summary>
        public DateTime PurchaseDate { get; set;}

        /// <summary>
        /// Array of items purchased.
        /// </summary>
        public List<ItemInstance> Items { get; set;}
    }

    public class ConsumeItemRequest
    {

        /// <summary>
        /// Unique instance identifier of the item to be consumed.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Number of uses to consume from the item.
        /// </summary>
        public int ConsumeCount { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    public class ConsumeItemResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique instance identifier of the item with uses consumed.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Number of uses remaining on the item.
        /// </summary>
        public int RemainingUses { get; set;}
    }

    public class CreateSharedGroupRequest
    {

        /// <summary>
        /// Unique identifier for the shared group (a random identifier will be assigned, if one is not specified).
        /// </summary>
        public string SharedGroupId { get; set;}
    }

    public class CreateSharedGroupResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}
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

    public class CurrentGamesRequest
    {

        /// <summary>
        /// region to check for game instances
        /// </summary>
        public Region? Region { get; set;}

        /// <summary>
        /// version of build to match against
        /// </summary>
        public string BuildVersion { get; set;}

        /// <summary>
        /// game mode to look for (optional)
        /// </summary>
        public string GameMode { get; set;}

        /// <summary>
        /// statistic name to find statistic-based matches (optional)
        /// </summary>
        public string StatisticName { get; set;}
    }

    public class CurrentGamesResult : PlayFabResultCommon
    {

        /// <summary>
        /// array of games found
        /// </summary>
        public List<GameInfo> Games { get; set;}

        /// <summary>
        /// total number of players across all servers
        /// </summary>
        public int PlayerCount { get; set;}

        /// <summary>
        /// number of games running
        /// </summary>
        public int GameCount { get; set;}
    }

    public class EmptyResult : PlayFabResultCommon
    {
    }

    public class ExecuteCloudScriptRequest
    {

        /// <summary>
        /// The name of the CloudScript function to execute
        /// </summary>
        public string FunctionName { get; set;}

        /// <summary>
        /// Object that is passed in to the function as the first argument
        /// </summary>
        public object FunctionParameter { get; set;}

        /// <summary>
        /// Option for which revision of the CloudScript to execute. 'Latest' executes the most recently created revision, 'Live' executes the current live, published revision, and 'Specific' executes the specified revision. The default value is 'Specific', if the SpeificRevision parameter is specified, otherwise it is 'Live'.
        /// </summary>
        public CloudScriptRevisionOption? RevisionSelection { get; set;}

        /// <summary>
        /// The specivic revision to execute, when RevisionSelection is set to 'Specific'
        /// </summary>
        public int? SpecificRevision { get; set;}

        /// <summary>
        /// Generate a 'player_executed_cloudscript' PlayStream event containing the results of the function execution and other contextual information. This event will show up in the PlayStream debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent { get; set;}
    }

    public class ExecuteCloudScriptResult : PlayFabResultCommon
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

    public class FacebookPlayFabIdPair
    {

        /// <summary>
        /// Unique Facebook identifier for a user.
        /// </summary>
        public string FacebookId { get; set;}

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook identifier.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class FriendInfo
    {

        /// <summary>
        /// PlayFab unique identifier for this friend.
        /// </summary>
        public string FriendPlayFabId { get; set;}

        /// <summary>
        /// PlayFab unique username for this friend.
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// Title-specific display name for this friend.
        /// </summary>
        public string TitleDisplayName { get; set;}

        /// <summary>
        /// Tags which have been associated with this friend.
        /// </summary>
        public List<string> Tags { get; set;}

        /// <summary>
        /// Unique lobby identifier of the Game Server Instance to which this player is currently connected.
        /// </summary>
        public string CurrentMatchmakerLobbyId { get; set;}

        /// <summary>
        /// Available Facebook information (if the user and PlayFab friend are also connected in Facebook).
        /// </summary>
        public UserFacebookInfo FacebookInfo { get; set;}

        /// <summary>
        /// Available Steam information (if the user and PlayFab friend are also connected in Steam).
        /// </summary>
        public UserSteamInfo SteamInfo { get; set;}

        /// <summary>
        /// Available Game Center information (if the user and PlayFab friend are also connected in Game Center).
        /// </summary>
        public UserGameCenterInfo GameCenterInfo { get; set;}
    }

    public class GameCenterPlayFabIdPair
    {

        /// <summary>
        /// Unique Game Center identifier for a user.
        /// </summary>
        public string GameCenterId { get; set;}

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Game Center identifier.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class GameInfo
    {

        /// <summary>
        /// region to which this server is associated
        /// </summary>
        public Region? Region { get; set;}

        /// <summary>
        /// unique lobby identifier for this game server
        /// </summary>
        public string LobbyID { get; set;}

        /// <summary>
        /// build version this server is running
        /// </summary>
        public string BuildVersion { get; set;}

        /// <summary>
        /// game mode this server is running
        /// </summary>
        public string GameMode { get; set;}

        /// <summary>
        /// stastic used to match this game in player statistic matchmaking
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// maximum players this server can support
        /// </summary>
        public int? MaxPlayers { get; set;}

        /// <summary>
        /// array of strings of current player names on this server (note that these are PlayFab usernames, as opposed to title display names)
        /// </summary>
        public List<string> PlayerUserIds { get; set;}

        /// <summary>
        /// duration in seconds this server has been running
        /// </summary>
        public uint RunTime { get; set;}

        /// <summary>
        /// game specific string denoting server configuration
        /// </summary>
        public string GameServerState { get; set;}
    }

    public class GameServerRegionsRequest
    {

        /// <summary>
        /// version of game server for which stats are being requested
        /// </summary>
        public string BuildVersion { get; set;}

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}
    }

    public class GameServerRegionsResult : PlayFabResultCommon
    {

        /// <summary>
        /// array of regions found matching the request parameters
        /// </summary>
        public List<RegionInfo> Regions { get; set;}
    }

    public class GetAccountInfoRequest
    {

        /// <summary>
        /// Unique PlayFab identifier of the user whose info is being requested. Optional, defaults to the authenticated user if no other lookup identifier set.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// PlayFab Username for the account to find (if no PlayFabId is specified).
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// User email address for the account to find (if no Username is specified).
        /// </summary>
        public string Email { get; set;}

        /// <summary>
        /// Title-specific username for the account to find (if no Email is set).
        /// </summary>
        public string TitleDisplayName { get; set;}
    }

    public class GetAccountInfoResult : PlayFabResultCommon
    {

        /// <summary>
        /// Account information for the local user.
        /// </summary>
        public UserAccountInfo AccountInfo { get; set;}
    }

    public class GetCatalogItemsRequest
    {

        /// <summary>
        /// Which catalog is being requested.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class GetCatalogItemsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of items which can be purchased.
        /// </summary>
        public List<CatalogItem> Catalog { get; set;}
    }

    public class GetCharacterDataRequest
    {

        /// <summary>
        /// Unique PlayFab identifier of the user to load data for. Optional, defaults to yourself if not set.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys { get; set;}

        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public int? IfChangedFromDataVersion { get; set;}
    }

    public class GetCharacterDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data { get; set;}

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
    }

    public class GetCharacterInventoryRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Used to limit results to only those from a specific catalog version.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class GetCharacterInventoryResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique identifier of the character for this inventory.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Array of inventory items belonging to the character.
        /// </summary>
        public List<ItemInstance> Inventory { get; set;}

        /// <summary>
        /// Array of virtual currency balance(s) belonging to the character.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency { get; set;}

        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes { get; set;}
    }

    public class GetCharacterLeaderboardRequest
    {

        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType { get; set;}

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}
    }

    public class GetCharacterLeaderboardResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetCharacterStatisticsRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    public class GetCharacterStatisticsResult : PlayFabResultCommon
    {

        /// <summary>
        /// The requested character statistics.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics { get; set;}
    }

    public class GetCloudScriptUrlRequest
    {

        /// <summary>
        /// Cloud Script Version to use. Defaults to 1.
        /// </summary>
        public int? Version { get; set;}

        /// <summary>
        /// Specifies whether the URL returned should be the one for the most recently uploaded Revision of the Cloud Script (true), or the Revision most recently set to live (false). Defaults to false.
        /// </summary>
        public bool? Testing { get; set;}
    }

    public class GetCloudScriptUrlResult : PlayFabResultCommon
    {

        /// <summary>
        /// URL of the Cloud Script logic server.
        /// </summary>
        public string Url { get; set;}
    }

    public class GetContentDownloadUrlRequest
    {

        /// <summary>
        /// Key of the content item to fetch, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key { get; set;}

        /// <summary>
        /// HTTP method to fetch item - GET or HEAD. Use HEAD when only fetching metadata. Default is GET.
        /// </summary>
        public string HttpMethod { get; set;}

        /// <summary>
        /// True if download through CDN. CDN provides better download bandwidth and time. However, if you want latest, non-cached version of the content, set this to false. Default is true.
        /// </summary>
        public bool? ThruCDN { get; set;}
    }

    public class GetContentDownloadUrlResult : PlayFabResultCommon
    {

        /// <summary>
        /// URL for downloading content via HTTP GET or HEAD method. The URL will expire in 1 hour.
        /// </summary>
        public string URL { get; set;}
    }

    public class GetFriendLeaderboardAroundCurrentUserRequest
    {

        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}

        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends { get; set;}

        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends { get; set;}
    }

    public class GetFriendLeaderboardAroundCurrentUserResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetFriendLeaderboardAroundPlayerRequest
    {

        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}

        /// <summary>
        /// PlayFab unique identifier of the user to center the leaderboard around. If null will center on the logged in user.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends { get; set;}

        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends { get; set;}
    }

    public class GetFriendLeaderboardAroundPlayerResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetFriendLeaderboardRequest
    {

        /// <summary>
        /// Statistic used to rank friends for this leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Position in the leaderboard to start this listing (defaults to the first entry).
        /// </summary>
        public int StartPosition { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}

        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends { get; set;}

        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends { get; set;}
    }

    public class GetFriendsListRequest
    {

        /// <summary>
        /// Indicates whether Steam service friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeSteamFriends { get; set;}

        /// <summary>
        /// Indicates whether Facebook friends should be included in the response. Default is true.
        /// </summary>
        public bool? IncludeFacebookFriends { get; set;}
    }

    public class GetFriendsListResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of friends found.
        /// </summary>
        public List<FriendInfo> Friends { get; set;}
    }

    public class GetLeaderboardAroundCharacterRequest
    {

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character on which to center the leaderboard.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}
    }

    public class GetLeaderboardAroundCharacterResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetLeaderboardAroundCurrentUserRequest
    {

        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}
    }

    public class GetLeaderboardAroundCurrentUserResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetLeaderboardAroundPlayerRequest
    {

        /// <summary>
        /// PlayFab unique identifier of the user to center the leaderboard around. If null will center on the logged in user.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}
    }

    public class GetLeaderboardAroundPlayerResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetLeaderboardForUsersCharactersRequest
    {

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount { get; set;}
    }

    public class GetLeaderboardForUsersCharactersResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetLeaderboardRequest
    {

        /// <summary>
        /// Statistic used to rank players for this leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Position in the leaderboard to start this listing (defaults to the first entry).
        /// </summary>
        public int StartPosition { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve. Default 10, maximum 100.
        /// </summary>
        public int? MaxResultsCount { get; set;}
    }

    public class GetLeaderboardResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered listing of users and their positions in the requested leaderboard.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetPhotonAuthenticationTokenRequest
    {

        /// <summary>
        /// The Photon applicationId for the game you wish to log into.
        /// </summary>
        public string PhotonApplicationId { get; set;}
    }

    public class GetPhotonAuthenticationTokenResult : PlayFabResultCommon
    {

        /// <summary>
        /// The Photon authentication token for this game-session.
        /// </summary>
        public string PhotonCustomAuthenticationToken { get; set;}
    }

    public class GetPlayerStatisticsRequest
    {

        /// <summary>
        /// statistics to return (current version will be returned for each)
        /// </summary>
        public List<string> StatisticNames { get; set;}

        /// <summary>
        /// statistics to return, if StatisticNames is not set (only statistics which have a version matching that provided will be returned)
        /// </summary>
        public List<StatisticNameVersion> StatisticNameVersions { get; set;}
    }

    public class GetPlayerStatisticsResult : PlayFabResultCommon
    {

        /// <summary>
        /// User statistics for the requested user.
        /// </summary>
        public List<StatisticValue> Statistics { get; set;}
    }

    public class GetPlayerStatisticVersionsRequest
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}
    }

    public class GetPlayerStatisticVersionsResult : PlayFabResultCommon
    {

        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public List<PlayerStatisticVersion> StatisticVersions { get; set;}
    }

    public class GetPlayerTradesRequest
    {

        /// <summary>
        /// Returns only trades with the given status. If null, returns all trades.
        /// </summary>
        public TradeStatus? StatusFilter { get; set;}
    }

    public class GetPlayerTradesResponse : PlayFabResultCommon
    {

        /// <summary>
        /// The trades for this player which are currently available to be accepted.
        /// </summary>
        public List<TradeInfo> OpenedTrades { get; set;}

        /// <summary>
        /// History of trades which this player has accepted.
        /// </summary>
        public List<TradeInfo> AcceptedTrades { get; set;}
    }

    public class GetPlayFabIDsFromFacebookIDsRequest
    {

        /// <summary>
        /// Array of unique Facebook identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> FacebookIDs { get; set;}
    }

    public class GetPlayFabIDsFromFacebookIDsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Mapping of Facebook identifiers to PlayFab identifiers.
        /// </summary>
        public List<FacebookPlayFabIdPair> Data { get; set;}
    }

    public class GetPlayFabIDsFromGameCenterIDsRequest
    {

        /// <summary>
        /// Array of unique Game Center identifiers (the Player Identifier) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> GameCenterIDs { get; set;}
    }

    public class GetPlayFabIDsFromGameCenterIDsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Mapping of Game Center identifiers to PlayFab identifiers.
        /// </summary>
        public List<GameCenterPlayFabIdPair> Data { get; set;}
    }

    public class GetPlayFabIDsFromGoogleIDsRequest
    {

        /// <summary>
        /// Array of unique Google identifiers (Google+ user IDs) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> GoogleIDs { get; set;}
    }

    public class GetPlayFabIDsFromGoogleIDsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Mapping of Google identifiers to PlayFab identifiers.
        /// </summary>
        public List<GooglePlayFabIdPair> Data { get; set;}
    }

    public class GetPlayFabIDsFromKongregateIDsRequest
    {

        /// <summary>
        /// Array of unique Kongregate identifiers (Kongregate's user_id) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> KongregateIDs { get; set;}
    }

    public class GetPlayFabIDsFromKongregateIDsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Mapping of Kongregate identifiers to PlayFab identifiers.
        /// </summary>
        public List<KongregatePlayFabIdPair> Data { get; set;}
    }

    public class GetPlayFabIDsFromSteamIDsRequest
    {

        /// <summary>
        /// Deprecated: Please use SteamStringIDs
        /// </summary>
        public List<ulong> SteamIDs { get; set;}

        /// <summary>
        /// Array of unique Steam identifiers (Steam profile IDs) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> SteamStringIDs { get; set;}
    }

    public class GetPlayFabIDsFromSteamIDsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Mapping of Steam identifiers to PlayFab identifiers.
        /// </summary>
        public List<SteamPlayFabIdPair> Data { get; set;}
    }

    public class GetPublisherDataRequest
    {

        /// <summary>
        ///  array of keys to get back data from the Publisher data blob, set by the admin tools
        /// </summary>
        public List<string> Keys { get; set;}
    }

    public class GetPublisherDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
    }

    public class GetPurchaseRequest
    {

        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId { get; set;}
    }

    public class GetPurchaseResult : PlayFabResultCommon
    {

        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId { get; set;}

        /// <summary>
        /// Payment provider used for transaction (If not VC)
        /// </summary>
        public string PaymentProvider { get; set;}

        /// <summary>
        /// Provider transaction ID (If not VC)
        /// </summary>
        public string TransactionId { get; set;}

        /// <summary>
        /// PlayFab transaction status
        /// </summary>
        public string TransactionStatus { get; set;}

        /// <summary>
        /// Date and time of the purchase.
        /// </summary>
        public DateTime PurchaseDate { get; set;}

        /// <summary>
        /// Array of items purchased.
        /// </summary>
        public List<ItemInstance> Items { get; set;}
    }

    public class GetSharedGroupDataRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// Specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned).
        /// </summary>
        public List<string> Keys { get; set;}

        /// <summary>
        /// If true, return the list of all members of the shared group.
        /// </summary>
        public bool? GetMembers { get; set;}
    }

    public class GetSharedGroupDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Data for the requested keys.
        /// </summary>
        public Dictionary<string,SharedGroupDataRecord> Data { get; set;}

        /// <summary>
        /// List of PlayFabId identifiers for the members of this group, if requested.
        /// </summary>
        public List<string> Members { get; set;}
    }

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

    public class GetStoreItemsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of items which can be purchased from this store.
        /// </summary>
        public List<StoreItem> Store { get; set;}
    }

    public class GetTitleDataRequest
    {

        /// <summary>
        /// Specific keys to search for in the title data (leave null to get all keys)
        /// </summary>
        public List<string> Keys { get; set;}
    }

    public class GetTitleDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
    }

    public class GetTitleNewsRequest
    {

        /// <summary>
        /// Limits the results to the last n entries. Defaults to 10 if not set.
        /// </summary>
        public int? Count { get; set;}
    }

    public class GetTitleNewsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of news items.
        /// </summary>
        public List<TitleNewsItem> News { get; set;}
    }

    public class GetTradeStatusRequest
    {

        /// <summary>
        /// Player who opened trade.
        /// </summary>
        public string OfferingPlayerId { get; set;}

        /// <summary>
        /// Trade identifier as returned by OpenTradeOffer.
        /// </summary>
        public string TradeId { get; set;}
    }

    public class GetTradeStatusResponse : PlayFabResultCommon
    {

        /// <summary>
        /// Information about the requested trade.
        /// </summary>
        public TradeInfo Trade { get; set;}
    }

    public class GetUserCombinedInfoRequest
    {

        /// <summary>
        /// Unique PlayFab identifier of the user whose info is being requested. Optional, defaults to the authenticated user if no other lookup identifier set.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// PlayFab Username for the account to find (if no PlayFabId is specified).
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// User email address for the account to find (if no Username is specified).
        /// </summary>
        public string Email { get; set;}

        /// <summary>
        /// Title-specific username for the account to find (if no Email is set).
        /// </summary>
        public string TitleDisplayName { get; set;}

        /// <summary>
        /// If set to false, account info will not be returned. Defaults to true.
        /// </summary>
        public bool? GetAccountInfo { get; set;}

        /// <summary>
        /// If set to false, inventory will not be returned. Defaults to true. Inventory will never be returned for users other than yourself.
        /// </summary>
        public bool? GetInventory { get; set;}

        /// <summary>
        /// If set to false, virtual currency balances will not be returned. Defaults to true. Currency balances will never be returned for users other than yourself.
        /// </summary>
        public bool? GetVirtualCurrency { get; set;}

        /// <summary>
        /// If set to false, custom user data will not be returned. Defaults to true.
        /// </summary>
        public bool? GetUserData { get; set;}

        /// <summary>
        /// User custom data keys to return. If set to null, all keys will be returned. For users other than yourself, only public data will be returned.
        /// </summary>
        public List<string> UserDataKeys { get; set;}

        /// <summary>
        /// If set to false, read-only user data will not be returned. Defaults to true.
        /// </summary>
        public bool? GetReadOnlyData { get; set;}

        /// <summary>
        /// User read-only custom data keys to return. If set to null, all keys will be returned. For users other than yourself, only public data will be returned.
        /// </summary>
        public List<string> ReadOnlyDataKeys { get; set;}
    }

    public class GetUserCombinedInfoResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique PlayFab identifier of the owner of the combined info.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Account information for the user.
        /// </summary>
        public UserAccountInfo AccountInfo { get; set;}

        /// <summary>
        /// Array of inventory items in the user's current inventory.
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

        /// <summary>
        /// User specific custom data.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data { get; set;}

        /// <summary>
        /// The version of the UserData that was returned.
        /// </summary>
        public uint DataVersion { get; set;}

        /// <summary>
        /// User specific read-only data.
        /// </summary>
        public Dictionary<string,UserDataRecord> ReadOnlyData { get; set;}

        /// <summary>
        /// The version of the Read-Only UserData that was returned.
        /// </summary>
        public uint ReadOnlyDataVersion { get; set;}
    }

    public class GetUserDataRequest
    {

        /// <summary>
        /// Specific keys to search for in the custom data. Leave null to get all keys.
        /// </summary>
        public List<string> Keys { get; set;}

        /// <summary>
        /// Unique PlayFab identifier of the user to load data for. Optional, defaults to yourself if not set.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public int? IfChangedFromDataVersion { get; set;}
    }

    public class GetUserDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data { get; set;}

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
    }

    public class GetUserInventoryRequest
    {
    }

    public class GetUserInventoryResult : PlayFabResultCommon
    {

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

    public class GetUserStatisticsRequest
    {
    }

    public class GetUserStatisticsResult : PlayFabResultCommon
    {

        /// <summary>
        /// User statistics for the active title.
        /// </summary>
        public Dictionary<string,int> UserStatistics { get; set;}
    }

    public class GooglePlayFabIdPair
    {

        /// <summary>
        /// Unique Google identifier for a user.
        /// </summary>
        public string GoogleId { get; set;}

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Google identifier.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class GrantCharacterToUserRequest
    {

        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Catalog item identifier of the item in the user's inventory that corresponds to the character in the catalog to be created.
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// Non-unique display name of the character being granted.
        /// </summary>
        public string CharacterName { get; set;}
    }

    public class GrantCharacterToUserResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique identifier tagged to this character.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Type of character that was created.
        /// </summary>
        public string CharacterType { get; set;}

        /// <summary>
        /// Indicates whether this character was created successfully.
        /// </summary>
        public bool Result { get; set;}
    }

    /// <summary>
    /// A unique instance of an item in a user's inventory
    /// </summary>
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

    public class ItemPurchaseRequest
    {

        /// <summary>
        /// Unique ItemId of the item to purchase.
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// How many of this item to purchase.
        /// </summary>
        public uint Quantity { get; set;}

        /// <summary>
        /// Title-specific text concerning this purchase.
        /// </summary>
        public string Annotation { get; set;}

        /// <summary>
        /// Items to be upgraded as a result of this purchase (upgraded items are hidden, as they are "replaced" by the new items).
        /// </summary>
        public List<string> UpgradeFromItems { get; set;}
    }

    public class KongregatePlayFabIdPair
    {

        /// <summary>
        /// Unique Kongregate identifier for a user.
        /// </summary>
        public string KongregateId { get; set;}

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Kongregate identifier.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class LinkAndroidDeviceIDRequest
    {

        /// <summary>
        /// Android device identifier for the user's device.
        /// </summary>
        public string AndroidDeviceId { get; set;}

        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS { get; set;}

        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string AndroidDevice { get; set;}
    }

    public class LinkAndroidDeviceIDResult : PlayFabResultCommon
    {
    }

    public class LinkCustomIDRequest
    {

        /// <summary>
        /// Custom unique identifier for the user, generated by the title.
        /// </summary>
        public string CustomId { get; set;}
    }

    public class LinkCustomIDResult : PlayFabResultCommon
    {
    }

    public class LinkFacebookAccountRequest
    {

        /// <summary>
        /// Unique identifier from Facebook for the user.
        /// </summary>
        public string AccessToken { get; set;}
    }

    public class LinkFacebookAccountResult : PlayFabResultCommon
    {
    }

    public class LinkGameCenterAccountRequest
    {

        /// <summary>
        /// Game Center identifier for the player account to be linked.
        /// </summary>
        public string GameCenterId { get; set;}
    }

    public class LinkGameCenterAccountResult : PlayFabResultCommon
    {
    }

    public class LinkGoogleAccountRequest
    {

        /// <summary>
        /// Unique token (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods) from Google Play for the user.
        /// </summary>
        public string AccessToken { get; set;}
    }

    public class LinkGoogleAccountResult : PlayFabResultCommon
    {
    }

    public class LinkIOSDeviceIDRequest
    {

        /// <summary>
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId { get; set;}

        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS { get; set;}

        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string DeviceModel { get; set;}
    }

    public class LinkIOSDeviceIDResult : PlayFabResultCommon
    {
    }

    public class LinkKongregateAccountRequest
    {

        /// <summary>
        /// Numeric user ID assigned by Kongregate
        /// </summary>
        public string KongregateId { get; set;}

        /// <summary>
        /// Valid session auth ticket issued by Kongregate
        /// </summary>
        public string AuthTicket { get; set;}
    }

    public class LinkKongregateAccountResult : PlayFabResultCommon
    {
    }

    public class LinkSteamAccountRequest
    {

        /// <summary>
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08").
        /// </summary>
        public string SteamTicket { get; set;}
    }

    public class LinkSteamAccountResult : PlayFabResultCommon
    {
    }

    public class ListUsersCharactersRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class ListUsersCharactersResult : PlayFabResultCommon
    {

        /// <summary>
        /// The requested list of characters.
        /// </summary>
        public List<CharacterResult> Characters { get; set;}
    }

    public class LogEventRequest
    {

        /// <summary>
        /// Optional timestamp for this event. If null, the a timestamp is auto-assigned to the event on the server.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// A unique event name which will be used as the table name in the Redshift database. The name will be made lower case, and cannot not contain spaces. The use of underscores is recommended, for readability. Events also cannot match reserved terms. The PlayFab reserved terms are 'log_in' and 'purchase', 'create' and 'request', while the Redshift reserved terms can be found here: http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html.
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// Contains all the data for this event. Event Values can be strings, booleans or numerics (float, double, integer, long) and must be consistent on a per-event basis (if the Value for Key 'A' in Event 'Foo' is an integer the first time it is sent, it must be an integer in all subsequent 'Foo' events). As with event names, Keys must also not use reserved words (see above). Finally, the size of the Body for an event must be less than 32KB (UTF-8 format).
        /// </summary>
        public Dictionary<string,object> Body { get; set;}

        /// <summary>
        /// Flag to set event Body as profile details in the Redshift database as well as a standard event.
        /// </summary>
        public bool ProfileSetEvent { get; set;}
    }

    public class LogEventResult : PlayFabResultCommon
    {
    }

    public class LoginResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique token authorizing the user and game at the server level, for the current session.
        /// </summary>
        public string SessionTicket { get; set;}

        /// <summary>
        /// Player's unique PlayFabId.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// True if the account was newly created on this login.
        /// </summary>
        public bool NewlyCreated { get; set;}

        /// <summary>
        /// Settings specific to this user.
        /// </summary>
        public UserSettings SettingsForUser { get; set;}

        /// <summary>
        /// The time of this user's previous login. If there was no previous login, then it's DateTime.MinValue
        /// </summary>
        public DateTime? LastLoginTime { get; set;}
    }

    public class LoginWithAndroidDeviceIDRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Android device identifier for the user's device.
        /// </summary>
        public string AndroidDeviceId { get; set;}

        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS { get; set;}

        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string AndroidDevice { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this Android device.
        /// </summary>
        public bool? CreateAccount { get; set;}
    }

    public class LoginWithCustomIDRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Custom unique identifier for the user, generated by the title.
        /// </summary>
        public string CustomId { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this Custom ID.
        /// </summary>
        public bool? CreateAccount { get; set;}
    }

    public class LoginWithEmailAddressRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Email address for the account.
        /// </summary>
        public string Email { get; set;}

        /// <summary>
        /// Password for the PlayFab account (6-30 characters)
        /// </summary>
        public string Password { get; set;}
    }

    public class LoginWithFacebookRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Unique identifier from Facebook for the user.
        /// </summary>
        public string AccessToken { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this Facebook account.
        /// </summary>
        public bool? CreateAccount { get; set;}
    }

    public class LoginWithGameCenterRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Unique Game Center player id.
        /// </summary>
        public string PlayerId { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this Game Center id.
        /// </summary>
        public bool? CreateAccount { get; set;}
    }

    public class LoginWithGoogleAccountRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Unique token (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods) from Google Play for the user.
        /// </summary>
        public string AccessToken { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this Google account.
        /// </summary>
        public bool? CreateAccount { get; set;}

        /// <summary>
        /// Deprecated - unused
        /// </summary>
        public string PublisherId { get; set;}
    }

    public class LoginWithIOSDeviceIDRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Vendor-specific iOS identifier for the user's device.
        /// </summary>
        public string DeviceId { get; set;}

        /// <summary>
        /// Specific Operating System version for the user's device.
        /// </summary>
        public string OS { get; set;}

        /// <summary>
        /// Specific model of the user's device.
        /// </summary>
        public string DeviceModel { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this iOS device.
        /// </summary>
        public bool? CreateAccount { get; set;}
    }

    public class LoginWithKongregateRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Numeric user ID assigned by Kongregate
        /// </summary>
        public string KongregateId { get; set;}

        /// <summary>
        /// Token issued by Kongregate's client API for the user.
        /// </summary>
        public string AuthTicket { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this Kongregate account.
        /// </summary>
        public bool? CreateAccount { get; set;}
    }

    public class LoginWithPlayFabRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// PlayFab username for the account.
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// Password for the PlayFab account (6-30 characters)
        /// </summary>
        public string Password { get; set;}
    }

    public class LoginWithSteamRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08").
        /// </summary>
        public string SteamTicket { get; set;}

        /// <summary>
        /// Automatically create a PlayFab account if one is not currently linked to this Steam account.
        /// </summary>
        public bool? CreateAccount { get; set;}
    }

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

    public class MatchmakeRequest
    {

        /// <summary>
        /// build version to match against [Note: Required if LobbyId is not specified]
        /// </summary>
        public string BuildVersion { get; set;}

        /// <summary>
        /// region to match make against [Note: Required if LobbyId is not specified]
        /// </summary>
        public Region? Region { get; set;}

        /// <summary>
        /// game mode to match make against [Note: Required if LobbyId is not specified]
        /// </summary>
        public string GameMode { get; set;}

        /// <summary>
        /// lobby identifier to match make against (used to select a specific server)
        /// </summary>
        public string LobbyId { get; set;}

        /// <summary>
        /// player statistic to use in finding a match. May be null for no stat-based matching
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// character to use for stats based matching. Leave null to use account stats
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// [deprecated]
        /// </summary>
        public bool? EnableQueue { get; set;}
    }

    public class MatchmakeResult : PlayFabResultCommon
    {

        /// <summary>
        /// unique lobby identifier of the server matched
        /// </summary>
        public string LobbyID { get; set;}

        /// <summary>
        /// IP address of the server
        /// </summary>
        public string ServerHostname { get; set;}

        /// <summary>
        /// port number to use for non-http communications with the server
        /// </summary>
        public int? ServerPort { get; set;}

        /// <summary>
        /// server authorization ticket (used by RedeemCoupon to validate user insertion into the game)
        /// </summary>
        public string Ticket { get; set;}

        /// <summary>
        /// timestamp for when the server will expire, if applicable
        /// </summary>
        public string Expires { get; set;}

        /// <summary>
        /// time in milliseconds the application is configured to wait on matchmaking results
        /// </summary>
        public int? PollWaitTimeMS { get; set;}

        /// <summary>
        /// result of match making process
        /// </summary>
        public MatchmakeStatus? Status { get; set;}
    }

    public enum MatchmakeStatus
    {
        Complete,
        Waiting,
        GameNotFound
    }

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

    public class OpenTradeRequest
    {

        /// <summary>
        /// Player inventory items offered for trade. If not set, the trade is effectively a gift request
        /// </summary>
        public List<string> OfferedInventoryInstanceIds { get; set;}

        /// <summary>
        /// Catalog items accepted for the trade. If not set, the trade is effectively a gift.
        /// </summary>
        public List<string> RequestedCatalogItemIds { get; set;}

        /// <summary>
        /// Players who are allowed to accept the trade. If null, the trade may be accepted by any player. If empty, the trade may not be accepted by any player.
        /// </summary>
        public List<string> AllowedPlayerIds { get; set;}
    }

    public class OpenTradeResponse : PlayFabResultCommon
    {

        /// <summary>
        /// The information about the trade that was just opened.
        /// </summary>
        public TradeInfo Trade { get; set;}
    }

    public class PayForPurchaseRequest
    {

        /// <summary>
        /// Purchase order identifier returned from StartPurchase.
        /// </summary>
        public string OrderId { get; set;}

        /// <summary>
        /// Payment provider to use to fund the purchase.
        /// </summary>
        public string ProviderName { get; set;}

        /// <summary>
        /// Currency to use to fund the purchase.
        /// </summary>
        public string Currency { get; set;}

        /// <summary>
        /// Payment provider transaction identifier. Required for Facebook Payments.
        /// </summary>
        public string ProviderTransactionId { get; set;}
    }

    public class PayForPurchaseResult : PlayFabResultCommon
    {

        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId { get; set;}

        /// <summary>
        /// Status of the transaction.
        /// </summary>
        public TransactionStatus? Status { get; set;}

        /// <summary>
        /// Virtual currency cost of the transaction.
        /// </summary>
        public Dictionary<string,int> VCAmount { get; set;}

        /// <summary>
        /// Real world currency for the transaction.
        /// </summary>
        public string PurchaseCurrency { get; set;}

        /// <summary>
        /// Real world cost of the transaction.
        /// </summary>
        public uint PurchasePrice { get; set;}

        /// <summary>
        /// Local credit applied to the transaction (provider specific).
        /// </summary>
        public uint CreditApplied { get; set;}

        /// <summary>
        /// Provider used for the transaction.
        /// </summary>
        public string ProviderData { get; set;}

        /// <summary>
        /// URL to the purchase provider page that details the purchase.
        /// </summary>
        public string PurchaseConfirmationPageURL { get; set;}

        /// <summary>
        /// Current virtual currency totals for the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency { get; set;}
    }

    public class PaymentOption
    {

        /// <summary>
        /// Specific currency to use to fund the purchase.
        /// </summary>
        public string Currency { get; set;}

        /// <summary>
        /// Name of the purchase provider for this option.
        /// </summary>
        public string ProviderName { get; set;}

        /// <summary>
        /// Amount of the specified currency needed for the purchase.
        /// </summary>
        public uint Price { get; set;}

        /// <summary>
        /// Amount of existing credit the user has with the provider.
        /// </summary>
        public uint StoreCredit { get; set;}
    }

    public class PlayerLeaderboardEntry
    {

        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue { get; set;}

        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position { get; set;}
    }

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
    }

    public class PurchaseItemRequest
    {

        /// <summary>
        /// Unique identifier of the item to purchase.
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// Virtual currency to use to purchase the item.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Price the client expects to pay for the item (in case a new catalog or store was uploaded, with new prices).
        /// </summary>
        public int Price { get; set;}

        /// <summary>
        /// Catalog version for the items to be purchased (defaults to most recent version.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Store to buy this item through. If not set, prices default to those in the catalog.
        /// </summary>
        public string StoreId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    public class PurchaseItemResult : PlayFabResultCommon
    {

        /// <summary>
        /// Details for the items purchased.
        /// </summary>
        public List<ItemInstance> Items { get; set;}
    }

    public class RedeemCouponRequest
    {

        /// <summary>
        /// Generated coupon code to redeem.
        /// </summary>
        public string CouponCode { get; set;}

        /// <summary>
        /// Catalog version of the coupon.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class RedeemCouponResult : PlayFabResultCommon
    {

        /// <summary>
        /// Items granted to the player as a result of redeeming the coupon.
        /// </summary>
        public List<ItemInstance> GrantedItems { get; set;}
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

    public class RegionInfo
    {

        /// <summary>
        /// unique identifier for the region
        /// </summary>
        public Region? Region { get; set;}

        /// <summary>
        /// name of the region
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        /// indicates whether the server specified is available in this region
        /// </summary>
        public bool Available { get; set;}

        /// <summary>
        /// url to ping to get roundtrip time
        /// </summary>
        public string PingUrl { get; set;}
    }

    public class RegisterForIOSPushNotificationRequest
    {

        /// <summary>
        /// Unique token generated by the Apple Push Notification service when the title registered to receive push notifications.
        /// </summary>
        public string DeviceToken { get; set;}

        /// <summary>
        /// If true, send a test push message immediately after sucessful registration. Defaults to false.
        /// </summary>
        public bool? SendPushNotificationConfirmation { get; set;}

        /// <summary>
        /// Message to display when confirming push notification.
        /// </summary>
        public string ConfirmationMessage { get; set;}
    }

    public class RegisterForIOSPushNotificationResult : PlayFabResultCommon
    {
    }

    public class RegisterPlayFabUserRequest
    {

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// PlayFab username for the account (3-20 characters)
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email { get; set;}

        /// <summary>
        /// Password for the PlayFab account (6-30 characters)
        /// </summary>
        public string Password { get; set;}

        /// <summary>
        /// An optional parameter that specifies whether both the username and email parameters are required. If true, both parameters are required; if false, the user must supply either the username or email parameter. The default value is true.
        /// </summary>
        public bool? RequireBothUsernameAndEmail { get; set;}

        /// <summary>
        /// An optional parameter for setting the display name for this title.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// [Deprecated - The Origination of a user is determined by the API call used to create the account. In the case of RegisterPlayFabUser, it will be Organic.
        /// </summary>
        public string Origination { get; set;}
    }

    public class RegisterPlayFabUserResult : PlayFabResultCommon
    {

        /// <summary>
        /// PlayFab unique identifier for this newly created account.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique token identifying the user and game at the server level, for the current session.
        /// </summary>
        public string SessionTicket { get; set;}

        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// Settings specific to this user.
        /// </summary>
        public UserSettings SettingsForUser { get; set;}
    }

    public class RemoveFriendRequest
    {

        /// <summary>
        /// PlayFab identifier of the friend account which is to be removed.
        /// </summary>
        public string FriendPlayFabId { get; set;}
    }

    public class RemoveFriendResult : PlayFabResultCommon
    {
    }

    public class RemoveSharedGroupMembersRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds { get; set;}
    }

    public class RemoveSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    public class ReportPlayerClientRequest
    {

        /// <summary>
        /// Unique PlayFab identifier of the reported player.
        /// </summary>
        public string ReporteeId { get; set;}

        /// <summary>
        /// Optional additional comment by reporting player.
        /// </summary>
        public string Comment { get; set;}
    }

    public class ReportPlayerClientResult : PlayFabResultCommon
    {

        /// <summary>
        /// Indicates whether this action completed successfully.
        /// </summary>
        public bool Updated { get; set;}

        /// <summary>
        /// The number of remaining reports which may be filed today.
        /// </summary>
        public int SubmissionsRemaining { get; set;}
    }

    public class RestoreIOSPurchasesRequest
    {

        /// <summary>
        /// Base64 encoded receipt data, passed back by the App Store as a result of a successful purchase.
        /// </summary>
        public string ReceiptData { get; set;}
    }

    public class RestoreIOSPurchasesResult : PlayFabResultCommon
    {
    }

    public class RunCloudScriptRequest
    {

        /// <summary>
        /// server action to trigger
        /// </summary>
        public string ActionId { get; set;}

        /// <summary>
        /// parameters to pass into the action (If you use this, don't use ParamsEncoded)
        /// </summary>
        public object Params { get; set;}

        /// <summary>
        /// json-encoded parameters to pass into the action (If you use this, don't use Params)
        /// </summary>
        public string ParamsEncoded { get; set;}
    }

    public class RunCloudScriptResult : PlayFabResultCommon
    {

        /// <summary>
        /// id of Cloud Script run
        /// </summary>
        public string ActionId { get; set;}

        /// <summary>
        /// version of Cloud Script run
        /// </summary>
        public int Version { get; set;}

        /// <summary>
        /// revision of Cloud Script run
        /// </summary>
        public int Revision { get; set;}

        /// <summary>
        /// return values from the server action as a dynamic object
        /// </summary>
        public object Results { get; set;}

        /// <summary>
        /// return values from the server action as a JSON encoded string
        /// </summary>
        public string ResultsEncoded { get; set;}

        /// <summary>
        /// any log statements generated during the run of this action
        /// </summary>
        public string ActionLog { get; set;}

        /// <summary>
        /// time this script took to run, in seconds
        /// </summary>
        public double ExecutionTime { get; set;}
    }

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

    public class SendAccountRecoveryEmailRequest
    {

        /// <summary>
        /// User email address attached to their account
        /// </summary>
        public string Email { get; set;}

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Deprecated - unused
        /// </summary>
        public string PublisherId { get; set;}
    }

    public class SendAccountRecoveryEmailResult : PlayFabResultCommon
    {
    }

    public class SetFriendTagsRequest
    {

        /// <summary>
        /// PlayFab identifier of the friend account to which the tag(s) should be applied.
        /// </summary>
        public string FriendPlayFabId { get; set;}

        /// <summary>
        /// Array of tags to set on the friend account.
        /// </summary>
        public List<string> Tags { get; set;}
    }

    public class SetFriendTagsResult : PlayFabResultCommon
    {
    }

    public class SharedGroupDataRecord
    {

        /// <summary>
        /// Data stored for the specified group data key.
        /// </summary>
        public string Value { get; set;}

        /// <summary>
        /// Unique PlayFab identifier of the user to last update this value.
        /// </summary>
        public string LastUpdatedBy { get; set;}

        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set;}

        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only members of the group (private).
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class StartGameRequest
    {

        /// <summary>
        /// version information for the build of the game server which is to be started
        /// </summary>
        public string BuildVersion { get; set;}

        /// <summary>
        /// the region to associate this server with for match filtering
        /// </summary>
        public Region Region { get; set;}

        /// <summary>
        /// the title-defined game mode this server is to be running (defaults to 0 if there is only one mode)
        /// </summary>
        public string GameMode { get; set;}

        /// <summary>
        /// player statistic for others to use in finding this game. May be null for no stat-based matching
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// character to use for stats based matching. Leave null to use account stats
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// custom command line argument when starting game server process
        /// </summary>
        public string CustomCommandLineData { get; set;}
    }

    public class StartGameResult : PlayFabResultCommon
    {

        /// <summary>
        /// unique identifier for the lobby of the server started
        /// </summary>
        public string LobbyID { get; set;}

        /// <summary>
        /// server IP address
        /// </summary>
        public string ServerHostname { get; set;}

        /// <summary>
        /// port on the server to be used for communication
        /// </summary>
        public int? ServerPort { get; set;}

        /// <summary>
        /// unique identifier for the server
        /// </summary>
        public string Ticket { get; set;}

        /// <summary>
        /// timestamp for when the server should expire, if applicable
        /// </summary>
        public string Expires { get; set;}

        /// <summary>
        /// password required to log into the server
        /// </summary>
        public string Password { get; set;}
    }

    public class StartPurchaseRequest
    {

        /// <summary>
        /// Catalog version for the items to be purchased. Defaults to most recent catalog.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Store through which to purchase items. If not set, prices will be pulled from the catalog itself.
        /// </summary>
        public string StoreId { get; set;}

        /// <summary>
        /// Array of items to purchase.
        /// </summary>
        public List<ItemPurchaseRequest> Items { get; set;}
    }

    public class StartPurchaseResult : PlayFabResultCommon
    {

        /// <summary>
        /// Purchase order identifier.
        /// </summary>
        public string OrderId { get; set;}

        /// <summary>
        /// Cart items to be purchased.
        /// </summary>
        public List<CartItem> Contents { get; set;}

        /// <summary>
        /// Available methods by which the user can pay.
        /// </summary>
        public List<PaymentOption> PaymentOptions { get; set;}

        /// <summary>
        /// Current virtual currency totals for the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrencyBalances { get; set;}
    }

    public class StatisticNameVersion
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// the version of the statistic to be returned
        /// </summary>
        public uint Version { get; set;}
    }

    public class StatisticUpdate
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded. Null when setting the statistic value for the first time.
        /// </summary>
        public uint? Version { get; set;}

        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value { get; set;}
    }

    public class StatisticValue
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value { get; set;}

        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded
        /// </summary>
        public uint Version { get; set;}
    }

    public class SteamPlayFabIdPair
    {

        /// <summary>
        /// Deprecated: Please use SteamStringId
        /// </summary>
        public ulong SteamId { get; set;}

        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamStringId { get; set;}

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam identifier.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    /// <summary>
    /// A store entry that list a catalog item at a particular price
    /// </summary>
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

    public class SubtractUserVirtualCurrencyRequest
    {

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

    public class TitleNewsItem
    {

        /// <summary>
        /// Date and time when the news items was posted.
        /// </summary>
        public DateTime Timestamp { get; set;}

        /// <summary>
        /// Unique identifier of news item.
        /// </summary>
        public string NewsId { get; set;}

        /// <summary>
        /// Title of the news item.
        /// </summary>
        public string Title { get; set;}

        /// <summary>
        /// News item text.
        /// </summary>
        public string Body { get; set;}
    }

    public class TradeInfo
    {

        /// <summary>
        /// Describes the current state of this trade.
        /// </summary>
        public TradeStatus? Status { get; set;}

        /// <summary>
        /// The identifier for this trade.
        /// </summary>
        public string TradeId { get; set;}

        /// <summary>
        /// The PlayFabId for the offering player.
        /// </summary>
        public string OfferingPlayerId { get; set;}

        /// <summary>
        /// The itemInstance Ids that are being offered.
        /// </summary>
        public List<string> OfferedInventoryInstanceIds { get; set;}

        /// <summary>
        /// The catalogItem Ids of the item instances being offered.
        /// </summary>
        public List<string> OfferedCatalogItemIds { get; set;}

        /// <summary>
        /// The catalogItem Ids requested in exchange.
        /// </summary>
        public List<string> RequestedCatalogItemIds { get; set;}

        /// <summary>
        /// An optional list of players allowed to complete this trade.  If null, anybody can complete the trade.
        /// </summary>
        public List<string> AllowedPlayerIds { get; set;}

        /// <summary>
        /// The PlayFab ID of the player who accepted the trade. If null, no one has accepted the trade.
        /// </summary>
        public string AcceptedPlayerId { get; set;}

        /// <summary>
        /// Item instances from the accepting player that are used to fulfill the trade. If null, no one has accepted the trade.
        /// </summary>
        public List<string> AcceptedInventoryInstanceIds { get; set;}

        /// <summary>
        /// The UTC time when this trade was created.
        /// </summary>
        public DateTime? OpenedAt { get; set;}

        /// <summary>
        /// If set, The UTC time when this trade was fulfilled.
        /// </summary>
        public DateTime? FilledAt { get; set;}

        /// <summary>
        /// If set, The UTC time when this trade was canceled.
        /// </summary>
        public DateTime? CancelledAt { get; set;}

        /// <summary>
        /// If set, The UTC time when this trade was made invalid.
        /// </summary>
        public DateTime? InvalidatedAt { get; set;}
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

    public class UnlinkAndroidDeviceIDRequest
    {

        /// <summary>
        /// Android device identifier for the user's device. If not specified, the most recently signed in Android Device ID will be used.
        /// </summary>
        public string AndroidDeviceId { get; set;}
    }

    public class UnlinkAndroidDeviceIDResult : PlayFabResultCommon
    {
    }

    public class UnlinkCustomIDRequest
    {

        /// <summary>
        /// Custom unique identifier for the user, generated by the title. If not specified, the most recently signed in Custom ID will be used.
        /// </summary>
        public string CustomId { get; set;}
    }

    public class UnlinkCustomIDResult : PlayFabResultCommon
    {
    }

    public class UnlinkFacebookAccountRequest
    {
    }

    public class UnlinkFacebookAccountResult : PlayFabResultCommon
    {
    }

    public class UnlinkGameCenterAccountRequest
    {
    }

    public class UnlinkGameCenterAccountResult : PlayFabResultCommon
    {
    }

    public class UnlinkGoogleAccountRequest
    {
    }

    public class UnlinkGoogleAccountResult : PlayFabResultCommon
    {
    }

    public class UnlinkIOSDeviceIDRequest
    {

        /// <summary>
        /// Vendor-specific iOS identifier for the user's device. If not specified, the most recently signed in iOS Device ID will be used.
        /// </summary>
        public string DeviceId { get; set;}
    }

    public class UnlinkIOSDeviceIDResult : PlayFabResultCommon
    {
    }

    public class UnlinkKongregateAccountRequest
    {
    }

    public class UnlinkKongregateAccountResult : PlayFabResultCommon
    {
    }

    public class UnlinkSteamAccountRequest
    {
    }

    public class UnlinkSteamAccountResult : PlayFabResultCommon
    {
    }

    public class UnlockContainerInstanceRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// ItemInstanceId of the container to unlock.
        /// </summary>
        public string ContainerItemInstanceId { get; set;}

        /// <summary>
        /// ItemInstanceId of the key that will be consumed by unlocking this container.  If the container requires a key, this parameter is required.
        /// </summary>
        public string KeyItemInstanceId { get; set;}

        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses catalog associated with the item instance.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class UnlockContainerItemRequest
    {

        /// <summary>
        /// Catalog ItemId of the container type to unlock.
        /// </summary>
        public string ContainerItemId { get; set;}

        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    public class UnlockContainerItemResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique instance identifier of the container unlocked.
        /// </summary>
        public string UnlockedItemInstanceId { get; set;}

        /// <summary>
        /// Unique instance identifier of the key used to unlock the container, if applicable.
        /// </summary>
        public string UnlockedWithItemInstanceId { get; set;}

        /// <summary>
        /// Items granted to the player as a result of unlocking the container.
        /// </summary>
        public List<ItemInstance> GrantedItems { get; set;}

        /// <summary>
        /// Virtual currency granted to the player as a result of unlocking the container.
        /// </summary>
        public Dictionary<string,uint> VirtualCurrency { get; set;}
    }

    public class UpdateCharacterDataRequest
    {

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

        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class UpdateCharacterDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
    }

    public class UpdateCharacterStatisticsRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Statistics to be updated with the provided values.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics { get; set;}
    }

    public class UpdateCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    public class UpdatePlayerStatisticsRequest
    {

        /// <summary>
        /// Statistics to be updated with the provided values
        /// </summary>
        public List<StatisticUpdate> Statistics { get; set;}
    }

    public class UpdatePlayerStatisticsResult : PlayFabResultCommon
    {
    }

    public class UpdateSharedGroupDataRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}

        /// <summary>
        /// Permission to be applied to all user data keys in this request.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class UpdateSharedGroupDataResult : PlayFabResultCommon
    {
    }

    public class UpdateUserDataRequest
    {

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

    public class UpdateUserDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
    }

    public class UpdateUserStatisticsRequest
    {

        /// <summary>
        /// Statistics to be updated with the provided values. UserStatistics object must follow the Key(string), Value(int) pattern.
        /// </summary>
        public Dictionary<string,int> UserStatistics { get; set;}
    }

    public class UpdateUserStatisticsResult : PlayFabResultCommon
    {
    }

    public class UpdateUserTitleDisplayNameRequest
    {

        /// <summary>
        /// New title display name for the user - must be between 3 and 25 characters.
        /// </summary>
        public string DisplayName { get; set;}
    }

    public class UpdateUserTitleDisplayNameResult : PlayFabResultCommon
    {

        /// <summary>
        /// Current title display name for the user (this will be the original display name if the rename attempt failed).
        /// </summary>
        public string DisplayName { get; set;}
    }

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

    public class UserAndroidDeviceInfo
    {

        /// <summary>
        /// Android device ID
        /// </summary>
        public string AndroidDeviceId { get; set;}
    }

    public class UserCustomIdInfo
    {

        /// <summary>
        /// Custom ID
        /// </summary>
        public string CustomId { get; set;}
    }

    public enum UserDataPermission
    {
        Private,
        Public
    }

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
        /// Indicates whether this data can be read by all users (public) or only the user (private).
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

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

    public class UserGameCenterInfo
    {

        /// <summary>
        /// Gamecenter identifier
        /// </summary>
        public string GameCenterId { get; set;}
    }

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

    public class UserIosDeviceInfo
    {

        /// <summary>
        /// iOS device ID
        /// </summary>
        public string IosDeviceId { get; set;}
    }

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
        Parse
    }

    public class UserPrivateAccountInfo
    {

        /// <summary>
        /// user email address
        /// </summary>
        public string Email { get; set;}
    }

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

    public class UserSettings
    {

        /// <summary>
        /// Boolean for whether this player is eligible for ad tracking.
        /// </summary>
        public bool NeedsAttribution { get; set;}
    }

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

    public class UserXboxInfo
    {

        /// <summary>
        /// XBox user ID
        /// </summary>
        public string XboxUserId { get; set;}
    }

    public class ValidateAmazonReceiptRequest
    {

        /// <summary>
        /// ReceiptId returned by the Amazon App Store in-app purchase API
        /// </summary>
        public string ReceiptId { get; set;}

        /// <summary>
        /// AmazonId of the user making the purchase as returned by the Amazon App Store in-app purchase API
        /// </summary>
        public string UserId { get; set;}

        /// <summary>
        /// Catalog version to use when granting receipt item. If null, defaults to primary catalog.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Currency used for the purchase.
        /// </summary>
        public string CurrencyCode { get; set;}

        /// <summary>
        /// Amount of the stated currency paid for the object.
        /// </summary>
        public int PurchasePrice { get; set;}
    }

    public class ValidateAmazonReceiptResult : PlayFabResultCommon
    {
    }

    public class ValidateGooglePlayPurchaseRequest
    {

        /// <summary>
        /// Original JSON string returned by the Google Play IAB API.
        /// </summary>
        public string ReceiptJson { get; set;}

        /// <summary>
        /// Signature returned by the Google Play IAB API.
        /// </summary>
        public string Signature { get; set;}

        /// <summary>
        /// Currency used for the purchase.
        /// </summary>
        public string CurrencyCode { get; set;}

        /// <summary>
        /// Amount of the stated currency paid for the object.
        /// </summary>
        public uint? PurchasePrice { get; set;}
    }

    public class ValidateGooglePlayPurchaseResult : PlayFabResultCommon
    {
    }

    public class ValidateIOSReceiptRequest
    {

        /// <summary>
        /// Base64 encoded receipt data, passed back by the App Store as a result of a successful purchase.
        /// </summary>
        public string ReceiptData { get; set;}

        /// <summary>
        /// Currency used for the purchase.
        /// </summary>
        public string CurrencyCode { get; set;}

        /// <summary>
        /// Amount of the stated currency paid for the object.
        /// </summary>
        public int PurchasePrice { get; set;}
    }

    public class ValidateIOSReceiptResult : PlayFabResultCommon
    {
    }

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

    public class WriteClientCharacterEventRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// The name of this event. This field is alphanumeric and at most 64 characters long. It is internally namespaced down onto the calling title. Best practices are to name in subject_verb_object format (player_logged_in).
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// The time (in UTC) associated with this event. If omitted, a timestamp of now in UTC will be applied.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// Arbitrary json values that represent the custom body of this event.
        /// </summary>
        public Dictionary<string,object> Body { get; set;}
    }

    public class WriteClientPlayerEventRequest
    {

        /// <summary>
        /// The name of this event. This field is alphanumeric and at most 64 characters long. It is internally namespaced down onto the calling title. Best practices are to name in subject_verb_object format (player_logged_in).
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// The time (in UTC) associated with this event. If omitted, a timestamp of 'now' in UTC will be applied.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// Arbitrary json values that represent the custom body of this event.
        /// </summary>
        public Dictionary<string,object> Body { get; set;}
    }

    public class WriteEventResponse : PlayFabResultCommon
    {

        /// <summary>
        /// The ID of the event as it was written to PlayStream. This is an alphanumeric GUID.
        /// </summary>
        public string EventId { get; set;}
    }

    public class WriteTitleEventRequest
    {

        /// <summary>
        /// The name of this event. This field is alphanumeric and at most 64 characters long. It is internally namespaced down onto the calling title. Best practices are to name in subject_verb_object format (player_logged_in).
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// The time (in UTC) associated with this event. If omitted, a timestamp of now in UTC will be applied.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// Arbitrary json values that represent the custom body of this event.
        /// </summary>
        public Dictionary<string,object> Body { get; set;}
    }
}
