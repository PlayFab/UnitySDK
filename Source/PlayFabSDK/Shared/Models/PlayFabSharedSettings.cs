using UnityEngine;
using PlayFab;

#if UNITY_5 && !UNITY_5_0
[CreateAssetMenu(fileName = "PlayFabSharedSettings", menuName = "PlayFab/CreateSharedSettings", order = 1)]
#endif
public class PlayFabSharedSettings : ScriptableObject
{
    public string TitleId;
#if ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFABSERVER_API
    public string DeveloperSecretKey;
#endif
#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
    public string ProductionEnvironmentPlayStreamUrl = "";
#endif
    public string ProductionEnvironmentUrl = "";
    public WebRequestType RequestType = WebRequestType.UnityWww;
    public int RequestTimeout = 2000;
    public bool RequestKeepAlive = true;
    public bool CompressApiData = true;

    public PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;
    public string LoggerHost = "";
    public int LoggerPort = 0;
    public bool EnableRealTimeLogging = false;
    public int LogCapLimit = 30;
}
