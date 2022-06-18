﻿using UnityEngine;

namespace Assets.Script.States.HumanStates
{
    public class HumanWalkingState : HumanBaseState
    {
        public override void OnEnterState(HumanController controller)
        {
            controller.transform.rotation = Quaternion.identity;
            //controller.transform.localRotation = Quaternion.identity;
            controller.rigidBody.angularVelocity = Vector3.zero;
            controller.rigidBody.constraints = 
                UnityEngine.RigidbodyConstraints.FreezeRotationX |
                UnityEngine.RigidbodyConstraints.FreezeRotationZ;
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