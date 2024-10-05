using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class PresetChangeImage : MyMonoBehaviour
{
    public VisualStyle imagePresetType;

    private void Awake()
    {
        /*var image = GetComponent<Image>();
        var imgPreset = GameSettings.CurrentUIPreset.GetImagePreset(imagePresetType);

        image.sprite = image.sprite;
        image.color = imgPreset.color;
        if (imgPreset.sprite)
        {
            image.sprite = imgPreset.sprite;
        }*/
    }
}
