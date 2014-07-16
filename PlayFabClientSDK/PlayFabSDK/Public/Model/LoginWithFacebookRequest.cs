using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LoginWithFacebookRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Facebook account
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
}