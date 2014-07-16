using System.Collections.Generic;



namespace PlayFab.Model
{
	
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
}