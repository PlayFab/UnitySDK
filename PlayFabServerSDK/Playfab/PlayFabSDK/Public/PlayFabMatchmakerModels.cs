using System;
using System.Collections.Generic;
using PlayFab.Internal;

namespace PlayFab.MatchmakerModels
{
	
	
	
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
			PurchaseDate = (DateTime?)JsonUtil.GetDateTime(json, "PurchaseDate");
			Expiration = (DateTime?)JsonUtil.GetDateTime(json, "Expiration");
			RemainingUses = (uint?)JsonUtil.Get<double?>(json, "RemainingUses");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			BundleParent = (string)JsonUtil.Get<string>(json, "BundleParent");
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
	
}
