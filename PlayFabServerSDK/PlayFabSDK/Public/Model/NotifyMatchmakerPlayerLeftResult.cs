using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class NotifyMatchmakerPlayerLeftResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// state of user leaving the Game Server Instance
		/// </summary>
		
		public PlayerConnectionState? PlayerState { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayerState = (PlayerConnectionState?)JsonUtil.GetEnum<PlayerConnectionState>(json, "PlayerState");
		}
	}
}