#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.LocalizationModels
{
    [Serializable]
    public class GetLanguageListRequest : PlayFabRequestCommon
    {
    }

    [Serializable]
    public class GetLanguageListResponse : PlayFabResultCommon
    {
        /// <summary>
        /// The list of allowed languages, in BCP47 two-letter format
        /// </summary>
        public List<string> LanguageList;
    }
}
#endif
