using System;
using System.IO;
using PlayFab.Internal;
using PlayFab.Json;

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
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
            public string developerSecretKey;
#endif
        }

        public static TestTitleData LoadTestTitleData(bool setPlayFabSettings = true)
        {
            if (_loadedData != null)
                return _loadedData;

            var filename = TestTitleDataDefaultFilename;

#if UNITY_STANDALONE_WIN
            // Prefer to load path from environment variable, if present
            var tempFilename = Environment.GetEnvironmentVariable("PF_TEST_TITLE_DATA_JSON");
            if (!string.IsNullOrEmpty(tempFilename))
                filename = tempFilename;
#endif

            if (File.Exists(filename))
            {
                var testInputsFile = PlayFabUtil.ReadAllFileText(filename);

                _loadedData = JsonWrapper.DeserializeObject<TestTitleData>(testInputsFile);
            }
            else
            {
                // NOTE FOR DEVELOPERS: POPULATE THIS SECTION WITH REAL INFORMATION (or set up a testTitleData file, and set your PF_TEST_TITLE_DATA_JSON to the path for that file)
                _loadedData = new TestTitleData
                {
                    titleId = "your title id here",
                    userEmail = "yourTest@email.com"
                };
            }

            if (setPlayFabSettings)
            {
                PlayFabSettings.TitleId = _loadedData.titleId;
#if ENABLE_PLAYFABSERVER_API || ENABLE_PLAYFABADMIN_API
                PlayFabSettings.DeveloperSecretKey = _loadedData.developerSecretKey;
#endif
            }

            return _loadedData;
        }
    }
}
