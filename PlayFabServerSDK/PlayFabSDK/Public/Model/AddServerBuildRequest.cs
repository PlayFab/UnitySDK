using System.Collections.Generic;

using System;

namespace PlayFab.Model
{
	
	public class AddServerBuildRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the build executable
		/// </summary>
		
		public string BuildId { get; set;}
		
		/// <summary>
		/// date and time to apply (stamp) to this build (usually current time/date)
		/// </summary>
		
		public DateTime? Timestamp { get; set;}
		
		/// <summary>
		/// is this build currently allowed to be used
		/// </summary>
		
		public bool Active { get; set;}
		
		/// <summary>
		/// is this build intended to run on dedicated ("bare metal") servers
		/// </summary>
		
		public bool DedicatedServerEligible { get; set;}
		
		/// <summary>
		/// Server host regions in which this build can be used
		/// </summary>
		
		public List<string> ActiveRegions { get; set;}
		
		/// <summary>
		/// developer comment(s) for this build
		/// </summary>
		
		public string Comment { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
			Timestamp = (DateTime?)JsonUtil.GetDateTime(json, "Timestamp");
			Active = (bool)JsonUtil.Get<bool?>(json, "Active");
			DedicatedServerEligible = (bool)JsonUtil.Get<bool?>(json, "DedicatedServerEligible");
			ActiveRegions = JsonUtil.GetList<string>(json, "ActiveRegions");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
		}
	}
}