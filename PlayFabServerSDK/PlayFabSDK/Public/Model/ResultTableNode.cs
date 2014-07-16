using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class ResultTableNode : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Whether this entry in the table is an item or a link to another table
		/// </summary>
		
		public ResultTableNodeType ResultItemType { get; set;}
		
		/// <summary>
		/// Either an ItemId, or the TableId of another random result table
		/// </summary>
		
		public string ResultItem { get; set;}
		
		/// <summary>
		/// How likely this is to be rolled - larger numbers add more weight
		/// </summary>
		
		public int Weight { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ResultItemType = (ResultTableNodeType)JsonUtil.GetEnum<ResultTableNodeType>(json, "ResultItemType");
			ResultItem = (string)JsonUtil.Get<string>(json, "ResultItem");
			Weight = (int)JsonUtil.Get<double?>(json, "Weight");
		}
	}
}