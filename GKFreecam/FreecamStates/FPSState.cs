using System.Runtime.InteropServices;
using UnityEngine;

namespace GKFreecam.FreecamStates
{
    public class FPSState : StateBase
    {
        private Vector3 _mDelta;

        public Vector3 GetMouseVel() => Input.mousePosition - _mDelta;
        public Vector3 GetMouseRotationVel() => new Vector3((Input.mousePosition - _mDelta).y, -(Input.mousePosition - _mDelta).x, (Input.mousePosition - _mDelta).z) * Globals.Config.Sensitivity * 10f;
        public override void Update()
        {
            int _sensitivity = Globals.Config.Sensitivity;
            Vector3 _vel = Vector3.zero;

            #region Mouse
            if (Input.GetMouseButton(1))
                CurrentState.m_Transform.eulerAngles = Vector3.SmoothDamp(CurrentState.m_Transform.eulerAngles, CurrentState.m_Transform.eulerAngles + GetMouseRotationVel(), ref _vel, 0.25f);
            #endregion

            #region Keyboard
            CurrentState.m_Transform.Translate(new Vector3(InputManager.Instance.GetAction(EAction.Steer) * _sensitivity, 0f, InputManager.Instance.GetAction(EAction.Accelerate)) / 2f * _sensitivity, Space.Self);
            #endregion

            _mDelta = Input.mousePosition;
        }
    }
}