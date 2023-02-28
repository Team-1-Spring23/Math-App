using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    private bool dragging, _placed;
    private Vector2 _offSet, _originalPosition;
    private PuzzleSlot _slot;

    public void Init(PuzzleSlot slot){
        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
    }
    void Awake () {
        _originalPosition = transform.position;
    }
    void Update (){
        if(_placed) return;
        if(!dragging) return;

        var mousePosition =  GetMousePos();
        transform.position = mousePosition - _offSet;
    }
    void OnMouseDown(){
        dragging = true;
        _offSet = GetMousePos() - (Vector2)transform.position;
    }
    void OnMouseUp(){
        if(Vector2.Distance (transform.position, _slot.transform.position) <3){
            transform.position = _slot.transform.position;
            // _slot.Placed();
            _placed = true;
        }
        else{
            transform.position = _originalPosition;
            dragging = false; 
        }
        
    }

    Vector2 GetMousePos(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
