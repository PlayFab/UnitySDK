#if ENABLE_PLAYFABSERVER_API
using System;
using PlayFab.ServerModels;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab
{
    /// <summary>
    /// Provides functionality to allow external (developer-controlled) servers to interact with user inventories and data in a trusted manner, and to handle matchmaking and client connection orchestration
    /// </summary>
    public static class PlayFabServerAPI
    {

        /// <summary>
        /// Validated a client's session ticket, and if successful, returns details for that user
        /// </summary>
        public static void AuthenticateSessionTicket(AuthenticateSessionTicketRequest request, Action<AuthenticateSessionTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AuthenticateSessionTicketRequest, AuthenticateSessionTicketResult>("Server", "/Server/AuthenticateSessionTicket", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Facebook identifiers.
        /// </summary>
        public static void GetPlayFabIDsFromFacebookIDs(GetPlayFabIDsFromFacebookIDsRequest request, Action<GetPlayFabIDsFromFacebookIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPlayFabIDsFromFacebookIDsRequest, GetPlayFabIDsFromFacebookIDsResult>("Server", "/Server/GetPlayFabIDsFromFacebookIDs", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the unique PlayFab identifiers for the given set of Steam identifiers. The Steam identifiers  are the profile IDs for the user accounts, available as SteamId in the Steamworks Community API calls.
        /// </summary>
        public static void GetPlayFabIDsFromSteamIDs(GetPlayFabIDsFromSteamIDsRequest request, Action<GetPlayFabIDsFromSteamIDsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPlayFabIDsFromSteamIDsRequest, GetPlayFabIDsFromSteamIDsResult>("Server", "/Server/GetPlayFabIDsFromSteamIDs", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the relevant details for a specified user
        /// </summary>
        public static void GetUserAccountInfo(GetUserAccountInfoRequest request, Action<GetUserAccountInfoResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserAccountInfoRequest, GetUserAccountInfoResult>("Server", "/Server/GetUserAccountInfo", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sends an iOS/Android Push Notification to a specific user, if that user's device has been configured for Push Notifications in PlayFab. If a user has linked both Android and iOS devices, both will be notified.
        /// </summary>
        public static void SendPushNotification(SendPushNotificationRequest request, Action<SendPushNotificationResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SendPushNotificationRequest, SendPushNotificationResult>("Server", "/Server/SendPushNotification", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        public static void DeleteUsers(DeleteUsersRequest request, Action<DeleteUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<DeleteUsersRequest, DeleteUsersResult>("Server", "/Server/DeleteUsers", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetLeaderboard(GetLeaderboardRequest request, Action<GetLeaderboardResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetLeaderboardRequest, GetLeaderboardResult>("Server", "/Server/GetLeaderboard", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked users for the given statistic, centered on the currently signed-in user
        /// </summary>
        public static void GetLeaderboardAroundUser(GetLeaderboardAroundUserRequest request, Action<GetLeaderboardAroundUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetLeaderboardAroundUserRequest, GetLeaderboardAroundUserResult>("Server", "/Server/GetLeaderboardAroundUser", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the current version and values for the indicated statistics, for the local player.
        /// </summary>
        public static void GetPlayerStatistics(GetPlayerStatisticsRequest request, Action<GetPlayerStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPlayerStatisticsRequest, GetPlayerStatisticsResult>("Server", "/Server/GetPlayerStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the information on the available versions of the specified statistic.
        /// </summary>
        public static void GetPlayerStatisticVersions(GetPlayerStatisticVersionsRequest request, Action<GetPlayerStatisticVersionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPlayerStatisticVersionsRequest, GetPlayerStatisticVersionsResult>("Server", "/Server/GetPlayerStatisticVersions", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Server", "/Server/GetUserData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Server", "/Server/GetUserInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Server", "/Server/GetUserPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Server", "/Server/GetUserPublisherInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Server", "/Server/GetUserPublisherReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, Action<GetUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserDataRequest, GetUserDataResult>("Server", "/Server/GetUserReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the user
        /// </summary>
        public static void GetUserStatistics(GetUserStatisticsRequest request, Action<GetUserStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserStatisticsRequest, GetUserStatisticsResult>("Server", "/Server/GetUserStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user
        /// </summary>
        public static void UpdatePlayerStatistics(UpdatePlayerStatisticsRequest request, Action<UpdatePlayerStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdatePlayerStatisticsRequest, UpdatePlayerStatisticsResult>("Server", "/Server/UpdatePlayerStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Server", "/Server/UpdateUserData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserInternalDataRequest, UpdateUserDataResult>("Server", "/Server/UpdateUserInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Server", "/Server/UpdateUserPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserInternalDataRequest, UpdateUserDataResult>("Server", "/Server/UpdateUserPublisherInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Server", "/Server/UpdateUserPublisherReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, Action<UpdateUserDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserDataRequest, UpdateUserDataResult>("Server", "/Server/UpdateUserReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to update statistics. Developers may override this setting in the Game Manager > Settings > API Features.
        /// </summary>
        public static void UpdateUserStatistics(UpdateUserStatisticsRequest request, Action<UpdateUserStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserStatisticsRequest, UpdateUserStatisticsResult>("Server", "/Server/UpdateUserStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, Action<GetCatalogItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCatalogItemsRequest, GetCatalogItemsResult>("Server", "/Server/GetCatalogItems", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, Action<GetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetPublisherDataRequest, GetPublisherDataResult>("Server", "/Server/GetPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetTitleDataRequest, GetTitleDataResult>("Server", "/Server/GetTitleData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        public static void GetTitleInternalData(GetTitleDataRequest request, Action<GetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetTitleDataRequest, GetTitleDataResult>("Server", "/Server/GetTitleInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        public static void GetTitleNews(GetTitleNewsRequest request, Action<GetTitleNewsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetTitleNewsRequest, GetTitleNewsResult>("Server", "/Server/GetTitleNews", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, Action<SetPublisherDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetPublisherDataRequest, SetPublisherDataResult>("Server", "/Server/SetPublisherData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetTitleDataRequest, SetTitleDataResult>("Server", "/Server/SetTitleData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleInternalData(SetTitleDataRequest request, Action<SetTitleDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetTitleDataRequest, SetTitleDataResult>("Server", "/Server/SetTitleInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Increments  the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddCharacterVirtualCurrency(AddCharacterVirtualCurrencyRequest request, Action<ModifyCharacterVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AddCharacterVirtualCurrencyRequest, ModifyCharacterVirtualCurrencyResult>("Server", "/Server/AddCharacterVirtualCurrency", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Increments  the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AddUserVirtualCurrencyRequest, ModifyUserVirtualCurrencyResult>("Server", "/Server/AddUserVirtualCurrency", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Consume uses of a consumable item. When all uses are consumed, it will be removed from the player's inventory.
        /// </summary>
        public static void ConsumeItem(ConsumeItemRequest request, Action<ConsumeItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ConsumeItemRequest, ConsumeItemResult>("Server", "/Server/ConsumeItem", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Returns the result of an evaluation of a Random Result Table - the ItemId from the game Catalog which would have been added to the player inventory, if the Random Result Table were added via a Bundle or a call to UnlockContainer.
        /// </summary>
        public static void EvaluateRandomResultTable(EvaluateRandomResultTableRequest request, Action<EvaluateRandomResultTableResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<EvaluateRandomResultTableRequest, EvaluateRandomResultTableResult>("Server", "/Server/EvaluateRandomResultTable", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the specified character's current inventory of virtual goods
        /// </summary>
        public static void GetCharacterInventory(GetCharacterInventoryRequest request, Action<GetCharacterInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCharacterInventoryRequest, GetCharacterInventoryResult>("Server", "/Server/GetCharacterInventory", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, Action<GetUserInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetUserInventoryRequest, GetUserInventoryResult>("Server", "/Server/GetUserInventory", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified character's inventory
        /// </summary>
        public static void GrantItemsToCharacter(GrantItemsToCharacterRequest request, Action<GrantItemsToCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GrantItemsToCharacterRequest, GrantItemsToCharacterResult>("Server", "/Server/GrantItemsToCharacter", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user's inventory
        /// </summary>
        public static void GrantItemsToUser(GrantItemsToUserRequest request, Action<GrantItemsToUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GrantItemsToUserRequest, GrantItemsToUserResult>("Server", "/Server/GrantItemsToUser", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, Action<GrantItemsToUsersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GrantItemsToUsersRequest, GrantItemsToUsersResult>("Server", "/Server/GrantItemsToUsers", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Modifies the number of remaining uses of a player's inventory item
        /// </summary>
        public static void ModifyItemUses(ModifyItemUsesRequest request, Action<ModifyItemUsesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ModifyItemUsesRequest, ModifyItemUsesResult>("Server", "/Server/ModifyItemUses", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Moves an item from a character's inventory into another of the users's character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromCharacter(MoveItemToCharacterFromCharacterRequest request, Action<MoveItemToCharacterFromCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<MoveItemToCharacterFromCharacterRequest, MoveItemToCharacterFromCharacterResult>("Server", "/Server/MoveItemToCharacterFromCharacter", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Moves an item from a user's inventory into their character's inventory.
        /// </summary>
        public static void MoveItemToCharacterFromUser(MoveItemToCharacterFromUserRequest request, Action<MoveItemToCharacterFromUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<MoveItemToCharacterFromUserRequest, MoveItemToCharacterFromUserResult>("Server", "/Server/MoveItemToCharacterFromUser", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Moves an item from a character's inventory into the owning user's inventory.
        /// </summary>
        public static void MoveItemToUserFromCharacter(MoveItemToUserFromCharacterRequest request, Action<MoveItemToUserFromCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<MoveItemToUserFromCharacterRequest, MoveItemToUserFromCharacterResult>("Server", "/Server/MoveItemToUserFromCharacter", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds the virtual goods associated with the coupon to the user's inventory. Coupons can be generated  via the Promotions->Coupons tab in the PlayFab Game Manager. See this post for more information on coupons:  https://playfab.com/blog/2015/06/18/using-stores-and-coupons-game-manager
        /// </summary>
        public static void RedeemCoupon(RedeemCouponRequest request, Action<RedeemCouponResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<RedeemCouponRequest, RedeemCouponResult>("Server", "/Server/RedeemCoupon", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Submit a report about a player (due to bad bahavior, etc.) on behalf of another player, so that customer service representatives for the title can take action concerning potentially toxic players.
        /// </summary>
        public static void ReportPlayer(ReportPlayerServerRequest request, Action<ReportPlayerServerResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ReportPlayerServerRequest, ReportPlayerServerResult>("Server", "/Server/ReportPlayer", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, Action<RevokeInventoryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<RevokeInventoryItemRequest, RevokeInventoryResult>("Server", "/Server/RevokeInventoryItem", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Decrements the character's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractCharacterVirtualCurrency(SubtractCharacterVirtualCurrencyRequest request, Action<ModifyCharacterVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SubtractCharacterVirtualCurrencyRequest, ModifyCharacterVirtualCurrencyResult>("Server", "/Server/SubtractCharacterVirtualCurrency", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Decrements the user's balance of the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, Action<ModifyUserVirtualCurrencyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SubtractUserVirtualCurrencyRequest, ModifyUserVirtualCurrencyResult>("Server", "/Server/SubtractUserVirtualCurrency", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Opens a specific container (ContainerItemInstanceId), with a specific key (KeyItemInstanceId, when required), and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static void UnlockContainerInstance(UnlockContainerInstanceRequest request, Action<UnlockContainerItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UnlockContainerInstanceRequest, UnlockContainerItemResult>("Server", "/Server/UnlockContainerInstance", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Searches Player or Character inventory for any ItemInstance matching the given CatalogItemId, if necessary unlocks it using any appropriate key, and returns the contents of the opened container. If the container (and key when relevant) are consumable (RemainingUses > 0), their RemainingUses will be decremented, consistent with the operation of ConsumeItem.
        /// </summary>
        public static void UnlockContainerItem(UnlockContainerItemRequest request, Action<UnlockContainerItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UnlockContainerItemRequest, UnlockContainerItemResult>("Server", "/Server/UnlockContainerItem", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the key-value pair data tagged to the specified item, which is read-only from the client.
        /// </summary>
        public static void UpdateUserInventoryItemCustomData(UpdateUserInventoryItemDataRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateUserInventoryItemDataRequest, EmptyResult>("Server", "/Server/UpdateUserInventoryItemCustomData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Informs the PlayFab match-making service that the user specified has left the Game Server Instance
        /// </summary>
        public static void NotifyMatchmakerPlayerLeft(NotifyMatchmakerPlayerLeftRequest request, Action<NotifyMatchmakerPlayerLeftResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<NotifyMatchmakerPlayerLeftRequest, NotifyMatchmakerPlayerLeftResult>("Server", "/Server/NotifyMatchmakerPlayerLeft", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Validates a Game Server session ticket and returns details about the user
        /// </summary>
        public static void RedeemMatchmakerTicket(RedeemMatchmakerTicketRequest request, Action<RedeemMatchmakerTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<RedeemMatchmakerTicketRequest, RedeemMatchmakerTicketResult>("Server", "/Server/RedeemMatchmakerTicket", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets the custom data of the indicated Game Server Instance
        /// </summary>
        public static void SetGameServerInstanceData(SetGameServerInstanceDataRequest request, Action<SetGameServerInstanceDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetGameServerInstanceDataRequest, SetGameServerInstanceDataResult>("Server", "/Server/SetGameServerInstanceData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Sets the state of the indicated Game Server Instance
        /// </summary>
        public static void SetGameServerInstanceState(SetGameServerInstanceStateRequest request, Action<SetGameServerInstanceStateResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<SetGameServerInstanceStateRequest, SetGameServerInstanceStateResult>("Server", "/Server/SetGameServerInstanceState", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Awards the specified users the specified Steam achievements
        /// </summary>
        public static void AwardSteamAchievement(AwardSteamAchievementRequest request, Action<AwardSteamAchievementResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AwardSteamAchievementRequest, AwardSteamAchievementResult>("Server", "/Server/AwardSteamAchievement", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Logs a custom analytics event
        /// </summary>
        public static void LogEvent(LogEventRequest request, Action<LogEventResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<LogEventRequest, LogEventResult>("Server", "/Server/LogEvent", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Writes a character-based event into PlayStream.
        /// </summary>
        public static void WriteCharacterEvent(WriteServerCharacterEventRequest request, Action<WriteEventResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<WriteServerCharacterEventRequest, WriteEventResponse>("Server", "/Server/WriteCharacterEvent", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Writes a player-based event into PlayStream.
        /// </summary>
        public static void WritePlayerEvent(WriteServerPlayerEventRequest request, Action<WriteEventResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<WriteServerPlayerEventRequest, WriteEventResponse>("Server", "/Server/WritePlayerEvent", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Writes a title-based event into PlayStream.
        /// </summary>
        public static void WriteTitleEvent(WriteTitleEventRequest request, Action<WriteEventResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<WriteTitleEventRequest, WriteEventResponse>("Server", "/Server/WriteTitleEvent", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds users to the set of those able to update both the shared data, as well as the set of users in the group. Only users in the group (and the server) can add new members.
        /// </summary>
        public static void AddSharedGroupMembers(AddSharedGroupMembersRequest request, Action<AddSharedGroupMembersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<AddSharedGroupMembersRequest, AddSharedGroupMembersResult>("Server", "/Server/AddSharedGroupMembers", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Requests the creation of a shared group object, containing key/value pairs which may be updated by all members of the group. When created by a server, the group will initially have no members.
        /// </summary>
        public static void CreateSharedGroup(CreateSharedGroupRequest request, Action<CreateSharedGroupResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<CreateSharedGroupRequest, CreateSharedGroupResult>("Server", "/Server/CreateSharedGroup", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Deletes a shared group, freeing up the shared group ID to be reused for a new group
        /// </summary>
        public static void DeleteSharedGroup(DeleteSharedGroupRequest request, Action<EmptyResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<DeleteSharedGroupRequest, EmptyResult>("Server", "/Server/DeleteSharedGroup", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves data stored in a shared group object, as well as the list of members in the group. The server can access all public and private group data.
        /// </summary>
        public static void GetSharedGroupData(GetSharedGroupDataRequest request, Action<GetSharedGroupDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetSharedGroupDataRequest, GetSharedGroupDataResult>("Server", "/Server/GetSharedGroupData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Removes users from the set of those able to update the shared data and the set of users in the group. Only users in the group can remove members. If as a result of the call, zero users remain with access, the group and its associated data will be deleted.
        /// </summary>
        public static void RemoveSharedGroupMembers(RemoveSharedGroupMembersRequest request, Action<RemoveSharedGroupMembersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<RemoveSharedGroupMembersRequest, RemoveSharedGroupMembersResult>("Server", "/Server/RemoveSharedGroupMembers", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Adds, updates, and removes data keys for a shared group object. If the permission is set to Public, all fields updated or added in this call will be readable by users not in the group. By default, data permissions are set to Private. Regardless of the permission setting, only members of the group (and the server) can update the data.
        /// </summary>
        public static void UpdateSharedGroupData(UpdateSharedGroupDataRequest request, Action<UpdateSharedGroupDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateSharedGroupDataRequest, UpdateSharedGroupDataResult>("Server", "/Server/UpdateSharedGroupData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' variable set to the specified PlayFabId parameter value.
        /// </summary>
        public static void ExecuteCloudScript(ExecuteCloudScriptServerRequest request, Action<ExecuteCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ExecuteCloudScriptServerRequest, ExecuteCloudScriptResult>("Server", "/Server/ExecuteCloudScript", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// This API retrieves a pre-signed URL for accessing a content file for the title. A subsequent  HTTP GET to the returned URL will attempt to download the content. A HEAD query to the returned URL will attempt to  retrieve the metadata of the content. Note that a successful result does not guarantee the existence of this content -  if it has not been uploaded, the query to retrieve the data will fail. See this post for more information:  https://community.playfab.com/hc/en-us/community/posts/205469488-How-to-upload-files-to-PlayFab-s-Content-Service
        /// </summary>
        public static void GetContentDownloadUrl(GetContentDownloadUrlRequest request, Action<GetContentDownloadUrlResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetContentDownloadUrlRequest, GetContentDownloadUrlResult>("Server", "/Server/GetContentDownloadUrl", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Deletes the specific character ID from the specified user.
        /// </summary>
        public static void DeleteCharacterFromUser(DeleteCharacterFromUserRequest request, Action<DeleteCharacterFromUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<DeleteCharacterFromUserRequest, DeleteCharacterFromUserResult>("Server", "/Server/DeleteCharacterFromUser", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Lists all of the characters that belong to a specific user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GetAllUsersCharacters(ListUsersCharactersRequest request, Action<ListUsersCharactersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<ListUsersCharactersRequest, ListUsersCharactersResult>("Server", "/Server/GetAllUsersCharacters", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, starting from the indicated point in the leaderboard
        /// </summary>
        public static void GetCharacterLeaderboard(GetCharacterLeaderboardRequest request, Action<GetCharacterLeaderboardResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCharacterLeaderboardRequest, GetCharacterLeaderboardResult>("Server", "/Server/GetCharacterLeaderboard", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the details of all title-specific statistics for the specific character
        /// </summary>
        public static void GetCharacterStatistics(GetCharacterStatisticsRequest request, Action<GetCharacterStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCharacterStatisticsRequest, GetCharacterStatisticsResult>("Server", "/Server/GetCharacterStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves a list of ranked characters for the given statistic, centered on the requested user
        /// </summary>
        public static void GetLeaderboardAroundCharacter(GetLeaderboardAroundCharacterRequest request, Action<GetLeaderboardAroundCharacterResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetLeaderboardAroundCharacterRequest, GetLeaderboardAroundCharacterResult>("Server", "/Server/GetLeaderboardAroundCharacter", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves a list of all of the user's characters for the given statistic.
        /// </summary>
        public static void GetLeaderboardForUserCharacters(GetLeaderboardForUsersCharactersRequest request, Action<GetLeaderboardForUsersCharactersResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetLeaderboardForUsersCharactersRequest, GetLeaderboardForUsersCharactersResult>("Server", "/Server/GetLeaderboardForUserCharacters", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Grants the specified character type to the user. CharacterIds are not globally unique; characterId must be evaluated with the parent PlayFabId to guarantee uniqueness.
        /// </summary>
        public static void GrantCharacterToUser(GrantCharacterToUserRequest request, Action<GrantCharacterToUserResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GrantCharacterToUserRequest, GrantCharacterToUserResult>("Server", "/Server/GrantCharacterToUser", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the values of the specified title-specific statistics for the specific character
        /// </summary>
        public static void UpdateCharacterStatistics(UpdateCharacterStatisticsRequest request, Action<UpdateCharacterStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateCharacterStatisticsRequest, UpdateCharacterStatisticsResult>("Server", "/Server/UpdateCharacterStatistics", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetCharacterData(GetCharacterDataRequest request, Action<GetCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCharacterDataRequest, GetCharacterDataResult>("Server", "/Server/GetCharacterData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which cannot be accessed by the client
        /// </summary>
        public static void GetCharacterInternalData(GetCharacterDataRequest request, Action<GetCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCharacterDataRequest, GetCharacterDataResult>("Server", "/Server/GetCharacterInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void GetCharacterReadOnlyData(GetCharacterDataRequest request, Action<GetCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<GetCharacterDataRequest, GetCharacterDataResult>("Server", "/Server/GetCharacterReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's chjaracter which is readable and writable by the client
        /// </summary>
        public static void UpdateCharacterData(UpdateCharacterDataRequest request, Action<UpdateCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateCharacterDataRequest, UpdateCharacterDataResult>("Server", "/Server/UpdateCharacterData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which cannot  be accessed by the client
        /// </summary>
        public static void UpdateCharacterInternalData(UpdateCharacterDataRequest request, Action<UpdateCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateCharacterDataRequest, UpdateCharacterDataResult>("Server", "/Server/UpdateCharacterInternalData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user's character which can only be read by the client
        /// </summary>
        public static void UpdateCharacterReadOnlyData(UpdateCharacterDataRequest request, Action<UpdateCharacterDataResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            PlayFabHttp.MakeApiCall<UpdateCharacterDataRequest, UpdateCharacterDataResult>("Server", "/Server/UpdateCharacterReadOnlyData", request , "X-SecretKey", resultCallback, errorCallback, customData);
        }


    }
}
#endif
