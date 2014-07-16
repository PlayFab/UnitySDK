using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LinkFacebookAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
		}
	}
}