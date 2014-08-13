using System;
using System.Collections.Generic;
using PlayFab.Internal;

namespace PlayFab.AdminModels
{
	
	
	
	public class AddNewsRequest : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			Title = (string)JsonUtil.Get<string>(json, "Title");
			Body = (string)JsonUtil.Get<string>(json, "Body");
		}
	}
	
	
	
	public class AddNewsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Unique id of the new news item
		/// </summary>
		
		public string NewsId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			NewsId = (string)JsonUtil.Get<string>(json, "NewsId");
		}
	}
	
	
	
	public class AddServerBuildRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the build executable
		/// </summary>
		
		public string BuildId { get; set;}
		
		/// <summary>
		/// date and time to apply (stamp) to this build (usually current time/date)
		/// </summary>
		
		public DateTime? Timestamp { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		
		public bool Active { get; set;}
		
		/// <summary>
		/// is this build intended to run on dedicated ("bare metal") servers
		/// </summary>
		
		public bool DedicatedServerEligible { get; set;}
		
		/// <summary>
		/// Server host regions in which this build can be used
		/// </summary>
		
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		
		public string Comment { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			Active = (bool)JsonUtil.Get<bool?>(json, "Active");
			DedicatedServerEligible = (bool)JsonUtil.Get<bool?>(json, "DedicatedServerEligible");
			ActiveRegions = JsonUtil.GetList<string>(json, "ActiveRegions");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
		}
	}
	
	
	
	public class AddServerBuildResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for this build executable
		/// </summary>
		
		public string BuildId { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		
		public bool Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// the unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
			Active = (bool)JsonUtil.Get<bool?>(json, "Active");
			ActiveRegions = JsonUtil.GetList<string>(json, "ActiveRegions");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
			Timestamp = (DateTime)JsonUtil.GetDateTime(json, "Timestamp");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
	
	
	
	public class AddUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be incremented
		/// </summary>
		
		public string PlayFabId { get; set;}
		
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
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Amount = (int)JsonUtil.Get<double?>(json, "Amount");
		}
	}
	
	
	
	public class AddVirtualCurrencyTypesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// List of virtual currency names to add as valid virtual currencies for this title
		/// </summary>
		
		public List<string> VirtualCurrencyIds { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrencyIds = JsonUtil.GetList<string>(json, "VirtualCurrencyIds");
		}
	}
	
	
	
	public class BlankResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
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
		/// defines the container properties for the item - containers are items which include contain other items, including random drop tables and virtual currencies, and which require a "key" item to open
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
		
		public uint UsageCount { get; set;}
		
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
			
			UsageCount = (uint)JsonUtil.Get<double?>(json, "UsageCount");
			UsagePeriod = (uint?)JsonUtil.Get<double?>(json, "UsagePeriod");
			UsagePeriodGroup = (string)JsonUtil.Get<string>(json, "UsagePeriodGroup");
		}
	}
	
	
	
	public class CatalogItemContainerInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ItemId which is required to unlock the container (items in the container will not be added to the player inventory until it is unlocked)
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
	
	
	
	public class GameModeInfo : PlayFabModelBase
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
		/// performance cost of a Game Server Instance on a given server TODO what are the values expected?
		/// </summary>
		
		public float PerfCostPerGame { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Gamemode = (string)JsonUtil.Get<string>(json, "Gamemode");
			MinPlayerCount = (uint)JsonUtil.Get<double?>(json, "MinPlayerCount");
			MaxPlayerCount = (uint)JsonUtil.Get<double?>(json, "MaxPlayerCount");
			PerfCostPerGame = (float)JsonUtil.Get<double?>(json, "PerfCostPerGame");
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
		/// array of items which can be purchased
		/// </summary>
		
		public List<CatalogItem> Catalog { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Catalog = JsonUtil.GetObjectList<CatalogItem>(json, "Catalog");
		}
	}
	
	
	
	public class GetMatchmakerGameInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the lobby for which info is being requested
		/// </summary>
		
		public string LobbyId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyId = (string)JsonUtil.Get<string>(json, "LobbyId");
		}
	}
	
	
	
	public class GetMatchmakerGameInfoResult : PlayFabModelBase
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
		
		/// <summary>
		/// output log from this Game Server Instance
		/// </summary>
		
		public string StdOutLog { get; set;}
		
		/// <summary>
		/// error log from this Game Server Instance
		/// </summary>
		
		public string StdErrLog { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyId = (string)JsonUtil.Get<string>(json, "LobbyId");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			StartTime = (DateTime)JsonUtil.GetDateTime(json, "StartTime");
			EndTime = (DateTime?)JsonUtil.GetDateTime(json, "EndTime");
			Mode = (string)JsonUtil.Get<string>(json, "Mode");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			Players = JsonUtil.GetList<string>(json, "Players");
			ServerAddress = (string)JsonUtil.Get<string>(json, "ServerAddress");
			ServerPort = (uint)JsonUtil.Get<double?>(json, "ServerPort");
			StdOutLog = (string)JsonUtil.Get<string>(json, "StdOutLog");
			StdErrLog = (string)JsonUtil.Get<string>(json, "StdErrLog");
		}
	}
	
	
	
	public class GetMatchmakerGameModesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// previously uploaded build version for which game modes are being requested
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
		}
	}
	
	
	
	public class GetMatchmakerGameModesResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of game modes available for the specified build
		/// </summary>
		
		public List<GameModeInfo> GameModes { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameModes = JsonUtil.GetObjectList<GameModeInfo>(json, "GameModes");
		}
	}
	
	
	
	public class GetRandomResultTablesRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class GetRandomResultTablesResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of random result tables currently available
		/// </summary>
		
		public Dictionary<string,RandomResultTable> Tables { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Tables = JsonUtil.GetObjectDictionary<RandomResultTable>(json, "Tables");
		}
	}
	
	
	
	public class GetServerBuildInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable for which information is being requested
		/// </summary>
		
		public string BuildId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
		}
	}
	
	
	
	/// <summary>
	/// Information about particular server build
	/// </summary>
	public class GetServerBuildInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for this build executable
		/// </summary>
		
		public string BuildId { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		
		public bool Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// the unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
			Active = (bool)JsonUtil.Get<bool?>(json, "Active");
			ActiveRegions = JsonUtil.GetList<string>(json, "ActiveRegions");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
			Timestamp = (DateTime)JsonUtil.GetDateTime(json, "Timestamp");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
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
	
	
	
	public class GetUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// specific keys to search for in the custom user data
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Keys = JsonUtil.GetList<string>(json, "Keys");
		}
	}
	
	
	
	public class GetUserDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being returned
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Data = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "Data");
		}
	}
	
	
	
	public class GetUserInventoryRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose inventory is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// used to limit results to only those from a specific catalog version
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class GetUserInventoryResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of inventory items belonging to the user
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
	
	
	
	public class GrantItemsToUsersRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// catalog version from which items are to be granted
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of items to grant and the users to whom the items are to be granted
		/// </summary>
		
		public List<ItemGrant> ItemGrants { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			ItemGrants = JsonUtil.GetObjectList<ItemGrant>(json, "ItemGrants");
		}
	}
	
	
	
	public class GrantItemsToUsersResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of items granted to users
		/// </summary>
		
		public List<ItemGrantResult> ItemGrantResults { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemGrantResults = JsonUtil.GetObjectList<ItemGrantResult>(json, "ItemGrantResults");
		}
	}
	
	
	
	public class ItemGrant : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		
		public string Annotation { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
		}
	}
	
	
	
	/// <summary>
	/// Result of granting an item to a user
	/// </summary>
	public class ItemGrantResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique instance Id of the granted item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// result of this operation
		/// </summary>
		
		public bool Result { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			Result = (bool)JsonUtil.Get<bool?>(json, "Result");
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
		
		public string PurchaseDate { get; set;}
		
		/// <summary>
		/// timestamp for when this instance will expire
		/// </summary>
		
		public string Expiration { get; set;}
		
		/// <summary>
		/// total number of remaining uses, if this is a consumable item
		/// </summary>
		
		public uint? RemainingUses { get; set;}
		
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
			PurchaseDate = (string)JsonUtil.Get<string>(json, "PurchaseDate");
			Expiration = (string)JsonUtil.Get<string>(json, "Expiration");
			RemainingUses = (uint?)JsonUtil.Get<double?>(json, "RemainingUses");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			BundleParent = (string)JsonUtil.Get<string>(json, "BundleParent");
		}
	}
	
	
	
	public class ListBuildsRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ListBuildsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of uploaded builds
		/// </summary>
		
		public List<GetServerBuildInfoResult> Builds { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Builds = JsonUtil.GetObjectList<GetServerBuildInfoResult>(json, "Builds");
		}
	}
	
	
	
	public class ListVirtualCurrencyTypesRequest : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ListVirtualCurrencyTypesResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// List of virtual currency names defined for this title
		/// </summary>
		
		public List<string> VirtualCurrencyIds { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrencyIds = JsonUtil.GetList<string>(json, "VirtualCurrencyIds");
		}
	}
	
	
	
	public class LookupUserAccountInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier to match against existing user accounts
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// email address to match against existing user accounts
		/// </summary>
		
		public string Email { get; set;}
		
		/// <summary>
		/// PlayFab username to match against existing user accounts
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific username to match against existing user accounts
		/// </summary>
		
		public string TitleDisplayName { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Email = (string)JsonUtil.Get<string>(json, "Email");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleDisplayName = (string)JsonUtil.Get<string>(json, "TitleDisplayName");
		}
	}
	
	
	
	public class LookupUserAccountInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user info for the user matching the request
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserInfo = JsonUtil.GetObject<UserAccountInfo>(json, "UserInfo");
		}
	}
	
	
	
	public class ModifyMatchmakerGameModesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// previously uploaded build version for which game modes are being specified
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// array of game modes (Note: this will replace all game modes for the indicated build version)
		/// </summary>
		
		public List<GameModeInfo> GameModes { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			GameModes = JsonUtil.GetObjectList<GameModeInfo>(json, "GameModes");
		}
	}
	
	
	
	public class ModifyMatchmakerGameModesResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ModifyServerBuildRequest : PlayFabModelBase
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
		/// is this build currently allowed to be used
		/// </summary>
		
		public bool? Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		
		public string Comment { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			Active = (bool?)JsonUtil.Get<bool?>(json, "Active");
			ActiveRegions = JsonUtil.GetList<string>(json, "ActiveRegions");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
		}
	}
	
	
	
	public class ModifyServerBuildResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for this build executable
		/// </summary>
		
		public string BuildId { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		
		public bool Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// the unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
			Active = (bool)JsonUtil.Get<bool?>(json, "Active");
			ActiveRegions = JsonUtil.GetList<string>(json, "ActiveRegions");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
			Timestamp = (DateTime)JsonUtil.GetDateTime(json, "Timestamp");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
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
	
	
	
	public class RandomResultTable : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Unique name for this drop table
		/// </summary>
		
		public string TableId { get; set;}
		
		/// <summary>
		/// Child nodes that indicate what kind of drop table item this actually is.
		/// </summary>
		
		public List<ResultTableNode> Nodes { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TableId = (string)JsonUtil.Get<string>(json, "TableId");
			Nodes = JsonUtil.GetObjectList<ResultTableNode>(json, "Nodes");
		}
	}
	
	
	
	public enum Region
	{
		USWest,
		USCentral,
		USEast,
		EUWest,
		APSouthEast,
		APNorthEast,
		SAEast,
		Australia,
		China,
		UberLan
	}
	
	
	
	public class RemoveServerBuildRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable to be removed
		/// </summary>
		
		public string BuildId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
		}
	}
	
	
	
	public class RemoveServerBuildResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable to be removed
		/// </summary>
		
		public string BuildId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
		}
	}
	
	
	
	public class RemoveTitleDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// key we want to remove
		/// </summary>
		
		public string Key { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Key = (string)JsonUtil.Get<string>(json, "Key");
		}
	}
	
	
	
	public class RemoveTitleDataResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ResetUserStatisticsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose statistics are to be reset
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class ResetUserStatisticsResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ResultTableNode : PlayFabModelBase
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ResultItemType = (ResultTableNodeType)JsonUtil.GetEnum<ResultTableNodeType>(json, "ResultItemType");
			ResultItem = (string)JsonUtil.Get<string>(json, "ResultItem");
			Weight = (int)JsonUtil.Get<double?>(json, "Weight");
		}
	}
	
	
	
	public enum ResultTableNodeType
	{
		ItemId,
		TableId
	}
	
	
	
	public class RevokeInventoryItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique PlayFab identifier for the user account which is to have the specified item removed
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique PlayFab identifier for the item instance to be removed
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
		}
	}
	
	
	
	public class RevokeInventoryResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SendAccountRecoveryEmailRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// email address to match against existing user accounts
		/// </summary>
		
		public string Email { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
		}
	}
	
	
	
	public class SendAccountRecoveryEmailResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SetTitleDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name
		/// </summary>
		
		public string Key { get; set;}
		
		/// <summary>
		/// new value to set
		/// </summary>
		
		public string Value { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Key = (string)JsonUtil.Get<string>(json, "Key");
			Value = (string)JsonUtil.Get<string>(json, "Value");
		}
	}
	
	
	
	public class SetTitleDataResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SubtractUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be decremented
		/// </summary>
		
		public string PlayFabId { get; set;}
		
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
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
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
	
	
	
	public class UpdateCatalogItemsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// which catalog is being updated
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of catalog items to be submitted
		/// </summary>
		
		public List<CatalogItem> CatalogItems { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			CatalogItems = JsonUtil.GetObjectList<CatalogItem>(json, "CatalogItems");
		}
	}
	
	
	
	public class UpdateCatalogItemsResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateRandomResultTablesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that table, while any others will be added to the available set)
		/// </summary>
		
		public List<RandomResultTable> Tables { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Tables = JsonUtil.GetObjectList<RandomResultTable>(json, "Tables");
		}
	}
	
	
	
	public class UpdateRandomResultTablesResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being updated
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// data to be written to the user's custom data
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Data = JsonUtil.GetDictionary<string>(json, "Data");
		}
	}
	
	
	
	public class UpdateUserDataResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserTitleDisplayNameRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose title specific display name is to be changed
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// new title display name for the user - must be between 3 and 25 characters
		/// </summary>
		
		public string DisplayName { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
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
	
	
	
	public class UserDataRecord : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user-supplied data for this user data key
		/// </summary>
		
		public string Value { get; set;}
		
		/// <summary>
		/// timestamp indicating when this data was last updated
		/// </summary>
		
		public DateTime LastUpdated { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Value = (string)JsonUtil.Get<string>(json, "Value");
			LastUpdated = (DateTime)JsonUtil.GetDateTime(json, "LastUpdated");
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
		Android
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
		/// name of the game, as it is displayed in-game
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Origination = (UserOrigination?)JsonUtil.GetEnum<UserOrigination>(json, "Origination");
			Created = (DateTime)JsonUtil.GetDateTime(json, "Created");
			LastLogin = (DateTime?)JsonUtil.GetDateTime(json, "LastLogin");
			FirstLogin = (DateTime?)JsonUtil.GetDateTime(json, "FirstLogin");
		}
	}
	
}
