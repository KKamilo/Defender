using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutear : MonoBehaviour
{
    int on_Off= 1;
    public void Silencio()
    {
        if(on_Off==1)
        {
            GameManager.mucica.Pause();
            on_Off=0;
        }
        else
        {
            GameManager.mucica.Play();
            on_Off=1;
        }

    }

}
