using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class PayForPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// information on the purchase as processed by the service
		/// </summary>
		
		public PurchaseData Purchase { get; set;}
		
		/// <summary>
		/// url to the purchase provider page that details the purchase
		/// </summary>
		
		public string PurchaseConfirmationPageURL { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Purchase = JsonUtil.GetObject<PurchaseData>(json, "Purchase");
			PurchaseConfirmationPageURL = (string)JsonUtil.Get<string>(json, "PurchaseConfirmationPageURL");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
		}
	}
}