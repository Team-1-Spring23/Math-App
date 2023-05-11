using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerDropSlotIntermediateMomo : MonoBehaviour, IDropHandler
{
    public AdditionPracticeIntermediate additionPracticeIntermediate; // Access game script

    void Start()
    {
        additionPracticeIntermediate = FindObjectOfType<AdditionPracticeIntermediate>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObjet = eventData.pointerDrag;
        draggedObjet.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

        Transform[] allChilds = GetComponent<RectTransform>().parent.GetComponentsInChildren<Transform>(true);
        bool isCorrectAnswer = false;
        string correctValue = null;

        for (int i = 0; i < allChilds.Length; i++)
        {
            if (!allChilds[i].gameObject.activeSelf
                && null != allChilds[i].gameObject.GetComponent<Text>()
                && allChilds[i].gameObject.GetComponent<Text>().text.Equals(draggedObjet.transform.GetChild(0).gameObject.GetComponent<Text>().text))
            {
                allChilds[i].gameObject.SetActive(true);
                GetComponent<RectTransform>().gameObject.SetActive(false);
                isCorrectAnswer = true;
                correctValue = allChilds[i].gameObject.GetComponent<Text>().text;
                draggedObjet.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
                break;
            }
        }

        if (null != additionPracticeIntermediate)
        {
            additionPracticeIntermediate.processAttempt(isCorrectAnswer, correctValue);
        }

    }

}
