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

    private void Update()
    {
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(new Vector3(0, rotation, 0));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * 1000);            
        }
    }

    private void LateUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
    }
}
