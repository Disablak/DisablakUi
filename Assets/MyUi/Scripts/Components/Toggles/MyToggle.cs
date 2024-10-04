using System;
using System.Collections.Generic;
using UnityEngine;


public class MyToggle : MyInteractable
{
    [Header(nameof(MyToggle))]
    [SerializeField] private   VisualStyle         _visualType;
    [SerializeField] private   VisualComponent             _visualBackground;
    [SerializeField] private   VisualIconAndLabelComponent _visualIconAndLabel;
    [SerializeField] protected MyIconWithLabel             _iconWithLabel;
    [Space]
    [SerializeField] private List<GameObject> objectsShowOnActiveState;

    private int _toggleId = -1;
    private ToggleState _toggleState = ToggleState.Default;
    [SerializeField] private bool _isHoverEnable = true;

    public Action<int, ToggleState> OnToggleChanged = null;
    
    public int ToggleId => _toggleId;
    
    public bool IsHoverEnable => _isHoverEnable;


    public void Init(int id)
    {
        if (_visualBackground)
            _visualBackground.SetVisualPreset(_visualType);

        if (_visualIconAndLabel)
            _visualIconAndLabel.SetVisualPreset(_visualType);

        _toggleId = id;
        ChangeVisualState(_toggleState);

        if (_visualBackground)
            _visualBackground.ResetStateOnDisable(false);
        if (_visualIconAndLabel)
            _visualIconAndLabel.ResetStateOnDisable(false);
    }

    public void AddObjectToVisualShow(GameObject showObject)
    {
        objectsShowOnActiveState.Add(showObject);
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
        if (IsHoverEnable)
        {
            OnToggleChanged?.Invoke(_toggleId, ToggleState.Hover);
        }
    }

    protected override void OnExit()
    {
        if (IsHoverEnable)
        {
            OnToggleChanged?.Invoke(_toggleId, ToggleState.Default);
        }
    }

    protected virtual void OnStateDefault()
    {
        if (_visualBackground)
            _visualBackground.OnMouseExit();
        if (_visualIconAndLabel)
            _visualIconAndLabel.OnMouseExit();

        foreach (GameObject obj in objectsShowOnActiveState)
        {
            obj.SetActive(false);
        }
    }
    
    protected virtual void OnStateHover()
    {
        if (_visualBackground)
            _visualBackground.OnMouseEnter();
        if (_visualIconAndLabel)
            _visualIconAndLabel.OnMouseEnter();
    }

    protected virtual void OnStateSelected()
    {
        if (_visualBackground)
            _visualBackground.OnClick();
        if (_visualIconAndLabel)
            _visualIconAndLabel.OnClick();

        foreach (GameObject obj in objectsShowOnActiveState)
        {
            obj.SetActive(true);
        }
    }
    
    protected virtual void OnStateDisabled()
    {
        if (_visualBackground)
            _visualBackground.OnDisabled();
        if (_visualIconAndLabel)
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
