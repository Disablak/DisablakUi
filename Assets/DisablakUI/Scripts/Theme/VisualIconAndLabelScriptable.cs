using UnityEngine;


[CreateAssetMenu(fileName = nameof(VisualIconAndLabelScriptable), menuName = "ScriptableObjects/UITheme/" + nameof(VisualIconAndLabelScriptable))]
public class VisualIconAndLabelScriptable : ScriptableObject
{
    public Color labelColorDefault;
    public Color iconColorDefault;
    [Space]
    public Color labelColorSelected;
    public Color iconColorSelected;
    [Space]
    public Color labelColorDisabled;
    public Color iconColorDisabled;
}
