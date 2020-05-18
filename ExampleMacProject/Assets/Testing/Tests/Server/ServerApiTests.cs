#if ENABLE_PLAYFABSERVER_API
using PlayFab.ServerModels;
using PlayFab.Json;

namespace PlayFab.UUnit
{
    public class ServerApiTests : UUnitTestCase
    {
        private string testPlayFabId;
        private TestTitleDataLoader.TestTitleData testTitleData;

        public override void SetUp(UUnitTestContext testContext)
        {
            testTitleData = TestTitleDataLoader.LoadTestTitleData();
            PlayFabSettings.staticSettings.TitleId = testTitleData.titleId;
            PlayFabSettings.staticSettings.DeveloperSecretKey = testTitleData.developerSecretKey;

            // Verify all the inputs won't cause crashes in the tests
            var titleInfoSet = !string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId) && !string.IsNullOrEmpty(PlayFabSettings.staticSettings.DeveloperSecretKey);
            if (!titleInfoSet)
                testContext.Skip(); // We cannot do client tests if the titleId is not given
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // No async work needed
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        [UUnitTest]
        public void ServerCustomIdLogin(UUnitTestContext testContext)
        {
            var request = new LoginWithServerCustomIdRequest
            {
                CreateAccount = true,
                ServerCustomId = PlayFabSettings.BuildIdentifier
            };
            PlayFabServerAPI.LoginWithServerCustomId(request, PlayFabUUnitUtils.ApiActionWrapper<ServerLoginResult>(testContext, OnLogin), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void OnLogin(ServerLoginResult result)
        {
            testPlayFabId = result.PlayFabId;
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.EndTest(UUnitFinishState.PASSED, testPlayFabId);
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
                PlayFabId = testPlayFabId
            };
            PlayFabServerAPI.ExecuteCloudScript(request, PlayFabUUnitUtils.ApiActionWrapper<ExecuteCloudScriptResult>(testContext, CloudScriptHwCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void CloudScriptHwCallback(ExecuteCloudScriptResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.NotNull(result.FunctionResult);
            var jobj = (JsonObject)result.FunctionResult;
            var messageValue = jobj["messageValue"] as string;
            testContext.StringEquals("Hello " + testPlayFabId + "!", messageValue);
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
                PlayFabId = testPlayFabId
            };
            PlayFabServerAPI.ExecuteCloudScript<HelloWorldWrapper>(request, PlayFabUUnitUtils.ApiActionWrapper<ExecuteCloudScriptResult>(testContext, CloudScriptGenericHwCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void CloudScriptGenericHwCallback(ExecuteCloudScriptResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var hwResult = result.FunctionResult as HelloWorldWrapper;
            testContext.NotNull(hwResult);
            testContext.StringEquals("Hello " + testPlayFabId + "!", hwResult.messageValue);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
        private class HelloWorldWrapper
        {
            public string messageValue = null;
        }
    }
}
#endif
