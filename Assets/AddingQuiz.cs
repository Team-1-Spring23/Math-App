using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AddingQuiz : MonoBehaviour
{
    // Access HelperFunctions
    private HelperFunctions helperFunctions;
    public int buttonClickCount = 0;

    public Text firstNumber;
    public Text secondNumber;

    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;
    public Button nextButton; // button to go to next problem
    public GameObject RandomAddGameObjects; // parent of all the game objects for this game

    public ParticleSystem pSystem;

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne;
    int answerTwo;
    int answerThree;
    public int correctAnswer;
    public Text rightorwrong_Text;

    public AudioSource correctAnswerAudio;
    public AudioSource incorrectAnswerAudio;

    public GameObject correctAnswerSprite;

    public GameObject answer1;
    public GameObject answer2;
    public GameObject answer3;

    Vector2 frstpos1;
    Vector2 frstpos2;
    Vector2 frstpos3;

    public void Start()
    {
        helperFunctions = FindObjectOfType<HelperFunctions>();
        frstpos1 = answer1.transform.position;
        frstpos2 = answer2.transform.position;
        frstpos3 = answer3.transform.position;
        DisplayMathProblem();
    }

    public void DisplayMathProblem()
    {
        rightorwrong_Text.enabled = false; // disable text displaying if an answer was correct/incorrect

        // Get two random numbers that sum to something between 2 and 9
        var nums = helperFunctions.GetTwoRandomSum(9);
        randomFirstNumber = nums.Item1;
        randomSecondNumber = nums.Item2;
        int randomSum = randomFirstNumber + randomSecondNumber;

        // Generate options
        var options = helperFunctions.GetSumOptions(randomFirstNumber, randomSecondNumber, 9);
        answerOne = options.Item1;
        answerTwo = options.Item2;
        answerThree = options.Item3;

        // Update text of all items
        firstNumber.text = "" + randomFirstNumber;
        secondNumber.text = "" + randomSecondNumber;
        answer1Button.GetComponentInChildren<Text>().text = "" + answerOne;
        answer2Button.GetComponentInChildren<Text>().text = "" + answerTwo;
        answer3Button.GetComponentInChildren<Text>().text = "" + answerThree;

        correctAnswer = randomSum;
    }
    public void showResults(bool isCorrectAnswer)
    {
        if (isCorrectAnswer)
        {
            rightorwrong_Text.enabled = true;
            rightorwrong_Text.color = Color.green;
            rightorwrong_Text.text = ("Correct");
            correctAnswerAudio.Play();
            pSystem.Clear();
            pSystem.Play();
            nextButton.gameObject.SetActive(true);
            correctAnswerSprite.gameObject.SetActive(true);
        }
        else
        {
            rightorwrong_Text.enabled = true;
            rightorwrong_Text.color = Color.red;
            rightorwrong_Text.text = ("Try again");
            Invoke("TurnOffText", 1);
            incorrectAnswerAudio.Play();
        }
    }
    public void refreshPuzzle()
    {
        //Just commenting this out for the demo
        buttonClickCount++;
        answer1.transform.position = frstpos1;
        answer2.transform.position = frstpos2;
        answer3.transform.position = frstpos3;
        nextButton.gameObject.SetActive(false); // hide until another correct answer
        correctAnswerSprite.gameObject.SetActive(false); // same
        StartCoroutine(helperFunctions.TransitionObject(RandomAddGameObjects));
        Invoke("DisplayMathProblem", 1); // Display new problem with 1 second delay (so objects are offscreen when it happens)
       // confetti scene will appear after 3 clicks of NEXT button
        if (buttonClickCount == 3) 
        {
            ShowConfettiScene();
            buttonClickCount = 0;
        }
    }

    private void ShowConfettiScene()
    {
        SceneManager.LoadScene("Confetti");

    }

    private void TurnOffText()
    {
        if (null != rightorwrong_Text)
        {
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