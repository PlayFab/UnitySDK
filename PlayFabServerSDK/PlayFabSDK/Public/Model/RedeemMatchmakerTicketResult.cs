using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RedeemMatchmakerTicketResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// boolean indicating whether the ticket was validated by the PlayFab service
		/// </summary>
		
		public bool TicketIsValid { get; set;}
		
		/// <summary>
		/// error value if the ticket was not validated
		/// </summary>
		
		public string Error { get; set;}
		
		/// <summary>
		/// user account information for the user validated
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TicketIsValid = (bool)JsonUtil.Get<bool?>(json, "TicketIsValid");
			Error = (string)JsonUtil.Get<string>(json, "Error");
			UserInfo = JsonUtil.GetObject<UserAccountInfo>(json, "UserInfo");
		}
	}
}