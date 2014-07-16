using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class StartGameResponse : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the lobby in the new Game Server Instance
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// region with which the server is associated
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// game mode for this Game Server Instance
		/// </summary>
		
		public uint GameMode { get; set;}
		
		/// <summary>
		/// unique identifier of the previously uploaded build executable which is being started
		/// </summary>
		
		public string Build { get; set;}
		
		/// <summary>
		/// IP address of the new Game Server Instance
		/// </summary>
		
		public string Address { get; set;}
		
		/// <summary>
		/// port number for communication with the Game Server Instance
		/// </summary>
		
		public uint Port { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (uint)JsonUtil.Get<double?>(json, "GameMode");
			Build = (string)JsonUtil.Get<string>(json, "Build");
			Address = (string)JsonUtil.Get<string>(json, "Address");
			Port = (uint)JsonUtil.Get<double?>(json, "Port");
		}
	}
}