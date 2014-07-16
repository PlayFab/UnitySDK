using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RandomResultTable : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Unique name for this drop table
		/// </summary>
		
		public string TableId { get; set;}
		
		/// <summary>
		/// Child nodes that indicate what kind of drop table item this actually is.
		/// </summary>
		
		public List<ResultTableNode> Nodes { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TableId = (string)JsonUtil.Get<string>(json, "TableId");
			Nodes = JsonUtil.GetObjectList<ResultTableNode>(json, "Nodes");
		}
	}
}