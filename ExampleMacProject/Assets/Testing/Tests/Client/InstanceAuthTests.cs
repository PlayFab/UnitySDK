#if !DISABLE_PLAYFABCLIENT_API && !DISABLE_PLAYFABENTITY_API

using PlayFab.ClientModels;

namespace PlayFab.UUnit
{
    public class InstanceAuthTests : UUnitTestCase
    {
        private TestTitleDataLoader.TestTitleData titleData;
        private PlayFabAuthenticationContext player1 = new PlayFabAuthenticationContext();
        private PlayFabAuthenticationContext player2 = new PlayFabAuthenticationContext();
        private PlayFabClientInstanceAPI client1;
        private PlayFabClientInstanceAPI client2;
        private PlayFabAuthenticationInstanceAPI auth1;
        private PlayFabAuthenticationInstanceAPI auth2;

        public override void ClassSetUp()
        {
            titleData = TestTitleDataLoader.LoadTestTitleData();
            PlayFabSettings.staticSettings.TitleId = titleData.titleId;

            client1 = new PlayFabClientInstanceAPI(player1);
            client2 = new PlayFabClientInstanceAPI(player2);
            auth1 = new PlayFabAuthenticationInstanceAPI(player1);
            auth2 = new PlayFabAuthenticationInstanceAPI(player2);

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
            player1.ForgetAllCredentials();
            player2.ForgetAllCredentials();

            VerifyCleanCreds(testContext);
        }

        private void VerifyCleanCreds(UUnitTestContext testContext)
        {
            testContext.False(client1.IsClientLoggedIn(), "Client1 login did not clean up properly.");
            testContext.False(client2.IsClientLoggedIn(), "Client2 login did not clean up properly.");
            testContext.False(auth1.IsEntityLoggedIn(), "Entity1 login did not clean up properly.");
            testContext.False(auth2.IsEntityLoggedIn(), "Entity2 login did not clean up properly.");

            testContext.False(PlayFabSettings.staticPlayer.IsClientLoggedIn(), "Static client login did not clean up properly.");
            testContext.False(PlayFabSettings.staticPlayer.IsEntityLoggedIn(), "Static entity login did not clean up properly.");
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        [UUnitTest]
        public void Instance1Login(UUnitTestContext testContext)
        {
            var loginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };
            client1.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, Instance1Callback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void Instance1Callback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(player1.IsClientLoggedIn(), "player1 client login failed, ");
            testContext.True(client1.IsClientLoggedIn(), "client1 client login failed");
            testContext.True(player1.IsEntityLoggedIn(), "player1 entity login failed");
            testContext.True(auth1.IsEntityLoggedIn(), "auth1 entity login failed");

            testContext.False(PlayFabSettings.staticPlayer.IsClientLoggedIn(), "p1 client context leaked to static context");
            testContext.False(PlayFabSettings.staticPlayer.IsEntityLoggedIn(), "p1 entity context leaked to static context");

            // Verify useful player information
            testContext.NotNull(player1.PlayFabId);
            testContext.NotNull(player1.EntityId);
            testContext.NotNull(player1.EntityType);

            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.staticSettings.TitleId + ", " + result.PlayFabId);
        }

        [UUnitTest]
        public void Instance2Login(UUnitTestContext testContext)
        {
            var loginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };
            client2.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, Instance2Callback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void Instance2Callback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(player2.IsClientLoggedIn(), "player2 client login failed, ");
            testContext.True(client2.IsClientLoggedIn(), "client2 client login failed");
            testContext.True(player2.IsEntityLoggedIn(), "player2 entity login failed");
            testContext.True(auth2.IsEntityLoggedIn(), "auth2 entity login failed");

            testContext.False(PlayFabSettings.staticPlayer.IsClientLoggedIn(), "p2 client context leaked to static context");
            testContext.False(PlayFabSettings.staticPlayer.IsEntityLoggedIn(), "p2 entity context leaked to static context");

            // Verify useful player information
            testContext.NotNull(player2.PlayFabId);
            testContext.NotNull(player2.EntityId);
            testContext.NotNull(player2.EntityType);

            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.staticSettings.TitleId + ", " + result.PlayFabId);
        }

#if !DISABLE_PLAYFAB_STATIC_API
        [UUnitTest]
        public void StaticLogin(UUnitTestContext testContext)
        {
            var loginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, StaticCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void StaticCallback(LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(PlayFabSettings.staticPlayer.IsClientLoggedIn(), "p2 client context leaked to static context");
            testContext.True(PlayFabSettings.staticPlayer.IsEntityLoggedIn(), "p2 entity context leaked to static context");

            testContext.False(client1.IsClientLoggedIn(), "Static login leaked to Client1");
            testContext.False(client2.IsClientLoggedIn(), "tatic login leaked to Client2");
            testContext.False(auth1.IsEntityLoggedIn(), "Static login leaked to Auth1");
            testContext.False(auth2.IsEntityLoggedIn(), "Static login leaked to Auth2");

            PlayFabSettings.staticPlayer.ForgetAllCredentials();

            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.staticSettings.TitleId + ", " + result.PlayFabId);
        }
#endif
    }
}

#endif
