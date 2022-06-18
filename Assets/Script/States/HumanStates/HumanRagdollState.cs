using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.States.HumanStates
{
    public class HumanRagdollState : HumanBaseState
    {
        public float timeToBeInState = 2f; //TODO: move to somewhere more configurable?
        private float timeInState = 0f;

        public override void OnEnterState(HumanController controller)
        {
            controller.rigidBody.constraints = UnityEngine.RigidbodyConstraints.None;
            timeInState = 0f;
        }

        public override void Update(HumanController controller)
        {
            timeInState += Time.deltaTime;
            if (timeInState >= timeToBeInState)
            {
                controller.stateMachine.TransitionState(WalkingState); //TODO: Introduce "Getting up" state?
            }
        }
    }
}
