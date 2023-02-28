using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Math_Addition : MonoBehaviour
{
    public Text firstNumber;
    public Text secondNumber;

    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;

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
        initializeUI();
        DisplayMathProblem();
    }

    public void initializeUI() {
        if (null != rightorwrong_Text) {
            rightorwrong_Text.enabled = false;
        }
    }

    private (int, int) GetTwoRandomSum() // Return tuple of two random numbers that sum to something between 2 and 9
    {
        int firstNum = Random.Range(1, 9); // Random integer between 1 and 8
        int nextNum = Random.Range(1, 10 - firstNum); // Ensure sum is no more than 9

        return (firstNum, nextNum);
    }
    private (int, int, int) GetSumOptions(int firstNum, int nextNum) // Return 3 random options between 1 and 9, one of which is the correct sum
    {
        int answer = firstNum + nextNum;

        if (answer < 2 || answer > 9)
        {
            throw new System.Exception("GetSumOptions received invalid values to sum");
        }

        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        possibilities.Remove(answer); // Ensure only one correct answer offered

        // Get first incorrect option
        int firstOptionIndex = Random.Range(0, possibilities.Count);
        int firstOption = possibilities[firstOptionIndex];

        // Ensure next incorrect option is different from the first one
        possibilities.Remove(firstOption);

        // Get next incorrect option
        int nextOptionIndex = Random.Range(0, possibilities.Count);
        int nextOption = possibilities[nextOptionIndex];

        // Shuffle options before returning them
        var options = new List<int>() { answer, firstOption, nextOption };
        int count = options.Count;
        for (int i = 0; i < count - 1; ++i)
        {
            int rand = Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }

        return (options[0], options[1], options[2]);
    }
    public void DisplayMathProblem()
    {
        //generate a random number as the first and second numbers
        var nums = GetTwoRandomSum();
        randomFirstNumber = nums.Item1;
        randomSecondNumber = nums.Item2;
        int randomSum = randomFirstNumber + randomSecondNumber;

        // Generate options
        var options = GetSumOptions(randomFirstNumber, randomSecondNumber);
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

    public void showResults(bool isCorrectAnswer) {
        if (isCorrectAnswer)
        {
            rightorwrong_Text.enabled = true;
            rightorwrong_Text.color = Color.green;
            rightorwrong_Text.text = ("Correct");
            correctAnswerAudio.Play();

            // Invoke("TurnOffText",1);
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
        initializeUI();
        DisplayMathProblem();
    }

    private void TurnOffText() {
        if (null !=  rightorwrong_Text) {
            rightorwrong_Text.enabled = false;
        }
    }
}


