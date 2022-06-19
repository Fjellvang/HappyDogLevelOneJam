using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [SerializeField] private IntVariable bonesCollected;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dog")
        {
            bonesCollected.Value += 1;
            Destroy(gameObject);
        }
    }
}
