using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumbers_1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text num1;
    public Text num2;
    public Text Ans1;
    public Text num3;
    public Text num4;
    public Text Ans2;
    public Text equal;
    public Text plus;

    public List<int> easyMathList = new List<int>(); // 
    //public List<char> easyMathListTwo = new List<char>();

    public int randomFirstNumber;
    public int randomSecondNumber;

    int answerOne, answerTwo, answerThree, answerFour, answerFive;
    //int answerTwo, answerThree, answerFour, answerFive;
    public int currentAnswer;
    // Start is called before the first frame update
    void Start()
    {
        DisplayMathProblem();
    }
    private (int, int) GetTwoRandomSum() // Return tuple of two random numbers
    {
        int firstNum = Random.Range(1, 5); // Random integer between 1 and 10
        int nextNum = Random.Range(1, 5); // Ensure the difference is not negative integer

        return (firstNum, nextNum);
    }
    private (int, int, int, int, int) GetDifferentOptions(int firstNum, int nextNum)
    {
        int answer = firstNum + nextNum;
        int firstOption = firstNum;
        int nextOption = nextNum;
        int thirdOption = '+';
        int fourthOption = '=';

        // Shuffle options before returning them
        var options = new List<int>() { answer, firstOption, nextOption, thirdOption, fourthOption };
        int count = options.Count;

        for (int i = 0; i < count - 1; ++i)
        {
            int rand = Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }

        return (options[0], options[1], options[2], options[3], options[4]);
    }
    public void DisplayMathProblem()
    {
        //generate a random number as the first and second numbers
        var nums = GetTwoRandomSum();
        randomFirstNumber = nums.Item1;
        randomSecondNumber = nums.Item2;
        int randomSum = randomFirstNumber + randomSecondNumber;


        var options = GetDifferentOptions(randomFirstNumber, randomSecondNumber);
        answerOne = options.Item1;
        answerTwo = options.Item2;
        answerThree = options.Item3;
        answerFour = options.Item4;
        answerFive = options.Item5;

        num1.text = "" + randomFirstNumber;
        num2.text = "" + randomSecondNumber;
        Ans1.text = "" + randomSum;

        if (answerOne < 10)
        {
            num3.text = "" + answerOne;
        }
        else if (answerOne == 61)
        {
            num3.text = "=";
        }
        else
        {
            num3.text = "+";
        }

        if (answerTwo < 10)
        {
            num4.text = "" + answerTwo;
        }
        else if (answerTwo == 61)
        {
            num4.text = "=";
        }
        else
        {
            num4.text = "+";
        }

        if (answerThree < 10)
        {
            Ans2.text = "" + answerThree;
        }
        else if (answerThree == 61)
        {
            Ans2.text = "=";
        }
        else
        {
            Ans2.text = "+";
        }

        if (answerFour < 10)
        {
            equal.text = "" + answerFour;
        }
        else if (answerFour == 61)
        {
            equal.text = "=";
        }
        else
        {
            equal.text = "+";
        }

        if (answerFive < 10)
        {
            plus.text = "" + answerFive;
        }
        else if (answerFive == 61)
        {
            plus.text = "=";
        }
        else
        {
            plus.text = "+";
        }


    }
}
