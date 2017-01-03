#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using PlayFab;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.UUnit;
using System;
using System.Collections.Generic;
using System.IO;

public class PlayStreamTests : UUnitTestCase
{
    // Functional
    private static bool _titleInfoSet;

    /// <summary>
    /// PlayFab Title cannot be created from SDK tests, so you must provide your titleId to run unit tests.
    /// (Also, we don't want lots of excess unused titles)
    /// </summary>
    public static void SetTitleInfo(Dictionary<string, string> testInputs)
    {
        string eachValue;

        _titleInfoSet = true;
        // Parse all the inputs
        _titleInfoSet &= testInputs.TryGetValue("titleId", out eachValue);
        PlayFabSettings.TitleId = eachValue;
        _titleInfoSet &= testInputs.TryGetValue("developerSecretKey", out eachValue);
        PlayFabSettings.DeveloperSecretKey = eachValue;
        // Verify all the inputs won't cause crashes in the tests
        _titleInfoSet &= !string.IsNullOrEmpty(PlayFabSettings.TitleId)
            && !string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey);
    }

    public override void ClassSetUp()
    {
        if (_execOnce)
        {
            Dictionary<string, string> testInputs;
            var filename = "testTitleData.json"; // default to local file if PF_TEST_TITLE_DATA_JSON env-var does not exist

#if UNITY_STANDALONE_WIN
            // Prefer to load path from environment variable, if present
            var tempFilename = Environment.GetEnvironmentVariable("PF_TEST_TITLE_DATA_JSON");
            if (!string.IsNullOrEmpty(tempFilename))
                filename = tempFilename;
#endif

            if (File.Exists(filename))
            {
                var testInputsFile = PlayFabUtil.ReadAllFileText(filename);

                testInputs = JsonWrapper.DeserializeObject<Dictionary<string, string>>(testInputsFile, PlayFabUtil.ApiSerializerStrategy);
            }
            else
            {
                // NOTE FOR DEVELOPERS: POPULATE THIS SECTION WITH REAL INFORMATION (or set up a testTitleData file, and set your PF_TEST_TITLE_DATA_JSON to the path for that file)
                testInputs = new Dictionary<string, string>();
                //Debug.LogError("Loading testSettings file failed: " + filename + ", loading defaults.");
                //testInputs["titleId"] = "your title id here";
                //testInputs["userEmail"] = "yourTest@email.com";
            }
            SetTitleInfo(testInputs);
            _execOnce = false;
        }
    }

    public override void SetUp(UUnitTestContext testContext)
    {
        if (!_titleInfoSet)
            testContext.Skip(); // We cannot do client tests if the titleId is not given
    }

    [UUnitTest]
    public void PlayStreamServerConnectionTest(UUnitTestContext testContext)
    {
        PlayFabPlayStreamAPI.Start();
        PlayFabPlayStreamAPI.OnSubscribed += () =>
        {
            testContext.EndTest(UUnitFinishState.PASSED, null);
        };
        PlayFabPlayStreamAPI.OnFailed += error =>
        {
            testContext.EndTest(UUnitFinishState.FAILED, error.Message);
        };
        PlayFabPlayStreamAPI.OnError += error =>
        {
            testContext.EndTest(UUnitFinishState.FAILED, error.StackTrace);
        };
    }

    public override void Tick(UUnitTestContext testContext)
    {
        // No async work needed
    }
}
#endif
