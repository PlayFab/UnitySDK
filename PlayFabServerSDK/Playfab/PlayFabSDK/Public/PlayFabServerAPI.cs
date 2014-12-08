using System;
using PlayFab.Serialization.JsonFx;
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
		public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
		public delegate void GetUserStatisticsCallback(GetUserStatisticsResult result);
		public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserInternalDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserReadOnlyDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserStatisticsCallback(UpdateUserStatisticsResult result);
		public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
		public delegate void GetTitleDataCallback(GetTitleDataResult result);
		public delegate void SetTitleDataCallback(SetTitleDataResult result);
		public delegate void AddUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
		public delegate void GrantItemsToUserCallback(GrantItemsToUserResult result);
		public delegate void GrantItemsToUsersCallback(GrantItemsToUsersResult result);
		public delegate void ModifyItemUsesCallback(ModifyItemUsesResult result);
		public delegate void SubtractUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void NotifyMatchmakerPlayerLeftCallback(NotifyMatchmakerPlayerLeftResult result);
		public delegate void RedeemMatchmakerTicketCallback(RedeemMatchmakerTicketResult result);
		public delegate void AwardSteamAchievementCallback(AwardSteamAchievementResult result);
		public delegate void AddSharedGroupMembersCallback(AddSharedGroupMembersResult result);
		public delegate void CreateSharedGroupCallback(CreateSharedGroupResult result);
		public delegate void DeleteSharedGroupCallback(EmptyResult result);
		public delegate void GetSharedGroupDataCallback(GetSharedGroupDataResult result);
		public delegate void RemoveSharedGroupMembersCallback(RemoveSharedGroupMembersResult result);
		public delegate void UpdateSharedGroupDataCallback(UpdateSharedGroupDataResult result);
		
		
		
		
		/// <summary>
		/// Validated a client's session ticket, and if successful, returns details for that user
		/// </summary>
		public static void AuthenticateSessionTicket(AuthenticateSessionTicketRequest request, AuthenticateSessionTicketCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AuthenticateSessionTicketResult result = null;
				PlayFabError error = null;
				ResultContainer<AuthenticateSessionTicketResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AuthenticateSessionTicket", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the relevant details for a specified user
		/// </summary>
		public static void GetUserAccountInfo(GetUserAccountInfoRequest request, GetUserAccountInfoCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserAccountInfoResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserAccountInfoResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserAccountInfo", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
		/// </summary>
		public static void SendPushNotification(SendPushNotificationRequest request, SendPushNotificationCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				SendPushNotificationResult result = null;
				PlayFabError error = null;
				ResultContainer<SendPushNotificationResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SendPushNotification", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
		/// </summary>
		public static void GetLeaderboard(GetLeaderboardRequest request, GetLeaderboardCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetLeaderboardResult result = null;
				PlayFabError error = null;
				ResultContainer<GetLeaderboardResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetLeaderboard", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
		/// </summary>
		public static void GetLeaderboardAroundUser(GetLeaderboardAroundUserRequest request, GetLeaderboardAroundUserCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetLeaderboardAroundUserResult result = null;
				PlayFabError error = null;
				ResultContainer<GetLeaderboardAroundUserResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetLeaderboardAroundUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void GetUserData(GetUserDataRequest request, GetUserDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void GetUserInternalData(GetUserDataRequest request, GetUserInternalDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void GetUserReadOnlyData(GetUserDataRequest request, GetUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the details of all title-specific statistics for the user
		/// </summary>
		public static void GetUserStatistics(GetUserStatisticsRequest request, GetUserStatisticsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserStatisticsResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserStatisticsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserStatistics", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void UpdateUserData(UpdateUserDataRequest request, UpdateUserDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which cannot be accessed by the client
		/// </summary>
		public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, UpdateUserInternalDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserInternalData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the title-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, UpdateUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserDataResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserReadOnlyData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the values of the specified title-specific statistics for the user
		/// </summary>
		public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, UpdateUserStatisticsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserStatisticsResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserStatisticsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateUserStatistics", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
		/// </summary>
		public static void GetCatalogItems(GetCatalogItemsRequest request, GetCatalogItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetCatalogItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<GetCatalogItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetCatalogItems", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the key-value store of custom title settings
		/// </summary>
		public static void GetTitleData(GetTitleDataRequest request, GetTitleDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetTitleDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetTitleDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetTitleData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Updates the key-value store of custom title settings
		/// </summary>
		public static void SetTitleData(SetTitleDataRequest request, SetTitleDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				SetTitleDataResult result = null;
				PlayFabError error = null;
				ResultContainer<SetTitleDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SetTitleData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Increments  the user's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, AddUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ModifyUserVirtualCurrencyResult result = null;
				PlayFabError error = null;
				ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AddUserVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified user's current inventory of virtual goods
		/// </summary>
		public static void GetUserInventory(GetUserInventoryRequest request, GetUserInventoryCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserInventoryResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserInventoryResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetUserInventory", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds the specified items to the specified user's inventory
		/// </summary>
		public static void GrantItemsToUser(GrantItemsToUserRequest request, GrantItemsToUserCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GrantItemsToUserResult result = null;
				PlayFabError error = null;
				ResultContainer<GrantItemsToUserResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GrantItemsToUser", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds the specified items to the specified user inventories
		/// </summary>
		public static void GrantItemsToUsers(GrantItemsToUsersRequest request, GrantItemsToUsersCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GrantItemsToUsersResult result = null;
				PlayFabError error = null;
				ResultContainer<GrantItemsToUsersResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GrantItemsToUsers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Modifies the number of remaining uses of a player's inventory item
		/// </summary>
		public static void ModifyItemUses(ModifyItemUsesRequest request, ModifyItemUsesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ModifyItemUsesResult result = null;
				PlayFabError error = null;
				ResultContainer<ModifyItemUsesResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/ModifyItemUses", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Decrements the user's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, SubtractUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ModifyUserVirtualCurrencyResult result = null;
				PlayFabError error = null;
				ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/SubtractUserVirtualCurrency", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
		/// </summary>
		public static void NotifyMatchmakerPlayerLeft(NotifyMatchmakerPlayerLeftRequest request, NotifyMatchmakerPlayerLeftCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				NotifyMatchmakerPlayerLeftResult result = null;
				PlayFabError error = null;
				ResultContainer<NotifyMatchmakerPlayerLeftResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/NotifyMatchmakerPlayerLeft", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Validates a Game Server session ticket and returns details about the user
		/// </summary>
		public static void RedeemMatchmakerTicket(RedeemMatchmakerTicketRequest request, RedeemMatchmakerTicketCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RedeemMatchmakerTicketResult result = null;
				PlayFabError error = null;
				ResultContainer<RedeemMatchmakerTicketResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/RedeemMatchmakerTicket", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Awards the specified users the specified Steam achievements
		/// </summary>
		public static void AwardSteamAchievement(AwardSteamAchievementRequest request, AwardSteamAchievementCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AwardSteamAchievementResult result = null;
				PlayFabError error = null;
				ResultContainer<AwardSteamAchievementResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AwardSteamAchievement", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
		/// </summary>
		public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, AddSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AddSharedGroupMembersResult result = null;
				PlayFabError error = null;
				ResultContainer<AddSharedGroupMembersResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/AddSharedGroupMembers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
		/// </summary>
		public static void CreateSharedGroup(CreateSharedGroupRequest request, CreateSharedGroupCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				CreateSharedGroupResult result = null;
				PlayFabError error = null;
				ResultContainer<CreateSharedGroupResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/CreateSharedGroup", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Deletes a shared group, freeing up the shared group ID to be reused for a new group
		/// </summary>
		public static void DeleteSharedGroup(DeleteSharedGroupRequest request, DeleteSharedGroupCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				EmptyResult result = null;
				PlayFabError error = null;
				ResultContainer<EmptyResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/DeleteSharedGroup", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
		/// </summary>
		public static void GetSharedGroupData(GetSharedGroupDataRequest request, GetSharedGroupDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetSharedGroupDataResult result = null;
				PlayFabError error = null;
				ResultContainer<GetSharedGroupDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/GetSharedGroupData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
		/// </summary>
		public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, RemoveSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RemoveSharedGroupMembersResult result = null;
				PlayFabError error = null;
				ResultContainer<RemoveSharedGroupMembersResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/RemoveSharedGroupMembers", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		/// <summary>
		/// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
		/// </summary>
		public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, UpdateSharedGroupDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateSharedGroupDataResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateSharedGroupDataResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Server/UpdateSharedGroupData", serializedJSON, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
		}
		
		
		
	}
}

