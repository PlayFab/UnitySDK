using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GameModeInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// specific game mode type
		/// </summary>
		
		public string Gamemode { get; set;}
		
		/// <summary>
		/// minimum user count required for this Game Server Instance to continue (usually 1)
		/// </summary>
		
		public uint MinPlayerCount { get; set;}
		
		/// <summary>
		/// maximum user count a specific Game Server Instance can support
		/// </summary>
		
		public uint MaxPlayerCount { get; set;}
		
		/// <summary>
		/// performance cost of a Game Server Instance on a given server TODO what are the values expected?
		/// </summary>
		
		public float PerfCostPerGame { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Gamemode = (string)JsonUtil.Get<string>(json, "Gamemode");
			MinPlayerCount = (uint)JsonUtil.Get<double?>(json, "MinPlayerCount");
			MaxPlayerCount = (uint)JsonUtil.Get<double?>(json, "MaxPlayerCount");
			PerfCostPerGame = (float)JsonUtil.Get<double?>(json, "PerfCostPerGame");
		}
	}
}