using System;
using System.Collections.Generic;
using System.IO;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab.UUnit
{
    public static class TestTitleDataLoader
    {
        private static TestTitleData _loadedData = null;
        public const string TestTitleDataDefaultFilename = "testTitleData.json"; // default to local file if PF_TEST_TITLE_DATA_JSON env-var does not exist;

        /// <summary>
        /// PlayFab Title cannot be created from SDK tests, so you must provide your titleId, and some other information to run unit tests.
        /// (Also, we don't want lots of excess unused titles)
        /// </summary>
        public class TestTitleData
        {
            // More details available here: https://github.com/PlayFab/SDKGenerator/blob/master/JenkinsConsoleUtility/testTitleData.md
            public string titleId;
            public string userEmail;
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
            public string developerSecretKey;
#endif
            public Dictionary<string, string> extraHeaders;
        }

        static TestTitleData LoadTitleDataWithPlugin(string titleDataJSON)
        {
            try
            {
                return PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<TestTitleData>(titleDataJSON);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static TestTitleData LoadTestTitleData(string testTitleDataContents = null, bool setPlayFabSettings = true)
        {
            SetTitleId(setPlayFabSettings);

            if (_loadedData != null)
                return _loadedData;

            if (!string.IsNullOrEmpty(testTitleDataContents))
            {
                _loadedData = LoadTitleDataWithPlugin(testTitleDataContents);
            }

            if(_loadedData == null)
            {
                var textAsset = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension(TestTitleDataDefaultFilename)); 
                if(textAsset != null)
                {
                    _loadedData = LoadTitleDataWithPlugin(textAsset.text);
                }
            }

            if (_loadedData == null)
            {
                var filename = TestTitleDataDefaultFilename;

#if UNITY_STANDALONE_WIN
                // Prefer to load path from environment variable, if present
                var tempFilename = Environment.GetEnvironmentVariable("PF_TEST_TITLE_DATA_JSON");
                if (!string.IsNullOrEmpty(tempFilename))
                    filename = tempFilename;
#endif
                if (File.Exists(filename))
                {
                    testTitleDataContents = PlayFabUtil.ReadAllFileText(filename);
                }

                _loadedData = LoadTitleDataWithPlugin(testTitleDataContents);
            }

            if(_loadedData == null)
            {
                // NOTE FOR DEVELOPERS: POPULATE THIS SECTION WITH REAL INFORMATION (or set up a testTitleData file, and set your PF_TEST_TITLE_DATA_JSON to the path for that file)
                _loadedData = new TestTitleData
                {
                    titleId = "your title id here",
                    userEmail = "yourTest@email.com"
                };
            }

            SetTitleId(setPlayFabSettings);
            return _loadedData;
        }

        private static void SetTitleId(bool setPlayFabSettings)
        {
            if (!setPlayFabSettings || _loadedData == null)
                return;

            PlayFabSettings.TitleId = _loadedData.titleId;
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API || UNITY_EDITOR
            PlayFabSettings.DeveloperSecretKey = _loadedData.developerSecretKey;
#endif
        }
    }
}
