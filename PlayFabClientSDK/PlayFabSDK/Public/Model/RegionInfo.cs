using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RegionInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// region we refer to
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// name of region
		/// </summary>
		
		public string Name { get; set;}
		
		/// <summary>
		/// is this region available for usage (e.g. adding a server, or adding players)
		/// </summary>
		
		public bool Available { get; set;}
		
		/// <summary>
		/// url to ping to get rountrip time
		/// </summary>
		
		public string PingUrl { get; set;}
		
		/// <summary>
		/// number of games / servers running on this region
		/// </summary>
		
		public uint GameCount { get; set;}
		
		/// <summary>
		/// number of players in this region
		/// </summary>
		
		public uint GamePlayersCount { get; set;}
		
		/// <summary>
		/// list of game modes being supported by servers in this region
		/// </summary>
		
		public List<GameModeInfo> GameModes { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			Name = (string)JsonUtil.Get<string>(json, "Name");
			Available = (bool)JsonUtil.Get<bool?>(json, "Available");
			PingUrl = (string)JsonUtil.Get<string>(json, "PingUrl");
			GameCount = (uint)JsonUtil.Get<double?>(json, "GameCount");
			GamePlayersCount = (uint)JsonUtil.Get<double?>(json, "GamePlayersCount");
			GameModes = JsonUtil.GetObjectList<GameModeInfo>(json, "GameModes");
		}
	}
}