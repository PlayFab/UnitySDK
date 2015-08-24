using System;
using PlayFab.Json;
using PlayFab.ServerModels;
using PlayFab.Internal;

namespace PlayFab
{
	
	/// <summary>
	/// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a trusted manner, and to handle matchmaking and client connection orchestration
	/// </summary>
	public class PlayFabServerAPI
	{
		public delegate void AuthenticateSessionTicketCallback(AuthenticateSessionTicketResult result);
		public delegate void GetUserAccountInfoCallback(GetUserAccountInfoResult result);
		public delegate void SendPushNotificationCallback(SendPushNotificationResult result);
		public delegate void GetLeaderboardCallback(GetLeaderboardResult result);
		public delegate void GetLeaderboardAroundUserCallback(GetLeaderboardAroundUserResult result);
		public delegate void GetUserDataCallback(GetUserDataResult result);
		public delegate void GetUserInternalDataCallback(GetUserDataResult result);
		public delegate void GetUserPublisherDataCallback(GetUserDataResult result);
		public delegate void GetUserPublisherInternalDataCallback(GetUserDataResult result);
		public delegate void GetUserPublisherReadOnlyDataCallback(GetUserDataResult result);
		public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
		public delegate void GetUserStatisticsCallback(GetUserStatisticsResult result);
		public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserInternalDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserPublisherDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserPublisherInternalDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserPublisherReadOnlyDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserReadOnlyDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserStatisticsCallback(UpdateUserStatisticsResult result);
		public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
		public delegate void GetTitleDataCallback(GetTitleDataResult result);
		public delegate void GetTitleInternalDataCallback(GetTitleDataResult result);
		public delegate void SetTitleDataCallback(SetTitleDataResult result);
		public delegate void SetTitleInternalDataCallback(SetTitleDataResult result);
		public delegate void AddCharacterVirtualCurrencyCallback(ModifyCharacterVirtualCurrencyResult result);
		public delegate void AddUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void GetCharacterInventoryCallback(GetCharacterInventoryResult result);
		public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
		public delegate void GrantItemsToCharacterCallback(GrantItemsToCharacterResult result);
		public delegate void GrantItemsToUserCallback(GrantItemsToUserResult result);
		public delegate void GrantItemsToUsersCallback(GrantItemsToUsersResult result);
		public delegate void ModifyItemUsesCallback(ModifyItemUsesResult result);
		public delegate void MoveItemToCharacterFromCharacterCallback(MoveItemToCharacterFromCharacterResult result);
		public delegate void MoveItemToCharacterFromUserCallback(MoveItemToCharacterFromUserResult result);
		public delegate void MoveItemToUserFromCharacterCallback(MoveItemToUserFromCharacterResult result);
		public delegate void ReportPlayerCallback(ReportPlayerServerResult result);
		public delegate void SubtractCharacterVirtualCurrencyCallback(ModifyCharacterVirtualCurrencyResult result);
		public delegate void SubtractUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void UpdateUserInventoryItemCustomDataCallback(UpdateUserInventoryItemDataResult result);
		public delegate void NotifyMatchmakerPlayerLeftCallback(NotifyMatchmakerPlayerLeftResult result);
		public delegate void RedeemMatchmakerTicketCallback(RedeemMatchmakerTicketResult result);
		public delegate void AwardSteamAchievementCallback(AwardSteamAchievementResult result);
		public delegate void LogEventCallback(LogEventResult result);
		public delegate void AddSharedGroupMembersCallback(AddSharedGroupMembersResult result);
		public delegate void CreateSharedGroupCallback(CreateSharedGroupResult result);
		public delegate void DeleteSharedGroupCallback(EmptyResult result);
		public delegate void GetPublisherDataCallback(GetPublisherDataResult result);
		public delegate void GetSharedGroupDataCallback(GetSharedGroupDataResult result);
		public delegate void RemoveSharedGroupMembersCallback(RemoveSharedGroupMembersResult result);
		public delegate void SetPublisherDataCallback(SetPublisherDataResult result);
		public delegate void UpdateSharedGroupDataCallback(UpdateSharedGroupDataResult result);
		public delegate void GetContentDownloadUrlCallback(GetContentDownloadUrlResult result);
		public delegate void DeleteCharacterFromUserCallback(DeleteCharacterFromUserResult result);
		public delegate void GetAllUsersCharactersCallback(ListUsersCharactersResult result);
		public delegate void GetCharacterLeaderboardCallback(GetCharacterLeaderboardResult result);
		public delegate void GetCharacterStatisticsCallback(GetCharacterStatisticsResult result);
		public delegate void GetLeaderboardAroundCharacterCallback(GetLeaderboardAroundCharacterResult result);
		public delegate void GetLeaderboardForUserCharactersCallback(GetLeaderboardForUsersCharactersResult result);
		public delegate void GrantCharacterToUserCallback(GrantCharacterToUserResult result);
		public delegate void UpdateCharacterStatisticsCallback(UpdateCharacterStatisticsResult result);
		public delegate void GetCharacterDataCallback(GetCharacterDataResult result);
		public delegate void GetCharacterInternalDataCallback(GetCharacterDataResult result);
		public delegate void GetCharacterReadOnlyDataCallback(GetCharacterDataResult result);
		public delegate void UpdateCharacterDataCallback(UpdateCharacterDataResult result);
		public delegate void UpdateCharacterInternalDataCallback(UpdateCharacterDataResult result);
		public delegate void UpdateCharacterReadOnlyDataCallback(UpdateCharacterDataResult result);
		
		
		
		
		/// <summary>
		/// Validated a client's session ticket, and if successful, returns details for that user
		/// </summary>
		public static void AuthenticateSessionTicket(AuthenticateSessionTicketRequest request, AuthenticateSessionTicketCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				AuthenticateSessionTicketResult result = null;
				ResultContainer<AuthenticateSessionTicketResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AuthenticateSessionTicket", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the relevant details for a specified user
		/// </summary>
		public static void GetUserAccountInfo(GetUserAccountInfoRequest request, GetUserAccountInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserAccountInfoResult result = null;
				ResultContainer<GetUserAccountInfoResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserAccountInfo", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
		/// </summary>
		public static void SendPushNotification(SendPushNotificationRequest request, SendPushNotificationCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				SendPushNotificationResult result = null;
				ResultContainer<SendPushNotificationResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SendPushNotification", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
		/// </summary>
		public static void GetLeaderboard(GetLeaderboardRequest request, GetLeaderboardCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetLeaderboardResult result = null;
				ResultContainer<GetLeaderboardResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetLeaderboard", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
		/// </summary>
		public static void GetLeaderboardAroundUser(GetLeaderboardAroundUserRequest request, GetLeaderboardAroundUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetLeaderboardAroundUserResult result = null;
				ResultContainer<GetLeaderboardAroundUserResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetLeaderboardAroundUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void GetUserData(GetUserDataRequest request, GetUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserDataResult result = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void GetUserInternalData(GetUserDataRequest request, GetUserInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserDataResult result = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void GetUserPublisherData(GetUserDataRequest request, GetUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserDataResult result = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserPublisherData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void GetUserPublisherInternalData(GetUserDataRequest request, GetUserPublisherInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserDataResult result = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserPublisherInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the publisher-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, GetUserPublisherReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserDataResult result = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserPublisherReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void GetUserReadOnlyData(GetUserDataRequest request, GetUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserDataResult result = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the details of all title-specific statistics for the user
		/// </summary>
		public static void GetUserStatistics(GetUserStatisticsRequest request, GetUserStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserStatisticsResult result = null;
				ResultContainer<GetUserStatisticsResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserStatistics", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void UpdateUserData(UpdateUserDataRequest request, UpdateUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserDataResult result = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, UpdateUserInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserDataResult result = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the publisher-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void UpdateUserPublisherData(UpdateUserDataRequest request, UpdateUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserDataResult result = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserPublisherData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the publisher-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, UpdateUserPublisherInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserDataResult result = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserPublisherInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the publisher-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, UpdateUserPublisherReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserDataResult result = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserPublisherReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, UpdateUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserDataResult result = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the values of the specified title-specific statistics for the user
		/// </summary>
		public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, UpdateUserStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserStatisticsResult result = null;
				ResultContainer<UpdateUserStatisticsResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserStatistics", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
		/// </summary>
		public static void GetCatalogItems(GetCatalogItemsRequest request, GetCatalogItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetCatalogItemsResult result = null;
				ResultContainer<GetCatalogItemsResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCatalogItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the key-value store of custom title settings
		/// </summary>
		public static void GetTitleData(GetTitleDataRequest request, GetTitleDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetTitleDataResult result = null;
				ResultContainer<GetTitleDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetTitleData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the key-value store of custom internal title settings
		/// </summary>
		public static void GetTitleInternalData(GetTitleDataRequest request, GetTitleInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetTitleDataResult result = null;
				ResultContainer<GetTitleDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetTitleInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the key-value store of custom title settings
		/// </summary>
		public static void SetTitleData(SetTitleDataRequest request, SetTitleDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				SetTitleDataResult result = null;
				ResultContainer<SetTitleDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SetTitleData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the key-value store of custom title settings
		/// </summary>
		public static void SetTitleInternalData(SetTitleDataRequest request, SetTitleInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				SetTitleDataResult result = null;
				ResultContainer<SetTitleDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SetTitleInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Increments  the character's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void AddCharacterVirtualCurrency(AddCharacterVirtualCurrencyRequest request, AddCharacterVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				ModifyCharacterVirtualCurrencyResult result = null;
				ResultContainer<ModifyCharacterVirtualCurrencyResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AddCharacterVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Increments  the user's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, AddUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				ModifyUserVirtualCurrencyResult result = null;
				ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AddUserVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified character's current inventory of virtual goods
		/// </summary>
		public static void GetCharacterInventory(GetCharacterInventoryRequest request, GetCharacterInventoryCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetCharacterInventoryResult result = null;
				ResultContainer<GetCharacterInventoryResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCharacterInventory", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified user's current inventory of virtual goods
		/// </summary>
		public static void GetUserInventory(GetUserInventoryRequest request, GetUserInventoryCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetUserInventoryResult result = null;
				ResultContainer<GetUserInventoryResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserInventory", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds the specified items to the specified character's inventory
		/// </summary>
		public static void GrantItemsToCharacter(GrantItemsToCharacterRequest request, GrantItemsToCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GrantItemsToCharacterResult result = null;
				ResultContainer<GrantItemsToCharacterResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GrantItemsToCharacter", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds the specified items to the specified user's inventory
		/// </summary>
		public static void GrantItemsToUser(GrantItemsToUserRequest request, GrantItemsToUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GrantItemsToUserResult result = null;
				ResultContainer<GrantItemsToUserResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GrantItemsToUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds the specified items to the specified user inventories
		/// </summary>
		public static void GrantItemsToUsers(GrantItemsToUsersRequest request, GrantItemsToUsersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GrantItemsToUsersResult result = null;
				ResultContainer<GrantItemsToUsersResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GrantItemsToUsers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Modifies the number of remaining uses of a player's inventory item
		/// </summary>
		public static void ModifyItemUses(ModifyItemUsesRequest request, ModifyItemUsesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				ModifyItemUsesResult result = null;
				ResultContainer<ModifyItemUsesResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/ModifyItemUses", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Moves an item from a character's inventory into another of the users's character's inventory.
		/// </summary>
		public static void MoveItemToCharacterFromCharacter(MoveItemToCharacterFromCharacterRequest request, MoveItemToCharacterFromCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				MoveItemToCharacterFromCharacterResult result = null;
				ResultContainer<MoveItemToCharacterFromCharacterResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/MoveItemToCharacterFromCharacter", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Moves an item from a user's inventory into their character's inventory.
		/// </summary>
		public static void MoveItemToCharacterFromUser(MoveItemToCharacterFromUserRequest request, MoveItemToCharacterFromUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				MoveItemToCharacterFromUserResult result = null;
				ResultContainer<MoveItemToCharacterFromUserResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/MoveItemToCharacterFromUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Moves an item from a character's inventory into the owning user's inventory.
		/// </summary>
		public static void MoveItemToUserFromCharacter(MoveItemToUserFromCharacterRequest request, MoveItemToUserFromCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				MoveItemToUserFromCharacterResult result = null;
				ResultContainer<MoveItemToUserFromCharacterResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/MoveItemToUserFromCharacter", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially poxic players.
		/// </summary>
		public static void ReportPlayer(ReportPlayerServerRequest request, ReportPlayerCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				ReportPlayerServerResult result = null;
				ResultContainer<ReportPlayerServerResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/ReportPlayer", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Decrements the character's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void SubtractCharacterVirtualCurrency(SubtractCharacterVirtualCurrencyRequest request, SubtractCharacterVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				ModifyCharacterVirtualCurrencyResult result = null;
				ResultContainer<ModifyCharacterVirtualCurrencyResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SubtractCharacterVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Decrements the user's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, SubtractUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				ModifyUserVirtualCurrencyResult result = null;
				ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SubtractUserVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
		/// </summary>
		public static void UpdateUserInventoryItemCustomData(UpdateUserInventoryItemDataRequest request, UpdateUserInventoryItemCustomDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateUserInventoryItemDataResult result = null;
				ResultContainer<UpdateUserInventoryItemDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserInventoryItemCustomData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
		/// </summary>
		public static void NotifyMatchmakerPlayerLeft(NotifyMatchmakerPlayerLeftRequest request, NotifyMatchmakerPlayerLeftCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				NotifyMatchmakerPlayerLeftResult result = null;
				ResultContainer<NotifyMatchmakerPlayerLeftResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/NotifyMatchmakerPlayerLeft", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Validates a Game Server session ticket and returns details about the user
		/// </summary>
		public static void RedeemMatchmakerTicket(RedeemMatchmakerTicketRequest request, RedeemMatchmakerTicketCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				RedeemMatchmakerTicketResult result = null;
				ResultContainer<RedeemMatchmakerTicketResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/RedeemMatchmakerTicket", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Awards the specified users the specified Steam achievements
		/// </summary>
		public static void AwardSteamAchievement(AwardSteamAchievementRequest request, AwardSteamAchievementCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				AwardSteamAchievementResult result = null;
				ResultContainer<AwardSteamAchievementResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AwardSteamAchievement", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Logs a custom analytics event
		/// </summary>
		public static void LogEvent(LogEventRequest request, LogEventCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				LogEventResult result = null;
				ResultContainer<LogEventResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/LogEvent", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
		/// </summary>
		public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, AddSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				AddSharedGroupMembersResult result = null;
				ResultContainer<AddSharedGroupMembersResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AddSharedGroupMembers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
		/// </summary>
		public static void CreateSharedGroup(CreateSharedGroupRequest request, CreateSharedGroupCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				CreateSharedGroupResult result = null;
				ResultContainer<CreateSharedGroupResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/CreateSharedGroup", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Deletes a shared group, freeing up the shared group ID to be reused for a new group
		/// </summary>
		public static void DeleteSharedGroup(DeleteSharedGroupRequest request, DeleteSharedGroupCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				EmptyResult result = null;
				ResultContainer<EmptyResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/DeleteSharedGroup", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the key-value store of custom publisher settings
		/// </summary>
		public static void GetPublisherData(GetPublisherDataRequest request, GetPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetPublisherDataResult result = null;
				ResultContainer<GetPublisherDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetPublisherData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
		/// </summary>
		public static void GetSharedGroupData(GetSharedGroupDataRequest request, GetSharedGroupDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetSharedGroupDataResult result = null;
				ResultContainer<GetSharedGroupDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetSharedGroupData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
		/// </summary>
		public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, RemoveSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				RemoveSharedGroupMembersResult result = null;
				ResultContainer<RemoveSharedGroupMembersResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/RemoveSharedGroupMembers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the key-value store of custom publisher settings
		/// </summary>
		public static void SetPublisherData(SetPublisherDataRequest request, SetPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				SetPublisherDataResult result = null;
				ResultContainer<SetPublisherDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SetPublisherData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
		/// </summary>
		public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, UpdateSharedGroupDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateSharedGroupDataResult result = null;
				ResultContainer<UpdateSharedGroupDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateSharedGroupData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://support.playfab.com/support/discussions/topics/1000059929
		/// </summary>
		public static void GetContentDownloadUrl(GetContentDownloadUrlRequest request, GetContentDownloadUrlCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetContentDownloadUrlResult result = null;
				ResultContainer<GetContentDownloadUrlResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetContentDownloadUrl", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Deletes the specific character ID from the specified user.
		/// </summary>
		public static void DeleteCharacterFromUser(DeleteCharacterFromUserRequest request, DeleteCharacterFromUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				DeleteCharacterFromUserResult result = null;
				ResultContainer<DeleteCharacterFromUserResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/DeleteCharacterFromUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Lists all of the characters that belong to a specific user.
		/// </summary>
		public static void GetAllUsersCharacters(ListUsersCharactersRequest request, GetAllUsersCharactersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				ListUsersCharactersResult result = null;
				ResultContainer<ListUsersCharactersResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetAllUsersCharacters", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
		/// </summary>
		public static void GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, GetCharacterLeaderboardCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetCharacterLeaderboardResult result = null;
				ResultContainer<GetCharacterLeaderboardResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCharacterLeaderboard", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the details of all title-specific statistics for the specific character
		/// </summary>
		public static void GetCharacterStatistics(GetCharacterStatisticsRequest request, GetCharacterStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetCharacterStatisticsResult result = null;
				ResultContainer<GetCharacterStatisticsResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCharacterStatistics", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked characters for the given statistic, centered on the requested user
		/// </summary>
		public static void GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, GetLeaderboardAroundCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetLeaderboardAroundCharacterResult result = null;
				ResultContainer<GetLeaderboardAroundCharacterResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetLeaderboardAroundCharacter", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of all of the user's characters for the given statistic.
		/// </summary>
		public static void GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, GetLeaderboardForUserCharactersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetLeaderboardForUsersCharactersResult result = null;
				ResultContainer<GetLeaderboardForUsersCharactersResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetLeaderboardForUserCharacters", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Grants the specified character type to the user.
		/// </summary>
		public static void GrantCharacterToUser(GrantCharacterToUserRequest request, GrantCharacterToUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GrantCharacterToUserResult result = null;
				ResultContainer<GrantCharacterToUserResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GrantCharacterToUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the values of the specified title-specific statistics for the specific character
		/// </summary>
		public static void UpdateCharacterStatistics(UpdateCharacterStatisticsRequest request, UpdateCharacterStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateCharacterStatisticsResult result = null;
				ResultContainer<UpdateCharacterStatisticsResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateCharacterStatistics", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void GetCharacterData(GetCharacterDataRequest request, GetCharacterDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetCharacterDataResult result = null;
				ResultContainer<GetCharacterDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCharacterData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
		/// </summary>
		public static void GetCharacterInternalData(GetCharacterDataRequest request, GetCharacterInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetCharacterDataResult result = null;
				ResultContainer<GetCharacterDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCharacterInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user's character which can only be read by the client
		/// </summary>
		public static void GetCharacterReadOnlyData(GetCharacterDataRequest request, GetCharacterReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				GetCharacterDataResult result = null;
				ResultContainer<GetCharacterDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCharacterReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
		/// </summary>
		public static void UpdateCharacterData(UpdateCharacterDataRequest request, UpdateCharacterDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateCharacterDataResult result = null;
				ResultContainer<UpdateCharacterDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateCharacterData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
		/// </summary>
		public static void UpdateCharacterInternalData(UpdateCharacterDataRequest request, UpdateCharacterInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateCharacterDataResult result = null;
				ResultContainer<UpdateCharacterDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateCharacterInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user's character which can only be read by the client
		/// </summary>
		public static void UpdateCharacterReadOnlyData(UpdateCharacterDataRequest request, UpdateCharacterReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
			Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
			{
				UpdateCharacterDataResult result = null;
				ResultContainer<UpdateCharacterDataResult>.HandleResults(responseStr, ref pfError, out result);
				if(pfError != null && errorCallback != null)
				{
					errorCallback(pfError);
				}
				if(result != null)
				{
					
					result.CustomData = customData;
					result.Request = request;
					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateCharacterReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		
        

	}
}

