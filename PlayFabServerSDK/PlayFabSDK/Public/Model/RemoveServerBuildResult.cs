using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class RemoveServerBuildResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable to be removed
		/// </summary>
		
		public string BuildId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildId = (string)JsonUtil.Get<string>(json, "BuildId");
		}
	}
}