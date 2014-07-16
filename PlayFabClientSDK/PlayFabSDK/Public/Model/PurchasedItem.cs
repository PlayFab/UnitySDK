using System.Collections.Generic;



namespace PlayFab.Model
{
	
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
}