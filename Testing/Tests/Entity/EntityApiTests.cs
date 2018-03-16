#if !DISABLE_PLAYFABCLIENT_API && ENABLE_PLAYFABENTITY_API
using PlayFab.EntityModels;
using PlayFab.Internal;
using System.Collections.Generic;
using System.Linq;

namespace PlayFab.UUnit
{
    public class EntityApiTests : UUnitTestCase
    {
        private TestTitleDataLoader.TestTitleData testTitleData;

        // Test-data constants
        private const string TEST_OBJ_NAME = "testCounter";
        // Test variables
        private EntityKey _entityKey;
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

            _entityKey = result.Entity;
            testContext.StringEquals(EntityTypes.title_player_account.ToString(), result.Entity.TypeString, "GetEntityToken EntityType not expected: " + result.Entity.TypeString);
            testContext.StringEquals(EntityTypes.title_player_account.ToString(), result.Entity.Type.ToString(), "GetEntityToken EntityType not expected: " + result.Entity.Type);

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
            var getRequest = new GetObjectsRequest { Entity = _entityKey, EscapeObject = true };
            PlayFabEntityAPI.GetObjects(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetObjectsResponse>(testContext, GetObjectCallback1), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetObjectCallback1(GetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            _testInteger = 0; // Default if the data isn't present
            foreach (var eachObjPair in result.Objects)
                if (eachObjPair.Key == TEST_OBJ_NAME)
                    int.TryParse(eachObjPair.Value.EscapedDataObject, out _testInteger);

            _testInteger = (_testInteger + 1) % 100; // This test is about the Expected value changing - but not testing more complicated issues like bounds

            var updateRequest = new SetObjectsRequest
            {
                Entity = _entityKey,
                Objects = new List<SetObject> {
                    new SetObject{ ObjectName = TEST_OBJ_NAME, DataObject = _testInteger }
                }
            };
            PlayFabEntityAPI.SetObjects(updateRequest, PlayFabUUnitUtils.ApiActionWrapper<SetObjectsResponse>(testContext, UpdateObjectCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void UpdateObjectCallback(SetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var getRequest = new GetObjectsRequest { Entity = _entityKey, EscapeObject = true };
            PlayFabEntityAPI.GetObjects(getRequest, PlayFabUUnitUtils.ApiActionWrapper<GetObjectsResponse>(testContext, GetObjectCallback2), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetObjectCallback2(GetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            testContext.IntEquals(result.Objects.Count, 1, "Incorrect number of entity objects: " + result.Objects.Count);
            testContext.True(result.Objects.ContainsKey(TEST_OBJ_NAME), "Expected Test object not found: " + result.Objects.Keys.FirstOrDefault());
            var actualInteger = int.Parse(result.Objects[TEST_OBJ_NAME].EscapedDataObject);
            testContext.IntEquals(_testInteger, actualInteger, "Entity Object was not updated: " + actualInteger + "!=" + _testInteger);

            testContext.EndTest(UUnitFinishState.PASSED, actualInteger.ToString());
        }
    }
}
#endif
