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
        if (dogIsFarAway())
        {
            yield return new WaitForSeconds(1);
            // IDLE HERE
            anim.SetBool("Run", false);
            transform.Rotate(new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f), Space.World);
        }
        else
        {
            transform.LookAt(dogPosition.Vector3);
            transform.Rotate(0, 180, 0);
        }

        // START WALKING HERE
        anim.SetBool("Run", true);
        float timePassed = 0;
        float endTime = 1;
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
