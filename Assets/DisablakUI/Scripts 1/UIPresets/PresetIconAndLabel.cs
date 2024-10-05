using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(PresetIconAndLabel), menuName = "ScriptableObjects/UIPreset/" + nameof(PresetIconAndLabel))]
public class PresetIconAndLabel : ScriptableObject
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
