using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GameModeInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// mode game server is running in - defaults to 0 if there is only one mode
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// number of game servers running
		/// </summary>
		
		public uint GameCount { get; set;}
		
		/// <summary>
		/// number of plaer
		/// </summary>
		
		public uint GamePlayersCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			GameCount = (uint)JsonUtil.Get<double?>(json, "GameCount");
			GamePlayersCount = (uint)JsonUtil.Get<double?>(json, "GamePlayersCount");
		}
	}
}