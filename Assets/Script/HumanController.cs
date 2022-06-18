using Assets.Script.StateMachine;
using Assets.Script.States.HumanStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rigidBody;

    [HideInInspector]
    public HumanStateMachine stateMachine;
    // Start is called before the first frame update

    public Transform Goal;

    private void OnEnable()
    {
        stateMachine = new HumanStateMachine(this);
        rigidBody = GetComponent<Rigidbody>();
        stateMachine.TransitionState(HumanBaseState.WalkingState);

        GetComponent<NavMeshAgent>().destination = Goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update(this);
    }
}
