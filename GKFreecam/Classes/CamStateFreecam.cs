using Harmony;
using GKML;
using UnityEngine;
using System;

namespace GKFreecam.Classes
{
    /// <summary>
    /// The CamState for the freecam.
    /// </summary>

    public class CamStateFreecam : CamState
    {
        public Vector3 mouseOrigin;
        public int CamState;
        public Vector3 mouseOrigin2;

        public override ECamState state => ECamState.Follow;

        public override void Enter(Transform _Transform, Transform _Target)
        {
            base.Enter(_Transform, _Target);
        }

        public override ECamState Manage(float dt)
        {
            switch (CamState)
            {
                case 1:
                    CSOne();
                    break;

                case 2:
                    CSTwo();
                    break;

                case 3:
                    CSThree();
                    break;
            }
            return state;
        }

        public void CSOne()
        {
            if (Input.GetMouseButtonDown(1))
                mouseOrigin2 = Input.mousePosition;

            if (Input.GetMouseButton(1))
            {
                Vector3 vector2 = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin2);
                Vector3 translation = new Vector3(vector2.y * 2f, -vector2.x * 2f, 0f);
                m_Transform.Rotate(translation, Space.World);
            }

            if (Input.GetMouseButtonDown(0))
                mouseOrigin = Input.mousePosition;

            if (Input.GetMouseButton(0))
            {
                Vector3 vector3 = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
                Vector3 translation2 = new Vector3(vector3.x * 2f, vector3.y * 2f, 0f);
                m_Transform.Translate(translation2, Space.Self);
            }

            if (Input.GetMouseButton(2))
                m_Transform.Translate(new Vector3(0f, 0f, 1f), Space.Self);
        }

        public void CSTwo()
        {
            if (Input.GetKey(KeyCode.I))
                m_Transform.Translate(new Vector3(0f, 0f, 0.5f), Space.Self);
            if (Input.GetKey(KeyCode.K))
                m_Transform.Translate(new Vector3(0f, 0f, -0.5f), Space.Self);
            if (Input.GetKey(KeyCode.J))
                m_Transform.Translate(new Vector3(-0.5f, 0f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.L))
                m_Transform.Translate(new Vector3(0.5f, 0f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.RightShift))
                m_Transform.Translate(new Vector3(0f, 0.5f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.RightControl))
                m_Transform.Translate(new Vector3(0f, -0.5f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.UpArrow))
                m_Transform.Rotate(0.5f, 0f, 0f);
            if (Input.GetKey(KeyCode.DownArrow))
                m_Transform.Rotate(-0.5f, 0f, 0f);
            if (Input.GetKey(KeyCode.LeftArrow))
                m_Transform.Rotate(0f, -0.5f, 0f);
            if (Input.GetKey(KeyCode.RightArrow))
                m_Transform.Rotate(0f, 0.5f, 0f);
        }

        public void CSThree()
        {
            float z;

            if (Input.GetKey(KeyCode.Joystick1Button5))
                z = 0.5f;
            else if (Input.GetKey(KeyCode.Joystick1Button4))
                z = -0.5f;
            else
                z = 0f;

            if (!Input.GetKey(KeyCode.Joystick1Button0))
                m_Transform.position += new Vector3(Input.GetAxis("DPadX"), Input.GetAxis("DPadY"), z);
            else
                m_Transform.Rotate(Input.GetAxis("DPadX"), Input.GetAxis("DPadY"), z);
        }
    }
}
