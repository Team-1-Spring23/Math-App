using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Math_Addition : MonoBehaviour
{
    public Text firstNumber;
    public Text secondNumber;
    public Text answer1;
    public Text answer2;
    public Text answer3;

    public List<int> easyMathList = new List<int>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne;
    int answerTwo;
    int answerThree;
    public int currentAnswer;
    public Text rightorwrong;

    private void Start()
    {
        DisplayMathProblem();
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
        answer1.text = "" + answerOne;
        answer2.text = "" + answerTwo;
        answer3.text = "" + answerThree;

        // Set which option is the correct answer (counting from 0)
        currentAnswer = 0;
        if (answerTwo == randomSum)
        {
            currentAnswer = 1;
        } else if (answerThree == randomSum)
        {
            currentAnswer = 2;
        }
    }
}


