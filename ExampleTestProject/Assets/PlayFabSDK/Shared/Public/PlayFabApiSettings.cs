using System.Collections.Generic;
using System;

namespace PlayFab
{
    public class PlayFabApiSettings
    {
        private string _ProductionEnvironmentUrl = PlayFabSettings.DefaultPlayFabApiUrl;
        public readonly Dictionary<string, string> _requestGetParams = new Dictionary<string, string> {
            { "sdk", PlayFabSettings.VersionString }
        };

        public virtual Dictionary<string, string> RequestGetParams { get { return _requestGetParams; } }

        /// <summary> This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        public virtual string ProductionEnvironmentUrl { get { return _ProductionEnvironmentUrl; } set { _ProductionEnvironmentUrl = value; } }
        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public virtual string TitleId { get; set; }
        /// <summary> The name of a customer vertical. This is only for customers running a private cluster.  Generally you shouldn't touch this </summary>
        internal virtual string VerticalName { get; set; }
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
        /// <summary> You must set this value for PlayFabSdk to work properly (Found in the Game Manager for your title, at the PlayFab Website) </summary>
        public virtual string DeveloperSecretKey { get; set; }
#endif
        /// <summary> Set this to true to prevent hardware information from leaving the device </summary>
        public virtual bool DisableDeviceInfo { get; set; }
        /// <summary> Set this to true to prevent focus change information from leaving the device </summary>
        public virtual bool DisableFocusTimeCollection { get; set; }

        public virtual string GetFullUrl(string apiCall, Dictionary<string, string> getParams)
        {
            return PlayFabSettings.GetFullUrl(apiCall, getParams, this);
        }
    }

    /// <summary>
    /// This is only meant for PlayFabSettings to use as a redirect to store values on PlayFabSharedSettings instead of locally
    /// </summary>
    internal class PlayFabSettingsRedirect : PlayFabApiSettings
    {
        private readonly Func<PlayFabSharedSettings> GetSO;
        public PlayFabSettingsRedirect(Func<PlayFabSharedSettings> getSO) { GetSO = getSO; }

        public override string ProductionEnvironmentUrl
        {
            get { var so = GetSO(); return so == null ? base.ProductionEnvironmentUrl : so.ProductionEnvironmentUrl; }
            set { var so = GetSO(); if (so != null) so.ProductionEnvironmentUrl = value; base.ProductionEnvironmentUrl = value; }
        }

        internal override string VerticalName
        {
            get { var so = GetSO(); return so == null ? base.VerticalName : so.VerticalName; }
            set { var so = GetSO(); if (so != null) so.VerticalName = value; base.VerticalName = value; }
        }

#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
        public override string DeveloperSecretKey
        {
            get { var so = GetSO(); return so == null ? base.DeveloperSecretKey : so.DeveloperSecretKey; }
            set { var so = GetSO(); if (so != null) so.DeveloperSecretKey = value; base.DeveloperSecretKey = value; }
        }
#endif

        public override string TitleId
        {
            get { var so = GetSO(); return so == null ? base.TitleId : so.TitleId; }
            set { var so = GetSO(); if (so != null) so.TitleId = value; base.TitleId = value; }
        }

        public override bool DisableDeviceInfo
        {
            get { var so = GetSO(); return so == null ? base.DisableDeviceInfo : so.DisableDeviceInfo; }
            set { var so = GetSO(); if (so != null) so.DisableDeviceInfo = value; base.DisableDeviceInfo = value; }
        }

        public override bool DisableFocusTimeCollection
        {
            get { var so = GetSO(); return so == null ? base.DisableFocusTimeCollection : so.DisableFocusTimeCollection; }
            set { var so = GetSO(); if (so != null) so.DisableFocusTimeCollection = value; base.DisableFocusTimeCollection = value; }
        }
    }
}
