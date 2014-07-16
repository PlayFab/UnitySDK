using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GameServerRegionsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of regions found matching the request parameters
		/// </summary>
		
		public List<RegionInfo> Regions { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Regions = JsonUtil.GetObjectList<RegionInfo>(json, "Regions");
		}
	}
}