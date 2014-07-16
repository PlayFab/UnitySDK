using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class CurrentGamesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// region we are interested in
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// version of build we want to get stats for
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// filter on value of game server instance - running, ended, waiting for players etc.
		/// </summary>
		
		public string IncludeState { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			IncludeState = (string)JsonUtil.Get<string>(json, "IncludeState");
		}
	}
}