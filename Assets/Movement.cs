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

    [SerializeField] Vector3Variable savedPosition;

    private void Update()
    {
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(new Vector3(0, rotation, 0));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * moveSpeed, ForceMode.Impulse);            
        }
    }

    private void LateUpdate()
    {
        savedPosition.Vector3 = transform.position;
        //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
    }
}
