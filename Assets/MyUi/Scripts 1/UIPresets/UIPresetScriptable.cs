using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(UIPresetScriptable), menuName = "ScriptableObjects/UIPreset/" + nameof(UIPresetScriptable))]
public class UIPresetScriptable : ScriptableObject
{
    [Serializable]
    public class VisualComponentTypeToPreset
    {
        public VisualStyle            type;
        public PresetClickableVisual   visual;
        public PresetIconAndLabel iconAndLabel;
    }

    [Serializable]
    public class ImagePreset
    {
        public VisualStyle type;
        public Color color = Color.white;
        public Sprite sprite;
    }

    public List<VisualComponentTypeToPreset> typePresets;
    public List<ImagePreset>                 imagePresets;


    public PresetClickableVisual GetVisual(VisualStyle type)
    {
        return typePresets.First(x => x.type == type).visual;
    }

    public PresetIconAndLabel GetIconAndLabel(VisualStyle type)
    {
        return typePresets.First(x => x.type == type).iconAndLabel;
    }

    public ImagePreset GetImagePreset(VisualStyle type)
    {
        return imagePresets.First(x => x.type == type);
    }
}


public enum VisualStyle
{
    None = 0,

    ButtonDefault = 1,
    ButtonSpecial = 2
}