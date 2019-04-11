#if !DISABLE_PLAYFABCLIENT_API
using System;
using PlayFab.ClientModels;

namespace PlayFab.UUnit
{
    public class ClientMultiUserTests : UUnitTestCase
    {
        private Action _tickAction;

        private PlayFabAuthenticationContext _player1;
        private PlayFabAuthenticationContext _player2;

        public override void Tick(UUnitTestContext testContext)
        {
            if (_tickAction != null)
                _tickAction();
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext) error.CustomData).Fail(error.GenerateErrorReport());
        }

        /// <summary>
        /// CLIENT API
        /// Test for more then one user can login at the same time asynchronously
        /// </summary>
        [UUnitTest]
        public void AsyncMultiUserLogin(UUnitTestContext testContext)
        {
            var player1LoginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier + "0",
                CreateAccount = true
            };

            var player2LoginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier + "1",
                CreateAccount = true
            };

            PlayFabClientAPI.LoginWithCustomID(player1LoginRequest, x => _player1 = x.AuthenticationContext,
                PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            PlayFabClientAPI.LoginWithCustomID(player2LoginRequest, x => _player2 = x.AuthenticationContext,
                PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);

            _tickAction = () =>
            {
                // return if players not loaded yet
                if (_player1 == null || _player2 == null) return;

                // reset delegate to avoid calling this method again
                _tickAction = null;

                // players must not be equals
                testContext.False(_player1.PlayFabId == _player2.PlayFabId);
                testContext.EndTest(UUnitFinishState.PASSED, "Two players are successfully login. " + _player1.PlayFabId + ", " + _player2.PlayFabId);
            };
        }

        /// <summary>
        /// CLIENT API
        /// Test for more than one user can make an API call at the same time asynchronously
        /// </summary>
        [UUnitTest]
        public void AsyncMultiUserApiCall(UUnitTestContext testContext)
        {
            var player1Request = new GetAccountInfoRequest {AuthenticationContext = _player1};
            var player2Request = new GetAccountInfoRequest {AuthenticationContext = _player2};
            UserAccountInfo player1AccountInfo = null;
            UserAccountInfo player2AccountInfo = null;

            PlayFabClientAPI.GetAccountInfo(player1Request, x => player1AccountInfo = x.AccountInfo,
                PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            PlayFabClientAPI.GetAccountInfo(player2Request, x => player2AccountInfo = x.AccountInfo,
                PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);

            _tickAction = () =>
            {
                // wait loading account info
                if (player1AccountInfo == null || player2AccountInfo == null) return;

                // reset delegate to avoid calling this method again
                _tickAction = null;

                // compares received data with cached data to make sure everything works correctly
                testContext.True(_player1.PlayFabId == player1AccountInfo.PlayFabId, "Player1 PlayFabIds not match!");
                testContext.True(_player2.PlayFabId == player2AccountInfo.PlayFabId, "Player2 PlayFabIds not match!");

                // playFabId at different players must be different
                testContext.False(player1AccountInfo.PlayFabId == player2AccountInfo.PlayFabId, "Players PlayFabId is equals!");
                testContext.EndTest(UUnitFinishState.PASSED, _player1.PlayFabId + ", " + _player2.PlayFabId);
            };
        }
    }
}
#endif
