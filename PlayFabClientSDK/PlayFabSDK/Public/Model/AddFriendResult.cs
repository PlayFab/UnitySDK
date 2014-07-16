using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class AddFriendResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// was the friend request processed successfully
		/// </summary>
		
		public bool Created { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Created = (bool)JsonUtil.Get<bool?>(json, "Created");
		}
	}
}