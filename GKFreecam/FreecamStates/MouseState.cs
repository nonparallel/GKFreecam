using UnityEngine;

namespace GKFreecam.FreecamStates
{
    public class MouseState : StateBase
    {
        private Vector3 _mOrigin { get => Globals.LMOrigin; }
        private Vector3 _mDelta;

        public Vector3 GetMouseVel() => Input.mousePosition - _mDelta;
        public Vector3 GetMouseRotationVel() => new Vector3((Input.mousePosition - _mDelta).y, -(Input.mousePosition - _mDelta).x, (Input.mousePosition - _mDelta).z) * 10f;

        public override void Update()
        {
            int _sensitivity = Globals.Config.Sensitivity;
            Vector3 _vel = Vector3.zero;

            if (Input.GetMouseButton(1))
                CurrentState.m_Transform.eulerAngles = Vector3.SmoothDamp(CurrentState.m_Transform.eulerAngles, CurrentState.m_Transform.eulerAngles + GetMouseRotationVel() * _sensitivity, ref _vel, 0.25f);

            if (Input.GetMouseButton(0))
                CurrentState.m_Transform.Translate(UICamera.mainCamera.ScreenToViewportPoint(Input.mousePosition - _mOrigin) * _sensitivity, Space.Self);

            if (Input.GetMouseButton(2))
                CurrentState.m_Transform.Translate(new Vector3(0f, 0f, _sensitivity), Space.Self);

            _mDelta = Input.mousePosition;
        }
    }
}