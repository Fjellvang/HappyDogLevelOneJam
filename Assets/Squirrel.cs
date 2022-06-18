using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [Range(0.1f, 100f)]
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        StartCoroutine(RunAround());
    }

    private IEnumerator RunAround()
    {
        transform.Rotate(new Vector3(0, UnityEngine.Random.Range(0, 360)));
        float timePassed = 0;
        float endTime = 1;
        while (timePassed < endTime)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
            timePassed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(RunAround());
    }
}
