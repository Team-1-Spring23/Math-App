using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.EventSystems;


public class DragDropMomoIntermediate : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject AnsB;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    Vector2 objectInitPos;

    // Start is called before the first frame update
    void Start()
    {

        //panel = GameObject.Find("Buttons_Panel");
        //buttons=panel.GetComponentInChildren<Button>();         
        objectInitPos = AnsB.transform.position;

    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        AnsB.transform.position = objectInitPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        rectTransform.position = Input.mousePosition;
    }
}
