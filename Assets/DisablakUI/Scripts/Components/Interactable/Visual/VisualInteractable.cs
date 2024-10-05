using UnityEngine;
using UnityEngine.UI;


public class VisualInteractable : MyMonoBehaviour, IVisualState
{
    [SerializeField] private Image                img;
    [SerializeField] private VisualClickAnimation clickAnim;

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

        img.color = visualInteractableScriptable.colorDefault;

        if (visualInteractableScriptable.spriteDefault)
        {
            img.sprite = visualInteractableScriptable.spriteDefault;
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

        img.color = visualInteractableScriptable.colorClick;

        if (visualInteractableScriptable.spriteClick)
        {
            img.sprite = visualInteractableScriptable.spriteClick;
        }

        if (clickAnim)
        {
            clickAnim.StartAnimation();
        }
    }

    public void OnMouseEnter()
    {
        if (!visualInteractableScriptable)
        {
            return;
        }

        img.color = visualInteractableScriptable.colorHover;

        if (visualInteractableScriptable.spriteHover)
        {
            img.sprite = visualInteractableScriptable.spriteHover;
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

        img.color = visualInteractableScriptable.colorDisabled;

        if (visualInteractableScriptable.spriteDisabled)
        {
            img.sprite = visualInteractableScriptable.spriteDisabled;
        }
    }
}
