using PlayFab.PfEditor.EditorModels;
using PlayFab.PfEditor.Json;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace PlayFab.PfEditor
{
    [InitializeOnLoad]
    public class PlayFabEditorDataService : UnityEditor.Editor
    {
        #region EditorPref data classes
        public class PlayFab_SharedSettingsProxy
        {
            private readonly Dictionary<string, PropertyInfo> _settingProps = new Dictionary<string, PropertyInfo>();
            private readonly string[] expectedProps = new[] { "titleid", "developersecretkey", "requesttype", "compressapidata", "requestkeepalive", "requesttimeout" };

            public string TitleId { get { return Get<string>("titleid"); } set { Set("titleid", value); } }
            public string DeveloperSecretKey { get { return Get<string>("developersecretkey"); } set { Set("developersecretkey", value); } }
            public PlayFabEditorSettings.WebRequestType WebRequestType { get { return Get<PlayFabEditorSettings.WebRequestType>("requesttype"); } set { Set("requesttype", (int)value); } }
            public bool CompressApiData { get { return Get<bool>("compressapidata"); } set { Set("compressapidata", value); } }
            public bool KeepAlive { get { return Get<bool>("requestkeepalive"); } set { Set("requestkeepalive", value); } }
            public int TimeOut { get { return Get<int>("requesttimeout"); } set { Set("requesttimeout", value); } }

            public PlayFab_SharedSettingsProxy()
            {
                LoadProps();
            }

            private PropertyInfo LoadProps(string name = null)
            {
                var playFabSettingsType = PlayFabEditorSDKTools.GetPlayFabSettings();
                if (playFabSettingsType == null)
                    return null;

                if (string.IsNullOrEmpty(name))
                {
                    for (var i = 0; i < expectedProps.Length; i++)
                        LoadProps(expectedProps[i]);
                    return null;
                }
                else
                {
                    var eachProperty = playFabSettingsType.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static);
                    if (eachProperty != null)
                        _settingProps[name.ToLowerInvariant()] = eachProperty;
                    return eachProperty;
                }
            }

            private T Get<T>(string name)
            {
                PropertyInfo propInfo;
                var success = _settingProps.TryGetValue(name.ToLowerInvariant(), out propInfo);
                T output = !success ? default(T) : (T)propInfo.GetValue(null, null);
                return output;
            }

            private void Set<T>(string name, T value)
            {
                PropertyInfo propInfo;
                if (!_settingProps.TryGetValue(name.ToLowerInvariant(), out propInfo))
                    propInfo = LoadProps(name);
                if (propInfo != null)
                    propInfo.SetValue(null, value, null);
                else
                    Debug.LogWarning("Could not save " + name + " because PlayFabSettings could not be found.");
            }
        }
        #endregion EditorPref data classes

        public static PlayFab_SharedSettingsProxy SharedSettings = new PlayFab_SharedSettingsProxy();

        private static string KeyPrefix
        {
            get
            {
                var dataPath = Application.dataPath;
                var lastIndex = dataPath.LastIndexOf('/');
                var secondToLastIndex = dataPath.LastIndexOf('/', lastIndex - 1);
                return dataPath.Substring(secondToLastIndex, lastIndex - secondToLastIndex);
            }
        }

        public static bool IsDataLoaded = false;

        public static Title ActiveTitle
        {
            get
            {
                if (PlayFabEditorPrefsSO.Instance.StudioList != null && PlayFabEditorPrefsSO.Instance.StudioList.Count > 0)
                {
                    if (string.IsNullOrEmpty(PlayFabEditorPrefsSO.Instance.SelectedStudio) || PlayFabEditorPrefsSO.Instance.SelectedStudio == PlayFabEditorHelper.STUDIO_OVERRIDE)
                        return new Title { Id = SharedSettings.TitleId, SecretKey = SharedSettings.DeveloperSecretKey, GameManagerUrl = PlayFabEditorHelper.GAMEMANAGER_URL };

                    if (string.IsNullOrEmpty(PlayFabEditorPrefsSO.Instance.SelectedStudio) || string.IsNullOrEmpty(SharedSettings.TitleId))
                        return null;

                    int studioIndex; int titleIndex;
                    if (DoesTitleExistInStudios(SharedSettings.TitleId, out studioIndex, out titleIndex))
                        return PlayFabEditorPrefsSO.Instance.StudioList[studioIndex].Titles[titleIndex];
                }
                return null;
            }
        }

        public static void SaveEnvDetails(bool updateToScriptableObj = true)
        {
            UpdateScriptableObject();
        }

        private static TResult LoadFromEditorPrefs<TResult>(string key) where TResult : class, new()
        {
            if (!EditorPrefs.HasKey(KeyPrefix + key))
                return new TResult();

            var serialized = EditorPrefs.GetString(KeyPrefix + key);
            var result = JsonWrapper.DeserializeObject<TResult>(serialized);
            if (result != null)
                return JsonWrapper.DeserializeObject<TResult>(serialized);
            return new TResult();
        }

        private static void UpdateScriptableObject()
        {
            var playfabSettingsType = PlayFabEditorSDKTools.GetPlayFabSettings();
            if (playfabSettingsType == null || !PlayFabEditorSDKTools.IsInstalled || !PlayFabEditorSDKTools.isSdkSupported)
                return;

            var props = playfabSettingsType.GetProperties();
            foreach (var property in props)
            {
                switch (property.Name.ToLowerInvariant())
                {
                    case "productionenvironmenturl":
                        property.SetValue(null, PlayFabEditorHelper.TITLE_ENDPOINT, null); break;
                }
            }

            var getSoMethod = playfabSettingsType.GetMethod("GetSharedSettingsObjectPrivate", BindingFlags.NonPublic | BindingFlags.Static);
            if (getSoMethod != null)
            {
                var so = getSoMethod.Invoke(null, new object[0]) as ScriptableObject;
                if (so != null)
                    EditorUtility.SetDirty(so);
            }
            PlayFabEditorPrefsSO.Save();
            AssetDatabase.SaveAssets();
        }

        public static bool DoesTitleExistInStudios(string searchFor) //out Studio studio
        {
            if (PlayFabEditorPrefsSO.Instance.StudioList == null)
                return false;
            searchFor = searchFor.ToLower();
            foreach (var studio in PlayFabEditorPrefsSO.Instance.StudioList)
                if (studio.Titles != null)
                    foreach (var title in studio.Titles)
                        if (title.Id.ToLower() == searchFor)
                            return true;
            return false;
        }

        private static bool DoesTitleExistInStudios(string searchFor, out int studioIndex, out int titleIndex) //out Studio studio
        {
            studioIndex = 0; // corresponds to our _OVERRIDE_
            titleIndex = -1;

            if (PlayFabEditorPrefsSO.Instance.StudioList == null)
                return false;

            for (var studioIdx = 0; studioIdx < PlayFabEditorPrefsSO.Instance.StudioList.Count; studioIdx++)
            {
                for (var titleIdx = 0; titleIdx < PlayFabEditorPrefsSO.Instance.StudioList[studioIdx].Titles.Length; titleIdx++)
                {
                    if (PlayFabEditorPrefsSO.Instance.StudioList[studioIdx].Titles[titleIdx].Id.ToLower() == searchFor.ToLower())
                    {
                        studioIndex = studioIdx;
                        titleIndex = titleIdx;
                        return true;
                    }
                }
            }

            return false;
        }

        public static void RefreshStudiosList(bool onlyIfNull = false)
        {
            if (string.IsNullOrEmpty(PlayFabEditorPrefsSO.Instance.DevAccountToken))
                return; // Can't load studios when not logged in
            if (onlyIfNull && PlayFabEditorPrefsSO.Instance.StudioList != null)
                return; // Don't spam load this, only load it the first time

            if (PlayFabEditorPrefsSO.Instance.StudioList != null)
                PlayFabEditorPrefsSO.Instance.StudioList.Clear();
            PlayFabEditorApi.GetStudios(new GetStudiosRequest(), (getStudioResult) =>
            {
                if (PlayFabEditorPrefsSO.Instance.StudioList == null)
                    PlayFabEditorPrefsSO.Instance.StudioList = new List<Studio>();
                foreach (var eachStudio in getStudioResult.Studios)
                    PlayFabEditorPrefsSO.Instance.StudioList.Add(eachStudio);
                PlayFabEditorPrefsSO.Instance.StudioList.Add(Studio.OVERRIDE);
                PlayFabEditorPrefsSO.Save();
            }, PlayFabEditorHelper.SharedErrorCallback);
        }
    }
}
