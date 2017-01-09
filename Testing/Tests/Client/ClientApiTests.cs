#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
using PlayFab.Json;
using System;
using System.Collections.Generic;

namespace PlayFab.UUnit
{
    /// <summary>
    /// A real system would potentially run only the client or server API, and not both.
    /// But, they still interact with eachother directly.
    /// The tests can't be independent for Client/Server, as the sequence of calls isn't really independent for real-world scenarios.
    /// The client logs in, which triggers a server, and then back and forth.
    /// For the purpose of testing, they each have pieces of information they share with one another, and that sharing makes various calls possible.
    /// </summary>
    public class ClientApiTests : UUnitTestCase
    {
        private Action _tickAction = null;

        // Test-data constants
        private const string TEST_STAT_NAME = "str";
        private const string TEST_DATA_KEY = "testCounter";

        // Fixed values provided from testInputs
        private static string _userEmail;
        public static string PlayFabId; // Public because the test framework uses this when tests are complete (could be better)

        // This test operates multi-threaded, so keep some thread-transfer varaibles
        private int _testInteger;

        public override void SetUp(UUnitTestContext testContext)
        {
            var titleData = TestTitleDataLoader.LoadTestTitleData();
            _userEmail = titleData.userEmail;

            // Verify all the inputs won't cause crashes in the tests
            var titleInfoSet = !string.IsNullOrEmpty(PlayFabSettings.TitleId) && !string.IsNullOrEmpty(_userEmail);
            if (!titleInfoSet)
                testContext.Skip(); // We cannot do client tests if the titleId is not given
        }

        public override void Tick(UUnitTestContext testContext)
        {
            if (_tickAction != null)
                _tickAction();
        }

        public override void TearDown(UUnitTestContext testContext)
        {
            PlayFabSettings.AdvertisingIdType = null;
            PlayFabSettings.AdvertisingIdValue = null;
            _tickAction = null;
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        /// <summary>
        /// CLIENT API
        /// Try to deliberately log in with an inappropriate password,
        ///   and verify that the error displays as expected.
        /// </summary>
        [UUnitTest]
        public void InvalidLogin(UUnitTestContext testContext)
        {
            // If the setup failed to log in a user, we need to create one.
            var request = new LoginWithEmailAddressRequest
            {
                TitleId = PlayFabSettings.TitleId,
                Email = _userEmail,
                Password = "INVALID",
            };
            PlayFabClientAPI.LoginWithEmailAddress(request, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, InvalidLoginCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ExpectedLoginErrorCallback), testContext);
        }
        private void InvalidLoginCallback(LoginResult result)
        {
            ((UUnitTestContext)result.CustomData).Fail("Login was not expected to pass.");
        }
        private void ExpectedLoginErrorCallback(PlayFabError error)
        {
            var errorReport = error.GenerateErrorReport().ToLower();
            var testContext = (UUnitTestContext)error.CustomData;
            testContext.False(errorReport.Contains("successful"), errorReport);
            testContext.True(errorReport.Contains("password"), errorReport);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }


        /// <summary>
        /// CLIENT API
        /// Try to deliberately register a user with an invalid email and password.
        ///   Verify that errorDetails are populated correctly.
        /// </summary>
        [UUnitTest]
        public void InvalidRegistration(UUnitTestContext testContext)
        {
            var registerRequest = new RegisterPlayFabUserRequest
            {
                Username = "x", // Provide invalid inputs for multiple parameters, which will show up in errorDetails
                Email = "x", // Provide invalid inputs for multiple parameters, which will show up in errorDetails
                Password = "x", // Provide invalid inputs for multiple parameters, which will show up in errorDetails
            };
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, PlayFabUUnitUtils.ApiActionWrapper<RegisterPlayFabUserResult>(testContext, InvalidRegistrationCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, ExpectedRegisterErrorCallback), testContext);
        }
        private void InvalidRegistrationCallback(RegisterPlayFabUserResult result)
        {
            ((UUnitTestContext)result.CustomData).Fail("Register was not expected to pass.");
        }
        private void ExpectedRegisterErrorCallback(PlayFabError error)
        {
            var expectedEmailMsg = "email address is not valid.";
            var expectedPasswordMsg = "password must be between";

            var errorReport = error.GenerateErrorReport().ToLower();
            var testContext = (UUnitTestContext)error.CustomData;
            testContext.True(errorReport.Contains(expectedEmailMsg), errorReport);
            testContext.True(errorReport.Contains(expectedPasswordMsg), errorReport);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }


        /// <summary>
        /// CLIENT API
        /// Log in or create a user, track their PlayFabId
        /// </summary>
        [UUnitTest]
        public void LoginOrRegister(UUnitTestContext testContext)
        {
            var loginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, LoginCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void LoginCallback(LoginResult result)
        {
            PlayFabId = result.PlayFabId;
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(PlayFabClientAPI.IsClientLoggedIn(), "User login failed");
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }


        /// <summary>
        /// CLIENT API
        /// Test that the login call sequence sends the AdvertisingId when set
        /// </summary>
        [UUnitTest]
        public void LoginWithAdvertisingId(UUnitTestContext testContext)
        {
#if (!UNITY_IOS && !UNITY_ANDROID) || (!UNITY_5_3 && !UNITY_5_4 && !UNITY_5_5)
            PlayFabSettings.AdvertisingIdType = PlayFabSettings.AD_TYPE_ANDROID_ID;
            PlayFabSettings.AdvertisingIdValue = "PlayFabTestId";
#endif

            var loginRequest = new LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, AdvertLoginCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void AdvertLoginCallback(LoginResult result)
        {
            PlayFabId = result.PlayFabId;
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(PlayFabClientAPI.IsClientLoggedIn(), "User login failed");

            var target = PlayFabSettings.AD_TYPE_ANDROID_ID + "_Successful";
            var failTime = DateTime.UtcNow + TimeSpan.FromSeconds(10);
            _tickAction = () =>
            {
                if (target == PlayFabSettings.AdvertisingIdType)
                    testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.AdvertisingIdValue);
                if (DateTime.UtcNow > failTime)
                    testContext.EndTest(UUnitFinishState.FAILED, "Timed out waiting for advertising attribution confirmation");
            };
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is correctly modified on the next call.
        /// Parameter types tested: string, Dictionary&lt;string, string>, DateTime
        /// </summary>
        [UUnitTest]
        public void UserDataApi(UUnitTestContext testContext)
        {
            var getRequest = new GetUserDataRequest();
            PlayFabClientAPI.GetUserData(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetUserDataResult>(testContext, GetUserDataCallback1), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetUserDataCallback1(GetUserDataResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            UserDataRecord userDataRecord;
            _testInteger = 0; // Default if the data isn't present
            if (result.Data.TryGetValue(TEST_DATA_KEY, out userDataRecord))
                int.TryParse(userDataRecord.Value, out _testInteger);
            _testInteger = (_testInteger + 1) % 100; // This test is about the Expected value changing - but not testing more complicated issues like bounds

            var updateRequest = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
                {
                    { TEST_DATA_KEY, _testInteger.ToString() }
                }
            };
            PlayFabClientAPI.UpdateUserData(updateRequest, PlayFabUUnitUtils.ApiActionWrapper<UpdateUserDataResult>(testContext, UpdateUserDataCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void UpdateUserDataCallback(UpdateUserDataResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var getRequest = new GetUserDataRequest();
            PlayFabClientAPI.GetUserData(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetUserDataResult>(testContext, GetUserDataCallback2), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetUserDataCallback2(GetUserDataResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            UserDataRecord userDataRecord;
            var actualValue = 0; // Default if the data isn't present
            if (result.Data.TryGetValue(TEST_DATA_KEY, out userDataRecord))
                int.TryParse(userDataRecord.Value, out actualValue);
            testContext.IntEquals(_testInteger, actualValue);
            testContext.NotNull(userDataRecord, "UserData record not found");

            var timeUpdated = userDataRecord.LastUpdated;
            var minTest = DateTime.UtcNow - TimeSpan.FromMinutes(5);
            var maxTest = DateTime.UtcNow + TimeSpan.FromMinutes(5);
            testContext.True(minTest <= timeUpdated && timeUpdated <= maxTest);

            testContext.True(Math.Abs((DateTime.UtcNow - timeUpdated).TotalMinutes) < 5); // Make sure that this timestamp is recent - This must also account for the difference between local machine time and server time
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is saved correctly, and that specific types are tested
        /// Parameter types tested: Dictionary&lt;string, int>
        /// </summary>
        [UUnitTest]
        public void PlayerStatisticsApi(UUnitTestContext testContext)
        {
            var getRequest = new GetPlayerStatisticsRequest();
            PlayFabClientAPI.GetPlayerStatistics(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetPlayerStatisticsResult>(testContext, GetPlayerStatsCallback1), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetPlayerStatsCallback1(GetPlayerStatisticsResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            _testInteger = 0;
            foreach (var eachStat in result.Statistics)
                if (eachStat.StatisticName == TEST_STAT_NAME)
                    _testInteger = eachStat.Value;
            _testInteger = (_testInteger + 1) % 100; // This test is about the Expected value changing - but not testing more complicated issues like bounds

            var updateRequest = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate { StatisticName = TEST_STAT_NAME, Value = _testInteger }
                }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(updateRequest, PlayFabUUnitUtils.ApiActionWrapper<UpdatePlayerStatisticsResult>(testContext, UpdatePlayerStatsCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void UpdatePlayerStatsCallback(UpdatePlayerStatisticsResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var getRequest = new GetPlayerStatisticsRequest();
            PlayFabClientAPI.GetPlayerStatistics(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetPlayerStatisticsResult>(testContext, GetPlayerStatsCallback2), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetPlayerStatsCallback2(GetPlayerStatisticsResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var actualValue = int.MinValue; // a value that shouldn't actually occur in this test
            foreach (var eachStat in result.Statistics)
                if (eachStat.StatisticName == TEST_STAT_NAME)
                    actualValue = eachStat.Value;
            testContext.IntEquals(_testInteger, actualValue);

            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// SERVER API
        /// Get or create the given test character for the given user
        /// Parameter types tested: Contained-Classes, string
        /// </summary>
        [UUnitTest]
        public void UserCharacter(UUnitTestContext testContext)
        {
            var request = new ListUsersCharactersRequest
            {
                PlayFabId = PlayFabId // Received from client upon login
            };
            PlayFabClientAPI.GetAllUsersCharacters(request, PlayFabUUnitUtils.ApiActionWrapper<ListUsersCharactersResult>(testContext, GetCharsCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetCharsCallback(ListUsersCharactersResult result)
        {
            ((UUnitTestContext)result.CustomData).EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test that leaderboard results can be requested
        /// Parameter types tested: List of contained-classes
        /// </summary>
        [UUnitTest]
        public void ClientLeaderBoard(UUnitTestContext testContext)
        {
            var clientRequest = new GetLeaderboardRequest
            {
                MaxResultsCount = 3,
                StatisticName = TEST_STAT_NAME,
            };
            PlayFabClientAPI.GetLeaderboard(clientRequest, PlayFabUUnitUtils.ApiActionWrapper<GetLeaderboardResult>(testContext, GetClientLbCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetClientLbCallback(GetLeaderboardResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(result.Leaderboard.Count > 0, "Client leaderboard should not be empty");
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }


        /// <summary>
        /// CLIENT API
        /// Test that AccountInfo can be requested
        /// Parameter types tested: List of enum-as-strings converted to list of enums
        /// </summary>
        [UUnitTest]
        public void AccountInfo(UUnitTestContext testContext)
        {
            var request = new GetAccountInfoRequest
            {
                PlayFabId = PlayFabId
            };
            PlayFabClientAPI.GetAccountInfo(request, PlayFabUUnitUtils.ApiActionWrapper<GetAccountInfoResult>(testContext, AcctInfoCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void AcctInfoCallback(GetAccountInfoResult result)
        {
            var enumCorrect = (result.AccountInfo != null
                && result.AccountInfo.TitleInfo != null
                && result.AccountInfo.TitleInfo.Origination != null
                && Enum.IsDefined(typeof(UserOrigination), result.AccountInfo.TitleInfo.Origination.Value));

            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(enumCorrect, "Enum value does not match expected options");
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test that CloudScript can be properly set up and invoked
        /// </summary>
        [UUnitTest]
        public void CloudScript(UUnitTestContext testContext)
        {
            var request = new ExecuteCloudScriptRequest
            {
                FunctionName = "helloWorld"
            };
            PlayFabClientAPI.ExecuteCloudScript(request, PlayFabUUnitUtils.ApiActionWrapper<ExecuteCloudScriptResult>(testContext, CloudScriptHwCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void CloudScriptHwCallback(ExecuteCloudScriptResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.NotNull(result.FunctionResult);
            var jobj = (JsonObject)result.FunctionResult;
            var messageValue = jobj["messageValue"] as string;
            testContext.StringEquals("Hello " + PlayFabId + "!", messageValue);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test that CloudScript errors can be deciphered
        /// </summary>
        [UUnitTest]
        public void CloudScriptError(UUnitTestContext testContext)
        {
            var request = new ExecuteCloudScriptRequest
            {
                FunctionName = "throwError"
            };
            PlayFabClientAPI.ExecuteCloudScript(request, PlayFabUUnitUtils.ApiActionWrapper<ExecuteCloudScriptResult>(testContext, CloudScriptErrorCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void CloudScriptErrorCallback(ExecuteCloudScriptResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.IsNull(result.FunctionResult, "The result should be null because the function did not return properly.");
            testContext.NotNull(result.Error, "The error should be defined because the function throws an error.");
            testContext.StringEquals(result.Error.Error, "JavascriptException", result.Error.Error);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test that CloudScript can be properly set up and invoked
        /// </summary>
        [UUnitTest]
        public void CloudScriptGeneric(UUnitTestContext testContext)
        {
            var request = new ExecuteCloudScriptRequest
            {
                FunctionName = "helloWorld"
            };
            PlayFabClientAPI.ExecuteCloudScript<HelloWorldWrapper>(request, PlayFabUUnitUtils.ApiActionWrapper<ExecuteCloudScriptResult>(testContext, CloudScriptGenericHwCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private static void CloudScriptGenericHwCallback(ExecuteCloudScriptResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            var hwResult = result.FunctionResult as HelloWorldWrapper;
            testContext.NotNull(hwResult);
            testContext.StringEquals("Hello " + PlayFabId + "!", hwResult.messageValue);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
        private class HelloWorldWrapper
        {
            public string messageValue = null;
        }

        /// <summary>
        /// CLIENT API
        /// Test that the client can publish custom PlayStream events
        /// </summary>
        [UUnitTest]
        public void WriteEvent(UUnitTestContext testContext)
        {
            var request = new WriteClientPlayerEventRequest
            {
                EventName = "ForumPostEvent",
                Timestamp = DateTime.UtcNow,
                Body = new Dictionary<string, object>
                {
                    { "Subject", "My First Post" },
                    { "Body", "My awesome Post." }
                }
            };

            PlayFabClientAPI.WritePlayerEvent(request, PlayFabUUnitUtils.ApiActionWrapper<WriteEventResponse>(testContext, WriteEventCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void WriteEventCallback(WriteEventResponse result)
        {
            // There's nothing else useful to test about this right now
            ((UUnitTestContext)result.CustomData).EndTest(UUnitFinishState.PASSED, null);
        }
    }
}
#endif
