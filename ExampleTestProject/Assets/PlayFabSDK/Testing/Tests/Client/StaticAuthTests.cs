#if !DISABLE_PLAYFABCLIENT_API && !DISABLE_PLAYFABENTITY_API && !DISABLE_PLAYFAB_STATIC_API

using PlayFab.ClientModels;

namespace PlayFab.UUnit
{
    public class StaticAuthTests : UUnitTestCase
    {
        private TestTitleDataLoader.TestTitleData titleData;

        public override void ClassSetUp()
        {
            titleData = TestTitleDataLoader.LoadTestTitleData();
            PlayFabSettings.staticSettings.TitleId = titleData.titleId;
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        public override void SetUp(UUnitTestContext testContext)
        {
            VerifyCleanCreds(testContext);
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // Tests are all async, no need to tick
        }

        public override void TearDown(UUnitTestContext testContext)
        {
            VerifyCleanCreds(testContext);
        }

        private void VerifyCleanCreds(UUnitTestContext testContext)
        {
            testContext.False(PlayFabClientAPI.IsClientLoggedIn(), "Static client login did not clean up properly.");
            testContext.False(PlayFabAuthenticationAPI.IsEntityLoggedIn(), "Static entity login did not clean up properly.");
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        [UUnitTest]
        public void BasicStaticLogin(UUnitTestContext testContext)
        {
            var loginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, StaticLoginCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void StaticLoginCallback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            testContext.True(PlayFabClientAPI.IsClientLoggedIn(), "static client login failed");
            testContext.True(PlayFabAuthenticationAPI.IsEntityLoggedIn(), "static entity login failed");

            PlayFabClientAPI.ForgetAllCredentials();

            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.staticSettings.TitleId + ", " + result.PlayFabId);
        }
    }
}

#endif
