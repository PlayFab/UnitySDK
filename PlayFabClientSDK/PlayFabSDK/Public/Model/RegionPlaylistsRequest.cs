using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RegionPlaylistsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// version of build we want to get stats for
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// region we are interested in
		/// </summary>
		
		public Region Region { get; set;}
		
		/// <summary>
		/// is the specific game ID granted by PlayFab via the website, found on the end of the URL once you are logged in and looking at a specific game
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region)JsonUtil.GetEnum<Region>(json, "Region");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
}