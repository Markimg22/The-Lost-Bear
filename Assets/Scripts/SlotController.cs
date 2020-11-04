using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotController : MonoBehaviour, IDropHandler {

  private RectTransform _rectTransform;


  private void Awake() {
      _rectTransform = GetComponent<RectTransform>();
  }

  public void OnDrop(PointerEventData eventData) {        
    // Can Drop?
    if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<ItemController>()) {
      eventData.pointerDrag.transform.SetParent(this.transform);
      eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _rectTransform.anchoredPosition;
    }
  }
}
