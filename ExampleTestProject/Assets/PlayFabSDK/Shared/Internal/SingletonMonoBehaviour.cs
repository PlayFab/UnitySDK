using UnityEngine;

namespace PlayFab.Internal
{
    //public to be accessible by Unity engine
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        private static T _instance;

        public static T instance
        {
            get
            {
                CreateInstance();
                return _instance;
            }
        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                //find existing instance
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    //create new instance
                    var go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }
                //initialize instance if necessary
                if (!_instance.initialized)
                {
                    _instance.Initialize();
                    _instance.initialized = true;
                }
            }
        }

        public virtual void Awake ()
        {
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(this);
            }

            //check if instance already exists when reloading original scene
            if (_instance != null)
            {
                DestroyImmediate (gameObject);
            }
        }

        protected bool initialized;

        protected virtual void Initialize() { }
    }
}
