using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GKFreecam.FreecamStates
{
    public abstract class StateBase
    {
        public CamState CurrentState;

        public abstract void Update();
    }
}
