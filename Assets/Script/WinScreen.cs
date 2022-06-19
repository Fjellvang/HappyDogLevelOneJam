using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private IntVariable dogExcitement;
    [SerializeField] private IntVariable bonesCollected;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Image image;

    private void Update()
    {
        if(dogExcitement.Value >= 100 && bonesCollected.Value == 10)
        {
            winScreen.SetActive(true);
            image.color = new Color(1, 1, 1, 0);
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        for (float i = 0; i <= 3f; i += Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
