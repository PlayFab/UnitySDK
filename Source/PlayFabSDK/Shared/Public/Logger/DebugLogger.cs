using System;

namespace PlayFab.Logger
{
    /// <summary>
    /// A logger which writes logs to System.Diagnostics.Debug.
    /// </summary>
    public class DebugLogger : ILogger
    {
        private LogLevel minLogLevel;

        public DebugLogger(LogLevel minLogLevel = LogLevel.Information)
        {
            this.minLogLevel = minLogLevel;
        }

        public void Critical(string format, params object[] args)
        {
            Log(LogLevel.Critical, format, args);
        }

        public void Debug(string format, params object[] args)
        {
            Log(LogLevel.Debug, format, args);
        }

        public void Error(string format, params object[] args)
        {
            Log(LogLevel.Error, format, args);
        }

        public void Information(string format, params object[] args)
        {
            Log(LogLevel.Information, format, args);
        }

        public void Trace(string format, params object[] args)
        {
            Log(LogLevel.Trace, format, args);
        }

        public void Warning(string format, params object[] args)
        {
            Log(LogLevel.Warning, format, args);
        }

        public void Log(LogLevel logLevel, string format, params object[] args)
        {
            Type logLevelType = typeof(LogLevel);

            // Don't log if the logLevel is invalid, or if it is less than the minimum log level specified.
            if (!Enum.IsDefined(logLevelType, logLevel) ||
                logLevel < minLogLevel) {
                return;
            }

            string msg = string.Format("{0} LOG {1}: {2}", DateTime.Now, Enum.GetName(logLevelType, logLevel), string.Format(format, args));

            switch (logLevel)
            {
                case LogLevel.Error:
                case LogLevel.Critical:
                    UnityEngine.Debug.LogError(msg);
                    break;
                case LogLevel.Warning:
                    UnityEngine.Debug.LogWarning(msg);
                    break;
                default:
                    UnityEngine.Debug.Log(msg);
                    break;
            }
        }
    }
}
