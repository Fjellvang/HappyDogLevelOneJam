using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exciting : MonoBehaviour
{
    [SerializeField] private IntVariable dogExcitement;
    [SerializeField] private int excitementChange;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dog")
        {
            dogExcitement.Value += excitementChange;
        }
    }
}
