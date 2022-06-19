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
        foreach (Transform waypoint in waypoints)
        {
            targets.Enqueue(waypoint);
        }
    }
}
