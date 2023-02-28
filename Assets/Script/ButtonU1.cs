using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonU1 : MonoBehaviour
{
  [SerializeField] private string home_screen = "home_screen";
   public void NewGameButton()
   {
    SceneManager.LoadScene(home_screen);
   }
}
