using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class ValidateIOSReceiptRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// base64 encoded receipt data, passed back by the App Store as a result of a successful purchase
		/// </summary>
		
		public string ReceiptData { get; set;}
		
		/// <summary>
		/// name of the object purchased
		/// </summary>
		
		public string ObjectName { get; set;}
		
		/// <summary>
		/// currency used for the purchase
		/// </summary>
		
		public string CurrencyCode { get; set;}
		
		/// <summary>
		/// amount of the stated currency paid for the object
		/// </summary>
		
		public decimal PurchasePrice { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ReceiptData = (string)JsonUtil.Get<string>(json, "ReceiptData");
			ObjectName = (string)JsonUtil.Get<string>(json, "ObjectName");
			CurrencyCode = (string)JsonUtil.Get<string>(json, "CurrencyCode");
			PurchasePrice = (decimal)JsonUtil.Get<double?>(json, "PurchasePrice");
		}
	}
}