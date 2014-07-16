using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class SendAccountRecoveryEmailRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user email address, used for account password recovery
		/// </summary>
		
		public string Email { get; set;}
		
		/// <summary>
		/// unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
}