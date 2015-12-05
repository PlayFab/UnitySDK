using System;
using PlayFab.Json;
using PlayFab.AdminModels;
using PlayFab.Internal;

namespace PlayFab
{
    /// <summary>
    /// APIs for managing title configurations, uploaded Game Server code executables, and user data
    /// </summary>
    public class PlayFabAdminAPI
    {
        public delegate void GetUserAccountInfoCallback(LookupUserAccountInfoResult result);
        public delegate void ResetUsersCallback(BlankResult result);
        public delegate void SendAccountRecoveryEmailCallback(SendAccountRecoveryEmailResult result);
        public delegate void UpdateUserTitleDisplayNameCallback(UpdateUserTitleDisplayNameResult result);
        public delegate void DeleteUsersCallback(DeleteUsersResult result);
        public delegate void GetDataReportCallback(GetDataReportResult result);
        public delegate void GetUserDataCallback(GetUserDataResult result);
        public delegate void GetUserInternalDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherInternalDataCallback(GetUserDataResult result);
        public delegate void GetUserPublisherReadOnlyDataCallback(GetUserDataResult result);
        public delegate void GetUserReadOnlyDataCallback(GetUserDataResult result);
        public delegate void ResetUserStatisticsCallback(ResetUserStatisticsResult result);
        public delegate void UpdateUserDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserInternalDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserPublisherDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserPublisherInternalDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserPublisherReadOnlyDataCallback(UpdateUserDataResult result);
        public delegate void UpdateUserReadOnlyDataCallback(UpdateUserDataResult result);
        public delegate void AddNewsCallback(AddNewsResult result);
        public delegate void AddVirtualCurrencyTypesCallback(BlankResult result);
        public delegate void GetCatalogItemsCallback(GetCatalogItemsResult result);
        public delegate void GetRandomResultTablesCallback(GetRandomResultTablesResult result);
        public delegate void GetStoreItemsCallback(GetStoreItemsResult result);
        public delegate void GetTitleDataCallback(GetTitleDataResult result);
        public delegate void ListVirtualCurrencyTypesCallback(ListVirtualCurrencyTypesResult result);
        public delegate void SetCatalogItemsCallback(UpdateCatalogItemsResult result);
        public delegate void SetStoreItemsCallback(UpdateStoreItemsResult result);
        public delegate void SetTitleDataCallback(SetTitleDataResult result);
        public delegate void SetupPushNotificationCallback(SetupPushNotificationResult result);
        public delegate void UpdateCatalogItemsCallback(UpdateCatalogItemsResult result);
        public delegate void UpdateRandomResultTablesCallback(UpdateRandomResultTablesResult result);
        public delegate void UpdateStoreItemsCallback(UpdateStoreItemsResult result);
        public delegate void AddUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
        public delegate void GetUserInventoryCallback(GetUserInventoryResult result);
        public delegate void GrantItemsToUsersCallback(GrantItemsToUsersResult result);
        public delegate void RevokeInventoryItemCallback(RevokeInventoryResult result);
        public delegate void SubtractUserVirtualCurrencyCallback(ModifyUserVirtualCurrencyResult result);
        public delegate void GetMatchmakerGameInfoCallback(GetMatchmakerGameInfoResult result);
        public delegate void GetMatchmakerGameModesCallback(GetMatchmakerGameModesResult result);
        public delegate void ModifyMatchmakerGameModesCallback(ModifyMatchmakerGameModesResult result);
        public delegate void AddServerBuildCallback(AddServerBuildResult result);
        public delegate void GetServerBuildInfoCallback(GetServerBuildInfoResult result);
        public delegate void GetServerBuildUploadUrlCallback(GetServerBuildUploadURLResult result);
        public delegate void ListServerBuildsCallback(ListBuildsResult result);
        public delegate void ModifyServerBuildCallback(ModifyServerBuildResult result);
        public delegate void RemoveServerBuildCallback(RemoveServerBuildResult result);
        public delegate void GetPublisherDataCallback(GetPublisherDataResult result);
        public delegate void SetPublisherDataCallback(SetPublisherDataResult result);
        public delegate void GetCloudScriptRevisionCallback(GetCloudScriptRevisionResult result);
        public delegate void GetCloudScriptVersionsCallback(GetCloudScriptVersionsResult result);
        public delegate void SetPublishedRevisionCallback(SetPublishedRevisionResult result);
        public delegate void UpdateCloudScriptCallback(UpdateCloudScriptResult result);
        public delegate void DeleteContentCallback(BlankResult result);
        public delegate void GetContentListCallback(GetContentListResult result);
        public delegate void GetContentUploadUrlCallback(GetContentUploadUrlResult result);
        public delegate void ResetCharacterStatisticsCallback(ResetCharacterStatisticsResult result);


        /// <summary>
        /// Retrieves the relevant details for a specified user, based upon a match against a supplied unique identifier
        /// </summary>
        public static void GetUserAccountInfo(LookupUserAccountInfoRequest request, GetUserAccountInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                LookupUserAccountInfoResult result;
                ResultContainer<LookupUserAccountInfoResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserAccountInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Resets all title-specific information about a particular account, including user data, virtual currency balances, inventory, purchase history, and statistics
        /// </summary>
        public static void ResetUsers(ResetUsersRequest request, ResetUsersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                BlankResult result;
                ResultContainer<BlankResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ResetUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Forces an email to be sent to the registered email address for the specified account, with a link allowing the user to change the password
        /// </summary>
        public static void SendAccountRecoveryEmail(SendAccountRecoveryEmailRequest request, SendAccountRecoveryEmailCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SendAccountRecoveryEmail", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the title specific display name for a user
        /// </summary>
        public static void UpdateUserTitleDisplayName(UpdateUserTitleDisplayNameRequest request, UpdateUserTitleDisplayNameCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserTitleDisplayName", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Deletes the users for the provided game. Deletes custom data, all account linkages, and statistics.
        /// </summary>
        public static void DeleteUsers(DeleteUsersRequest request, DeleteUsersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                DeleteUsersResult result;
                ResultContainer<DeleteUsersResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/DeleteUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves a download URL for the requested report
        /// </summary>
        public static void GetDataReport(GetDataReportRequest request, GetDataReportCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetDataReportResult result;
                ResultContainer<GetDataReportResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetDataReport", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserData(GetUserDataRequest request, GetUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserInternalData(GetUserDataRequest request, GetUserInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void GetUserPublisherData(GetUserDataRequest request, GetUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void GetUserPublisherInternalData(GetUserDataRequest request, GetUserPublisherInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserPublisherReadOnlyData(GetUserDataRequest request, GetUserPublisherReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void GetUserReadOnlyData(GetUserDataRequest request, GetUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Completely removes all statistics for the specified user, for the current game
        /// </summary>
        public static void ResetUserStatistics(ResetUserStatisticsRequest request, ResetUserStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ResetUserStatisticsResult result;
                ResultContainer<ResetUserStatisticsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ResetUserStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserData(UpdateUserDataRequest request, UpdateUserDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserInternalData(UpdateUserInternalDataRequest request, UpdateUserInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which is readable and writable by the client
        /// </summary>
        public static void UpdateUserPublisherData(UpdateUserDataRequest request, UpdateUserPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which cannot be accessed by the client
        /// </summary>
        public static void UpdateUserPublisherInternalData(UpdateUserInternalDataRequest request, UpdateUserPublisherInternalDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserPublisherInternalData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the publisher-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserPublisherReadOnlyData(UpdateUserDataRequest request, UpdateUserPublisherReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserPublisherReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the title-specific custom data for the user which can only be read by the client
        /// </summary>
        public static void UpdateUserReadOnlyData(UpdateUserDataRequest request, UpdateUserReadOnlyDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateUserReadOnlyData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Adds a new news item to the title's news feed
        /// </summary>
        public static void AddNews(AddNewsRequest request, AddNewsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AddNewsResult result;
                ResultContainer<AddNewsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddNews", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Adds one or more virtual currencies to the set defined for the title. Virtual Currencies have a maximum value of 2,147,483,647 when granted to a player. Any value over that will be discarded.
        /// </summary>
        public static void AddVirtualCurrencyTypes(AddVirtualCurrencyTypesRequest request, AddVirtualCurrencyTypesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                BlankResult result;
                ResultContainer<BlankResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddVirtualCurrencyTypes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the specified version of the title's catalog of virtual goods, including all defined properties
        /// </summary>
        public static void GetCatalogItems(GetCatalogItemsRequest request, GetCatalogItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the random drop table configuration for the title
        /// </summary>
        public static void GetRandomResultTables(GetRandomResultTablesRequest request, GetRandomResultTablesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetRandomResultTablesResult result;
                ResultContainer<GetRandomResultTablesResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetRandomResultTables", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the set of items defined for the specified store, including all prices defined
        /// </summary>
        public static void GetStoreItems(GetStoreItemsRequest request, GetStoreItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetStoreItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        public static void GetTitleData(GetTitleDataRequest request, GetTitleDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retuns the list of all defined virtual currencies for the title
        /// </summary>
        public static void ListVirtualCurrencyTypes(ListVirtualCurrencyTypesRequest request, ListVirtualCurrencyTypesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ListVirtualCurrencyTypesResult result;
                ResultContainer<ListVirtualCurrencyTypesResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ListVirtualCurrencyTypes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Creates the catalog configuration of all virtual goods for the specified catalog version
        /// </summary>
        public static void SetCatalogItems(UpdateCatalogItemsRequest request, SetCatalogItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateCatalogItemsResult result;
                ResultContainer<UpdateCatalogItemsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Sets all the items in one virtual store
        /// </summary>
        public static void SetStoreItems(UpdateStoreItemsRequest request, SetStoreItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateStoreItemsResult result;
                ResultContainer<UpdateStoreItemsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetStoreItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Creates and updates the key-value store of custom title settings
        /// </summary>
        public static void SetTitleData(SetTitleDataRequest request, SetTitleDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                SetTitleDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetTitleData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Sets the Amazon Resource Name (ARN) for iOS and Android push notifications. Documentation on the exact restrictions can be found at: http://docs.aws.amazon.com/sns/latest/api/API_CreatePlatformApplication.html. Currently, Amazon device Messaging is not supported.
        /// </summary>
        public static void SetupPushNotification(SetupPushNotificationRequest request, SetupPushNotificationCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                SetupPushNotificationResult result;
                ResultContainer<SetupPushNotificationResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetupPushNotification", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the catalog configuration for virtual goods in the specified catalog version
        /// </summary>
        public static void UpdateCatalogItems(UpdateCatalogItemsRequest request, UpdateCatalogItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateCatalogItemsResult result;
                ResultContainer<UpdateCatalogItemsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateCatalogItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the random drop table configuration for the title
        /// </summary>
        public static void UpdateRandomResultTables(UpdateRandomResultTablesRequest request, UpdateRandomResultTablesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateRandomResultTablesResult result;
                ResultContainer<UpdateRandomResultTablesResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateRandomResultTables", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates an existing virtual item store with new or modified items
        /// </summary>
        public static void UpdateStoreItems(UpdateStoreItemsRequest request, UpdateStoreItemsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateStoreItemsResult result;
                ResultContainer<UpdateStoreItemsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateStoreItems", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Increments the specified virtual currency by the stated amount
        /// </summary>
        public static void AddUserVirtualCurrency(AddUserVirtualCurrencyRequest request, AddUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the specified user's current inventory of virtual goods
        /// </summary>
        public static void GetUserInventory(GetUserInventoryRequest request, GetUserInventoryCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetUserInventory", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Adds the specified items to the specified user inventories
        /// </summary>
        public static void GrantItemsToUsers(GrantItemsToUsersRequest request, GrantItemsToUsersCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GrantItemsToUsersResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GrantItemsToUsers", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Revokes access to an item in a user's inventory
        /// </summary>
        public static void RevokeInventoryItem(RevokeInventoryItemRequest request, RevokeInventoryItemCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RevokeInventoryResult result;
                ResultContainer<RevokeInventoryResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/RevokeInventoryItem", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Decrements the specified virtual currency by the stated amount
        /// </summary>
        public static void SubtractUserVirtualCurrency(SubtractUserVirtualCurrencyRequest request, SubtractUserVirtualCurrencyCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SubtractUserVirtualCurrency", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the details for a specific completed session, including links to standard out and standard error logs
        /// </summary>
        public static void GetMatchmakerGameInfo(GetMatchmakerGameInfoRequest request, GetMatchmakerGameInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetMatchmakerGameInfoResult result;
                ResultContainer<GetMatchmakerGameInfoResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetMatchmakerGameInfo", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the details of defined game modes for the specified game server executable
        /// </summary>
        public static void GetMatchmakerGameModes(GetMatchmakerGameModesRequest request, GetMatchmakerGameModesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetMatchmakerGameModesResult result;
                ResultContainer<GetMatchmakerGameModesResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetMatchmakerGameModes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the game server mode details for the specified game server executable
        /// </summary>
        public static void ModifyMatchmakerGameModes(ModifyMatchmakerGameModesRequest request, ModifyMatchmakerGameModesCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ModifyMatchmakerGameModesResult result;
                ResultContainer<ModifyMatchmakerGameModesResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ModifyMatchmakerGameModes", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Adds the game server executable specified (previously uploaded - see GetServerBuildUploadUrl) to the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void AddServerBuild(AddServerBuildRequest request, AddServerBuildCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                AddServerBuildResult result;
                ResultContainer<AddServerBuildResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/AddServerBuild", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the build details for the specified game server executable
        /// </summary>
        public static void GetServerBuildInfo(GetServerBuildInfoRequest request, GetServerBuildInfoCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            
            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetServerBuildInfoResult result;
                ResultContainer<GetServerBuildInfoResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetServerBuildInfo", serializedJson, null, null, callback);
        }

        /// <summary>
        /// Retrieves the pre-authorized URL for uploading a game server package containing a build (does not enable the build for use - see AddServerBuild)
        /// </summary>
        public static void GetServerBuildUploadUrl(GetServerBuildUploadURLRequest request, GetServerBuildUploadUrlCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetServerBuildUploadURLResult result;
                ResultContainer<GetServerBuildUploadURLResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetServerBuildUploadUrl", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the build details for all game server executables which are currently defined for the title
        /// </summary>
        public static void ListServerBuilds(ListBuildsRequest request, ListServerBuildsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ListBuildsResult result;
                ResultContainer<ListBuildsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ListServerBuilds", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the build details for the specified game server executable
        /// </summary>
        public static void ModifyServerBuild(ModifyServerBuildRequest request, ModifyServerBuildCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ModifyServerBuildResult result;
                ResultContainer<ModifyServerBuildResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ModifyServerBuild", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Removes the game server executable specified from the set of those a client is permitted to request in a call to StartGame
        /// </summary>
        public static void RemoveServerBuild(RemoveServerBuildRequest request, RemoveServerBuildCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                RemoveServerBuildResult result;
                ResultContainer<RemoveServerBuildResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/RemoveServerBuild", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        public static void GetPublisherData(GetPublisherDataRequest request, GetPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        public static void SetPublisherData(SetPublisherDataRequest request, SetPublisherDataCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                SetPublisherDataResult result;
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetPublisherData", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Gets the contents and information of a specific Cloud Script revision.
        /// </summary>
        public static void GetCloudScriptRevision(GetCloudScriptRevisionRequest request, GetCloudScriptRevisionCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCloudScriptRevisionResult result;
                ResultContainer<GetCloudScriptRevisionResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetCloudScriptRevision", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Lists all the current cloud script versions. For each version, information about the current published and latest revisions is also listed.
        /// </summary>
        public static void GetCloudScriptVersions(GetCloudScriptVersionsRequest request, GetCloudScriptVersionsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetCloudScriptVersionsResult result;
                ResultContainer<GetCloudScriptVersionsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetCloudScriptVersions", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Sets the currently published revision of a title Cloud Script
        /// </summary>
        public static void SetPublishedRevision(SetPublishedRevisionRequest request, SetPublishedRevisionCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                SetPublishedRevisionResult result;
                ResultContainer<SetPublishedRevisionResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/SetPublishedRevision", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Creates a new Cloud Script revision and uploads source code to it. Note that at this time, only one file should be submitted in the revision.
        /// </summary>
        public static void UpdateCloudScript(UpdateCloudScriptRequest request, UpdateCloudScriptCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                UpdateCloudScriptResult result;
                ResultContainer<UpdateCloudScriptResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/UpdateCloudScript", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Delete a content file from the title
        /// </summary>
        public static void DeleteContent(DeleteContentRequest request, DeleteContentCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                BlankResult result;
                ResultContainer<BlankResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/DeleteContent", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// List all contents of the title and get statistics such as size
        /// </summary>
        public static void GetContentList(GetContentListRequest request, GetContentListCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetContentListResult result;
                ResultContainer<GetContentListResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetContentList", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Retrieves the pre-signed URL for uploading a content file. A subsequent HTTP PUT to the returned URL uploads the content.
        /// </summary>
        public static void GetContentUploadUrl(GetContentUploadUrlRequest request, GetContentUploadUrlCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                GetContentUploadUrlResult result;
                ResultContainer<GetContentUploadUrlResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/GetContentUploadUrl", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }

        /// <summary>
        /// Completely removes all statistics for the specified character, for the current game
        /// </summary>
        public static void ResetCharacterStatistics(ResetCharacterStatisticsRequest request, ResetCharacterStatisticsCallback resultCallback, ErrorCallback errorCallback, object customData = null)
        {
            if (PlayFabSettings.DeveloperSecretKey == null) throw new Exception ("Must have PlayFabSettings.DeveloperSecretKey set to call this method");

            string serializedJson = JsonConvert.SerializeObject(request, Util.JsonFormatting, Util.JsonSettings);
            Action<string,PlayFabError> callback = delegate(string responseStr, PlayFabError pfError)
            {
                ResetCharacterStatisticsResult result;
                ResultContainer<ResetCharacterStatisticsResult>.HandleResults(responseStr, ref pfError, out result);
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
            PlayFabHTTP.Post(PlayFabSettings.GetURL()+"/Admin/ResetCharacterStatistics", serializedJson, "X-SecretKey", PlayFabSettings.DeveloperSecretKey, callback);
        }


    }
}
