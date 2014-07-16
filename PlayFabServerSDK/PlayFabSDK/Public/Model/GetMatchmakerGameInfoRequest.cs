using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class GetMatchmakerGameInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the lobby for which info is being requested
		/// </summary>
		
		public string LobbyId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyId = (string)JsonUtil.Get<string>(json, "LobbyId");
		}
	}
}