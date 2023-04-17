using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AdditionPractice : MonoBehaviour
{


    public Text firstNumber;
    public Text secondNumber;

    public Button answer1Button;
    public Button answer2Button;
    public Button answer3Button;
    public Button answer4Button;
    public Button answer5Button;
    public Button answer6Button;
    public Button answer7Button;
    //public Button nextButton;
    //public GameObject RandomAddGameObjects;


    public int randomFirstNumber;
    public int randomSecondNumber;
     int[] options=new int[7]; 

    // public int randomFirstNumber2;
    // public int randomSecondNumber2;

    // public int randomFirstNumber3;
    // public int randomSecondNumber3;

    // public int randomFirstNumber4;
    // public int randomSecondNumber4;

    // public int randomFirstNumber5;
    // public int randomSecondNumber5;

    // public int randomFirstNumber6;
    // public int randomSecondNumber6;

    
    int answerOne;
    int answerTwo;
    int answerThree;
    int answerfour;
    int answerfive;
    int answersix;
    int answerseven;
    public int correctAnswer;
    //public Text rightorwrong_Text;

    // public AudioSource correctAnswerAudio;
    // public AudioSource incorrectAnswerAudio;

    // public GameObject answer1;
    // public GameObject answer2;
    // public GameObject answer3;

    // Vector2 frstpos1;
    // Vector2 frstpos2;
    // Vector2 frstpos3;  

    // Start is called before the first frame update
    void Start()
    {
         //Random.InitState(System.DateTime.Now.Millisecond);
         DisplayMathProblem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private (int, int) GetTwoRandomSum(){
        int firstNumber=Random.Range(1, 10);
        int secondNumber=Random.Range(1, 10 - firstNumber);

        return(firstNumber,secondNumber);
    }

    public int[] GetRandomOptions(int firstNum, int secondnum){

        int answer = firstNum + secondnum;

        if (answer < 2 || answer > 10)
        {
            throw new System.Exception("GetSumOptions received invalid values to sum");
        }       
             
        options[0] = answer;
        for(int i=1;i<7;i++){
        int option=Random.Range(1,10);        
        options[i]=option;
        } 
        
       
        for (int i = 0; i < 7; i++)
    {
        int rand = Random.Range(i, 7);        
        int tmp = options[i];
        options[i] = options[rand];
        options[rand] = tmp;
        }
              
        return options;
    }
     
    public void DisplayMathProblem(){

        var nums = GetTwoRandomSum();
        randomFirstNumber = nums.Item1;
        randomSecondNumber = nums.Item2;
        
        firstNumber.text = "" + randomFirstNumber;
        secondNumber.text = "" + randomSecondNumber;         

       int[] numbers=new int[7];
       numbers=GetRandomOptions(randomFirstNumber, randomSecondNumber);
       answerOne = numbers[0];
       answerTwo = numbers[1];
       answerThree = numbers[2];
       answerfour = numbers[3];
       answerfive = numbers[4];
       answersix = numbers[5];
       answerseven = numbers[6];      

       answer1Button.GetComponentInChildren<Text>().text = "" + answerOne;
       answer2Button.GetComponentInChildren<Text>().text = "" + answerTwo;
       answer3Button.GetComponentInChildren<Text>().text = "" + answerThree;
       answer4Button.GetComponentInChildren<Text>().text = "" + answerfour;
       answer5Button.GetComponentInChildren<Text>().text = "" + answerfive;
       answer6Button.GetComponentInChildren<Text>().text = "" + answersix;
       answer7Button.GetComponentInChildren<Text>().text = "" + answerseven;
       int randomSum = randomFirstNumber+randomSecondNumber;
       correctAnswer = randomSum;


    }
    // public void ButtonAnswer1()
    // {
    //     bool isButton1Correct = answer1Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
    //     showResults(isButton1Correct);
    // }

    // public void ButtonAnswer2()
    // {
    //     bool isButton2Correct = answer2Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
    //     showResults(isButton2Correct);
    // }

    // public void ButtonAnswer3()
    // {
    //     bool isButton3Correct = answer3Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
    //     showResults(isButton3Correct);
    // }
    //  public void ButtonAnswer4()
    //  {
    //     bool isButton4Correct = answer4Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
    //     showResults(isButton4Correct);
    //  }
    //  public void ButtonAnswer5()
    //  {
    //     bool isButton5Correct = answer5Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
    //     showResults(isButton5Correct);
    //  }
    //  public void ButtonAnswer6()
    //  {
    //     bool isButton6Correct = answer6Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
    //     showResults(isButton6Correct);
    //  }
    //  public void ButtonAnswer7()
    //  {
    //     bool isButton7Correct = answer7Button.GetComponentInChildren<Text>().text.Equals(correctAnswer.ToString());
    //     showResults(isButton7Correct);
    //  }

}
