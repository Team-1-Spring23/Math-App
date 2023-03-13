using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objects_Math_Addition : MonoBehaviour
{
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
    public GameObject Right1Object;
    public GameObject Right2Object;
    public GameObject Right3Object;
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
        initializeUI();
        DisplayMathProblem();
    }

    public void initializeUI() {
        if (null != rightorwrong_Text) {
            rightorwrong_Text.enabled = false;
        }
    }

    private (int, int) GetTwoRandomSum() // Return tuple of two random numbers that sum to something between 2 and 5
    {
        int firstNum = Random.Range(1, 3); // Random integer between 1 and 3
        int nextNum = Random.Range(1, 5 - firstNum); // Ensure sum is no more than 5

        return (firstNum, nextNum);
    }
    private (int, int, int) GetSumOptions(int firstNum, int nextNum) // Return 3 random options between 1 and 5, one of which is the correct sum
    {
        int answer = firstNum + nextNum;

        if (answer < 2 || answer > 5)
        {
            throw new System.Exception("GetSumOptions received invalid values to sum");
        }

        var possibilities = new List<int>() { 1, 2, 3, 4, 5 };
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

        // Display corresponding objects
        GameObject obj = Left1Object.transform.GetChild(0).gameObject;
        Left1Object.SetActive(true);
        obj.GetComponentInChildren<Image>().sprite = ObjectSprite1;

        correctAnswer = randomSum;
    }


    public void ButtonAnswer1()
    {
        Debug.Log(34);
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
        StartCoroutine(NewProblem());
    }

    private IEnumerator NewProblem()
    {
        Vector3 originalPos = RandomAddGameObjects.transform.position;
        Vector3 leftOffScreen = originalPos + new Vector3(-1 * Screen.width, 0, 0);
        Vector3 rightOffScreen = originalPos + new Vector3(Screen.width, 0, 0);
        float elapsedTime = 0;
        int moveSpeed = 8;

        while (elapsedTime < 1)
        {
            RandomAddGameObjects.transform.position = Vector3.Lerp(RandomAddGameObjects.transform.position, leftOffScreen, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RandomAddGameObjects.transform.position = rightOffScreen;
        initializeUI();
        DisplayMathProblem();

        while (elapsedTime < 2)
        {
            RandomAddGameObjects.transform.position = Vector3.Lerp(RandomAddGameObjects.transform.position, originalPos, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        RandomAddGameObjects.transform.position = originalPos; // ensure end at original position since Lerp is inexact

        yield return null;
    }

    private void TurnOffText() {
        if (null !=  rightorwrong_Text) {
            rightorwrong_Text.enabled = false;
        }
    }
}


