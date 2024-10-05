public interface IVisualState
{
    void ResetStateOnDisable(bool isReset);
    void OnClick();
    void OnMouseEnter();
    void OnMouseExit();
    void OnDisabled();
}