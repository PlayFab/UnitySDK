using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class UpdateRandomResultTablesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of random result tables to make available (Note: specifying an existing TableId will result in overwriting that table, while any others will be added to the available set)
		/// </summary>
		
		public List<RandomResultTable> Tables { get; set;}
		
		/// <summary>
		/// unique identifier of the title for which the tables are to be added
		/// </summary>
		
		public string TitleId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Tables = JsonUtil.GetObjectList<RandomResultTable>(json, "Tables");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
}