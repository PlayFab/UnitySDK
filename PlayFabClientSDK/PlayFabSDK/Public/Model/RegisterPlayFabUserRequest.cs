using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RegisterPlayFabUserRequest : PlayFabModelBase
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
		/// user email address, used for account password recovery
		/// </summary>
		
		public string Email { get; set;}
		
		/// <summary>
		/// password for the account to be signed in (6-24 characters)
		/// </summary>
		
		public string Password { get; set;}
		
		/// <summary>
		/// optional string indicating where this user came from (iOS iPhone, Android, etc.)
		/// </summary>
		
		public string Origination { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Email = (string)JsonUtil.Get<string>(json, "Email");
			Password = (string)JsonUtil.Get<string>(json, "Password");
			Origination = (string)JsonUtil.Get<string>(json, "Origination");
		}
	}
}