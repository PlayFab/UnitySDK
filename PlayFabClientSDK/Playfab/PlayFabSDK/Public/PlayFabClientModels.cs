using System;
using System.Collections.Generic;
using PlayFab.Internal;

namespace PlayFab.ClientModels
{
	
	
	
	public class AddFriendRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab username of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendUsername { get; set;}
		
		/// <summary>
		/// email address of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendEmail { get; set;}
		
		/// <summary>
		/// title-specific display name of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendTitleDisplayName { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			FriendUsername = (string)JsonUtil.Get<string>(json, "FriendUsername");
			FriendEmail = (string)JsonUtil.Get<string>(json, "FriendEmail");
			FriendTitleDisplayName = (string)JsonUtil.Get<string>(json, "FriendTitleDisplayName");
		}
	}
	
	
	
	public class AddFriendResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// was the friend request processed successfully
		/// </summary>
		
		public bool Created { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Created = (bool)JsonUtil.Get<bool?>(json, "Created");
		}
	}
	
	
	
	public class AddSharedGroupMembersRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to add as members of the shared group
		/// </summary>
		
		public List<string> PlayFabIds { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			PlayFabIds = JsonUtil.GetList<string>(json, "PlayFabIds");
		}
	}
	
	
	
	public class AddSharedGroupMembersResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class AddUsernamePasswordRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab username for the account to be signed in (3-24 characters)
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// user email address, used for account password recovery
		/// </summary>
		
		public string Email { get; set;}
		
		/// <summary>
		/// password for the account to be signed in (6-24 characters)
		/// </summary>
		
		public string Password { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Email = (string)JsonUtil.Get<string>(json, "Email");
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
	
	
	
	public class AddUsernamePasswordResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		
		public string Username { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Username = (string)JsonUtil.Get<string>(json, "Username");
		}
	}
	
	
	
	public class AddUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the virtual currency which is to be incremented
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be added to the user balance of the specified virtual currency
		/// </summary>
		
		public int Amount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Amount = (int)JsonUtil.Get<double?>(json, "Amount");
		}
	}
	
	
	
	public class AndroidDevicePushNotificationRegistrationRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// the Registration ID provided by the Google Cloud Messaging service when the title registered to receive push notifications (see the GCM documentation, here: http://developer.android.com/google/gcm/client.html)
		/// </summary>
		
		public string DeviceToken { get; set;}
		
		/// <summary>
		/// If true, send a test push message immediately after sucessful registration. Defaults to false.
		/// </summary>
		
		public bool? SendPushNotificationConfirmation { get; set;}
		
		/// <summary>
		/// Message to display when confirming push notification.
		/// </summary>
		
		public string ConfirmationMessege { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DeviceToken = (string)JsonUtil.Get<string>(json, "DeviceToken");
			SendPushNotificationConfirmation = (bool?)JsonUtil.Get<bool?>(json, "SendPushNotificationConfirmation");
			ConfirmationMessege = (string)JsonUtil.Get<string>(json, "ConfirmationMessege");
		}
	}
	
	
	
	public class AndroidDevicePushNotificationRegistrationResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class CartItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the catalog item
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// class name to which catalog item belongs
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// unique instance identifier for this catalog item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// display name for the catalog item
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// description of the catalog item
		/// </summary>
		
		public string Description { get; set;}
		
		/// <summary>
		/// the cost of the catalog item for each applicable virtual currency
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// the cost of the catalog item for each applicable real world currency
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// the amount of each applicable virtual currency which will be received as a result of purchasing this catalog item
		/// </summary>
		
		public Dictionary<string,uint> VCAmount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Description = (string)JsonUtil.Get<string>(json, "Description");
			VirtualCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyPrices");
			RealCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "RealCurrencyPrices");
			VCAmount = JsonUtil.GetDictionaryUInt32(json, "VCAmount");
		}
	}
	
	
	
	/// <summary>
	/// A purchasable item from the item catalog
	/// </summary>
	public class CatalogItem : PlayFabModelBase
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
		/// catalog item for this item
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
		/// the date this item becomes available for purchase
		/// </summary>
		
		public DateTime? ReleaseDate { get; set;}
		
		/// <summary>
		/// the date this item will no longer be available for purchase
		/// </summary>
		
		public DateTime? ExpirationDate { get; set;}
		
		/// <summary>
		/// (deprecated)
		/// </summary>
		
		public bool? IsFree { get; set;}
		
		/// <summary>
		/// can this item be purchased (if not, it can still be granted by a server-based operation, such as a loot drop from a monster)
		/// </summary>
		
		public bool? NotForSale { get; set;}
		
		/// <summary>
		/// can an instance of this item be exchanged between players?
		/// </summary>
		
		public bool? NotForTrade { get; set;}
		
		/// <summary>
		/// list of item tags
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// game specific custom data
		/// </summary>
		
		public string CustomData { get; set;}
		
		/// <summary>
		/// array of ItemId values which are evaluated when any item is added to the player inventory - if all items in this array are present, the this item will also be added to the player inventory
		/// </summary>
		
		public List<string> GrantedIfPlayerHas { get; set;}
		
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Description = (string)JsonUtil.Get<string>(json, "Description");
			VirtualCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyPrices");
			RealCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "RealCurrencyPrices");
			ReleaseDate = (DateTime?)JsonUtil.GetDateTime(json, "ReleaseDate");
			ExpirationDate = (DateTime?)JsonUtil.GetDateTime(json, "ExpirationDate");
			IsFree = (bool?)JsonUtil.Get<bool?>(json, "IsFree");
			NotForSale = (bool?)JsonUtil.Get<bool?>(json, "NotForSale");
			NotForTrade = (bool?)JsonUtil.Get<bool?>(json, "NotForTrade");
			Tags = JsonUtil.GetList<string>(json, "Tags");
			CustomData = (string)JsonUtil.Get<string>(json, "CustomData");
			GrantedIfPlayerHas = JsonUtil.GetList<string>(json, "GrantedIfPlayerHas");
			Consumable = JsonUtil.GetObject<CatalogItemConsumableInfo>(json, "Consumable");
			Container = JsonUtil.GetObject<CatalogItemContainerInfo>(json, "Container");
			Bundle = JsonUtil.GetObject<CatalogItemBundleInfo>(json, "Bundle");
		}
	}
	
	
	
	public class CatalogItemBundleInfo : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BundledItems = JsonUtil.GetList<string>(json, "BundledItems");
			BundledResultTables = JsonUtil.GetList<string>(json, "BundledResultTables");
			BundledVirtualCurrencies = JsonUtil.GetDictionaryUInt32(json, "BundledVirtualCurrencies");
		}
	}
	
	
	
	public class CatalogItemConsumableInfo : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UsageCount = (uint?)JsonUtil.Get<double?>(json, "UsageCount");
			UsagePeriod = (uint?)JsonUtil.Get<double?>(json, "UsagePeriod");
			UsagePeriodGroup = (string)JsonUtil.Get<string>(json, "UsagePeriodGroup");
		}
	}
	
	
	
	/// <summary>
	/// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
	/// </summary>
	public class CatalogItemContainerInfo : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			KeyItemId = (string)JsonUtil.Get<string>(json, "KeyItemId");
			ItemContents = JsonUtil.GetList<string>(json, "ItemContents");
			ResultTableContents = JsonUtil.GetList<string>(json, "ResultTableContents");
			VirtualCurrencyContents = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyContents");
		}
	}
	
	
	
	public class ConfirmPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		
		public string OrderId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
		}
	}
	
	
	
	public class ConfirmPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// date and time of the purchase
		/// </summary>
		
		public DateTime PurchaseDate { get; set;}
		
		/// <summary>
		/// array of items purchased
		/// </summary>
		
		public List<PurchasedItem> Items { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			PurchaseDate = (DateTime)JsonUtil.GetDateTime(json, "PurchaseDate");
			Items = JsonUtil.GetObjectList<PurchasedItem>(json, "Items");
		}
	}
	
	
	
	public class ConsumeItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique instance identifier of the item to be consumed
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// number of uses to consume from the item
		/// </summary>
		
		public int ConsumeCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			ConsumeCount = (int)JsonUtil.Get<double?>(json, "ConsumeCount");
		}
	}
	
	
	
	public class ConsumeItemResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class CreateSharedGroupRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group (a random identifier will be assigned, if one is not specified)
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
		}
	}
	
	
	
	public class CreateSharedGroupResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
		}
	}
	
	
	
	public enum Currency
	{
		USD,
		GBP,
		EUR,
		RUB,
		BRL,
		CIS,
		CAD
	}
	
	
	
	public class CurrentGamesRequest : PlayFabModelBase
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
		/// server state to match against (running, ended, waiting for players etc.)
		/// </summary>
		
		public string IncludeState { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			IncludeState = (string)JsonUtil.Get<string>(json, "IncludeState");
		}
	}
	
	
	
	public class CurrentGamesResult : PlayFabModelBase
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
		
		/// <summary>
		/// indicates there are servers for which there was no response
		/// </summary>
		
		public bool? IncompleteResult { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Games = JsonUtil.GetObjectList<GameInfo>(json, "Games");
			PlayerCount = (int)JsonUtil.Get<double?>(json, "PlayerCount");
			GameCount = (int)JsonUtil.Get<double?>(json, "GameCount");
			IncompleteResult = (bool?)JsonUtil.Get<bool?>(json, "IncompleteResult");
		}
	}
	
	
	
	public class FriendInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this friend
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab unique username for this friend
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific display name for this friend
		/// </summary>
		
		public string TitleDisplayName { get; set;}
		
		/// <summary>
		/// tags which have been associated with this friend
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// unique lobby identifier of the Game Server Instance to which this player is currently connected
		/// </summary>
		
		public string CurrentMatchmakerLobbyId { get; set;}
		
		/// <summary>
		/// available Facebook information (if the user and PlayFab friend are also connected in Facebook)
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// available Steam information (if the user and PlayFab friend are also connected in Steam)
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// available Game Center information (if the user and PlayFab friend are also connected in Game Center)
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleDisplayName = (string)JsonUtil.Get<string>(json, "TitleDisplayName");
			Tags = JsonUtil.GetList<string>(json, "Tags");
			CurrentMatchmakerLobbyId = (string)JsonUtil.Get<string>(json, "CurrentMatchmakerLobbyId");
			FacebookInfo = JsonUtil.GetObject<UserFacebookInfo>(json, "FacebookInfo");
			SteamInfo = JsonUtil.GetObject<UserSteamInfo>(json, "SteamInfo");
			GameCenterInfo = JsonUtil.GetObject<UserGameCenterInfo>(json, "GameCenterInfo");
		}
	}
	
	
	
	public class GameInfo : PlayFabModelBase
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
		/// maximum players this server can support
		/// </summary>
		
		public int MaxPlayers { get; set;}
		
		/// <summary>
		/// array of strings of current player names on this server (note that these are PlayFab usernames, as opposed to title display names)
		/// </summary>
		
		public List<string> PlayerUsernames { get; set;}
		
		/// <summary>
		/// duration in seconds this server has been running
		/// </summary>
		
		public uint RunTime { get; set;}
		
		/// <summary>
		/// game specific string denoting server configuration
		/// </summary>
		
		public string GameServerState { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			MaxPlayers = (int)JsonUtil.Get<double?>(json, "MaxPlayers");
			PlayerUsernames = JsonUtil.GetList<string>(json, "PlayerUsernames");
			RunTime = (uint)JsonUtil.Get<double?>(json, "RunTime");
			GameServerState = (string)JsonUtil.Get<string>(json, "GameServerState");
		}
	}
	
	
	
	public class GameServerRegionsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// version of game server for which stats are being requested
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
	
	
	
	public class GameServerRegionsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of regions found matching the request parameters
		/// </summary>
		
		public List<RegionInfo> Regions { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Regions = JsonUtil.GetObjectList<RegionInfo>(json, "Regions");
		}
	}
	
	
	
	public class GetAccountInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the user to load data for. Optional, defaults to yourself if not set.
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class GetAccountInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// account information for the local user
		/// </summary>
		
		public UserAccountInfo AccountInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AccountInfo = JsonUtil.GetObject<UserAccountInfo>(json, "AccountInfo");
		}
	}
	
	
	
	public class GetCatalogItemsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// which catalog is being requested
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class GetCatalogItemsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of inventory objects
		/// </summary>
		
		public List<CatalogItem> Catalog { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Catalog = JsonUtil.GetObjectList<CatalogItem>(json, "Catalog");
		}
	}
	
	
	
	public class GetFriendLeaderboardRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistic used to rank friends for this leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// position in the leaderboard to start this listing (defaults to the first entry)
		/// </summary>
		
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			StartPosition = (int)JsonUtil.Get<double?>(json, "StartPosition");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetFriendsListRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// indicates whether Steam service friends should also be included in the response
		/// </summary>
		
		public bool? IncludeSteamFriends { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			IncludeSteamFriends = (bool?)JsonUtil.Get<bool?>(json, "IncludeSteamFriends");
		}
	}
	
	
	
	public class GetFriendsListResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of friends found
		/// </summary>
		
		public List<FriendInfo> Friends { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Friends = JsonUtil.GetObjectList<FriendInfo>(json, "Friends");
		}
	}
	
	
	
	public class GetLeaderboardAroundCurrentUserRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistic used to rank players for this leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetLeaderboardAroundCurrentUserResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ordered listing of users and their positions in the requested leaderboard
		/// </summary>
		
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Leaderboard = JsonUtil.GetObjectList<PlayerLeaderboardEntry>(json, "Leaderboard");
		}
	}
	
	
	
	public class GetLeaderboardRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistic used to rank players for this leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// position in the leaderboard to start this listing (defaults to the first entry)
		/// </summary>
		
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			StartPosition = (int)JsonUtil.Get<double?>(json, "StartPosition");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetLeaderboardResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ordered listing of users and their positions in the requested leaderboard
		/// </summary>
		
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Leaderboard = JsonUtil.GetObjectList<PlayerLeaderboardEntry>(json, "Leaderboard");
		}
	}
	
	
	
	public class GetSharedGroupDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned)
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		/// <summary>
		/// if true, return the list of all members of the shared group
		/// </summary>
		
		public bool? GetMembers { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			Keys = JsonUtil.GetList<string>(json, "Keys");
			GetMembers = (bool?)JsonUtil.Get<bool?>(json, "GetMembers");
		}
	}
	
	
	
	public class GetSharedGroupDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data for the requested keys
		/// </summary>
		
		public Dictionary<string,SharedGroupDataRecord> Data { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers for the members of this group, if requested
		/// </summary>
		
		public List<string> Members { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetObjectDictionary<SharedGroupDataRecord>(json, "Data");
			Members = JsonUtil.GetList<string>(json, "Members");
		}
	}
	
	
	
	public class GetStoreItemsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unqiue identifier for the store which is being requested
		/// </summary>
		
		public string StoreId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StoreId = (string)JsonUtil.Get<string>(json, "StoreId");
		}
	}
	
	
	
	public class GetStoreItemsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of store items
		/// </summary>
		
		public List<StoreItem> Store { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Store = JsonUtil.GetObjectList<StoreItem>(json, "Store");
		}
	}
	
	
	
	public class GetTitleDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		///  array of keys to get back data from the TitleData data blob, set by the admin tools
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Keys = JsonUtil.GetList<string>(json, "Keys");
		}
	}
	
	
	
	public class GetTitleDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetDictionary<string>(json, "Data");
		}
	}
	
	
	
	public class GetTitleNewsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// limits the results to the last n entries (defaults to 10 if not set)
		/// </summary>
		
		public int? Count { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Count = (int?)JsonUtil.Get<double?>(json, "Count");
		}
	}
	
	
	
	public class GetTitleNewsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of news items
		/// </summary>
		
		public List<TitleNewsItem> News { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			News = JsonUtil.GetObjectList<TitleNewsItem>(json, "News");
		}
	}
	
	
	
	public class GetUserCombinedInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the user to load info about. Defaults to yourself if not set.
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// If set to false, account info will not be returned (defaults to true)
		/// </summary>
		
		public bool? GetAccountInfo { get; set;}
		
		/// <summary>
		/// If set to false, inventory will not be returned (defaults to true). Inventory will never be returned for users other than yourself.
		/// </summary>
		
		public bool? GetInventory { get; set;}
		
		/// <summary>
		/// If set to false, virtual currency balances will not be returned (defaults to true). Currency balances will never be returned for users other than yourself.
		/// </summary>
		
		public bool? GetVirtualCurrency { get; set;}
		
		/// <summary>
		/// If set to false, custom user data will not be returned (defaults to true).
		/// </summary>
		
		public bool? GetUserData { get; set;}
		
		/// <summary>
		/// User custom data keys to return. Leave null to get all keys. For users other than yourself, only public data will be returned.
		/// </summary>
		
		public List<string> UserDataKeys { get; set;}
		
		/// <summary>
		/// If set to false, read-only user data will not be returned (defaults to true).
		/// </summary>
		
		public bool? GetReadOnlyData { get; set;}
		
		/// <summary>
		/// User read-only custom data keys to return. Leave null to get all keys. For users other than yourself, only public data will be returned.
		/// </summary>
		
		public List<string> ReadOnlyDataKeys { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			GetAccountInfo = (bool?)JsonUtil.Get<bool?>(json, "GetAccountInfo");
			GetInventory = (bool?)JsonUtil.Get<bool?>(json, "GetInventory");
			GetVirtualCurrency = (bool?)JsonUtil.Get<bool?>(json, "GetVirtualCurrency");
			GetUserData = (bool?)JsonUtil.Get<bool?>(json, "GetUserData");
			UserDataKeys = JsonUtil.GetList<string>(json, "UserDataKeys");
			GetReadOnlyData = (bool?)JsonUtil.Get<bool?>(json, "GetReadOnlyData");
			ReadOnlyDataKeys = JsonUtil.GetList<string>(json, "ReadOnlyDataKeys");
		}
	}
	
	
	
	public class GetUserCombinedInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the owner of the combined info
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// account information for the user
		/// </summary>
		
		public UserAccountInfo AccountInfo { get; set;}
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		/// <summary>
		/// user specific custom data
		/// </summary>
		
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		/// <summary>
		/// user specific read-only data
		/// </summary>
		
		public Dictionary<string,UserDataRecord> ReadOnlyData { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			AccountInfo = JsonUtil.GetObject<UserAccountInfo>(json, "AccountInfo");
			Inventory = JsonUtil.GetObjectList<ItemInstance>(json, "Inventory");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
			Data = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "Data");
			ReadOnlyData = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "ReadOnlyData");
		}
	}
	
	
	
	public class GetUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// specific keys to search for in the custom user data. Leave null to get all keys.
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		/// <summary>
		/// PlayFabId of the user to load data for. Optional, defaults to yourself if not set.
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Keys = JsonUtil.GetList<string>(json, "Keys");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class GetUserDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "Data");
		}
	}
	
	
	
	public class GetUserInventoryRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class GetUserInventoryResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Inventory = JsonUtil.GetObjectList<ItemInstance>(json, "Inventory");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
		}
	}
	
	
	
	public class GetUserStatisticsRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class GetUserStatisticsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user statistics for the active title
		/// </summary>
		
		public Dictionary<string,int> UserStatistics { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserStatistics = JsonUtil.GetDictionaryInt32(json, "UserStatistics");
		}
	}
	
	
	
	/// <summary>
	/// A unique instance of an item in a user's inventory
	/// </summary>
	public class ItemInstance : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the inventory item, as defined in the catalog
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item identifier for this specific instance of the item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name for the inventory item, as defined in the catalog
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// timestamp for when this instance was purchased
		/// </summary>
		
		public DateTime? PurchaseDate { get; set;}
		
		/// <summary>
		/// timestamp for when this instance will expire
		/// </summary>
		
		public DateTime? Expiration { get; set;}
		
		/// <summary>
		/// total number of remaining uses, if this is a consumable item
		/// </summary>
		
		public int? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment associated with this instance when it was added to the user inventory
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version for the inventory item, when this instance was created
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container
		/// </summary>
		
		public string BundleParent { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			PurchaseDate = (DateTime?)JsonUtil.GetDateTime(json, "PurchaseDate");
			Expiration = (DateTime?)JsonUtil.GetDateTime(json, "Expiration");
			RemainingUses = (int?)JsonUtil.Get<double?>(json, "RemainingUses");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			BundleParent = (string)JsonUtil.Get<string>(json, "BundleParent");
		}
	}
	
	
	
	public class ItemPuchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ItemId of the item to purchase
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// how many of this item to purchase
		/// </summary>
		
		public uint Quantity { get; set;}
		
		/// <summary>
		/// title-specific text concerning this purchase
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// items to be upgraded as a result of this purchase (upgraded items are hidden, as they are "replaced" by the new items)
		/// </summary>
		
		public List<string> UpgradeFromItems { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			Quantity = (uint)JsonUtil.Get<double?>(json, "Quantity");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			UpgradeFromItems = JsonUtil.GetList<string>(json, "UpgradeFromItems");
		}
	}
	
	
	
	public class LinkFacebookAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
		}
	}
	
	
	
	public class LinkFacebookAccountResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LinkGameCenterAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Game Center identifier for the player account to be linked
		/// </summary>
		
		public string GameCenterId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameCenterId = (string)JsonUtil.Get<string>(json, "GameCenterId");
		}
	}
	
	
	
	public class LinkGameCenterAccountResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LinkSteamAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier from Steam for the user
		/// </summary>
		
		public string SteamTicket { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SteamTicket = (string)JsonUtil.Get<string>(json, "SteamTicket");
		}
	}
	
	
	
	public class LinkSteamAccountResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LogEventRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// A unique event name which will be used as the table name in the Redshift database. The name will be made lower case, and cannot not contain spaces. The use of underscores is recommended, for readability. Events also cannot match reserved terms. The PlayFab reserved terms are 'log_in' and 'purchase', 'create' and 'request', while the Redshift reserved terms can be found here: http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html.
		/// </summary>
		
		public string eventName { get; set;}
		
		/// <summary>
		/// Contains all the data for this event. Event Values can be strings, booleans or numerics (float, double, integer, long) and must be consistent on a per-event basis (if the Value for Key 'A' in Event 'Foo' is an integer the first time it is sent, it must be an integer in all subsequent 'Foo' events). As with event names, Keys must also not use reserved words (see above). Finally, the size of the Body for an event must be less than 32KB (UTF-8 format).
		/// </summary>
		
		public Dictionary<string,object> Body { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			eventName = (string)JsonUtil.Get<string>(json, "eventName");
			Body = JsonUtil.GetDictionary<object>(json, "Body");
		}
	}
	
	
	
	public class LogEventResult : PlayFabModelBase
	{
		public List<string> errors { get; set;}
				
			public override void Deserialize (Dictionary<string,object> json)
		{
			
			errors = JsonUtil.GetList<string>(json, "errors");
		}
	}
	
	
	
	public class LoginResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// a unique token authorizing the user and game at the server level, for the current session
		/// </summary>
		
		public string SessionTicket { get; set;}
		
		/// <summary>
		/// player's unique PlayFabId
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// true if the account was newly created on this login
		/// </summary>
		
		public bool NewlyCreated { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SessionTicket = (string)JsonUtil.Get<string>(json, "SessionTicket");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			NewlyCreated = (bool)JsonUtil.Get<bool?>(json, "NewlyCreated");
		}
	}
	
	
	
	public class LoginWithAndroidDeviceIDRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// Android device identifier for the user's device
		/// </summary>
		
		public string AndroidDeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string AndroidDevice { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AndroidDeviceId = (string)JsonUtil.Get<string>(json, "AndroidDeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			AndroidDevice = (string)JsonUtil.Get<string>(json, "AndroidDevice");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithFacebookRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Facebook account
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithGameCenterRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique Game Center player id
		/// </summary>
		
		public string PlayerId { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Game Center id
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			PlayerId = (string)JsonUtil.Get<string>(json, "PlayerId");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithGoogleAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique token from Google Play for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
		}
	}
	
	
	
	public class LoginWithIOSDeviceIDRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// vendor-specific iOS identifier for the user's device
		/// </summary>
		
		public string DeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string DeviceModel { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			DeviceId = (string)JsonUtil.Get<string>(json, "DeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			DeviceModel = (string)JsonUtil.Get<string>(json, "DeviceModel");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithPlayFabRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// PlayFab username for the account to be signed in (3-24 characters)
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// password for the account to be signed in (6-24 characters)
		/// </summary>
		
		public string Password { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
	
	
	
	public class LoginWithSteamRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique identifier from Steam for the user
		/// </summary>
		
		public string SteamTicket { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Steam account
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			SteamTicket = (string)JsonUtil.Get<string>(json, "SteamTicket");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class MatchmakeRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// build version to match against
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// region to match make against
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// game mode to match make against
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// lobby identifier to match make against (used to select a specific server)
		/// </summary>
		
		public string LobbyId { get; set;}
		
		/// <summary>
		/// [deprecated]
		/// </summary>
		
		public bool? EnableQueue { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			LobbyId = (string)JsonUtil.Get<string>(json, "LobbyId");
			EnableQueue = (bool?)JsonUtil.Get<bool?>(json, "EnableQueue");
		}
	}
	
	
	
	public class MatchmakeResult : PlayFabModelBase
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
		/// port number to use for http communications with the server
		/// </summary>
		
		public int? WebSocketPort { get; set;}
		
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
		
		/// <summary>
		/// [deprecated]
		/// </summary>
		
		public List<string> Queue { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			ServerHostname = (string)JsonUtil.Get<string>(json, "ServerHostname");
			ServerPort = (int?)JsonUtil.Get<double?>(json, "ServerPort");
			WebSocketPort = (int?)JsonUtil.Get<double?>(json, "WebSocketPort");
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			Expires = (string)JsonUtil.Get<string>(json, "Expires");
			PollWaitTimeMS = (int?)JsonUtil.Get<double?>(json, "PollWaitTimeMS");
			Status = (MatchmakeStatus?)JsonUtil.GetEnum<MatchmakeStatus>(json, "Status");
			Queue = JsonUtil.GetList<string>(json, "Queue");
		}
	}
	
	
	
	public enum MatchmakeStatus
	{
		Complete,
		Waiting,
		GameNotFound
	}
	
	
	
	public class ModifyUserVirtualCurrencyResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the virtual currency which was modified
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// balance of the virtual currency after modification
		/// </summary>
		
		public int Balance { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Balance = (int)JsonUtil.Get<double?>(json, "Balance");
		}
	}
	
	
	
	public class PayForPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// payment provider to use to fund the purchase
		/// </summary>
		
		public string ProviderName { get; set;}
		
		/// <summary>
		/// currency to use to fund the purchase
		/// </summary>
		
		public string Currency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			ProviderName = (string)JsonUtil.Get<string>(json, "ProviderName");
			Currency = (string)JsonUtil.Get<string>(json, "Currency");
		}
	}
	
	
	
	public class PayForPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// status of the transaction
		/// </summary>
		
		public TransactionStatus? Status { get; set;}
		
		/// <summary>
		/// virtual currency cost of the transaction
		/// </summary>
		
		public Dictionary<string,int> VCAmount { get; set;}
		
		/// <summary>
		/// real world currency for the transaction
		/// </summary>
		
		public string PurchaseCurrency { get; set;}
		
		/// <summary>
		/// real world cost of the transaction
		/// </summary>
		
		public uint PurchasePrice { get; set;}
		
		/// <summary>
		/// local credit applied to the transaction (provider specific)
		/// </summary>
		
		public uint CreditApplied { get; set;}
		
		/// <summary>
		/// provider used for the transaction
		/// </summary>
		
		public string ProviderData { get; set;}
		
		/// <summary>
		/// url to the purchase provider page that details the purchase
		/// </summary>
		
		public string PurchaseConfirmationPageURL { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			Status = (TransactionStatus?)JsonUtil.GetEnum<TransactionStatus>(json, "Status");
			VCAmount = JsonUtil.GetDictionaryInt32(json, "VCAmount");
			PurchaseCurrency = (string)JsonUtil.Get<string>(json, "PurchaseCurrency");
			PurchasePrice = (uint)JsonUtil.Get<double?>(json, "PurchasePrice");
			CreditApplied = (uint)JsonUtil.Get<double?>(json, "CreditApplied");
			ProviderData = (string)JsonUtil.Get<string>(json, "ProviderData");
			PurchaseConfirmationPageURL = (string)JsonUtil.Get<string>(json, "PurchaseConfirmationPageURL");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
		}
	}
	
	
	
	public class PaymentOption : PlayFabModelBase
	{
		
		
		/// <summary>
		/// specific currency to use to fund the purchase
		/// </summary>
		
		public string Currency { get; set;}
		
		/// <summary>
		/// name of the purchase provider for this option
		/// </summary>
		
		public string ProviderName { get; set;}
		
		/// <summary>
		/// amount of the specified currency needed for the purchase
		/// </summary>
		
		public uint Price { get; set;}
		
		/// <summary>
		/// amount of existing credit the user has with the provider
		/// </summary>
		
		public uint StoreCredit { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Currency = (string)JsonUtil.Get<string>(json, "Currency");
			ProviderName = (string)JsonUtil.Get<string>(json, "ProviderName");
			Price = (uint)JsonUtil.Get<double?>(json, "Price");
			StoreCredit = (uint)JsonUtil.Get<double?>(json, "StoreCredit");
		}
	}
	
	
	
	public class PlayerLeaderboardEntry : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user for this leaderboard entry
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// title-specific display name of the user for this leaderboard entry
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// specific value of the user's statistic
		/// </summary>
		
		public int StatValue { get; set;}
		
		/// <summary>
		/// user's overall position in the leaderboard
		/// </summary>
		
		public int Position { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			StatValue = (int)JsonUtil.Get<double?>(json, "StatValue");
			Position = (int)JsonUtil.Get<double?>(json, "Position");
		}
	}
	
	
	
	public class PurchasedItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique instance identifier for this catalog item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// unique identifier for the catalog item
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// catalog version for the item purchased
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// display name for the catalog item
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// currency type for the cost of the catalog item
		/// </summary>
		
		public string UnitCurrency { get; set;}
		
		/// <summary>
		/// cost of the catalog item in the given currency
		/// </summary>
		
		public uint UnitPrice { get; set;}
		
		/// <summary>
		/// array of unique items that were awarded when this catalog item was purchased
		/// </summary>
		
		public List<string> BundleContents { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			UnitCurrency = (string)JsonUtil.Get<string>(json, "UnitCurrency");
			UnitPrice = (uint)JsonUtil.Get<double?>(json, "UnitPrice");
			BundleContents = JsonUtil.GetList<string>(json, "BundleContents");
		}
	}
	
	
	
	public class PurchaseItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ItemId of the item to purchase
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// virtual currency to use to purchase the item
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// price the client expects to pay for the item (in case a new catalog or store was uploaded, with new prices)
		/// </summary>
		
		public int Price { get; set;}
		
		/// <summary>
		/// catalog version for the items to be purchased (defaults to most recent version
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// store to buy this item through. If not set, prices default to those in the catalog.
		/// </summary>
		
		public string StoreId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Price = (int)JsonUtil.Get<double?>(json, "Price");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			StoreId = (string)JsonUtil.Get<string>(json, "StoreId");
		}
	}
	
	
	
	public class PurchaseItemResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// details for the items purchased
		/// </summary>
		
		public List<PurchasedItem> Items { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Items = JsonUtil.GetObjectList<PurchasedItem>(json, "Items");
		}
	}
	
	
	
	public class RedeemCouponRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// generated coupon code to redeem
		/// </summary>
		
		public string CouponCode { get; set;}
		
		/// <summary>
		/// catalog version of the coupon
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CouponCode = (string)JsonUtil.Get<string>(json, "CouponCode");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class RedeemCouponResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// items granted to the player as a result of redeeming the coupon
		/// </summary>
		
		public List<ItemInstance> GrantedItems { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GrantedItems = JsonUtil.GetObjectList<ItemInstance>(json, "GrantedItems");
		}
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
	
	
	
	public class RegionInfo : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			Name = (string)JsonUtil.Get<string>(json, "Name");
			Available = (bool)JsonUtil.Get<bool?>(json, "Available");
			PingUrl = (string)JsonUtil.Get<string>(json, "PingUrl");
		}
	}
	
	
	
	public class RegisterForIOSPushNotificationRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique token generated by the Apple Push Notification service when the title registered to receive push notifications
		/// </summary>
		
		public string DeviceToken { get; set;}
		
		/// <summary>
		/// If true, send a test push message immediately after sucessful registration. Defaults to false.
		/// </summary>
		
		public bool? SendPushNotificationConfirmation { get; set;}
		
		/// <summary>
		/// Message to display when confirming push notification.
		/// </summary>
		
		public string ConfirmationMessege { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DeviceToken = (string)JsonUtil.Get<string>(json, "DeviceToken");
			SendPushNotificationConfirmation = (bool?)JsonUtil.Get<bool?>(json, "SendPushNotificationConfirmation");
			ConfirmationMessege = (string)JsonUtil.Get<string>(json, "ConfirmationMessege");
		}
	}
	
	
	
	public class RegisterForIOSPushNotificationResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class RegisterPlayFabUserRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// PlayFab username for the account to be signed in (3-24 characters)
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// user email address, used for account password recovery
		/// </summary>
		
		public string Email { get; set;}
		
		/// <summary>
		/// password for the account to be signed in (6-24 characters)
		/// </summary>
		
		public string Password { get; set;}
		
		/// <summary>
		/// optional string indicating where this user came from (iOS iPhone, Android, etc.)
		/// </summary>
		
		public string Origination { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Email = (string)JsonUtil.Get<string>(json, "Email");
			Password = (string)JsonUtil.Get<string>(json, "Password");
			Origination = (string)JsonUtil.Get<string>(json, "Origination");
		}
	}
	
	
	
	public class RegisterPlayFabUserResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this newly created account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// a unique token identifying the user and game at the server level, for the current session
		/// </summary>
		
		public string SessionTicket { get; set;}
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		
		public string Username { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			SessionTicket = (string)JsonUtil.Get<string>(json, "SessionTicket");
			Username = (string)JsonUtil.Get<string>(json, "Username");
		}
	}
	
	
	
	public class RemoveFriendRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account which is to be removed
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
		}
	}
	
	
	
	public class RemoveFriendResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class RemoveSharedGroupMembersRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to remove from the shared group
		/// </summary>
		
		public List<string> PlayFabIds { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			PlayFabIds = JsonUtil.GetList<string>(json, "PlayFabIds");
		}
	}
	
	
	
	public class RemoveSharedGroupMembersResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SendAccountRecoveryEmailRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user email address, used for account password recovery
		/// </summary>
		
		public string Email { get; set;}
		
		/// <summary>
		/// unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
	
	
	
	public class SendAccountRecoveryEmailResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SetFriendTagsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account to which the tag(s) should be applied
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// array of tags to set on the friend account
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			Tags = JsonUtil.GetList<string>(json, "Tags");
		}
	}
	
	
	
	public class SetFriendTagsResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SharedGroupDataRecord : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data stored for the specified group data key
		/// </summary>
		
		public string Value { get; set;}
		
		/// <summary>
		/// PlayFabId of the user to last update this value
		/// </summary>
		
		public string LastUpdatedBy { get; set;}
		
		/// <summary>
		/// timestamp for when this data was last updated
		/// </summary>
		
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// indicates whether this data can be read by all users (public) or only members of the group (private)
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Value = (string)JsonUtil.Get<string>(json, "Value");
			LastUpdatedBy = (string)JsonUtil.Get<string>(json, "LastUpdatedBy");
			LastUpdated = (DateTime)JsonUtil.GetDateTime(json, "LastUpdated");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class StartGameRequest : PlayFabModelBase
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
		/// informs the service that a password is associated with this server
		/// </summary>
		
		public bool PasswordRestricted { get; set;}
		
		/// <summary>
		/// custom command line argument when starting game server process
		/// </summary>
		
		public string CustomCommandLineData { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			PasswordRestricted = (bool)JsonUtil.Get<bool?>(json, "PasswordRestricted");
			CustomCommandLineData = (string)JsonUtil.Get<string>(json, "CustomCommandLineData");
		}
	}
	
	
	
	public class StartGameResult : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			ServerHostname = (string)JsonUtil.Get<string>(json, "ServerHostname");
			ServerPort = (int?)JsonUtil.Get<double?>(json, "ServerPort");
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			Expires = (string)JsonUtil.Get<string>(json, "Expires");
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
	
	
	
	public class StartPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// catalog version for the items to be purchased. Defaults to most recent catalog.
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// store through which to purchase items. If not set, prices will be pulled from the catalog itself.
		/// </summary>
		
		public string StoreId { get; set;}
		
		/// <summary>
		/// the set of items to purchase
		/// </summary>
		
		public List<ItemPuchaseRequest> Items { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			StoreId = (string)JsonUtil.Get<string>(json, "StoreId");
			Items = JsonUtil.GetObjectList<ItemPuchaseRequest>(json, "Items");
		}
	}
	
	
	
	public class StartPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// cart items to be purchased
		/// </summary>
		
		public List<CartItem> Contents { get; set;}
		
		/// <summary>
		/// available methods by which the user can pay
		/// </summary>
		
		public List<PaymentOption> PaymentOptions { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrencyBalances { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			Contents = JsonUtil.GetObjectList<CartItem>(json, "Contents");
			PaymentOptions = JsonUtil.GetObjectList<PaymentOption>(json, "PaymentOptions");
			VirtualCurrencyBalances = JsonUtil.GetDictionaryInt32(json, "VirtualCurrencyBalances");
		}
	}
	
	
	
	/// <summary>
	/// A store entry that list a catalog item at a particular price
	/// </summary>
	public class StoreItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the catalog
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// catalog version for this item
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// override prices for this item for specific currencies
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			VirtualCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyPrices");
			RealCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "RealCurrencyPrices");
		}
	}
	
	
	
	public class SubtractUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the virtual currency which is to be decremented
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be subtracted from the user balance of the specified virtual currency
		/// </summary>
		
		public int Amount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Amount = (int)JsonUtil.Get<double?>(json, "Amount");
		}
	}
	
	
	
	public enum TitleActivationStatus
	{
		None,
		ActivatedTitleKey,
		PendingSteam,
		ActivatedSteam,
		RevokedSteam
	}
	
	
	
	public class TitleNewsItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// date and time when the news items was posted
		/// </summary>
		
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// unique id of this bit of news
		/// </summary>
		
		public string NewsId { get; set;}
		
		/// <summary>
		/// title of the news item
		/// </summary>
		
		public string Title { get; set;}
		
		/// <summary>
		/// news item text
		/// </summary>
		
		public string Body { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Timestamp = (DateTime)JsonUtil.GetDateTime(json, "Timestamp");
			NewsId = (string)JsonUtil.Get<string>(json, "NewsId");
			Title = (string)JsonUtil.Get<string>(json, "Title");
			Body = (string)JsonUtil.Get<string>(json, "Body");
		}
	}
	
	
	
	public enum TransactionStatus
	{
		CreateCart,
		Init,
		Approved,
		Succeeded,
		FailedByProvider,
		RefundPending,
		Refunded,
		RefundFailed,
		ChargedBack,
		FailedByUber,
		Revoked,
		TradePending,
		Upgraded,
		Other,
		Failed
	}
	
	
	
	public class UnlinkFacebookAccountRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkFacebookAccountResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkGameCenterAccountRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkGameCenterAccountResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkSteamAccountRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkSteamAccountResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlockContainerItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the container to attempt to unlock
		/// </summary>
		
		public string ContainerItemId { get; set;}
		
		/// <summary>
		/// catalog version of the container
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ContainerItemId = (string)JsonUtil.Get<string>(json, "ContainerItemId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class UnlockContainerItemResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique instance identifier of the container unlocked
		/// </summary>
		
		public string UnlockedItemInstanceId { get; set;}
		
		/// <summary>
		/// unique instance identifier of the key used to unlock the container, if applicable
		/// </summary>
		
		public string UnlockedWithItemInstanceId { get; set;}
		
		/// <summary>
		/// items granted to the player as a result of unlocking the container
		/// </summary>
		
		public List<ItemInstance> GrantedItems { get; set;}
		
		/// <summary>
		/// virtual currency granted to the player as a result of unlocking the container
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UnlockedItemInstanceId = (string)JsonUtil.Get<string>(json, "UnlockedItemInstanceId");
			UnlockedWithItemInstanceId = (string)JsonUtil.Get<string>(json, "UnlockedWithItemInstanceId");
			GrantedItems = JsonUtil.GetObjectList<ItemInstance>(json, "GrantedItems");
			VirtualCurrency = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrency");
		}
	}
	
	
	
	public class UpdateEmailAddressRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user email address, used for account password recovery
		/// </summary>
		
		public string Email { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
		}
	}
	
	
	
	public class UpdateEmailAddressResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdatePasswordRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// password for the account to be signed in (6-24 characters)
		/// </summary>
		
		public string Password { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
	
	
	
	public class UpdatePasswordResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateSharedGroupDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// key value pairs to be stored in the shared group - note that keys will be trimmed of whitespace, must not begin with a '!' character, and that null values will result in the removal of the key from the data set
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// permission to be applied to all user data keys in this request
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			Data = JsonUtil.GetDictionary<string>(json, "Data");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UpdateSharedGroupDataResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data to be written to the user's custom data. A key with a null value will be removed, rather than being set to null.
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetDictionary<string>(json, "Data");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UpdateUserDataResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserStatisticsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistics to be updated with the provided values
		/// </summary>
		
		public Dictionary<string,int> UserStatistics { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserStatistics = JsonUtil.GetDictionaryInt32(json, "UserStatistics");
		}
	}
	
	
	
	public class UpdateUserStatisticsResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserTitleDisplayNameRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// new title display name for the user - must be between 3 and 25 characters
		/// </summary>
		
		public string DisplayName { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
		}
	}
	
	
	
	public class UpdateUserTitleDisplayNameResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// current title display name for the user (this will be the original display name if the rename attempt failed)
		/// </summary>
		
		public string DisplayName { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
		}
	}
	
	
	
	public class UserAccountInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the user account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user account was created
		/// </summary>
		
		public DateTime Created { get; set;}
		
		/// <summary>
		/// user account name in the PlayFab service
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific information for the user account
		/// </summary>
		
		public UserTitleInfo TitleInfo { get; set;}
		
		/// <summary>
		/// personal information for the user which is considered more sensitive
		/// </summary>
		
		public UserPrivateAccountInfo PrivateInfo { get; set;}
		
		/// <summary>
		/// user Facebook information, if a Facebook account has been linked
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// user Steam information, if a Steam account has been linked
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// user Gamecenter information, if a Gamecenter account has been linked
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Created = (DateTime)JsonUtil.GetDateTime(json, "Created");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleInfo = JsonUtil.GetObject<UserTitleInfo>(json, "TitleInfo");
			PrivateInfo = JsonUtil.GetObject<UserPrivateAccountInfo>(json, "PrivateInfo");
			FacebookInfo = JsonUtil.GetObject<UserFacebookInfo>(json, "FacebookInfo");
			SteamInfo = JsonUtil.GetObject<UserSteamInfo>(json, "SteamInfo");
			GameCenterInfo = JsonUtil.GetObject<UserGameCenterInfo>(json, "GameCenterInfo");
		}
	}
	
	
	
	public enum UserDataPermission
	{
		Private,
		Public
	}
	
	
	
	public class UserDataRecord : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data stored for the specified user data key
		/// </summary>
		
		public string Value { get; set;}
		
		/// <summary>
		/// timestamp for when this data was last updated
		/// </summary>
		
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// indicates whether this data can be read by all users (public) or only the user (private)
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Value = (string)JsonUtil.Get<string>(json, "Value");
			LastUpdated = (DateTime)JsonUtil.GetDateTime(json, "LastUpdated");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UserFacebookInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Facebook identifier
		/// </summary>
		
		public string FacebookId { get; set;}
		
		/// <summary>
		/// Facebook username
		/// </summary>
		
		public string FacebookUsername { get; set;}
		
		/// <summary>
		/// Facebook display name
		/// </summary>
		
		public string FacebookDisplayname { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FacebookId = (string)JsonUtil.Get<string>(json, "FacebookId");
			FacebookUsername = (string)JsonUtil.Get<string>(json, "FacebookUsername");
			FacebookDisplayname = (string)JsonUtil.Get<string>(json, "FacebookDisplayname");
		}
	}
	
	
	
	public class UserGameCenterInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Gamecenter identifier
		/// </summary>
		
		public string GameCenterId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameCenterId = (string)JsonUtil.Get<string>(json, "GameCenterId");
		}
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
		GameCenter
	}
	
	
	
	public class UserPrivateAccountInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user email address
		/// </summary>
		
		public string Email { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
		}
	}
	
	
	
	public class UserSteamInfo : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SteamId = (string)JsonUtil.Get<string>(json, "SteamId");
			SteamCountry = (string)JsonUtil.Get<string>(json, "SteamCountry");
			SteamCurrency = (Currency?)JsonUtil.GetEnum<Currency>(json, "SteamCurrency");
			SteamActivationStatus = (TitleActivationStatus?)JsonUtil.GetEnum<TitleActivationStatus>(json, "SteamActivationStatus");
		}
	}
	
	
	
	public class UserTitleInfo : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Origination = (UserOrigination?)JsonUtil.GetEnum<UserOrigination>(json, "Origination");
			Created = (DateTime)JsonUtil.GetDateTime(json, "Created");
			LastLogin = (DateTime?)JsonUtil.GetDateTime(json, "LastLogin");
			FirstLogin = (DateTime?)JsonUtil.GetDateTime(json, "FirstLogin");
			isBanned = (bool?)JsonUtil.Get<bool?>(json, "isBanned");
		}
	}
	
	
	
	public class ValidateGooglePlayPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// The original json string returned by the Google Play IAB api
		/// </summary>
		
		public string ReceiptJson { get; set;}
		
		/// <summary>
		/// The signature returned by the Google Play IAB api
		/// </summary>
		
		public string Signature { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ReceiptJson = (string)JsonUtil.Get<string>(json, "ReceiptJson");
			Signature = (string)JsonUtil.Get<string>(json, "Signature");
		}
	}
	
	
	
	public class ValidateGooglePlayPurchaseResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ValidateIOSReceiptRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// base64 encoded receipt data, passed back by the App Store as a result of a successful purchase
		/// </summary>
		
		public string ReceiptData { get; set;}
		
		/// <summary>
		/// currency used for the purchase
		/// </summary>
		
		public string CurrencyCode { get; set;}
		
		/// <summary>
		/// amount of the stated currency paid for the object
		/// </summary>
		
		public int PurchasePrice { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ReceiptData = (string)JsonUtil.Get<string>(json, "ReceiptData");
			CurrencyCode = (string)JsonUtil.Get<string>(json, "CurrencyCode");
			PurchasePrice = (int)JsonUtil.Get<double?>(json, "PurchasePrice");
		}
	}
	
	
	
	public class ValidateIOSReceiptResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
}
