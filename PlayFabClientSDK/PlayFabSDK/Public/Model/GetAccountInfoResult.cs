using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetAccountInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// account information for the local user
		/// </summary>
		
		public UserAccountInfo AccountInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AccountInfo = JsonUtil.GetObject<UserAccountInfo>(json, "AccountInfo");
		}
	}
}