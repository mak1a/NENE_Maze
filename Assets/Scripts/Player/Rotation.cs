using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nene.Player
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField, Header("カメラの親オブジェクト")]
        Transform m_camera;

        [SerializeField, Header("球のRigidbody")]
        Rigidbody m_ball;

        Vector2Int m_rotation;

        Vector2Int m_moveDir;

        [SerializeField, Header("球のスピード")]
        float m_ballSpeed;
        // Start is called before the first frame update
        void Start()
        {
            m_rotation = new Vector2Int();
            m_moveDir = new Vector2Int();
        }

        // Update is called once per frame
        void Update()
        {
            m_moveDir.x = (int)(Input.GetAxisRaw("Vertical") * 2);
            m_moveDir.y = -(int)(Input.GetAxisRaw("Horizontal") * 2);

            var x = m_moveDir.x;
            var z = m_moveDir.y;

            if (x == 0 && m_rotation.x != 0)
            {
                x = m_rotation.x >= 0 ? -1 : 1;
            }
            if (z == 0 && m_rotation.y != 0)
            {
                z = m_rotation.y >= 0 ? -1 : 1;
            }

            if (Mathf.Abs(m_rotation.x + x) <= 10)
            {
                m_rotation.x += x;
            }
            if (Mathf.Abs(m_rotation.y + z) <= 10)
            {
                m_rotation.y += z;
            }

            m_camera.rotation = Quaternion.Euler(-m_rotation.x, 0f, -m_rotation.y) ;
        }

        void FixedUpdate()
        {
            m_ball.AddForce(-m_moveDir.y * m_ballSpeed, 0f, m_moveDir.x * m_ballSpeed);
        }
    } 
}
