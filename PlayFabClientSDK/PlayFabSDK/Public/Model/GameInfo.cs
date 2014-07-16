using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GameInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// region this server is part of
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// unique lobby id for this game server
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// build version this server is running
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// game mode this server is running
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// level name this server is running (if appropriate)
		/// </summary>
		
		public string Map { get; set;}
		
		/// <summary>
		/// maximum players this server can support
		/// </summary>
		
		public int MaxPlayers { get; set;}
		
		/// <summary>
		/// array of strings of current player names on this server (note, these are usernames, which means they are account names, not display names)
		/// </summary>
		
		public List<string> PlayerUsernames { get; set;}
		
		/// <summary>
		/// duration this server has been running (in seconds)
		/// </summary>
		
		public uint RunTime { get; set;}
		
		/// <summary>
		/// game specific string denoting server configuration
		/// </summary>
		
		public string GameServerState { get; set;}
		
		/// <summary>
		/// unique client provided string - passed in at start game request - that details user defined specifics about this game server instance
		/// </summary>
		
		public string TitleData { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			Map = (string)JsonUtil.Get<string>(json, "Map");
			MaxPlayers = (int)JsonUtil.Get<double?>(json, "MaxPlayers");
			PlayerUsernames = JsonUtil.GetList<string>(json, "PlayerUsernames");
			RunTime = (uint)JsonUtil.Get<double?>(json, "RunTime");
			GameServerState = (string)JsonUtil.Get<string>(json, "GameServerState");
			TitleData = (string)JsonUtil.Get<string>(json, "TitleData");
		}
	}
}