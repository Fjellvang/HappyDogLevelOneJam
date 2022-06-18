using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HalfwayPointScript : MonoBehaviour
{
    public Transform Dog;
    public Transform Human;
    public float offSetMultiplier = -1.5f;
    public Vector3 offSet = new Vector3(0, 5f, 0);

    // Update is called once per frame
    void Update()
    {
        var delta = Dog.position - Human.position;
        transform.position = offSet + Human.position + delta * offSetMultiplier;
    }
}
