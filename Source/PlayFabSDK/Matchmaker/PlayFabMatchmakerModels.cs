#if ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.MatchmakerModels
{
    [Serializable]
    public class AuthUserRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Session Ticket provided by the client.
        /// </summary>
        public string AuthorizationTicket;
    }

    [Serializable]
    public class AuthUserResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Boolean indicating if the user has been authorized to use the external match-making service.
        /// </summary>
        public bool Authorized;
        /// <summary>
        /// PlayFab unique identifier of the account that has been authorized.
        /// </summary>
        public string PlayFabId;
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
    public class PlayerJoinedRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the Game Server Instance the user is joining.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// PlayFab unique identifier for the user joining.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class PlayerJoinedResponse : PlayFabResultCommon
    {
    }

    [Serializable]
    public class PlayerLeftRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the Game Server Instance the user is leaving.
        /// </summary>
        public string LobbyId;
        /// <summary>
        /// PlayFab unique identifier for the user leaving.
        /// </summary>
        public string PlayFabId;
    }

    [Serializable]
    public class PlayerLeftResponse : PlayFabResultCommon
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
        /// Previous lobby id if re-registering an existing game.
        /// </summary>
        public string LobbyId;
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
        /// Unique identifier generated for the Game Server Instance that is registered. If LobbyId is specified in request and the game still exists in PlayFab, the LobbyId in request is returned. Otherwise a new lobby id will be returned.
        /// </summary>
        public string LobbyId;
    }

    [Serializable]
    public class StartGameRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Unique identifier of the previously uploaded build executable which is to be started.
        /// </summary>
        public string Build;
        /// <summary>
        /// Region with which to associate the server, for filtering.
        /// </summary>
        public Region Region;
        /// <summary>
        /// Game mode for this Game Server Instance.
        /// </summary>
        public string GameMode;
        /// <summary>
        /// Custom command line argument when starting game server process.
        /// </summary>
        public string CustomCommandLineData;
        /// <summary>
        /// HTTP endpoint URL for receiving game status events, if using an external matchmaker. When the game ends, PlayFab will make a POST request to this URL with the X-SecretKey header set to the value of the game's secret and an application/json body of { "EventName": "game_ended", "GameID": "<gameid>" }.
        /// </summary>
        public string ExternalMatchmakerEventEndpoint;
    }

    [Serializable]
    public class StartGameResponse : PlayFabResultCommon
    {
        /// <summary>
        /// Unique identifier for the game/lobby in the new Game Server Instance.
        /// </summary>
        public string GameID;
        /// <summary>
        /// IP address of the new Game Server Instance.
        /// </summary>
        public string ServerHostname;
        /// <summary>
        /// Port number for communication with the Game Server Instance.
        /// </summary>
        public uint ServerPort;
    }

    [Serializable]
    public class UserInfoRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose information is being requested.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// Minimum catalog version for which data is requested (filters the results to only contain inventory items which have a catalog version of this or higher).
        /// </summary>
        public int MinCatalogVersion;
    }

    [Serializable]
    public class UserInfoResponse : PlayFabResultCommon
    {
        /// <summary>
        /// PlayFab unique identifier of the user whose information was requested.
        /// </summary>
        public string PlayFabId;
        /// <summary>
        /// PlayFab unique user name.
        /// </summary>
        public string Username;
        /// <summary>
        /// Title specific display name, if set.
        /// </summary>
        public string TitleDisplayName;
        /// <summary>
        /// Array of inventory items in the user's current inventory.
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
        /// <summary>
        /// Boolean indicating whether the user is a developer.
        /// </summary>
        public bool IsDeveloper;
        /// <summary>
        /// Steam unique identifier, if the user has an associated Steam account.
        /// </summary>
        public string SteamId;
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
