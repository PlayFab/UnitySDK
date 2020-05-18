#if !DISABLE_PLAYFABCLIENT_API

using System;
using PlayFab.ClientModels;

namespace PlayFab.UUnit
{
    public class ClientMultiUserTests : UUnitTestCase
    {
        private Action _tickAction;

        private PlayFabAuthenticationContext _player1 = new PlayFabAuthenticationContext();
        private PlayFabAuthenticationContext _player2 = new PlayFabAuthenticationContext();

        private PlayFabClientInstanceAPI clientApi = new PlayFabClientInstanceAPI();

        public override void Tick(UUnitTestContext testContext)
        {
            if (_tickAction != null)
                _tickAction();
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        /// <summary>
        /// CLIENT API
        /// Test for more then one user can login at the same time asynchronously
        /// </summary>
        [UUnitTest]
        public void AsyncMultiUserLogin(UUnitTestContext testContext)
        {
            var defaultLoginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true
            };

            var player1LoginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier + "0",
                CreateAccount = true,
                AuthenticationContext = _player1
            };

            var player2LoginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier + "1",
                CreateAccount = true,
                AuthenticationContext = _player2
            };

            clientApi.LoginWithCustomID(defaultLoginRequest, null, PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            clientApi.LoginWithCustomID(player1LoginRequest, null, PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            clientApi.LoginWithCustomID(player2LoginRequest, null, PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);

            _tickAction = () =>
            {
                // return if players not loaded yet
                if (clientApi.authenticationContext.PlayFabId == null || _player1.PlayFabId == null || _player2.PlayFabId == null) return;

                // reset delegate to avoid calling this method again
                _tickAction = null;

                // players must not be equals
                testContext.False(clientApi.authenticationContext.PlayFabId == _player1.PlayFabId);
                testContext.False(clientApi.authenticationContext.PlayFabId == _player2.PlayFabId);
                testContext.False(_player1.PlayFabId == _player2.PlayFabId);
                testContext.EndTest(UUnitFinishState.PASSED, "Two players are successfully login. " + _player1.PlayFabId + ", " + _player2.PlayFabId);
            };
        }
    }
}

#endif
