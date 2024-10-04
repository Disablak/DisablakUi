using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(VisualClickAnimation))]
public class VisualColor : MyMonoBehaviour, IVisualState
{
    [SerializeField] private Color colorDefault = Color.white;
    [SerializeField] private Color colorClick = Color.white;
    [SerializeField] private Color colorHover = Color.white;
    [SerializeField] private Color colorDisabled = new Color(1f,1f,1f, 0.5f);
    [Space]
    [SerializeField] private Image img;
    [SerializeField] private VisualClickAnimation clickAnim;

    private bool _resetOnDisable = true;
    

    private void OnDisable()
    {
        if (_resetOnDisable)
        {
            DefaultState();
        }
    }

    private void DefaultState()
    {
        img.color = colorDefault;
    }

    void IVisualState.ResetStateOnDisable(bool isReset)
    {
        _resetOnDisable = isReset;
    }

    void IVisualState.OnClick()
    {
        img.color = colorClick;
        if (clickAnim)
        {
            clickAnim.StartAnimation();
        }
    }

    void IVisualState.OnMouseEnter()
    {
        img.color = colorHover;
    }

    void IVisualState.OnMouseExit()
    {
        DefaultState();
    }

    void IVisualState.OnDisabled()
    {
        img.color = colorDisabled;
    }
}
