using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class backButton : MonoBehaviour
{
   [SerializeField] private string screen_name;
   public void backButtonFns()
   {
    SceneManager.LoadScene(screen_name);
   }
}
