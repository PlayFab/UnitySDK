using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
	public class ValidateGooglePlayPurchaseResult : PlayFabModelBase
	{
		
		
		
		public string kind { get; set;}
		
		
		public DateTime? purchaseTime { get; set;}
		
		
		public int puchaseState { get; set;}
		
		
		public int consumptionState { get; set;}
		
		
		public string developerPayload { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			kind = (string)JsonUtil.Get<string>(json, "kind");
			purchaseTime = (DateTime?)JsonUtil.GetDateTime(json, "purchaseTime");
			puchaseState = (int)JsonUtil.Get<double?>(json, "puchaseState");
			consumptionState = (int)JsonUtil.Get<double?>(json, "consumptionState");
			developerPayload = (string)JsonUtil.Get<string>(json, "developerPayload");
		}
	}
}