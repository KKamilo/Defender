using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverIA;
    public static AudioSource mucica;
    public  AudioSource sonido;

    void Start ()
    {
        mucica= GetComponent<AudioSource>();
        gameIsOver= false;
        mucica=sonido;
    }
    void Update()
    {
        if (gameIsOver)return;

        if(Input.GetKeyDown("f"))
        EndGame();

        if (Currency.lives<=0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver= true;
        mucica.Stop();
        gameOverIA.SetActive(true);
    }
}
