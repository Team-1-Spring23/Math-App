using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]private string puzzle_scene ="Random Addition";
    
    public void puzzleButton(){
       
       SceneManager.LoadScene(puzzle_scene);
 
    }
}
