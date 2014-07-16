using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class MatchmakeResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique lobby id of server we made a match against
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// server IP address we made a match against
		/// </summary>
		
		public string ServerHostname { get; set;}
		
		/// <summary>
		/// port number server communicates on
		/// </summary>
		
		public uint? ServerPort { get; set;}
		
		/// <summary>
		/// if server uses http connection protocols, this is the port it uses
		/// </summary>
		
		public uint? WebSocketPort { get; set;}
		
		/// <summary>
		/// server authorisation ticket - used by RedeemCoupon to validate user insertion into the game
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// time/date the server expires on
		/// </summary>
		
		public string Expires { get; set;}
		
		/// <summary>
		/// UNKNOWN - unused in code
		/// </summary>
		
		public uint? PollWaitTimeMS { get; set;}
		
		/// <summary>
		/// result of match making process
		/// </summary>
		
		public MatchmakeStatus? Status { get; set;}
		
		/// <summary>
		/// queue of unique user Id's of players waiting to join this game. This user will be at the end of this list.
		/// </summary>
		
		public List<string> Queue { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			ServerHostname = (string)JsonUtil.Get<string>(json, "ServerHostname");
			ServerPort = (uint?)JsonUtil.Get<double?>(json, "ServerPort");
			WebSocketPort = (uint?)JsonUtil.Get<double?>(json, "WebSocketPort");
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			Expires = (string)JsonUtil.Get<string>(json, "Expires");
			PollWaitTimeMS = (uint?)JsonUtil.Get<double?>(json, "PollWaitTimeMS");
			Status = (MatchmakeStatus?)JsonUtil.GetEnum<MatchmakeStatus>(json, "Status");
			Queue = JsonUtil.GetList<string>(json, "Queue");
		}
	}
}