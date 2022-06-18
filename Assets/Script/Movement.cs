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

    private void Update()
    {
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(new Vector3(0, rotation, 0));
        rb.AddForce(transform.forward * moveSpeed * (1 + excitement.Value / 25), ForceMode.Impulse);            
    }

    private void LateUpdate()
    {
        if (savedPosition == null)
        {
            return;
        }
        savedPosition.Vector3 = transform.position;
        //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * moveSpeed);
    }
}
