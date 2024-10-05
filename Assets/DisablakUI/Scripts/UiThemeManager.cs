using System;
using UnityEngine;

public class UiThemeManager : MonoBehaviour
{
    [SerializeField] private UIPresetScriptable _defaultPreset;


    private static UiThemeManager _instance = null;
    public static UiThemeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UiThemeManager>();
            }

            return _instance;
        }
        private set => _instance = value;
    }


    private void Awake()
    {
        Instance = this;
    }

    public UIPresetScriptable GetPreset()
    {
        return _defaultPreset;
    }
}
