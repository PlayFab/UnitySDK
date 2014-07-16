using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class UserFacebookInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// facebook id
		/// </summary>
		
		public string FacebookId { get; set;}
		
		/// <summary>
		/// facebook username
		/// </summary>
		
		public string FacebookUsername { get; set;}
		
		/// <summary>
		/// facebook display name
		/// </summary>
		
		public string FacebookDisplayname { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FacebookId = (string)JsonUtil.Get<string>(json, "FacebookId");
			FacebookUsername = (string)JsonUtil.Get<string>(json, "FacebookUsername");
			FacebookDisplayname = (string)JsonUtil.Get<string>(json, "FacebookDisplayname");
		}
	}
}