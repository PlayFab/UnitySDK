using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class StartGameResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ID for the lobby of the server started.
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// server IP address.
		/// </summary>
		
		public string ServerHostname { get; set;}
		
		/// <summary>
		/// port on server used for communication
		/// </summary>
		
		public uint? ServerPort { get; set;}
		
		/// <summary>
		/// unique ID for this server used in certain API calls
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// expiration date, if appropriate
		/// </summary>
		
		public string Expires { get; set;}
		
		/// <summary>
		/// password to log in with
		/// </summary>
		
		public string Password { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			ServerHostname = (string)JsonUtil.Get<string>(json, "ServerHostname");
			ServerPort = (uint?)JsonUtil.Get<double?>(json, "ServerPort");
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			Expires = (string)JsonUtil.Get<string>(json, "Expires");
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
}