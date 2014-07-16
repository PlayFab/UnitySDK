using System.Collections.Generic;



namespace PlayFab.Model
{
	
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
}