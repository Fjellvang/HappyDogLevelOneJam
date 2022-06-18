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
        public float timeToBeInState = 4f; //TODO: move to somewhere more configurable?
        private float timeInState = 0f;
        private float originalMass;

        public override void OnEnterState(HumanController controller)
        {
            originalMass = controller.rigidBody.mass;
            controller.rigidBody.mass = originalMass * 0.1f; // Half the mass so we drag it easier?
            controller.rigidBody.constraints = UnityEngine.RigidbodyConstraints.None;
            timeInState = 0f;

            controller.navMeshAgent.enabled = false;
            controller.rigidBody.isKinematic = false;
        }

        public override void Update(HumanController controller)
        {
            timeInState += Time.deltaTime;
            if (timeInState >= timeToBeInState && Input.GetKeyDown(KeyCode.G))
            {
                controller.stateMachine.TransitionState(WalkingState); //TODO: Introduce "Getting up" state?
            }
        }

        public override void OnExitState(HumanController controller)
        {
            controller.rigidBody.mass = originalMass;
        }
    }
}
