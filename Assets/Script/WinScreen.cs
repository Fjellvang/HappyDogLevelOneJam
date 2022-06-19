using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private IntVariable dogExcitement;
    [SerializeField] private IntVariable bonesCollected;

    private void Update()
    {
        if(dogExcitement.Value == 100 && bonesCollected.Value == 10)
        {
            
        }
    }
}
