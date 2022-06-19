using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [SerializeField] private IntVariable bonesCollected;
    [SerializeField] private AudioSource celebrationSound;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dog")
        {
            celebrationSound.Play();
            bonesCollected.Value += 1;
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(gameObject, 4f);
        }
    }
}
