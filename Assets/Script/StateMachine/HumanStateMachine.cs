using Assets.Script.States.HumanStates;
using Assets.Scripts.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.StateMachine
{
    public class HumanStateMachine : StateMachine<HumanBaseState, HumanController>
    {
        public HumanStateMachine(HumanController controller) : base(controller)
        {
        }
    }
}
