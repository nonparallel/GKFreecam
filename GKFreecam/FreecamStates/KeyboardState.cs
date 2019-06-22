using UnityEngine;

namespace GKFreecam.FreecamStates
{
    public class KeyboardState : StateBase
    {
        public override void Update()
        {
            int _sensitivity = Globals.Config.Sensitivity;

            CurrentState.m_Transform.Translate(new Vector3(InputManager.Instance.GetAction(EAction.Steer), 0f, InputManager.Instance.GetAction(EAction.Accelerate)) / 2f, Space.Self);

            int UpDown = (Utils.BoolToInt(Input.GetKey(KeyCode.UpArrow)) - Utils.BoolToInt(Input.GetKey(KeyCode.DownArrow))) * _sensitivity;
            int LeftRight = (Utils.BoolToInt(Input.GetKey(KeyCode.RightArrow)) - Utils.BoolToInt(Input.GetKey(KeyCode.LeftArrow))) * _sensitivity;

            CurrentState.m_Transform.Rotate(UpDown, 0f, 0f, Space.Self);
            CurrentState.m_Transform.Rotate(0f, LeftRight, 0f, Space.World);
        }
    }
}
