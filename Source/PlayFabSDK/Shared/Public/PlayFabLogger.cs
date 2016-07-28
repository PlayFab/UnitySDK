using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using PlayFab.Internal;
using UnityEngine;

namespace PlayFab.Public
{
#if !UNITY_WSA && !UNITY_WP8 && !NETFX_CORE
    public interface IPlayFabLogger
    {
        IPAddress ip { get; set; }
        int port { get; set; }
        string url { get; set; }

        // Unity MonoBehaviour callbacks
        void OnEnable();
        void OnDisable();
        void OnDestroy();
    }

    /// <summary>
    /// This is some unity-log capturing logic, and threading tools that allow logging to be caught and processed on another thread
    /// </summary>
    public abstract class PlayFabLoggerBase : IPlayFabLogger
    {
        private static readonly StringBuilder Sb = new StringBuilder();
        private readonly Queue<string> LogMessageQueue = new Queue<string>();
        private const int LOG_CACHE_INTERVAL_MS = 10000;

        private Thread _writeLogThread;
        private readonly object _threadLock = new object();
        private static readonly TimeSpan _threadKillTimeout = TimeSpan.FromSeconds(60);
        private DateTime _threadKillTime = DateTime.UtcNow + _threadKillTimeout; // Kill the thread after 1 minute of inactivity
        private bool _isApplicationPlaying = true;
        private int _pendingLogsCount;

        public IPAddress ip { get; set; }
        public int port { get; set; }
        public string url { get; set; }

        protected PlayFabLoggerBase()
        {
            PlayFabDataGatherer gatherer = new PlayFabDataGatherer();
            gatherer.GatherData();
            var message = gatherer.GenerateReport();
            lock (LogMessageQueue)
            {
                LogMessageQueue.Enqueue(message);
            }
        }

        public virtual void OnEnable()
        {
            PlayFabHttp.instance.StartCoroutine(RegisterLogger()); // Coroutine helper to set up log-callbacks
        }

        private IEnumerator RegisterLogger()
        {
            yield return new WaitForEndOfFrame(); // Effectively just a short wait before activating this registration
            if (!string.IsNullOrEmpty(PlayFabSettings.LoggerHost))
            {
#if UNITY_5
                Application.logMessageReceivedThreaded += HandleUnityLog;
#else
                Application.RegisterLogCallback(HandleUnityLog);
#endif
            }
        }

        public virtual void OnDisable()
        {
            if (!string.IsNullOrEmpty(PlayFabSettings.LoggerHost))
            {
#if UNITY_5
                Application.logMessageReceivedThreaded -= HandleUnityLog;
#else
                Application.RegisterLogCallback(null);
#endif
            }
        }

        public virtual void OnDestroy()
        {
            _isApplicationPlaying = false;
        }

        /// <summary>
        /// Logs are cached and written in bursts
        /// BeginUploadLog is called at the begining of each burst
        /// </summary>
        protected abstract void BeginUploadLog();
        /// <summary>
        /// Logs are cached and written in bursts
        /// UploadLog is called for each cached log, between BeginUploadLog and EndUploadLog
        /// </summary>
        protected abstract void UploadLog(string message);
        /// <summary>
        /// Logs are cached and written in bursts
        /// EndUploadLog is called at the end of each burst
        /// </summary>
        protected abstract void EndUploadLog();

        /// <summary>
        /// Handler to process Unity logs into our logging system
        /// </summary>
        /// <param name="message"></param>
        /// <param name="stacktrace"></param>
        /// <param name="type"></param>
        private void HandleUnityLog(string message, string stacktrace, LogType type)
        {
            if (!PlayFabSettings.EnableRealTimeLogging)
                return;

            Sb.Length = 0;
            if (type == LogType.Log || type == LogType.Warning)
            {
                Sb.Append(type).Append(": ").Append(message);
                message = Sb.ToString();
                lock (LogMessageQueue)
                {
                    LogMessageQueue.Enqueue(message);
                }
            }
            else if (type == LogType.Error || type == LogType.Exception)
            {
                Sb.Append(type).Append(": ").Append(message).Append("\n").Append(stacktrace).Append(StackTraceUtility.ExtractStackTrace());
                message = Sb.ToString();
                lock (LogMessageQueue)
                {
                    LogMessageQueue.Enqueue(message);
                }
            }
            ActivateThreadWorker();
        }

        private void ActivateThreadWorker()
        {
            lock (_threadLock)
            {
                if (_writeLogThread != null)
                {
                    return;
                }
                _writeLogThread = new Thread(WriteLogThreadWorker);
                _writeLogThread.Start();
            }
        }

        private void WriteLogThreadWorker()
        {
            try
            {
                bool active;
                lock (_threadLock)
                {
                    // Kill the thread after 1 minute of inactivity
                    _threadKillTime = DateTime.UtcNow + _threadKillTimeout;
                }

                var localLogQueue = new Queue<string>();
                do
                {
                    lock (LogMessageQueue)
                    {
                        _pendingLogsCount = LogMessageQueue.Count;
                        while (LogMessageQueue.Count > 0) // Transfer the messages to the local queue
                            localLogQueue.Enqueue(LogMessageQueue.Dequeue());
                    }

                    BeginUploadLog();
                    while (localLogQueue.Count > 0) // Transfer the messages to the local queue
                        UploadLog(localLogQueue.Dequeue());
                    EndUploadLog();

                    #region Expire Thread.
                    // Check if we've been inactive
                    lock (_threadLock)
                    {
                        var now = DateTime.UtcNow;
                        if (_pendingLogsCount > 0 && _isApplicationPlaying)
                        {
                            // Still active, reset the _threadKillTime
                            _threadKillTime = now + _threadKillTimeout;
                        }
                        // Kill the thread after 1 minute of inactivity
                        active = now <= _threadKillTime;
                        if (!active)
                        {
                            _writeLogThread = null;
                        }
                        // This thread will be stopped, so null this now, inside lock (_threadLock)
                    }
                    #endregion

                    Thread.Sleep(LOG_CACHE_INTERVAL_MS);
                } while (active);

            }
            catch (Exception e)
            {
                Debug.LogException(e);
                _writeLogThread = null;
            }
        }
    }
#else
    public interface IPlayFabLogger
    {
        string ip { get; set; }
        int port { get; set; }
        string url { get; set; }

        // Unity MonoBehaviour callbacks
        void OnEnable();
        void OnDisable();
        void OnDestroy();
    }

    /// <summary>
    /// This is just a placeholder.  WP8 doesn't support direct threading, but instead makes you use the await command.
    /// </summary>
    public abstract class PlayFabLoggerBase : IPlayFabLogger
    {
        public string ip { get; set; }
        public int port { get; set; }
        public string url { get; set; }

        // Unity MonoBehaviour callbacks
        public void OnEnable() { }
        public void OnDisable() { }
        public void OnDestroy() { }

        protected abstract void BeginUploadLog();
        protected abstract void UploadLog(string message);
        protected abstract void EndUploadLog();
    }
#endif

    /// <summary>
    /// This translates the logs up to the PlayFab service via a PlayFab restful API
    /// TODO: PLAYFAB - attach these to the PlayFab API
    /// </summary>
    public class PlayFabLogger : PlayFabLoggerBase
    {
        /// <summary>
        /// Logs are cached and written in bursts
        /// BeginUploadLog is called at the begining of each burst
        /// </summary>
        protected override void BeginUploadLog()
        {
        }
        /// <summary>
        /// Logs are cached and written in bursts
        /// UploadLog is called for each cached log, between BeginUploadLog and EndUploadLog
        /// </summary>
        protected override void UploadLog(string message)
        {
        }
        /// <summary>
        /// Logs are cached and written in bursts
        /// EndUploadLog is called at the end of each burst
        /// </summary>
        protected override void EndUploadLog()
        {
        }
    }
}
