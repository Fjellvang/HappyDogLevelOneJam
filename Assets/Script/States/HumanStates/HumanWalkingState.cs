using UnityEngine;

namespace Assets.Script.States.HumanStates
{
    public class HumanWalkingState : HumanBaseState
    {
        public override void OnEnterState(HumanController controller)
        {
            controller.transform.rotation = Quaternion.identity;
            controller.rigidBody.constraints = 
                UnityEngine.RigidbodyConstraints.FreezeRotationX |
                UnityEngine.RigidbodyConstraints.FreezeRotationZ;
            controller.transform.rotation = Quaternion.identity;
        }
        public override void Update(HumanController controller)
        {
            //DEBUG CODE
            if (Input.GetKeyDown(KeyCode.G))
            {
                controller.stateMachine.TransitionState(RagdollState);
            }
        }
    }
}
