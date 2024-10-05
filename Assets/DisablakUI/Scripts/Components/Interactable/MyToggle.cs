using System;
using System.Collections.Generic;
using UnityEngine;


public class MyToggle : MyInteractable
{
    [Header(nameof(MyToggle))]
    [SerializeField] private VisualInteractable _visualInteractable;
    [SerializeField] private VisualIconAndLabel _visualIconAndLabel;
    [SerializeField] private MyIconWithLabel    _iconWithLabel;
    [Space]
    [SerializeField] private List<GameObject> _objectsShowOnActiveState;

    private int _toggleId = -1;
    private ToggleState _toggleState = ToggleState.Default;

    public Action<int, ToggleState> OnToggleChanged = null;
    
    public int ToggleId => _toggleId;



    public void Init(int id)
    {
        _visualInteractable.SetVisualPreset(_visualStyle);
        _visualIconAndLabel.SetVisualPreset(_visualStyle);

        _toggleId = id;
        ChangeVisualState(_toggleState);

        _visualInteractable.ResetStateOnDisable(false);
        _visualIconAndLabel.ResetStateOnDisable(false);
    }

    public void AddObjectToVisualShow(GameObject showObject)
    {
        _objectsShowOnActiveState.Add(showObject);
    }

    protected override void OnChangeInteractable()
    {
        _toggleState = IsInteractable ? ToggleState.Default : ToggleState.Disabled;
        ChangeVisualState(_toggleState);
    }

    protected override void OnPointerClick()
    {
        OnToggleChanged?.Invoke(_toggleId, ToggleState.Selected);
    }

    protected override void OnEnter()
    {
        OnToggleChanged?.Invoke(_toggleId, ToggleState.Hover);
    }

    protected override void OnExit()
    {
        OnToggleChanged?.Invoke(_toggleId, ToggleState.Default);
    }

    protected virtual void OnStateDefault()
    {
        _visualInteractable.OnMouseExit();
        _visualIconAndLabel.OnMouseExit();

        foreach (GameObject obj in _objectsShowOnActiveState)
        {
            obj.SetActive(false);
        }
    }
    
    protected virtual void OnStateHover()
    {
        _visualInteractable.OnMouseEnter();
        _visualIconAndLabel.OnMouseEnter();
    }

    protected virtual void OnStateSelected()
    {
        _visualInteractable.OnClick();
        _visualIconAndLabel.OnClick();

        foreach (GameObject obj in _objectsShowOnActiveState)
        {
            obj.SetActive(true);
        }
    }
    
    protected virtual void OnStateDisabled()
    {
        _visualInteractable.OnDisabled();
        _visualIconAndLabel.OnDisabled();
    }
    
    public void ChangeVisualState(ToggleState state)
    {
        _toggleState = state;
        
        if (!IsInteractable)
        {
            _toggleState = ToggleState.Disabled;
        }
        
        switch (_toggleState)
        {
        case ToggleState.Default:
            OnStateDefault();
            break;
        
        case ToggleState.Hover:
            OnStateHover();
            break;
        
        case ToggleState.Selected:
            OnStateSelected();
            break;
        
        case ToggleState.Disabled:
            OnStateDisabled();
            break;
        
        default: throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    public void SetText(string text)
    {
        if (_iconWithLabel)
        {
            _iconWithLabel.SetLabelText(text);
        }
    }

    public void SetIcon(Sprite icon)
    {
        if (_iconWithLabel)
        {
            _iconWithLabel.SetIconSprite(icon);
        }
    }
}

public enum ToggleState
{
    Default,
    Hover,
    Selected,
    Disabled,
}
