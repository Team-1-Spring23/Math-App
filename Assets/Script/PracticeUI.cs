using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PracticeUI : MonoBehaviour
{
    [SerializeField]private string practiceUI = "practiceUI";
    
    public void practiceButton(){
       
       SceneManager.LoadScene(practiceUI);
 
    }
}
