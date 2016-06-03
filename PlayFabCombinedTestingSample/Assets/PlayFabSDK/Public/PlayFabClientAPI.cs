using System;
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
        public delegate void ProcessApiCallback<in TResult>(TResult result) where TResult : PlayFabResultCommon;

        public delegate void GetPhotonAuthenticationTokenRequestCallback(string urlPath, int callId, GetPhotonAuthenticationTokenRequest request, object customData);
        public delegate void GetPhotonAuthenticationTokenResponseCallback(string urlPath, int callId, GetPhotonAuthenticationTokenRequest request, GetPhotonAuthenticationTokenResult result, PlayFabError error, object customData);
        public delegate void LoginWithAndroidDeviceIDRequestCallback(string urlPath, int callId, LoginWithAndroidDeviceIDRequest request, object customData);
        public delegate void LoginWithAndroidDeviceIDResponseCallback(string urlPath, int callId, LoginWithAndroidDeviceIDRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithCustomIDRequestCallback(string urlPath, int callId, LoginWithCustomIDRequest request, object customData);
        public delegate void LoginWithCustomIDResponseCallback(string urlPath, int callId, LoginWithCustomIDRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithEmailAddressRequestCallback(string urlPath, int callId, LoginWithEmailAddressRequest request, object customData);
        public delegate void LoginWithEmailAddressResponseCallback(string urlPath, int callId, LoginWithEmailAddressRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithFacebookRequestCallback(string urlPath, int callId, LoginWithFacebookRequest request, object customData);
        public delegate void LoginWithFacebookResponseCallback(string urlPath, int callId, LoginWithFacebookRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithGameCenterRequestCallback(string urlPath, int callId, LoginWithGameCenterRequest request, object customData);
        public delegate void LoginWithGameCenterResponseCallback(string urlPath, int callId, LoginWithGameCenterRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithGoogleAccountRequestCallback(string urlPath, int callId, LoginWithGoogleAccountRequest request, object customData);
        public delegate void LoginWithGoogleAccountResponseCallback(string urlPath, int callId, LoginWithGoogleAccountRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithIOSDeviceIDRequestCallback(string urlPath, int callId, LoginWithIOSDeviceIDRequest request, object customData);
        public delegate void LoginWithIOSDeviceIDResponseCallback(string urlPath, int callId, LoginWithIOSDeviceIDRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithKongregateRequestCallback(string urlPath, int callId, LoginWithKongregateRequest request, object customData);
        public delegate void LoginWithKongregateResponseCallback(string urlPath, int callId, LoginWithKongregateRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithPlayFabRequestCallback(string urlPath, int callId, LoginWithPlayFabRequest request, object customData);
        public delegate void LoginWithPlayFabResponseCallback(string urlPath, int callId, LoginWithPlayFabRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void LoginWithSteamRequestCallback(string urlPath, int callId, LoginWithSteamRequest request, object customData);
        public delegate void LoginWithSteamResponseCallback(string urlPath, int callId, LoginWithSteamRequest request, LoginResult result, PlayFabError error, object customData);
        public delegate void RegisterPlayFabUserRequestCallback(string urlPath, int callId, RegisterPlayFabUserRequest request, object customData);
        public delegate void RegisterPlayFabUserResponseCallback(string urlPath, int callId, RegisterPlayFabUserRequest request, RegisterPlayFabUserResult result, PlayFabError error, object customData);
        public delegate void AddUsernamePasswordRequestCallback(string urlPath, int callId, AddUsernamePasswordRequest request, object customData);
        public delegate void AddUsernamePasswordResponseCallback(string urlPath, int callId, AddUsernamePasswordRequest request, AddUsernamePasswordResult result, PlayFabError error, object customData);
        public delegate void GetAccountInfoRequestCallback(string urlPath, int callId, GetAccountInfoRequest request, object customData);
        public delegate void GetAccountInfoResponseCallback(string urlPath, int callId, GetAccountInfoRequest request, GetAccountInfoResult result, PlayFabError error, object customData);
        public delegate void GetPlayFabIDsFromFacebookIDsRequestCallback(string urlPath, int callId, GetPlayFabIDsFromFacebookIDsRequest request, object customData);
        public delegate void GetPlayFabIDsFromFacebookIDsResponseCallback(string urlPath, int callId, GetPlayFabIDsFromFacebookIDsRequest request, GetPlayFabIDsFromFacebookIDsResult result, PlayFabError error, object customData);
        public delegate void GetPlayFabIDsFromGameCenterIDsRequestCallback(string urlPath, int callId, GetPlayFabIDsFromGameCenterIDsRequest request, object customData);
        public delegate void GetPlayFabIDsFromGameCenterIDsResponseCallback(string urlPath, int callId, GetPlayFabIDsFromGameCenterIDsRequest request, GetPlayFabIDsFromGameCenterIDsResult result, PlayFabError error, object customData);
        public delegate void GetPlayFabIDsFromGoogleIDsRequestCallback(string urlPath, int callId, GetPlayFabIDsFromGoogleIDsRequest request, object customData);
        public delegate void GetPlayFabIDsFromGoogleIDsResponseCallback(string urlPath, int callId, GetPlayFabIDsFromGoogleIDsRequest request, GetPlayFabIDsFromGoogleIDsResult result, PlayFabError error, object customData);
        public delegate void GetPlayFabIDsFromKongregateIDsRequestCallback(string urlPath, int callId, GetPlayFabIDsFromKongregateIDsRequest request, object customData);
        public delegate void GetPlayFabIDsFromKongregateIDsResponseCallback(string urlPath, int callId, GetPlayFabIDsFromKongregateIDsRequest request, GetPlayFabIDsFromKongregateIDsResult result, PlayFabError error, object customData);
        public delegate void GetPlayFabIDsFromSteamIDsRequestCallback(string urlPath, int callId, GetPlayFabIDsFromSteamIDsRequest request, object customData);
        public delegate void GetPlayFabIDsFromSteamIDsResponseCallback(string urlPath, int callId, GetPlayFabIDsFromSteamIDsRequest request, GetPlayFabIDsFromSteamIDsResult result, PlayFabError error, object customData);
        public delegate void GetUserCombinedInfoRequestCallback(string urlPath, int callId, GetUserCombinedInfoRequest request, object customData);
        public delegate void GetUserCombinedInfoResponseCallback(string urlPath, int callId, GetUserCombinedInfoRequest request, GetUserCombinedInfoResult result, PlayFabError error, object customData);
        public delegate void LinkAndroidDeviceIDRequestCallback(string urlPath, int callId, LinkAndroidDeviceIDRequest request, object customData);
        public delegate void LinkAndroidDeviceIDResponseCallback(string urlPath, int callId, LinkAndroidDeviceIDRequest request, LinkAndroidDeviceIDResult result, PlayFabError error, object customData);
        public delegate void LinkCustomIDRequestCallback(string urlPath, int callId, LinkCustomIDRequest request, object customData);
        public delegate void LinkCustomIDResponseCallback(string urlPath, int callId, LinkCustomIDRequest request, LinkCustomIDResult result, PlayFabError error, object customData);
        public delegate void LinkFacebookAccountRequestCallback(string urlPath, int callId, LinkFacebookAccountRequest request, object customData);
        public delegate void LinkFacebookAccountResponseCallback(string urlPath, int callId, LinkFacebookAccountRequest request, LinkFacebookAccountResult result, PlayFabError error, object customData);
        public delegate void LinkGameCenterAccountRequestCallback(string urlPath, int callId, LinkGameCenterAccountRequest request, object customData);
        public delegate void LinkGameCenterAccountResponseCallback(string urlPath, int callId, LinkGameCenterAccountRequest request, LinkGameCenterAccountResult result, PlayFabError error, object customData);
        public delegate void LinkGoogleAccountRequestCallback(string urlPath, int callId, LinkGoogleAccountRequest request, object customData);
        public delegate void LinkGoogleAccountResponseCallback(string urlPath, int callId, LinkGoogleAccountRequest request, LinkGoogleAccountResult result, PlayFabError error, object customData);
        public delegate void LinkIOSDeviceIDRequestCallback(string urlPath, int callId, LinkIOSDeviceIDRequest request, object customData);
        public delegate void LinkIOSDeviceIDResponseCallback(string urlPath, int callId, LinkIOSDeviceIDRequest request, LinkIOSDeviceIDResult result, PlayFabError error, object customData);
        public delegate void LinkKongregateRequestCallback(string urlPath, int callId, LinkKongregateAccountRequest request, object customData);
        public delegate void LinkKongregateResponseCallback(string urlPath, int callId, LinkKongregateAccountRequest request, LinkKongregateAccountResult result, PlayFabError error, object customData);
        public delegate void LinkSteamAccountRequestCallback(string urlPath, int callId, LinkSteamAccountRequest request, object customData);
        public delegate void LinkSteamAccountResponseCallback(string urlPath, int callId, LinkSteamAccountRequest request, LinkSteamAccountResult result, PlayFabError error, object customData);
        public delegate void ReportPlayerRequestCallback(string urlPath, int callId, ReportPlayerClientRequest request, object customData);
        public delegate void ReportPlayerResponseCallback(string urlPath, int callId, ReportPlayerClientRequest request, ReportPlayerClientResult result, PlayFabError error, object customData);
        public delegate void SendAccountRecoveryEmailRequestCallback(string urlPath, int callId, SendAccountRecoveryEmailRequest request, object customData);
        public delegate void SendAccountRecoveryEmailResponseCallback(string urlPath, int callId, SendAccountRecoveryEmailRequest request, SendAccountRecoveryEmailResult result, PlayFabError error, object customData);
        public delegate void UnlinkAndroidDeviceIDRequestCallback(string urlPath, int callId, UnlinkAndroidDeviceIDRequest request, object customData);
        public delegate void UnlinkAndroidDeviceIDResponseCallback(string urlPath, int callId, UnlinkAndroidDeviceIDRequest request, UnlinkAndroidDeviceIDResult result, PlayFabError error, object customData);
        public delegate void UnlinkCustomIDRequestCallback(string urlPath, int callId, UnlinkCustomIDRequest request, object customData);
        public delegate void UnlinkCustomIDResponseCallback(string urlPath, int callId, UnlinkCustomIDRequest request, UnlinkCustomIDResult result, PlayFabError error, object customData);
        public delegate void UnlinkFacebookAccountRequestCallback(string urlPath, int callId, UnlinkFacebookAccountRequest request, object customData);
        public delegate void UnlinkFacebookAccountResponseCallback(string urlPath, int callId, UnlinkFacebookAccountRequest request, UnlinkFacebookAccountResult result, PlayFabError error, object customData);
        public delegate void UnlinkGameCenterAccountRequestCallback(string urlPath, int callId, UnlinkGameCenterAccountRequest request, object customData);
        public delegate void UnlinkGameCenterAccountResponseCallback(string urlPath, int callId, UnlinkGameCenterAccountRequest request, UnlinkGameCenterAccountResult result, PlayFabError error, object customData);
        public delegate void UnlinkGoogleAccountRequestCallback(string urlPath, int callId, UnlinkGoogleAccountRequest request, object customData);
        public delegate void UnlinkGoogleAccountResponseCallback(string urlPath, int callId, UnlinkGoogleAccountRequest request, UnlinkGoogleAccountResult result, PlayFabError error, object customData);
        public delegate void UnlinkIOSDeviceIDRequestCallback(string urlPath, int callId, UnlinkIOSDeviceIDRequest request, object customData);
        public delegate void UnlinkIOSDeviceIDResponseCallback(string urlPath, int callId, UnlinkIOSDeviceIDRequest request, UnlinkIOSDeviceIDResult result, PlayFabError error, object customData);
        public delegate void UnlinkKongregateRequestCallback(string urlPath, int callId, UnlinkKongregateAccountRequest request, object customData);
        public delegate void UnlinkKongregateResponseCallback(string urlPath, int callId, UnlinkKongregateAccountRequest request, UnlinkKongregateAccountResult result, PlayFabError error, object customData);
        public delegate void UnlinkSteamAccountRequestCallback(string urlPath, int callId, UnlinkSteamAccountRequest request, object customData);
        public delegate void UnlinkSteamAccountResponseCallback(string urlPath, int callId, UnlinkSteamAccountRequest request, UnlinkSteamAccountResult result, PlayFabError error, object customData);
        public delegate void UpdateUserTitleDisplayNameRequestCallback(string urlPath, int callId, UpdateUserTitleDisplayNameRequest request, object customData);
        public delegate void UpdateUserTitleDisplayNameResponseCallback(string urlPath, int callId, UpdateUserTitleDisplayNameRequest request, UpdateUserTitleDisplayNameResult result, PlayFabError error, object customData);
        public delegate void GetFriendLeaderboardRequestCallback(string urlPath, int callId, GetFriendLeaderboardRequest request, object customData);
        public delegate void GetFriendLeaderboardResponseCallback(string urlPath, int callId, GetFriendLeaderboardRequest request, GetLeaderboardResult result, PlayFabError error, object customData);
        public delegate void GetFriendLeaderboardAroundCurrentUserRequestCallback(string urlPath, int callId, GetFriendLeaderboardAroundCurrentUserRequest request, object customData);
        public delegate void GetFriendLeaderboardAroundCurrentUserResponseCallback(string urlPath, int callId, GetFriendLeaderboardAroundCurrentUserRequest request, GetFriendLeaderboardAroundCurrentUserResult result, PlayFabError error, object customData);
        public delegate void GetFriendLeaderboardAroundPlayerRequestCallback(string urlPath, int callId, GetFriendLeaderboardAroundPlayerRequest request, object customData);
        public delegate void GetFriendLeaderboardAroundPlayerResponseCallback(string urlPath, int callId, GetFriendLeaderboardAroundPlayerRequest request, GetFriendLeaderboardAroundPlayerResult result, PlayFabError error, object customData);
        public delegate void GetLeaderboardRequestCallback(string urlPath, int callId, GetLeaderboardRequest request, object customData);
        public delegate void GetLeaderboardResponseCallback(string urlPath, int callId, GetLeaderboardRequest request, GetLeaderboardResult result, PlayFabError error, object customData);
        public delegate void GetLeaderboardAroundCurrentUserRequestCallback(string urlPath, int callId, GetLeaderboardAroundCurrentUserRequest request, object customData);
        public delegate void GetLeaderboardAroundCurrentUserResponseCallback(string urlPath, int callId, GetLeaderboardAroundCurrentUserRequest request, GetLeaderboardAroundCurrentUserResult result, PlayFabError error, object customData);
        public delegate void GetLeaderboardAroundPlayerRequestCallback(string urlPath, int callId, GetLeaderboardAroundPlayerRequest request, object customData);
        public delegate void GetLeaderboardAroundPlayerResponseCallback(string urlPath, int callId, GetLeaderboardAroundPlayerRequest request, GetLeaderboardAroundPlayerResult result, PlayFabError error, object customData);
        public delegate void GetPlayerStatisticsRequestCallback(string urlPath, int callId, GetPlayerStatisticsRequest request, object customData);
        public delegate void GetPlayerStatisticsResponseCallback(string urlPath, int callId, GetPlayerStatisticsRequest request, GetPlayerStatisticsResult result, PlayFabError error, object customData);
        public delegate void GetPlayerStatisticVersionsRequestCallback(string urlPath, int callId, GetPlayerStatisticVersionsRequest request, object customData);
        public delegate void GetPlayerStatisticVersionsResponseCallback(string urlPath, int callId, GetPlayerStatisticVersionsRequest request, GetPlayerStatisticVersionsResult result, PlayFabError error, object customData);
        public delegate void GetUserDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserPublisherDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserPublisherDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserPublisherReadOnlyDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserPublisherReadOnlyDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserReadOnlyDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserReadOnlyDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserStatisticsRequestCallback(string urlPath, int callId, GetUserStatisticsRequest request, object customData);
        public delegate void GetUserStatisticsResponseCallback(string urlPath, int callId, GetUserStatisticsRequest request, GetUserStatisticsResult result, PlayFabError error, object customData);
        public delegate void UpdatePlayerStatisticsRequestCallback(string urlPath, int callId, UpdatePlayerStatisticsRequest request, object customData);
        public delegate void UpdatePlayerStatisticsResponseCallback(string urlPath, int callId, UpdatePlayerStatisticsRequest request, UpdatePlayerStatisticsResult result, PlayFabError error, object customData);
        public delegate void UpdateUserDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserPublisherDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserPublisherDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserStatisticsRequestCallback(string urlPath, int callId, UpdateUserStatisticsRequest request, object customData);
        public delegate void UpdateUserStatisticsResponseCallback(string urlPath, int callId, UpdateUserStatisticsRequest request, UpdateUserStatisticsResult result, PlayFabError error, object customData);
        public delegate void GetCatalogItemsRequestCallback(string urlPath, int callId, GetCatalogItemsRequest request, object customData);
        public delegate void GetCatalogItemsResponseCallback(string urlPath, int callId, GetCatalogItemsRequest request, GetCatalogItemsResult result, PlayFabError error, object customData);
        public delegate void GetPublisherDataRequestCallback(string urlPath, int callId, GetPublisherDataRequest request, object customData);
        public delegate void GetPublisherDataResponseCallback(string urlPath, int callId, GetPublisherDataRequest request, GetPublisherDataResult result, PlayFabError error, object customData);
        public delegate void GetStoreItemsRequestCallback(string urlPath, int callId, GetStoreItemsRequest request, object customData);
        public delegate void GetStoreItemsResponseCallback(string urlPath, int callId, GetStoreItemsRequest request, GetStoreItemsResult result, PlayFabError error, object customData);
        public delegate void GetTitleDataRequestCallback(string urlPath, int callId, GetTitleDataRequest request, object customData);
        public delegate void GetTitleDataResponseCallback(string urlPath, int callId, GetTitleDataRequest request, GetTitleDataResult result, PlayFabError error, object customData);
        public delegate void GetTitleNewsRequestCallback(string urlPath, int callId, GetTitleNewsRequest request, object customData);
        public delegate void GetTitleNewsResponseCallback(string urlPath, int callId, GetTitleNewsRequest request, GetTitleNewsResult result, PlayFabError error, object customData);
        public delegate void AddUserVirtualCurrencyRequestCallback(string urlPath, int callId, AddUserVirtualCurrencyRequest request, object customData);
        public delegate void AddUserVirtualCurrencyResponseCallback(string urlPath, int callId, AddUserVirtualCurrencyRequest request, ModifyUserVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void ConfirmPurchaseRequestCallback(string urlPath, int callId, ConfirmPurchaseRequest request, object customData);
        public delegate void ConfirmPurchaseResponseCallback(string urlPath, int callId, ConfirmPurchaseRequest request, ConfirmPurchaseResult result, PlayFabError error, object customData);
        public delegate void ConsumeItemRequestCallback(string urlPath, int callId, ConsumeItemRequest request, object customData);
        public delegate void ConsumeItemResponseCallback(string urlPath, int callId, ConsumeItemRequest request, ConsumeItemResult result, PlayFabError error, object customData);
        public delegate void GetCharacterInventoryRequestCallback(string urlPath, int callId, GetCharacterInventoryRequest request, object customData);
        public delegate void GetCharacterInventoryResponseCallback(string urlPath, int callId, GetCharacterInventoryRequest request, GetCharacterInventoryResult result, PlayFabError error, object customData);
        public delegate void GetPurchaseRequestCallback(string urlPath, int callId, GetPurchaseRequest request, object customData);
        public delegate void GetPurchaseResponseCallback(string urlPath, int callId, GetPurchaseRequest request, GetPurchaseResult result, PlayFabError error, object customData);
        public delegate void GetUserInventoryRequestCallback(string urlPath, int callId, GetUserInventoryRequest request, object customData);
        public delegate void GetUserInventoryResponseCallback(string urlPath, int callId, GetUserInventoryRequest request, GetUserInventoryResult result, PlayFabError error, object customData);
        public delegate void PayForPurchaseRequestCallback(string urlPath, int callId, PayForPurchaseRequest request, object customData);
        public delegate void PayForPurchaseResponseCallback(string urlPath, int callId, PayForPurchaseRequest request, PayForPurchaseResult result, PlayFabError error, object customData);
        public delegate void PurchaseItemRequestCallback(string urlPath, int callId, PurchaseItemRequest request, object customData);
        public delegate void PurchaseItemResponseCallback(string urlPath, int callId, PurchaseItemRequest request, PurchaseItemResult result, PlayFabError error, object customData);
        public delegate void RedeemCouponRequestCallback(string urlPath, int callId, RedeemCouponRequest request, object customData);
        public delegate void RedeemCouponResponseCallback(string urlPath, int callId, RedeemCouponRequest request, RedeemCouponResult result, PlayFabError error, object customData);
        public delegate void StartPurchaseRequestCallback(string urlPath, int callId, StartPurchaseRequest request, object customData);
        public delegate void StartPurchaseResponseCallback(string urlPath, int callId, StartPurchaseRequest request, StartPurchaseResult result, PlayFabError error, object customData);
        public delegate void SubtractUserVirtualCurrencyRequestCallback(string urlPath, int callId, SubtractUserVirtualCurrencyRequest request, object customData);
        public delegate void SubtractUserVirtualCurrencyResponseCallback(string urlPath, int callId, SubtractUserVirtualCurrencyRequest request, ModifyUserVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void UnlockContainerInstanceRequestCallback(string urlPath, int callId, UnlockContainerInstanceRequest request, object customData);
        public delegate void UnlockContainerInstanceResponseCallback(string urlPath, int callId, UnlockContainerInstanceRequest request, UnlockContainerItemResult result, PlayFabError error, object customData);
        public delegate void UnlockContainerItemRequestCallback(string urlPath, int callId, UnlockContainerItemRequest request, object customData);
        public delegate void UnlockContainerItemResponseCallback(string urlPath, int callId, UnlockContainerItemRequest request, UnlockContainerItemResult result, PlayFabError error, object customData);
        public delegate void AddFriendRequestCallback(string urlPath, int callId, AddFriendRequest request, object customData);
        public delegate void AddFriendResponseCallback(string urlPath, int callId, AddFriendRequest request, AddFriendResult result, PlayFabError error, object customData);
        public delegate void GetFriendsListRequestCallback(string urlPath, int callId, GetFriendsListRequest request, object customData);
        public delegate void GetFriendsListResponseCallback(string urlPath, int callId, GetFriendsListRequest request, GetFriendsListResult result, PlayFabError error, object customData);
        public delegate void RemoveFriendRequestCallback(string urlPath, int callId, RemoveFriendRequest request, object customData);
        public delegate void RemoveFriendResponseCallback(string urlPath, int callId, RemoveFriendRequest request, RemoveFriendResult result, PlayFabError error, object customData);
        public delegate void SetFriendTagsRequestCallback(string urlPath, int callId, SetFriendTagsRequest request, object customData);
        public delegate void SetFriendTagsResponseCallback(string urlPath, int callId, SetFriendTagsRequest request, SetFriendTagsResult result, PlayFabError error, object customData);
        public delegate void RegisterForIOSPushNotificationRequestCallback(string urlPath, int callId, RegisterForIOSPushNotificationRequest request, object customData);
        public delegate void RegisterForIOSPushNotificationResponseCallback(string urlPath, int callId, RegisterForIOSPushNotificationRequest request, RegisterForIOSPushNotificationResult result, PlayFabError error, object customData);
        public delegate void RestoreIOSPurchasesRequestCallback(string urlPath, int callId, RestoreIOSPurchasesRequest request, object customData);
        public delegate void RestoreIOSPurchasesResponseCallback(string urlPath, int callId, RestoreIOSPurchasesRequest request, RestoreIOSPurchasesResult result, PlayFabError error, object customData);
        public delegate void ValidateIOSReceiptRequestCallback(string urlPath, int callId, ValidateIOSReceiptRequest request, object customData);
        public delegate void ValidateIOSReceiptResponseCallback(string urlPath, int callId, ValidateIOSReceiptRequest request, ValidateIOSReceiptResult result, PlayFabError error, object customData);
        public delegate void GetCurrentGamesRequestCallback(string urlPath, int callId, CurrentGamesRequest request, object customData);
        public delegate void GetCurrentGamesResponseCallback(string urlPath, int callId, CurrentGamesRequest request, CurrentGamesResult result, PlayFabError error, object customData);
        public delegate void GetGameServerRegionsRequestCallback(string urlPath, int callId, GameServerRegionsRequest request, object customData);
        public delegate void GetGameServerRegionsResponseCallback(string urlPath, int callId, GameServerRegionsRequest request, GameServerRegionsResult result, PlayFabError error, object customData);
        public delegate void MatchmakeRequestCallback(string urlPath, int callId, MatchmakeRequest request, object customData);
        public delegate void MatchmakeResponseCallback(string urlPath, int callId, MatchmakeRequest request, MatchmakeResult result, PlayFabError error, object customData);
        public delegate void StartGameRequestCallback(string urlPath, int callId, StartGameRequest request, object customData);
        public delegate void StartGameResponseCallback(string urlPath, int callId, StartGameRequest request, StartGameResult result, PlayFabError error, object customData);
        public delegate void AndroidDevicePushNotificationRegistrationRequestCallback(string urlPath, int callId, AndroidDevicePushNotificationRegistrationRequest request, object customData);
        public delegate void AndroidDevicePushNotificationRegistrationResponseCallback(string urlPath, int callId, AndroidDevicePushNotificationRegistrationRequest request, AndroidDevicePushNotificationRegistrationResult result, PlayFabError error, object customData);
        public delegate void ValidateGooglePlayPurchaseRequestCallback(string urlPath, int callId, ValidateGooglePlayPurchaseRequest request, object customData);
        public delegate void ValidateGooglePlayPurchaseResponseCallback(string urlPath, int callId, ValidateGooglePlayPurchaseRequest request, ValidateGooglePlayPurchaseResult result, PlayFabError error, object customData);
        public delegate void LogEventRequestCallback(string urlPath, int callId, LogEventRequest request, object customData);
        public delegate void LogEventResponseCallback(string urlPath, int callId, LogEventRequest request, LogEventResult result, PlayFabError error, object customData);
        public delegate void WriteCharacterEventRequestCallback(string urlPath, int callId, WriteClientCharacterEventRequest request, object customData);
        public delegate void WriteCharacterEventResponseCallback(string urlPath, int callId, WriteClientCharacterEventRequest request, WriteEventResponse result, PlayFabError error, object customData);
        public delegate void WritePlayerEventRequestCallback(string urlPath, int callId, WriteClientPlayerEventRequest request, object customData);
        public delegate void WritePlayerEventResponseCallback(string urlPath, int callId, WriteClientPlayerEventRequest request, WriteEventResponse result, PlayFabError error, object customData);
        public delegate void WriteTitleEventRequestCallback(string urlPath, int callId, WriteTitleEventRequest request, object customData);
        public delegate void WriteTitleEventResponseCallback(string urlPath, int callId, WriteTitleEventRequest request, WriteEventResponse result, PlayFabError error, object customData);
        public delegate void AddSharedGroupMembersRequestCallback(string urlPath, int callId, AddSharedGroupMembersRequest request, object customData);
        public delegate void AddSharedGroupMembersResponseCallback(string urlPath, int callId, AddSharedGroupMembersRequest request, AddSharedGroupMembersResult result, PlayFabError error, object customData);
        public delegate void CreateSharedGroupRequestCallback(string urlPath, int callId, CreateSharedGroupRequest request, object customData);
        public delegate void CreateSharedGroupResponseCallback(string urlPath, int callId, CreateSharedGroupRequest request, CreateSharedGroupResult result, PlayFabError error, object customData);
        public delegate void GetSharedGroupDataRequestCallback(string urlPath, int callId, GetSharedGroupDataRequest request, object customData);
        public delegate void GetSharedGroupDataResponseCallback(string urlPath, int callId, GetSharedGroupDataRequest request, GetSharedGroupDataResult result, PlayFabError error, object customData);
        public delegate void RemoveSharedGroupMembersRequestCallback(string urlPath, int callId, RemoveSharedGroupMembersRequest request, object customData);
        public delegate void RemoveSharedGroupMembersResponseCallback(string urlPath, int callId, RemoveSharedGroupMembersRequest request, RemoveSharedGroupMembersResult result, PlayFabError error, object customData);
        public delegate void UpdateSharedGroupDataRequestCallback(string urlPath, int callId, UpdateSharedGroupDataRequest request, object customData);
        public delegate void UpdateSharedGroupDataResponseCallback(string urlPath, int callId, UpdateSharedGroupDataRequest request, UpdateSharedGroupDataResult result, PlayFabError error, object customData);
        public delegate void ExecuteCloudScriptRequestCallback(string urlPath, int callId, ExecuteCloudScriptRequest request, object customData);
        public delegate void ExecuteCloudScriptResponseCallback(string urlPath, int callId, ExecuteCloudScriptRequest request, ExecuteCloudScriptResult result, PlayFabError error, object customData);
        public delegate void GetCloudScriptUrlRequestCallback(string urlPath, int callId, GetCloudScriptUrlRequest request, object customData);
        public delegate void GetCloudScriptUrlResponseCallback(string urlPath, int callId, GetCloudScriptUrlRequest request, GetCloudScriptUrlResult result, PlayFabError error, object customData);
        public delegate void RunCloudScriptRequestCallback(string urlPath, int callId, RunCloudScriptRequest request, object customData);
        public delegate void RunCloudScriptResponseCallback(string urlPath, int callId, RunCloudScriptRequest request, RunCloudScriptResult result, PlayFabError error, object customData);
        public delegate void GetContentDownloadUrlRequestCallback(string urlPath, int callId, GetContentDownloadUrlRequest request, object customData);
        public delegate void GetContentDownloadUrlResponseCallback(string urlPath, int callId, GetContentDownloadUrlRequest request, GetContentDownloadUrlResult result, PlayFabError error, object customData);
        public delegate void GetAllUsersCharactersRequestCallback(string urlPath, int callId, ListUsersCharactersRequest request, object customData);
        public delegate void GetAllUsersCharactersResponseCallback(string urlPath, int callId, ListUsersCharactersRequest request, ListUsersCharactersResult result, PlayFabError error, object customData);
        public delegate void GetCharacterLeaderboardRequestCallback(string urlPath, int callId, GetCharacterLeaderboardRequest request, object customData);
        public delegate void GetCharacterLeaderboardResponseCallback(string urlPath, int callId, GetCharacterLeaderboardRequest request, GetCharacterLeaderboardResult result, PlayFabError error, object customData);
        public delegate void GetCharacterStatisticsRequestCallback(string urlPath, int callId, GetCharacterStatisticsRequest request, object customData);
        public delegate void GetCharacterStatisticsResponseCallback(string urlPath, int callId, GetCharacterStatisticsRequest request, GetCharacterStatisticsResult result, PlayFabError error, object customData);
        public delegate void GetLeaderboardAroundCharacterRequestCallback(string urlPath, int callId, GetLeaderboardAroundCharacterRequest request, object customData);
        public delegate void GetLeaderboardAroundCharacterResponseCallback(string urlPath, int callId, GetLeaderboardAroundCharacterRequest request, GetLeaderboardAroundCharacterResult result, PlayFabError error, object customData);
        public delegate void GetLeaderboardForUserCharactersRequestCallback(string urlPath, int callId, GetLeaderboardForUsersCharactersRequest request, object customData);
        public delegate void GetLeaderboardForUserCharactersResponseCallback(string urlPath, int callId, GetLeaderboardForUsersCharactersRequest request, GetLeaderboardForUsersCharactersResult result, PlayFabError error, object customData);
        public delegate void GrantCharacterToUserRequestCallback(string urlPath, int callId, GrantCharacterToUserRequest request, object customData);
        public delegate void GrantCharacterToUserResponseCallback(string urlPath, int callId, GrantCharacterToUserRequest request, GrantCharacterToUserResult result, PlayFabError error, object customData);
        public delegate void UpdateCharacterStatisticsRequestCallback(string urlPath, int callId, UpdateCharacterStatisticsRequest request, object customData);
        public delegate void UpdateCharacterStatisticsResponseCallback(string urlPath, int callId, UpdateCharacterStatisticsRequest request, UpdateCharacterStatisticsResult result, PlayFabError error, object customData);
        public delegate void GetCharacterDataRequestCallback(string urlPath, int callId, GetCharacterDataRequest request, object customData);
        public delegate void GetCharacterDataResponseCallback(string urlPath, int callId, GetCharacterDataRequest request, GetCharacterDataResult result, PlayFabError error, object customData);
        public delegate void GetCharacterReadOnlyDataRequestCallback(string urlPath, int callId, GetCharacterDataRequest request, object customData);
        public delegate void GetCharacterReadOnlyDataResponseCallback(string urlPath, int callId, GetCharacterDataRequest request, GetCharacterDataResult result, PlayFabError error, object customData);
        public delegate void UpdateCharacterDataRequestCallback(string urlPath, int callId, UpdateCharacterDataRequest request, object customData);
        public delegate void UpdateCharacterDataResponseCallback(string urlPath, int callId, UpdateCharacterDataRequest request, UpdateCharacterDataResult result, PlayFabError error, object customData);
        public delegate void ValidateAmazonIAPReceiptRequestCallback(string urlPath, int callId, ValidateAmazonReceiptRequest request, object customData);
        public delegate void ValidateAmazonIAPReceiptResponseCallback(string urlPath, int callId, ValidateAmazonReceiptRequest request, ValidateAmazonReceiptResult result, PlayFabError error, object customData);
        public delegate void AcceptTradeRequestCallback(string urlPath, int callId, AcceptTradeRequest request, object customData);
        public delegate void AcceptTradeResponseCallback(string urlPath, int callId, AcceptTradeRequest request, AcceptTradeResponse result, PlayFabError error, object customData);
        public delegate void CancelTradeRequestCallback(string urlPath, int callId, CancelTradeRequest request, object customData);
        public delegate void CancelTradeResponseCallback(string urlPath, int callId, CancelTradeRequest request, CancelTradeResponse result, PlayFabError error, object customData);
        public delegate void GetPlayerTradesRequestCallback(string urlPath, int callId, GetPlayerTradesRequest request, object customData);
        public delegate void GetPlayerTradesResponseCallback(string urlPath, int callId, GetPlayerTradesRequest request, GetPlayerTradesResponse result, PlayFabError error, object customData);
        public delegate void GetTradeStatusRequestCallback(string urlPath, int callId, GetTradeStatusRequest request, object customData);
        public delegate void GetTradeStatusResponseCallback(string urlPath, int callId, GetTradeStatusRequest request, GetTradeStatusResponse result, PlayFabError error, object customData);
        public delegate void OpenTradeRequestCallback(string urlPath, int callId, OpenTradeRequest request, object customData);
        public delegate void OpenTradeResponseCallback(string urlPath, int callId, OpenTradeRequest request, OpenTradeResponse result, PlayFabError error, object customData);
        public delegate void AttributeInstallRequestCallback(string urlPath, int callId, AttributeInstallRequest request, object customData);
        public delegate void AttributeInstallResponseCallback(string urlPath, int callId, AttributeInstallRequest request, AttributeInstallResult result, PlayFabError error, object customData);

        /// <summary>
        /// Gets a Photon custom authentication token that can be used to securely join the player into a Photon room. See https://api.playfab.com/docs/using-photon-with-playfab/ for more details.
        /// </summary>
        public static void GetPhotonAuthenticationToken(GetPhotonAuthenticationTokenRequest request, ProcessApiCallback<GetPhotonAuthenticationTokenResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPhotonAuthenticationTokenResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPhotonAuthenticationToken", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Signs the user in using the Android device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithAndroidDeviceID(LoginWithAndroidDeviceIDRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithAndroidDeviceIDResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithAndroidDeviceID", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithAndroidDeviceIDResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user in using a custom unique identifier generated by the title, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithCustomID(LoginWithCustomIDRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithCustomIDResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithCustomID", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithCustomIDResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithEmailAddress(LoginWithEmailAddressRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithEmailAddressResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithEmailAddress", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithEmailAddressResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user in using a Facebook access token, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithFacebook(LoginWithFacebookRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithFacebookResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithFacebook", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithFacebookResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user in using an iOS Game Center player identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithGameCenter(LoginWithGameCenterRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithGameCenterResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithGameCenter", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithGameCenterResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user in using a Google account access token(https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods), returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithGoogleAccount(LoginWithGoogleAccountRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithGoogleAccountResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithGoogleAccount", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithGoogleAccountResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user in using the vendor-specific iOS device identifier, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithIOSDeviceID(LoginWithIOSDeviceIDRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithIOSDeviceIDResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithIOSDeviceID", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithIOSDeviceIDResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user in using a Kongregate player account.
        /// </summary>
        public static void LoginWithKongregate(LoginWithKongregateRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithKongregateResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithKongregate", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithKongregateResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user into the PlayFab account, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithPlayFab(LoginWithPlayFabRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithPlayFabResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithPlayFab", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithPlayFabResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Signs the user in using a Steam authentication ticket, returning a session identifier that can subsequently be used for API calls which require an authenticated user
        /// </summary>
        public static void LoginWithSteam(LoginWithSteamRequest request, ProcessApiCallback<LoginResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LoginResult>.HandleResults(requestContainer, resultCallback, errorCallback, LoginWithSteamResultAction);
            };
            PlayFabHTTP.Post("/Client/LoginWithSteam", serializedJson, null, null, callback, request, customData);
        }
        public static void LoginWithSteamResultAction(LoginResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Registers a new Playfab user account, returning a session identifier that can subsequently be used for API calls which require an authenticated user. You must supply either a username or an email address.
        /// </summary>
        public static void RegisterPlayFabUser(RegisterPlayFabUserRequest request, ProcessApiCallback<RegisterPlayFabUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            request.TitleId = request.TitleId ?? PlayFabSettings.TitleId;
            if (request.TitleId == null) throw new Exception("Must be have PlayFabSettings.TitleId set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RegisterPlayFabUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, RegisterPlayFabUserResultAction);
            };
            PlayFabHTTP.Post("/Client/RegisterPlayFabUser", serializedJson, null, null, callback, request, customData);
        }
        public static void RegisterPlayFabUserResultAction(RegisterPlayFabUserResult result, CallRequestContainer requestContainer)
        {
            _authKey = result.SessionTicket ?? _authKey;
            MultiStepClientLogin(result.SettingsForUser.NeedsAttribution);

        }

        /// <summary>
        /// Adds playfab username/password auth to an existing semi-anonymous account created via a 3rd party auth method.
        /// </summary>
        public static void AddUsernamePassword(AddUsernamePasswordRequest request, ProcessApiCallback<AddUsernamePasswordResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AddUsernamePasswordResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/AddUsernamePassword", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the user's PlayFab account details
        /// </summary>
        public static void GetAccountInfo(GetAccountInfoRequest request, ProcessApiCallback<GetAccountInfoResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetAccountInfoResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetAccountInfo", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, ProcessApiCallback<GetPlayFabIDsFromFacebookIDsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayFabIDsFromFacebookIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayFabIDsFromFacebookIDs", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Game Center identifiers (referenced in the Game Center Programming Guide as the Player Identifier).
        /// </summary>
        public static void GetPlayFabIDsFromGameCenterIDs(GetPlayFabIDsFromGameCenterIDsRequest request, ProcessApiCallback<GetPlayFabIDsFromGameCenterIDsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayFabIDsFromGameCenterIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayFabIDsFromGameCenterIDs", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Google identifiers. The Google identifiers are the IDs for the user accounts, available as "id" in the Google+ People API calls.
        /// </summary>
        public static void GetPlayFabIDsFromGoogleIDs(GetPlayFabIDsFromGoogleIDsRequest request, ProcessApiCallback<GetPlayFabIDsFromGoogleIDsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayFabIDsFromGoogleIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayFabIDsFromGoogleIDs", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Kongregate identifiers. The Kongregate identifiers are the IDs for the user accounts, available as "user_id" from the Kongregate API methods(ex: http://developers.kongregate.com/docs/client/getUserId).
        /// </summary>
        public static void GetPlayFabIDsFromKongregateIDs(GetPlayFabIDsFromKongregateIDsRequest request, ProcessApiCallback<GetPlayFabIDsFromKongregateIDsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayFabIDsFromKongregateIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayFabIDsFromKongregateIDs", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public static void GetPlayFabIDsFromSteamIDs(GetPlayFabIDsFromSteamIDsRequest request, ProcessApiCallback<GetPlayFabIDsFromSteamIDsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayFabIDsFromSteamIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayFabIDsFromSteamIDs", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves all requested data for a user in one unified request. By default, this API returns all  data for the locally signed-in user. The input parameters may be used to limit the data retrieved to any subset of the available data, as well as retrieve the available data for a different user. Note that certain data, including inventory, virtual currency balances, and personally identifying information, may only be retrieved for the locally signed-in user. In the example below, a request is made for the account details, virtual currency balances, and specified user data for the locally signed-in user.
        /// </summary>
        public static void GetUserCombinedInfo(GetUserCombinedInfoRequest request, ProcessApiCallback<GetUserCombinedInfoResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserCombinedInfoResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetUserCombinedInfo", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the Android device identifier to the user's PlayFab account
        /// </summary>
        public static void LinkAndroidDeviceID(LinkAndroidDeviceIDRequest request, ProcessApiCallback<LinkAndroidDeviceIDResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkAndroidDeviceIDResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkAndroidDeviceID", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the custom identifier, generated by the title, to the user's PlayFab account
        /// </summary>
        public static void LinkCustomID(LinkCustomIDRequest request, ProcessApiCallback<LinkCustomIDResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkCustomIDResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkCustomID", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the Facebook account associated with the provided Facebook access token to the user's PlayFab account
        /// </summary>
        public static void LinkFacebookAccount(LinkFacebookAccountRequest request, ProcessApiCallback<LinkFacebookAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkFacebookAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkFacebookAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the Game Center account associated with the provided Game Center ID to the user's PlayFab account
        /// </summary>
        public static void LinkGameCenterAccount(LinkGameCenterAccountRequest request, ProcessApiCallback<LinkGameCenterAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkGameCenterAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkGameCenterAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the currently signed-in user account to the Google account specified by the Google account access token (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods).
        /// </summary>
        public static void LinkGoogleAccount(LinkGoogleAccountRequest request, ProcessApiCallback<LinkGoogleAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkGoogleAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkGoogleAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the vendor-specific iOS device identifier to the user's PlayFab account
        /// </summary>
        public static void LinkIOSDeviceID(LinkIOSDeviceIDRequest request, ProcessApiCallback<LinkIOSDeviceIDResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkIOSDeviceIDResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkIOSDeviceID", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the Kongregate identifier to the user's PlayFab account
        /// </summary>
        public static void LinkKongregate(LinkKongregateAccountRequest request, ProcessApiCallback<LinkKongregateAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkKongregateAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkKongregate", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Links the Steam account associated with the provided Steam authentication ticket to the user's PlayFab account
        /// </summary>
        public static void LinkSteamAccount(LinkSteamAccountRequest request, ProcessApiCallback<LinkSteamAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LinkSteamAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LinkSteamAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Submit a report for another player (due to bad bahavior, etc.), so that customer service representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        public static void ReportPlayer(ReportPlayerClientRequest request, ProcessApiCallback<ReportPlayerClientResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ReportPlayerClientResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/ReportPlayer", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the user's account, with a link allowing the user to change the password
        /// </summary>
        public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, ProcessApiCallback<SendAccountRecoveryEmailResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            
            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SendAccountRecoveryEmailResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/SendAccountRecoveryEmail", serializedJson, null, null, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related Android device identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkAndroidDeviceID(UnlinkAndroidDeviceIDRequest request, ProcessApiCallback<UnlinkAndroidDeviceIDResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkAndroidDeviceIDResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkAndroidDeviceID", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related custom identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkCustomID(UnlinkCustomIDRequest request, ProcessApiCallback<UnlinkCustomIDResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkCustomIDResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkCustomID", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related Facebook account from the user's PlayFab account
        /// </summary>
        public static void UnlinkFacebookAccount(UnlinkFacebookAccountRequest request, ProcessApiCallback<UnlinkFacebookAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkFacebookAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkFacebookAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related Game Center account from the user's PlayFab account
        /// </summary>
        public static void UnlinkGameCenterAccount(UnlinkGameCenterAccountRequest request, ProcessApiCallback<UnlinkGameCenterAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkGameCenterAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkGameCenterAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related Google account from the user's PlayFab account (https://developers.google.com/android/reference/com/google/android/gms/auth/GoogleAuthUtil#public-methods).
        /// </summary>
        public static void UnlinkGoogleAccount(UnlinkGoogleAccountRequest request, ProcessApiCallback<UnlinkGoogleAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkGoogleAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkGoogleAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related iOS device identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkIOSDeviceID(UnlinkIOSDeviceIDRequest request, ProcessApiCallback<UnlinkIOSDeviceIDResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkIOSDeviceIDResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkIOSDeviceID", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related Kongregate identifier from the user's PlayFab account
        /// </summary>
        public static void UnlinkKongregate(UnlinkKongregateAccountRequest request, ProcessApiCallback<UnlinkKongregateAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkKongregateAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkKongregate", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Unlinks the related Steam account from the user's PlayFab account
        /// </summary>
        public static void UnlinkSteamAccount(UnlinkSteamAccountRequest request, ProcessApiCallback<UnlinkSteamAccountResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlinkSteamAccountResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlinkSteamAccount", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title specific display name for the user
        /// </summary>
        public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, ProcessApiCallback<UpdateUserTitleDisplayNameResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserTitleDisplayNameResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdateUserTitleDisplayName", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetFriendLeaderboard(GetFriendLeaderboardRequest request, ProcessApiCallback<GetLeaderboardResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetFriendLeaderboard", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetFriendLeaderboardAroundCurrentUser(GetFriendLeaderboardAroundCurrentUserRequest request, ProcessApiCallback<GetFriendLeaderboardAroundCurrentUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetFriendLeaderboardAroundCurrentUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetFriendLeaderboardAroundCurrentUser", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked friends of the current player for the given statistic, centered on the requested PlayFab user. If PlayFabId is empty or null will return currently logged in user.
        /// </summary>
        public static void GetFriendLeaderboardAroundPlayer(GetFriendLeaderboardAroundPlayerRequest request, ProcessApiCallback<GetFriendLeaderboardAroundPlayerResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetFriendLeaderboardAroundPlayerResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetFriendLeaderboardAroundPlayer", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetLeaderboard(GetLeaderboardRequest request, ProcessApiCallback<GetLeaderboardResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetLeaderboard", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetLeaderboardAroundCurrentUser(GetLeaderboardAroundCurrentUserRequest request, ProcessApiCallback<GetLeaderboardAroundCurrentUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardAroundCurrentUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetLeaderboardAroundCurrentUser", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the requested player. If PlayFabId is empty or null will return currently logged in user.
        /// </summary>
        public static void GetLeaderboardAroundPlayer(GetLeaderboardAroundPlayerRequest request, ProcessApiCallback<GetLeaderboardAroundPlayerResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardAroundPlayerResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetLeaderboardAroundPlayer", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the indicated statistics (current version and values for all statistics, if none are specified), for the local player.
        /// </summary>
        public static void GetPlayerStatistics(GetPlayerStatisticsRequest request, ProcessApiCallback<GetPlayerStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayerStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayerStatistics", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, ProcessApiCallback<GetPlayerStatisticVersionsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayerStatisticVersionsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayerStatisticVersions", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetUserData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetUserPublisherData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetUserPublisherReadOnlyData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetUserReadOnlyData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public static void GetUserStatistics(GetUserStatisticsRequest request, ProcessApiCallback<GetUserStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetUserStatistics", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public static void UpdatePlayerStatistics(UpdatePlayerStatisticsRequest request, ProcessApiCallback<UpdatePlayerStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdatePlayerStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdatePlayerStatistics", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdateUserData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Creates and updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdateUserPublisherData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, ProcessApiCallback<UpdateUserStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdateUserStatistics", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, ProcessApiCallback<GetCatalogItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCatalogItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetCatalogItems", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, ProcessApiCallback<GetPublisherDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPublisherDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPublisherData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static void GetStoreItems(GetStoreItemsRequest request, ProcessApiCallback<GetStoreItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetStoreItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetStoreItems", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, ProcessApiCallback<GetTitleDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetTitleData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public static void GetTitleNews(GetTitleNewsRequest request, ProcessApiCallback<GetTitleNewsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetTitleNewsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetTitleNews", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Increments the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, ProcessApiCallback<ModifyUserVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/AddUserVirtualCurrency", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Confirms with the payment provider that the purchase was approved (if applicable) and adjusts inventory and virtual currency balances as appropriate
        /// </summary>
        public static void ConfirmPurchase(ConfirmPurchaseRequest request, ProcessApiCallback<ConfirmPurchaseResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ConfirmPurchaseResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/ConfirmPurchase", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public static void ConsumeItem(ConsumeItemRequest request, ProcessApiCallback<ConsumeItemResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ConsumeItemResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/ConsumeItem", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static void GetCharacterInventory(GetCharacterInventoryRequest request, ProcessApiCallback<GetCharacterInventoryResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetCharacterInventory", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a completed purchase along with its current PlayFab status.
        /// </summary>
        public static void GetPurchase(GetPurchaseRequest request, ProcessApiCallback<GetPurchaseResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPurchaseResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPurchase", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, ProcessApiCallback<GetUserInventoryResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetUserInventory", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Selects a payment option for purchase order created via StartPurchase
        /// </summary>
        public static void PayForPurchase(PayForPurchaseRequest request, ProcessApiCallback<PayForPurchaseResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<PayForPurchaseResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/PayForPurchase", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Buys a single item with virtual currency. You must specify both the virtual currency to use to purchase, as well as what the client believes the price to be. This lets the server fail the purchase if the price has changed.
        /// </summary>
        public static void PurchaseItem(PurchaseItemRequest request, ProcessApiCallback<PurchaseItemResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<PurchaseItemResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/PurchaseItem", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/using-stores-and-coupons-game-manager/
        /// </summary>
        public static void RedeemCoupon(RedeemCouponRequest request, ProcessApiCallback<RedeemCouponResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RedeemCouponResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/RedeemCoupon", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Creates an order for a list of items from the title catalog
        /// </summary>
        public static void StartPurchase(StartPurchaseRequest request, ProcessApiCallback<StartPurchaseResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<StartPurchaseResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/StartPurchase", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, ProcessApiCallback<ModifyUserVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/SubtractUserVirtualCurrency", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Opens the specified container, with the specified key (when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static void UnlockContainerInstance(UnlockContainerInstanceRequest request, ProcessApiCallback<UnlockContainerItemResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlockContainerItemResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlockContainerInstance", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Searches target inventory for an ItemInstance matching the given CatalogItemId, if necessary unlocks it using an appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static void UnlockContainerItem(UnlockContainerItemRequest request, ProcessApiCallback<UnlockContainerItemResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlockContainerItemResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UnlockContainerItem", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the PlayFab user, based upon a match against a supplied unique identifier, to the friend list of the local user. At least one of FriendPlayFabId,FriendUsername,FriendEmail, or FriendTitleDisplayName should be initialized.
        /// </summary>
        public static void AddFriend(AddFriendRequest request, ProcessApiCallback<AddFriendResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AddFriendResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/AddFriend", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the current friend list for the local user, constrained to users who have PlayFab accounts. Friends from linked accounts (Facebook, Steam) are also included. You may optionally exclude some linked services' friends.
        /// </summary>
        public static void GetFriendsList(GetFriendsListRequest request, ProcessApiCallback<GetFriendsListResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetFriendsListResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetFriendsList", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Removes a specified user from the friend list of the local user
        /// </summary>
        public static void RemoveFriend(RemoveFriendRequest request, ProcessApiCallback<RemoveFriendResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RemoveFriendResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/RemoveFriend", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the tag list for a specified user in the friend list of the local user
        /// </summary>
        public static void SetFriendTags(SetFriendTagsRequest request, ProcessApiCallback<SetFriendTagsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetFriendTagsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/SetFriendTags", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Registers the iOS device to receive push notifications
        /// </summary>
        public static void RegisterForIOSPushNotification(RegisterForIOSPushNotificationRequest request, ProcessApiCallback<RegisterForIOSPushNotificationResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RegisterForIOSPushNotificationResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/RegisterForIOSPushNotification", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Restores all in-app purchases based on the given refresh receipt.
        /// </summary>
        public static void RestoreIOSPurchases(RestoreIOSPurchasesRequest request, ProcessApiCallback<RestoreIOSPurchasesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RestoreIOSPurchasesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/RestoreIOSPurchases", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Validates with the Apple store that the receipt for an iOS in-app purchase is valid and that it matches the purchased catalog item
        /// </summary>
        public static void ValidateIOSReceipt(ValidateIOSReceiptRequest request, ProcessApiCallback<ValidateIOSReceiptResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ValidateIOSReceiptResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/ValidateIOSReceipt", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Get details about all current running game servers matching the given parameters.
        /// </summary>
        public static void GetCurrentGames(CurrentGamesRequest request, ProcessApiCallback<CurrentGamesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<CurrentGamesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetCurrentGames", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        ///  Get details about the regions hosting game servers matching the given parameters.
        /// </summary>
        public static void GetGameServerRegions(GameServerRegionsRequest request, ProcessApiCallback<GameServerRegionsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GameServerRegionsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetGameServerRegions", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Attempts to locate a game session matching the given parameters. If the goal is to match the player into a specific active session, only the LobbyId is required. Otherwise, the BuildVersion, GameMode, and Region are all required parameters. Note that parameters specified in the search are required (they are not weighting factors). If a slot is found in a server instance matching the parameters, the slot will be assigned to that player, removing it from the availabe set. In that case, the information on the game session will be returned, otherwise the Status returned will be GameNotFound. Note that EnableQueue is deprecated at this time.
        /// </summary>
        public static void Matchmake(MatchmakeRequest request, ProcessApiCallback<MatchmakeResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<MatchmakeResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/Matchmake", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Start a new game server with a given configuration, add the current player and return the connection information.
        /// </summary>
        public static void StartGame(StartGameRequest request, ProcessApiCallback<StartGameResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<StartGameResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/StartGame", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Registers the Android device to receive push notifications
        /// </summary>
        public static void AndroidDevicePushNotificationRegistration(AndroidDevicePushNotificationRegistrationRequest request, ProcessApiCallback<AndroidDevicePushNotificationRegistrationResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AndroidDevicePushNotificationRegistrationResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/AndroidDevicePushNotificationRegistration", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Validates a Google Play purchase and gives the corresponding item to the player.
        /// </summary>
        public static void ValidateGooglePlayPurchase(ValidateGooglePlayPurchaseRequest request, ProcessApiCallback<ValidateGooglePlayPurchaseResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ValidateGooglePlayPurchaseResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/ValidateGooglePlayPurchase", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Logs a custom analytics event
        /// </summary>
        public static void LogEvent(LogEventRequest request, ProcessApiCallback<LogEventResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LogEventResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/LogEvent", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        public static void WriteCharacterEvent(WriteClientCharacterEventRequest request, ProcessApiCallback<WriteEventResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<WriteEventResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/WriteCharacterEvent", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        public static void WritePlayerEvent(WriteClientPlayerEventRequest request, ProcessApiCallback<WriteEventResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<WriteEventResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/WritePlayerEvent", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        public static void WriteTitleEvent(WriteTitleEventRequest request, ProcessApiCallback<WriteEventResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<WriteEventResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/WriteTitleEvent", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group can add new members.
        /// </summary>
        public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, ProcessApiCallback<AddSharedGroupMembersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AddSharedGroupMembersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/AddSharedGroupMembers", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. Upon creation, the current user will be the only member of the group.
        /// </summary>
        public static void CreateSharedGroup(CreateSharedGroupRequest request, ProcessApiCallback<CreateSharedGroupResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<CreateSharedGroupResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/CreateSharedGroup", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. Non-members of the group may use this to retrieve group data, including membership, but they will not receive data for keys marked as private.
        /// </summary>
        public static void GetSharedGroupData(GetSharedGroupDataRequest request, ProcessApiCallback<GetSharedGroupDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetSharedGroupDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetSharedGroupData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
        /// </summary>
        public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, ProcessApiCallback<RemoveSharedGroupMembersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RemoveSharedGroupMembersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/RemoveSharedGroupMembers", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group can update the data.
        /// </summary>
        public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, ProcessApiCallback<UpdateSharedGroupDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateSharedGroupDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdateSharedGroupData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated player.
        /// </summary>
        public static void ExecuteCloudScript(ExecuteCloudScriptRequest request, ProcessApiCallback<ExecuteCloudScriptResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ExecuteCloudScriptResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/ExecuteCloudScript", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific URL for Cloud Script servers. This must be queried once, prior  to making any calls to RunCloudScript.
        /// </summary>
        public static void GetCloudScriptUrl(GetCloudScriptUrlRequest request, ProcessApiCallback<GetCloudScriptUrlResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCloudScriptUrlResult>.HandleResults(requestContainer, resultCallback, errorCallback, GetCloudScriptUrlResultAction);
            };
            PlayFabHTTP.Post("/Client/GetCloudScriptUrl", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }
        public static void GetCloudScriptUrlResultAction(GetCloudScriptUrlResult result, CallRequestContainer requestContainer)
        {
            PlayFabSettings.LogicServerUrl = result.Url;

        }

        /// <summary>
        /// Triggers a particular server action, passing the provided inputs to the hosted Cloud Script. An action in this context is a handler in the JavaScript. NOTE: Before calling this API, you must call GetCloudScriptUrl to be assigned a Cloud Script server URL. When using an official PlayFab SDK, this URL is stored internally in the SDK, but GetCloudScriptUrl must still be manually called.
        /// </summary>
        public static void RunCloudScript(RunCloudScriptRequest request, ProcessApiCallback<RunCloudScriptResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RunCloudScriptResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/RunCloudScript", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service
        /// </summary>
        public static void GetContentDownloadUrl(GetContentDownloadUrlRequest request, ProcessApiCallback<GetContentDownloadUrlResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetContentDownloadUrlResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetContentDownloadUrl", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GetAllUsersCharacters(ListUsersCharactersRequest request, ProcessApiCallback<ListUsersCharactersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ListUsersCharactersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetAllUsersCharacters", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, ProcessApiCallback<GetCharacterLeaderboardResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterLeaderboardResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetCharacterLeaderboard", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public static void GetCharacterStatistics(GetCharacterStatisticsRequest request, ProcessApiCallback<GetCharacterStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetCharacterStatistics", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested Character ID
        /// </summary>
        public static void GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, ProcessApiCallback<GetLeaderboardAroundCharacterResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardAroundCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetLeaderboardAroundCharacter", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static void GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, ProcessApiCallback<GetLeaderboardForUsersCharactersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardForUsersCharactersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetLeaderboardForUserCharacters", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GrantCharacterToUser(GrantCharacterToUserRequest request, ProcessApiCallback<GrantCharacterToUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GrantCharacterToUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GrantCharacterToUser", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character. By default, clients are not permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public static void UpdateCharacterStatistics(UpdateCharacterStatisticsRequest request, ProcessApiCallback<UpdateCharacterStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCharacterStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdateCharacterStatistics", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which is readable and writable by the client
        /// </summary>
        public static void GetCharacterData(GetCharacterDataRequest request, ProcessApiCallback<GetCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetCharacterData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the character which can only be read by the client
        /// </summary>
        public static void GetCharacterReadOnlyData(GetCharacterDataRequest request, ProcessApiCallback<GetCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetCharacterReadOnlyData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Creates and updates the title-specific custom data for the user's character which is readable  and writable by the client
        /// </summary>
        public static void UpdateCharacterData(UpdateCharacterDataRequest request, ProcessApiCallback<UpdateCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/UpdateCharacterData", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Validates with Amazon that the receipt for an Amazon App Store in-app purchase is valid and that it matches the purchased catalog item
        /// </summary>
        public static void ValidateAmazonIAPReceipt(ValidateAmazonReceiptRequest request, ProcessApiCallback<ValidateAmazonReceiptResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ValidateAmazonReceiptResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/ValidateAmazonIAPReceipt", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Accepts an open trade. If the call is successful, the offered and accepted items will be swapped between the two players' inventories.
        /// </summary>
        public static void AcceptTrade(AcceptTradeRequest request, ProcessApiCallback<AcceptTradeResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AcceptTradeResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/AcceptTrade", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Cancels an open trade.
        /// </summary>
        public static void CancelTrade(CancelTradeRequest request, ProcessApiCallback<CancelTradeResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<CancelTradeResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/CancelTrade", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Gets all trades the player has either opened or accepted, optionally filtered by trade status.
        /// </summary>
        public static void GetPlayerTrades(GetPlayerTradesRequest request, ProcessApiCallback<GetPlayerTradesResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayerTradesResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetPlayerTrades", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Gets the current status of an existing trade.
        /// </summary>
        public static void GetTradeStatus(GetTradeStatusRequest request, ProcessApiCallback<GetTradeStatusResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetTradeStatusResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/GetTradeStatus", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Opens a new outstanding trade.
        /// </summary>
        public static void OpenTrade(OpenTradeRequest request, ProcessApiCallback<OpenTradeResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<OpenTradeResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Client/OpenTrade", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }

        /// <summary>
        /// Attributes an install for advertisment.
        /// </summary>
        public static void AttributeInstall(AttributeInstallRequest request, ProcessApiCallback<AttributeInstallResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (_authKey == null) throw new Exception("Must be logged in to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AttributeInstallResult>.HandleResults(requestContainer, resultCallback, errorCallback, AttributeInstallResultAction);
            };
            PlayFabHTTP.Post("/Client/AttributeInstall", serializedJson, "X-Authorization", _authKey, callback, request, customData);
        }
        public static void AttributeInstallResultAction(AttributeInstallResult result, CallRequestContainer requestContainer)
        {
            // Modify AdvertisingIdType:  Prevents us from sending the id multiple times, and allows automated tests to determine id was sent successfully
            PlayFabSettings.AdvertisingIdType += "_Successful";

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
                AndroidJavaClass advertIdGetter = new AndroidJavaClass("com.playfab.unityadinfoplugin.PlayFabGetAdvertId");

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
