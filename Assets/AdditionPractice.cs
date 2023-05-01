using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AdditionPractice : MonoBehaviour
{
    // Access HelperFunctions
    private HelperFunctions helperFunctions;

    public Text panel1firstNumber; // Text for each digit in each problem
    public Text panel1secondNumber;
    public Text panel1ans;
    public Text panel1AnsSlot;
    public Text panel2firstNumber;
    public Text panel2secondNumber;
    public Text panel2ans;
    public Text panel2AnsSlot;
    public Text panel3firstNumber;
    public Text panel3secondNumber;
    public Text panel3ans;
    public Text panel3AnsSlot;
    public Text panel4firstNumber;
    public Text panel4secondNumber;
    public Text panel4ans;
    public Text panel4AnsSlot;
    public Text panel5firstNumber;
    public Text panel5secondNumber;
    public Text panel5ans;
    public Text panel5AnsSlot;
    public Text panel6firstNumber;
    public Text panel6secondNumber;
    public Text panel6ans;
    public Text panel6AnsSlot;

    public Text answer1Button; // Text of the answer buttons
    public Text answer2Button;
    public Text answer3Button;
    public Text answer4Button;
    public Text answer5Button;
    public Text answer6Button;
    public Text answer7Button;
    
    int answerOne; // Values of the correct sums
    int answerTwo;
    int answerThree;
    int answerFour;
    int answerFive;
    int answerSix;

    public int panel1question; // Which number are we asking for - first, second, or third
    public int panel2question;
    public int panel3question;
    public int panel4question;
    public int panel5question;
    public int panel6question;

    private HashSet<string> currentPuzzleQuestions = new HashSet<string>();

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
        // Set up all 6 problems, first the digits being summed
        var nums1 = getPuzzleNumbers();
        panel1firstNumber.text = "" + nums1.Item1;
        panel1secondNumber.text = "" + nums1.Item2;
        answerOne = nums1.Item1 + nums1.Item2;

        var nums2 = getPuzzleNumbers();
        panel2firstNumber.text = "" + nums2.Item1;
        panel2secondNumber.text = "" + nums2.Item2;
        answerTwo = nums2.Item1 + nums2.Item2;

        var nums3 = getPuzzleNumbers();
        panel3firstNumber.text = "" + nums3.Item1;
        panel3secondNumber.text = "" + nums3.Item2;
        answerThree = nums3.Item1 + nums3.Item2;

        var nums4 = getPuzzleNumbers();
        panel4firstNumber.text = "" + nums4.Item1;
        panel4secondNumber.text = "" + nums4.Item2;
        answerFour = nums4.Item1 + nums4.Item2;

        var nums5 = getPuzzleNumbers();
        panel5firstNumber.text = "" + nums5.Item1;
        panel5secondNumber.text = "" + nums5.Item2;
        answerFive = nums5.Item1 + nums5.Item2;

        var nums6 = getPuzzleNumbers();
        panel6firstNumber.text = "" + nums6.Item1;
        panel6secondNumber.text = "" + nums6.Item2;
        answerSix = nums6.Item1 + nums6.Item2;

        // Set answer text
        panel1ans.text = "" + answerOne;
        panel2ans.text = "" + answerTwo;
        panel3ans.text = "" + answerThree;
        panel4ans.text = "" + answerFour;
        panel5ans.text = "" + answerFive;
        panel6ans.text = "" + answerSix;

        // Randomly choose a number in each panel to hide
        panel1question = Random.Range(1, 4);
        panel2question = Random.Range(1, 4);
        panel3question = Random.Range(1, 4);
        panel4question = Random.Range(1, 4);
        panel5question = Random.Range(1, 4);
        panel6question = Random.Range(1, 4);

        var options = new List<int>(); // List of answer options (will contain everything that gets hidden here)
        switch (panel1question)
        {
            case 1:
                panel1firstNumber.gameObject.SetActive(false);
                panel1AnsSlot.transform.position = panel1firstNumber.transform.position;
                panel1AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel1firstNumber.text));
                break;
            case 2:
                panel1secondNumber.gameObject.SetActive(false);
                panel1AnsSlot.transform.position = panel1secondNumber.transform.position;
                panel1AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel1secondNumber.text));
                break;
            case 3:
                panel1ans.gameObject.SetActive(false);
                panel1AnsSlot.transform.position = panel1ans.transform.position;
                panel1AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel1ans.text));
                break;
        }
        switch (panel2question)
        {
            case 1:
                panel2firstNumber.gameObject.SetActive(false);
                panel2AnsSlot.transform.position = panel2firstNumber.transform.position;
                panel2AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel2firstNumber.text));
                break;
            case 2:
                panel2secondNumber.gameObject.SetActive(false);
                panel2AnsSlot.transform.position = panel2secondNumber.transform.position;
                panel2AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel2secondNumber.text));
                break;
            case 3:
                panel2ans.gameObject.SetActive(false);
                panel2AnsSlot.transform.position = panel2ans.transform.position;
                panel2AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel2ans.text));
                break;
        }
        switch (panel3question)
        {
            case 1:
                panel3firstNumber.gameObject.SetActive(false);
                panel3AnsSlot.transform.position = panel3firstNumber.transform.position;
                panel3AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel3firstNumber.text));
                break;
            case 2:
                panel3secondNumber.gameObject.SetActive(false);
                panel3AnsSlot.transform.position = panel3secondNumber.transform.position;
                panel3AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel3secondNumber.text));
                break;
            case 3:
                panel3ans.gameObject.SetActive(false);
                panel3AnsSlot.transform.position = panel3ans.transform.position;
                panel3AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel3ans.text));
                break;
        }
        switch (panel4question)
        {
            case 1:
                panel4firstNumber.gameObject.SetActive(false);
                panel4AnsSlot.transform.position = panel4firstNumber.transform.position;
                panel4AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel4firstNumber.text));
                break;
            case 2:
                panel4secondNumber.gameObject.SetActive(false);
                panel4AnsSlot.transform.position = panel4secondNumber.transform.position;
                panel4AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel4secondNumber.text));
                break;
            case 3:
                panel4ans.gameObject.SetActive(false);
                panel4AnsSlot.transform.position = panel4ans.transform.position;
                panel4AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel4ans.text));
                break;
        }
        switch (panel5question)
        {
            case 1:
                panel5firstNumber.gameObject.SetActive(false);
                panel5AnsSlot.transform.position = panel5firstNumber.transform.position;
                panel5AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel5firstNumber.text));
                break;
            case 2:
                panel5secondNumber.gameObject.SetActive(false);
                panel5AnsSlot.transform.position = panel5secondNumber.transform.position;
                panel5AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel5secondNumber.text));
                break;
            case 3:
                panel5ans.gameObject.SetActive(false);
                panel5AnsSlot.transform.position = panel5ans.transform.position;
                panel5AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel5ans.text));
                break;
        }
        switch (panel6question)
        {
            case 1:
                panel6firstNumber.gameObject.SetActive(false);
                panel6AnsSlot.transform.position = panel6firstNumber.transform.position;
                panel6AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel6firstNumber.text));
                break;
            case 2:
                panel6secondNumber.gameObject.SetActive(false);
                panel6AnsSlot.transform.position = panel6secondNumber.transform.position;
                panel6AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel6secondNumber.text));
                break;
            case 3:
                panel6ans.gameObject.SetActive(false);
                panel6AnsSlot.transform.position = panel6ans.transform.position;
                panel6AnsSlot.gameObject.SetActive(true);
                options.Add(int.Parse(panel6ans.text));
                break;
        }

        // Set up answer options
        // First pick a random number that is not a correct option, since we need to include 1 dummy option
        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        foreach (var i in options)
        {
            possibilities.Remove(i);
        }
        int randomIndex = Random.Range(0, possibilities.Count);
        int dummyAnswer = possibilities[randomIndex];
        options.Add(dummyAnswer);
        // Randomize order of options
        int count = options.Count;
        for (int i = 0; i < count - 1; ++i)
        {
            int rand = Random.Range(i, count);
            int tmp = options[i];
            options[i] = options[rand];
            options[rand] = tmp;
        }
        // Finally, set answer button text
        answer1Button.text = "" + options[0];
        answer2Button.text = "" + options[1];
        answer3Button.text = "" + options[2];
        answer4Button.text = "" + options[3];
        answer5Button.text = "" + options[4];
        answer6Button.text = "" + options[5];
        answer7Button.text = "" + options[6];

        // Now all is set up, and the correct answers are stored in the text of the digits that were hidden during setup
    }

    private (int, int) getPuzzleNumbers()
    {
        (int, int) numbers = helperFunctions.GetTwoRandomSum(9);
        string numbers_key = numbers.Item1.ToString() + numbers.Item2.ToString();

        while (currentPuzzleQuestions.Contains(numbers_key)) {
            numbers = helperFunctions.GetTwoRandomSum(9);
            numbers_key = numbers.Item1.ToString() + numbers.Item2.ToString();
        }

        currentPuzzleQuestions.Add(numbers_key);
        return numbers;
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
