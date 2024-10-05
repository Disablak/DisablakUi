using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class PresetChangeTextColor: MyMonoBehaviour
{
    public VisualStyle imagePresetType;


    private void Awake()
    {
        /*var text     = GetComponent<TextMeshProUGUI>();
        var textPreset = GameSettings.CurrentUIPreset.GetImagePreset(imagePresetType);

        text.color = textPreset.color;*/
    }
}