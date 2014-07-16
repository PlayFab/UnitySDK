using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class LinkGameCenterAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Game Center identifier for the player account to be linked
		/// </summary>
		
		public string GameCenterId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameCenterId = (string)JsonUtil.Get<string>(json, "GameCenterId");
		}
	}
}