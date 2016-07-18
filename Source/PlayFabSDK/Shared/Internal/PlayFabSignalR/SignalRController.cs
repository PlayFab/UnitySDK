#if ENABLE_PLAYSTREAM_REALTIME

using System;
using System.Collections.Generic;
using System.Threading;
using SignalR.Client._20.Hubs;

namespace PlayFab.Internal
{
    public class SignalRController : SingletonMonoBehaviour<SignalRController>
    {
        private enum ConnectionState
        {
            Unstarted,
            Pending,
            Running
        }

        private static readonly Queue<Action> ResultQueue = new Queue<Action>();
        private static readonly Queue<Action> _tempActions = new Queue<Action>();
        private static readonly string ConnectionUrl = "http://playstreamlive.playfabdev.com/signalr";
        private static readonly string HubName = "SubscriptionHub";
        private static readonly string TokenKey = "X-Authentication";

        private static float ConnectionTimeout { get; set; }

        public Action OnConnected;
        public Action OnConnectionFailed;

        private ConnectionState _connState = ConnectionState.Unstarted;
        private readonly object _connLock = new object();
        private HubConnection _connection;
        private IHubProxy _proxy;

        private Thread _startThread;
        private DateTime _startTime;

        public void Update()
        {
            lock (ResultQueue)
            {
                while (ResultQueue.Count > 0)
                {
                    var actionToQueue = ResultQueue.Dequeue();
                    _tempActions.Enqueue(actionToQueue);
                }
            }

            while (_tempActions.Count > 0)
            {
                var finishedRequest = _tempActions.Dequeue();
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
                _connState = ConnectionState.Running;
                if (OnConnected != null) OnConnected();
            }

            if (_connState == ConnectionState.Running || _connState == ConnectionState.Unstarted) return;

            if ((DateTime.UtcNow - _startTime).Seconds > ConnectionTimeout)
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
                    if (OnConnectionFailed != null) OnConnectionFailed();
                }

            }
        }

        public void OnDestroy()
        {
            if (_connection != null)
                _connection.Stop();
            lock (ResultQueue)
                ResultQueue.Clear();
        }

        public void StartConnection(string token, float timeOut)
        {
            if (_connState != ConnectionState.Unstarted) return;
            ConnectionTimeout = timeOut;
            _connState = ConnectionState.Pending;
            _startTime = DateTime.UtcNow;
            
            _startThread = new Thread(_ThreadedStartConnection);
            _startThread.Start(token);
        }

        private void _ThreadedStartConnection(object tokenValue)
        {
            var _startedConnection = new HubConnection(ConnectionUrl, new Dictionary<string, string>
                                   {
                                       { TokenKey, (string)tokenValue }
                                   });
            var _startedProxy = _startedConnection.CreateProxy(HubName);
            _startedConnection.Start();

            lock (_connLock)
            {
                _proxy = _startedProxy;
                _connection = _startedConnection;
            }
        }

        public void StopConnetion()
        {
            lock (_connLock) if (_connection != null) _connection.Stop();
            _connState = ConnectionState.Unstarted;
        }

        public void OnClosed(Action closedAction)
        {
            lock (_connLock) _connection.Closed += closedAction;
        }

        public void SubscripeFor(string methodName, Action<object[]> callback)
        {
            lock (_connLock)
            {
                _proxy.Subscribe(methodName).Data += objs =>
                {
                    lock (ResultQueue)
                    {
                        ResultQueue.Enqueue(() =>
                        {
                            callback(objs);
                        });
                    }
                };
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

    }

}

#endif
