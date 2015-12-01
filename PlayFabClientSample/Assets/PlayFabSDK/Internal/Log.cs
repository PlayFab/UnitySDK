using PlayFab;

namespace PlayFab.Internal
{
    public class Log
    {
        public static void Debug(string text, params object[] args)
        {
            if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Debug) != 0)
            {
                UnityEngine.Debug.Log(Util.timeStamp + " DEBUG: " + Util.Format(text, args));
            }
        }

        public static void Info(string text, params object[] args)
        {
            if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Info) != 0)
            {
                UnityEngine.Debug.Log(Util.timeStamp + " INFO: " + Util.Format(text, args));
            }
        }

        public static void Warning(string text, params object[] args)
        {
            if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Warning) != 0)
            {
                UnityEngine.Debug.LogWarning(Util.timeStamp + " WARNING: " + Util.Format(text, args));
            }
        }

        public static void Error(string text, params object[] args)
        {
            if ((PlayFabSettings.LogLevel & PlayFabLogLevel.Error) != 0)
            {
                UnityEngine.Debug.LogError(Util.timeStamp + " ERROR: " + Util.Format(text, args));
            }
        }
    }
}
