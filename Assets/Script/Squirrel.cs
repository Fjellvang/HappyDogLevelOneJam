using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource sound;
    [SerializeField] private Rigidbody rb;
    [Range(0.1f, 100f)]
    [SerializeField] private float moveSpeed;

    [SerializeField] private Vector3Variable dogPosition;
    [SerializeField] private IntVariable dogExcitement;
    [SerializeField] private int excitementChange;


    private Coroutine behaviour;
    private bool fleeing;
    private void Start()
    {
        behaviour = StartCoroutine(Roam());
    }

    private void Update()
    {
        if (dogIsClose() && fleeing == false)
        {
            StopCoroutine(behaviour);
            behaviour = StartCoroutine(RunAway());
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

        behaviour = StartCoroutine(Roam());
    }

    private IEnumerator RunAway()
    {
        fleeing = true;
        sound.Play();
        dogExcitement.Value += excitementChange;
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

    private bool dogIsClose()
    {
        return Vector3.Distance(transform.position, dogPosition.Vector3) < 3f;
    }
}
