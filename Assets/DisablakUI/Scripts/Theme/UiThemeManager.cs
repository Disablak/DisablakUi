using UnityEngine;


public class UiThemeManager : MonoBehaviour
{
    [SerializeField] private UIThemeScriptable _defaultTheme;

    private static UiThemeManager _instance = null;

    public static UiThemeManager Instance
    {
        get
        {
            if (!_instance)
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

    public UIThemeScriptable GetPreset()
    {
        return _defaultTheme;
    }
}
