using System.Collections.Generic;



namespace PlayFab.Model
{
	
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
}