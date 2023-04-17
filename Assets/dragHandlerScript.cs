using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class dragHandlerScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //public static GameObject buttonsBeingDragged;
    //public Vector3 startPosition;
    //public Transform startParent;
    public Transform answerSlot;
    public float desiredDuration = 10.0f;
    float elapsedTime;
    bool isOnStart = false;
    public TMP_Text answerText;
    public TMP_Text currentText;
    public RectTransform answerTextPosition;
    public float d;
    //public RectTransform currentTextPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isOnStart = false;
        elapsedTime = 0;
        //buttonsBeingDragged = gameObject;
        //startPosition = transform.position;
        //startParent = transform.parent;
    }


    public void OnDrag(PointerEventData eventData)
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        //buttonsBeingDragged = null;
        if (isCorrectSlot() == false)
        {
            isOnStart = true;
        }
        else
        {
            if (answerText.text == currentText.text)
            {
                transform.position = answerSlot.position;
                isOnStart = false;
                Debug.Log("Correct");
            }
            else
            {
                isOnStart = true;
            }


        }


        //if (transform.parent != startParent)
        //{
        //    transform.position = startPosition;
        //}
    }


    public void Update()
    {
        var answerPosScreenPoint = answerTextPosition.position;
        answerPosScreenPoint.z = 10.0f; //distance of the plane from the camera
        var transformPosScreenPoint = transform.position;
        transformPosScreenPoint.z = 10.0f; //distance of the plane from the camera
        d = Vector3.Distance(answerPosScreenPoint, transformPosScreenPoint);


        if (isOnStart == true)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;
            transform.position = Vector3.Lerp(transform.position, transform.parent.position, percentageComplete);
        }

    }


    public bool isCorrectSlot()
    {
        if (d < 1)
        {
            return true;
        }


        return false;
    }
}





