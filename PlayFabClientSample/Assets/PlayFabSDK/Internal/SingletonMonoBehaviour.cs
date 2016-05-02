using UnityEngine;

namespace PlayFab.Internal
{
    //public to be accessible by Unity engine
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        private static T m_instance;

        public static T instance
        {
            get
            {
                if (m_instance == null)
                {
                    //find existing instance
                    m_instance = GameObject.FindObjectOfType<T> ();
                    if (m_instance == null)
                    {
                        //create new instance
                        GameObject go = new GameObject (typeof (T).Name);
                        m_instance = go.AddComponent<T> ();
                    }
                    //initialize instance if necessary
                    if (!m_instance.initialized)
                    {
                        m_instance.Initialize ();
                        m_instance.initialized = true;
                    }
                }
                return m_instance;
            }
        }

        private void Awake ()
        {
            DontDestroyOnLoad(this);
            //check if instance already exists when reloading original scene
            if (m_instance != null)
            {
                DestroyImmediate (gameObject);
            }
        }

        protected bool initialized { get; set; }

        protected virtual void Initialize ()
        {}
    }
}
