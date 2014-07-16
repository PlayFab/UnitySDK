using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class UnlockContainerItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the container to attempt to unlock
		/// </summary>
		
		public string ContainerItemId { get; set;}
		
		/// <summary>
		/// catalog version of the container
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ContainerItemId = (string)JsonUtil.Get<string>(json, "ContainerItemId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
}