using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class addingLevelManager : MonoBehaviour
{
    public TMP_Text rightOperandText;
    public TMP_Text leftOperandText;
    public TMP_Text solutionText;
    public TMP_Text highlightTextLeft;
    public TMP_Text highlightTextRight;
    public TMP_Text highlightTextAnswer;

    int leftOperand = 0;
    int rightOperand = 0;
    [SerializeField]
    int answer;
    int choice;
   
    // Start is called before the first frame update
    void Start()
    {
        leftOperand = Random.Range(1, 6);
        rightOperand = Random.Range(1, 6);
        answer = leftOperand + rightOperand;
     
        //display correct Text
        leftOperandText.text = leftOperand.ToString();
        rightOperandText.text = rightOperand.ToString();
        solutionText.text = answer.ToString();
        highlightTextLeft.text = leftOperand.ToString();
        highlightTextRight.text = rightOperand.ToString();
        highlightTextAnswer.text = answer.ToString();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

//Notes
//int.Parse() is used to take a string and convert it to an int
//.ToString() is used to take an int and make it a string