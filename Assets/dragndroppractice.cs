using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.EventSystems;


public class dragndroppractice : MonoBehaviour
{

       // public GameObject panel;
    // public GameObject buttons;
     public GameObject Crt_ans;
     public GameObject AnsB;
     public Text Ans;
     public Text num1;
     public Text num2;
    
    // public Button NextButton;

     public float dropdistance;

     public bool islocked;
    // public int[] buttons;
    // public int[] buttonstext;

    Vector2 objectInitPos;

    // Start is called before the first frame update
    void Start()
    {

         //panel = GameObject.Find("Buttons_Panel");
         //buttons=panel.GetComponentInChildren<Button>();         
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
    //        NextButton.gameObject.SetActive(true);
         }
         else
         {
             islocked = false;
             objectInitPos = AnsB.transform.position;   // Worng answer will be pulled to it's original position             
    //         NextButton.gameObject.SetActive(false);

        }
    }
     public void OriginalPosition()
     {
         AnsB.transform.position = Input.mousePosition;
    }

}
