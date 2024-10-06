using UnityEngine;
using UnityEngine.UI;


public class VisualInteractable : MonoBehaviour, IVisualState
{
    [SerializeField] private Image                _img;
    [SerializeField] private VisualClickAnimation _clickAnim;

    private bool _resetOnDisable = true;
    private VisualInteractableScriptable visualInteractableScriptable;


    public void SetVisualPreset(VisualStyle visualStyle)
    {
        visualInteractableScriptable = UiThemeManager.Instance.GetPreset().GetVisual(visualStyle);
    }

    private void OnDisable()
    {
        if (_resetOnDisable)
        {
            DefaultState();
        }
    }

    private void DefaultState()
    {
        if (!visualInteractableScriptable)
        {
            return;
        }

        _img.color = visualInteractableScriptable.colorDefault;

        if (visualInteractableScriptable.spriteDefault)
        {
            _img.sprite = visualInteractableScriptable.spriteDefault;
        }
    }

    public void ResetStateOnDisable(bool isReset)
    {
        _resetOnDisable = isReset;
    }

    public void OnClick()
    {
        if (!visualInteractableScriptable)
        {
            return;
        }

        _img.color = visualInteractableScriptable.colorClick;

        if (visualInteractableScriptable.spriteClick)
        {
            _img.sprite = visualInteractableScriptable.spriteClick;
        }

        if (_clickAnim)
        {
            _clickAnim.StartAnimation();
        }
    }

    public void OnMouseEnter()
    {
        if (!visualInteractableScriptable)
        {
            return;
        }

        _img.color = visualInteractableScriptable.colorHover;

        if (visualInteractableScriptable.spriteHover)
        {
            _img.sprite = visualInteractableScriptable.spriteHover;
        }
    }

    public void OnMouseExit()
    {
        DefaultState();
    }

    public void OnDisabled()
    {
        if (!visualInteractableScriptable)
        {
            return;
        }

        _img.color = visualInteractableScriptable.colorDisabled;

        if (visualInteractableScriptable.spriteDisabled)
        {
            _img.sprite = visualInteractableScriptable.spriteDisabled;
        }
    }
}
