#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.ProfilesModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// All PlayFab entities have profiles, which hold top-level properties about the entity. These APIs give you the tools
    /// needed to manage entity profiles.
    /// </summary>
    public static class PlayFabProfilesAPI
    {
        static PlayFabProfilesAPI() {}


        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabHttp.ForgetAllCredentials();
        }

        /// <summary>
        /// Gets the global title access policy
        /// </summary>
        public static void GetGlobalPolicy(GetGlobalPolicyRequest request, Action<GetGlobalPolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/GetGlobalPolicy", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        public static void GetProfile(GetEntityProfileRequest request, Action<GetEntityProfileResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/GetProfile", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Retrieves the entity's profile.
        /// </summary>
        public static void GetProfiles(GetEntityProfilesRequest request, Action<GetEntityProfilesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/GetProfiles", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Sets the global title access policy
        /// </summary>
        public static void SetGlobalPolicy(SetGlobalPolicyRequest request, Action<SetGlobalPolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/SetGlobalPolicy", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Updates the entity's language. The precedence hierarchy for communication to the player is Title Player Account
        /// language, Master Player Account language, and then title default language if the first two aren't set or supported.
        /// </summary>
        public static void SetProfileLanguage(SetProfileLanguageRequest request, Action<SetProfileLanguageResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/SetProfileLanguage", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Sets the profiles access policy
        /// </summary>
        public static void SetProfilePolicy(SetEntityProfilePolicyRequest request, Action<SetEntityProfilePolicyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {

            PlayFabHttp.MakeApiCall("/Profile/SetProfilePolicy", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }


    }
}
#endif
