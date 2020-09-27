using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region Fields

    private RectTransform _rectTransform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private Vector3 _initialPosition;

    private Transform _commandBlocksParent;

    [ HideInInspector ]
    public bool isConnected;

    #endregion



    #region Unity

    private void Awake() 
    {
        _rectTransform = GetComponent<RectTransform>();    
        _canvas = transform.root.GetComponent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _commandBlocksParent = this.transform.parent;
    }

    private void Start() 
    {
        _initialPosition = this.transform.localPosition;    
        isConnected = false;
    }

    #endregion



    #region EventSystems

    public void OnBeginDrag( PointerEventData eventData )
    {
        _canvasGroup.alpha = 0.5f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag( PointerEventData eventData )
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        this.transform.SetParent( _commandBlocksParent );
        isConnected = false;
    }

    public void OnEndDrag( PointerEventData eventData )
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        if( !isConnected )
        {
            this.transform.localPosition = _initialPosition;
        }
    }

    #endregion
}
