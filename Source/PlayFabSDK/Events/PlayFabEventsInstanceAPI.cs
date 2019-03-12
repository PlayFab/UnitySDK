#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.EventsModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// Write custom PlayStream events for any PlayFab entity. PlayStream events can be used for analytics, reporting,
    /// debugging, or to trigger custom actions in near real-time.
    /// </summary>
    public class PlayFabEventsInstanceAPI
    {
        public PlayFabApiSettings ApiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabEventsInstanceAPI() {}

        public PlayFabEventsInstanceAPI(PlayFabApiSettings settings) 
        {
            ApiSettings = settings;
        }

        public PlayFabEventsInstanceAPI(PlayFabAuthenticationContext context) 
        {
            authenticationContext = context;
        }

        public PlayFabEventsInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context) 
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
        /// Write batches of entity based events to PlayStream.
        /// </summary>

        public void WriteEvents(WriteEventsRequest request, Action<WriteEventsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Event/WriteEvents", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 

    }
}
#endif
