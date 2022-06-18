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

    [HideInInspector]
    public NavMeshAgent navMeshAgent;


    private void OnEnable()
    {
        stateMachine = new HumanStateMachine(this);
        rigidBody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        stateMachine.TransitionState(HumanBaseState.WalkingState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update(this);
    }
}
