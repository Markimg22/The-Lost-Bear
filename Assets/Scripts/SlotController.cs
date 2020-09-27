﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SlotController : MonoBehaviour, IDropHandler
{
    public void OnDrop( PointerEventData eventData )
    {        
        if( eventData.pointerDrag != null )
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.SetParent( this.transform );
            eventData.pointerDrag.GetComponent<ItemController>().isConnected = true;
        }
    }
}
