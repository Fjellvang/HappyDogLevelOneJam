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
    [SerializeField] private IntVariable dogExcitement;

    private void Start()
    {
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        anim.SetBool("Run", false);
        if (dogIsFarAway())
        {
            float wait = UnityEngine.Random.Range(1f, 2f);
            yield return new WaitForSeconds(wait);
            transform.Rotate(new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f), Space.World);
            yield return new WaitForSeconds(wait);
        }
        else
        {
            StartCoroutine(RunAway());
            yield break;
        }

        
        anim.SetBool("Run", true);

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

    private IEnumerator RunAway()
    {
        dogExcitement.Value += 1;
        transform.LookAt(dogPosition.Vector3);
        transform.Rotate(0, 180, 0);
        anim.SetBool("Run", true);
        float timePassed = 0;
        float endTime = 5;
        while (timePassed < endTime)
        {

            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed * 4f);
            timePassed += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    private bool dogIsFarAway()
    {
        return Vector3.Distance(transform.position, dogPosition.Vector3) > 10f;
    }
}
