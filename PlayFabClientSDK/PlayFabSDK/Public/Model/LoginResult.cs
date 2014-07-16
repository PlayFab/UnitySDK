using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LoginResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// a unique token identifying the user and game at the server level, for the current session
		/// </summary>
		
		public string SessionTicket { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SessionTicket = (string)JsonUtil.Get<string>(json, "SessionTicket");
		}
	}
}