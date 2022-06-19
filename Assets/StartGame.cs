using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject humanAndDog;
    [SerializeField] private GameObject cinemachineGameObject;
    [SerializeField] private GameObject menuParticleSystem;
    public void StartGameScene()
    {
        menuParticleSystem.SetActive(false);
        StartCoroutine(PlayAnimation());       
    }

    private IEnumerator PlayAnimation()
    {
        anim.SetTrigger("Start");
        startButton.SetActive(false);
        yield return new WaitForSeconds(8f);
        humanAndDog.SetActive(true);
        gameObject.SetActive(false);
        cinemachineGameObject.SetActive(true);
    }
}
