using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RemoveFriendRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account which is to be removed
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
		}
	}
}