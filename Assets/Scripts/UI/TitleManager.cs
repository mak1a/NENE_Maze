using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;
using UnityEngine.SceneManagement;

namespace Nene.UI
{
    public class TitleManager : MonoBehaviour
    {
        [SerializeField, Header("ノーマルモード用のボタン")]
        Button m_normalButton;

        [SerializeField, Header("ハードモード用のボタン")]
        Button m_hardButton;

        Utility.FadeManager m_fadeMgr;

        void Awake()
        {
            Application.targetFrameRate = 60;
        }

        // Start is called before the first frame update
        void Start()
        {
            m_fadeMgr = Utility.FadeManager.Instance;

            m_normalButton.OnClickAsObservable().AsObservable().First()
                .Subscribe(_ =>
                {
                    m_fadeMgr.ChangeScene("Normal", 0.5f);
                }).AddTo(this);

            m_hardButton.OnClickAsObservable().AsObservable().First()
                .Subscribe(_ =>
                {
                    m_fadeMgr.ChangeScene("Hard", 0.5f);
                }).AddTo(this);
        }
    }
}
