using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MyToggleGroup : MonoBehaviour
{
    [SerializeField] private int startActiveToggleId = 0;
    [SerializeField] private bool initOnStart = true;
    [SerializeField] private bool multiSelect = false;
    
    private List<MyToggle> _toggles        = new List<MyToggle>();
    private List<int>      _selectedIds    = new List<int>();

    public int CountToggles => _toggles.Count;
    public List<MyToggle> Toggles => _toggles;
    public List<int> SelectedToggleIds => _selectedIds;

    public event Action<int, bool> OnToggleActivated = delegate { }; // id, is mouse click
    public event Action<int, ToggleState> OnToggleStateChanged = delegate {}; // id, state

    
    private void Start()
    {
        if (initOnStart)
        {
            InitAllToggles();
        }
    }

    public void InitAllToggles(bool activateStartToggle = true)
    {
        _selectedIds = new List<int>();
        _toggles     = GetComponentsInChildren<MyToggle>().ToList();

        for (int i = 0; i < _toggles.Count; i++)
        {
            _toggles[i].Init(i);
            _toggles[i].OnToggleChanged = OnToggleChanged;
        }

        if (activateStartToggle)
        {
            ActivateToggle(startActiveToggleId);
        }
    }

    private void OnToggleChanged(int id, ToggleState toggleState)
    {
        //if (!multiSelect)
        //{
        //    if (toggleState == ToggleState.Selected && _selectedIds.Contains(id))
        //        return;
        //}

        ToggleChangeState(id, toggleState, true);
    }

    private void ToggleChangeState(int toggleId, ToggleState toggleState, bool isMouseClick)
    {
        if (toggleId < 0 || _toggles.Count <= toggleId)
        {
            return;
        }

        switch (toggleState)
        {
        case ToggleState.Default:
            if (!_selectedIds.Contains(toggleId))
            {
                _toggles[toggleId].ChangeVisualState(ToggleState.Default);
            }
            break;
        
        case ToggleState.Hover:
            _toggles[toggleId].ChangeVisualState(ToggleState.Hover);
            break;
        
        case ToggleState.Selected:
            if (multiSelect)
            {
                if (_selectedIds.Contains(toggleId))
                {
                    _toggles[toggleId].ChangeVisualState(ToggleState.Default);
                    _selectedIds.Remove(toggleId);
                    OnToggleStateChanged?.Invoke(toggleId, toggleState);
                    return;
                }
            }
            else
            {
                AllTogglesToDefaultState();
            }

            _toggles[toggleId].ChangeVisualState(ToggleState.Selected);
            _selectedIds.Add(toggleId);

            OnToggleActivated?.Invoke(toggleId, isMouseClick);
            break;
        
        default: throw new ArgumentOutOfRangeException(nameof(toggleState), toggleState, null);
        }

        OnToggleStateChanged?.Invoke(toggleId, toggleState);
    }

    public void ActivateToggle(int id, bool force = false)
    {
        if (_selectedIds.Contains(id) && !force)
            return;
        
        ToggleChangeState(id, ToggleState.Selected, false);
    }
    
    public void AllTogglesToDefaultState()
    {
        _selectedIds.Clear();

        foreach (MyToggle toggle in _toggles)
        {
            toggle.ChangeVisualState(ToggleState.Default);
        }
    }

    public MyToggle GetToggle(int id)
    {
        if (_toggles == null)
            _toggles = GetComponentsInChildren<MyToggle>().ToList();
        
        if (_toggles != null && _toggles.Count - 1 >= id)
            return _toggles[id];
        
        return null;
    }

    public void SetStartToggle(int id)
    {
        startActiveToggleId = id;
    }
}
