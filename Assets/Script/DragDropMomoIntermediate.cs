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

    private Vector3 mousePositionOffset;

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
        mousePositionOffset = eventData.pointerDrag.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
        Canvas[] canvases = eventData.pointerDrag.transform.GetComponentsInParent<Canvas>();
        if (null != mousePositionOffset)
        {
            eventData.pointerDrag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mousePositionOffset;
        }
        else if (canvases != null && canvases.Length > 0)
        {
            rectTransform.anchoredPosition += eventData.delta / canvases[0].scaleFactor;
        }
        else
        {
            eventData.pointerDrag.transform.position = Input.mousePosition;
        }
    }
}
