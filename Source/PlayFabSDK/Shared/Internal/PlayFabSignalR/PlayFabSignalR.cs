#if ENABLE_PLAYSTREAM_REALTIME

using System;
using System.Collections.Generic;
using System.Threading;
using SignalR.Client._20.Hubs;

namespace PlayFab.Internal
{
    public class PlayFabSignalR : IPlayFabRealtime
    {
        public event Action OnConnected;
        public event Action<string> OnReceived;
        public event Action OnReconnected;
        public event Action OnDisconnected;
        public event Action<Exception> OnError;

        public TimeSpan ConnectionTimeout { get; set; }
        public string AuthToken { get; set; }
        public string Uri { get; set; }
        public string Controller { get; set; }

        #region Private

        private const string TokenKey = "X-Authentication";
        private const float DefaultTimeout = 10000;
        private static readonly Queue<Action> ResultQueue = new Queue<Action>();
        private static readonly Queue<Action> TempActions = new Queue<Action>();

        private ConnectionState _connState = ConnectionState.Unstarted;
        private readonly object _connLock = new object();
        private HubConnection _connection;
        private IHubProxy _proxy;

        private Thread _startThread;
        private DateTime _startTime;

        #endregion

        public void Start()
        {
            lock (_connLock)
            {
                if (_connState != ConnectionState.Unstarted)
                {
                    return;
                }
                _connState = ConnectionState.Pending;
            }

            _startTime = DateTime.UtcNow;

            _startThread = new Thread(_ThreadedStartConnection);
            _startThread.Start(AuthToken);
        }

        public void Close()
        {
            if (_connection != null)
            {
                _connection.Stop();
            }
            lock (ResultQueue)
            {
                ResultQueue.Clear();
            }
        }

        public void Update()
        {
            lock (ResultQueue)
            {
                while (ResultQueue.Count > 0)
                {
                    var actionToQueue = ResultQueue.Dequeue();
                    TempActions.Enqueue(actionToQueue);
                }
            }

            while (TempActions.Count > 0)
            {
                var finishedRequest = TempActions.Dequeue();
                finishedRequest.Invoke();
            }

            var doOnConnectCallback = false;
            var doOnConnectionFailedCallback = false;
            lock (_connLock)
            {
                if (_connection != null && _connState == ConnectionState.Pending)
                {
                    doOnConnectCallback = true;
                }
            }
            if (doOnConnectCallback)
            {
                lock (_connLock)
                {
                    _connState = ConnectionState.Running;
                }
                    
                if (OnConnected != null)
                {
                    OnConnected();
                }
            }

            lock (_connLock)
            {
                if (_connState == ConnectionState.Running || _connState == ConnectionState.Unstarted)
                {
                    return;
                }
            }

            if ((DateTime.UtcNow - _startTime) > ConnectionTimeout)
            {
                lock (_connLock)
                {
                    if (_startThread != null)
                    {
                        _startThread.Abort();
                        _startThread = null;
                        doOnConnectionFailedCallback = true;
                    }
                }

                if (doOnConnectionFailedCallback)
                {
                    _connState = ConnectionState.Unstarted;
                    if (OnError != null)
                    {
                        OnError(new TimeoutException("Timeout after " + DefaultTimeout + " ms"));
                    }
                }

            }
        }

        private void _ThreadedStartConnection(object tokenValue)
        {

            var startedConnection = new HubConnection(Uri, new Dictionary<string, string>
                                   {
                                       { TokenKey, (string)tokenValue }
                                   });
            var startedProxy = startedConnection.CreateProxy(Controller);
            
            ConnectionTimeout = TimeSpan.FromMilliseconds(DefaultTimeout);
            startedConnection.Start();
           
            lock (_connLock)
            {
                _proxy = startedProxy;
                _connection = startedConnection;

                _connection.Reconnected += ReconnectedAction;
                _connection.Received += ReceivedAction;
                _connection.Error += ErrorAction;
                _connection.Closed += ClosedAction;
            }
        }

        #region Connection callbacks

        private void ReconnectedAction()
        {
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(() =>
                {
                    if (OnReconnected != null)
                    {
                        OnReconnected();
                    }
                });
            }
        }

        private void ReceivedAction(string receivedMsg)
        {
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(() =>
                {
                    if (OnReceived != null)
                    {
                        OnReceived(receivedMsg);
                    }
                });
            }
        }

        private void ErrorAction(Exception ex)
        {
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(() =>
                {
                    if (OnError != null)
                    {
                        OnError(ex);
                    }
                });

            }
        }

        private void ClosedAction()
        {
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(() =>
                {
                    if (OnDisconnected != null)
                    {
                        OnDisconnected();
                    }
                });
            }
        }

        #endregion Connection callbacks

        public void StopConnetion()
        {
            lock (_connLock)
            {
                if (_connection != null)
                {
                    _connection.Stop();
                }
                _connState = ConnectionState.Unstarted;
            }
        }

        public void OnClosed(Action closedAction)
        {
            lock (_connLock)
            {
                _connection.Closed += closedAction;
            }
        }

        public void Subscribe(string methodName, Action<object[]> callback)
        {
            Action<object[]> onData = objs =>
            {
                lock (ResultQueue)
                {
                    ResultQueue.Enqueue(() =>
                    {
                        callback(objs);
                    });
                }
            };

            lock (_connLock)
            {
                _proxy.Subscribe(methodName).Data += onData;
            }
        }

        public void Invoke<T>(string methodName, Action<T> callback, params object[] args)
        {
            _proxy.Invoke<T>(methodName, args).Finished += (sender, e) =>
            {
                lock (ResultQueue)
                {
                    ResultQueue.Enqueue(() =>
                    {
                        callback(e.Result);
                    });
                }
            };
        }

        public void Invoke(string methodName, Action callback, params object[] args)
        {
            _proxy.Invoke(methodName, args).Finished += (sender, e) =>
            {
                lock (ResultQueue)
                {
                    ResultQueue.Enqueue(callback);
                }
            };
        }

        public enum ConnectionState
        {
            Unstarted,
            Pending,
            Running
        }
    }
}

#endif
