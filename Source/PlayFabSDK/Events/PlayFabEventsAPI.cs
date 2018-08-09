#if ENABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.EventsModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// Entity profiles are the top level containers for essentially all information about an entity.
    /// </summary>
    public static class PlayFabEventsAPI
    {
        static PlayFabEventsAPI() {}

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabHttp.ForgetAllCredentials();
        }

        /// <summary>
        /// Write batches of entity based events to PlayStream.
        /// </summary>
        public static void WriteEvents(WriteEventsRequest request, Action<WriteEventsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Event/WriteEvents", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }


    }
}
#endif
