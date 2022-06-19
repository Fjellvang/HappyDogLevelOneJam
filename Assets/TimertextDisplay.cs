using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimertextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        text.SetText(((int)Time.timeSinceLevelLoad).ToString());
    }
}
