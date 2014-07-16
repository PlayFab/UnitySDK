using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RedeemCouponResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of items granted to the player as a result of redeeming the coupon
		/// </summary>
		
		public List<ItemInstance> GrantedItems { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GrantedItems = JsonUtil.GetObjectList<ItemInstance>(json, "GrantedItems");
		}
	}
}