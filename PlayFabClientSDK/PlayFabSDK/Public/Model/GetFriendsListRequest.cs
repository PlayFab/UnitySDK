using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetFriendsListRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// indicates whether Steam service friends should also be included in the response
		/// </summary>
		
		public bool? IncludeSteamFriends { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			IncludeSteamFriends = (bool?)JsonUtil.Get<bool?>(json, "IncludeSteamFriends");
		}
	}
}