using System;
using UnityEngine;


[RequireComponent(typeof(MyToggleGroup))]
public class MyToggleGroupPrevNext : MonoBehaviour
{
    private MyToggleGroup _toggleGroup;
    private int           _curStepId = -1;
    private int           _countElements = -1;
    private Action<int>   _onActivateElement = null;
    
    private void Awake()
    {
        _toggleGroup = GetComponent<MyToggleGroup>();
        _toggleGroup.OnToggleActivated += OnClickPrevNext;
    }
    
    private void OnClickPrevNext(int id, bool _)
    {
        if (id == 0)
        {
            ChangeStep(_curStepId - 1);
        }else
        {
            ChangeStep(_curStepId + 1);
        }
    }
    
    private void ChangeStep(int id)
    {
        int prevPage = _curStepId;
        _curStepId = Mathf.Clamp(id, 0, _countElements - 1);
        
        if (prevPage == _curStepId)
        {
            return;
        }

        _onActivateElement?.Invoke(_curStepId);
    }
    
    public void Init(int countElements, Action<int> onActivateElement)
    {
        _curStepId = 0;
        _countElements = countElements;
        _onActivateElement = onActivateElement;
    }
}
