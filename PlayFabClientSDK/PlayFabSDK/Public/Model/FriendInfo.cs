using System.Collections.Generic;



namespace PlayFab.Model
{
	
	public class FriendInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this friend
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab unique username for this friend
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific display name for this friend
		/// </summary>
		
		public string TitleDisplayName { get; set;}
		
		/// <summary>
		/// tags which have been associated with this friend
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// unique lobby identifier of the Game Server Instance to which this player is currently connected
		/// </summary>
		
		public string CurrentMatchmakerLobbyId { get; set;}
		
		/// <summary>
		/// available Facebook information (if the user and PlayFab friend are also connected in Facebook)
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// available Steam information (if the user and PlayFab friend are also connected in Steam)
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// available Game Center information (if the user and PlayFab friend are also connected in Game Center)
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleDisplayName = (string)JsonUtil.Get<string>(json, "TitleDisplayName");
			Tags = JsonUtil.GetList<string>(json, "Tags");
			CurrentMatchmakerLobbyId = (string)JsonUtil.Get<string>(json, "CurrentMatchmakerLobbyId");
			FacebookInfo = JsonUtil.GetObject<UserFacebookInfo>(json, "FacebookInfo");
			SteamInfo = JsonUtil.GetObject<UserSteamInfo>(json, "SteamInfo");
			GameCenterInfo = JsonUtil.GetObject<UserGameCenterInfo>(json, "GameCenterInfo");
		}
	}
}