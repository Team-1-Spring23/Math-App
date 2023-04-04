using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{

    public GameObject Crt_ans;
    public GameObject AnsB;
    public Text Ans;
    public Text num1;
    public Text num2;
    public Button NextButton;
    public GameObject Confetti;


    public float dropdistance;

    public bool islocked;

    Vector2 objectInitPos;


    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = AnsB.transform.position;
    }
    public void DragObject()
    {
        if (!islocked)
        {
            AnsB.transform.position = Input.mousePosition; // To move with mouse position
        }
    }
    public void DropObject()
    {
        int a = Convert.ToInt32(num1.text);
        int b = Convert.ToInt32(num2.text);
        int c = Convert.ToInt32(Ans.text);
        float Distance = Vector3.Distance(AnsB.transform.position, Crt_ans.transform.position);
        if (c == a + b) // Check to idenfity correct answer
        {
            islocked = true;
            AnsB.transform.position = Crt_ans.transform.position; // Correct answer will be fixed in answer panel
            OnMouseUp();
            Confetti.gameObject.SetActive(true);
            NextButton.gameObject.SetActive(true);
        }
        else
        {
            islocked = false;
            AnsB.transform.position = objectInitPos; // Worng answer will be pulled to it's original position
            NextButton.gameObject.SetActive(false);

        }
    }
    public void OriginalPosition()
    {
        AnsB.transform.position = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // Load the confetti scene
        SceneManager.LoadScene("Confetti");
    }

}