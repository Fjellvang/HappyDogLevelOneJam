using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject startButton;
    public void StartGameScene()
    {
        StartCoroutine(PlayAnimation());       
    }

    private IEnumerator PlayAnimation()
    {
        anim.SetTrigger("Start");
        startButton.SetActive(false);
        yield return new WaitForSeconds(8f);
        gameObject.SetActive(false);
    }
}