using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class CatalogItemConsumableInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// number of times this object can be used
		/// </summary>
		
		public uint UsageCount { get; set;}
		
		/// <summary>
		/// duration of how long this item is viable after player aqquires it (in seconds) (optional)
		/// </summary>
		
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// All items that have the same value in this string get their expiration dates added together.
		/// </summary>
		
		public string UsagePeriodGroup { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UsageCount = (uint)JsonUtil.Get<double?>(json, "UsageCount");
			UsagePeriod = (uint?)JsonUtil.Get<double?>(json, "UsagePeriod");
			UsagePeriodGroup = (string)JsonUtil.Get<string>(json, "UsagePeriodGroup");
		}
	}
}