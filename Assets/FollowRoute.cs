using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRoute : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    private Queue<Transform> targets;
    private Transform target;
    private void Start()
    {
        targets = new Queue<Transform>();
        foreach (Transform waypoint in waypoints)
        {
            targets.Enqueue(waypoint);
        }
        target = targets.Peek();
    }

    private void Update()
    {
        if (targetInRange())
        {
            targets.Enqueue(target);
            target = targets.Dequeue();
        }

        transform.LookAt(target);
    }

    private bool targetInRange()
    {
        if (target == null) return false;
        return Vector3.Distance(transform.position, target.position) < 3f;
    }
}
