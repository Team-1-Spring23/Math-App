using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objects_Math_Addition : MonoBehaviour
{
    // Access HelperFunctions
    private HelperFunctions helperFunctions;

    public Text firstNumber;
    public Text secondNumber;

    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;
    public Button nextButton; // button to go to next problem

    public Sprite ObjectSprite1;
    public Sprite ObjectSprite2;
    public Sprite ObjectSprite3;
    public GameObject Left1Object;
    public GameObject Left2Object;
    public GameObject Left3Object;
    public GameObject Left4Object;
    public GameObject Right1Object;
    public GameObject Right2Object;
    public GameObject Right3Object;
    public GameObject Right4Object;
    public GameObject RandomAddGameObjects; // parent of all the game objects for this game

    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne;
    int answerTwo;
    int answerThree;
    public int correctAnswer;
    public Text rightorwrong_Text;

    public AudioSource correctAnswerAudio;
    public AudioSource incorrectAnswerAudio;


    public void Start()
    {
        helperFunctions = FindObjectOfType<HelperFunctions>();
        DisplayMathProblem();
    }

    public void updateObjectSprites()
    {
        int objNum = Random.Range(1, 4); // randomly select sprite 1, 2, or 3
        Sprite newSprite = ObjectSprite1;
        if (objNum == 1)
        {
            newSprite = ObjectSprite1;
        }
        else if (objNum == 2)
        {
            newSprite = ObjectSprite2;
        }
        else if (objNum == 3)
        {
            newSprite = ObjectSprite3;
        }

        // left side
        if (randomFirstNumber == 1)
        {
            GameObject obj = Left1Object.transform.GetChild(0).gameObject;
            obj.GetComponentInChildren<Image>().sprite = newSprite;
            Left1Object.SetActive(true);
        }
        else if (randomFirstNumber == 2)
        {
            GameObject obj1 = Left2Object.transform.GetChild(0).gameObject;
            GameObject obj2 = Left2Object.transform.GetChild(1).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            Left2Object.SetActive(true);
        }
        else if (randomFirstNumber == 3)
        {
            GameObject obj1 = Left3Object.transform.GetChild(0).gameObject;
            GameObject obj2 = Left3Object.transform.GetChild(1).gameObject;
            GameObject obj3 = Left3Object.transform.GetChild(2).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            Left3Object.SetActive(true);
        }
        else if (randomFirstNumber == 4)
        {
            GameObject obj1 = Left4Object.transform.GetChild(0).gameObject;
            GameObject obj2 = Left4Object.transform.GetChild(1).gameObject;
            GameObject obj3 = Left4Object.transform.GetChild(2).gameObject;
            GameObject obj4 = Left4Object.transform.GetChild(3).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            Left4Object.SetActive(true);
        }

        // right side
        if (randomSecondNumber == 1)
        {
            GameObject obj = Right1Object.transform.GetChild(0).gameObject;
            obj.GetComponentInChildren<Image>().sprite = newSprite;
            Right1Object.SetActive(true);
        }
        else if (randomSecondNumber == 2)
        {
            GameObject obj1 = Right2Object.transform.GetChild(0).gameObject;
            GameObject obj2 = Right2Object.transform.GetChild(1).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            Right2Object.SetActive(true);
        }
        else if (randomSecondNumber == 3)
        {
            GameObject obj1 = Right3Object.transform.GetChild(0).gameObject;
            GameObject obj2 = Right3Object.transform.GetChild(1).gameObject;
            GameObject obj3 = Right3Object.transform.GetChild(2).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            Right3Object.SetActive(true);
        }
        else if (randomSecondNumber == 4)
        {
            GameObject obj1 = Right4Object.transform.GetChild(0).gameObject;
            GameObject obj2 = Right4Object.transform.GetChild(1).gameObject;
            GameObject obj3 = Right4Object.transform.GetChild(2).gameObject;
            GameObject obj4 = Right4Object.transform.GetChild(3).gameObject;
            obj1.GetComponentInChildren<Image>().sprite = newSprite;
            obj2.GetComponentInChildren<Image>().sprite = newSprite;
            obj3.GetComponentInChildren<Image>().sprite = newSprite;
            obj4.GetComponentInChildren<Image>().sprite = newSprite;
            Right4Object.SetActive(true);
        }
    }

    public void DisplayMathProblem()
    {
        rightorwrong_Text.enabled = false; // disable text displaying if an answer was correct/incorrect

        // Get two random numbers that sum to something between 2 and 5
        var nums = helperFunctions.GetTwoRandomSum(5);
        randomFirstNumber = nums.Item1;
        randomSecondNumber = nums.Item2;
        int randomSum = randomFirstNumber + randomSecondNumber;

        // Generate options
        var options = helperFunctions.GetSumOptions(randomFirstNumber, randomSecondNumber, 5);
        answerOne = options.Item1;
        answerTwo = options.Item2;
        answerThree = options.Item3;

        // Update text of all items
        firstNumber.text = "" + randomFirstNumber;
        secondNumber.text = "" + randomSecondNumber;
        answer1Button.GetComponentInChildren<Text>().text = "" + answerOne;
        answer2Button.GetComponentInChildren<Text>().text = "" + answerTwo;
        answer3Button.GetComponentInChildren<Text>().text = "" + answerThree;

        // Display corresponding objects
        updateObjectSprites();

        correctAnswer = randomSum;
    }

    public void showResults(bool isCorrectAnswer) {
        if (isCorrectAnswer)
        {
            rightorwrong_Text.enabled = true;
            rightorwrong_Text.color = Color.green;
            rightorwrong_Text.text = ("Correct");
            correctAnswerAudio.Play();
            nextButton.gameObject.SetActive(true);
        }
        else
        {
            rightorwrong_Text.enabled = true;
            rightorwrong_Text.color = Color.red;
            rightorwrong_Text.text = ("Try again");
            Invoke("TurnOffText",1);
            incorrectAnswerAudio.Play();
        }
    }

    public void refreshPuzzle() {
        nextButton.gameObject.SetActive(false); // hide until another correct answer
        // now hide all objects
        Left1Object.SetActive(false);
        Left2Object.SetActive(false);
        Left3Object.SetActive(false);
        Left4Object.SetActive(false);
        Right1Object.SetActive(false);
        Right2Object.SetActive(false);
        Right3Object.SetActive(false);
        Right4Object.SetActive(false);
        // animated transition
        StartCoroutine(helperFunctions.TransitionObject(RandomAddGameObjects));
        Invoke("DisplayMathProblem", 1); // Display new problem with 1 second delay (so objects are offscreen when it happens)
    }

    private void TurnOffText() {
        if (null !=  rightorwrong_Text) {
            rightorwrong_Text.enabled = false;
        }
    }

    // These functions display whether the corresponding button contains the correct answer, and are called on click
    // Todo: Called when dragged and dropped into the correct location, instead of on click
    public void ButtonAnswer1()
    {
        bool isButton1Correct = answer1Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
        showResults(isButton1Correct);
    }

    public void ButtonAnswer2()
    {
        bool isButton2Correct = answer2Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
        showResults(isButton2Correct);
    }

    public void ButtonAnswer3()
    {
        bool isButton3Correct = answer3Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
        showResults(isButton3Correct);
    }
}


