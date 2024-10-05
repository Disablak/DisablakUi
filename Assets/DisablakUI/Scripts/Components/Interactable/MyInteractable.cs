using UnityEngine;
using UnityEngine.EventSystems;


public abstract class MyInteractable : MyMonoBehaviour, IElementUI, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header(nameof(MyInteractable))]
    [SerializeField] protected VisualStyle _visualStyle;
    [SerializeField] private bool        _isInteractable = true;
    [SerializeField] private bool        _isInProgress   = false;

    public bool IsInteractable => _isInteractable;


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (_isInProgress)
        {
            // TODO show dialog "feature in progress"
            return;
        }
        
        if (_isInteractable)
        {
            OnPointerClick();
            // TODO play sound
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (_isInteractable)
        {
            OnEnter();
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (_isInteractable)
        {
            OnExit();
        }
    }
    
    protected abstract void OnPointerClick();
    protected abstract void OnEnter();
    protected abstract void OnExit();
    
    public void SetInteractable(bool isInteractable)
    {
        this._isInteractable = isInteractable;
        OnChangeInteractable();
    }
    
    protected virtual void OnChangeInteractable()
    {}
}