using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Nene.Utility
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static object m_syncObj = new object();

        static bool m_isApplicationQuitting = false;

        private static volatile T m_instance;
        public static T Instance
        {
            get
            {
                if (m_isApplicationQuitting)
                {
                    return null;
                }

                if (!m_instance)
                {
                    m_instance = FindObjectOfType<T>() as T;
                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        return m_instance;
                    }

                    if (!m_instance)
                    {
                        lock(m_syncObj)
                        {
                            GameObject singleton = new GameObject();
                            singleton.name = typeof(T).ToString() + " (singleton)";
                            m_instance = singleton.AddComponent<T>();
                            DontDestroyOnLoad(singleton);
                        }
                    }
                }

                return m_instance;
            }

            private set
            {
                m_instance = value;
            }
        }

        void OnApplicationQuit()
        {
            m_isApplicationQuitting = true;
        }

        void OnDestroy()
        {
            m_instance = null;
        }

        protected SingletonMonoBehaviour() { }
    }
}
