using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonesText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private IntVariable bonesCollected;

    private void Start()
    {
        bonesCollected.Value = 0;
    }

    private void Update()
    {
        text.SetText(bonesCollected.Value + " / 10");
    }
}
