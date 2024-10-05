using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class VisualIconAndLabel : MyMonoBehaviour, IVisualState
{
    [SerializeField] private Image           imgIcon;
    [SerializeField] private TextMeshProUGUI txtLabel;

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

        if (imgIcon)
            imgIcon.color = visualIconAndLabelScriptable.iconColorDefault;

        txtLabel.color = visualIconAndLabelScriptable.labelColorDefault;
    }

    private void ColorToSelected()
    {
        if (!visualIconAndLabelScriptable)
        {
            return;
        }

        if (imgIcon)
            imgIcon.color = visualIconAndLabelScriptable.iconColorSelected;

        txtLabel.color = visualIconAndLabelScriptable.labelColorSelected;
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

        if (imgIcon)
            imgIcon.color = visualIconAndLabelScriptable.iconColorDisabled;

        txtLabel.color = visualIconAndLabelScriptable.labelColorDisabled;
    }
}
