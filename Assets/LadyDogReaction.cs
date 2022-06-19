using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyDogReaction : MonoBehaviour
{
    [SerializeField] private Vector3Variable dogPosition;
    [SerializeField] private Animator anim;
    private bool dogSpotted;

    private void Update()
    {
        if (dogIsClose() && !dogSpotted)
        {
            dogSpotted = true;
            anim.SetTrigger("Scream");
        }
    }

    private bool dogIsClose()
    {
        return Vector3.Distance(transform.position, dogPosition.Vector3) < 3f;
    }

}
