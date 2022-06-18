using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    SpringJoint[] springJoints;

    public float springValue;

    private void OnEnable()
    {
        springJoints = GetComponentsInChildren<SpringJoint>();
        springValue = springJoints[0].spring;
    }

    [ContextMenu("Set Spring Initial")]
    public void SetSpringInitial() => SetSpringValue();
    [ContextMenu("Set Spring double")]
    public void SetSpringDouble() => SetSpringValue(2);
    [ContextMenu("Set Spring half")]
    public void SetSpringHalf() => SetSpringValue(.1f);

    private void SetSpringValue(float multiplier = 1)
    {
        foreach (var joint in springJoints)
        {
            joint.spring = springValue * multiplier;
        }
    }

    [ContextMenu("Recalculate Anchors")]
    public void RecalcuateAnchors()
    {
        foreach (var joint in springJoints)
        {
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetSpringHalf();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetSpringInitial();
        }
    }
}
