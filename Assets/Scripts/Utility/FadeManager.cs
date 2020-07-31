using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Nene.Utility
{
    public class FadeManager : SingletonMonoBehaviour<FadeManager>
    {
        private CanvasGroup m_fadeCanvas;

        void Awake()
        {
            m_fadeCanvas = Instance.GetComponent<CanvasGroup>();

            DontDestroyOnLoad(m_fadeCanvas);
        }

        public void ChangeScene(string sceneName_, float fadeTime_)
        {
            m_fadeCanvas.DOFade(1.0f, fadeTime_)
                .OnComplete(() =>
                {
                    SceneManager.LoadScene(sceneName_);
                    m_fadeCanvas.DOFade(0.0f, fadeTime_);
                });
        }
    }
}
