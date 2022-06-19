using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leash : MonoBehaviour
{

    [SerializeField] Transform[] leashPivots;
    [SerializeField] Transform[] leashBones;
    
    void Update()
    {
        for (int i = 0; i < leashPivots.Length; i++)
        {
            leashBones[i].position = leashPivots[i].position;
            leashBones[i].rotation = leashPivots[i].rotation;
            if (i != 0)
            {
                leashBones[i].LookAt(leashPivots[i-1].position);
                leashBones[i].Rotate(new Vector3(-90,0,0));
            }
            
        }
    }
}
