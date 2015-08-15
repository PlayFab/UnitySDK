using System;
using PlayFab.Json;
using PlayFab.MatchmakerModels;
using PlayFab.Internal;

namespace PlayFab
{
	
	/// <summary>
	/// Enables the use of an external match-making service in conjunction with PlayFab hosted Game Server instances
	/// </summary>
	public class PlayFabMatchmakerAPI
	{
		public delegate void AuthUserCallback(AuthUserResponse result);
		public delegate void PlayerJoinedCallback(PlayerJoinedResponse result);
		public delegate void PlayerLeftCallback(PlayerLeftResponse result);
		public delegate void StartGameCallback(StartGameResponse result);
		public delegate void UserInfoCallback(UserInfoResponse result);
		
		
		
		
		/// <summary>
		/// Validates a user with the PlayFab service
		/// </summary>
		public static void AuthUser(AuthUserRequest request, AuthUserCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,string> callback = delegate(string responseStr, string errorStr)
			{
				AuthUserResponse result = null;
				PlayFabError error = null;
				ResultContainer<AuthUserResponse>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/AuthUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Informs the PlayFab game server hosting service that the indicated user has joined the Game Server Instance specified
		/// </summary>
		public static void PlayerJoined(PlayerJoinedRequest request, PlayerJoinedCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,string> callback = delegate(string responseStr, string errorStr)
			{
				PlayerJoinedResponse result = null;
				PlayFabError error = null;
				ResultContainer<PlayerJoinedResponse>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/PlayerJoined", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Informs the PlayFab game server hosting service that the indicated user has left the Game Server Instance specified
		/// </summary>
		public static void PlayerLeft(PlayerLeftRequest request, PlayerLeftCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,string> callback = delegate(string responseStr, string errorStr)
			{
				PlayerLeftResponse result = null;
				PlayFabError error = null;
				ResultContainer<PlayerLeftResponse>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/PlayerLeft", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Instructs the PlayFab game server hosting service to instantiate a new Game Server Instance
		/// </summary>
		public static void StartGame(StartGameRequest request, StartGameCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,string> callback = delegate(string responseStr, string errorStr)
			{
				StartGameResponse result = null;
				PlayFabError error = null;
				ResultContainer<StartGameResponse>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/StartGame", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the relevant details for a specified user, which the external match-making service can then use to compute effective matches
		/// </summary>
		public static void UserInfo(UserInfoRequest request, UserInfoCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,string> callback = delegate(string responseStr, string errorStr)
			{
				UserInfoResponse result = null;
				PlayFabError error = null;
				ResultContainer<UserInfoResponse>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Matchmaker/UserInfo", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		
        
	}
}

