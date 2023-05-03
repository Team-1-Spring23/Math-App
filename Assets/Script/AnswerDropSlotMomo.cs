using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AnswerDropSlotMomo : MonoBehaviour, IDropHandler
{
    public AudioSource correctAnswerAudio;
    public AudioSource incorrectAnswerAudio;

    public GameObject correctAnswerSprite;
    public GameObject incorrectAnswerSprite;

    public Button nextButton;

    private Coroutine coroutineMessage;

    public AdditionPractice additionPractice; // Access game script

    void Start()
    {
        //Random.InitState(System.DateTime.Now.Millisecond);
        additionPractice = FindObjectOfType<AdditionPractice>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObjet = eventData.pointerDrag;
        draggedObjet.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

        Transform[] allChilds = GetComponent<RectTransform>().parent.GetComponentsInChildren<Transform>(true);
        bool isCorrectAnswer = false;

        for (int i = 0; i < allChilds.Length; i++) {
            if (!allChilds[i].gameObject.activeSelf && allChilds[i].gameObject.GetComponent<Text>().text.Equals(draggedObjet.transform.GetChild(0).gameObject.GetComponent<Text>().text))
            {
                allChilds[i].gameObject.SetActive(true);
                isCorrectAnswer = true;
                break;
            }
        }

        if (isCorrectAnswer)
        {
            if (null != coroutineMessage)
            {
                StopCoroutine(coroutineMessage);
            }
            correctAnswerAudio.Play();
            // nextButton.gameObject.SetActive(true);
            correctAnswerSprite.gameObject.SetActive(true);
            incorrectAnswerSprite.gameObject.SetActive(false);
            coroutineMessage = StartCoroutine(disableAnimationAfterMillis(correctAnswerSprite, 3.0f));
            //draggedObjet.SetActive(false);
            GetComponent<RectTransform>().gameObject.SetActive(false);
            additionPractice.incrementCorrect();
            if (additionPractice.numCorrect >= 6)
            {
                nextButton.gameObject.SetActive(true);
                //additionPractice.DisplayMathProblem();
                //correctAnswerSprite.gameObject.SetActive(false);
                //incorrectAnswerSprite.gameObject.SetActive(false);
            }
        }
        else
        {
            if (null != coroutineMessage)
            {
                StopCoroutine(coroutineMessage);
            }
            incorrectAnswerAudio.Play();
            correctAnswerSprite.gameObject.SetActive(false);
            incorrectAnswerSprite.gameObject.SetActive(true);
            coroutineMessage = StartCoroutine(disableAnimationAfterMillis(incorrectAnswerSprite, 3.0f));
        }
    }

    public IEnumerator disableAnimationAfterMillis(GameObject gameObject, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }

}
