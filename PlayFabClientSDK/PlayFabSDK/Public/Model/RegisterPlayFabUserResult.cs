using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RegisterPlayFabUserResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this newly created account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// a unique token identifying the user and game at the server level, for the current session
		/// </summary>
		
		public string SessionTicket { get; set;}
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		
		public string Username { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			SessionTicket = (string)JsonUtil.Get<string>(json, "SessionTicket");
			Username = (string)JsonUtil.Get<string>(json, "Username");
		}
	}
}