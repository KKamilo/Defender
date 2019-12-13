using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public AudioSource musica;
    public string levelToLoad = "Referens";
    void Start ()
    {
        musica.GetComponent<AudioSource>();
    }
    public void Play()
    {
        musica.Stop();
        SceneManager.LoadScene(levelToLoad);
    }

}
