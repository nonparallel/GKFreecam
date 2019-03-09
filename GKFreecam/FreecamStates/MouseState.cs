using UnityEngine;

namespace GKFreecam.FreecamStates
{
    public class MouseState : StateBase
    {
        private Vector3 _mOrigin;
        private Vector3 _mDelta;

        public Vector3 GetMouseVel() => Input.mousePosition - _mDelta;
        public Vector3 GetMouseRotationVel() => new Vector3((Input.mousePosition - _mDelta).y, -(Input.mousePosition - _mDelta).x, (Input.mousePosition - _mDelta).z) * 10f;

        public override void Update()
        {
            Vector3 _vel = Vector3.zero;

            if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
                _mOrigin = Input.mousePosition;

            if (Input.GetMouseButton(1))
                CurrentState.m_Transform.eulerAngles = Vector3.SmoothDamp(CurrentState.m_Transform.eulerAngles, CurrentState.m_Transform.eulerAngles + GetMouseRotationVel(), ref _vel, 0.25f);

            if (Input.GetMouseButton(0))
                CurrentState.m_Transform.Translate(UICamera.mainCamera.ScreenToViewportPoint(Input.mousePosition - _mOrigin), Space.Self);

            if (Input.GetMouseButton(2))
                CurrentState.m_Transform.Translate(new Vector3(0f, 0f, 0.25f), Space.Self);

            _mDelta = Input.mousePosition;
        }
    }
}