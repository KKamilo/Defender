using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int starMoney= 300;
    public static int moneda;
    public static int lives;
    public int startLives=20;
    void Start()
    {
        lives= startLives;
        moneda= starMoney;
    }
}
