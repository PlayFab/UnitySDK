using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetFriendsListResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of friends found
		/// </summary>
		
		public List<FriendInfo> Friends { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Friends = JsonUtil.GetObjectList<FriendInfo>(json, "Friends");
		}
	}
}