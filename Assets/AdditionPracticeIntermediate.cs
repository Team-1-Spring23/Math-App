using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionPracticeIntermediate : MonoBehaviour
{
    private static int MAX_SLOTS = 6;

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

    public AudioSource correctAnswerAudio;
    public AudioSource incorrectAnswerAudio;

    public GameObject correctAnswerSprite;
    public GameObject incorrectAnswerSprite;

    public Button nextButton;

    private HashSet<string> currentPuzzleQuestions = new HashSet<string>();
    private List<int> unsolvedCorrectAnswers = new List<int>();

    private Coroutine correctAnswerCoroutineMessage;
    private Coroutine incorrectAnswerCoroutineMessage;

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
        currentPuzzleQuestions.Clear();
        unsolvedCorrectAnswers.Clear();

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

        panel1ans.gameObject.SetActive(false);
        panel1AnsSlot.transform.position = panel1ans.transform.position;
        panel1AnsSlot.gameObject.SetActive(true);
        unsolvedCorrectAnswers.Add(int.Parse(panel1ans.text));

        panel2ans.gameObject.SetActive(false);
        panel2AnsSlot.transform.position = panel2ans.transform.position;
        panel2AnsSlot.gameObject.SetActive(true);
        unsolvedCorrectAnswers.Add(int.Parse(panel2ans.text));

        panel3ans.gameObject.SetActive(false);
        panel3AnsSlot.transform.position = panel3ans.transform.position;
        panel3AnsSlot.gameObject.SetActive(true);
        unsolvedCorrectAnswers.Add(int.Parse(panel3ans.text));

        panel4ans.gameObject.SetActive(false);
        panel4AnsSlot.transform.position = panel4ans.transform.position;
        panel4AnsSlot.gameObject.SetActive(true);
        unsolvedCorrectAnswers.Add(int.Parse(panel4ans.text));

        panel5ans.gameObject.SetActive(false);
        panel5AnsSlot.transform.position = panel5ans.transform.position;
        panel5AnsSlot.gameObject.SetActive(true);
        unsolvedCorrectAnswers.Add(int.Parse(panel5ans.text));

        panel6ans.gameObject.SetActive(false);
        panel6AnsSlot.transform.position = panel6ans.transform.position;
        panel6AnsSlot.gameObject.SetActive(true);
        unsolvedCorrectAnswers.Add(int.Parse(panel6ans.text));

        // Button Panel
        answer1Button.transform.parent.transform.parent.gameObject.SetActive(true);

        // Set up answer options
        generateAndSetRandomOptions(unsolvedCorrectAnswers);

        nextButton.gameObject.SetActive(false);
        correctAnswerSprite.gameObject.SetActive(false);
        incorrectAnswerSprite.gameObject.SetActive(false);
    }

    private void generateAndSetRandomOptions(List<int> unsolvedCorrectAnswers)
    {
        var options = new List<int>();
        options.AddRange(unsolvedCorrectAnswers);
        // First pick a random number that is not a correct option, since we need to include 1 dummy option
        var possibilities = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        foreach (var i in unsolvedCorrectAnswers)
        {
            possibilities.Remove(i);
        }

        while (options.Count <= MAX_SLOTS)
        {
            int randomIndex = Random.Range(0, possibilities.Count);
            int dummyAnswer = possibilities[randomIndex];
            options.Add(dummyAnswer);
            possibilities.Remove(dummyAnswer);
        }

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
    }

    private (int, int) getPuzzleNumbers()
    {
        (int, int) numbers = helperFunctions.GetTwoRandomSum(9);
        string numbers_key = numbers.Item1.ToString() + "_" + numbers.Item2.ToString();

        while (currentPuzzleQuestions.Contains(numbers_key))
        {
            numbers = helperFunctions.GetTwoRandomSum(9);
            numbers_key = numbers.Item1.ToString() + "_" + numbers.Item2.ToString();
        }

        currentPuzzleQuestions.Add(numbers_key);
        return numbers;
    }

    public void processAttempt(bool isCorrectAnswer, string correctValue)
    {

        if (isCorrectAnswer)
        {
            if (null != correctAnswerCoroutineMessage)
            {
                StopCoroutine(correctAnswerCoroutineMessage);
            }
            correctAnswerAudio.Play();
            correctAnswerSprite.gameObject.SetActive(true);
            incorrectAnswerSprite.gameObject.SetActive(false);
            correctAnswerCoroutineMessage = StartCoroutine(disableAnimationAfterMillis(correctAnswerSprite, 3.0f));


            if (null != correctValue)
            {
                unsolvedCorrectAnswers.Remove(int.Parse(correctValue));
            }

            if (unsolvedCorrectAnswers.Count == 0)
            {
                nextButton.gameObject.SetActive(true);
                // hide button panel
                StartCoroutine(disableAnimationAfterMillis(answer1Button.transform.parent.transform.parent.gameObject, 0.25f));
            }
            else
            {
                // Refresh reshuffle options, if puzzle still not solved
                generateAndSetRandomOptions(unsolvedCorrectAnswers);
            }
        }
        else
        {
            if (null != incorrectAnswerCoroutineMessage)
            {
                StopCoroutine(incorrectAnswerCoroutineMessage);
            }
            incorrectAnswerAudio.Play();
            correctAnswerSprite.gameObject.SetActive(false);
            incorrectAnswerSprite.gameObject.SetActive(true);
            incorrectAnswerCoroutineMessage = StartCoroutine(disableAnimationAfterMillis(incorrectAnswerSprite, 3.0f));
        }
    }

    public IEnumerator disableAnimationAfterMillis(GameObject gameObject, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }

}
