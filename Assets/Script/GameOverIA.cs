using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverIA : MonoBehaviour
{
   
   public void Retry()
   {
      SceneManager.LoadScene (1); 
   }
   public void Menu()
   {
      SceneManager.LoadScene (0); 
   }
}
