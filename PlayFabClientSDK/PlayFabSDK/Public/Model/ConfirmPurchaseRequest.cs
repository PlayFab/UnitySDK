using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class ConfirmPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		
		public string OrderId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
		}
	}
}