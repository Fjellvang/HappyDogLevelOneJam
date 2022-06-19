using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void StartGameScene()
    {
        anim.SetTrigger("Start");
    }
}
