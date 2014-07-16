using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LoginWithSteamRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique identifier from Steam for the user
		/// </summary>
		
		public string SteamTicket { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Steam account
		/// </summary>
		
		public bool CreateAccount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			SteamTicket = (string)JsonUtil.Get<string>(json, "SteamTicket");
			CreateAccount = (bool)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
}