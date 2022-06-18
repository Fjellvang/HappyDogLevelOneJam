using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcitementBarHandler : MonoBehaviour
{
    [SerializeField] private IntVariable excitement;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.value = excitement.Value;
    }
}
