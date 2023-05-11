using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragDropMomoIntermediate : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject AnsB;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    Vector2 objectInitPos;

    private NumberToAudio numberToAudio;

    // Start is called before the first frame update
    void Start()
    {
        objectInitPos = AnsB.transform.position;
        numberToAudio = FindObjectOfType<NumberToAudio>();
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        try
        {
            int number = Int32.Parse(eventData.pointerDrag.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            numberToAudio.playAudioForNumber(number);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

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
