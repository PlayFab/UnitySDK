using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RedeemCouponRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// generated coupon code to redeem
		/// </summary>
		
		public string CouponCode { get; set;}
		
		/// <summary>
		/// catalog version of the coupon
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CouponCode = (string)JsonUtil.Get<string>(json, "CouponCode");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
}