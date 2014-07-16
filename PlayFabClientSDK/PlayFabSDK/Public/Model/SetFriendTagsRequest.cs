using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class SetFriendTagsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account to which the tag(s) should be applied
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// array of tags to set on the friend account
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			Tags = JsonUtil.GetList<string>(json, "Tags");
		}
	}
}