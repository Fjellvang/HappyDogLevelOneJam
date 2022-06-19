using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySoundController : MonoBehaviour
{
    [SerializeField] private AudioSource babysound;
    [SerializeField] Vector3Variable dogPosition;
    private void Update()
    {
        if (dogIsClose() && !babysound.isPlaying)
        {
            babysound.Play();
        } else if(!dogIsClose() && babysound.isPlaying)
        {
            babysound.Stop();
        }
    }

    private bool dogIsClose()
    {
        return Vector3.Distance(transform.position, dogPosition.Vector3) < 10f;
    }
}
