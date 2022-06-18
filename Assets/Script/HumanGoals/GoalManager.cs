using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    Vector3[] goals;
    private void OnEnable()
    {
        goals = GetComponentsInChildren<Transform>().Select(x => x.position).ToArray();

        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        instance = this; 
    }

    private static GoalManager instance;
    public static GoalManager Instance => instance;

    public Vector3 GetRandomGoal() { return goals[Random.Range(0, goals.Length)]; } // A better solution might be to exclude already returned points. For later.

    private void OnDrawGizmosSelected()
    {
        foreach (var transform in goals)
        {
            Gizmos.DrawSphere(transform, 50f);
        }
    }
}
