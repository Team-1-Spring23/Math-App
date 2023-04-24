using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dragHandlerScript : MonoBehaviour
{

    public GameObject NumberOne;
    public GameObject NumberTwo;
    public GameObject Plus;
    public GameObject Equal;
    public GameObject Answer;
    public Button nextButton;

    public Text NumberOneText;
    public Text NumberTwoText;
    public Text PlusText;
    public Text EqualText;
    public Text AnswerText;

    static bool EqualLocked;
    static bool NumberOneLocked;
    static bool NumberTwoLocked;
    static bool AnswerLocked;
    static bool PlusLocked;


    public GameObject NumberOnePanel;
    public GameObject NumberTwoPanel;
    public GameObject PlusPanel;
    public GameObject EqualPanel;
    public GameObject AnswerPanel;
    static int buttonClickCount = 0;



    public Text NumberOneButtonText, NumberTwoButtonText, PlusButtonText, EqualButtonText, AnswerButtonText;

    const float PROXIMITY_SENSITIVITY = 90.01f;

    private Text CurrentTextLoc;
    private GameObject panelObject;
    public Vector2 NumberOneInitialPos, NumberTwoIntialPos, PlusInitialPos, EqualInitialPos, AnswerInitialPos;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Starting");
        NumberOneInitialPos = NumberOne.transform.position;
        NumberTwoIntialPos = NumberTwo.transform.position;
        PlusInitialPos = Plus.transform.position;
        EqualInitialPos = Equal.transform.position;
        AnswerInitialPos = Answer.transform.position;

        nextButton.gameObject.SetActive(false);

        //nextButton.onClick.AddListener(onMouseClick);

    }

    public void restartPuzzle()
    {
        buttonClickCount++;

        if (buttonClickCount == 2)
        {
            ShowConfettiScene();
            buttonClickCount = 0;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void ShowConfettiScene()
    {
        SceneManager.LoadScene("Confetti");
    }

    //private IEnumerator RestartPuzzleCoroutine()
    //{
    //    yield return new WaitForSeconds(0.7f); // wait for 1 second
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    //}

    public void DragObject(GameObject obj)
    {
        //obj.transform.position = Input.mousePosition;
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    private (Text, GameObject) WhichTextIsNearToThisObject(GameObject obj)
    {
        if (Vector3.Distance(obj.transform.position, NumberOneText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            //Debug.Log("NumberOneText" + NumberOneText + "NumberOnePanel" + NumberOnePanel);
            return (NumberOneText, NumberOnePanel);
        }

        if (Vector3.Distance(obj.transform.position, NumberTwoText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            //Debug.Log("NumberOneText" + NumberTwoText + "NumberOnePanel" + NumberTwoPanel);
            return (NumberTwoText, NumberTwoPanel);
        }

        if (Vector3.Distance(obj.transform.position, EqualText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (EqualText, EqualPanel);
        }

        if (Vector3.Distance(obj.transform.position, PlusText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (PlusText, PlusPanel);
        }

        if (Vector3.Distance(obj.transform.position, AnswerText.transform.position) <= PROXIMITY_SENSITIVITY)
        {
            return (AnswerText, AnswerPanel);
        }

        //if it reaches here it means that, I am in empty space
        return (null, null);
    }


    /*
     * This functions job is if it finds the right match i.e
     * If the button is dropped on to right panel then it must
     * return true else for anyother case which is either null 
     * or wrong object then return false
     */
    public bool AreObjectsNear(GameObject Obj, Text ButtonText)
    {
        try
        {
            //Debug.Log("Sample1");
            Text TextTxt;

            //This functions job is to give if the button is around an empty space
            //or near an object
            var ret = WhichTextIsNearToThisObject(Obj);
            TextTxt = ret.Item1;
            //Debug.Log(TextTxt);
            panelObject = ret.Item2;
            //Debug.Log(panelObject);

            //If the nearby panel is empty or wrong return false
            if (TextTxt == null || ButtonText == null || (TextTxt.text != ButtonText.text))
            {
                //Debug.Log("TextTxt.text"+TextTxt.text+"ButtonText.text"+ ButtonText.text);
                return false;
            }

            //if it enter here's it means that the object is in the right place
            CurrentTextLoc = TextTxt;
            return true;
            //Debug.Log("Sample3");
        }

        catch (Exception e)
        {
            Debug.Log(e.ToString());
            return false;
        }

    }

    private void check_if_all_objects_are_locked()
    {
        Debug.Log("status " + EqualLocked + NumberOneLocked + NumberTwoLocked + AnswerLocked + PlusLocked);

        if (EqualLocked && NumberOneLocked && NumberTwoLocked && AnswerLocked && PlusLocked)
        {
            Debug.Log("All Locked");
            EqualLocked = NumberOneLocked = NumberTwoLocked = AnswerLocked = PlusLocked = false;

            NumberOne.transform.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
            //NumberOneButtonText.GetComponent<Image>().material.color = Color.red;
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

            NumberTwo.transform.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
            //NumberTwoButtonText.GetComponent<Image>().material.color = Color.green;
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

            Plus.transform.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
            //PlusButtonText.GetComponent<Image>().material.color = Color.green;
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

            Answer.transform.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
            //AnswerButtonText.GetComponent<Image>().material.color = Color.green;
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);

            Equal.transform.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
            //EqualButtonText.GetComponent<Image>().material.color = Color.green;
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);



            nextButton.gameObject.SetActive(true);

            //This is the code to make the panel text transparent after drag and dropping

            NumberOneButtonText.color = new Color(1f, 1f, 1f, 0f);
            NumberTwoButtonText.color = new Color(1f, 1f, 1f, 0f);
            AnswerButtonText.color = new Color(1f, 1f, 1f, 0f);
            PlusButtonText.color = new Color(1f, 1f, 1f, 0f);
            EqualButtonText.color = new Color(1f, 1f, 1f, 0f);

            // this code to move the numbers to the middle of the screen

            //NumberOneText.transform.position = new Vector2((Screen.width / 2f) - 225, Screen.height / 2f);
            //NumberOneText.color = new Color(1f, 1f, 1f, 1f);

            //PlusText.transform.position = new Vector2((Screen.width / 2f) - 125, Screen.height / 2f);
            //PlusText.color = new Color(1f, 1f, 1f, 1f);

            //NumberTwoText.transform.position = new Vector2((Screen.width / 2f), Screen.height / 2f);
            //NumberTwoText.color = new Color(1f, 1f, 1f, 1f);

            //EqualText.transform.position = new Vector2((Screen.width / 2f) + 125, Screen.height / 2f);
            //EqualText.color = new Color(1f, 1f, 1f, 1f);

            //AnswerText.transform.position = new Vector2((Screen.width / 2f) + 225, Screen.height / 2f);
            //AnswerText.color = new Color(1f, 1f, 1f, 1f);

        }
    }


    /*    private void onMouseClick()
        {
        }
    */
    public void DropObject(GameObject obj)
    {
        if (obj == NumberOne)
        {
            // Debug.Log("Sample");

            if (AreObjectsNear(obj, NumberOneButtonText))
            {
                /*if it enters here it means that we need to lock this object
                 * and make the pannel, button disappear
                 */

                //This will lock the position of button
                obj.transform.position = CurrentTextLoc.transform.position;
                Debug.Log(CurrentTextLoc.transform.position);

                //Setting a global variable to indicate that the number one is blocked
                NumberOneLocked = true;
                Debug.Log("NumberOneLocked");

                //Change the button and panel transperency 
                NumberOne.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                NumberOne.gameObject.SetActive(false);
                // check if all objects are locked or not
                check_if_all_objects_are_locked();

            }
            else
            {
                //If it enters here it means that return back to same position
                obj.transform.position = NumberOneInitialPos;
            }
            return;
        }

        if (obj == NumberTwo)
        {
            if (AreObjectsNear(obj, NumberTwoButtonText))
            {
                obj.transform.position = CurrentTextLoc.transform.position;
                NumberTwoLocked = true;
                Debug.Log("NumberTwoLocked");

                NumberTwo.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                NumberTwo.gameObject.SetActive(false);
                check_if_all_objects_are_locked();
            }
            else
            {
                obj.transform.position = NumberTwoIntialPos;
            }
            return;
        }

        if (obj == Answer)
        {
            if (AreObjectsNear(obj, AnswerButtonText))
            {
                obj.transform.position = CurrentTextLoc.transform.position;
                AnswerLocked = true;
                Debug.Log("AnswerLocked");

                Answer.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                Answer.gameObject.SetActive(false);
                check_if_all_objects_are_locked();
            }
            else
            {
                obj.transform.position = AnswerInitialPos;
            }
            return;
        }

        if (obj == Plus)
        {
            if (AreObjectsNear(obj, PlusButtonText))
            {
                obj.transform.position = CurrentTextLoc.transform.position;
                PlusLocked = true;
                Debug.Log("PlusLocked");

                //change button transperency 
                Plus.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                Plus.gameObject.SetActive(false);
                check_if_all_objects_are_locked();
            }
            else
            {
                obj.transform.position = PlusInitialPos;
            }
            return;
        }

        if (obj == Equal)
        {
            if (AreObjectsNear(obj, EqualButtonText))
            {
                obj.transform.position = CurrentTextLoc.transform.position;
                EqualLocked = true;
                Debug.Log("EqualLocked");

                Equal.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                panelObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                Equal.gameObject.SetActive(false);
                check_if_all_objects_are_locked();
            }
            else
            {
                obj.transform.position = EqualInitialPos;
            }
            return;
        }

    }
}