using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Nene.UI
{
    public class Goal : MonoBehaviour
    {
        [SerializeField, Header("球のRigidbody")]
        Rigidbody m_ball;

        bool m_isGoal;

        void Start()
        {
            m_isGoal = false;
        }

        void FixedUpdate()
        {
            if (!m_isGoal)
            {
                return;
            }

            m_ball.AddForce(0f, 50f, 0f);
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Finish"))
            {
                m_isGoal = true;

                Observable.Timer(TimeSpan.FromSeconds(1.0)).Subscribe(_ =>
                {
                    Utility.FadeManager.Instance.ChangeScene("Title", 0.5f);
                }).AddTo(this);
            }
        }
    }
}
