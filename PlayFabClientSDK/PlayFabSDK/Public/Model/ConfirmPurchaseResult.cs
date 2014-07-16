using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
	public class ConfirmPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// date and time of the purchase
		/// </summary>
		
		public DateTime? PurchaseDate { get; set;}
		
		/// <summary>
		/// array of items purchased
		/// </summary>
		
		public List<PurchasedItem> Items { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			PurchaseDate = (DateTime?)JsonUtil.GetDateTime(json, "PurchaseDate");
			Items = JsonUtil.GetObjectList<PurchasedItem>(json, "Items");
		}
	}
}