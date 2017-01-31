#if ENABLE_PLAYFABSERVER_API
using PlayFab.ServerModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlayFab.UUnit
{
    public class ServerApiTests : UUnitTestCase
    {
        private static bool _titleInfoSet = false;
        private static bool _execOnce = true;
        private const string FakePlayFabId = "1337"; // A real playfabId here would be nice, but without a client login, it's hard to get one

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

        public override void SetUp(UUnitTestContext testContext)
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

                    testInputs = JsonWrapper.DeserializeObject<Dictionary<string, string>>(testInputsFile);
                }
                else
                {
                    // NOTE FOR DEVELOPERS: POPULATE THIS SECTION WITH REAL INFORMATION (or set up a testTitleData file, and set your PF_TEST_TITLE_DATA_JSON to the path for that file)
                    testInputs = new Dictionary<string, string>();
                    //Debug.LogError("Loading testSettings file failed: " + filename + ", loading defaults.");
                    //testInputs["titleId"] = "your title id here";
                    //testInputs["developerSecretKey"] = "your secret key here"; // BE VERY CAREFUL NOT TO PUBLISH THIS, or build it into a client
                }
                SetTitleInfo(testInputs);
                _execOnce = false;
            }

            if (!_titleInfoSet)
                testContext.Skip(); // We cannot do client tests if the titleId is not given
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // No async work needed
        }

        public override void TearDown(UUnitTestContext testContext)
        {
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }
        
        /// <summary>
        /// SERVER API
        /// Test that CloudScript can be properly set up and invoked
        /// </summary>
        [UUnitTest]
        public void ServerCloudScript(UUnitTestContext testContext)
        {
            var request = new ExecuteCloudScriptServerRequest
            {
                FunctionName = "helloWorld",
                PlayFabId = FakePlayFabId
            };
            PlayFabServerAPI.ExecuteCloudScript(request, PlayFabUUnitUtils.ApiActionWrapper<ExecuteCloudScriptResult>(testContext, CloudScriptHwCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void CloudScriptHwCallback(ExecuteCloudScriptResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.NotNull(result.FunctionResult);
            var jobj = (JsonObject)result.FunctionResult;
            var messageValue = jobj["messageValue"] as string;
            testContext.StringEquals("Hello " + FakePlayFabId + "!", messageValue);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test that CloudScript can be properly set up and invoked
        /// </summary>
        [UUnitTest]
        public void ServerCloudScriptGeneric(UUnitTestContext testContext)
        {
            var request = new ExecuteCloudScriptServerRequest
            {
                FunctionName = "helloWorld",
                PlayFabId = FakePlayFabId
            };
            PlayFabServerAPI.ExecuteCloudScript<HelloWorldWrapper>(request, PlayFabUUnitUtils.ApiActionWrapper<ExecuteCloudScriptResult>(testContext, CloudScriptGenericHwCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void CloudScriptGenericHwCallback(ExecuteCloudScriptResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var hwResult = result.FunctionResult as HelloWorldWrapper;
            testContext.NotNull(hwResult);
            testContext.StringEquals("Hello " + FakePlayFabId + "!", hwResult.messageValue);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
        private class HelloWorldWrapper
        {
            public string messageValue = null;
        }
    }
}
#endif
