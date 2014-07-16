using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class PlaylistInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique id of a playlist
		/// </summary>
		
		public string PlaylistId { get; set;}
		
		/// <summary>
		/// number of games running on this region
		/// </summary>
		
		public uint GameCount { get; set;}
		
		/// <summary>
		/// number of players inside this region
		/// </summary>
		
		public uint GamePlayersCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlaylistId = (string)JsonUtil.Get<string>(json, "PlaylistId");
			GameCount = (uint)JsonUtil.Get<double?>(json, "GameCount");
			GamePlayersCount = (uint)JsonUtil.Get<double?>(json, "GamePlayersCount");
		}
	}
}