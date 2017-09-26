#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using PlayFab;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.UUnit;
using System;
using System.Collections.Generic;
using System.IO;

public class PlayStreamTests : UUnitTestCase
{
    public override void ClassSetUp()
    {
        TestTitleDataLoader.LoadTestTitleData();
    }

    public override void SetUp(UUnitTestContext testContext)
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId) || string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey))
            testContext.Skip(); // We cannot do client tests if the titleId is not given
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
