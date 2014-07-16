using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class PaymentOption : PlayFabModelBase
	{
		
		
		/// <summary>
		/// currency type
		/// </summary>
		
		public string Currency { get; set;}
		
		/// <summary>
		/// name of entity that is doing the billing
		/// </summary>
		
		public string ProviderName { get; set;}
		
		/// <summary>
		/// Price paid
		/// </summary>
		
		public uint Price { get; set;}
		
		/// <summary>
		/// Credit towards this purchase
		/// </summary>
		
		public uint StoreCredit { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Currency = (string)JsonUtil.Get<string>(json, "Currency");
			ProviderName = (string)JsonUtil.Get<string>(json, "ProviderName");
			Price = (uint)JsonUtil.Get<double?>(json, "Price");
			StoreCredit = (uint)JsonUtil.Get<double?>(json, "StoreCredit");
		}
	}
}