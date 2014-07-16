using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class ListBuildsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of uploaded builds
		/// </summary>
		
		public List<GetServerBuildInfoResult> Builds { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Builds = JsonUtil.GetObjectList<GetServerBuildInfoResult>(json, "Builds");
		}
	}
}