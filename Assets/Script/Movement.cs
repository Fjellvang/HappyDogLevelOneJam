using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [Range(0.1f, 100f)]
    [SerializeField] private float moveSpeed;
    [Range(0.1f, 10f)]
    [SerializeField] private float rotationSpeed;
    private float rotation;
    [SerializeField] private Animator anim;

    [SerializeField] private Vector3Variable savedPosition;
    [SerializeField] private IntVariable excitement;
    [SerializeField] private float excitementStrength;

    private void Update()
    {
        rotation = Input.GetAxis("Horizontal") * rotationSpeed * excitementStrength;
        transform.Rotate(new Vector3(0, rotation, 0));

        float speed = excitement.Value * excitementStrength;
        anim.SetFloat("Speed", speed);
        Debug.Log(speed);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);            
    }

    private void LateUpdate()
    {
        if (savedPosition == null)
        {
            return;
        }
        savedPosition.Vector3 = transform.position;
    }
}
