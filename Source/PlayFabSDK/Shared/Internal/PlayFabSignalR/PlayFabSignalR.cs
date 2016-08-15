#if ENABLE_PLAYFABPLAYSTREAM_API && ENABLE_PLAYFABSERVER_API
using System;
using System.Collections.Generic;
using System.Threading;
using SignalR.Client._20.Hubs;

namespace PlayFab.Internal
{
    public class PlayFabSignalR : IPlayFabSignalR
    {
        public PlayFabSignalR(Action onConnected)
        {
            OnConnected += onConnected;
        }

        public event Action<string> OnReceived;
        public event Action OnReconnected;
        public event Action OnDisconnected;
        public event Action<Exception> OnError;

        #region Private

        private string _url;
        private string _hubName;

        private event Action OnConnected;
        private static readonly Queue<Action> ResultQueue = new Queue<Action>();
        private static readonly Queue<Action> TempActions = new Queue<Action>();

        private ConnectionState _connState = ConnectionState.Unstarted;
        private readonly object _connLock = new object();
        private HubConnection _connection;
        private IHubProxy _proxy;

        private Thread _startThread;
        private TimeSpan _defaultTimeout = TimeSpan.FromSeconds(110);
        private DateTime _startTime;

        #endregion

        public void Start(string url, string hubName)
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

            _url = url;
            _hubName = hubName;
            _startThread = new Thread(_ThreadedStartConnection);
            _startThread.Start();
        }

        public void Stop()
        {
            lock (_connLock)
            {
                if (_connection != null)
                {
                    _connection.Stop();
                }
                _connState = ConnectionState.Unstarted;
            }

            lock (ResultQueue)
            {
                ResultQueue.Clear();
            }
        }

        public void Subscribe(string methodName, Action<object[]> callback)
        {
            Action<object[]> onData = objs =>
            {
                Action enqueuedAction = () =>
                {
                    callback(objs);
                };

                lock (ResultQueue)
                {
                    ResultQueue.Enqueue(enqueuedAction);
                }
            };

            lock (_connLock)
            {
                _proxy.Subscribe(methodName).Data += onData;
            }
        }

        public void Invoke(string methodName, Action callback, params object[] args)
        {
            EventHandler<SignalR.Client._20.Transports.CustomEventArgs<object>> invokeCallback = (sender, e) =>
            {
                lock (ResultQueue)
                {
                    ResultQueue.Enqueue(callback);
                }
            };

            lock (_connLock)
            {
                _proxy.Invoke(methodName, args).Finished += invokeCallback;
            }
        }

        public void Update()
        {
            lock (ResultQueue)
            {
                while (ResultQueue.Count > 0)
                {
                    var actionToQueue = ResultQueue.Dequeue();
                    if (actionToQueue != null)
                    {
                        TempActions.Enqueue(actionToQueue);
                    }
                }
            }

            while (TempActions.Count > 0)
            {
                var finishedRequest = TempActions.Dequeue();
                if (finishedRequest != null)
                {
                    finishedRequest.Invoke();
                }
            }

            lock (_connLock)
            {
                if (_connState != ConnectionState.Pending) return;
            }

            AbortThreadIfTimeout();
        }

        private void AbortThreadIfTimeout()
        {
            if ((DateTime.UtcNow - _startTime) <= _defaultTimeout) return;
            lock (_connLock)
            {
                if (_startThread == null) return;
            }

            _startThread.Abort();
            _startThread = null;
            lock (_connLock)
            {
                _connState = ConnectionState.Unstarted;
            }
            if (OnError != null)
            {
                OnError(new TimeoutException("Connection timeout after " + _defaultTimeout.TotalSeconds + "s"));
            }
        }

        private void _ThreadedStartConnection()
        {
            var startedConnection = new HubConnection(_url);

            var startedProxy = startedConnection.CreateProxy(_hubName);

            startedConnection.Start();

            lock (_connLock)
            {
                _proxy = startedProxy;
                _connection = startedConnection;

                _connection.Reconnected += ReconnectedAction;
                _connection.Received += ReceivedAction;
                _connection.Error += ErrorAction;
                _connection.Closed += ClosedAction;
                _connState = ConnectionState.Running;
            }
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(OnConnected);
            }
        }

        #region Connection callbacks

        private void ReconnectedAction()
        {
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(OnReconnected);
            }
        }

        private void ReceivedAction(string receivedMsg)
        {
            Action receivedCallback = () =>
            {
                if (OnReceived != null)
                {
                    OnReceived(receivedMsg);
                }
            };
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(receivedCallback);
            }
        }

        private void ErrorAction(Exception ex)
        {
            Action errorAction = () =>
            {
                if (OnError != null)
                {
                    OnError(ex);
                }
                   
            };

            lock (ResultQueue)
            {
                ResultQueue.Enqueue(errorAction);
            }
        }

        private void ClosedAction()
        {
            lock (ResultQueue)
            {
                ResultQueue.Enqueue(OnDisconnected);
            }
        }

        #endregion Connection callbacks

        private enum ConnectionState
        {
            Unstarted,
            Pending,
            Running
        }
    }
}

#endif
