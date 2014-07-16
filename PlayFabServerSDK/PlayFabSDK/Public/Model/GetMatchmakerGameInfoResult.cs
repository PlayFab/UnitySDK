using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
	public class GetMatchmakerGameInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the lobby 
		/// </summary>
		
		public string LobbyId { get; set;}
		
		/// <summary>
		/// unique identifier of the Game Server Instance for this lobby
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// time when the Game Server Instance was created
		/// </summary>
		
		public DateTime? StartTime { get; set;}
		
		/// <summary>
		/// time when Game Server Instance is currently scheduled to end
		/// </summary>
		
		public DateTime? EndTime { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		
		public string Mode { get; set;}
		
		/// <summary>
		/// version identifier of the game server executable binary being run
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// region in which the Game Server Instance is running
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// array of unique PlayFab identifiers for users currently connected to this Game Server Instance
		/// </summary>
		
		public List<string> Players { get; set;}
		
		/// <summary>
		/// IP address for this Game Server Instance
		/// </summary>
		
		public string ServerAddress { get; set;}
		
		/// <summary>
		/// communication port for this Game Server Instance
		/// </summary>
		
		public uint ServerPort { get; set;}
		
		/// <summary>
		/// output log from this Game Server Instance
		/// </summary>
		
		public string StdOutLog { get; set;}
		
		/// <summary>
		/// error log from this Game Server Instance
		/// </summary>
		
		public string StdErrLog { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyId = (string)JsonUtil.Get<string>(json, "LobbyId");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			StartTime = (DateTime?)JsonUtil.GetDateTime(json, "StartTime");
			EndTime = (DateTime?)JsonUtil.GetDateTime(json, "EndTime");
			Mode = (string)JsonUtil.Get<string>(json, "Mode");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			Players = JsonUtil.GetList<string>(json, "Players");
			ServerAddress = (string)JsonUtil.Get<string>(json, "ServerAddress");
			ServerPort = (uint)JsonUtil.Get<double?>(json, "ServerPort");
			StdOutLog = (string)JsonUtil.Get<string>(json, "StdOutLog");
			StdErrLog = (string)JsonUtil.Get<string>(json, "StdErrLog");
		}
	}
}