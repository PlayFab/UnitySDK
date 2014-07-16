using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class MatchmakeRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// build version we want to match make against
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// region we want to match make against
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// game mode we want to match make against
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// lobby ID we want to match make against (i.e. selecting a specific server)
		/// </summary>
		
		public string LobbyId { get; set;}
		
		/// <summary>
		/// if specified match specified is full, allow the user to wait in a queue to join. NOTE - only valid if LobbyId is specified
		/// </summary>
		
		public bool? EnableQueue { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			LobbyId = (string)JsonUtil.Get<string>(json, "LobbyId");
			EnableQueue = (bool?)JsonUtil.Get<bool?>(json, "EnableQueue");
		}
	}
}