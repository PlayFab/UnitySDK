using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class StartGameRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// which uploaded build of the game server we are starting up
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// the region we want to associate this server with for filtering servers
		/// </summary>
		
		public Region Region { get; set;}
		
		/// <summary>
		/// which user defined game mode this server is going to be running (e.g. Capture The Flag = 0, Deathmatch = 1) - default to 0 if there is only one mode
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// Is there a password associated with this server?
		/// </summary>
		
		public bool PasswordRestricted { get; set;}
		
		/// <summary>
		/// Lobby Id that the user came from from within the match maker service
		/// </summary>
		
		public string ReplayLobbyId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			PasswordRestricted = (bool)JsonUtil.Get<bool?>(json, "PasswordRestricted");
			ReplayLobbyId = (string)JsonUtil.Get<string>(json, "ReplayLobbyId");
		}
	}
}