using UnityEngine;
using UnityEngine.UI;


public class VisualInteractable : MyMonoBehaviour, IVisualState
{
    [SerializeField] private Image                img;
    [SerializeField] private VisualClickAnimation clickAnim;

    private bool _resetOnDisable = true;
    private PresetClickableVisual _visualPreset;


    public void SetVisualPreset(VisualStyle visualStyle)
    {
        _visualPreset = UiThemeManager.Instance.GetPreset().GetVisual(visualStyle);
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
        if (!_visualPreset)
        {
            return;
        }

        img.color = _visualPreset.colorDefault;

        if (_visualPreset.spriteDefault)
        {
            img.sprite = _visualPreset.spriteDefault;
        }
    }

    public void ResetStateOnDisable(bool isReset)
    {
        _resetOnDisable = isReset;
    }

    public void OnClick()
    {
        if (!_visualPreset)
        {
            return;
        }

        img.color = _visualPreset.colorClick;

        if (_visualPreset.spriteClick)
        {
            img.sprite = _visualPreset.spriteClick;
        }

        if (clickAnim)
        {
            clickAnim.StartAnimation();
        }
    }

    public void OnMouseEnter()
    {
        if (!_visualPreset)
        {
            return;
        }

        img.color = _visualPreset.colorHover;

        if (_visualPreset.spriteHover)
        {
            img.sprite = _visualPreset.spriteHover;
        }
    }

    public void OnMouseExit()
    {
        DefaultState();
    }

    public void OnDisabled()
    {
        if (!_visualPreset)
        {
            return;
        }

        img.color = _visualPreset.colorDisabled;

        if (_visualPreset.spriteDisabled)
        {
            img.sprite = _visualPreset.spriteDisabled;
        }
    }
}
