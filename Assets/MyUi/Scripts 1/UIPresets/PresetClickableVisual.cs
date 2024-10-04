using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(PresetClickableVisual), menuName = "ScriptableObjects/UIPreset/" + nameof(PresetClickableVisual))]
public class PresetClickableVisual : ScriptableObject
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
