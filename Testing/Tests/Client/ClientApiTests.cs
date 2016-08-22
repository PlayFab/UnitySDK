#if !DISABLE_PLAYFABCLIENT_API
using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PlayFab.UUnit
{
    /// <summary>
    /// A real system would potentially run only the client or server API, and not both.
    /// But, they still interact with eachother directly.
    /// The tests can't be independent for Client/Server, as the sequence of calls isn't really independent for real-world scenarios.
    /// The client logs in, which triggers a server, and then back and forth.
    /// For the purpose of testing, they each have pieces of information they share with one another, and that sharing makes various calls possible.
    /// </summary>
    public class PlayFabApiTest : UUnitTestCase
    {
        // Test-data constants
        private const string TEST_STAT_NAME = "str";
        private const string TEST_DATA_KEY = "testCounter";

        // Functional
        private static bool EXEC_ONCE = true;
        private static bool TITLE_INFO_SET = false;
        private static bool TITLE_CAN_UPDATE_SETTINGS = false;

        // Fixed values provided from testInputs
        private static string USER_NAME;
        private static string USER_EMAIL;
        private static string USER_PASSWORD;

        // Information fetched by appropriate API calls
        public static string PlayFabId;

        // This test operates multi-threaded, so keep some thread-transfer varaibles
        private int _testInteger;

        /// <summary>
        /// PlayFab Title cannot be created from SDK tests, so you must provide your titleId to run unit tests.
        /// (Also, we don't want lots of excess unused titles)
        /// </summary>
        public static void SetTitleInfo(Dictionary<string, string> testInputs)
        {
            string eachValue;

            TITLE_INFO_SET = true;
            // Parse all the inputs
            TITLE_INFO_SET &= testInputs.TryGetValue("titleId", out eachValue);
            PlayFabSettings.TitleId = eachValue;

            TITLE_INFO_SET &= testInputs.TryGetValue("titleCanUpdateSettings", out eachValue);
            TITLE_INFO_SET &= bool.TryParse(eachValue, out TITLE_CAN_UPDATE_SETTINGS);

            TITLE_INFO_SET &= testInputs.TryGetValue("userName", out USER_NAME);
            TITLE_INFO_SET &= testInputs.TryGetValue("userEmail", out USER_EMAIL);
            TITLE_INFO_SET &= testInputs.TryGetValue("userPassword", out USER_PASSWORD);

            // Verify all the inputs won't cause crashes in the tests
            TITLE_INFO_SET &= !string.IsNullOrEmpty(PlayFabSettings.TitleId)
                && !string.IsNullOrEmpty(USER_NAME)
                && !string.IsNullOrEmpty(USER_EMAIL)
                && !string.IsNullOrEmpty(USER_PASSWORD);
        }

        public override void SetUp(UUnitTestContext testContext)
        {
            if (EXEC_ONCE)
            {
                Dictionary<string, string> testInputs;
                string filename = "C:/depot/pf-main/tools/SDKBuildScripts/testTitleData.json"; // TODO: Figure out how to not hard code this
                if (File.Exists(filename))
                {
                    string testInputsFile = PlayFabUtil.ReadAllFileText(filename);

                    testInputs = JsonWrapper.DeserializeObject<Dictionary<string, string>>(testInputsFile, PlayFabUtil.ApiSerializerStrategy);
                }
                else
                {
                    // NOTE FOR DEVELOPERS: if you want to run these tests, provide useful defaults, and uncomment this section, or provide a valid path to a "testTitleData.json" file above
                    testInputs = new Dictionary<string, string>();
                    //Debug.LogError("Loading testSettings file failed: " + filename + ", loading defaults.");
                    //testInputs["titleId"] = "your title id here";
                    //testInputs["titleCanUpdateSettings"] = "true"; // These tests require a GameManager setting: clients must be able to set stats and userData
                    //testInputs["userName"] = "yourTestUserName";
                    //testInputs["userEmail"] = "yourTest@email.com";
                    //testInputs["userPassword"] = "yourTestPassword";
                }
                SetTitleInfo(testInputs);
                EXEC_ONCE = false;
            }

            if (!TITLE_INFO_SET)
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
        /// CLIENT API
        /// Try to deliberately log in with an inappropriate password,
        ///   and verify that the error displays as expected.
        /// </summary>
        [UUnitTest]
        public void InvalidLogin(UUnitTestContext testContext)
        {
            // If the setup failed to log in a user, we need to create one.
            var request = new LoginWithEmailAddressRequest();
            request.TitleId = PlayFabSettings.TitleId;
            request.Email = USER_EMAIL;
            request.Password = USER_PASSWORD + "INVALID";
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
            var registerRequest = new RegisterPlayFabUserRequest();
            registerRequest.TitleId = PlayFabSettings.TitleId;
            registerRequest.Username = "x"; // Provide invalid inputs for multiple parameters, which will show up in errorDetails
            registerRequest.Email = "x"; // Provide invalid inputs for multiple parameters, which will show up in errorDetails
            registerRequest.Password = "x"; // Provide invalid inputs for multiple parameters, which will show up in errorDetails
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
            var loginRequest = new LoginWithCustomIDRequest();
            loginRequest.CustomId = PlayFabSettings.BuildIdentifier;
            loginRequest.CreateAccount = true;
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
            //PlayFabSettings.AdvertisingIdType = PlayFabSettings.AD_TYPE_ANDROID_ID;  //TODO: Evaluate why we would need to set this.
            PlayFabSettings.AdvertisingIdValue = "PlayFabTestId";

            var loginRequest = new LoginWithCustomIDRequest();
            loginRequest.CustomId = PlayFabSettings.BuildIdentifier;
            loginRequest.CreateAccount = true;
            PlayFabClientAPI.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<LoginResult>(testContext, AdvertLoginCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void AdvertLoginCallback(LoginResult result)
        {
            PlayFabId = result.PlayFabId;
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(PlayFabClientAPI.IsClientLoggedIn(), "User login failed");

            // TODO:
            // testContext.StringEquals(PlayFabSettings.AD_TYPE_ANDROID_ID + "_Successful", PlayFabSettings.AdvertisingIdType);
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is correctly modified on the next call.
        /// Parameter types tested: string, Dictionary<string, string>, DateTime
        /// </summary>
        [UUnitTest]
        public void UserDataApi(UUnitTestContext testContext)
        {
            if (!TITLE_CAN_UPDATE_SETTINGS)
            {
                testContext.EndTest(UUnitFinishState.SKIPPED, "This title cannot update statistics from the client");
                return;
            }

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
            int actualValue = 0; // Default if the data isn't present
            if (result.Data.TryGetValue(TEST_DATA_KEY, out userDataRecord))
                int.TryParse(userDataRecord.Value, out actualValue);
            testContext.IntEquals(_testInteger, actualValue);
            testContext.NotNull(userDataRecord, "UserData record not found");

            DateTime timeUpdated = userDataRecord.LastUpdated;
            DateTime minTest = DateTime.UtcNow - TimeSpan.FromMinutes(5);
            DateTime maxTest = DateTime.UtcNow + TimeSpan.FromMinutes(5);
            testContext.True(minTest <= timeUpdated && timeUpdated <= maxTest);

            testContext.True(Math.Abs((DateTime.UtcNow - timeUpdated).TotalMinutes) < 5); // Make sure that this timestamp is recent - This must also account for the difference between local machine time and server time
            testContext.EndTest(UUnitFinishState.PASSED, null);
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is saved correctly, and that specific types are tested
        /// Parameter types tested: Dictionary<string, int>
        /// </summary>
        [UUnitTest]
        public void PlayerStatisticsApi(UUnitTestContext testContext)
        {
            if (!TITLE_CAN_UPDATE_SETTINGS)
            {
                testContext.EndTest(UUnitFinishState.SKIPPED, "This title cannot update statistics from the client");
                return;
            }

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
            var request = new ListUsersCharactersRequest();
            request.PlayFabId = PlayFabId; // Received from client upon login
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
            var clientRequest = new GetLeaderboardRequest();
            clientRequest.MaxResultsCount = 3;
            clientRequest.StatisticName = TEST_STAT_NAME;
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
            GetAccountInfoRequest request = new GetAccountInfoRequest
            {
                PlayFabId = PlayFabId
            };
            PlayFabClientAPI.GetAccountInfo(request, PlayFabUUnitUtils.ApiActionWrapper<GetAccountInfoResult>(testContext, AcctInfoCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void AcctInfoCallback(GetAccountInfoResult result)
        {
            bool enumCorrect = (result.AccountInfo != null
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
