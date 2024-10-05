using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class VisualIconAndLabel : MyMonoBehaviour, IVisualState
{
    [SerializeField] private Image           imgIcon;
    [SerializeField] private TextMeshProUGUI txtLabel;

    private bool               _resetOnDisable = true;
    private PresetIconAndLabel _presetIconAndLabel;


    public void SetVisualPreset(VisualStyle visualStyle)
    {
        _presetIconAndLabel = UiThemeManager.Instance.GetPreset().GetIconAndLabel(visualStyle);
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
        if (!_presetIconAndLabel)
        {
            return;
        }

        if (imgIcon)
            imgIcon.color = _presetIconAndLabel.iconColorDefault;

        txtLabel.color = _presetIconAndLabel.labelColorDefault;
    }

    private void ColorToSelected()
    {
        if (!_presetIconAndLabel)
        {
            return;
        }

        if (imgIcon)
            imgIcon.color = _presetIconAndLabel.iconColorSelected;

        txtLabel.color = _presetIconAndLabel.labelColorSelected;
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
        if (!_presetIconAndLabel)
        {
            return;
        }

        if (imgIcon)
            imgIcon.color = _presetIconAndLabel.iconColorDisabled;

        txtLabel.color = _presetIconAndLabel.labelColorDisabled;
    }
}
