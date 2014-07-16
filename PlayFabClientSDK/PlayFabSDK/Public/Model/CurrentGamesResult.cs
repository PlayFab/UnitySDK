using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class CurrentGamesResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of games the system found
		/// </summary>
		
		public List<GameInfo> Games { get; set;}
		
		/// <summary>
		/// total number of players across all servers
		/// </summary>
		
		public int PlayerCount { get; set;}
		
		/// <summary>
		/// number of games running
		/// </summary>
		
		public int GameCount { get; set;}
		
		/// <summary>
		/// indicates there are some servers it could not get a response for
		/// </summary>
		
		public bool? IncompleteResult { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Games = JsonUtil.GetObjectList<GameInfo>(json, "Games");
			PlayerCount = (int)JsonUtil.Get<double?>(json, "PlayerCount");
			GameCount = (int)JsonUtil.Get<double?>(json, "GameCount");
			IncompleteResult = (bool?)JsonUtil.Get<bool?>(json, "IncompleteResult");
		}
	}
}