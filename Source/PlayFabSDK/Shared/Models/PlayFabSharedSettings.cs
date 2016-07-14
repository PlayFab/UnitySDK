using UnityEngine;
using PlayFab;

[CreateAssetMenu(fileName = "PlayFabSharedSettings", menuName = "PlayFab/CreateSharedSettings", order = 1)]
public class PlayFabSharedSettings : ScriptableObject
{
    public string TitleId;
#if ENABLE_PLAYFABADMIN_API || ENABLE_PLAYFABSERVER_API
    public string DeveloperSecretKey;
#endif
    public string ProductionEnvironmentUrl = ".playfabapi.com";
    public WebRequestType RequestType = WebRequestType.UnityWww;
    public int RequestTimeout = 2000;
    public bool RequestKeepAlive = true;
    public bool CompressApiData = true;

    public PlayFabLogLevel LogLevel = PlayFabLogLevel.Warning | PlayFabLogLevel.Error;
    public string LoggerHost = "";
    public int LoggerPort = 0;
    public bool EnableRealTimeLogging = false;
    public int LogCapLimit = 30;

    public bool IsTesting;
}
