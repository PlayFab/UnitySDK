using System;
using PlayFab.ServerModels;
using PlayFab.Internal;
using PlayFab.Json;
using UnityEngine;

namespace PlayFab
{
    /// <summary>
    /// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a trusted manner, and to handle matchmaking and client connection orchestration
    /// </summary>
    public static class PlayFabServerAPI
    {
        public delegate void AuthenticateSessionTicketRequestCallback(string urlPath, int callId, AuthenticateSessionTicketRequest request, object customData);
        public delegate void AuthenticateSessionTicketResponseCallback(string urlPath, int callId, AuthenticateSessionTicketRequest request, AuthenticateSessionTicketResult result, PlayFabError error, object customData);
        public delegate void GetPlayFabIDsFromFacebookIDsRequestCallback(string urlPath, int callId, GetPlayFabIDsFromFacebookIDsRequest request, object customData);
        public delegate void GetPlayFabIDsFromFacebookIDsResponseCallback(string urlPath, int callId, GetPlayFabIDsFromFacebookIDsRequest request, GetPlayFabIDsFromFacebookIDsResult result, PlayFabError error, object customData);
        public delegate void GetPlayFabIDsFromSteamIDsRequestCallback(string urlPath, int callId, GetPlayFabIDsFromSteamIDsRequest request, object customData);
        public delegate void GetPlayFabIDsFromSteamIDsResponseCallback(string urlPath, int callId, GetPlayFabIDsFromSteamIDsRequest request, GetPlayFabIDsFromSteamIDsResult result, PlayFabError error, object customData);
        public delegate void GetUserAccountInfoRequestCallback(string urlPath, int callId, GetUserAccountInfoRequest request, object customData);
        public delegate void GetUserAccountInfoResponseCallback(string urlPath, int callId, GetUserAccountInfoRequest request, GetUserAccountInfoResult result, PlayFabError error, object customData);
        public delegate void SendPushNotificationRequestCallback(string urlPath, int callId, SendPushNotificationRequest request, object customData);
        public delegate void SendPushNotificationResponseCallback(string urlPath, int callId, SendPushNotificationRequest request, SendPushNotificationResult result, PlayFabError error, object customData);
        public delegate void DeleteUsersRequestCallback(string urlPath, int callId, DeleteUsersRequest request, object customData);
        public delegate void DeleteUsersResponseCallback(string urlPath, int callId, DeleteUsersRequest request, DeleteUsersResult result, PlayFabError error, object customData);
        public delegate void GetLeaderboardRequestCallback(string urlPath, int callId, GetLeaderboardRequest request, object customData);
        public delegate void GetLeaderboardResponseCallback(string urlPath, int callId, GetLeaderboardRequest request, GetLeaderboardResult result, PlayFabError error, object customData);
        public delegate void GetLeaderboardAroundUserRequestCallback(string urlPath, int callId, GetLeaderboardAroundUserRequest request, object customData);
        public delegate void GetLeaderboardAroundUserResponseCallback(string urlPath, int callId, GetLeaderboardAroundUserRequest request, GetLeaderboardAroundUserResult result, PlayFabError error, object customData);
        public delegate void GetPlayerStatisticsRequestCallback(string urlPath, int callId, GetPlayerStatisticsRequest request, object customData);
        public delegate void GetPlayerStatisticsResponseCallback(string urlPath, int callId, GetPlayerStatisticsRequest request, GetPlayerStatisticsResult result, PlayFabError error, object customData);
        public delegate void GetPlayerStatisticVersionsRequestCallback(string urlPath, int callId, GetPlayerStatisticVersionsRequest request, object customData);
        public delegate void GetPlayerStatisticVersionsResponseCallback(string urlPath, int callId, GetPlayerStatisticVersionsRequest request, GetPlayerStatisticVersionsResult result, PlayFabError error, object customData);
        public delegate void GetUserDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserInternalDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserInternalDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserPublisherDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserPublisherDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
        public delegate void GetUserPublisherInternalDataRequestCallback(string urlPath, int callId, GetUserDataRequest request, object customData);
        public delegate void GetUserPublisherInternalDataResponseCallback(string urlPath, int callId, GetUserDataRequest request, GetUserDataResult result, PlayFabError error, object customData);
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
        public delegate void UpdateUserInternalDataRequestCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, object customData);
        public delegate void UpdateUserInternalDataResponseCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserPublisherDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserPublisherDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserPublisherInternalDataRequestCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, object customData);
        public delegate void UpdateUserPublisherInternalDataResponseCallback(string urlPath, int callId, UpdateUserInternalDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserPublisherReadOnlyDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserPublisherReadOnlyDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserReadOnlyDataRequestCallback(string urlPath, int callId, UpdateUserDataRequest request, object customData);
        public delegate void UpdateUserReadOnlyDataResponseCallback(string urlPath, int callId, UpdateUserDataRequest request, UpdateUserDataResult result, PlayFabError error, object customData);
        public delegate void UpdateUserStatisticsRequestCallback(string urlPath, int callId, UpdateUserStatisticsRequest request, object customData);
        public delegate void UpdateUserStatisticsResponseCallback(string urlPath, int callId, UpdateUserStatisticsRequest request, UpdateUserStatisticsResult result, PlayFabError error, object customData);
        public delegate void GetCatalogItemsRequestCallback(string urlPath, int callId, GetCatalogItemsRequest request, object customData);
        public delegate void GetCatalogItemsResponseCallback(string urlPath, int callId, GetCatalogItemsRequest request, GetCatalogItemsResult result, PlayFabError error, object customData);
        public delegate void GetPublisherDataRequestCallback(string urlPath, int callId, GetPublisherDataRequest request, object customData);
        public delegate void GetPublisherDataResponseCallback(string urlPath, int callId, GetPublisherDataRequest request, GetPublisherDataResult result, PlayFabError error, object customData);
        public delegate void GetTitleDataRequestCallback(string urlPath, int callId, GetTitleDataRequest request, object customData);
        public delegate void GetTitleDataResponseCallback(string urlPath, int callId, GetTitleDataRequest request, GetTitleDataResult result, PlayFabError error, object customData);
        public delegate void GetTitleInternalDataRequestCallback(string urlPath, int callId, GetTitleDataRequest request, object customData);
        public delegate void GetTitleInternalDataResponseCallback(string urlPath, int callId, GetTitleDataRequest request, GetTitleDataResult result, PlayFabError error, object customData);
        public delegate void GetTitleNewsRequestCallback(string urlPath, int callId, GetTitleNewsRequest request, object customData);
        public delegate void GetTitleNewsResponseCallback(string urlPath, int callId, GetTitleNewsRequest request, GetTitleNewsResult result, PlayFabError error, object customData);
        public delegate void SetPublisherDataRequestCallback(string urlPath, int callId, SetPublisherDataRequest request, object customData);
        public delegate void SetPublisherDataResponseCallback(string urlPath, int callId, SetPublisherDataRequest request, SetPublisherDataResult result, PlayFabError error, object customData);
        public delegate void SetTitleDataRequestCallback(string urlPath, int callId, SetTitleDataRequest request, object customData);
        public delegate void SetTitleDataResponseCallback(string urlPath, int callId, SetTitleDataRequest request, SetTitleDataResult result, PlayFabError error, object customData);
        public delegate void SetTitleInternalDataRequestCallback(string urlPath, int callId, SetTitleDataRequest request, object customData);
        public delegate void SetTitleInternalDataResponseCallback(string urlPath, int callId, SetTitleDataRequest request, SetTitleDataResult result, PlayFabError error, object customData);
        public delegate void AddCharacterVirtualCurrencyRequestCallback(string urlPath, int callId, AddCharacterVirtualCurrencyRequest request, object customData);
        public delegate void AddCharacterVirtualCurrencyResponseCallback(string urlPath, int callId, AddCharacterVirtualCurrencyRequest request, ModifyCharacterVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void AddUserVirtualCurrencyRequestCallback(string urlPath, int callId, AddUserVirtualCurrencyRequest request, object customData);
        public delegate void AddUserVirtualCurrencyResponseCallback(string urlPath, int callId, AddUserVirtualCurrencyRequest request, ModifyUserVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void ConsumeItemRequestCallback(string urlPath, int callId, ConsumeItemRequest request, object customData);
        public delegate void ConsumeItemResponseCallback(string urlPath, int callId, ConsumeItemRequest request, ConsumeItemResult result, PlayFabError error, object customData);
        public delegate void EvaluateRandomResultTableRequestCallback(string urlPath, int callId, EvaluateRandomResultTableRequest request, object customData);
        public delegate void EvaluateRandomResultTableResponseCallback(string urlPath, int callId, EvaluateRandomResultTableRequest request, EvaluateRandomResultTableResult result, PlayFabError error, object customData);
        public delegate void GetCharacterInventoryRequestCallback(string urlPath, int callId, GetCharacterInventoryRequest request, object customData);
        public delegate void GetCharacterInventoryResponseCallback(string urlPath, int callId, GetCharacterInventoryRequest request, GetCharacterInventoryResult result, PlayFabError error, object customData);
        public delegate void GetUserInventoryRequestCallback(string urlPath, int callId, GetUserInventoryRequest request, object customData);
        public delegate void GetUserInventoryResponseCallback(string urlPath, int callId, GetUserInventoryRequest request, GetUserInventoryResult result, PlayFabError error, object customData);
        public delegate void GrantItemsToCharacterRequestCallback(string urlPath, int callId, GrantItemsToCharacterRequest request, object customData);
        public delegate void GrantItemsToCharacterResponseCallback(string urlPath, int callId, GrantItemsToCharacterRequest request, GrantItemsToCharacterResult result, PlayFabError error, object customData);
        public delegate void GrantItemsToUserRequestCallback(string urlPath, int callId, GrantItemsToUserRequest request, object customData);
        public delegate void GrantItemsToUserResponseCallback(string urlPath, int callId, GrantItemsToUserRequest request, GrantItemsToUserResult result, PlayFabError error, object customData);
        public delegate void GrantItemsToUsersRequestCallback(string urlPath, int callId, GrantItemsToUsersRequest request, object customData);
        public delegate void GrantItemsToUsersResponseCallback(string urlPath, int callId, GrantItemsToUsersRequest request, GrantItemsToUsersResult result, PlayFabError error, object customData);
        public delegate void ModifyItemUsesRequestCallback(string urlPath, int callId, ModifyItemUsesRequest request, object customData);
        public delegate void ModifyItemUsesResponseCallback(string urlPath, int callId, ModifyItemUsesRequest request, ModifyItemUsesResult result, PlayFabError error, object customData);
        public delegate void MoveItemToCharacterFromCharacterRequestCallback(string urlPath, int callId, MoveItemToCharacterFromCharacterRequest request, object customData);
        public delegate void MoveItemToCharacterFromCharacterResponseCallback(string urlPath, int callId, MoveItemToCharacterFromCharacterRequest request, MoveItemToCharacterFromCharacterResult result, PlayFabError error, object customData);
        public delegate void MoveItemToCharacterFromUserRequestCallback(string urlPath, int callId, MoveItemToCharacterFromUserRequest request, object customData);
        public delegate void MoveItemToCharacterFromUserResponseCallback(string urlPath, int callId, MoveItemToCharacterFromUserRequest request, MoveItemToCharacterFromUserResult result, PlayFabError error, object customData);
        public delegate void MoveItemToUserFromCharacterRequestCallback(string urlPath, int callId, MoveItemToUserFromCharacterRequest request, object customData);
        public delegate void MoveItemToUserFromCharacterResponseCallback(string urlPath, int callId, MoveItemToUserFromCharacterRequest request, MoveItemToUserFromCharacterResult result, PlayFabError error, object customData);
        public delegate void RedeemCouponRequestCallback(string urlPath, int callId, RedeemCouponRequest request, object customData);
        public delegate void RedeemCouponResponseCallback(string urlPath, int callId, RedeemCouponRequest request, RedeemCouponResult result, PlayFabError error, object customData);
        public delegate void ReportPlayerRequestCallback(string urlPath, int callId, ReportPlayerServerRequest request, object customData);
        public delegate void ReportPlayerResponseCallback(string urlPath, int callId, ReportPlayerServerRequest request, ReportPlayerServerResult result, PlayFabError error, object customData);
        public delegate void RevokeInventoryItemRequestCallback(string urlPath, int callId, RevokeInventoryItemRequest request, object customData);
        public delegate void RevokeInventoryItemResponseCallback(string urlPath, int callId, RevokeInventoryItemRequest request, RevokeInventoryResult result, PlayFabError error, object customData);
        public delegate void SubtractCharacterVirtualCurrencyRequestCallback(string urlPath, int callId, SubtractCharacterVirtualCurrencyRequest request, object customData);
        public delegate void SubtractCharacterVirtualCurrencyResponseCallback(string urlPath, int callId, SubtractCharacterVirtualCurrencyRequest request, ModifyCharacterVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void SubtractUserVirtualCurrencyRequestCallback(string urlPath, int callId, SubtractUserVirtualCurrencyRequest request, object customData);
        public delegate void SubtractUserVirtualCurrencyResponseCallback(string urlPath, int callId, SubtractUserVirtualCurrencyRequest request, ModifyUserVirtualCurrencyResult result, PlayFabError error, object customData);
        public delegate void UnlockContainerInstanceRequestCallback(string urlPath, int callId, UnlockContainerInstanceRequest request, object customData);
        public delegate void UnlockContainerInstanceResponseCallback(string urlPath, int callId, UnlockContainerInstanceRequest request, UnlockContainerItemResult result, PlayFabError error, object customData);
        public delegate void UnlockContainerItemRequestCallback(string urlPath, int callId, UnlockContainerItemRequest request, object customData);
        public delegate void UnlockContainerItemResponseCallback(string urlPath, int callId, UnlockContainerItemRequest request, UnlockContainerItemResult result, PlayFabError error, object customData);
        public delegate void UpdateUserInventoryItemCustomDataRequestCallback(string urlPath, int callId, UpdateUserInventoryItemDataRequest request, object customData);
        public delegate void UpdateUserInventoryItemCustomDataResponseCallback(string urlPath, int callId, UpdateUserInventoryItemDataRequest request, EmptyResult result, PlayFabError error, object customData);
        public delegate void NotifyMatchmakerPlayerLeftRequestCallback(string urlPath, int callId, NotifyMatchmakerPlayerLeftRequest request, object customData);
        public delegate void NotifyMatchmakerPlayerLeftResponseCallback(string urlPath, int callId, NotifyMatchmakerPlayerLeftRequest request, NotifyMatchmakerPlayerLeftResult result, PlayFabError error, object customData);
        public delegate void RedeemMatchmakerTicketRequestCallback(string urlPath, int callId, RedeemMatchmakerTicketRequest request, object customData);
        public delegate void RedeemMatchmakerTicketResponseCallback(string urlPath, int callId, RedeemMatchmakerTicketRequest request, RedeemMatchmakerTicketResult result, PlayFabError error, object customData);
        public delegate void SetGameServerInstanceDataRequestCallback(string urlPath, int callId, SetGameServerInstanceDataRequest request, object customData);
        public delegate void SetGameServerInstanceDataResponseCallback(string urlPath, int callId, SetGameServerInstanceDataRequest request, SetGameServerInstanceDataResult result, PlayFabError error, object customData);
        public delegate void SetGameServerInstanceStateRequestCallback(string urlPath, int callId, SetGameServerInstanceStateRequest request, object customData);
        public delegate void SetGameServerInstanceStateResponseCallback(string urlPath, int callId, SetGameServerInstanceStateRequest request, SetGameServerInstanceStateResult result, PlayFabError error, object customData);
        public delegate void AwardSteamAchievementRequestCallback(string urlPath, int callId, AwardSteamAchievementRequest request, object customData);
        public delegate void AwardSteamAchievementResponseCallback(string urlPath, int callId, AwardSteamAchievementRequest request, AwardSteamAchievementResult result, PlayFabError error, object customData);
        public delegate void LogEventRequestCallback(string urlPath, int callId, LogEventRequest request, object customData);
        public delegate void LogEventResponseCallback(string urlPath, int callId, LogEventRequest request, LogEventResult result, PlayFabError error, object customData);
        public delegate void WriteCharacterEventRequestCallback(string urlPath, int callId, WriteServerCharacterEventRequest request, object customData);
        public delegate void WriteCharacterEventResponseCallback(string urlPath, int callId, WriteServerCharacterEventRequest request, WriteEventResponse result, PlayFabError error, object customData);
        public delegate void WritePlayerEventRequestCallback(string urlPath, int callId, WriteServerPlayerEventRequest request, object customData);
        public delegate void WritePlayerEventResponseCallback(string urlPath, int callId, WriteServerPlayerEventRequest request, WriteEventResponse result, PlayFabError error, object customData);
        public delegate void WriteTitleEventRequestCallback(string urlPath, int callId, WriteTitleEventRequest request, object customData);
        public delegate void WriteTitleEventResponseCallback(string urlPath, int callId, WriteTitleEventRequest request, WriteEventResponse result, PlayFabError error, object customData);
        public delegate void AddSharedGroupMembersRequestCallback(string urlPath, int callId, AddSharedGroupMembersRequest request, object customData);
        public delegate void AddSharedGroupMembersResponseCallback(string urlPath, int callId, AddSharedGroupMembersRequest request, AddSharedGroupMembersResult result, PlayFabError error, object customData);
        public delegate void CreateSharedGroupRequestCallback(string urlPath, int callId, CreateSharedGroupRequest request, object customData);
        public delegate void CreateSharedGroupResponseCallback(string urlPath, int callId, CreateSharedGroupRequest request, CreateSharedGroupResult result, PlayFabError error, object customData);
        public delegate void DeleteSharedGroupRequestCallback(string urlPath, int callId, DeleteSharedGroupRequest request, object customData);
        public delegate void DeleteSharedGroupResponseCallback(string urlPath, int callId, DeleteSharedGroupRequest request, EmptyResult result, PlayFabError error, object customData);
        public delegate void GetSharedGroupDataRequestCallback(string urlPath, int callId, GetSharedGroupDataRequest request, object customData);
        public delegate void GetSharedGroupDataResponseCallback(string urlPath, int callId, GetSharedGroupDataRequest request, GetSharedGroupDataResult result, PlayFabError error, object customData);
        public delegate void RemoveSharedGroupMembersRequestCallback(string urlPath, int callId, RemoveSharedGroupMembersRequest request, object customData);
        public delegate void RemoveSharedGroupMembersResponseCallback(string urlPath, int callId, RemoveSharedGroupMembersRequest request, RemoveSharedGroupMembersResult result, PlayFabError error, object customData);
        public delegate void UpdateSharedGroupDataRequestCallback(string urlPath, int callId, UpdateSharedGroupDataRequest request, object customData);
        public delegate void UpdateSharedGroupDataResponseCallback(string urlPath, int callId, UpdateSharedGroupDataRequest request, UpdateSharedGroupDataResult result, PlayFabError error, object customData);
        public delegate void ExecuteCloudScriptRequestCallback(string urlPath, int callId, ExecuteCloudScriptServerRequest request, object customData);
        public delegate void ExecuteCloudScriptResponseCallback(string urlPath, int callId, ExecuteCloudScriptServerRequest request, ExecuteCloudScriptResult result, PlayFabError error, object customData);
        public delegate void GetContentDownloadUrlRequestCallback(string urlPath, int callId, GetContentDownloadUrlRequest request, object customData);
        public delegate void GetContentDownloadUrlResponseCallback(string urlPath, int callId, GetContentDownloadUrlRequest request, GetContentDownloadUrlResult result, PlayFabError error, object customData);
        public delegate void DeleteCharacterFromUserRequestCallback(string urlPath, int callId, DeleteCharacterFromUserRequest request, object customData);
        public delegate void DeleteCharacterFromUserResponseCallback(string urlPath, int callId, DeleteCharacterFromUserRequest request, DeleteCharacterFromUserResult result, PlayFabError error, object customData);
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
        public delegate void GetCharacterInternalDataRequestCallback(string urlPath, int callId, GetCharacterDataRequest request, object customData);
        public delegate void GetCharacterInternalDataResponseCallback(string urlPath, int callId, GetCharacterDataRequest request, GetCharacterDataResult result, PlayFabError error, object customData);
        public delegate void GetCharacterReadOnlyDataRequestCallback(string urlPath, int callId, GetCharacterDataRequest request, object customData);
        public delegate void GetCharacterReadOnlyDataResponseCallback(string urlPath, int callId, GetCharacterDataRequest request, GetCharacterDataResult result, PlayFabError error, object customData);
        public delegate void UpdateCharacterDataRequestCallback(string urlPath, int callId, UpdateCharacterDataRequest request, object customData);
        public delegate void UpdateCharacterDataResponseCallback(string urlPath, int callId, UpdateCharacterDataRequest request, UpdateCharacterDataResult result, PlayFabError error, object customData);
        public delegate void UpdateCharacterInternalDataRequestCallback(string urlPath, int callId, UpdateCharacterDataRequest request, object customData);
        public delegate void UpdateCharacterInternalDataResponseCallback(string urlPath, int callId, UpdateCharacterDataRequest request, UpdateCharacterDataResult result, PlayFabError error, object customData);
        public delegate void UpdateCharacterReadOnlyDataRequestCallback(string urlPath, int callId, UpdateCharacterDataRequest request, object customData);
        public delegate void UpdateCharacterReadOnlyDataResponseCallback(string urlPath, int callId, UpdateCharacterDataRequest request, UpdateCharacterDataResult result, PlayFabError error, object customData);

        /// <summary>
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        public static void AuthenticateSessionTicket(AuthenticateSessionTicketRequest request, PlayFabResultCommon.ProcessApiCallback<AuthenticateSessionTicketResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AuthenticateSessionTicketResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/AuthenticateSessionTicket", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, PlayFabResultCommon.ProcessApiCallback<GetPlayFabIDsFromFacebookIDsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayFabIDsFromFacebookIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetPlayFabIDsFromFacebookIDs", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public static void GetPlayFabIDsFromSteamIDs(GetPlayFabIDsFromSteamIDsRequest request, PlayFabResultCommon.ProcessApiCallback<GetPlayFabIDsFromSteamIDsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayFabIDsFromSteamIDsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetPlayFabIDsFromSteamIDs", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        public static void GetUserAccountInfo(GetUserAccountInfoRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserAccountInfoResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserAccountInfoResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserAccountInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        public static void SendPushNotification(SendPushNotificationRequest request, PlayFabResultCommon.ProcessApiCallback<SendPushNotificationResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SendPushNotificationResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SendPushNotification", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        public static void DeleteUsers(DeleteUsersRequest request, PlayFabResultCommon.ProcessApiCallback<DeleteUsersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<DeleteUsersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/DeleteUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetLeaderboard(GetLeaderboardRequest request, PlayFabResultCommon.ProcessApiCallback<GetLeaderboardResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetLeaderboard", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetLeaderboardAroundUser(GetLeaderboardAroundUserRequest request, PlayFabResultCommon.ProcessApiCallback<GetLeaderboardAroundUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardAroundUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetLeaderboardAroundUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the current version and values for the indicated statistics, for the local player.
        /// </summary>
        public static void GetPlayerStatistics(GetPlayerStatisticsRequest request, PlayFabResultCommon.ProcessApiCallback<GetPlayerStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayerStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetPlayerStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, PlayFabResultCommon.ProcessApiCallback<GetPlayerStatisticVersionsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPlayerStatisticVersionsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetPlayerStatisticVersions", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public static void GetUserStatistics(GetUserStatisticsRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        public static void UpdatePlayerStatistics(UpdatePlayerStatisticsRequest request, PlayFabResultCommon.ProcessApiCallback<UpdatePlayerStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdatePlayerStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdatePlayerStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateUserDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateUserStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateUserStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, PlayFabResultCommon.ProcessApiCallback<GetCatalogItemsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCatalogItemsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetPublisherDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetPublisherDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetTitleDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        public static void GetTitleInternalData(GetTitleDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetTitleDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetTitleInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public static void GetTitleNews(GetTitleNewsRequest request, PlayFabResultCommon.ProcessApiCallback<GetTitleNewsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetTitleNewsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetTitleNews", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, PlayFabResultCommon.ProcessApiCallback<SetPublisherDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetPublisherDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, PlayFabResultCommon.ProcessApiCallback<SetTitleDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleInternalData(SetTitleDataRequest request, PlayFabResultCommon.ProcessApiCallback<SetTitleDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetTitleDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SetTitleInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Increments  the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddCharacterVirtualCurrency(AddCharacterVirtualCurrencyRequest request, PlayFabResultCommon.ProcessApiCallback<ModifyCharacterVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyCharacterVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/AddCharacterVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Increments  the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, PlayFabResultCommon.ProcessApiCallback<ModifyUserVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/AddUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public static void ConsumeItem(ConsumeItemRequest request, PlayFabResultCommon.ProcessApiCallback<ConsumeItemResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ConsumeItemResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/ConsumeItem", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
        /// </summary>
        public static void EvaluateRandomResultTable(EvaluateRandomResultTableRequest request, PlayFabResultCommon.ProcessApiCallback<EvaluateRandomResultTableResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<EvaluateRandomResultTableResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/EvaluateRandomResultTable", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static void GetCharacterInventory(GetCharacterInventoryRequest request, PlayFabResultCommon.ProcessApiCallback<GetCharacterInventoryResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetCharacterInventory", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, PlayFabResultCommon.ProcessApiCallback<GetUserInventoryResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetUserInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetUserInventory", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified character's inventory
        /// </summary>
        public static void GrantItemsToCharacter(GrantItemsToCharacterRequest request, PlayFabResultCommon.ProcessApiCallback<GrantItemsToCharacterResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GrantItemsToCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GrantItemsToCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        public static void GrantItemsToUser(GrantItemsToUserRequest request, PlayFabResultCommon.ProcessApiCallback<GrantItemsToUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GrantItemsToUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GrantItemsToUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, PlayFabResultCommon.ProcessApiCallback<GrantItemsToUsersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GrantItemsToUsersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GrantItemsToUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        public static void ModifyItemUses(ModifyItemUsesRequest request, PlayFabResultCommon.ProcessApiCallback<ModifyItemUsesResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyItemUsesResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/ModifyItemUses", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromCharacter(MoveItemToCharacterFromCharacterRequest request, PlayFabResultCommon.ProcessApiCallback<MoveItemToCharacterFromCharacterResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<MoveItemToCharacterFromCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/MoveItemToCharacterFromCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromUser(MoveItemToCharacterFromUserRequest request, PlayFabResultCommon.ProcessApiCallback<MoveItemToCharacterFromUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<MoveItemToCharacterFromUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/MoveItemToCharacterFromUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        public static void MoveItemToUserFromCharacter(MoveItemToUserFromCharacterRequest request, PlayFabResultCommon.ProcessApiCallback<MoveItemToUserFromCharacterResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<MoveItemToUserFromCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/MoveItemToUserFromCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
        /// </summary>
        public static void RedeemCoupon(RedeemCouponRequest request, PlayFabResultCommon.ProcessApiCallback<RedeemCouponResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RedeemCouponResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/RedeemCoupon", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        public static void ReportPlayer(ReportPlayerServerRequest request, PlayFabResultCommon.ProcessApiCallback<ReportPlayerServerResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ReportPlayerServerResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/ReportPlayer", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, PlayFabResultCommon.ProcessApiCallback<RevokeInventoryResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RevokeInventoryResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/RevokeInventoryItem", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Decrements the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractCharacterVirtualCurrency(SubtractCharacterVirtualCurrencyRequest request, PlayFabResultCommon.ProcessApiCallback<ModifyCharacterVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyCharacterVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SubtractCharacterVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, PlayFabResultCommon.ProcessApiCallback<ModifyUserVirtualCurrencyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ModifyUserVirtualCurrencyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SubtractUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static void UnlockContainerInstance(UnlockContainerInstanceRequest request, PlayFabResultCommon.ProcessApiCallback<UnlockContainerItemResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlockContainerItemResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UnlockContainerInstance", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static void UnlockContainerItem(UnlockContainerItemRequest request, PlayFabResultCommon.ProcessApiCallback<UnlockContainerItemResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UnlockContainerItemResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UnlockContainerItem", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        public static void UpdateUserInventoryItemCustomData(UpdateUserInventoryItemDataRequest request, PlayFabResultCommon.ProcessApiCallback<EmptyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<EmptyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateUserInventoryItemCustomData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
        /// </summary>
        public static void NotifyMatchmakerPlayerLeft(NotifyMatchmakerPlayerLeftRequest request, PlayFabResultCommon.ProcessApiCallback<NotifyMatchmakerPlayerLeftResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<NotifyMatchmakerPlayerLeftResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/NotifyMatchmakerPlayerLeft", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Validates a Game Server session ticket and returns details about the user
        /// </summary>
        public static void RedeemMatchmakerTicket(RedeemMatchmakerTicketRequest request, PlayFabResultCommon.ProcessApiCallback<RedeemMatchmakerTicketResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RedeemMatchmakerTicketResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/RedeemMatchmakerTicket", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sets the custom data of the indicated Game Server Instance
        /// </summary>
        public static void SetGameServerInstanceData(SetGameServerInstanceDataRequest request, PlayFabResultCommon.ProcessApiCallback<SetGameServerInstanceDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetGameServerInstanceDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SetGameServerInstanceData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sets the custom data of the indicated Game Server Instance
        /// </summary>
        public static void SetGameServerInstanceData(SetGameServerInstanceDataRequest request, ProcessApiCallback<SetGameServerInstanceDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = SimpleJson.SerializeObject(request, Util.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetGameServerInstanceDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHTTP.Post("/Server/SetGameServerInstanceData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Sets the state of the indicated Game Server Instance
        /// </summary>
        public static void SetGameServerInstanceState(SetGameServerInstanceStateRequest request, PlayFabResultCommon.ProcessApiCallback<SetGameServerInstanceStateResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<SetGameServerInstanceStateResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/SetGameServerInstanceState", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        public static void AwardSteamAchievement(AwardSteamAchievementRequest request, PlayFabResultCommon.ProcessApiCallback<AwardSteamAchievementResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AwardSteamAchievementResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/AwardSteamAchievement", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Logs a custom analytics event
        /// </summary>
        public static void LogEvent(LogEventRequest request, PlayFabResultCommon.ProcessApiCallback<LogEventResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<LogEventResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/LogEvent", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        public static void WriteCharacterEvent(WriteServerCharacterEventRequest request, PlayFabResultCommon.ProcessApiCallback<WriteEventResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<WriteEventResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/WriteCharacterEvent", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        public static void WritePlayerEvent(WriteServerPlayerEventRequest request, PlayFabResultCommon.ProcessApiCallback<WriteEventResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<WriteEventResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/WritePlayerEvent", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        public static void WriteTitleEvent(WriteTitleEventRequest request, PlayFabResultCommon.ProcessApiCallback<WriteEventResponse> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<WriteEventResponse>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/WriteTitleEvent", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
        /// </summary>
        public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, PlayFabResultCommon.ProcessApiCallback<AddSharedGroupMembersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<AddSharedGroupMembersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/AddSharedGroupMembers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
        /// </summary>
        public static void CreateSharedGroup(CreateSharedGroupRequest request, PlayFabResultCommon.ProcessApiCallback<CreateSharedGroupResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<CreateSharedGroupResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/CreateSharedGroup", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group
        /// </summary>
        public static void DeleteSharedGroup(DeleteSharedGroupRequest request, PlayFabResultCommon.ProcessApiCallback<EmptyResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<EmptyResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/DeleteSharedGroup", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
        /// </summary>
        public static void GetSharedGroupData(GetSharedGroupDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetSharedGroupDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetSharedGroupDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetSharedGroupData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
        /// </summary>
        public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, PlayFabResultCommon.ProcessApiCallback<RemoveSharedGroupMembersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<RemoveSharedGroupMembersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/RemoveSharedGroupMembers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
        /// </summary>
        public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateSharedGroupDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateSharedGroupDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateSharedGroupData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' variable set to the specified PlayFabId parameter value.
        /// </summary>
        public static void ExecuteCloudScript(ExecuteCloudScriptServerRequest request, PlayFabResultCommon.ProcessApiCallback<ExecuteCloudScriptResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ExecuteCloudScriptResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/ExecuteCloudScript", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service
        /// </summary>
        public static void GetContentDownloadUrl(GetContentDownloadUrlRequest request, PlayFabResultCommon.ProcessApiCallback<GetContentDownloadUrlResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetContentDownloadUrlResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetContentDownloadUrl", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        public static void DeleteCharacterFromUser(DeleteCharacterFromUserRequest request, PlayFabResultCommon.ProcessApiCallback<DeleteCharacterFromUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<DeleteCharacterFromUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/DeleteCharacterFromUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GetAllUsersCharacters(ListUsersCharactersRequest request, PlayFabResultCommon.ProcessApiCallback<ListUsersCharactersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<ListUsersCharactersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetAllUsersCharacters", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, PlayFabResultCommon.ProcessApiCallback<GetCharacterLeaderboardResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterLeaderboardResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetCharacterLeaderboard", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        public static void GetCharacterStatistics(GetCharacterStatisticsRequest request, PlayFabResultCommon.ProcessApiCallback<GetCharacterStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetCharacterStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        public static void GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, PlayFabResultCommon.ProcessApiCallback<GetLeaderboardAroundCharacterResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardAroundCharacterResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetLeaderboardAroundCharacter", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static void GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, PlayFabResultCommon.ProcessApiCallback<GetLeaderboardForUsersCharactersResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetLeaderboardForUsersCharactersResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetLeaderboardForUserCharacters", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GrantCharacterToUser(GrantCharacterToUserRequest request, PlayFabResultCommon.ProcessApiCallback<GrantCharacterToUserResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GrantCharacterToUserResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GrantCharacterToUser", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        public static void UpdateCharacterStatistics(UpdateCharacterStatisticsRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateCharacterStatisticsResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCharacterStatisticsResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateCharacterStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetCharacterData(GetCharacterDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetCharacterData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        public static void GetCharacterInternalData(GetCharacterDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetCharacterInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void GetCharacterReadOnlyData(GetCharacterDataRequest request, PlayFabResultCommon.ProcessApiCallback<GetCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<GetCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/GetCharacterReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
        /// </summary>
        public static void UpdateCharacterData(UpdateCharacterDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateCharacterData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
        /// </summary>
        public static void UpdateCharacterInternalData(UpdateCharacterDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateCharacterInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void UpdateCharacterReadOnlyData(UpdateCharacterDataRequest request, PlayFabResultCommon.ProcessApiCallback<UpdateCharacterDataResult> resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonWrapper.SerializeObject(request, PlayFabUtil.ApiSerializerStrategy);
            Action<CallRequestContainer> callback = delegate(CallRequestContainer requestContainer)
            {
                ResultContainer<UpdateCharacterDataResult>.HandleResults(requestContainer, resultCallback, errorCallback, null);
            };
            PlayFabHttp.Post("/Server/UpdateCharacterReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback, request, customData);
        }


    }
}
