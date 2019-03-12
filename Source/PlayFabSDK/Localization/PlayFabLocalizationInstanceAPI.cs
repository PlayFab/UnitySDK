#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.LocalizationModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// The Localization APIs give you the tools needed to manage language setup in your title.
    /// </summary>
    public class PlayFabLocalizationInstanceAPI
    {
        public PlayFabApiSettings ApiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabLocalizationInstanceAPI() {}

        public PlayFabLocalizationInstanceAPI(PlayFabApiSettings settings) 
        {
            ApiSettings = settings;
        }

        public PlayFabLocalizationInstanceAPI(PlayFabAuthenticationContext context) 
        {
            authenticationContext = context;
        }

        public PlayFabLocalizationInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context) 
        {
            ApiSettings = settings;
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
            if(authenticationContext != null)
            {
                authenticationContext.ForgetAllCredentials();
            }
        }

        /// <summary>
        /// Retrieves the list of allowed languages, only accessible by title entities
        /// </summary>

        public void GetLanguageList(GetLanguageListRequest request, Action<GetLanguageListResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Locale/GetLanguageList", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 

    }
}
#endif
