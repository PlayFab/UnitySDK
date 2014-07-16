using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RedeemMatchmakerTicketRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// server authorization ticket passed back from a call to Matchmake or StartGame
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// IP Address of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string IP { get; set;}
		
		/// <summary>
		/// unique identifier of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string ServerId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			IP = (string)JsonUtil.Get<string>(json, "IP");
			ServerId = (string)JsonUtil.Get<string>(json, "ServerId");
		}
	}
}