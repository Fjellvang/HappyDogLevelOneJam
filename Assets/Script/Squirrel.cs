using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] private Rigidbody rb;
    [Range(0.1f, 100f)]
    [SerializeField] private float moveSpeed;

    [SerializeField] private Vector3Variable dogPosition;

    private void Start()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        anim.SetBool("Run", false);//set the animator to be idle
        if (dogIsFarAway())
        {
            yield return new WaitForSeconds(1);
            // IDLE HERE
            
            transform.Rotate(new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f), Space.World);
            yield return new WaitForSeconds(2.5f);//pause before it staers moving again
        }
        else
        {
            transform.LookAt(dogPosition.Vector3);
            transform.Rotate(0, 180, 0);
        }

        
        anim.SetBool("Run", true);//set the animator to be running
        // START WALKING HERE

        float timePassed = 0;
        float endTime = 5;
        while (timePassed < endTime)
        {
            
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
            timePassed += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Run());
    }

    private bool dogIsFarAway()
    {
        return Vector3.Distance(transform.position, dogPosition.Vector3) > 10f;
    }
}
