using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class StartPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// catalog version for the items to be purchased
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// the set of items to purchase
		/// </summary>
		
		public List<ItemPuchaseRequest> Items { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			Items = JsonUtil.GetObjectList<ItemPuchaseRequest>(json, "Items");
		}
	}
}