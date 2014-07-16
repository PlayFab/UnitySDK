using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class ValidateGooglePlayPurchaseRequest : PlayFabModelBase
	{
		
		
		
		public string packageName { get; set;}
		
		
		public string productId { get; set;}
		
		
		public string purchaseToken { get; set;}
		
		/// <summary>
		/// OAuth 2.0 token retrieved from Google
		/// </summary>
		
		public string accessToken { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			packageName = (string)JsonUtil.Get<string>(json, "packageName");
			productId = (string)JsonUtil.Get<string>(json, "productId");
			purchaseToken = (string)JsonUtil.Get<string>(json, "purchaseToken");
			accessToken = (string)JsonUtil.Get<string>(json, "accessToken");
		}
	}
}