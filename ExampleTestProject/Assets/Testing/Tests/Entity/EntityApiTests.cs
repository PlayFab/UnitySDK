#if !DISABLE_PLAYFABCLIENT_API && !DISABLE_PLAYFABENTITY_API

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
        private const string TEST_FILE_NAME = "testfile";
        private readonly byte[] _testPayload = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int _testInteger;
        private bool _shouldDeleteFiles;

        private PlayFabClientInstanceAPI clientApi;
        private PlayFabAuthenticationInstanceAPI authApi;
        private PlayFabDataInstanceAPI dataApi;

        public override void ClassSetUp()
        {
            testTitleData = TestTitleDataLoader.LoadTestTitleData();
            clientApi = new PlayFabClientInstanceAPI();
            authApi = new PlayFabAuthenticationInstanceAPI(clientApi.authenticationContext);
            dataApi = new PlayFabDataInstanceAPI(clientApi.authenticationContext);

            PlayFabSettings.staticPlayer.ForgetAllCredentials();
        }

        public override void SetUp(UUnitTestContext testContext)
        {
            // Verify all the inputs won't cause crashes in the tests
            var titleInfoSet = !string.IsNullOrEmpty(PlayFabSettings.TitleId);
            if (!titleInfoSet)
                testContext.Skip(); // We cannot do client tests if the titleId is not given
        }

        public override void Tick(UUnitTestContext testContext)
        {
            // Do nothing, because the test finishes asynchronously
        }

        public override void TearDown(UUnitTestContext testContext)
        {
            // TearDown is not currently suited to handle async cases, though I think it's possible to handle the case
            // For now, this is an example of bad test design (kicking off async work after the test stops),
            //   but in this case, it should only happen if the test fails anyways, so it's... more tolerable
            DeleteFiles(testContext, new List<string> { TEST_FILE_NAME }, false, UUnitFinishState.FAILED, "Problem in the test: Test state was failed in TearDown, and actual test state was lost");
        }

        public override void ClassTearDown()
        {
            PlayFabSettings.staticPlayer.ForgetAllCredentials();
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
            clientApi.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<ClientModels.LoginResult>(testContext, LoginCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void LoginCallback(ClientModels.LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            testContext.True(clientApi.IsClientLoggedIn(), "Client login failed");
            testContext.True(dataApi.IsEntityLoggedIn(), "Entity login didn't transfer to DataApi");
            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.TitleId + ", " + result.PlayFabId);
        }

        /// <summary>
        /// ENTITY API
        /// Verify that a client login can be converted into an entity token
        /// </summary>
        [UUnitTest]
        public void GetEntityToken(UUnitTestContext testContext)
        {
            var tokenRequest = new AuthenticationModels.GetEntityTokenRequest();
            authApi.GetEntityToken(tokenRequest, PlayFabUUnitUtils.ApiActionWrapper<AuthenticationModels.GetEntityTokenResponse>(testContext, GetTokenCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetTokenCallback(AuthenticationModels.GetEntityTokenResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            testContext.StringEquals("title_player_account", result.Entity.Type, "GetEntityToken Entity Type not expected: " + result.Entity.Type);

            testContext.True(clientApi.IsClientLoggedIn(), "Client login failed");
            testContext.True(dataApi.IsEntityLoggedIn(), "Entity login didn't transfer to DataApi");
            testContext.EndTest(UUnitFinishState.PASSED, PlayFabSettings.TitleId + ", " + result.EntityToken.Substring(0, 25) + "...");
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
            testContext.True(dataApi.IsEntityLoggedIn(), "Client");
            var getRequest = new DataModels.GetObjectsRequest { Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType }, EscapeObject = true };
            dataApi.GetObjects(getRequest, PlayFabUUnitUtils.ApiActionWrapper<DataModels.GetObjectsResponse>(testContext, GetObjectCallback1), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetObjectCallback1(DataModels.GetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            _testInteger = 0; // Default if the data isn't present
            foreach (var eachObjPair in result.Objects)
                if (eachObjPair.Key == TEST_OBJ_NAME)
                    int.TryParse(eachObjPair.Value.EscapedDataObject, out _testInteger);

            _testInteger = (_testInteger + 1) % 100; // This test is about the Expected value changing - but not testing more complicated issues like bounds

            var updateRequest = new DataModels.SetObjectsRequest
            {
                Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType },
                Objects = new List<DataModels.SetObject> {
                    new DataModels.SetObject{ ObjectName = TEST_OBJ_NAME, DataObject = _testInteger }
                }
            };
            dataApi.SetObjects(updateRequest, PlayFabUUnitUtils.ApiActionWrapper<DataModels.SetObjectsResponse>(testContext, UpdateObjectCallback), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void UpdateObjectCallback(DataModels.SetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            var getRequest = new DataModels.GetObjectsRequest { Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType }, EscapeObject = true };
            dataApi.GetObjects(getRequest, PlayFabUUnitUtils.ApiActionWrapper<DataModels.GetObjectsResponse>(testContext, GetObjectCallback2), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void GetObjectCallback2(DataModels.GetObjectsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            testContext.IntEquals(result.Objects.Count, 1, "Incorrect number of entity objects: " + result.Objects.Count);
            testContext.True(result.Objects.ContainsKey(TEST_OBJ_NAME), "Expected Test object not found: " + result.Objects.Keys.FirstOrDefault());
            var actualInteger = int.Parse(result.Objects[TEST_OBJ_NAME].EscapedDataObject);
            testContext.IntEquals(_testInteger, actualInteger, "Entity Object was not updated: " + actualInteger + "!=" + _testInteger);

            testContext.EndTest(UUnitFinishState.PASSED, actualInteger.ToString());
        }

        #region PUT_Verb_Test
        /// <summary>
        /// ENTITY PUT API
        /// Tests a sequence of calls that upload file to a server via PUT.
        /// Verifies that the file can be downloaded with the same information it's been saved with.
        /// This sequence assumes that at test start, there are no files on the entity, and it will create and delete a file.
        /// </summary>
        //[UUnitTest]
        public void PutApi(UUnitTestContext testContext)
        {
            var loginRequest = new ClientModels.LoginWithCustomIDRequest
            {
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true,
            };

            clientApi.LoginWithCustomID(loginRequest, PlayFabUUnitUtils.ApiActionWrapper<ClientModels.LoginResult>(testContext, LoginCallbackPutTest), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        private void LoginCallbackPutTest(ClientModels.LoginResult result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            if (result.EntityToken != null)
            {
                LoadFiles(testContext);
            }
            else
            {
                testContext.Fail("Entity Token is null!");
            }
        }
        private void LoadFiles(UUnitTestContext testContext)
        {
            var request = new DataModels.GetFilesRequest
            {
                Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType },
            };

            dataApi.GetFiles(request, PlayFabUUnitUtils.ApiActionWrapper<DataModels.GetFilesResponse>(testContext, OnGetFilesInfo), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        void OnGetFilesInfo(DataModels.GetFilesResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;
            bool testFileFound = false;
            DataModels.GetFileMetadata fileMetaData = new DataModels.GetFileMetadata();

            foreach (var eachFilePair in result.Metadata)
            {
                if (eachFilePair.Key.Equals(TEST_FILE_NAME))
                {
                    testFileFound = true;
                    _shouldDeleteFiles = true; // We attached a file to the player, teardown should delete the file if the test fails

                    fileMetaData = eachFilePair.Value;
                    break; // this test only support one file
                }
            }

            if (!testFileFound)
            {
                UploadFile(testContext, TEST_FILE_NAME);
            }
            else
            {
                GetActualFile(testContext, fileMetaData);
            }
        }
        void GetActualFile(UUnitTestContext testContext, DataModels.GetFileMetadata fileData)
        {
            PlayFabHttp.SimpleGetCall(fileData.DownloadUrl,
                PlayFabUUnitUtils.SimpleApiActionWrapper<byte[]>(testContext, TestFileContent),
                error =>
                {
                    testContext.Fail(error);
                });
        }
        void UploadFile(UUnitTestContext testContext, string fileName)
        {
            var request = new DataModels.InitiateFileUploadsRequest
            {
                Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType },
                FileNames = new List<string>
                {
                    fileName
                },
            };

            dataApi.InitiateFileUploads(request, PlayFabUUnitUtils.ApiActionWrapper<DataModels.InitiateFileUploadsResponse>(testContext, OnInitFileUpload), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, OnInitFailed), testContext);
        }
        void DeleteFiles(UUnitTestContext testContext, List<string> fileName, bool shouldEndTest, UUnitFinishState finishState, string finishMessage)
        {
            if (!_shouldDeleteFiles) // Only delete the file if it was created
                return;

            var request = new DataModels.DeleteFilesRequest
            {
                Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType },
                FileNames = fileName,
            };

            _shouldDeleteFiles = false; // We have successfully deleted the file, it should not try again in teardown
            dataApi.DeleteFiles(request, result =>
            {
                if (shouldEndTest)
                    testContext.EndTest(finishState, finishMessage);
            },
            PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        void OnInitFailed(PlayFabError error)
        {
            var testContext = (UUnitTestContext)error.CustomData;

            if (error.Error == PlayFabErrorCode.EntityFileOperationPending)
            {
                var request = new DataModels.AbortFileUploadsRequest
                {
                    Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType },
                    FileNames = new List<string> { TEST_FILE_NAME },
                };

                dataApi.AbortFileUploads(request, PlayFabUUnitUtils.ApiActionWrapper<DataModels.AbortFileUploadsResponse>(testContext, OnAbortFileUpload), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
            }
            else
            {
                if (error.CustomData != null)
                {
                    SharedErrorCallback(error);
                }
                else
                {
                    testContext.Fail(error.ErrorMessage);
                }
            }
        }
        void OnAbortFileUpload(DataModels.AbortFileUploadsResponse result)
        {
            var testContext = (UUnitTestContext)result.CustomData;

            UploadFile(testContext, TEST_FILE_NAME);
        }
        void OnInitFileUpload(DataModels.InitiateFileUploadsResponse response)
        {
            var testContext = (UUnitTestContext)response.CustomData;

            PlayFabHttp.SimplePutCall(response.UploadDetails[0].UploadUrl,
                _testPayload,
                PlayFabUUnitUtils.SimpleApiActionWrapper<byte[]>(testContext, FinalizeUpload),
                error =>
                {
                    testContext.Fail(error);
                }
            );
        }
        void FinalizeUpload(UUnitTestContext testContext, byte[] payload)
        {
            var request = new DataModels.FinalizeFileUploadsRequest
            {
                Entity = new DataModels.EntityKey { Id = clientApi.authenticationContext.EntityId, Type = clientApi.authenticationContext.EntityType },
                FileNames = new List<string> { TEST_FILE_NAME },
            };
            dataApi.FinalizeFileUploads(request, PlayFabUUnitUtils.ApiActionWrapper<DataModels.FinalizeFileUploadsResponse>(testContext, OnUploadSuccess), PlayFabUUnitUtils.ApiActionWrapper<PlayFabError>(testContext, SharedErrorCallback), testContext);
        }
        void OnUploadSuccess(DataModels.FinalizeFileUploadsResponse result)
        {
            _shouldDeleteFiles = true; // We attached a file to the player, teardown should delete the file if the test fails

            var testContext = (UUnitTestContext)result.CustomData;

            LoadFiles(testContext);
        }
        void TestFileContent(UUnitTestContext testContext, byte[] result)
        {
            var json = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);

            testContext.NotNull(result, "Raw file result was null");
            testContext.True(result.Length > 0, "Raw file result was zero length");

            testContext.StringEquals(json.SerializeObject(_testPayload), json.SerializeObject(result), json.SerializeObject(result));
            DeleteFiles(testContext, new List<string> { TEST_FILE_NAME }, true, UUnitFinishState.PASSED, "File " + TEST_FILE_NAME + " was succesfully created and uploaded to server with PUT");
        }
        #endregion
    }
}

#endif
