using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadyDogReaction : MonoBehaviour
{
    [SerializeField] private Vector3Variable dogPosition;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Image image;
    private bool dogSpotted;

    private void Update()
    {
        if (dogIsClose() && !dogSpotted)
        {
            dogSpotted = true;
            anim.SetTrigger("Scream");
            loseScreen.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    private bool dogIsClose()
    {
        return Vector3.Distance(transform.position, dogPosition.Vector3) < 3f;
    }
    private IEnumerator FadeIn()
    {
        image.color = new Color(1, 1, 1, 0);
        for (float i = 0; i <= 8f; i += Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
