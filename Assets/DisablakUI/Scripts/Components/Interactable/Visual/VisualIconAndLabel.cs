using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class VisualIconAndLabel : MonoBehaviour, IVisualState
{
    [SerializeField] private Image           _imgIcon;
    [SerializeField] private TextMeshProUGUI _txtLabel;

    private bool               _resetOnDisable = true;
    private VisualIconAndLabelScriptable visualIconAndLabelScriptable;


    public void SetVisualPreset(VisualStyle visualStyle)
    {
        visualIconAndLabelScriptable = UiThemeManager.Instance.GetPreset().GetIconAndLabel(visualStyle);
    }

    private void OnDisable()
    {
        if (_resetOnDisable)
        {
            ColorToDefault();
        }
    }

    private void ColorToDefault()
    {
        if (!visualIconAndLabelScriptable)
        {
            return;
        }

        if (_imgIcon)
            _imgIcon.color = visualIconAndLabelScriptable.iconColorDefault;

        _txtLabel.color = visualIconAndLabelScriptable.labelColorDefault;
    }

    private void ColorToSelected()
    {
        if (!visualIconAndLabelScriptable)
        {
            return;
        }

        if (_imgIcon)
            _imgIcon.color = visualIconAndLabelScriptable.iconColorSelected;

        _txtLabel.color = visualIconAndLabelScriptable.labelColorSelected;
    }

    public void ResetStateOnDisable(bool isReset)
    {
        _resetOnDisable = isReset;
    }

    public void OnClick()
    {
        ColorToSelected();
    }

    public void OnMouseEnter()
    {
        ColorToSelected();
    }

    public void OnMouseExit()
    {
        ColorToDefault();
    }

    public void OnDisabled()
    {
        if (!visualIconAndLabelScriptable)
        {
            return;
        }

        if (_imgIcon)
            _imgIcon.color = visualIconAndLabelScriptable.iconColorDisabled;

        _txtLabel.color = visualIconAndLabelScriptable.labelColorDisabled;
    }
}
