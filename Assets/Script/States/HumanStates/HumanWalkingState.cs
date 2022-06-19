using UnityEngine;

namespace Assets.Script.States.HumanStates
{
    public class HumanWalkingState : HumanBaseState
    {
        private Vector3 currentGoal = Vector3.zero;
        public override void OnEnterState(HumanController controller)
        {
            controller.transform.rotation = Quaternion.identity;
            //controller.transform.localRotation = Quaternion.identity;
            controller.rigidBody.angularVelocity = Vector3.zero;
            controller.rigidBody.constraints = 
                UnityEngine.RigidbodyConstraints.FreezeRotationX |
                UnityEngine.RigidbodyConstraints.FreezeRotationZ;

            controller.rigidBody.isKinematic = true;

            SetNewPath(controller);
        }
        public override void Update(HumanController controller)
        {
            //DEBUG CODE
            if (Input.GetKeyDown(KeyCode.G))
            {
                controller.stateMachine.TransitionState(RagdollState);
            }

            var goalDeltaMagnitude = (controller.transform.position - currentGoal).magnitude;
            if (goalDeltaMagnitude < 4f)
            {
                SetNewPath(controller);
            }
        }

        private void SetNewPath(HumanController controller)
        {
            var newGoal =  GoalManager.Instance.GetRandomGoal();
            currentGoal = newGoal;
        }
    }
}
