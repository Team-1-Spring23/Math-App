using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class shopButton : MonoBehaviour
{
  [SerializeField] private string store_page = "store_page";
   public void NewGameButton()
   {
    SceneManager.LoadScene(store_page);
   }
}
