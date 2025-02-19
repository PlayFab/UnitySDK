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
            private readonly string[] expectedProps = new[] { "titleid", "requesttype", "requestkeepalive", "requesttimeout" };

            public string TitleId { get { return Get<string>("titleid"); } set { Set("titleid", value); } }
            public PlayFabEditorSettings.WebRequestType WebRequestType { get { return Get<PlayFabEditorSettings.WebRequestType>("requesttype"); } set { Set("requesttype", (int)value); } }
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

        public static bool IsDataLoaded = false;

        public static void SaveEnvDetails(bool updateToScriptableObj = true)
        {
            UpdateScriptableObject();
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
    }
}
