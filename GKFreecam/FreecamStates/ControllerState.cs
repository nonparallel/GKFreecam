using UnityEngine;

namespace GKFreecam.FreecamStates
{
    public class ControllerState : StateBase
    {
        public override void Update()
        {
            float z;

            if (Input.GetKey(KeyCode.Joystick1Button5))
                z = 0.5f;
            else if (Input.GetKey(KeyCode.Joystick1Button4))
                z = -0.5f;
            else
                z = 0f;

            if (!Input.GetKey(KeyCode.Joystick1Button0))
                CurrentState.m_Transform.position += new Vector3(Input.GetAxis("DPadX"), Input.GetAxis("DPadY"), z);
            else
                CurrentState.m_Transform.Rotate(Input.GetAxis("DPadX"), Input.GetAxis("DPadY"), z);
        }
    }
}
