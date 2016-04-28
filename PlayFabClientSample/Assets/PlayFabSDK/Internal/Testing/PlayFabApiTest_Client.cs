using PlayFab.ClientModels;
using PlayFab.Internal;
using PlayFab.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

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
        private const int TEST_STAT_BASE = 10;
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
        private static string CHAR_NAME;

        // Information fetched by appropriate API calls
        private static string playFabId;

        // This test operates multi-threaded, so keep some thread-transfer varaibles
        private string lastReceivedMessage;
        private UserDataRecord testCounterReturn;
        private int testStatReturn;
        CharacterResult targetCharacter = null;

        /// <summary>
        /// PlayFab Title cannot be created from SDK tests, so you must provide your titleId to run unit tests.
        /// (Also, we don't want lots of excess unused titles)
        /// </summary>
        public static void SetTitleInfo(Dictionary<string, string> testInputs)
        {
            string eachValue;

            PlayFabHTTP.instance.Awake();
            PlayFabSettings.RequestType = WebRequestType.HttpWebRequest;

            TITLE_INFO_SET = true;

            // Parse all the inputs
            TITLE_INFO_SET &= testInputs.TryGetValue("titleId", out eachValue);
            PlayFabSettings.TitleId = eachValue;

            TITLE_INFO_SET &= testInputs.TryGetValue("titleCanUpdateSettings", out eachValue);
            TITLE_INFO_SET &= bool.TryParse(eachValue, out TITLE_CAN_UPDATE_SETTINGS);

            TITLE_INFO_SET &= testInputs.TryGetValue("userName", out USER_NAME);
            TITLE_INFO_SET &= testInputs.TryGetValue("userEmail", out USER_EMAIL);
            TITLE_INFO_SET &= testInputs.TryGetValue("userPassword", out USER_PASSWORD);

            TITLE_INFO_SET &= testInputs.TryGetValue("characterName", out CHAR_NAME);

            // Verify all the inputs won't cause crashes in the tests
            TITLE_INFO_SET &= !string.IsNullOrEmpty(PlayFabSettings.TitleId)
                && !string.IsNullOrEmpty(USER_NAME)
                && !string.IsNullOrEmpty(USER_EMAIL)
                && !string.IsNullOrEmpty(USER_PASSWORD)
                && !string.IsNullOrEmpty(CHAR_NAME);
        }

        protected override void SetUp()
        {
            if (EXEC_ONCE)
            {
                string filename = "C:/depot/pf-main/tools/SDKBuildScripts/testTitleData.json"; // TODO: Figure out how to not hard code this
                if (File.Exists(filename))
                {

                    string testInputsFile = Util.ReadAllFileText(filename);

                    var testInputs = SimpleJson.DeserializeObject<Dictionary<string, string>>(testInputsFile, Util.ApiSerializerStrategy);
                    SetTitleInfo(testInputs);
                }
                else
                {
                    Console.WriteLine("Loading testSettings file failed: " + filename);
                    Console.WriteLine("From: " + Directory.GetCurrentDirectory());
                }
                EXEC_ONCE = false;
            }

            if (!TITLE_INFO_SET)
                UUnitAssert.Skip(); // We cannot do client tests if the titleId is not given
        }

        protected override void TearDown()
        {
            // TODO: Destroy any characters
        }

        private void WaitForApiCalls()
        {
            lastReceivedMessage = null;
            DateTime expireTime = DateTime.UtcNow + TimeSpan.FromSeconds(3);
            while (PlayFabHTTP.GetPendingMessages() != 0 && DateTime.UtcNow < expireTime)
            {
                Thread.Sleep(1); // Wait for the threaded call to be executed
                PlayFabHTTP.instance.Update(); // Invoke the callbacks for any threaded messages
            }
            UUnitAssert.True(DateTime.UtcNow < expireTime, "Request timed out");
            UUnitAssert.NotNull(lastReceivedMessage, "Unexpected internal error within PlayFab api, or test suite");
        }

        private static readonly StringBuilder TempSb = new StringBuilder();
        private void SharedErrorCallback(PlayFabError error)
        {
            TempSb.Length = 0;
            TempSb.Append(error.ErrorMessage);
            if (error.ErrorDetails != null)
                foreach (var pair in error.ErrorDetails)
                    foreach (var msg in pair.Value)
                        TempSb.Append("\n").Append(pair.Key).Append(": ").Append(msg);
            lastReceivedMessage = TempSb.ToString();
        }

        /// <summary>
        /// CLIENT API
        /// Try to deliberately log in with an inappropriate password,
        ///   and verify that the error displays as expected.
        /// </summary>
        [UUnitTest]
        public void InvalidLogin()
        {
            // If the setup failed to log in a user, we need to create one.
            var request = new LoginWithEmailAddressRequest();
            request.TitleId = PlayFabSettings.TitleId;
            request.Email = USER_EMAIL;
            request.Password = USER_PASSWORD + "INVALID";
            PlayFabClientAPI.LoginWithEmailAddress(request, LoginCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.False(lastReceivedMessage.ToLower().Contains("successful"), lastReceivedMessage);
            UUnitAssert.True(lastReceivedMessage.ToLower().Contains("password"), lastReceivedMessage);
        }
        private void LoginCallback(LoginResult result)
        {
            playFabId = result.PlayFabId;
            lastReceivedMessage = "Login Successful";
        }

        /// <summary>
        /// CLIENT API
        /// Try to deliberately register a character with an invalid email and password.
        ///   Verify that errorDetails are populated correctly.
        /// </summary>
        [UUnitTest]
        public void InvalidRegistration()
        {
            var registerRequest = new RegisterPlayFabUserRequest();
            registerRequest.TitleId = PlayFabSettings.TitleId;
            registerRequest.Username = "x"; // Provide invalid inputs for multiple parameters, which will show up in errorDetails
            registerRequest.Email = "x"; // Provide invalid inputs for multiple parameters, which will show up in errorDetails
            registerRequest.Password = "x"; // Provide invalid inputs for multiple parameters, which will show up in errorDetails
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterCallback, SharedErrorCallback);
            WaitForApiCalls();

            var expectedEmailMsg = "email address is not valid.";
            var expectedPasswordMsg = "password must be between";
            UUnitAssert.True(lastReceivedMessage.ToLower().Contains(expectedEmailMsg), lastReceivedMessage);
            UUnitAssert.True(lastReceivedMessage.ToLower().Contains(expectedPasswordMsg), lastReceivedMessage);
        }

        /// <summary>
        /// CLIENT API
        /// Log in or create a user, track their PlayFabId
        /// </summary>
        [UUnitTest]
        public void LoginOrRegister()
        {
            if (!PlayFabClientAPI.IsClientLoggedIn()) // If we haven't already logged in...
            {
                var loginRequest = new LoginWithEmailAddressRequest();
                loginRequest.Email = USER_EMAIL;
                loginRequest.Password = USER_PASSWORD;
                loginRequest.TitleId = PlayFabSettings.TitleId;
                PlayFabClientAPI.LoginWithEmailAddress(loginRequest, LoginCallback, SharedErrorCallback);
                WaitForApiCalls();

                // We don't do any test here, because the user may not exist, and thus login might fail, but the test should not
            }

            if (PlayFabClientAPI.IsClientLoggedIn())
                return; // Success, already logged in

            // If the setup failed to log in a user, we need to create one.
            var registerRequest = new RegisterPlayFabUserRequest();
            registerRequest.TitleId = PlayFabSettings.TitleId;
            registerRequest.Username = USER_NAME;
            registerRequest.Email = USER_EMAIL;
            registerRequest.Password = USER_PASSWORD;
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.StringEquals("User Registration Successful", lastReceivedMessage); // If we get here, we definitely registered a new user, and we definitely want to verify success

            UUnitAssert.True(PlayFabClientAPI.IsClientLoggedIn(), "User login failed");
        }
        private void RegisterCallback(RegisterPlayFabUserResult result)
        {
            playFabId = result.PlayFabId;
            lastReceivedMessage = "User Registration Successful";
        }

        /// <summary>
        /// CLIENT API
        /// Test that the login call sequence sends the AdvertisingId when set
        /// </summary>
        [UUnitTest]
        public void LoginWithAdvertisingId()
        {
            PlayFabSettings.AdvertisingIdType = PlayFabSettings.AD_TYPE_ANDROID_ID;
            PlayFabSettings.AdvertisingIdValue = "PlayFabTestId";

            var loginRequest = new LoginWithEmailAddressRequest();
            loginRequest.Email = USER_EMAIL;
            loginRequest.Password = USER_PASSWORD;
            loginRequest.TitleId = PlayFabSettings.TitleId;
            PlayFabClientAPI.LoginWithEmailAddress(loginRequest, LoginCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.StringEquals(PlayFabSettings.AD_TYPE_ANDROID_ID + "_Successful", PlayFabSettings.AdvertisingIdType);
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is correctly modified on the next call.
        /// Parameter types tested: string, Dictionary<string, string>, DateTime
        /// </summary>
        [UUnitTest]
        public void UserDataApi()
        {
            int testCounterValueExpected, testCounterValueActual;

            var getRequest = new GetUserDataRequest();
            PlayFabClientAPI.GetUserData(getRequest, GetUserDataCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.Equals("User Data Received", lastReceivedMessage);
            int.TryParse(testCounterReturn.Value, out testCounterValueExpected);
            testCounterValueExpected = (testCounterValueExpected + 1) % 100; // This test is about the expected value changing - but not testing more complicated issues like bounds

            var updateRequest = new UpdateUserDataRequest();
            updateRequest.Data = new Dictionary<string, string>();
            updateRequest.Data[TEST_DATA_KEY] = testCounterValueExpected.ToString();
            PlayFabClientAPI.UpdateUserData(updateRequest, UpdateUserDataCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.StringEquals("User Data Updated", lastReceivedMessage);

            getRequest = new GetUserDataRequest();
            PlayFabClientAPI.GetUserData(getRequest, GetUserDataCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.StringEquals("User Data Received", lastReceivedMessage);
            int.TryParse(testCounterReturn.Value, out testCounterValueActual);
            UUnitAssert.IntEquals(testCounterValueExpected, testCounterValueActual);

            DateTime timeUpdated = testCounterReturn.LastUpdated;
            DateTime minTest = DateTime.UtcNow - TimeSpan.FromMinutes(5);
            DateTime maxTest = DateTime.UtcNow + TimeSpan.FromMinutes(5);
            UUnitAssert.True(minTest <= timeUpdated && timeUpdated <= maxTest);

            // UnityEngine.Debug.Log((DateTime.UtcNow - timeUpdated).TotalSeconds);
            UUnitAssert.True(Math.Abs((DateTime.UtcNow - timeUpdated).TotalMinutes) < 5); // Make sure that this timestamp is recent - This must also account for the difference between local machine time and server time
        }
        private void GetUserDataCallback(GetUserDataResult result)
        {
            lastReceivedMessage = "User Data Received";

            if (!result.Data.TryGetValue(TEST_DATA_KEY, out testCounterReturn))
            {
                testCounterReturn = new UserDataRecord();
                testCounterReturn.Value = "0";
            }
        }
        private void UpdateUserDataCallback(UpdateUserDataResult result)
        {
            lastReceivedMessage = "User Data Updated";
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is saved correctly, and that specific types are tested
        /// Parameter types tested: Dictionary<string, int>
        /// </summary>
        [UUnitTest]
        public void UserStatisticsApi()
        {
            int testStatExpected, testStatActual;

            var getRequest = new GetUserStatisticsRequest();
            PlayFabClientAPI.GetUserStatistics(getRequest, GetUserStatsCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.Equals("User Stats Received", lastReceivedMessage);
            testStatExpected = ((testStatReturn + 1) % TEST_STAT_BASE) + TEST_STAT_BASE; // This test is about the expected value changing (incrementing through from TEST_STAT_BASE to TEST_STAT_BASE * 2 - 1)

            var updateRequest = new UpdateUserStatisticsRequest();
            updateRequest.UserStatistics = new Dictionary<string, int>();
            updateRequest.UserStatistics[TEST_STAT_NAME] = testStatExpected;
            PlayFabClientAPI.UpdateUserStatistics(updateRequest, UpdateUserStatsCallback, SharedErrorCallback);
            WaitForApiCalls();

            // Test update result - no data returned, so error or no error, based on Title settings
            if (!TITLE_CAN_UPDATE_SETTINGS)
            {
                UUnitAssert.Equals("error message from PlayFab", lastReceivedMessage);
                return; // The rest of this tests changing settings - Which we verified we cannot do
            }
            else // if (CAN_UPDATE_SETTINGS)
            {
                UUnitAssert.Equals("User Stats Updated", lastReceivedMessage);
            }

            getRequest = new GetUserStatisticsRequest();
            PlayFabClientAPI.GetUserStatistics(getRequest, GetUserStatsCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.Equals("User Stats Received", lastReceivedMessage);
            testStatActual = testStatReturn;
            UUnitAssert.Equals(testStatExpected, testStatActual);
        }
        private void GetUserStatsCallback(GetUserStatisticsResult result)
        {
            lastReceivedMessage = "User Stats Received";

            if (!result.UserStatistics.TryGetValue(TEST_STAT_NAME, out testStatReturn))
                testStatReturn = TEST_STAT_BASE;
        }
        private void UpdateUserStatsCallback(UpdateUserStatisticsResult result)
        {
            lastReceivedMessage = "User Stats Updated";
        }

        /// <summary>
        /// SERVER API
        /// Get or create the given test character for the given user
        /// Parameter types tested: Contained-Classes, string
        /// </summary>
        [UUnitTest]
        public void UserCharacter()
        {
            var request = new ListUsersCharactersRequest();
            request.PlayFabId = playFabId; // Received from client upon login
            PlayFabClientAPI.GetAllUsersCharacters(request, GetCharsCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.Equals("Get Chars Successful", lastReceivedMessage);
            UUnitAssert.NotNull(targetCharacter, "The test character did not exist");
        }
        private void GetCharsCallback(ListUsersCharactersResult result)
        {
            lastReceivedMessage = "Get Chars Successful";
            foreach (var eachCharacter in result.Characters)
                if (eachCharacter.CharacterName == CHAR_NAME)
                    targetCharacter = eachCharacter;
        }

        /// <summary>
        /// CLIENT AND SERVER API
        /// Test that leaderboard results can be requested
        /// Parameter types tested: List of contained-classes
        /// </summary>
        [UUnitTest]
        public void LeaderBoard()
        {
            var clientRequest = new GetLeaderboardRequest();
            clientRequest.MaxResultsCount = 3;
            clientRequest.StatisticName = TEST_STAT_NAME;
            PlayFabClientAPI.GetLeaderboard(clientRequest, GetClientLbCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.Equals("Get Client Leaderboard Successful", lastReceivedMessage);
            // Testing anything more would be testing actual functionality of the Leaderboard, which is outside the scope of this test.
        }
        public void GetClientLbCallback(GetLeaderboardResult result)
        {
            if (result.Leaderboard.Count > 0)
                lastReceivedMessage = "Get Client Leaderboard Successful";
            else
                lastReceivedMessage = "Get Client Leaderboard, empty";
        }

        /// <summary>
        /// CLIENT API
        /// Test that AccountInfo can be requested
        /// Parameter types tested: List of enum-as-strings converted to list of enums
        /// </summary>
        [UUnitTest]
        public void AccountInfo()
        {
            GetAccountInfoRequest request = new GetAccountInfoRequest();
            request.PlayFabId = playFabId;
            PlayFabClientAPI.GetAccountInfo(request, AcctInfoCallback, SharedErrorCallback);
            WaitForApiCalls();

            UUnitAssert.Equals("Enums tested", lastReceivedMessage);
        }
        private void AcctInfoCallback(GetAccountInfoResult result)
        {
            if (result.AccountInfo == null || result.AccountInfo.TitleInfo == null || result.AccountInfo.TitleInfo.Origination == null
            || !Enum.IsDefined(typeof(UserOrigination), result.AccountInfo.TitleInfo.Origination.Value))
            {
                lastReceivedMessage = "Enums not properly tested";
                return;
            }

            lastReceivedMessage = "Enums tested";
        }

        /// <summary>
        /// CLIENT API
        /// Test that CloudScript can be properly set up and invoked
        /// </summary>
        [UUnitTest]
        private void CloudScript()
        {
            if (string.IsNullOrEmpty(PlayFabSettings.LogicServerUrl))
            {
                PlayFabClientAPI.GetCloudScriptUrl(new GetCloudScriptUrlRequest(), CloudScriptUrlCallback, SharedErrorCallback);
                WaitForApiCalls();
                UUnitAssert.True(lastReceivedMessage.StartsWith("CloudScript setup complete: "), lastReceivedMessage);
            }

            var request = new RunCloudScriptRequest();
            request.ActionId = "helloWorld";
            PlayFabClientAPI.RunCloudScript(request, CloudScriptHwCallback, SharedErrorCallback);
            WaitForApiCalls();
            UUnitAssert.Equals("Hello " + playFabId + "!", lastReceivedMessage);
        }
        private void CloudScriptUrlCallback(GetCloudScriptUrlResult result)
        {
            lastReceivedMessage = "CloudScript setup complete: " + result.Url;
        }
        private void CloudScriptHwCallback(RunCloudScriptResult result)
        {
            UUnitAssert.NotNull(result.ResultsEncoded);
            UUnitAssert.NotNull(result.Results);
            var jobj = result.Results as JsonObject;
            lastReceivedMessage = jobj["messageValue"] as string;
        }

        /// <summary>
        /// CLIENT API
        /// Test that the client can publish custom PlayStream events
        /// </summary>
        [UUnitTest]
        private void WriteEvent()
        {
            var request = new WriteClientPlayerEventRequest();
            request.EventName = "ForumPostEvent";
            request.Timestamp = DateTime.UtcNow;
            request.Body = new Dictionary<string, object>();
            request.Body["Subject"] = "My First Post";
            request.Body["Body"] = "My awesome post.";

            PlayFabClientAPI.WritePlayerEvent(request, WriteEventCallback, SharedErrorCallback);
            WaitForApiCalls();
            UUnitAssert.StringEquals("WriteEvent posted successfully.", lastReceivedMessage);
        }
        private void WriteEventCallback(WriteEventResponse result)
        {
            lastReceivedMessage = "WriteEvent posted successfully.";
        }
    }
}
