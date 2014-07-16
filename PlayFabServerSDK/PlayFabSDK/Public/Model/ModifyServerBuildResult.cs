using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
	public class ModifyServerBuildResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for this build executable
		/// </summary>
		
		public string BuildId { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		
		public bool Active { get; set;}
		
		/// <summary>
		/// array of regions where this build can used, when it is active
		/// </summary>
		
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		
		public string Comment { get; set;}
		
		/// <summary>
		/// time this build was last modified (or uploaded, if this build has never been modified)
		/// </summary>
		
		public DateTime? Timestamp { get; set;}
		
		/// <summary>
		/// the unique identifier for the title, found in the URL on the PlayFab developer site as "TitleId=[n]" when a title has been selected
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
			Active = (bool)JsonUtil.Get<bool?>(json, "Active");
			ActiveRegions = JsonUtil.GetList<string>(json, "ActiveRegions");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
}