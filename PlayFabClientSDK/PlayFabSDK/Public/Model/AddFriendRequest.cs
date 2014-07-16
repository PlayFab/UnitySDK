using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class AddFriendRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab username of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendUsername { get; set;}
		
		/// <summary>
		/// email address of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendEmail { get; set;}
		
		/// <summary>
		/// title-specific display name of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendTitleDisplayName { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			FriendUsername = (string)JsonUtil.Get<string>(json, "FriendUsername");
			FriendEmail = (string)JsonUtil.Get<string>(json, "FriendEmail");
			FriendTitleDisplayName = (string)JsonUtil.Get<string>(json, "FriendTitleDisplayName");
		}
	}
}