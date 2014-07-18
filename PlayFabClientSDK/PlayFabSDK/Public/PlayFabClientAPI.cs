using System;
using Pathfinding.Serialization.JsonFx;
using PlayFab.Model;
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
		public delegate void LoginWithGoogleAccountCallback(LoginResult result);
		public delegate void LoginWithIOSDeviceIDCallback(LoginResult result);
		public delegate void LoginWithPlayFabCallback(LoginResult result);
		public delegate void LoginWithSteamCallback(LoginResult result);
		public delegate void RegisterPlayFabUserCallback(RegisterPlayFabUserResult result);
		public delegate void SendAccountRecoveryEmailCallback(SendAccountRecoveryEmailResult result);
		public delegate void GetAccountInfoCallback(GetAccountInfoResult result);
		public delegate void LinkFacebookAccountCallback(LinkFacebookAccountResult result);
		public delegate void LinkGameCenterAccountCallback(LinkGameCenterAccountResult result);
		public delegate void LinkSteamAccountCallback(LinkSteamAccountResult result);
		public delegate void UnlinkFacebookAccountCallback(UnlinkFacebookAccountResult result);
		public delegate void UnlinkGameCenterAccountCallback(UnlinkGameCenterAccountResult result);
		public delegate void UnlinkSteamAccountCallback(UnlinkSteamAccountResult result);
		public delegate void UpdateEmailAddressCallback(UpdateEmailAddressResult result);
		public delegate void UpdatePasswordCallback(UpdatePasswordResult result);
		public delegate void UpdateUserTitleDisplayNameCallback(UpdateUserTitleDisplayNameResult result);
		public delegate void GetUserDataCallback(GetUserDataResult result);
		public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
		public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
		public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
		public delegate void GetTitleDataCallback(GetTitleDataResult result);
		public delegate void GetTitleNewsCallback(GetTitleNewsResult result);
		public delegate void ConfirmPurchaseCallback(ConfirmPurchaseResult result);
		public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
		public delegate void PayForPurchaseCallback(PayForPurchaseResult result);
		public delegate void PurchaseItemCallback(PurchaseItemResult result);
		public delegate void RedeemCouponCallback(RedeemCouponResult result);
		public delegate void StartPurchaseCallback(StartPurchaseResult result);
		public delegate void UnlockContainerItemCallback(UnlockContainerItemResult result);
		public delegate void AddFriendCallback(AddFriendResult result);
		public delegate void GetFriendsListCallback(GetFriendsListResult result);
		public delegate void RemoveFriendCallback(RemoveFriendResult result);
		public delegate void SetFriendTagsCallback(SetFriendTagsResult result);
		public delegate void RegisterForIOSPushNotificationCallback(RegisterForIOSPushNotificationResult result);
		public delegate void ValidateIOSReceiptCallback(ValidateIOSReceiptResult result);
		public delegate void GetCurrentGamesCallback(CurrentGamesResult result);
		public delegate void GetGameServerRegionsCallback(GameServerRegionsResult result);
		public delegate void GetRegionPlaylistsCallback(RegionPlaylistsResult result);
		public delegate void MatchmakeCallback(MatchmakeResult result);
		public delegate void StartGameCallback(StartGameResult result);
		public delegate void AndroidDevicePushNotificationRegistrationCallback(AndroidDevicePushNotificationRegistrationResult result);
		public delegate void ValidateGooglePlayPurchaseCallback(ValidateGooglePlayPurchaseResult result);
		
		
		
		
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
		public static void UnlinkSteamAccount(LinkSteamAccountRequest request, UnlinkSteamAccountCallback resultCallback, ErrorCallback errorCallback)
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
		/// Retrieves the user's current inventory of virtual goods
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
		/// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
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
		/// Validates with the iTunes store that the receipt for an iOS in-app purchase is valid and that it matches the purchased catalog item
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
		/// Get statistics about game server mode playlists.
		/// </summary>
		public static void GetRegionPlaylists(RegionPlaylistsRequest request, GetRegionPlaylistsCallback resultCallback, ErrorCallback errorCallback)
		{
			if (AuthKey == null) throw new Exception ("Must be logged in to call this method");

			string serializedJSON = JsonWriter.Serialize (request, Util.GlobalJsonWriterSettings);
			PlayFabHTTP.HTTPCallback callback = delegate(string responseStr, string errorStr)
			{
				RegionPlaylistsResult result = null;
				PlayFabError error = null;
				ResultContainer<RegionPlaylistsResult>.HandleResults(responseStr, errorStr, out result, out error);
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
			PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetRegionPlaylists", serializedJSON, "X-Authorization", AuthKey, callback);
		}
		
		/// <summary>
		/// Assign the current player to an existing or new game server matching the given parameters and return the connection information.
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
		/// Validates with the GooglePlay store that the receipt for an in-app purchase is valid and that it matches the purchased catalog item
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
		
		
		
		private static string AuthKey = null;
		
	}
}

