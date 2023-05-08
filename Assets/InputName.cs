using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InputName : MonoBehaviour
{
    public TMP_InputField nameField;
    // Start is called before the first frame update
    void Start()
    {
        nameField.onSubmit.AddListener(nextScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void nextScreen(string name)
    {
        //Debug.Log(name);
        SceneManager.LoadScene("Loading_bar");
    }
}