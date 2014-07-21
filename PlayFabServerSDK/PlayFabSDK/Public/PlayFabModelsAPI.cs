using System;
using System.Collections.Generic;

namespace PlayFab.Model
{

	
	
	
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
		
		public DateTime? Timestamp { get; set;}
		
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
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
	
	
	
	public class CatalogItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// internal item name
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// class name to which item belongs
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// catalog item we are working against
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// displayable item name
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// text description of item
		/// </summary>
		
		public string Description { get; set;}
		
		/// <summary>
		/// Price of this object in virtual currencies
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// Price of this object in real money currencies
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// if this object was dropped, when it was dropped (optional)
		/// </summary>
		
		public DateTime? ReleaseDate { get; set;}
		
		/// <summary>
		/// date this object will no longer be viable (optional)
		/// </summary>
		
		public DateTime? ExpirationDate { get; set;}
		
		/// <summary>
		/// is this a free object?
		/// </summary>
		
		public bool? IsFree { get; set;}
		
		/// <summary>
		/// can we buy this object (might be only gettable by being dropped by a monster)
		/// </summary>
		
		public bool? NotForSale { get; set;}
		
		/// <summary>
		/// can we pass this object to someone else?
		/// </summary>
		
		public bool? NotForTrade { get; set;}
		
		/// <summary>
		/// List of item tags
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// Game specific custom data field (could be json, xml, etc)
		/// </summary>
		
		public string CustomData { get; set;}
		
		/// <summary>
		/// array of unique item Id's that, if the player already has, will automatically place this item in a players inventory
		/// </summary>
		
		public List<string> GrantedIfPlayerHas { get; set;}
		
		/// <summary>
		/// If set, makes this item consumable and sets consumable properties
		/// </summary>
		
		public CatalogItemConsumableInfo Consumable { get; set;}
		
		/// <summary>
		/// If set, makes this item a container and sets container properties
		/// </summary>
		
		public CatalogItemContainerInfo Container { get; set;}
		
		/// <summary>
		/// If set, makes this item a bundle and sets bundle properties
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
		/// array of Unique item id's that this item will grant you once you have this item in your inventory
		/// </summary>
		
		public List<string> BundledItems { get; set;}
		
		/// <summary>
		/// array of result table id's that this item will reference and randomly create items from
		/// </summary>
		
		public List<string> BundledResultTables { get; set;}
		
		/// <summary>
		/// Virtual currencies contained in this item
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
		/// number of times this object can be used
		/// </summary>
		
		public uint UsageCount { get; set;}
		
		/// <summary>
		/// duration of how long this item is viable after player aqquires it (in seconds) (optional)
		/// </summary>
		
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// All items that have the same value in this string get their expiration dates added together.
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
		/// unique item id that, if in posession, the object unlocks and provides the player with content items
		/// </summary>
		
		public string KeyItemId { get; set;}
		
		/// <summary>
		/// array of Unique item id's that this item will grant you once you have opened it
		/// </summary>
		
		public List<string> ItemContents { get; set;}
		
		/// <summary>
		/// array of result table id's that this item will reference and randomly create items from
		/// </summary>
		
		public List<string> ResultTableContents { get; set;}
		
		/// <summary>
		/// Virtual currencies contained in this item
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
		
		public DateTime? StartTime { get; set;}
		
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
			StartTime = (DateTime?)JsonUtil.GetDateTime(json, "StartTime");
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
		
		public DateTime? Timestamp { get; set;}
		
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
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
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
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Inventory = JsonUtil.GetObjectList<ItemInstance>(json, "Inventory");
		}
	}
	
	
	
	public class ItemInstance : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Object name
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item id
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name object belongs to
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// date purchased
		/// </summary>
		
		public string PurchaseDate { get; set;}
		
		/// <summary>
		/// date object will expire (optional)
		/// </summary>
		
		public string Expiration { get; set;}
		
		/// <summary>
		/// number of remaining uses (optional)
		/// </summary>
		
		public uint? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version that this item is part of
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// Unique ID of the parent of where this item may have come from (e.g. if it comes from a crate or coupon)
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
		
		public DateTime? Timestamp { get; set;}
		
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
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
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
		
		
		/// <summary>
		/// key that was set
		/// </summary>
		
		public string Key { get; set;}
		
		/// <summary>
		/// new value set for key
		/// </summary>
		
		public string Value { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Key = (string)JsonUtil.Get<string>(json, "Key");
			Value = (string)JsonUtil.Get<string>(json, "Value");
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
		
		/// <summary>
		/// unique identifier of the title for which the tables are to be added
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Tables = JsonUtil.GetObjectList<RandomResultTable>(json, "Tables");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
	
	
	
	public class UpdateRandomResultTablesResult : PlayFabModelBase
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
		/// unique id for account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// time / date account was created
		/// </summary>
		
		public DateTime? Created { get; set;}
		
		/// <summary>
		/// account name
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// specific game title information
		/// </summary>
		
		public UserTitleInfo TitleInfo { get; set;}
		
		/// <summary>
		/// user's private account into
		/// </summary>
		
		public UserPrivateAccountInfo PrivateInfo { get; set;}
		
		/// <summary>
		/// facebook information (if linked)
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// steam information (if linked)
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// gamecenter information (if linked)
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Created = (DateTime?)JsonUtil.GetDateTime(json, "Created");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleInfo = JsonUtil.GetObject<UserTitleInfo>(json, "TitleInfo");
			PrivateInfo = JsonUtil.GetObject<UserPrivateAccountInfo>(json, "PrivateInfo");
			FacebookInfo = JsonUtil.GetObject<UserFacebookInfo>(json, "FacebookInfo");
			SteamInfo = JsonUtil.GetObject<UserSteamInfo>(json, "SteamInfo");
			GameCenterInfo = JsonUtil.GetObject<UserGameCenterInfo>(json, "GameCenterInfo");
		}
	}
	
	
	
	public class UserFacebookInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// facebook id
		/// </summary>
		
		public string FacebookId { get; set;}
		
		/// <summary>
		/// facebook username
		/// </summary>
		
		public string FacebookUsername { get; set;}
		
		/// <summary>
		/// facebook display name
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
		/// gamecenter id if account is linked
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
		/// Email address
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
		/// steam id
		/// </summary>
		
		public string SteamId { get; set;}
		
		/// <summary>
		/// if account is linked to steam, this is the country that steam reports the player being in
		/// </summary>
		
		public string SteamCountry { get; set;}
		
		/// <summary>
		/// Currency set in the user's steam account
		/// </summary>
		
		public Currency? SteamCurrency { get; set;}
		
		/// <summary>
		/// STEAM specific - what stage of game ownership is the user at with Steam
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
		/// displayable game name
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// optional value that details where the user originated
		/// </summary>
		
		public UserOrigination? Origination { get; set;}
		
		/// <summary>
		/// When this object was created. Title specific reporting for user creation time should be done against this rather than the User created field since account creation can differ significantly between title registration.
		/// </summary>
		
		public DateTime? Created { get; set;}
		
		/// <summary>
		/// Last time the user logged in to this title
		/// </summary>
		
		public DateTime? LastLogin { get; set;}
		
		/// <summary>
		///  Time the user first logged in. This can be different from when the UTD was created. For example we create a UTD when issuing a beta key. An arbitrary amount of time can pass before the user actually logs in.
		/// </summary>
		
		public DateTime? FirstLogin { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Origination = (UserOrigination?)JsonUtil.GetEnum<UserOrigination>(json, "Origination");
			Created = (DateTime?)JsonUtil.GetDateTime(json, "Created");
			LastLogin = (DateTime?)JsonUtil.GetDateTime(json, "LastLogin");
			FirstLogin = (DateTime?)JsonUtil.GetDateTime(json, "FirstLogin");
		}
	}
	
	
	
	public class AuthUserRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Session Ticket provided by the client
		/// </summary>
		
		public string AuthorizationTicket { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AuthorizationTicket = (string)JsonUtil.Get<string>(json, "AuthorizationTicket");
		}
	}
	
	
	
	public class AuthUserResponse : PlayFabModelBase
	{
		
		
		/// <summary>
		/// boolean indicating if the user has been authorized to use the external match-making service
		/// </summary>
		
		public bool Authorized { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the account that has been authorized
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Authorized = (bool)JsonUtil.Get<bool?>(json, "Authorized");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class PlayerJoinedRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the Game Server Instance the user is joining
		/// </summary>
		
		public string ServerId { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier for the user joining
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ServerId = (string)JsonUtil.Get<string>(json, "ServerId");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class PlayerJoinedResponse : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class PlayerLeftRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the Game Server Instance the user is leaving
		/// </summary>
		
		public string ServerId { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier for the user leaving
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ServerId = (string)JsonUtil.Get<string>(json, "ServerId");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class PlayerLeftResponse : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class StartGameRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable which is to be started
		/// </summary>
		
		public string Build { get; set;}
		
		/// <summary>
		/// region with which to associate the server, for filtering
		/// </summary>
		
		public Region Region { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		
		public uint GameMode { get; set;}
		
		/// <summary>
		/// IP Address of the external service which should receive status updates for the session
		/// </summary>
		
		public string Subscriber { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Build = (string)JsonUtil.Get<string>(json, "Build");
			Region = (Region)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (uint)JsonUtil.Get<double?>(json, "GameMode");
			Subscriber = (string)JsonUtil.Get<string>(json, "Subscriber");
		}
	}
	
	
	
	public class StartGameResponse : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the lobby in the new Game Server Instance
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// region with which the server is associated
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		
		public uint GameMode { get; set;}
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable which is being started
		/// </summary>
		
		public string Build { get; set;}
		
		/// <summary>
		/// IP address of the new Game Server Instance
		/// </summary>
		
		public string Address { get; set;}
		
		/// <summary>
		/// port number for communication with the Game Server Instance
		/// </summary>
		
		public uint Port { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (uint)JsonUtil.Get<double?>(json, "GameMode");
			Build = (string)JsonUtil.Get<string>(json, "Build");
			Address = (string)JsonUtil.Get<string>(json, "Address");
			Port = (uint)JsonUtil.Get<double?>(json, "Port");
		}
	}
	
	
	
	public class UserInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// minimum catalog version for which data is requested (filters the results to only contain inventory items which have a catalog version of this or higher)
		/// </summary>
		
		public uint MinCatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			MinCatalogVersion = (uint)JsonUtil.Get<double?>(json, "MinCatalogVersion");
		}
	}
	
	
	
	public class UserInfoResponse : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information was requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title specific display name, if set
		/// </summary>
		
		public string TitleDisplayName { get; set;}
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		/// <summary>
		/// boolean indicating whether the user is a developer
		/// </summary>
		
		public bool IsDeveloper { get; set;}
		
		/// <summary>
		/// Steam unique identifier, if the user has an associated Steam account
		/// </summary>
		
		public string SteamId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleDisplayName = (string)JsonUtil.Get<string>(json, "TitleDisplayName");
			Inventory = JsonUtil.GetObjectList<ItemInstance>(json, "Inventory");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
			IsDeveloper = (bool)JsonUtil.Get<bool?>(json, "IsDeveloper");
			SteamId = (string)JsonUtil.Get<string>(json, "SteamId");
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
	
	
	
	public class AwardSteamAchievementItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user who is to be granted the specified Steam achievement
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique Steam achievement name
		/// </summary>
		
		public string AchievementName { get; set;}
		
		/// <summary>
		/// result of the award attempt (only valid on response, not on request)
		/// </summary>
		
		public bool Result { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			AchievementName = (string)JsonUtil.Get<string>(json, "AchievementName");
			Result = (bool)JsonUtil.Get<bool?>(json, "Result");
		}
	}
	
	
	
	public class AwardSteamAchievementRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of achievements to grant and the users to whom they are to be granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> Achievements { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Achievements = JsonUtil.GetObjectList<AwardSteamAchievementItem>(json, "Achievements");
		}
	}
	
	
	
	public class AwardSteamAchievementResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of achievements granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> AchievementResults { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AchievementResults = JsonUtil.GetObjectList<AwardSteamAchievementItem>(json, "AchievementResults");
		}
	}
	
	
	
	public class GetUserAccountInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class GetUserAccountInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information was requested
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserInfo = JsonUtil.GetObject<UserAccountInfo>(json, "UserInfo");
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
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Data = JsonUtil.GetDictionary<string>(json, "Data");
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
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			Result = (bool)JsonUtil.Get<bool?>(json, "Result");
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
	
	
	
	public class NotifyMatchmakerPlayerLeftRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the Game Server Instance the user is leaving
		/// </summary>
		
		public string ServerId { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the user that is leaving the Game Server Instance
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ServerId = (string)JsonUtil.Get<string>(json, "ServerId");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class NotifyMatchmakerPlayerLeftResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// state of user leaving the Game Server Instance
		/// </summary>
		
		public PlayerConnectionState? PlayerState { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayerState = (PlayerConnectionState?)JsonUtil.GetEnum<PlayerConnectionState>(json, "PlayerState");
		}
	}
	
	
	
	public enum PlayerConnectionState
	{
		Unassigned,
		Connecting,
		Participating,
		Participated,
		Reconnecting
	}
	
	
	
	public class RedeemMatchmakerTicketRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// server authorization ticket passed back from a call to Matchmake or StartGame
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// IP Address of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string IP { get; set;}
		
		/// <summary>
		/// unique identifier of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string ServerId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			IP = (string)JsonUtil.Get<string>(json, "IP");
			ServerId = (string)JsonUtil.Get<string>(json, "ServerId");
		}
	}
	
	
	
	public class RedeemMatchmakerTicketResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// boolean indicating whether the ticket was validated by the PlayFab service
		/// </summary>
		
		public bool TicketIsValid { get; set;}
		
		/// <summary>
		/// error value if the ticket was not validated
		/// </summary>
		
		public string Error { get; set;}
		
		/// <summary>
		/// user account information for the user validated
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TicketIsValid = (bool)JsonUtil.Get<bool?>(json, "TicketIsValid");
			Error = (string)JsonUtil.Get<string>(json, "Error");
			UserInfo = JsonUtil.GetObject<UserAccountInfo>(json, "UserInfo");
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
	
	
}