using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Draganddrop_puzzle : MonoBehaviour,IBeginDragHandler, 
  IDragHandler, 
  IEndDragHandler
 {

   public Transform answerSlot;
   public float desiredDuration = 10.0f;
   float elapsedTime;
   bool isOnStart = false;
   public TMP_Text answerText;
   public TMP_Text currentText;
   public RectTransform answerTextPosition;
   public float d;

  private void Start()
  {
    //mOriginalPosition = UIDragElement.localPosition;
  } 

  public void OnBeginDrag(PointerEventData eventData){
    isOnStart = false;
    elapsedTime = 0;
    //buttonsBeingDragged = gameObject;
    //startPosition = transform.position;
    //startParent = transform.parent;   
     }

  public void OnDrag(PointerEventData eventData)
  {
    transform.position = Input.mousePosition;
  }
  public void OnEndDrag(PointerEventData eventData)
  {
    //buttonsBeingDragged = null;
    if(isCorrectSlot() == false)
    {
      isOnStart = true;
      }
      else
      {
        if(answerText.text == currentText.text)
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
  }

  public void Update()
  {
    d = Vector3.Distance(answerTextPosition.position, transform.position);
    if(isOnStart == true)
    {
      elapsedTime += Time.deltaTime;
      float percentageComplete = elapsedTime / desiredDuration;
      transform.position = Vector3.Lerp(transform.position, transform.parent.position, percentageComplete);
       }
  }

  public bool isCorrectSlot() 
  {

     if(d < 60)
     {
      return true;
      }
      return false;
      }
  }

