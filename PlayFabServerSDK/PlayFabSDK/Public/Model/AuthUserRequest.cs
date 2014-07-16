using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class AuthUserRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Session Ticket provided by the client
		/// </summary>
		
		public string AuthorizationTicket { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AuthorizationTicket = (string)JsonUtil.Get<string>(json, "AuthorizationTicket");
		}
	}
}