using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
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
}