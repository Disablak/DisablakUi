using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MyHorizontalLayout : MyMonoBehaviour
{
    //[Observe(nameof(Layout))]
    [SerializeField] private HorizontalLayoutType layoutType = HorizontalLayoutType.Center;
    [SerializeField] private float spacing = 10.0f;
    [SerializeField] private bool invertSort = false;
    
    private void Start()
    {
        Layout();
    }

    public void Layout()
    {
        if (layoutType == HorizontalLayoutType.None)
        {
            return;
        }

        if (invertSort && Application.isPlaying)
        {
            List<Transform> children = GetActiveChildren();
            foreach (Transform child in children)
            {
                child.SetAsFirstSibling();
            }
        }
        
        switch (layoutType)
        {
        case HorizontalLayoutType.Left:
            LayoutChildren(0.0f);
            break;
        
        case HorizontalLayoutType.Center: 
            float totalWidth = GetTotalChildrenWidth();
            float rectHalfWidth = RectTransform.rect.width / 2.0f;
            float startX = rectHalfWidth - (totalWidth / 2f);
            LayoutChildren(startX);
            break;
        
        default: throw new ArgumentOutOfRangeException();
        }
    }
    
    private float GetTotalChildrenWidth()
    {
        float totalWidth = 0f;
        
        List<Transform> children = GetActiveChildren();
        for (int i = 0; i < children.Count; i++)
        {
            Transform child = children[i];
            float     space = i == children.Count - 1 ? 0.0f : spacing;
            totalWidth += GetWidth(child) + space;
        }
        
        return totalWidth;
    }
    
    private float GetWidth(Transform childTransform)
    {
        if (childTransform.TryGetComponent(typeof(TextMeshProUGUI), out Component textMeshPro))
        {
            TextMeshProUGUI textMeshProUGUI = (TextMeshProUGUI)textMeshPro;
            return textMeshProUGUI.preferredWidth;
        }
           
        RectTransform childRectTransform = childTransform.GetComponent<RectTransform>();
        return childRectTransform.rect.width;
    }
    
    private List<Transform> GetActiveChildren()
    {
        List<Transform> activeChildren = new();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.activeInHierarchy)
            {
                activeChildren.Add(child);
            }
        }
        
        return activeChildren;
    }
    
    private void LayoutChildren(float startX)
    {
        float           currentX = startX;
        List<Transform> children = GetActiveChildren();
        for (int i = 0; i < children.Count; i++)
        {
            Transform child = children[i];
            RectTransform childRectTransform = child.GetComponent<RectTransform>();
            float space = i == children.Count - 1 ? 0.0f : spacing;
            childRectTransform.anchoredPosition = new Vector2(currentX, 0f);
            currentX += GetWidth(child) + space;
        }
    }
}


public enum HorizontalLayoutType
{
    None,
    Left,
    Center
}