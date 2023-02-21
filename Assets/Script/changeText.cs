using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeText : MonoBehaviour
{
    public GameObject myText;
    // Start is called before the first frame update
    void Start()
    {
        myText.GetComponent<Text>().text = "Changed!";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
