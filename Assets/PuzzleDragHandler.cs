using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PuzzleDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject buttonsBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        buttonsBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        buttonsBeingDragged = null;
        if (transform.parent != startParent)
        {
            transform.position = startPosition;
        }
    }
}


