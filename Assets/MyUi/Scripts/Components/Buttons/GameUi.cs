using UnityEngine;


 public class GameUi : MonoBehaviour
{
    [SerializeField] private UIPresetScriptable _uiPreset;


    public static GameUi Instance;


    private void Awake()
    {
        Instance = this;
    }

    public UIPresetScriptable GetUiPreset()
    {
        return _uiPreset;
    }
}
