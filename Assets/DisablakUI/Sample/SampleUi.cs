using System.Collections.Generic;
using UnityEngine;

public class SampleUi : MonoBehaviour
{
    [SerializeField] private MyButton _buttonDefault;
    [SerializeField] private MyButton _buttonSpecial;
    [Space]
    [SerializeField] private MyToggleGroup _toggleGroup;
    [SerializeField] private MyToggle _togglePrefab;

    private readonly List<string> _toggleData = new List<string>()
    {
        "Toggle Left",
        "Toggle Right",
    };


    private void Start()
    {
        _buttonDefault.IconWithLabel.SetLabelText("Default Button");
        _buttonDefault.OnClick += () => { Debug.Log("click default"); };

        _buttonSpecial.IconWithLabel.SetLabelText("Special Button");
        _buttonSpecial.OnClick += () => { Debug.Log("click special"); };

        InitToggle();
    }

    private void InitToggle()
    {
        for (int i = 0; i < _toggleData.Count; i++)
        {
            MyToggle newToggle = Instantiate(_togglePrefab, _toggleGroup.transform);
            newToggle.SetText( _toggleData[i] );
        }

        _toggleGroup.OnToggleActivated += OnToggleActivated;
        _toggleGroup.InitAllToggles();
    }

    private void OnToggleActivated(int toggleId, bool isMouseClick)
    {
        Debug.Log( _toggleData[toggleId] );
    }
}
