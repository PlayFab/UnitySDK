#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.DataModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// Store arbitrary data associated with an entity. Objects are small (~1KB) JSON-compatible objects which are stored
    /// directly on the entity profile. Objects are made available for use in other PlayFab contexts, such as PlayStream events
    /// and CloudScript functions. Files can efficiently store data of any size or format. Both objects and files support a
    /// flexible permissions system to control read and write access by other entities.
    /// </summary>
    public static class PlayFabDataAPI
    {
        static PlayFabDataAPI() {}


        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabHttp.ForgetAllCredentials();
        }

        /// <summary>
        /// Abort pending file uploads to an entity's profile.
        /// </summary>
        public static void AbortFileUploads(AbortFileUploadsRequest request, Action<AbortFileUploadsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/AbortFileUploads", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Delete files on an entity's profile.
        /// </summary>
        public static void DeleteFiles(DeleteFilesRequest request, Action<DeleteFilesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/DeleteFiles", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Finalize file uploads to an entity's profile.
        /// </summary>
        public static void FinalizeFileUploads(FinalizeFileUploadsRequest request, Action<FinalizeFileUploadsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/FinalizeFileUploads", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves file metadata from an entity's profile.
        /// </summary>
        public static void GetFiles(GetFilesRequest request, Action<GetFilesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/GetFiles", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves objects from an entity's profile.
        /// </summary>
        public static void GetObjects(GetObjectsRequest request, Action<GetObjectsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Object/GetObjects", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Initiates file uploads to an entity's profile.
        /// </summary>
        public static void InitiateFileUploads(InitiateFileUploadsRequest request, Action<InitiateFileUploadsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/File/InitiateFileUploads", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Sets objects on an entity's profile.
        /// </summary>
        public static void SetObjects(SetObjectsRequest request, Action<SetObjectsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Object/SetObjects", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }


    }
}
#endif
