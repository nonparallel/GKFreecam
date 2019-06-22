using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GKFreecam.FreecamStates
{
    public abstract class StateBase
    {
        internal bool _entered = false;
        public CamState CurrentState;

        public abstract void Update();

        public virtual void UpdateRealtime()
        {

        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}
