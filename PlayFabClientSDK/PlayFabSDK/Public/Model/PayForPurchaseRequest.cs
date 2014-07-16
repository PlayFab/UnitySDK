using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class PayForPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// payment provider to use to fund the purchase
		/// </summary>
		
		public string ProviderName { get; set;}
		
		/// <summary>
		/// currency to use to fund the purchase
		/// </summary>
		
		public string Currency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			ProviderName = (string)JsonUtil.Get<string>(json, "ProviderName");
			Currency = (string)JsonUtil.Get<string>(json, "Currency");
		}
	}
}