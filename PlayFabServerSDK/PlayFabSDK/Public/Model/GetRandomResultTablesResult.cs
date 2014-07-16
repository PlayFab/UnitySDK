using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetRandomResultTablesResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of random result tables currently available
		/// </summary>
		
		public Dictionary<string,RandomResultTable> Tables { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Tables = JsonUtil.GetObjectDictionary<RandomResultTable>(json, "Tables");
		}
	}
}