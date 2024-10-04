using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(VisualClickAnimation))]
public class VisualSprite : MyMonoBehaviour, IVisualState
{
    [SerializeField] private Sprite spriteDefault  = null;
    [SerializeField] private Sprite spriteClick    = null;
    [SerializeField] private Sprite spriteHover    = null;
    [SerializeField] private Sprite spriteDisabled = null;
    [Space]
    [SerializeField] private Image image;
    [SerializeField] private VisualClickAnimation clickAnim;
    
    private bool _resetOnDisable = true;
    

    private void OnDisable()
    {
        if (_resetOnDisable)
        {
            image.sprite = spriteDefault;
        }
    }

    void IVisualState.ResetStateOnDisable(bool isReset)
    {
        _resetOnDisable = isReset;
    }
    
    void IVisualState.OnClick()
    {
        image.sprite = spriteClick;
        clickAnim.StartAnimation();
    }

    void IVisualState.OnMouseEnter()
    {
        image.sprite = spriteHover;
    }

    void IVisualState.OnMouseExit()
    {
        image.sprite = spriteDefault;
    }

    void IVisualState.OnDisabled()
    {
        image.sprite = spriteDisabled;
    }
}
