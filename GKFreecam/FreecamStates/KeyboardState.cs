using UnityEngine;

namespace GKFreecam.FreecamStates
{
    public class KeyboardState : StateBase
    {
        public override void Update()
        {
            if (Input.GetKey(KeyCode.I))
                CurrentState.m_Transform.Translate(new Vector3(0f, 0f, 0.5f), Space.Self);
            if (Input.GetKey(KeyCode.K))
                CurrentState.m_Transform.Translate(new Vector3(0f, 0f, -0.5f), Space.Self);
            if (Input.GetKey(KeyCode.J))
                CurrentState.m_Transform.Translate(new Vector3(-0.5f, 0f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.L))
                CurrentState.m_Transform.Translate(new Vector3(0.5f, 0f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.RightShift))
                CurrentState.m_Transform.Translate(new Vector3(0f, 0.5f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.RightControl))
                CurrentState.m_Transform.Translate(new Vector3(0f, -0.5f, 0f), Space.Self);
            if (Input.GetKey(KeyCode.UpArrow))
                CurrentState.m_Transform.Rotate(0.5f, 0f, 0f);
            if (Input.GetKey(KeyCode.DownArrow))
                CurrentState.m_Transform.Rotate(-0.5f, 0f, 0f);
            if (Input.GetKey(KeyCode.LeftArrow))
                CurrentState.m_Transform.Rotate(0f, -0.5f, 0f);
            if (Input.GetKey(KeyCode.RightArrow))
                CurrentState.m_Transform.Rotate(0f, 0.5f, 0f);
        }
    }
}
