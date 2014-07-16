using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RegionPlaylistsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of games in regions found matching the request parameters
		/// </summary>
		
		public List<PlaylistInfo> Playlists { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Playlists = JsonUtil.GetObjectList<PlaylistInfo>(json, "Playlists");
		}
	}
}