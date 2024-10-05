using System;
using UnityEngine;


public class MyButton : MyInteractable
{
    [Header(nameof(MyButton))]
    [SerializeField] private VisualInteractable _visualInteractable;
    [SerializeField] private VisualIconAndLabel _visualIconAndLabel;
    [SerializeField] private MyIconWithLabel    _iconWithLabel;

    public event Action OnClick = delegate {};
    
    public MyIconWithLabel IconWithLabel => _iconWithLabel;


    protected void Awake()
    {
        _visualInteractable.SetVisualPreset(_visualStyle);
        _visualIconAndLabel.SetVisualPreset(_visualStyle);
    }

    private void OnEnable()
    {
        UpdateState();
    }

    protected override void OnChangeInteractable()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (IsInteractable)
        {
            _visualInteractable.OnMouseExit();
            _visualIconAndLabel.OnMouseExit();
        }else
        {
            _visualInteractable.OnDisabled();
            _visualIconAndLabel.OnDisabled();
        }
    }

    protected override void OnPointerClick()
    {
        _visualInteractable.OnClick();
        _visualIconAndLabel.OnClick();

        OnClick?.Invoke();
    }

    protected override void OnEnter()
    {
        _visualInteractable.OnMouseEnter();
        _visualIconAndLabel.OnMouseEnter();
    }

    protected override void OnExit()
    {
        _visualInteractable.OnMouseExit();
        _visualIconAndLabel.OnMouseExit();
    }
}
