using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(UIPresetScriptable), menuName = "ScriptableObjects/UIPreset/" + nameof(UIPresetScriptable))]
public class UIPresetScriptable : ScriptableObject
{
    [Serializable]
    public class StyleClickable
    {
        public VisualStyle           type;
        public PresetClickableVisual visual;
        public PresetIconAndLabel    iconAndLabel;
    }

    [SerializeField] private List<StyleClickable>                 _stylePresets;


    public StyleClickable GetStyleClickable(VisualStyle type)
    {
        return _stylePresets.FirstOrDefault(x => x.type == type);
    }

    public PresetClickableVisual GetVisual(VisualStyle type)
    {
        StyleClickable style = GetStyleClickable( type );
        if (style == null)
        {
            Debug.LogWarning($"Style {type} not found");
            return null;
        }

        if (style.visual == null)
        {
            Debug.LogWarning($"Style Visual {type} not found");
            return null;
        }

        return style.visual;
    }

    public PresetIconAndLabel GetIconAndLabel(VisualStyle type)
    {
        StyleClickable style = GetStyleClickable( type );
        if (style == null)
        {
            Debug.LogError($"Style {type} not found");
            return null;
        }

        if (style.iconAndLabel == null)
        {
            Debug.LogError($"Style Icon and Label {type} not found");
            return null;
        }

        return style.iconAndLabel;
    }
}


public enum VisualStyle
{
    None = 0,

    ButtonDefault = 1,
    ButtonSpecial = 2,

    ToggleDefault = 3,
}