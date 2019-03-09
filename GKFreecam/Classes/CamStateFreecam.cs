using Harmony;
using GKML;
using UnityEngine;

using System;
using System.Collections.Generic;

using GKFreecam.FreecamStates;

namespace GKFreecam.Classes
{
    /// <summary>
    /// The CamState for the freecam.
    /// </summary>

    public class CamStateFreecam : CamState
    {
        public int CamState;
        public override ECamState state => ECamState.Follow;

        public List<StateBase> States = new List<StateBase>();

        public void AddState<T>() where T : StateBase
        {
            T _state = Activator.CreateInstance<T>();
            _state.CurrentState = this;

            States.Add(_state);
        }

        public override ECamState Manage(float dt)
        {
            States[CamState].Update();
            return state;
        }

        public void CSThree()
        {
            
        }
    }
}
