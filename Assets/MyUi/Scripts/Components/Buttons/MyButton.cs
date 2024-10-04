using System;
using UnityEngine;


public class MyButton : MyInteractable
{
    [Header(nameof(MyButton))]
    [SerializeField] private VisualComponent             _visualBackground;
    [SerializeField] private VisualIconAndLabelComponent _visualIconAndLabel;
    [SerializeField] private MyIconWithLabel             _iconWithLabel;

    public event Action OnClick = delegate {};
    
    public MyIconWithLabel IconWithLabel => _iconWithLabel;


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
            if (_visualBackground)
            {
                _visualBackground.OnMouseExit();
            }
            if (_visualIconAndLabel)
            {
                _visualIconAndLabel.OnMouseExit();
            }
        }else
        {
            if (_visualBackground)
            {
                _visualBackground.OnDisabled();
            }
            if (_visualIconAndLabel)
            {
                _visualIconAndLabel.OnDisabled();
            }
        }
    }

    protected override void OnPointerClick()
    {
        if (_visualBackground)
        {
            _visualBackground.OnClick();
        }
        if (_visualIconAndLabel)
        {
            _visualIconAndLabel.OnClick();
        }

        OnClick?.Invoke();
    }

    protected override void OnEnter()
    {
        if (_visualBackground)
        {
            _visualBackground.OnMouseEnter();
        }
        if (_visualIconAndLabel)
        {
            _visualIconAndLabel.OnMouseEnter();
        }
    }

    protected override void OnExit()
    {
        if (_visualBackground)
        {
            _visualBackground.OnMouseExit();
        }
        if (_visualIconAndLabel)
        {
            _visualIconAndLabel.OnMouseExit();
        }
    }
}
