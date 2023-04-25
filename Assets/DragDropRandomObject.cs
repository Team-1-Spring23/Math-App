using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragDropRandomObject : MonoBehaviour
{

    public GameObject Crt_ans;
    public GameObject AnsB;
    public Text Ans;
    public Text num1;
    public Text num2;
    public Button NextButton;
    private GameObject panelObject;
    static int Count = 0;
    private HelperFunctions helperFunctions;
    public GameObject RandomAddGameObjects; // parent of all the game objects for this game




    private Objects_Math_Addition Objects_Math_Addition; // access Objects_Math_Addition functions

    public float dropdistance;

    public bool islocked;

    Vector2 objectInitPos;


    // Start is called before the first frame update
    void Start()
    {
        Objects_Math_Addition = FindObjectOfType<Objects_Math_Addition>();
        objectInitPos = AnsB.transform.position;
    }
    public void DragObject()
    {
        if (!islocked)
        {
            //AnsB.transform.position = Input.mousePosition; // To move with mouse position
            var screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f; //distance of the plane from the camera
            AnsB.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
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
            Objects_Math_Addition.showResults(true); // show correct answer
            //AnsB.transform.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
            AnsB.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            AnsB.gameObject.SetActive(false);
        }
        else
        {
            islocked = false;
            AnsB.transform.position = objectInitPos; // Worng answer will be pulled to it's original position
            Objects_Math_Addition.showResults(false); // show incorrect answer
        }
    }
    public void restartPuzzle()
    {
        Count++;
        if (Count == 2)
        {
            SceneManager.LoadScene("Fun_Confetti");
            Count = 0;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}