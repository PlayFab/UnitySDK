namespace PlayFab.Logger
{
    /// <summary>
    /// Logging severity levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Logs that contain the most detailed messages. These messages may contain sensitive
        /// application data. These messages are disabled by default and should never be
        /// enabled in a production environment.
        /// </summary>
        Trace = 0,

        /// <summary>
        /// Logs that are used for interactive investigation during development. These logs
        /// should primarily contain information useful for debugging and have no long-term
        /// value.
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logs that track the general flow of the application. These logs should have long-term
        /// value.
        /// </summary>
        Information = 2,

        /// <summary>
        /// Logs that highlight an abnormal or unexpected event in the application flow,
        /// but do not otherwise cause the application execution to stop.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Logs that highlight when the current flow of execution is stopped due to a failure.
        /// These should indicate a failure in the current activity, not an application-wide
        /// failure.
        /// </summary>
        Error = 4,

        /// <summary>
        /// Logs that describe an unrecoverable application or system crash, or a catastrophic
        /// failure that requires immediate attention.
        /// </summary>
        Critical = 5,

        /// <summary>
        /// Not used for writing log messages. Specifies that a logging category should not
        /// write any messages.
        /// </summary>
        None = 6
    }

    /// <summary>
    /// A logging interface used by PlayFab which allows
    /// different clients to leverage their own logging system.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log a message at a specific logging level.
        /// </summary>
        /// <param name="logLevel">The log level to log at</param>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Log(LogLevel logLevel, string format, params object[] args);

        /// <summary>
        /// Log a trace message.
        /// </summary>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Trace(string format, params object[] args);

        /// <summary>
        /// Log a debug message.
        /// </summary>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Debug(string format, params object[] args);

        /// <summary>
        /// Log an information message.
        /// </summary>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Information(string format, params object[] args);

        /// <summary>
        /// Log a warning message.
        /// </summary>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Warning(string format, params object[] args);

        /// <summary>
        /// Log an error message.
        /// </summary>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Error(string format, params object[] args);

        /// <summary>
        /// Log a critical message.
        /// </summary>
        /// <param name="format">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Critical(string format, params object[] args);
    }
}