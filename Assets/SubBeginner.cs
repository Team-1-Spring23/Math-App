using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SubBeginner : MonoBehaviour
{
    static int count = 0;
    List<TextMeshProUGUI> firstRandomNumbers;
    List<TextMeshProUGUI> secondRandomNumbers;

    List<Text> answerTexts;

    public int[] finalAnswers;

    public int panelCount = 0;

    int[] correctAnswersList;

    public Button nextBtn;

    // Text In Answer Panel List


    //Initialise an Answer Panel Queue
    Queue<GameObject> panelsQueue;

    //Dictionary<Vector2, GameObject> panelsMap;

    //This is the panel that is being answered at the moment
    GameObject presentlyActivePanel;

    //I have added this in order to change the Alpha of the @param presentlyActivePanel
    Image panelImage;

    //Answer Buttons Panel
    GameObject buttonsPanel;

    //Green Board Panel
    GameObject greenBoardPanel;

    // Start is called before the first frame update
    void Start()
    {
        initPanelsAndVariables();
        Debug.Log("Sub Harish Start Called");
        finalAnswers = GenerateRandomNumbers();

    }

    //Here is the function to generate the Answer Panels Queue
    void initPanelsAndVariables()
    {

        panelsQueue = new Queue<GameObject>();

        getPanels();


        // Initialise @param firstRandomNumbers
        firstRandomNumbers = new List<TextMeshProUGUI>();

        //Intialise @param secondRandomNumbers
        secondRandomNumbers = new List<TextMeshProUGUI>();

        getFirstandSecondTMPList();


        /**
         * Answer Buttons Panel
         */
        buttonsPanel = GameObject.FindWithTag("AnswerButtonsPanel");

        //Initialise the Answers Texts List
        answerTexts = new List<Text>();

        //Transform component of the panel game object
        Transform panelTransform = buttonsPanel.GetComponent<Transform>();

        //Loop through all the children of the panel

        for (int i = 0; i < panelTransform.childCount; i++)
        {
            Transform childTransform = panelTransform.GetChild(i);

            //Convert the child Transform into Button
            Button currentAnsButton = childTransform.GetComponent<Button>();

            Text currentAnsText = currentAnsButton.GetComponentInChildren<Text>();

            answerTexts.Add(currentAnsText);

            Debug.Log("answers Text list" + answerTexts[i]);
        }

        

        presentlyActivePanel = panelsQueue.Dequeue();

        changePanelTransparency(presentlyActivePanel);

        foreach (GameObject panel in panelsQueue)
        {
            TextMeshProUGUI[] allChildTextComponents = panel.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI childText in allChildTextComponents)
            {
                childText.color = new Color(childText.color.r, childText.color.g, childText.color.b, 0.3f);
            }
        }

        // Connect the Board to Tag

        greenBoardPanel = GameObject.FindGameObjectWithTag(Tags.GREEN_BOARD_PANEL);



    }




    /**
     * Since Panels Get Dequeued we need to call them again in the animation function
     */

    void getPanels()
    {
        panelCount = 0;
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.FIRST_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.SECOND_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.THIRD_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.FOURTH_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.FIFTH_PANEL));
        panelsQueue.Enqueue(GameObject.FindWithTag(Tags.SIXTH_PANEL));
        Debug.Log("panelCheck"+panelsQueue);
        resetTIAText(panelsQueue);
    }


    void resetTIAText(Queue<GameObject> panelsQueue)
    {
        foreach (GameObject panel in panelsQueue)
        {
            GameObject answerPanelObject = panel.transform.GetChild(4).gameObject;


            //TIA Code
            Transform TIATransform = answerPanelObject.transform.GetChild(0);
            TextMeshProUGUI TextInAnswerPanel = TIATransform.GetComponent<TextMeshProUGUI>();
            TextInAnswerPanel.text = "?";
        }
    }




    void getFirstandSecondTMPList()
    {
        foreach (GameObject panel in panelsQueue)
        {
            Transform leftSideNumber = panel.transform.GetChild(0);

            //Get the TMP Text from the currentChild
            TextMeshProUGUI firstNumberTMP = leftSideNumber.GetComponent<TextMeshProUGUI>();

            //Add it to our @param firstRandomNumbers
            firstRandomNumbers.Add(firstNumberTMP);

            //Now let's focus on the right side Numbers
            Transform rightSideNumber = panel.transform.GetChild(2);

            //Get the TMP Text from the currentChild
            TextMeshProUGUI secondNumberTMP = rightSideNumber.GetComponent<TextMeshProUGUI>();

            //Add the @param secondNumberTMP to @param secondRandomNumbers
            secondRandomNumbers.Add(secondNumberTMP);


        }

    }

    void checkFirstChild()
    {

        //Transform firstChild = PresentlyActivePanel.transform.GetChild(0);

        //TextMeshProUGUI firstText = firstChild.GetComponent<TextMeshProUGUI>();

        //Debug.Log(firstText.text);
        ////Debug.Log(PresentlyActivePanel.transform.childCount);

    }


    void changePanelTransparency(GameObject currentPanel)
    {
        //Generating Transparency
        panelImage = currentPanel.GetComponent<Image>();
        Color panelColor = panelImage.color;
        panelColor.a = 0.3f;

        panelImage.color = panelColor;

        TextMeshProUGUI[] allChildTextComponents = currentPanel.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI childText in allChildTextComponents)
        {
            childText.color = new Color(childText.color.r, childText.color.g, childText.color.b, 1f);
        }

    }

    public void resetTransparency(GameObject currentPanel)
    {
        //Generating Transparency
        panelImage = currentPanel.GetComponent<Image>();
        Color panelColor = panelImage.color;
        panelColor.a = 0f;

        panelImage.color = panelColor;

    }

    public GameObject getCurrentlyActivePanel()
    {
        if (this.presentlyActivePanel == null)
        {
            Debug.Log("Panel is null");
            return null;
        }
        return this.presentlyActivePanel;
    }

    public void changeCurrentlyActivePanel()
    {

        resetTransparency(presentlyActivePanel);

        presentlyActivePanel = panelsQueue.Dequeue();

        changePanelTransparency(presentlyActivePanel);
        panelCount++;
        GenerateAnswerButtons(finalAnswers[panelCount]);

    }

    public int[] GenerateRandomNumbers()
    {
        ////First Initialise the panels and Variables
        //initPanelsAndVariables();

        int[] firstNosList = new int[6];
        int[] secondNosList = new int[6];
        int randomNumber;

        correctAnswersList = new int[6];

        for (int i = 0; i < 6; i++)
        {
            randomNumber = Random.Range(1, 6);
            firstRandomNumbers[i].text = randomNumber.ToString();
            firstNosList[i] = randomNumber;
        }

        for (int i = 0; i < 6; i++)
        {
            randomNumber = Random.Range(1, 6);
            secondRandomNumbers[i].text = randomNumber.ToString();
            secondNosList[i] = randomNumber;
        }


        for (int i = 0; i < 6; i++)
        {
            correctAnswersList[i] = firstNosList[i] + secondNosList[i];
        }


        GenerateAnswerButtons(correctAnswersList[panelCount]);




        return correctAnswersList;

    }





    public void GenerateAnswerButtons(int correctAnswer)
    {
        int[] answerChoices = new int[7];

        int randomPlace = Random.Range(0, 7);

        answerChoices[randomPlace] = correctAnswer;

        int randomAnswer;

        for (int i = 0; i < 7; i++)
        {
            if (i == randomPlace)
            {
                continue;
            }
            //Ensure that the new random number isn't repeted and isn't the correct answer

            randomAnswer = Random.Range(1, 9);

            while (randomAnswer == correctAnswer || answerChoices.Contains(randomAnswer))
            {
                randomAnswer = Random.Range(1, 9);
            }

            answerChoices[i] = randomAnswer;

        }

        for (int i = 0; i < 7; i++)
        {
            answerTexts[i].text = answerChoices[i].ToString();
        }


    }


    /**
     *==========================================
     *          Code For Animation 
     *============================================ 
     */


    private void resetPanelsAndButtons()
    {



        firstRandomNumbers.Clear();
        secondRandomNumbers.Clear();

    }


    public void RefreshPuzzle()
    {
        count++;
        if (count % 2 == 0)
        {
            SceneManager.LoadScene("Beginner_Confetti");
            Debug.Log("Confetti loading");
            count = 0;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        //Start NewBoard Couroutine

        StartCoroutine(newBoardAnimation());
    }

    private IEnumerator newBoardAnimation()
    {

        Debug.Log(greenBoardPanel.tag);

        Vector2 originalPos = greenBoardPanel.transform.position;

        Vector2 leftOffScreen = originalPos + new Vector2(-1 * Screen.width, 0);
        Vector2 rightOffScreen = originalPos + new Vector2(Screen.width, 0);

        float elapsedTime = 0;
        int moveSpeed = 8;

        while (elapsedTime < 1)
        {
            greenBoardPanel.transform.position = Vector2.Lerp(greenBoardPanel.transform.position, leftOffScreen, Time.deltaTime * moveSpeed);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        greenBoardPanel.transform.position = rightOffScreen;

        /**
         * ================================================
         *              CODE TO RESTART THE BOARD
         */

        resetPanelsAndButtons();
        initPanelsAndVariables();
        finalAnswers = GenerateRandomNumbers();

        /**
         * ================================================
         */


        while (elapsedTime < 2)
        {
            greenBoardPanel.transform.position = Vector2.Lerp(greenBoardPanel.transform.position, originalPos, Time.deltaTime * moveSpeed);
            elapsedTime += Time.deltaTime;

            yield return null;
        }



        greenBoardPanel.transform.position = originalPos;

        yield return null;


    }



}