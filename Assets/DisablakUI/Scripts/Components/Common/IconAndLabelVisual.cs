using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class IconAndLabelVisual : MyMonoBehaviour, IVisualState
{
    [SerializeField] private Color colorDefault      = Color.white;
    [SerializeField] private Color iconColorDefault  = Color.white;
    [SerializeField] private Color colorSelected     = Color.white;
    [SerializeField] private Color iconColorSelected = Color.white;
    [SerializeField] private Color colorDisabled     = Color.white;
    [SerializeField] private Color iconColorDisabled = Color.white;
    [Space]
    [SerializeField] private Image imgIcon;
    [SerializeField] private TextMeshProUGUI txtLabel;
    
    private bool               _resetOnDisable = true;

    

    private void OnDisable()
    {
        if (_resetOnDisable)
        {
            ColorToDefault();
        }
    }

    private void ColorToDefault()
    {
        if (imgIcon)
            imgIcon.color = iconColorDefault;
        
        txtLabel.color = colorDefault;
    }
    
    private void ColorToSelected()
    {
        if (imgIcon)
            imgIcon.color = iconColorSelected;
        
        txtLabel.color = colorSelected;
    }

    void IVisualState.ResetStateOnDisable(bool isReset)
    {
        _resetOnDisable = isReset;
    }

    void IVisualState.OnClick()
    {
        ColorToSelected();
    }

    void IVisualState.OnMouseEnter()
    {
        ColorToSelected();
    }

    void IVisualState.OnMouseExit()
    {
        ColorToDefault();
    }

    void IVisualState.OnDisabled()
    {
        if (imgIcon)
            imgIcon.color = iconColorDisabled;
        
        txtLabel.color = colorDisabled;
    }
}
