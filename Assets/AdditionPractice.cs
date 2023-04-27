using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AdditionPractice : MonoBehaviour
{
    // Access HelperFunctions
    private HelperFunctions helperFunctions;

    public Text panel1firstNumber;
    public Text panel1secondNumber;
    public Text panel1ans;
    public Text panel2firstNumber;
    public Text panel2secondNumber;
    public Text panel2ans;
    public Text panel3firstNumber;
    public Text panel3secondNumber;
    public Text panel3ans;
    public Text panel4firstNumber;
    public Text panel4secondNumber;
    public Text panel4ans;
    public Text panel5firstNumber;
    public Text panel5secondNumber;
    public Text panel5ans;
    public Text panel6firstNumber;
    public Text panel6secondNumber;
    public Text panel6ans;

    public Text answer1Button;
    public Text answer2Button;
    public Text answer3Button;
    public Text answer4Button;
    public Text answer5Button;
    public Text answer6Button;
    public Text answer7Button;

    //public Button nextButton;
    //public GameObject RandomAddGameObjects;

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
    int answerFour;
    int answerFive;
    int answerSix;

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
        helperFunctions = FindObjectOfType<HelperFunctions>();
        DisplayMathProblem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void DisplayMathProblem()
    {
        // Set up all 6 problems
        var nums1 = helperFunctions.GetTwoRandomSum(9);
        panel1firstNumber.text = "" + nums1.Item1;
        panel1secondNumber.text = "" + nums1.Item2;
        answerOne = nums1.Item1 + nums1.Item2;

        var nums2 = helperFunctions.GetTwoRandomSum(9);
        panel2firstNumber.text = "" + nums2.Item1;
        panel2secondNumber.text = "" + nums2.Item2;
        answerTwo = nums2.Item1 + nums2.Item2;

        var nums3 = helperFunctions.GetTwoRandomSum(9);
        panel3firstNumber.text = "" + nums3.Item1;
        panel3secondNumber.text = "" + nums3.Item2;
        answerThree = nums3.Item1 + nums3.Item2;

        var nums4 = helperFunctions.GetTwoRandomSum(9);
        panel4firstNumber.text = "" + nums4.Item1;
        panel4secondNumber.text = "" + nums4.Item2;
        answerFour = nums4.Item1 + nums4.Item2;

        var nums5 = helperFunctions.GetTwoRandomSum(9);
        panel5firstNumber.text = "" + nums5.Item1;
        panel5secondNumber.text = "" + nums5.Item2;
        answerFive = nums5.Item1 + nums5.Item2;

        var nums6 = helperFunctions.GetTwoRandomSum(9);
        panel6firstNumber.text = "" + nums6.Item1;
        panel6secondNumber.text = "" + nums6.Item2;
        answerSix = nums6.Item1 + nums6.Item2;

        panel1ans.text = "" + answerOne;
        panel2ans.text = "" + answerTwo;
        panel3ans.text = "" + answerThree;
        panel4ans.text = "" + answerFour;
        panel5ans.text = "" + answerFive;
        panel6ans.text = "" + answerSix;

        // Set up answer options
        var options = new List<int>() { answerOne, answerTwo, answerThree, answerFour, answerFive, answerSix, Random.Range(1,10) };
        // Randomize their order
        int count = options.Count;
        for (int i = 0; i < count - 1; ++i)
        {
            int rand = Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }

        answer1Button.text = "" + options[0];
        answer2Button.text = "" + options[1];
        answer3Button.text = "" + options[2];
        answer4Button.text = "" + options[3];
        answer5Button.text = "" + options[4];
        answer6Button.text = "" + options[5];
        answer7Button.text = "" + options[6];
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
