using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiveAI : MonoBehaviour
{
    public TextMeshProUGUI liveText;


    void Update()
    {
        liveText.text= "Vidas = "+ Currency.lives;
    }
}
