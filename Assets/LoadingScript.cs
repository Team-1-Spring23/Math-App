using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public GameObject LoadBarFill;
    private Vector3 scaleChange = new Vector3(0.5f,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadBarFill.transform.localScale += scaleChange;
        if (LoadBarFill.transform.localScale.x >= 640)
        {
            // Done loading
            SceneManager.LoadScene("home_screen");
        }
    }
}
