using System;
using PlayFab.Serialization.JsonFx;
using PlayFab.ClientModels;
using PlayFab.Internal;

namespace PlayFab
{
	
	/// <summary>
	/// APIs which provide the full range of PlayFab features available to the client - authentication, account and data management, inventory, friends, matchmaking, reporting, and platform-specific functionality
	/// </summary>
	public class PlayFabClientAPI
	{
		public delegate void LoginWithAndroidDeviceIDCallback(LoginResult result);
		public delegate void LoginWithFacebookCallback(LoginResult result);
		public delegate void LoginWithGameCenterCallback(LoginResult result);
		public delegate void LoginWithGoogleAccountCallback(LoginResult result);
		public delegate void LoginWithIOSDeviceIDCallback(LoginResult result);
		public delegate void LoginWithPlayFabCallback(LoginResult result);
		public delegate void LoginWithSteamCallback(LoginResult result);
		public delegate void RegisterPlayFabUserCallback(RegisterPlayFabUserResult result);
		public delegate void AddUsernamePasswordCallback(AddUsernamePasswordResult result);
		public delegate void GetAccountInfoCallback(GetAccountInfoResult result);
		public delegate void GetPlayFabIDsFromFacebookIDsCallback(GetPlayFabIDsFromFacebookIDsResult result);
		public delegate void GetUserCombinedInfoCallback(GetUserCombinedInfoResult result);
		public delegate void LinkFacebookAccountCallback(LinkFacebookAccountResult result);
		public delegate void LinkGameCenterAccountCallback(LinkGameCenterAccountResult result);
		public delegate void LinkSteamAccountCallback(LinkSteamAccountResult result);
		public delegate void SendAccountRecoveryEmailCallback(SendAccountRecoveryEmailResult result);
		public delegate void UnlinkFacebookAccountCallback(UnlinkFacebookAccountResult result);
		public delegate void UnlinkGameCenterAccountCallback(UnlinkGameCenterAccountResult result);
		public delegate void UnlinkSteamAccountCallback(UnlinkSteamAccountResult result);
		public delegate void UpdateEmailAddressCallback(UpdateEmailAddressResult result);
		public delegate void UpdatePasswordCallback(UpdatePasswordResult result);
		public delegate void UpdateUserTitleDisplayNameCallback(UpdateUserTitleDisplayNameResult result);
		public delegate void GetFriendLeaderboardCallback(GetLeaderboardResult result);
		public delegate void GetLeaderboardCallback(GetLeaderboardResult result);
		public delegate void GetLeaderboardAroundCurrentUserCallback(GetLeaderboardAroundCurrentUserResult result);
		public delegate void GetUserDataCallback(GetUserDataResult result);
		public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
		public delegate void GetUserStatisticsCallback(GetUserStatisticsResult result);
		public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
		public delegate void UpdateUserStatisticsCallback(UpdateUserStatisticsResult result);
		public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
		public delegate void GetStoreItemsCallback(GetStoreItemsResult result);
		public delegate void GetTitleDataCallback(GetTitleDataResult result);
		public delegate void GetTitleNewsCallback(GetTitleNewsResult result);
		public delegate void AddUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void ConfirmPurchaseCallback(ConfirmPurchaseResult result);
		public delegate void ConsumeItemCallback(ConsumeItemResult result);
		public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
		public delegate void PayForPurchaseCallback(PayForPurchaseResult result);
		public delegate void PurchaseItemCallback(PurchaseItemResult result);
		public delegate void RedeemCouponCallback(RedeemCouponResult result);
		public delegate void StartPurchaseCallback(StartPurchaseResult result);
		public delegate void SubtractUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
		public delegate void UnlockContainerItemCallback(UnlockContainerItemResult result);
		public delegate void AddFriendCallback(AddFriendResult result);
		public delegate void GetFriendsListCallback(GetFriendsListResult result);
		public delegate void RemoveFriendCallback(RemoveFriendResult result);
		public delegate void SetFriendTagsCallback(SetFriendTagsResult result);
		public delegate void RegisterForIOSPushNotificationCallback(RegisterForIOSPushNotificationResult result);
		public delegate void ValidateIOSReceiptCallback(ValidateIOSReceiptResult result);
		public delegate void GetCurrentGamesCallback(CurrentGamesResult result);
		public delegate void GetGameServerRegionsCallback(GameServerRegionsResult result);
		public delegate void MatchmakeCallback(MatchmakeResult result);
		public delegate void StartGameCallback(StartGameResult result);
		public delegate void AndroidDevicePushNotificationRegistrationCallback(AndroidDevicePushNotificationRegistrationResult result);
		public delegate void ValidateGooglePlayPurchaseCallback(ValidateGooglePlayPurchaseResult result);
		public delegate void LogEventCallback(LogEventResult result);
		public delegate void AddSharedGroupMembersCallback(AddSharedGroupMembersResult result);
		public delegate void CreateSharedGroupCallback(CreateSharedGroupResult result);
		public delegate void GetSharedGroupDataCallback(GetSharedGroupDataResult result);
		public delegate void RemoveSharedGroupMembersCallback(RemoveSharedGroupMembersResult result);
		public delegate void UpdateSharedGroupDataCallback(UpdateSharedGroupDataResult result);
		public delegate void GetCloudScriptUrlCallback(GetCloudScriptUrlResult result);
		public delegate void RunCloudScriptCallback(RunCloudScriptResult result);
		
		
		
		
		/// <summary>
		/// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void LoginWithAndroidDeviceID(LoginWithAndroidDeviceIDRequest request, LoginWithAndroidDeviceIDCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LoginResult result = null;
				PlayFabError error = null;
				ResultContainer<LoginResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithAndroidDeviceID", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Signs the user in using a Facebook access token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void LoginWithFacebook(LoginWithFacebookRequest request, LoginWithFacebookCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LoginResult result = null;
				PlayFabError error = null;
				ResultContainer<LoginResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithFacebook", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Signs the user in using an iOS Game Center player identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void LoginWithGameCenter(LoginWithGameCenterRequest request, LoginWithGameCenterCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LoginResult result = null;
				PlayFabError error = null;
				ResultContainer<LoginResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithGameCenter", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Signs the user in using a Google account access token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void LoginWithGoogleAccount(LoginWithGoogleAccountRequest request, LoginWithGoogleAccountCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LoginResult result = null;
				PlayFabError error = null;
				ResultContainer<LoginResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithGoogleAccount", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Signs the user in using the vendor-specific iOS device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void LoginWithIOSDeviceID(LoginWithIOSDeviceIDRequest request, LoginWithIOSDeviceIDCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LoginResult result = null;
				PlayFabError error = null;
				ResultContainer<LoginResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithIOSDeviceID", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void LoginWithPlayFab(LoginWithPlayFabRequest request, LoginWithPlayFabCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LoginResult result = null;
				PlayFabError error = null;
				ResultContainer<LoginResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithPlayFab", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void LoginWithSteam(LoginWithSteamRequest request, LoginWithSteamCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LoginResult result = null;
				PlayFabError error = null;
				ResultContainer<LoginResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithSteam", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Registers a new Playfab user account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
		/// </summary>
		public static void RegisterPlayFabUser(RegisterPlayFabUserRequest request, RegisterPlayFabUserCallback resultCallback, ErrorCallback errorCallback)
		{
			request.TitleId = PlayFabSettings.TitleId ?? request.TitleId;
			if(request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RegisterPlayFabUserResult result = null;
				PlayFabError error = null;
				ResultContainer<RegisterPlayFabUserResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					AuthKey = result.SessionTicket ?? AuthKey;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RegisterPlayFabUser", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Adds playfab username/password auth to an existing semi-anonymous account created via a 3rd party auth method.
		/// </summary>
		public static void AddUsernamePassword(AddUsernamePasswordRequest request, AddUsernamePasswordCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AddUsernamePasswordResult result = null;
				PlayFabError error = null;
				ResultContainer<AddUsernamePasswordResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddUsernamePassword", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the user's PlayFab account details
		/// </summary>
		public static void GetAccountInfo(GetAccountInfoRequest request, GetAccountInfoCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetAccountInfoResult result = null;
				PlayFabError error = null;
				ResultContainer<GetAccountInfoResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetAccountInfo", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
		/// </summary>
		public static void GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, GetPlayFabIDsFromFacebookIDsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetPlayFabIDsFromFacebookIDsResult result = null;
				PlayFabError error = null;
				ResultContainer<GetPlayFabIDsFromFacebookIDsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPlayFabIDsFromFacebookIDs", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves all requested data for a user in one unified request. By default, this API returns all  data for the locally signed-in user. The input parameters may be used to limit the data retrieved any any subset of the available data, as well as retrieve the available data for a different user. Note that certain data, including inventory, virtual currency balances, and personally identifying information, may only be retrieved for the locally signed-in user. In the example below, a request is made for the account details, virtual currency balances, and specified user data for the locally signed-in user.
		/// </summary>
		public static void GetUserCombinedInfo(GetUserCombinedInfoRequest request, GetUserCombinedInfoCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetUserCombinedInfoResult result = null;
				PlayFabError error = null;
				ResultContainer<GetUserCombinedInfoResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserCombinedInfo", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab account
		/// </summary>
		public static void LinkFacebookAccount(LinkFacebookAccountRequest request, LinkFacebookAccountCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LinkFacebookAccountResult result = null;
				PlayFabError error = null;
				ResultContainer<LinkFacebookAccountResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkFacebookAccount", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account
		/// </summary>
		public static void LinkGameCenterAccount(LinkGameCenterAccountRequest request, LinkGameCenterAccountCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LinkGameCenterAccountResult result = null;
				PlayFabError error = null;
				ResultContainer<LinkGameCenterAccountResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkGameCenterAccount", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab account
		/// </summary>
		public static void LinkSteamAccount(LinkSteamAccountRequest request, LinkSteamAccountCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LinkSteamAccountResult result = null;
				PlayFabError error = null;
				ResultContainer<LinkSteamAccountResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkSteamAccount", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to change the password
		/// </summary>
		public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, SendAccountRecoveryEmailCallback resultCallback, ErrorCallback errorCallback)
		{
			
			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				SendAccountRecoveryEmailResult result = null;
				PlayFabError error = null;
				ResultContainer<SendAccountRecoveryEmailResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/SendAccountRecoveryEmail", serializedJSON, null, null, callback);
		}
		
		/// <summary>
		/// Unlinks the related Facebook account from the user's PlayFab account
		/// </summary>
		public static void UnlinkFacebookAccount(UnlinkFacebookAccountRequest request, UnlinkFacebookAccountCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UnlinkFacebookAccountResult result = null;
				PlayFabError error = null;
				ResultContainer<UnlinkFacebookAccountResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkFacebookAccount", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Unlinks the related Game Center account from the user's PlayFab account
		/// </summary>
		public static void UnlinkGameCenterAccount(UnlinkGameCenterAccountRequest request, UnlinkGameCenterAccountCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UnlinkGameCenterAccountResult result = null;
				PlayFabError error = null;
				ResultContainer<UnlinkGameCenterAccountResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkGameCenterAccount", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Unlinks the related Steam account from the user's PlayFab account
		/// </summary>
		public static void UnlinkSteamAccount(UnlinkSteamAccountRequest request, UnlinkSteamAccountCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UnlinkSteamAccountResult result = null;
				PlayFabError error = null;
				ResultContainer<UnlinkSteamAccountResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkSteamAccount", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Updates the local user's email address in PlayFab
		/// </summary>
		public static void UpdateEmailAddress(UpdateEmailAddressRequest request, UpdateEmailAddressCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateEmailAddressResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateEmailAddressResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateEmailAddress", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Updates the local user's password in PlayFab
		/// </summary>
		public static void UpdatePassword(UpdatePasswordRequest request, UpdatePasswordCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdatePasswordResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdatePasswordResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdatePassword", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Updates the title specific display name for the user
		/// </summary>
		public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, UpdateUserTitleDisplayNameCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UpdateUserTitleDisplayNameResult result = null;
				PlayFabError error = null;
				ResultContainer<UpdateUserTitleDisplayNameResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateUserTitleDisplayName", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked friends of the current player for the given statistic, starting from the indicated point in the leaderboard
		/// </summary>
		public static void GetFriendLeaderboard(GetFriendLeaderboardRequest request, GetFriendLeaderboardCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetFriendLeaderboard", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
		/// </summary>
		public static void GetLeaderboard(GetLeaderboardRequest request, GetLeaderboardCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetLeaderboard", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
		/// </summary>
		public static void GetLeaderboardAroundCurrentUser(GetLeaderboardAroundCurrentUserRequest request, GetLeaderboardAroundCurrentUserCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetLeaderboardAroundCurrentUserResult result = null;
				PlayFabError error = null;
				ResultContainer<GetLeaderboardAroundCurrentUserResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetLeaderboardAroundCurrentUser", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void GetUserData(GetUserDataRequest request, GetUserDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserData", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title-specific custom data for the user which can only be read by the client
		/// </summary>
		public static void GetUserReadOnlyData(GetUserDataRequest request, GetUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserReadOnlyData", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the details of all title-specific statistics for the user
		/// </summary>
		public static void GetUserStatistics(GetUserStatisticsRequest request, GetUserStatisticsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserStatistics", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Creates and updates the title-specific custom data for the user which is readable and writable by the client
		/// </summary>
		public static void UpdateUserData(UpdateUserDataRequest request, UpdateUserDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateUserData", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Updates the values of the specified title-specific statistics for the user
		/// </summary>
		public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, UpdateUserStatisticsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateUserStatistics", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
		/// </summary>
		public static void GetCatalogItems(GetCatalogItemsRequest request, GetCatalogItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCatalogItems", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the set of items defined for the specified store, including all prices defined
		/// </summary>
		public static void GetStoreItems(GetStoreItemsRequest request, GetStoreItemsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetStoreItemsResult result = null;
				PlayFabError error = null;
				ResultContainer<GetStoreItemsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetStoreItems", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the key-value store of custom title settings
		/// </summary>
		public static void GetTitleData(GetTitleDataRequest request, GetTitleDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetTitleData", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the title news feed, as configured in the developer portal
		/// </summary>
		public static void GetTitleNews(GetTitleNewsRequest request, GetTitleNewsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetTitleNewsResult result = null;
				PlayFabError error = null;
				ResultContainer<GetTitleNewsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetTitleNews", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Increments the user's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, AddUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddUserVirtualCurrency", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual currency balances as appropriate
		/// </summary>
		public static void ConfirmPurchase(ConfirmPurchaseRequest request, ConfirmPurchaseCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ConfirmPurchaseResult result = null;
				PlayFabError error = null;
				ResultContainer<ConfirmPurchaseResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ConfirmPurchase", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
		/// </summary>
		public static void ConsumeItem(ConsumeItemRequest request, ConsumeItemCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ConsumeItemResult result = null;
				PlayFabError error = null;
				ResultContainer<ConsumeItemResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ConsumeItem", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the user's current inventory of virtual goods
		/// </summary>
		public static void GetUserInventory(GetUserInventoryRequest request, GetUserInventoryCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserInventory", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Selects a payment option for purchase order created via StartPurchase
		/// </summary>
		public static void PayForPurchase(PayForPurchaseRequest request, PayForPurchaseCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				PayForPurchaseResult result = null;
				PlayFabError error = null;
				ResultContainer<PayForPurchaseResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/PayForPurchase", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
		/// </summary>
		public static void PurchaseItem(PurchaseItemRequest request, PurchaseItemCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				PurchaseItemResult result = null;
				PlayFabError error = null;
				ResultContainer<PurchaseItemResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/PurchaseItem", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Adds the virtual goods associated with the coupon to the user's inventory
		/// </summary>
		public static void RedeemCoupon(RedeemCouponRequest request, RedeemCouponCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RedeemCouponResult result = null;
				PlayFabError error = null;
				ResultContainer<RedeemCouponResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RedeemCoupon", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Creates an order for a list of items from the title catalog
		/// </summary>
		public static void StartPurchase(StartPurchaseRequest request, StartPurchaseCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				StartPurchaseResult result = null;
				PlayFabError error = null;
				ResultContainer<StartPurchaseResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/StartPurchase", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Decrements the user's balance of the specified virtual currency by the stated amount
		/// </summary>
		public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, SubtractUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/SubtractUserVirtualCurrency", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Unlocks a container item in the user's inventory and consumes a key item of the type indicated by the container item
		/// </summary>
		public static void UnlockContainerItem(UnlockContainerItemRequest request, UnlockContainerItemCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				UnlockContainerItemResult result = null;
				PlayFabError error = null;
				ResultContainer<UnlockContainerItemResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlockContainerItem", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user
		/// </summary>
		public static void AddFriend(AddFriendRequest request, AddFriendCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AddFriendResult result = null;
				PlayFabError error = null;
				ResultContainer<AddFriendResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddFriend", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts
		/// </summary>
		public static void GetFriendsList(GetFriendsListRequest request, GetFriendsListCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetFriendsListResult result = null;
				PlayFabError error = null;
				ResultContainer<GetFriendsListResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetFriendsList", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Removes a specified user from the friend list of the local user
		/// </summary>
		public static void RemoveFriend(RemoveFriendRequest request, RemoveFriendCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RemoveFriendResult result = null;
				PlayFabError error = null;
				ResultContainer<RemoveFriendResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RemoveFriend", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Updates the tag list for a specified user in the friend list of the local user
		/// </summary>
		public static void SetFriendTags(SetFriendTagsRequest request, SetFriendTagsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				SetFriendTagsResult result = null;
				PlayFabError error = null;
				ResultContainer<SetFriendTagsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/SetFriendTags", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Registers the iOS device to receive push notifications
		/// </summary>
		public static void RegisterForIOSPushNotification(RegisterForIOSPushNotificationRequest request, RegisterForIOSPushNotificationCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RegisterForIOSPushNotificationResult result = null;
				PlayFabError error = null;
				ResultContainer<RegisterForIOSPushNotificationResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RegisterForIOSPushNotification", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Validates with the Apple store that the receipt for an iOS in-app purchase is valid and that it matches the purchased catalog item
		/// </summary>
		public static void ValidateIOSReceipt(ValidateIOSReceiptRequest request, ValidateIOSReceiptCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ValidateIOSReceiptResult result = null;
				PlayFabError error = null;
				ResultContainer<ValidateIOSReceiptResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ValidateIOSReceipt", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Get details about all current running game servers matching the given parameters.
		/// </summary>
		public static void GetCurrentGames(CurrentGamesRequest request, GetCurrentGamesCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				CurrentGamesResult result = null;
				PlayFabError error = null;
				ResultContainer<CurrentGamesResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCurrentGames", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		///  Get details about the regions hosting game servers matching the given parameters.
		/// </summary>
		public static void GetGameServerRegions(GameServerRegionsRequest request, GetGameServerRegionsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GameServerRegionsResult result = null;
				PlayFabError error = null;
				ResultContainer<GameServerRegionsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetGameServerRegions", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Attempts to locate a game session matching the given parameters. Note that parameters specified in the search are required (they are not weighting factors). If a slot is found in a server instance matching the parameters, the slot will be assigned to that player, removing it from the availabe set. In that case, the information on the game session will be returned, otherwise the Status returned will be GameNotFound. Note that EnableQueue is deprecated at this time.
		/// </summary>
		public static void Matchmake(MatchmakeRequest request, MatchmakeCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				MatchmakeResult result = null;
				PlayFabError error = null;
				ResultContainer<MatchmakeResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/Matchmake", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Start a new game server with a given configuration, add the current player and return the connection information.
		/// </summary>
		public static void StartGame(StartGameRequest request, StartGameCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				StartGameResult result = null;
				PlayFabError error = null;
				ResultContainer<StartGameResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/StartGame", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Registers the Android device to receive push notifications
		/// </summary>
		public static void AndroidDevicePushNotificationRegistration(AndroidDevicePushNotificationRegistrationRequest request, AndroidDevicePushNotificationRegistrationCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				AndroidDevicePushNotificationRegistrationResult result = null;
				PlayFabError error = null;
				ResultContainer<AndroidDevicePushNotificationRegistrationResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AndroidDevicePushNotificationRegistration", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Validates a Google Play purchase and gives the corresponding item to the player.
		/// </summary>
		public static void ValidateGooglePlayPurchase(ValidateGooglePlayPurchaseRequest request, ValidateGooglePlayPurchaseCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				ValidateGooglePlayPurchaseResult result = null;
				PlayFabError error = null;
				ResultContainer<ValidateGooglePlayPurchaseResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ValidateGooglePlayPurchase", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Logs a custom analytics event
		/// </summary>
		public static void LogEvent(LogEventRequest request, LogEventCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				LogEventResult result = null;
				PlayFabError error = null;
				ResultContainer<LogEventResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LogEvent", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group can add new members.
		/// </summary>
		public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, AddSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddSharedGroupMembers", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. Upon creation, the current user will be the only member of the group.
		/// </summary>
		public static void CreateSharedGroup(CreateSharedGroupRequest request, CreateSharedGroupCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/CreateSharedGroup", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Retrieves data stored in a shared group object, as well as the list of members in the group. Non-members of the group may use this to retrieve group data, including membership, but they will not receive data for keys marked as private.
		/// </summary>
		public static void GetSharedGroupData(GetSharedGroupDataRequest request, GetSharedGroupDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetSharedGroupData", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
		/// </summary>
		public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, RemoveSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RemoveSharedGroupMembers", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group can update the data.
		/// </summary>
		public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, UpdateSharedGroupDataCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateSharedGroupData", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Gets the title-specific url for Cloud Script servers. Must be called before making any calls to RunCloudScript.
		/// </summary>
		public static void GetCloudScriptUrl(GetCloudScriptUrlRequest request, GetCloudScriptUrlCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				GetCloudScriptUrlResult result = null;
				PlayFabError error = null;
				ResultContainer<GetCloudScriptUrlResult>.HandleResults(responseStr, errorStr, out result, out error);
				if(error != null && errorCallback != null)
				{
					errorCallback(error);
				}
				if(result != null)
				{
					PlayFabSettings.LogicServerURL = result.Url;

					if(resultCallback != null)
					{
						resultCallback(result);
					}
				}
			};
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCloudScriptUrl", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Triggers a particular server action
		/// </summary>
		public static void RunCloudScript(RunCloudScriptRequest request, RunCloudScriptCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RunCloudScriptResult result = null;
				PlayFabError error = null;
				ResultContainer<RunCloudScriptResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetLogicURL()+"/Client/RunCloudScript", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		
		
		public static string AuthKey = null;
		
	}
}

