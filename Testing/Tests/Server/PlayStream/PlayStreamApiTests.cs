#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System.Collections.Generic;
using System.IO;
using PlayFab.UUnit;
using PlayFab;
using PlayFab.Internal;
using PlayFab.Json;

public class PlayStreamTests : UUnitTestCase
{
    // Functional
    private static bool TITLE_INFO_SET;

    public override void ClassSetUp()
    {
        var filename = "C:/depot/pf-main/tools/SDKBuildScripts/testTitleData.json";
        if (File.Exists(filename))
        {
            var testInputsFile = PlayFabUtil.ReadAllFileText(filename);

            var testInputs = JsonWrapper.DeserializeObject<Dictionary<string, string>>(testInputsFile, PlayFabUtil.ApiSerializerStrategy);
            TITLE_INFO_SET = true;

            string titleId;
            TITLE_INFO_SET &= testInputs.TryGetValue("titleId", out titleId);
            PlayFabSettings.TitleId = titleId;

            string devSecretKey;
            TITLE_INFO_SET &= testInputs.TryGetValue("developerSecretKey", out devSecretKey);
            PlayFabSettings.DeveloperSecretKey = devSecretKey;
        }
    }

    public override void SetUp(UUnitTestContext testContext)
    {
        if (!TITLE_INFO_SET)
        {
            testContext.Skip();
        }
    }

    [UUnitTest]
    public void PlayStreamServerConnectionTest(UUnitTestContext testContext)
    {
        PlayFabPlayStreamAPI.Start();
        PlayFabPlayStreamAPI.OnSubscribed += () =>
        {
            testContext.EndTest(UUnitFinishState.PASSED, null);
        };
        PlayFabPlayStreamAPI.OnFailed += error =>
        {
            testContext.EndTest(UUnitFinishState.FAILED, error.Message);
        };
        PlayFabPlayStreamAPI.OnError += error =>
        {
            testContext.EndTest(UUnitFinishState.FAILED, error.StackTrace);
        };
    }

    public override void Tick(UUnitTestContext testContext)
    {
        // No async work needed
    }
}
#endif
