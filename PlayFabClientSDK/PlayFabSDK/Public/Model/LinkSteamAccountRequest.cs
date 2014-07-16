using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LinkSteamAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier from Steam for the user
		/// </summary>
		
		public string SteamTicket { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SteamTicket = (string)JsonUtil.Get<string>(json, "SteamTicket");
		}
	}
}