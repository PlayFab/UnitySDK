#if !DISABLE_PLAYFABENTITY_API

using System;
using System.Collections.Generic;
using PlayFab.CloudScriptModels;
using PlayFab.Internal;
using PlayFab.SharedModels;

namespace PlayFab
{
    /// <summary>
    /// API methods for executing CloudScript using an Entity Profile
    /// </summary>
    public class PlayFabCloudScriptInstanceAPI : IPlayFabInstanceApi
    {
        public PlayFabApiSettings apiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabCloudScriptInstanceAPI() { }

        public PlayFabCloudScriptInstanceAPI(PlayFabApiSettings settings)
        {
            apiSettings = settings;
        }

        public PlayFabCloudScriptInstanceAPI(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabCloudScriptInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            apiSettings = settings;
            authenticationContext = context;
        }

        public void SetAuthenticationContext(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationContext GetAuthenticationContext()
        {
            return authenticationContext;
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public void ForgetAllCredentials()
        {
            if (authenticationContext != null)
            {
                authenticationContext.ForgetAllCredentials();
            }
        }

        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution of any kind of
        /// custom server-side functionality you can implement, and it can be used in conjunction with virtually anything.
        /// </summary>
        public void ExecuteEntityCloudScript(ExecuteEntityCloudScriptRequest request, Action<ExecuteCloudScriptResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var context = (request == null ? null : request.AuthenticationContext) ?? authenticationContext;
            PlayFabHttp.MakeApiCall("/CloudScript/ExecuteEntityCloudScript", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, context, apiSettings, this);
        }

    }
}

#endif
