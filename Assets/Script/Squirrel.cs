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

    private Coroutine roaming;

    private void Start()
    {
        roaming = StartCoroutine(Roam());
    }

    private void Update()
    {
        if (!dogIsFarAway())
        {
            StopCoroutine(roaming);
            StartCoroutine(RunAway());
        }
    }

    private IEnumerator Roam()
    {
        anim.SetBool("Run", false);
        float wait = UnityEngine.Random.Range(1f, 2f);
        yield return new WaitForSeconds(wait);
        transform.Rotate(new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f), Space.World);
        yield return new WaitForSeconds(wait);
        
        anim.SetBool("Run", true);

        float timePassed = 0;
        float endTime = 5;
        while (timePassed < endTime)
        {
            
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
            timePassed += Time.deltaTime;
            yield return null;
        }

        roaming = StartCoroutine(Roam());
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
