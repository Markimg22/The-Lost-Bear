using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler {

  private RectTransform _rectTransform;
  private Canvas _canvas;
  private CanvasGroup _canvasGroup;
  private Transform _commandBlocksParent;


  private void Awake() {
    _rectTransform = GetComponent<RectTransform>();    
    _canvas = transform.root.GetComponent<Canvas>();
    _canvasGroup = GetComponent<CanvasGroup>();
    _commandBlocksParent = this.transform.parent;
  }

  public void OnPointerDown(PointerEventData eventData){ }

  public void OnBeginDrag(PointerEventData eventData) {
    _canvasGroup.alpha = 0.5f;
    _canvasGroup.blocksRaycasts = false;
  }

  public void OnDrag(PointerEventData eventData) {
    _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
  }

  public void OnEndDrag(PointerEventData eventData) {
    _canvasGroup.alpha = 1f;
    _canvasGroup.blocksRaycasts = true;
  }
}
