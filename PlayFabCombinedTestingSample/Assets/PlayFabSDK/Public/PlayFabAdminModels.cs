using System;
using System.Collections.Generic;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Json.Converters;

namespace PlayFab.AdminModels
{
	
	
	
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
	
	
	
	public class AddNewsResult
	{   
		
		/// <summary>
		/// Unique id of the new news item
		/// </summary>
		public string NewsId { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	}
	
	
	
	public class AddServerBuildResult
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
		/// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		public string TitleId { get; set;}
		
		/// <summary>
		/// the current status of the build validation and processing steps
		/// </summary>
		public GameBuildStatus? Status { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
		/// Amount to be added to the user balance of the specified virtual currency.
		/// </summary>
		public int Amount { get; set;}
	}
	
	
	
	public class AddVirtualCurrencyTypesRequest
	{   
		
		/// <summary>
		/// List of virtual currencies and their initial deposits (the amount a user is granted when signing in for the first time) to the title
		/// </summary>
		public List<VirtualCurrencyData> VirtualCurrencies { get; set;}
	}
	
	
	
	public class BlankResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
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
	
	
	
	public class ContentInfo
	{   
		
		/// <summary>
		/// Key of the content
		/// </summary>
		public string Key { get; set;}
		
		/// <summary>
		/// Size of the content in bytes
		/// </summary>
		public long Size { get; set;}
		
		/// <summary>
		/// Last modified time
		/// </summary>
		public DateTime LastModified { get; set;}
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
	
	
	
	public class DeleteContentRequest
	{   
		
		/// <summary>
		/// Key of the content item to be deleted
		/// </summary>
		public string Key { get; set;}
	}
	
	
	
	public class DeleteUsersRequest
	{   
		
		/// <summary>
		/// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
		/// </summary>
		public List<string> PlayFabIds { get; set;}
		
		/// <summary>
		/// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		public string TitleId { get; set;}
	}
	
	
	
	public class DeleteUsersResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public enum GameBuildStatus
	{
		Available,
		Validating,
		InvalidBuildPackage,
		Processing,
		FailedToProcess
	}
	
	
	
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
	}
	
	
	
	public class GetCatalogItemsRequest
	{   
		
		/// <summary>
		/// Which catalog is being requested.
		/// </summary>
		public string CatalogVersion { get; set;}
	}
	
	
	
	public class GetCatalogItemsResult
	{   
		
		/// <summary>
		/// Array of items which can be purchased.
		/// </summary>
		public List<CatalogItem> Catalog { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class GetCloudScriptRevisionResult
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetCloudScriptVersionsRequest
	{   
	}
	
	
	
	public class GetCloudScriptVersionsResult
	{   
		
		/// <summary>
		/// List of versions
		/// </summary>
		public List<CloudScriptVersionStatus> Versions { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetContentListRequest
	{   
		
		/// <summary>
		/// Limits the response to keys that begin with the specified prefix. You can use prefixes to list contents under a folder, or for a specified version, etc.
		/// </summary>
		public string Prefix { get; set;}
	}
	
	
	
	public class GetContentListResult
	{   
		
		/// <summary>
		/// Number of content items returned. We currently have a maximum of 1000 items limit.
		/// </summary>
		public long ItemCount { get; set;}
		
		/// <summary>
		/// The total size of listed contents in bytes
		/// </summary>
		public long TotalSize { get; set;}
		
		public List<ContentInfo> Contents { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class GetContentUploadUrlResult
	{   
		
		/// <summary>
		/// URL for uploading content via HTTP PUT method. The URL will expire in 1 hour.
		/// </summary>
		public string URL { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class GetDataReportResult
	{   
		
		public string DownloadUrl { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetMatchmakerGameInfoRequest
	{   
		
		/// <summary>
		/// unique identifier of the lobby for which info is being requested
		/// </summary>
		public string LobbyId { get; set;}
	}
	
	
	
	public class GetMatchmakerGameInfoResult
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetMatchmakerGameModesRequest
	{   
		
		/// <summary>
		/// previously uploaded build version for which game modes are being requested
		/// </summary>
		public string BuildVersion { get; set;}
	}
	
	
	
	public class GetMatchmakerGameModesResult
	{   
		
		/// <summary>
		/// array of game modes available for the specified build
		/// </summary>
		public List<GameModeInfo> GameModes { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetPublisherDataRequest
	{   
		
		/// <summary>
		///  array of keys to get back data from the Publisher data blob, set by the admin tools
		/// </summary>
		public List<string> Keys { get; set;}
	}
	
	
	
	public class GetPublisherDataResult
	{   
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetRandomResultTablesRequest
	{   
		
		/// <summary>
		/// catalog version to fetch tables from. Use default catalog version if null
		/// </summary>
		public string CatalogVersion { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetRandomResultTablesResult
	{   
		
		/// <summary>
		/// array of random result tables currently available
		/// </summary>
		public Dictionary<string,RandomResultTableListing> Tables { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	public class GetServerBuildInfoResult
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
		/// developer comment(s) for this build
		/// </summary>
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetServerBuildUploadURLRequest
	{   
		
		/// <summary>
		/// unique identifier of the game server build to upload
		/// </summary>
		public string BuildId { get; set;}
	}
	
	
	
	public class GetServerBuildUploadURLResult
	{   
		
		/// <summary>
		/// pre-authorized URL for uploading the game server build package
		/// </summary>
		public string URL { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
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
	
	
	
	public class GetStoreItemsResult
	{   
		
		/// <summary>
		/// Array of items which can be purchased from this store.
		/// </summary>
		public List<StoreItem> Store { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetTitleDataRequest
	{   
		
		/// <summary>
		/// Specific keys to search for in the title data (leave null to get all keys)
		/// </summary>
		public List<string> Keys { get; set;}
	}
	
	
	
	public class GetTitleDataResult
	{   
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
		public int? IfChangedFromDataVersion { get; set;}
	}
	
	
	
	public class GetUserDataResult
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class GetUserInventoryRequest
	{   
		
		/// <summary>
		/// Unique PlayFab assigned ID of the user on whom the operation will be performed.
		/// </summary>
		public string PlayFabId { get; set;}
	}
	
	
	
	public class GetUserInventoryResult
	{   
		
		/// <summary>
		/// PlayFab unique identifier of the user whose inventory is being returned.
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	/// <summary>
	/// Result of granting an item to a user
	/// </summary>
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
	
	
	
	public class GrantItemsToUsersResult
	{   
		
		/// <summary>
		/// Array of items granted to users.
		/// </summary>
		public List<GrantedItemInstance> ItemGrantResults { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class ListBuildsRequest
	{   
	}
	
	
	
	public class ListBuildsResult
	{   
		
		/// <summary>
		/// array of uploaded game server builds
		/// </summary>
		public List<GetServerBuildInfoResult> Builds { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class ListVirtualCurrencyTypesRequest
	{   
	}
	
	
	
	public class ListVirtualCurrencyTypesResult
	{   
		
		/// <summary>
		/// List of virtual currency names defined for this title
		/// </summary>
		public List<VirtualCurrencyData> VirtualCurrencies { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class LookupUserAccountInfoResult
	{   
		
		/// <summary>
		/// User info for the user matching the request
		/// </summary>
		public UserAccountInfo UserInfo { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class ModifyMatchmakerGameModesResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class ModifyServerBuildResult
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
		/// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
		/// </summary>
		public string TitleId { get; set;}
		
		/// <summary>
		/// the current status of the build validation and processing steps
		/// </summary>
		public GameBuildStatus? Status { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class ModifyUserVirtualCurrencyResult
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
		/// Amount added or subtracted from the user's virtual currency.
		/// </summary>
		public int BalanceChange { get; set;}
		
		/// <summary>
		/// Balance of the virtual currency after modification.
		/// </summary>
		public int Balance { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class RefundPurchaseRequest
	{   
		
		/// <summary>
		/// Unique PlayFab assigned ID of the user on whom the operation will be performed.
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// Unique order ID for the purchase in question.
		/// </summary>
		public string OrderId { get; set;}
		
		/// <summary>
		/// Reason for refund. In the case of Facebook this must match one of their refund or dispute resolution enums (See: https://developers.facebook.com/docs/payments/implementation-guide/handling-disputes-refunds)
		/// </summary>
		public string Reason { get; set;}
	}
	
	
	
	public class RefundPurchaseResponse
	{   
		
		/// <summary>
		/// The order's updated purchase status.
		/// </summary>
		public string PurchaseStatus { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
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
	
	
	
	public class RemoveServerBuildRequest
	{   
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable to be removed
		/// </summary>
		public string BuildId { get; set;}
	}
	
	
	
	public class RemoveServerBuildResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class ResetCharacterStatisticsResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class ResetUsersRequest
	{   
		
		/// <summary>
		/// Array of users to reset
		/// </summary>
		public List<UserCredentials> Users { get; set;}
	}
	
	
	
	public class ResetUserStatisticsRequest
	{   
		
		/// <summary>
		/// Unique PlayFab assigned ID of the user on whom the operation will be performed.
		/// </summary>
		public string PlayFabId { get; set;}
	}
	
	
	
	public class ResetUserStatisticsResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public enum ResolutionOutcome
	{
		Revoke,
		Reinstate,
		Manual
	}
	
	
	
	public class ResolvePurchaseDisputeRequest
	{   
		
		/// <summary>
		/// Unique PlayFab assigned ID of the user on whom the operation will be performed.
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// Unique order ID for the purchase in question.
		/// </summary>
		public string OrderId { get; set;}
		
		/// <summary>
		/// Reason for refund. In the case of Facebook this must match one of their refund or dispute resolution enums (See: https://developers.facebook.com/docs/payments/implementation-guide/handling-disputes-refunds)
		/// </summary>
		public string Reason { get; set;}
		
		/// <summary>
		/// Enum for the desired purchase result state after notifying the payment provider. Valid values are Revoke, Reinstate and Manual. Manual will cause no change to the order state.
		/// </summary>
		public ResolutionOutcome Outcome { get; set;}
	}
	
	
	
	public class ResolvePurchaseDisputeResponse
	{   
		
		/// <summary>
		/// The order's updated purchase status.
		/// </summary>
		public string PurchaseStatus { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public enum ResultTableNodeType
	{
		ItemId,
		TableId
	}
	
	
	
	public class RevokeInventoryItemRequest
	{   
		
		/// <summary>
		/// unique PlayFab identifier for the user account which is to have the specified item removed
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// Unique PlayFab assigned ID for a specific character owned by a user
		/// </summary>
		public string CharacterId { get; set;}
		
		/// <summary>
		/// unique PlayFab identifier for the item instance to be removed
		/// </summary>
		public string ItemInstanceId { get; set;}
	}
	
	
	
	public class RevokeInventoryResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class SendAccountRecoveryEmailRequest
	{   
		
		/// <summary>
		/// User email address attached to their account
		/// </summary>
		public string Email { get; set;}
	}
	
	
	
	public class SendAccountRecoveryEmailResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class SetPublishedRevisionResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class SetPublisherDataResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class SetTitleDataResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class SetupPushNotificationResult
	{   
		
		/// <summary>
		/// Amazon Resource Name for the created notification topic.
		/// </summary>
		public string ARN { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
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
	
	
	
	public class UpdateCatalogItemsRequest
	{   
		
		/// <summary>
		/// which catalog is being updated
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of catalog items to be submitted
		/// </summary>
		public List<CatalogItem> Catalog { get; set;}
	}
	
	
	
	public class UpdateCatalogItemsResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class UpdateCloudScriptRequest
	{   
		
		/// <summary>
		/// Cloud Script version to update. If null, defaults to most recent version
		/// </summary>
		public int? Version { get; set;}
		
		/// <summary>
		/// List of Cloud Script files to upload to create the new revision. Must have at least one file.
		/// </summary>
		public List<CloudScriptFile> Files { get; set;}
	}
	
	
	
	public class UpdateCloudScriptResult
	{   
		
		/// <summary>
		/// Cloud Script version updated
		/// </summary>
		public int Version { get; set;}
		
		/// <summary>
		/// New revision number created
		/// </summary>
		public int Revision { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class UpdateRandomResultTablesRequest
	{   
		
		/// <summary>
		/// which catalog is being updated. If null, update the current default catalog version
		/// </summary>
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that table, while any others will be added to the available set)
		/// </summary>
		public List<RandomResultTable> Tables { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class UpdateRandomResultTablesResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
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
	
	
	
	public class UpdateStoreItemsResult
	{   
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class UpdateUserDataRequest
	{   
		
		/// <summary>
		/// Unique PlayFab assigned ID of the user on whom the operation will be performed.
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// Data to be written to the user's custom data. Note that keys are trimmed of whitespace, are limited to 1024 characters, and may not begin with a '!' character.
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
		/// </summary>
		public UserDataPermission? Permission { get; set;}
	}
	
	
	
	public class UpdateUserDataResult
	{   
		
		/// <summary>
		/// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
		/// </summary>
		public uint DataVersion { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class UpdateUserInternalDataRequest
	{   
		
		/// <summary>
		/// Unique PlayFab assigned ID of the user on whom the operation will be performed.
		/// </summary>
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// Data to be written to the user's custom data.
		/// </summary>
		public Dictionary<string,string> Data { get; set;}
	}
	
	
	
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
	
	
	
	public class UpdateUserTitleDisplayNameResult
	{   
		
		/// <summary>
		/// current title display name for the user (this will be the original display name if the rename attempt failed)
		/// </summary>
		public string DisplayName { get; set;}
		public object Request { get; set; }
		public object CustomData { get; set;  }
		
	}
	
	
	
	public class UserAccountInfo
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
	}
	
	
	
	public class UserCredentials
	{   
		
		/// <summary>
		/// Username of user to reset
		/// </summary>
		public string Username { get; set;}
		
		/// <summary>
		/// Password for the PlayFab account (6-30 characters)
		/// </summary>
		public string Password { get; set;}
	}
	
	
	
	public enum UserDataPermission
	{
		Private,
		Public
	}
	
	
	
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
		CustomId
	}
	
	
	
	public class UserPrivateAccountInfo
	{   
		
		/// <summary>
		/// user email address
		/// </summary>
		public string Email { get; set;}
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
		/// amount to automatically grant users upon first login to the tilte
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
