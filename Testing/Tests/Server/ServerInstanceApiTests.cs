#if ENABLE_PLAYFABSERVER_API
using PlayFab.ServerModels;
using PlayFab.Json;
using System;

namespace PlayFab.UUnit
{
    public class ServerInstanceApiTests : UUnitTestCase
    {
        private const string FakePlayFabId = "1337"; // A real playfabId here would be nice, but without a client login, it's hard to get one

        private static int SuccessfulLoginCount = 0, SuccessfulGetAllSegmentsCount = 0, UnsuccessfulGetAllSegmentsCount = 0, ParallelRequestSuccessfuCount = 0, ParallelRequestUnsuccessfuCount = 0;

        private static TestTitleDataLoader.TestTitleData testTitleData;

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

            PlayFabAuthenticationContext context = new PlayFabAuthenticationContext();
            context.DeveloperSecretKey = testTitleData.developerSecretKey;

            try
            {
                PlayFabServerInstanceAPI serverInstanceWithoutAnyParameter = new PlayFabServerInstanceAPI();
                PlayFabServerInstanceAPI serverInstanceWithSettings = new PlayFabServerInstanceAPI(settings);
                PlayFabServerInstanceAPI serverInstanceWithContext = new PlayFabServerInstanceAPI(context);
                PlayFabServerInstanceAPI serverInstanceWithSameParameter = new PlayFabServerInstanceAPI(context);
                PlayFabServerInstanceAPI serverInstanceWithSettingsAndContext = new PlayFabServerInstanceAPI(settings, context);
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }
            catch (Exception)
            {
                testContext.Fail("Multi Intance Server api can not be created");
            }
        }

        /// <summary>
        /// SERVER API
        /// Different instances of the same API class may have different API settings and use them
        /// </summary>
        [UUnitTest]
        public void MultipleInstanceWithDifferentSettings(UUnitTestContext testContext)
        {
            PlayFabApiSettings settings = new PlayFabApiSettings();
            settings.ProductionEnvironmentUrl = "https://test1.playfabapi.com";
            settings.TitleId = "test1";

            PlayFabApiSettings settings2 = new PlayFabApiSettings();
            settings2.ProductionEnvironmentUrl = "https://test2.playfabapi.com";
            settings2.TitleId = "test2";

            PlayFabAuthenticationContext context = new PlayFabAuthenticationContext();
            context.DeveloperSecretKey = "key1";

            PlayFabAuthenticationContext context2 = new PlayFabAuthenticationContext();
            context2.DeveloperSecretKey = "key2";

            try
            {
                PlayFabServerInstanceAPI serverInstance1 = new PlayFabServerInstanceAPI(settings, context);
                PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(settings2, context2);

                testContext.StringEquals("test1", serverInstance1.ApiSettings.TitleId, "MultipleInstanceWithDifferentSettings can not be completed");
                testContext.StringEquals("https://test1.playfabapi.com", serverInstance1.ApiSettings.ProductionEnvironmentUrl, "MultipleInstanceWithDifferentSettings can not be completed");
                testContext.StringEquals("key1", serverInstance1.GetAuthenticationContext().DeveloperSecretKey, "MultipleInstanceWithDifferentSettings can not be completed");

                testContext.StringEquals("test2", serverInstance2.ApiSettings.TitleId, "MultipleInstanceWithDifferentSettings can not be completed");
                testContext.StringEquals("https://test2.playfabapi.com", serverInstance2.ApiSettings.ProductionEnvironmentUrl, "MultipleInstanceWithDifferentSettings can not be completed");
                testContext.StringEquals("key2", serverInstance2.GetAuthenticationContext().DeveloperSecretKey, "MultipleInstanceWithDifferentSettings can not be completed");
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }
            catch (Exception)
            {
                testContext.Fail("Multi Intance Server api can not be created");
            }
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

            PlayFabAuthenticationContext context = new PlayFabAuthenticationContext();
            context.DeveloperSecretKey = testTitleData.developerSecretKey;

            var loginRequest1 = new LoginWithServerCustomIdRequest()
            {
                CreateAccount = true,
                ServerCustomId = "test_Instance1",
                AuthenticationContext = context
            };

            var loginRequest2 = new LoginWithServerCustomIdRequest()
            {
                CreateAccount = true,
                ServerCustomId = "test_Instance2",
                AuthenticationContext = context
            };

            try
            {
                PlayFabServerInstanceAPI serverInstance1 = new PlayFabServerInstanceAPI(settings, context);
                PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(settings, context);

                SuccessfulLoginCount = 0;
                serverInstance1.LoginWithServerCustomId(loginRequest1, PlayFabUUnitUtils.ApiActionWrapper<ServerLoginResult>(testContext, ApiInstanceLoginSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
                serverInstance2.LoginWithServerCustomId(loginRequest2, PlayFabUUnitUtils.ApiActionWrapper<ServerLoginResult>(testContext, ApiInstanceLoginSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            }
            catch (Exception)
            {
                testContext.Fail("Multi Intance Server api can not be created");
            }
        }
        private void ApiInstanceLoginSuccessCallBack(ServerLoginResult result)
        {
            SuccessfulLoginCount++;
            if (SuccessfulLoginCount == 2)
            {
                var testContext = (UUnitTestContext)result.CustomData;
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }
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

            PlayFabAuthenticationContext context = new PlayFabAuthenticationContext();
            context.DeveloperSecretKey = "WRONGKEYTOFAIL";

            //IT will  use context developer key - Should has error because of wrong key
            PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(context);
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
            
            PlayFabApiSettings settings = new PlayFabApiSettings();
            settings.TitleId = testTitleData.titleId;

            PlayFabAuthenticationContext context = new PlayFabAuthenticationContext();
            context.DeveloperSecretKey = testTitleData.developerSecretKey;

            PlayFabAuthenticationContext context2 = new PlayFabAuthenticationContext();
            context2.DeveloperSecretKey = "GETERROR";

            PlayFabAuthenticationContext context3 = new PlayFabAuthenticationContext();
            context3.DeveloperSecretKey = testTitleData.developerSecretKey;

            PlayFabAuthenticationContext context4 = new PlayFabAuthenticationContext();
            context4.DeveloperSecretKey = "TESTKEYERROR";

            PlayFabAuthenticationContext context5 = new PlayFabAuthenticationContext();
            context5.DeveloperSecretKey = "123421";

            PlayFabServerInstanceAPI serverInstance = new PlayFabServerInstanceAPI(settings, context);
            PlayFabServerInstanceAPI serverInstance1 = new PlayFabServerInstanceAPI(settings, context);
            PlayFabServerInstanceAPI serverInstance2 = new PlayFabServerInstanceAPI(settings, context2);
            PlayFabServerInstanceAPI serverInstance3 = new PlayFabServerInstanceAPI(settings, context3);
            PlayFabServerInstanceAPI serverInstance4 = new PlayFabServerInstanceAPI(settings, context4);
            PlayFabServerInstanceAPI serverInstance5 = new PlayFabServerInstanceAPI(settings, context5);

            serverInstance.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
            serverInstance1.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
            serverInstance2.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
            serverInstance3.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
            serverInstance4.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
            serverInstance5.GetAllSegments(new GetAllSegmentsRequest(), PlayFabUUnitUtils.ApiActionWrapper<GetAllSegmentsResult>(testContext, ParallelRequestSuccessCallBack), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ParallelRequestExpectedErrorCallBack), testContext);
        }

        private void ParallelRequestSuccessCallBack(GetAllSegmentsResult result)
        {
            ParallelRequestSuccessfuCount++;
            var testContext = (UUnitTestContext)result.CustomData;
            if (ParallelRequestSuccessfuCount == 3 && ParallelRequestUnsuccessfuCount == 3)
            {
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

        }
        private void ParallelRequestExpectedErrorCallBack(PlayFabError error)
        {
            ParallelRequestUnsuccessfuCount++;
            var testContext = (UUnitTestContext)error.CustomData;
            if (ParallelRequestSuccessfuCount == 3 && ParallelRequestUnsuccessfuCount == 3)
            {
                testContext.EndTest(UUnitFinishState.PASSED, null);
            }

        }
    }
}
#endif
