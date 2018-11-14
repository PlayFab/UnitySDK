#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.CloudScriptModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// API methods for executing CloudScript using an Entity Profile
    /// </summary>
    public static class PlayFabCloudScriptAPI
    {
        static PlayFabCloudScriptAPI() {}


        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabHttp.ForgetAllCredentials();
        }

        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution of any kind of
        /// custom server-side functionality you can implement, and it can be used in conjunction with virtually anything.
        /// </summary>
        public static void ExecuteEntityCloudScript(ExecuteEntityCloudScriptRequest request, Action<ExecuteCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/CloudScript/ExecuteEntityCloudScript", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }


    }
}
#endif
