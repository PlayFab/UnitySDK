using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class StartPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// cart items to be purchased
		/// </summary>
		
		public List<CartItem> Contents { get; set;}
		
		/// <summary>
		/// available methods by which the user can pay
		/// </summary>
		
		public List<PaymentOption> PaymentOptions { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrencyBalances { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			Contents = JsonUtil.GetObjectList<CartItem>(json, "Contents");
			PaymentOptions = JsonUtil.GetObjectList<PaymentOption>(json, "PaymentOptions");
			VirtualCurrencyBalances = JsonUtil.GetDictionaryInt32(json, "VirtualCurrencyBalances");
		}
	}
}