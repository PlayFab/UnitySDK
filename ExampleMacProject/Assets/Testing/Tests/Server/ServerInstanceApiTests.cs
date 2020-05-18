#if ENABLE_PLAYFABSERVER_API

using PlayFab.ServerModels;

namespace PlayFab.UUnit
{
    public class ServerInstanceApiTests : UUnitTestCase
    {
        private const string FakePlayFabId = "1337"; // A real playfabId here would be nice, but without a client login, it's hard to get one

        private static TestTitleDataLoader.TestTitleData testTitleData;

        private int SuccessfulGetAllSegmentsCount = 0, UnsuccessfulGetAllSegmentsCount = 0, ParallelRequestSuccessfuCount = 0, ParallelRequestUnsuccessfuCount = 0;
        private string InstancePlayFabId1, InstancePlayFabId2;

        private const string test1Url = "https://test1." + PlayFabSettings.DefaultPlayFabApiUrl;
        private const string test2Url = "https://test2." + PlayFabSettings.DefaultPlayFabApiUrl;

        public override void SetUp(UUnitTestContext testContext)
        {
            testTitleData = TestTitleDataLoader.LoadTestTitleData();
            PlayFabSettings.TitleId = testTitleData.titleId;
            PlayFabSettings.DeveloperSecretKey = testTitleData.developerSecretKey;
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

        /// <summary>
        /// SERVER API
        /// Multiple instances of the same API class can be created
        /// </summary>
        [UUnitTest]
        public void CreateMultipleServerInstance(UUnitTestContext testContext)
        {
            PlayFabApiSettings settings = new PlayFabApiSettings();
            settings.TitleId = testTitleData.titleId;
            settings.DeveloperSecretKey = testTitleData.developerSecretKey;

            var instance1 = new PlayFabServerInstanceAPI();
            var instance2 = new PlayFabServerInstanceAPI(settings);

            instance1.ForgetAllCredentials();
            instance2.ForgetAllCredentials();

            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// SERVER API
        /// Different instances of the same API class may have different API settings and use them
        /// </summary>
        [UUnitTest]
        public void MultipleInstanceWithDifferentSettings(UUnitTestContext testContext)
        {
            PlayFabApiSettings settings1 = new PlayFabApiSettings();
            settings1.ProductionEnvironmentUrl = test1Url;
            settings1.TitleId = "test1";
            settings1.DeveloperSecretKey = "key1";

            PlayFabApiSettings settings2 = new PlayFabApiSettings();
            settings2.ProductionEnvironmentUrl = test2Url;
            settings2.TitleId = "test2";
            settings2.DeveloperSecretKey = "key2";

            PlayFabServerInstanceAPI serverInstance1 = new PlayFabServerInstanceAPI(settings1);
            testContext.StringEquals("test1", serverInstance1.apiSettings.TitleId, "MultipleInstanceWithDifferentSettings can not be completed");
            testContext.StringEquals(test1Url, serverInstance1.apiSettings.ProductionEnvironmentUrl, "MultipleInstanceWithDifferentSettings can not be completed");
            testContext.StringEquals("key1", serverInstance1.apiSettings.DeveloperSecretKey, "MultipleInstanceWithDifferentSettings can not be completed");

            PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(settings2);
            testContext.StringEquals("test2", serverInstance2.apiSettings.TitleId, "MultipleInstanceWithDifferentSettings can not be completed");
            testContext.StringEquals(test2Url, serverInstance2.apiSettings.ProductionEnvironmentUrl, "MultipleInstanceWithDifferentSettings can not be completed");
            testContext.StringEquals("key2", serverInstance2.apiSettings.DeveloperSecretKey, "MultipleInstanceWithDifferentSettings can not be completed");

            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// SERVER API
        /// Each API instance can be used to login a player separately from any other API instances,
        /// and that player's authentication context is stored in the API instance
        /// </summary>
        [UUnitTest]
        public void ApiInstanceLogin(UUnitTestContext testContext)
        {
            PlayFabApiSettings settings = new PlayFabApiSettings();
            settings.TitleId = testTitleData.titleId;
            settings.DeveloperSecretKey = testTitleData.developerSecretKey;

            var loginRequest1 = new LoginWithServerCustomIdRequest()
            {
                CreateAccount = true,
                ServerCustomId = "test_Instance1"
            };

            var loginRequest2 = new LoginWithServerCustomIdRequest()
            {
                CreateAccount = true,
                ServerCustomId = "test_Instance2"
            };

            PlayFabServerInstanceAPI serverInstance1 = new PlayFabServerInstanceAPI(settings);
            PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(settings);

            serverInstance1.LoginWithServerCustomId(loginRequest1, PlayFabUUnitUtils.ApiActionWrapper<ServerLoginResult>(testContext, OnInstanceLogin1), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            serverInstance2.LoginWithServerCustomId(loginRequest2, PlayFabUUnitUtils.ApiActionWrapper<ServerLoginResult>(testContext, OnInstanceLogin2), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void OnInstanceLogin1(ServerLoginResult result)
        {
            InstancePlayFabId1 = result.PlayFabId;
            var testContext = (UUnitTestContext)result.CustomData;
            ProcessBothLogins(testContext);
        }
        private void OnInstanceLogin2(ServerLoginResult result)
        {
            InstancePlayFabId2 = result.PlayFabId;
            var testContext = (UUnitTestContext)result.CustomData;
            ProcessBothLogins(testContext);
        }

        private void ProcessBothLogins(UUnitTestContext testContext)
        {
            testContext.False(InstancePlayFabId1 == InstancePlayFabId2);
            if (!string.IsNullOrEmpty(InstancePlayFabId1) && !string.IsNullOrEmpty(InstancePlayFabId2))
                testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// SERVER API
        /// If API settings object is not set by a customer developer for an instance of an API class then the
        /// API instance always uses the static PlayFabSettings class (the same way as static API classes)
        /// </summary>
        [UUnitTest]
        public void CheckWithNoSettings(UUnitTestContext testContext)
        {
            //It should work with static class only
            PlayFabServerInstanceAPI serverInstanceWithoutAnyParameter = new PlayFabServerInstanceAPI();
            serverInstanceWithoutAnyParameter.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, CheckWithNoSettingsSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void CheckWithNoSettingsSuccessCallBack(GetAllSegmentsResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
        /// <summary>
        /// SERVER API
        /// Try to check server instance with authentication context and without authentication context
        /// </summary>
        [UUnitTest]
        public void CheckWithAuthContextAndWithoutAuthContext(UUnitTestContext testContext)
        {
            //IT will  use static developer key - Should has no error
            PlayFabServerInstanceAPI serverInstance1 = new PlayFabServerInstanceAPI();
            serverInstance1.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, CheckWithAuthContextAndWithoutAuthContextSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);

            var apiSettings = new PlayFabApiSettings();
            apiSettings.DeveloperSecretKey = "WRONGKEYTOFAIL";

            //IT will  use context developer key - Should has error because of wrong key
            PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(apiSettings);
            serverInstance2.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, CheckWithAuthContextAndWithoutAuthContextSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, CheckWithAuthContextAndWithoutAuthContextExpectedErrorCallBack), testContext);
        }
        private void CheckWithAuthContextAndWithoutAuthContextSuccessCallBack(GetAllSegmentsResult result)
        {
            SuccessfulGetAllSegmentsCount++;
            var testContext = (UUnitTestContext)result.CustomData;
            if (SuccessfulGetAllSegmentsCount == 1 && UnsuccessfulGetAllSegmentsCount == 1)
            {
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

        }
        private void CheckWithAuthContextAndWithoutAuthContextExpectedErrorCallBack(PlayFabError error)
        {
            UnsuccessfulGetAllSegmentsCount++;
            var testContext = (UUnitTestContext)error.CustomData;
            if (SuccessfulGetAllSegmentsCount == 1 && UnsuccessfulGetAllSegmentsCount == 1)
            {
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

        }

        /// <summary>
        /// SERVER API
        /// Try to parallel request at same time
        /// </summary>
        [UUnitTest]
        public void ParallelRequest(UUnitTestContext testContext)
        {
            var settings1 = new PlayFabApiSettings();
            settings1.TitleId = testTitleData.titleId;
            settings1.DeveloperSecretKey = testTitleData.developerSecretKey;

            var settings2 = new PlayFabApiSettings();
            settings2.TitleId = testTitleData.titleId;
            settings2.DeveloperSecretKey = "TESTKEYERROR";

            PlayFabServerInstanceAPI serverInstance1 = new PlayFabServerInstanceAPI(settings1);
            PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(settings2);

            serverInstance1.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
            serverInstance2.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
        }

        private void ParallelRequestSuccessCallBack(GetAllSegmentsResult result)
        {
            ParallelRequestSuccessfuCount++;
            var testContext = (UUnitTestContext)result.CustomData;
            if (ParallelRequestSuccessfuCount == 1 && ParallelRequestUnsuccessfuCount == 1)
            {
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

        }
        private void ParallelRequestExpectedErrorCallBack(PlayFabError error)
        {
            ParallelRequestUnsuccessfuCount++;
            var testContext = (UUnitTestContext)error.CustomData;
            if (ParallelRequestSuccessfuCount == 1 && ParallelRequestUnsuccessfuCount == 1)
            {
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }
        }
    }
}

#endif
