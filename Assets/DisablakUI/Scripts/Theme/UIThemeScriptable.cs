using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(UIThemeScriptable), menuName = "ScriptableObjects/UITheme/" + nameof(UIThemeScriptable))]
public class UIThemeScriptable : ScriptableObject
{
    [Serializable]
    public class StyleClickable
    {
        public VisualStyle           type;
        public VisualInteractableScriptable _visualInteractableScriptable;
        public VisualIconAndLabelScriptable    _visualIconAndLabelScriptable;
    }

    [SerializeField] private List<StyleClickable> _stylePresets;


    public StyleClickable GetStyleClickable(VisualStyle type)
    {
        return _stylePresets.FirstOrDefault(x => x.type == type);
    }

    public VisualInteractableScriptable GetVisual(VisualStyle type)
    {
        StyleClickable style = GetStyleClickable( type );
        if (style == null)
        {
            Debug.LogWarning($"Style {type} not found");
            return null;
        }

        if (style._visualInteractableScriptable == null)
        {
            Debug.LogWarning($"Style Visual {type} not found");
            return null;
        }

        return style._visualInteractableScriptable;
    }

    public VisualIconAndLabelScriptable GetIconAndLabel(VisualStyle type)
    {
        StyleClickable style = GetStyleClickable( type );
        if (style == null)
        {
            Debug.LogError($"Style {type} not found");
            return null;
        }

        if (style._visualIconAndLabelScriptable == null)
        {
            Debug.LogError($"Style Icon and Label {type} not found");
            return null;
        }

        return style._visualIconAndLabelScriptable;
    }
}


public enum VisualStyle
{
    None = 0,

    ButtonDefault = 1,
    ButtonSpecial = 2,

    ToggleDefault = 3,
}