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

int firstNumberInProblem;
int secondNumberInProblem;
int answerOne;
int answerTwo;
int answerThree;
int displayRandomAnswer;
int randomAnswerPlacement;
public int currentAnswer;
public Text rightorwrong;

private void Start()
{
    DisplayMathProblem();
}
public void DisplayMathProblem()
{
    //generate a random number as the first and second numbers
    randomFirstNumber = Random.Range(0,easyMathList.Count + 1);
    randomSecondNumber = Random.Range(0,easyMathList.Count + 1);
//assigning first and second number
firstNumberInProblem = randomFirstNumber;
secondNumberInProblem = randomSecondNumber;
//addition
answerOne = firstNumberInProblem + secondNumberInProblem;
displayRandomAnswer = Random.Range(0,2);
if(displayRandomAnswer == 0)
{
    answerTwo = answerOne + Random.Range(1,5);
}
else
{
    answerThree = answerOne - Random.Range(1,5);
}

firstNumber.text = "" + firstNumberInProblem;
secondNumber.text = "" + secondNumberInProblem;
randomAnswerPlacement = Random.Range(0,2);
if(randomAnswerPlacement == 0)
{
    answer1.text = "" + answerOne;
    answer2.text = "" + answerTwo;
    answer3.text = "" + answerThree;
    currentAnswer = 0;
}
else
{
    answer1.text = "" + answerTwo;
    answer2.text = "" + answerOne;
    answer3.text = "" + answerThree;
    currentAnswer = 1;
}
}
    }    
    

