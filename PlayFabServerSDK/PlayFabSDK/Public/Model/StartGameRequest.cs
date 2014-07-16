using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class StartGameRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable which is to be started
		/// </summary>
		
		public string Build { get; set;}
		
		/// <summary>
		/// region with which to associate the server, for filtering
		/// </summary>
		
		public Region Region { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		
		public uint GameMode { get; set;}
		
		/// <summary>
		/// IP Address of the external service which should receive status updates for the session
		/// </summary>
		
		public string Subscriber { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Build = (string)JsonUtil.Get<string>(json, "Build");
			Region = (Region)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (uint)JsonUtil.Get<double?>(json, "GameMode");
			Subscriber = (string)JsonUtil.Get<string>(json, "Subscriber");
		}
	}
}