using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LoginWithPlayFabRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// PlayFab username for the account to be signed in (3-24 characters)
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// password for the account to be signed in (6-24 characters)
		/// </summary>
		
		public string Password { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
}