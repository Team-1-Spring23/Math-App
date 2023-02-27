using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PracticeUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]private string practiceUI = "practiceUI";
    
    public void practiceButton(){
       
       SceneManager.LoadScene(practiceUI);
 
    }
}
