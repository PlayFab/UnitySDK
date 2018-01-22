#if !DISABLE_PLAYFABCLIENT_API && ENABLE_PLAYFABENTITY_API
using PlayFab.EntityModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using PlayFab.Json;
using UnityEngine;

namespace PlayFab.UUnit
{
    /// <summary>
    /// A real system would potentially run only the client or server API, and not both.
    /// But, they still interact with eachother directly.
    /// The tests can't be independent for Client/Server, as the sequence of calls isn't really independent for real-world scenarios.
    /// The client logs in, which triggers a server, and then back and forth.
    /// For the purpose of testing, they each have pieces of information they share with one another, and that sharing makes various calls possible.
    /// </summary>
    public class EntityApiTests : UUnitTestCase
    {
        private TestTitleDataLoader.TestTitleData testTitleData;

        // Test-data constants
        private const string TEST_OBJ_NAME = "testCounter";
        // Test variables
        private string _entityId;
        private string _testFileUrl;
        private string _testFileChecksum;
        private int _testInteger;

        public override void SetUp(UUnitTestContext testContext)
        {
            testTitleData = TestTitleDataLoader.LoadTestTitleData();

            // Verify all the inputs won't cause crashes in the tests
            var titleInfoSet = !string.IsNullOrEmpty(PlayFabSettings.TitleId);
            if (!titleInfoSet)
                testContext.Skip(); // We cannot do client tests if the titleId is not given

            if (testTitleData.extraHeaders != null)
                foreach (var pair in testTitleData.extraHeaders)
                    PlayFabHttp.GlobalHeaderInjection[pair.Key] = pair.Value;
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // Do nothing, because the test finishes asynchronously
        }

        public override void ClassTearDown()
        {
            PlayFabEntityAPI.ForgetAllCredentials();
        }

        private void SharedErrorCallback(PlayFabError error)
        {
            // This error was not expected.  Report it and fail.
            ((UUnitTestContext)error.CustomData).Fail(error.GenerateErrorReport());
        }

        /// <summary>
        /// CLIENT/ENTITY API
        /// Log in or create a user, track their PlayFabId
        /// </summary>
        [UUnitTest]
        public void EntityClientLogin(UUnitTestContext testContext)
        {
            var loginRequest = new ClientModels.LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };
            PlayFabClientAPI.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<ClientModels.LoginResult>(testContext, LoginCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void LoginCallback(ClientModels.LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(PlayFabClientAPI.IsClientLoggedIn(), "User login failed");
            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.TitleId + ", " + result.PlayFabId);
        }

        /// <summary>
        /// ENTITY API
        /// Verify that a client login can be converted into an entity token
        /// </summary>
        [UUnitTest]
        public void GetEntityToken(UUnitTestContext testContext)
        {
            var tokenRequest = new GetEntityTokenRequest();
            PlayFabEntityAPI.GetEntityToken(tokenRequest, PlayFabUUnitUtils.ApiActionWrapper<GetEntityTokenResponse>(testContext, GetTokenCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetTokenCallback(GetEntityTokenResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            _entityId = result.EntityId;
            testContext.StringEquals(EntityTypes.title_player_account.ToString(), result.EntityType, "GetEntityToken EntityType not expected: " + result.EntityType);

            testContext.True(PlayFabClientAPI.IsClientLoggedIn(), "Get Entity Token failed");
            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.TitleId + ", " + result.EntityToken);
        }

        /// <summary>
        /// ENTITY API
        /// Test a sequence of calls that modifies entity objects,
        ///   and verifies that the next sequential API call contains updated information.
        /// Verify that the object is correctly modified on the next call.
        /// </summary>
        [UUnitTest]
        public void ObjectApi(UUnitTestContext testContext)
        {
            var getRequest = new GetObjectsRequest { EntityId = _entityId, EntityType = EntityTypes.title_player_account, EscapeObject = true };
            PlayFabEntityAPI.GetObjects(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetObjectsResponse>(testContext, GetObjectCallback1), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetObjectCallback1(GetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            _testInteger = 0; // Default if the data isn't present
            foreach (var eachObj in result.Objects)
                if (eachObj.ObjectName == TEST_OBJ_NAME)
                    int.TryParse(eachObj.EscapedDataObject, out _testInteger);

            _testInteger = (_testInteger + 1) % 100; // This test is about the Expected value changing - but not testing more complicated issues like bounds

            var updateRequest = new SetObjectsRequest
            {
                EntityId = _entityId,
                EntityType = EntityTypes.title_player_account,
                Objects = new List<SetObject> {
                    new SetObject{ ObjectName = TEST_OBJ_NAME, Unstructured = true, DataObject = _testInteger }
                }
            };
            PlayFabEntityAPI.SetObjects(updateRequest, PlayFabUUnitUtils.ApiActionWrapper<SetObjectsResponse>(testContext, UpdateObjectCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void UpdateObjectCallback(SetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var getRequest = new GetObjectsRequest { EntityId = _entityId, EntityType = EntityTypes.title_player_account, EscapeObject = true };
            PlayFabEntityAPI.GetObjects(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetObjectsResponse>(testContext, GetObjectCallback2), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetObjectCallback2(GetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var actualInteger = -100; // Default if the data isn't present
            testContext.IntEquals(result.Objects.Count, 1, "Incorrect number of entity objects: " + result.Objects.Count);
            testContext.StringEquals(result.Objects[0].ObjectName, TEST_OBJ_NAME, "Expected Test object not found: " + result.Objects[0].ObjectName);
            actualInteger = int.Parse(result.Objects[0].EscapedDataObject);
            testContext.True(actualInteger != -100, "Entity object not set");
            testContext.IntEquals(_testInteger, actualInteger, "Entity Object was not updated: " + actualInteger + "!=" + _testInteger);

            testContext.EndTest(UUnitFinishState.PASSED, null);
        }
    }
}
#endif
