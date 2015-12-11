using System;
using PlayFab.Json;
using PlayFab.ClientModels;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab
{
    /// <summary>
    /// APIs which provide the full range of PlayFab features available to the client - authentication, account and data management, inventory, friends, matchmaking, reporting, and platform-specific functionality
    /// </summary>
    public static class PlayFabClientAPI
    {
        public delegate void GetPhotonAuthenticationTokenCallback(GetPhotonAuthenticationTokenResult result);
        public delegate void LoginWithAndroidDeviceIDCallback(LoginResult result);
        public delegate void LoginWithCustomIDCallback(LoginResult result);
        public delegate void LoginWithEmailAddressCallback(LoginResult result);
        public delegate void LoginWithFacebookCallback(LoginResult result);
        public delegate void LoginWithGameCenterCallback(LoginResult result);
        public delegate void LoginWithGoogleAccountCallback(LoginResult result);
        public delegate void LoginWithIOSDeviceIDCallback(LoginResult result);
        public delegate void LoginWithKongregateCallback(LoginResult result);
        public delegate void LoginWithPlayFabCallback(LoginResult result);
        public delegate void LoginWithPSNCallback(LoginResult result);
        public delegate void LoginWithSteamCallback(LoginResult result);
        public delegate void LoginWithXboxCallback(LoginResult result);
        public delegate void RegisterPlayFabUserCallback(RegisterPlayFabUserResult result);
        public delegate void AddUsernamePasswordCallback(AddUsernamePasswordResult result);
        public delegate void GetAccountInfoCallback(GetAccountInfoResult result);
        public delegate void GetPlayFabIDsFromFacebookIDsCallback(GetPlayFabIDsFromFacebookIDsResult result);
        public delegate void GetPlayFabIDsFromGameCenterIDsCallback(GetPlayFabIDsFromGameCenterIDsResult result);
        public delegate void GetPlayFabIDsFromGoogleIDsCallback(GetPlayFabIDsFromGoogleIDsResult result);
        public delegate void GetPlayFabIDsFromPSNAccountIDsCallback(GetPlayFabIDsFromPSNAccountIDsResult result);
        public delegate void GetPlayFabIDsFromSteamIDsCallback(GetPlayFabIDsFromSteamIDsResult result);
        public delegate void GetUserCombinedInfoCallback(GetUserCombinedInfoResult result);
        public delegate void LinkAndroidDeviceIDCallback(LinkAndroidDeviceIDResult result);
        public delegate void LinkCustomIDCallback(LinkCustomIDResult result);
        public delegate void LinkFacebookAccountCallback(LinkFacebookAccountResult result);
        public delegate void LinkGameCenterAccountCallback(LinkGameCenterAccountResult result);
        public delegate void LinkGoogleAccountCallback(LinkGoogleAccountResult result);
        public delegate void LinkIOSDeviceIDCallback(LinkIOSDeviceIDResult result);
        public delegate void LinkKongregateCallback(LinkKongregateAccountResult result);
        public delegate void LinkPSNAccountCallback(LinkPSNAccountResult result);
        public delegate void LinkSteamAccountCallback(LinkSteamAccountResult result);
        public delegate void LinkXboxAccountCallback(LinkXboxAccountResult result);
        public delegate void SendAccountRecoveryEmailCallback(SendAccountRecoveryEmailResult result);
        public delegate void UnlinkAndroidDeviceIDCallback(UnlinkAndroidDeviceIDResult result);
        public delegate void UnlinkCustomIDCallback(UnlinkCustomIDResult result);
        public delegate void UnlinkFacebookAccountCallback(UnlinkFacebookAccountResult result);
        public delegate void UnlinkGameCenterAccountCallback(UnlinkGameCenterAccountResult result);
        public delegate void UnlinkGoogleAccountCallback(UnlinkGoogleAccountResult result);
        public delegate void UnlinkIOSDeviceIDCallback(UnlinkIOSDeviceIDResult result);
        public delegate void UnlinkKongregateCallback(UnlinkKongregateAccountResult result);
        public delegate void UnlinkPSNAccountCallback(UnlinkPSNAccountResult result);
        public delegate void UnlinkSteamAccountCallback(UnlinkSteamAccountResult result);
        public delegate void UnlinkXboxAccountCallback(UnlinkXboxAccountResult result);
        public delegate void UpdateUserTitleDisplayNameCallback(UpdateUserTitleDisplayNameResult result);
        public delegate void GetFriendLeaderboardCallback(GetLeaderboardResult result);
        public delegate void GetFriendLeaderboardAroundCurrentUserCallback(GetFriendLeaderboardAroundCurrentUserResult result);
        public delegate void GetLeaderboardCallback(GetLeaderboardResult result);
        public delegate void GetLeaderboardAroundCurrentUserCallback(GetLeaderboardAroundCurrentUserResult result);
        public delegate void GetUserDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherReadOnlyDataCallback(GetUserDataResult result);
        public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
        public delegate void GetUserStatisticsCallback(GetUserStatisticsResult result);
        public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserPublisherDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserStatisticsCallback(UpdateUserStatisticsResult result);
        public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
        public delegate void GetStoreItemsCallback(GetStoreItemsResult result);
        public delegate void GetTitleDataCallback(GetTitleDataResult result);
        public delegate void GetTitleNewsCallback(GetTitleNewsResult result);
        public delegate void AddUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
        public delegate void ConfirmPurchaseCallback(ConfirmPurchaseResult result);
        public delegate void ConsumeItemCallback(ConsumeItemResult result);
        public delegate void GetCharacterInventoryCallback(GetCharacterInventoryResult result);
        public delegate void GetPurchaseCallback(GetPurchaseResult result);
        public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
        public delegate void PayForPurchaseCallback(PayForPurchaseResult result);
        public delegate void PurchaseItemCallback(PurchaseItemResult result);
        public delegate void RedeemCouponCallback(RedeemCouponResult result);
        public delegate void ReportPlayerCallback(ReportPlayerClientResult result);
        public delegate void StartPurchaseCallback(StartPurchaseResult result);
        public delegate void SubtractUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
        public delegate void UnlockContainerItemCallback(UnlockContainerItemResult result);
        public delegate void AddFriendCallback(AddFriendResult result);
        public delegate void GetFriendsListCallback(GetFriendsListResult result);
        public delegate void RemoveFriendCallback(RemoveFriendResult result);
        public delegate void SetFriendTagsCallback(SetFriendTagsResult result);
        public delegate void RegisterForIOSPushNotificationCallback(RegisterForIOSPushNotificationResult result);
        public delegate void RestoreIOSPurchasesCallback(RestoreIOSPurchasesResult result);
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
        public delegate void GetPublisherDataCallback(GetPublisherDataResult result);
        public delegate void GetSharedGroupDataCallback(GetSharedGroupDataResult result);
        public delegate void RemoveSharedGroupMembersCallback(RemoveSharedGroupMembersResult result);
        public delegate void UpdateSharedGroupDataCallback(UpdateSharedGroupDataResult result);
        public delegate void ConsumePSNEntitlementsCallback(ConsumePSNEntitlementsResult result);
        public delegate void RefreshPSNAuthTokenCallback(EmptyResult result);
        public delegate void GetCloudScriptUrlCallback(GetCloudScriptUrlResult result);
        public delegate void RunCloudScriptCallback(RunCloudScriptResult result);
        public delegate void GetContentDownloadUrlCallback(GetContentDownloadUrlResult result);
        public delegate void GetAllUsersCharactersCallback(ListUsersCharactersResult result);
        public delegate void GetCharacterLeaderboardCallback(GetCharacterLeaderboardResult result);
        public delegate void GetLeaderboardAroundCharacterCallback(GetLeaderboardAroundCharacterResult result);
        public delegate void GetLeaderboardForUserCharactersCallback(GetLeaderboardForUsersCharactersResult result);
        public delegate void GrantCharacterToUserCallback(GrantCharacterToUserResult result);
        public delegate void GetCharacterDataCallback(GetCharacterDataResult result);
        public delegate void GetCharacterReadOnlyDataCallback(GetCharacterDataResult result);
        public delegate void UpdateCharacterDataCallback(UpdateCharacterDataResult result);
        public delegate void ValidateAmazonIAPReceiptCallback(ValidateAmazonReceiptResult result);
        public delegate void AcceptTradeCallback(AcceptTradeResponse result);
        public delegate void CancelTradeCallback(CancelTradeResponse result);
        public delegate void GetPlayerTradesCallback(GetPlayerTradesResponse result);
        public delegate void GetTradeStatusCallback(GetTradeStatusResponse result);
        public delegate void OpenTradeCallback(OpenTradeResponse result);
        public delegate void AttributeInstallCallback(AttributeInstallResult result);


        /// <summary>
        /// Gets a Photon custom authentication token that can be used to securely join the player into a Photon room. See https://api.playfab.com/docs/using-photon-with-playfab/ for more details.
        /// </summary>
        public static void GetPhotonAuthenticationToken(GetPhotonAuthenticationTokenRequest request, GetPhotonAuthenticationTokenCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPhotonAuthenticationTokenResult result;
                ResultContainer<GetPhotonAuthenticationTokenResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPhotonAuthenticationToken", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithAndroidDeviceID(LoginWithAndroidDeviceIDRequest request, LoginWithAndroidDeviceIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithAndroidDeviceID", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithCustomID(LoginWithCustomIDRequest request, LoginWithCustomIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithCustomID", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithEmailAddress(LoginWithEmailAddressRequest request, LoginWithEmailAddressCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithEmailAddress", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithFacebook(LoginWithFacebookRequest request, LoginWithFacebookCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithFacebook", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithGameCenter(LoginWithGameCenterRequest request, LoginWithGameCenterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithGameCenter", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using a Google account access token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithGoogleAccount(LoginWithGoogleAccountRequest request, LoginWithGoogleAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithGoogleAccount", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using the vendor-specific iOS device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithIOSDeviceID(LoginWithIOSDeviceIDRequest request, LoginWithIOSDeviceIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithIOSDeviceID", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using a Kongregate player account.
        /// </summary>
        public static void LoginWithKongregate(LoginWithKongregateRequest request, LoginWithKongregateCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithKongregate", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithPlayFab(LoginWithPlayFabRequest request, LoginWithPlayFabCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithPlayFab", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using a PlayStation Network authentication code, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithPSN(LoginWithPSNRequest request, LoginWithPSNCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithPSN", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithSteam(LoginWithSteamRequest request, LoginWithSteamCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithSteam", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Signs the user in using a Xbox Live Token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithXbox(LoginWithXboxRequest request, LoginWithXboxCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LoginResult result;
                ResultContainer<LoginResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LoginWithXbox", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Registers a new Playfab user account, returning a session identifier that can subsequently be used for API calls which require an authenticated user. You must supply either a username or an email address.
        /// </summary>
        public static void RegisterPlayFabUser(RegisterPlayFabUserRequest request, RegisterPlayFabUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception ("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RegisterPlayFabUserResult result;
                ResultContainer<RegisterPlayFabUserResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    _authKey = result.SessionTicket ?? _authKey;
                    MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RegisterPlayFabUser", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Adds playfab username/password auth to an existing semi-anonymous account created via a 3rd party auth method.
        /// </summary>
        public static void AddUsernamePassword(AddUsernamePasswordRequest request, AddUsernamePasswordCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AddUsernamePasswordResult result;
                ResultContainer<AddUsernamePasswordResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddUsernamePassword", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the user's PlayFab account details
        /// </summary>
        public static void GetAccountInfo(GetAccountInfoRequest request, GetAccountInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetAccountInfoResult result;
                ResultContainer<GetAccountInfoResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetAccountInfo", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, GetPlayFabIDsFromFacebookIDsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPlayFabIDsFromFacebookIDsResult result;
                ResultContainer<GetPlayFabIDsFromFacebookIDsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPlayFabIDsFromFacebookIDs", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Game Center identifiers (referenced in the Game Center Programming Guide as the Player Identifier).
        /// </summary>
        public static void GetPlayFabIDsFromGameCenterIDs(GetPlayFabIDsFromGameCenterIDsRequest request, GetPlayFabIDsFromGameCenterIDsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPlayFabIDsFromGameCenterIDsResult result;
                ResultContainer<GetPlayFabIDsFromGameCenterIDsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPlayFabIDsFromGameCenterIDs", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google identifiers. The Google identifiers are the IDs for the user accounts, available as "id" in the Google+ People API calls.
        /// </summary>
        public static void GetPlayFabIDsFromGoogleIDs(GetPlayFabIDsFromGoogleIDsRequest request, GetPlayFabIDsFromGoogleIDsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPlayFabIDsFromGoogleIDsResult result;
                ResultContainer<GetPlayFabIDsFromGoogleIDsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPlayFabIDsFromGoogleIDs", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of PlayStation Network identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromPSNAccountIDs(GetPlayFabIDsFromPSNAccountIDsRequest request, GetPlayFabIDsFromPSNAccountIDsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPlayFabIDsFromPSNAccountIDsResult result;
                ResultContainer<GetPlayFabIDsFromPSNAccountIDsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPlayFabIDsFromPSNAccountIDs", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public static void GetPlayFabIDsFromSteamIDs(GetPlayFabIDsFromSteamIDsRequest request, GetPlayFabIDsFromSteamIDsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPlayFabIDsFromSteamIDsResult result;
                ResultContainer<GetPlayFabIDsFromSteamIDsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPlayFabIDsFromSteamIDs", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves all requested data for a user in one unified request. By default, this API returns all  data for the locally signed-in user. The input parameters may be used to limit the data retrieved to any subset of the available data, as well as retrieve the available data for a different user. Note that certain data, including inventory, virtual currency balances, and personally identifying information, may only be retrieved for the locally signed-in user. In the example below, a request is made for the account details, virtual currency balances, and specified user data for the locally signed-in user.
        /// </summary>
        public static void GetUserCombinedInfo(GetUserCombinedInfoRequest request, GetUserCombinedInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetUserCombinedInfoResult result;
                ResultContainer<GetUserCombinedInfoResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserCombinedInfo", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the Android device identifier to the user's PlayFab account
        /// </summary>
        public static void LinkAndroidDeviceID(LinkAndroidDeviceIDRequest request, LinkAndroidDeviceIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkAndroidDeviceIDResult result;
                ResultContainer<LinkAndroidDeviceIDResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkAndroidDeviceID", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the custom identifier, generated by the title, to the user's PlayFab account
        /// </summary>
        public static void LinkCustomID(LinkCustomIDRequest request, LinkCustomIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkCustomIDResult result;
                ResultContainer<LinkCustomIDResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkCustomID", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab account
        /// </summary>
        public static void LinkFacebookAccount(LinkFacebookAccountRequest request, LinkFacebookAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkFacebookAccountResult result;
                ResultContainer<LinkFacebookAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkFacebookAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account
        /// </summary>
        public static void LinkGameCenterAccount(LinkGameCenterAccountRequest request, LinkGameCenterAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkGameCenterAccountResult result;
                ResultContainer<LinkGameCenterAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkGameCenterAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the currently signed-in user account to the Google account specified by the Google account access token
        /// </summary>
        public static void LinkGoogleAccount(LinkGoogleAccountRequest request, LinkGoogleAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkGoogleAccountResult result;
                ResultContainer<LinkGoogleAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkGoogleAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's PlayFab account
        /// </summary>
        public static void LinkIOSDeviceID(LinkIOSDeviceIDRequest request, LinkIOSDeviceIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkIOSDeviceIDResult result;
                ResultContainer<LinkIOSDeviceIDResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkIOSDeviceID", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the Kongregate identifier to the user's PlayFab account
        /// </summary>
        public static void LinkKongregate(LinkKongregateAccountRequest request, LinkKongregateCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkKongregateAccountResult result;
                ResultContainer<LinkKongregateAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkKongregate", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the PlayStation Network account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static void LinkPSNAccount(LinkPSNAccountRequest request, LinkPSNAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkPSNAccountResult result;
                ResultContainer<LinkPSNAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkPSNAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab account
        /// </summary>
        public static void LinkSteamAccount(LinkSteamAccountRequest request, LinkSteamAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkSteamAccountResult result;
                ResultContainer<LinkSteamAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkSteamAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Links the Xbox Live account associated with the provided access code to the user's PlayFab account
        /// </summary>
        public static void LinkXboxAccount(LinkXboxAccountRequest request, LinkXboxAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LinkXboxAccountResult result;
                ResultContainer<LinkXboxAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LinkXboxAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to change the password
        /// </summary>
        public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, SendAccountRecoveryEmailCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            
            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                SendAccountRecoveryEmailResult result;
                ResultContainer<SendAccountRecoveryEmailResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/SendAccountRecoveryEmail", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Unlinks the related Android device identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkAndroidDeviceID(UnlinkAndroidDeviceIDRequest request, UnlinkAndroidDeviceIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkAndroidDeviceIDResult result;
                ResultContainer<UnlinkAndroidDeviceIDResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkAndroidDeviceID", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related custom identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkCustomID(UnlinkCustomIDRequest request, UnlinkCustomIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkCustomIDResult result;
                ResultContainer<UnlinkCustomIDResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkCustomID", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related Facebook account from the user's PlayFab account
        /// </summary>
        public static void UnlinkFacebookAccount(UnlinkFacebookAccountRequest request, UnlinkFacebookAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkFacebookAccountResult result;
                ResultContainer<UnlinkFacebookAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkFacebookAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related Game Center account from the user's PlayFab account
        /// </summary>
        public static void UnlinkGameCenterAccount(UnlinkGameCenterAccountRequest request, UnlinkGameCenterAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkGameCenterAccountResult result;
                ResultContainer<UnlinkGameCenterAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkGameCenterAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related Google account from the user's PlayFab account
        /// </summary>
        public static void UnlinkGoogleAccount(UnlinkGoogleAccountRequest request, UnlinkGoogleAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkGoogleAccountResult result;
                ResultContainer<UnlinkGoogleAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkGoogleAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkIOSDeviceID(UnlinkIOSDeviceIDRequest request, UnlinkIOSDeviceIDCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkIOSDeviceIDResult result;
                ResultContainer<UnlinkIOSDeviceIDResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkIOSDeviceID", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related Kongregate identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkKongregate(UnlinkKongregateAccountRequest request, UnlinkKongregateCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkKongregateAccountResult result;
                ResultContainer<UnlinkKongregateAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkKongregate", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related PSN account from the user's PlayFab account
        /// </summary>
        public static void UnlinkPSNAccount(UnlinkPSNAccountRequest request, UnlinkPSNAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkPSNAccountResult result;
                ResultContainer<UnlinkPSNAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkPSNAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related Steam account from the user's PlayFab account
        /// </summary>
        public static void UnlinkSteamAccount(UnlinkSteamAccountRequest request, UnlinkSteamAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkSteamAccountResult result;
                ResultContainer<UnlinkSteamAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkSteamAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlinks the related Xbox Live account from the user's PlayFab account
        /// </summary>
        public static void UnlinkXboxAccount(UnlinkXboxAccountRequest request, UnlinkXboxAccountCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlinkXboxAccountResult result;
                ResultContainer<UnlinkXboxAccountResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlinkXboxAccount", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Updates the title specific display name for the user
        /// </summary>
        public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, UpdateUserTitleDisplayNameCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateUserTitleDisplayNameResult result;
                ResultContainer<UpdateUserTitleDisplayNameResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateUserTitleDisplayName", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetFriendLeaderboard(GetFriendLeaderboardRequest request, GetFriendLeaderboardCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetLeaderboardResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetFriendLeaderboard", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetFriendLeaderboardAroundCurrentUser(GetFriendLeaderboardAroundCurrentUserRequest request, GetFriendLeaderboardAroundCurrentUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetFriendLeaderboardAroundCurrentUserResult result;
                ResultContainer<GetFriendLeaderboardAroundCurrentUserResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetFriendLeaderboardAroundCurrentUser", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetLeaderboard(GetLeaderboardRequest request, GetLeaderboardCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetLeaderboardResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetLeaderboard", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetLeaderboardAroundCurrentUser(GetLeaderboardAroundCurrentUserRequest request, GetLeaderboardAroundCurrentUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetLeaderboardAroundCurrentUserResult result;
                ResultContainer<GetLeaderboardAroundCurrentUserResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetLeaderboardAroundCurrentUser", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, GetUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetUserDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, GetUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetUserDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserPublisherData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, GetUserPublisherReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetUserDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserPublisherReadOnlyData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, GetUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetUserDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserReadOnlyData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public static void GetUserStatistics(GetUserStatisticsRequest request, GetUserStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetUserStatisticsResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserStatistics", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, UpdateUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateUserDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateUserData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Creates and updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, UpdateUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateUserDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateUserPublisherData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, UpdateUserStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateUserStatisticsResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateUserStatistics", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, GetCatalogItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCatalogItemsResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCatalogItems", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static void GetStoreItems(GetStoreItemsRequest request, GetStoreItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetStoreItemsResult result;
                ResultContainer<GetStoreItemsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetStoreItems", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, GetTitleDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetTitleDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetTitleData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public static void GetTitleNews(GetTitleNewsRequest request, GetTitleNewsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetTitleNewsResult result;
                ResultContainer<GetTitleNewsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetTitleNews", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, AddUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ModifyUserVirtualCurrencyResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddUserVirtualCurrency", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual currency balances as appropriate
        /// </summary>
        public static void ConfirmPurchase(ConfirmPurchaseRequest request, ConfirmPurchaseCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ConfirmPurchaseResult result;
                ResultContainer<ConfirmPurchaseResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ConfirmPurchase", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public static void ConsumeItem(ConsumeItemRequest request, ConsumeItemCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ConsumeItemResult result;
                ResultContainer<ConsumeItemResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ConsumeItem", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static void GetCharacterInventory(GetCharacterInventoryRequest request, GetCharacterInventoryCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCharacterInventoryResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCharacterInventory", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a completed purchase along with its current PlayFab status.
        /// </summary>
        public static void GetPurchase(GetPurchaseRequest request, GetPurchaseCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPurchaseResult result;
                ResultContainer<GetPurchaseResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPurchase", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, GetUserInventoryCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetUserInventoryResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetUserInventory", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Selects a payment option for purchase order created via StartPurchase
        /// </summary>
        public static void PayForPurchase(PayForPurchaseRequest request, PayForPurchaseCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                PayForPurchaseResult result;
                ResultContainer<PayForPurchaseResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/PayForPurchase", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        public static void PurchaseItem(PurchaseItemRequest request, PurchaseItemCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                PurchaseItemResult result;
                ResultContainer<PurchaseItemResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/PurchaseItem", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/using-stores-and-coupons-game-manager/
        /// </summary>
        public static void RedeemCoupon(RedeemCouponRequest request, RedeemCouponCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RedeemCouponResult result;
                ResultContainer<RedeemCouponResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RedeemCoupon", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Submit a report for another player (due to bad bahavior, etc.), so that customer service representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        public static void ReportPlayer(ReportPlayerClientRequest request, ReportPlayerCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ReportPlayerClientResult result;
                ResultContainer<ReportPlayerClientResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ReportPlayer", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Creates an order for a list of items from the title catalog
        /// </summary>
        public static void StartPurchase(StartPurchaseRequest request, StartPurchaseCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                StartPurchaseResult result;
                ResultContainer<StartPurchaseResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/StartPurchase", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, SubtractUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ModifyUserVirtualCurrencyResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/SubtractUserVirtualCurrency", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Unlocks a container item in the user's inventory and consumes a key item of the type indicated by the container item
        /// </summary>
        public static void UnlockContainerItem(UnlockContainerItemRequest request, UnlockContainerItemCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UnlockContainerItemResult result;
                ResultContainer<UnlockContainerItemResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UnlockContainerItem", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user. At least one of FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        public static void AddFriend(AddFriendRequest request, AddFriendCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AddFriendResult result;
                ResultContainer<AddFriendResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddFriend", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts. Friends from linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        public static void GetFriendsList(GetFriendsListRequest request, GetFriendsListCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetFriendsListResult result;
                ResultContainer<GetFriendsListResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetFriendsList", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        public static void RemoveFriend(RemoveFriendRequest request, RemoveFriendCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RemoveFriendResult result;
                ResultContainer<RemoveFriendResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RemoveFriend", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of the local user
        /// </summary>
        public static void SetFriendTags(SetFriendTagsRequest request, SetFriendTagsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                SetFriendTagsResult result;
                ResultContainer<SetFriendTagsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/SetFriendTags", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Registers the iOS device to receive push notifications
        /// </summary>
        public static void RegisterForIOSPushNotification(RegisterForIOSPushNotificationRequest request, RegisterForIOSPushNotificationCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RegisterForIOSPushNotificationResult result;
                ResultContainer<RegisterForIOSPushNotificationResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RegisterForIOSPushNotification", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Restores all in-app purchases based on the given refresh receipt.
        /// </summary>
        public static void RestoreIOSPurchases(RestoreIOSPurchasesRequest request, RestoreIOSPurchasesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RestoreIOSPurchasesResult result;
                ResultContainer<RestoreIOSPurchasesResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RestoreIOSPurchases", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Validates with the Apple store that the receipt for an iOS in-app purchase is valid and that it matches the purchased catalog item
        /// </summary>
        public static void ValidateIOSReceipt(ValidateIOSReceiptRequest request, ValidateIOSReceiptCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ValidateIOSReceiptResult result;
                ResultContainer<ValidateIOSReceiptResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ValidateIOSReceipt", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Get details about all current running game servers matching the given parameters.
        /// </summary>
        public static void GetCurrentGames(CurrentGamesRequest request, GetCurrentGamesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                CurrentGamesResult result;
                ResultContainer<CurrentGamesResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCurrentGames", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        ///  Get details about the regions hosting game servers matching the given parameters.
        /// </summary>
        public static void GetGameServerRegions(GameServerRegionsRequest request, GetGameServerRegionsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GameServerRegionsResult result;
                ResultContainer<GameServerRegionsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetGameServerRegions", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Attempts to locate a game session matching the given parameters. Note that parameters specified in the search are required (they are not weighting factors). If a slot is found in a server instance matching the parameters, the slot will be assigned to that player, removing it from the availabe set. In that case, the information on the game session will be returned, otherwise the Status returned will be GameNotFound. Note that EnableQueue is deprecated at this time.
        /// </summary>
        public static void Matchmake(MatchmakeRequest request, MatchmakeCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                MatchmakeResult result;
                ResultContainer<MatchmakeResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/Matchmake", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Start a new game server with a given configuration, add the current player and return the connection information.
        /// </summary>
        public static void StartGame(StartGameRequest request, StartGameCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                StartGameResult result;
                ResultContainer<StartGameResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/StartGame", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Registers the Android device to receive push notifications
        /// </summary>
        public static void AndroidDevicePushNotificationRegistration(AndroidDevicePushNotificationRegistrationRequest request, AndroidDevicePushNotificationRegistrationCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AndroidDevicePushNotificationRegistrationResult result;
                ResultContainer<AndroidDevicePushNotificationRegistrationResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AndroidDevicePushNotificationRegistration", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Validates a Google Play purchase and gives the corresponding item to the player.
        /// </summary>
        public static void ValidateGooglePlayPurchase(ValidateGooglePlayPurchaseRequest request, ValidateGooglePlayPurchaseCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ValidateGooglePlayPurchaseResult result;
                ResultContainer<ValidateGooglePlayPurchaseResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ValidateGooglePlayPurchase", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Logs a custom analytics event
        /// </summary>
        public static void LogEvent(LogEventRequest request, LogEventCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LogEventResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/LogEvent", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group can add new members.
        /// </summary>
        public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, AddSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AddSharedGroupMembersResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AddSharedGroupMembers", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. Upon creation, the current user will be the only member of the group.
        /// </summary>
        public static void CreateSharedGroup(CreateSharedGroupRequest request, CreateSharedGroupCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                CreateSharedGroupResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/CreateSharedGroup", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, GetPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPublisherDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPublisherData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. Non-members of the group may use this to retrieve group data, including membership, but they will not receive data for keys marked as private.
        /// </summary>
        public static void GetSharedGroupData(GetSharedGroupDataRequest request, GetSharedGroupDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetSharedGroupDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetSharedGroupData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
        /// </summary>
        public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, RemoveSharedGroupMembersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RemoveSharedGroupMembersResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RemoveSharedGroupMembers", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group can update the data.
        /// </summary>
        public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, UpdateSharedGroupDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateSharedGroupDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateSharedGroupData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Checks for any new consumable entitlements. If any are found, they are consumed and added as PlayFab items
        /// </summary>
        public static void ConsumePSNEntitlements(ConsumePSNEntitlementsRequest request, ConsumePSNEntitlementsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ConsumePSNEntitlementsResult result;
                ResultContainer<ConsumePSNEntitlementsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ConsumePSNEntitlements", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Uses the supplied OAuth code to refresh the internally cached player PSN auth token
        /// </summary>
        public static void RefreshPSNAuthToken(RefreshPSNAuthTokenRequest request, RefreshPSNAuthTokenCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                EmptyResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/RefreshPSNAuthToken", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific URL for Cloud Script servers. This must be queried once, prior  to making any calls to RunCloudScript.
        /// </summary>
        public static void GetCloudScriptUrl(GetCloudScriptUrlRequest request, GetCloudScriptUrlCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCloudScriptUrlResult result;
                ResultContainer<GetCloudScriptUrlResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    PlayFabSettings.LogicServerURL = result.Url;

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCloudScriptUrl", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Triggers a particular server action, passing the provided inputs to the hosted Cloud Script. An action in this context is a handler in the JavaScript. NOTE: Before calling this API, you must call GetCloudScriptUrl to be assigned a Cloud Script server URL. When using an official PlayFab SDK, this URL is stored internally in the SDK, but GetCloudScriptUrl must still be manually called.
        /// </summary>
        public static void RunCloudScript(RunCloudScriptRequest request, RunCloudScriptCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RunCloudScriptResult result;
                ResultContainer<RunCloudScriptResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetLogicURL()+"/Client/RunCloudScript", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://support.playfab.com/support/discussions/topics/1000059929
        /// </summary>
        public static void GetContentDownloadUrl(GetContentDownloadUrlRequest request, GetContentDownloadUrlCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetContentDownloadUrlResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetContentDownloadUrl", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user.
        /// </summary>
        public static void GetAllUsersCharacters(ListUsersCharactersRequest request, GetAllUsersCharactersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ListUsersCharactersResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetAllUsersCharacters", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, GetCharacterLeaderboardCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCharacterLeaderboardResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCharacterLeaderboard", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, GetLeaderboardAroundCharacterCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetLeaderboardAroundCharacterResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetLeaderboardAroundCharacter", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static void GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, GetLeaderboardForUserCharactersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetLeaderboardForUsersCharactersResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetLeaderboardForUserCharacters", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Grants the specified character type to the user.
        /// </summary>
        public static void GrantCharacterToUser(GrantCharacterToUserRequest request, GrantCharacterToUserCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GrantCharacterToUserResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GrantCharacterToUser", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which is readable and writable by the client
        /// </summary>
        public static void GetCharacterData(GetCharacterDataRequest request, GetCharacterDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCharacterDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCharacterData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which can only be read by the client
        /// </summary>
        public static void GetCharacterReadOnlyData(GetCharacterDataRequest request, GetCharacterReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCharacterDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetCharacterReadOnlyData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user's character which is readable  and writable by the client
        /// </summary>
        public static void UpdateCharacterData(UpdateCharacterDataRequest request, UpdateCharacterDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateCharacterDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/UpdateCharacterData", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Validates with Amazon that the receipt for an Amazon App Store in-app purchase is valid and that it matches the purchased catalog item
        /// </summary>
        public static void ValidateAmazonIAPReceipt(ValidateAmazonReceiptRequest request, ValidateAmazonIAPReceiptCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ValidateAmazonReceiptResult result;
                ResultContainer<ValidateAmazonReceiptResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/ValidateAmazonIAPReceipt", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Accepts an open trade. If the call is successful, the offered and accepted items will be swapped between the two players' inventories.
        /// </summary>
        public static void AcceptTrade(AcceptTradeRequest request, AcceptTradeCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AcceptTradeResponse result;
                ResultContainer<AcceptTradeResponse>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AcceptTrade", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Cancels an open trade.
        /// </summary>
        public static void CancelTrade(CancelTradeRequest request, CancelTradeCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                CancelTradeResponse result;
                ResultContainer<CancelTradeResponse>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/CancelTrade", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Gets all trades the player has either opened or accepted, optionally filtered by trade status.
        /// </summary>
        public static void GetPlayerTrades(GetPlayerTradesRequest request, GetPlayerTradesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetPlayerTradesResponse result;
                ResultContainer<GetPlayerTradesResponse>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetPlayerTrades", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Gets the current status of an existing trade.
        /// </summary>
        public static void GetTradeStatus(GetTradeStatusRequest request, GetTradeStatusCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetTradeStatusResponse result;
                ResultContainer<GetTradeStatusResponse>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/GetTradeStatus", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Opens a new outstanding trade.
        /// </summary>
        public static void OpenTrade(OpenTradeRequest request, OpenTradeCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                OpenTradeResponse result;
                ResultContainer<OpenTradeResponse>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/OpenTrade", serializedJson, "X-Authorization", _authKey, callback);
        }

        /// <summary>
        /// Attributes an install for advertisment.
        /// </summary>
        public static void AttributeInstall(AttributeInstallRequest request, AttributeInstallCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception ("Must be logged in to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AttributeInstallResult result;
                ResultContainer<AttributeInstallResult>.HandleResults(responseStr, ref pfError, out result);
                if(pfError != null && errorCallback != null)
                {
                    errorCallback(pfError);
                }
                if(result != null)
                {
                    PlayFabSettings.AdvertisingIdType += "_Successful";

                    result.CustomData = customData;
                    result.Request = request;
                    if(resultCallback != null)
                    {
                        resultCallback(result);
                    }
                }
            };
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Client/AttributeInstall", serializedJson, "X-Authorization", _authKey, callback);
        }

        private static string _authKey = null;
        // Determine if the _authKey is set, without actually making it public
        public static bool IsClientLoggedIn()
        {
            return !string.IsNullOrEmpty(_authKey);
        }

        private static void MultiStepClientLogin(bool needsAttribution)
        {
            // Automatically try to fetch the ID
            if (needsAttribution && !PlayFab.PlayFabSettings.DisableAdvertising && string.IsNullOrEmpty(PlayFab.PlayFabSettings.AdvertisingIdType) && string.IsNullOrEmpty(PlayFab.PlayFabSettings.AdvertisingIdValue))
                GetAdvertisingId(out PlayFab.PlayFabSettings.AdvertisingIdType, out PlayFab.PlayFabSettings.AdvertisingIdValue, ref PlayFab.PlayFabSettings.DisableAdvertising);

            // Send the ID when appropriate
            if (needsAttribution && !PlayFab.PlayFabSettings.DisableAdvertising && !string.IsNullOrEmpty(PlayFab.PlayFabSettings.AdvertisingIdType) && !string.IsNullOrEmpty(PlayFab.PlayFabSettings.AdvertisingIdValue))
            {
                AttributeInstallRequest request = new AttributeInstallRequest();
                if (PlayFab.PlayFabSettings.AdvertisingIdType == PlayFab.PlayFabSettings.AD_TYPE_IDFA)
                    request.Idfa = PlayFab.PlayFabSettings.AdvertisingIdValue;
                else if (PlayFab.PlayFabSettings.AdvertisingIdType == PlayFab.PlayFabSettings.AD_TYPE_ANDROID_ID)
                    request.Android_Id = PlayFab.PlayFabSettings.AdvertisingIdValue;
                else
                    return;
                AttributeInstall(request, null, null);
            }
        }

        public static void GetAdvertisingId(out string advertisingIdType, out string advertisingIdValue, ref bool disableAdvertising)
        {
            advertisingIdType = "undefined";
            advertisingIdValue = "";

            try
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                AndroidJavaClass advertIdGetter = new AndroidJavaClass("com.playfab.unityplugin.PlayFabGetAdvertId");

                AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
                AndroidJavaObject context = jc.GetStatic<AndroidJavaObject>("currentActivity");

                AndroidJavaObject adInfo = null;
                adInfo = advertIdGetter.CallStatic<AndroidJavaObject>("getAdvertisingIdInfo", context);

                if (adInfo != null)
                {
                    advertisingIdType = PlayFab.PlayFabSettings.AD_TYPE_ANDROID_ID;
                    advertisingIdValue = adInfo.Get<string>("advertisingId");
                    disableAdvertising = adInfo.Get<bool>("limitAdTrackingEnabled");
                }
#elif UNITY_IOS && !UNITY_EDITOR
                    advertisingIdType = PlayFab.PlayFabSettings.AD_TYPE_IDFA;
                    advertisingIdValue = PlayFabiOSPlugin.getIdfa();
                    disableAdvertising = PlayFabiOSPlugin.getAdvertisingDisabled();
#endif
            }
            catch (Exception e)
            {
                advertisingIdType = "error";
                advertisingIdValue = "";
                disableAdvertising = true;
                Debug.LogException(e);
            }
        }
    }
}
