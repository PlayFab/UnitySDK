using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace PlayFab.PfEditor
{
    public class EditorCoroutine
    {
        public string Id;
        public class EditorWaitForSeconds : YieldInstruction
        {
            public float Seconds;

            public EditorWaitForSeconds(float seconds)
            {
                this.Seconds = seconds;
            }
        }

        private SortedList<float, IEnumerator> shouldRunAfterTimes = new SortedList<float, IEnumerator>();
        private const float _tick = .02f;

        public static EditorCoroutine Start(IEnumerator _routine)
        {
            var coroutine = new EditorCoroutine(_routine);
            coroutine.Id = Guid.NewGuid().ToString();
            coroutine.Start();
            return coroutine;
        }

#if UNITY_2018_2_OR_NEWER
        public static EditorCoroutine Start(IEnumerator _routine, UnityWebRequest www)
        {
            var coroutine = new EditorCoroutine(_routine);
            coroutine.Id = Guid.NewGuid().ToString();
            coroutine._www = www;
            coroutine.Start();
            return coroutine;
        }
#else
        public static EditorCoroutine Start(IEnumerator _routine, WWW www)
        {
            var coroutine = new EditorCoroutine(_routine);
            coroutine.Id = Guid.NewGuid().ToString();
            coroutine._www = www;
            coroutine.Start();
            return coroutine;
        }
#endif


        readonly IEnumerator routine;


#if UNITY_2018_2_OR_NEWER
        private UnityWebRequest _www;
        private bool _sent = false;
#else
        private WWW _www;
#endif

        EditorCoroutine(IEnumerator _routine)
        {
            routine = _routine;
        }

        void Start()
        {
            EditorApplication.update += Update;
        }
        private void Stop()
        {
            EditorApplication.update -= Update;
            _www.Dispose();
        }

        private float _timeCounter = 0;
        void Update()
        {
            _timeCounter += _tick;
            //Debug.LogFormat("ID:{0}  TimeCounter:{1}", this.Id, _timeCounter);

            try
            {
                if (_www != null)
                {
#if UNITY_2018_2_OR_NEWER
                    if (!_sent)
                    {
                        try
                        {
                            routine.MoveNext();
                            _sent = true;
                        }
                        catch (ArgumentNullException)
                        {
                        }
                    }
#endif

                    if (_www.isDone && !routine.MoveNext())
                    {
                        Stop();
                    }
                }
                else
                {
                    var seconds = routine.Current as EditorWaitForSeconds;
                    if (seconds != null)
                    {
                        var wait = seconds;
                        shouldRunAfterTimes.Add(_timeCounter + wait.Seconds, routine);
                    }
                    else if (!routine.MoveNext())
                    {
                        Stop();
                    }
                }

                var shouldRun = shouldRunAfterTimes;
                var index = 0;
                foreach (var runAfterSeconds in shouldRun)
                {
                    if (_timeCounter >= runAfterSeconds.Key)
                    {
                        //Debug.LogFormat("RunAfterSeconds: {0} >= {1}", runAfterSeconds.Key, _timeCounter);
                        shouldRunAfterTimes.RemoveAt(index);
                        if (!runAfterSeconds.Value.MoveNext())
                        {
                            Stop();
                        }
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }
}
