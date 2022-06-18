using Assets.Scripts.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.States.HumanStates
{
    public abstract class HumanBaseState : BaseState<HumanController>
    {
        public static HumanRagdollState RagdollState = new HumanRagdollState();
        public static HumanWalkingState WalkingState = new HumanWalkingState();
        public override void OnEnterState(HumanController controller)
        {
        }

        public override void OnExitState(HumanController controller)
        {
        }

        public override void Update(HumanController controller)
        {
        }
    }
}
