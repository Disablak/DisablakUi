using UnityEngine;


[CreateAssetMenu(fileName = nameof(VisualInteractableScriptable), menuName = "ScriptableObjects/UITheme/" + nameof(VisualInteractableScriptable))]
public class VisualInteractableScriptable : ScriptableObject
{
    public Color colorDefault;
    public Color colorClick;
    public Color colorHover;
    public Color colorDisabled;
    [Space]
    public Sprite spriteDefault;
    public Sprite spriteClick;
    public Sprite spriteHover;
    public Sprite spriteDisabled;
}
