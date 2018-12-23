using Harmony;
using GKML;
using UnityEngine;
using System;

namespace GKFreecam.Classes
{
    /// <summary>
    /// Reimplementation of CameraBase.
    /// </summary>

    public class CameraBaseExtension : CameraBase
    {
        private CamStateFreecam freecam = new CamStateFreecam();
        private bool infreecam = false;
        private int FreecamType = 1;

        private Transform m_pTransform;
        private ECamState m_PrevState;

        public new void Start()
        {
            foreach (CamState camState in GetComponents<CamState>())
            {
                if (CamStates[(int)camState.state] == null)
                {
                    CamStates[(int)camState.state] = camState;
                }
            }
            m_pTransform = transform;
            m_PrevState = ECamState.None;
            CurrentState = m_StartState;
        }

        protected CamState GetCurrentStateClassFix()
        {
            return infreecam ? freecam : CamStates[(int)CurrentState];
        }

        private new void FixedUpdate()
        {
            //some bullshit that doesnt depend on the state being in the enum if we're in freecam
            //re: no u

            if (CurrentState == ECamState.None)
            {
                return;
            }

            ECamState currentState = CurrentState;
            ECamState currentState2 = GetCurrentStateClassFix().Manage(Time.fixedDeltaTime);

            m_pTransform.position = GetCurrentStateClassFix().m_Transform.position;
            m_pTransform.rotation = GetCurrentStateClassFix().m_Transform.rotation;

            if (currentState == CurrentState)
            {
                CurrentState = currentState2;
            }
        }

        public void Update()
        {
            freecam.CamState = FreecamType;

            if (Input.GetKeyDown(KeyCode.LeftBracket) && !infreecam)
            {
                freecam.Enter(transform, null);
                infreecam = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftBracket) && infreecam)
            {
                FreecamType++;
                if (FreecamType > 3)
                {
                    FreecamType = 1;
                    infreecam = false;
                }
            }
        }
    }
}
