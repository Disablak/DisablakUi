using System.Collections;
using UnityEngine;


public class VisualClickAnimation : MyMonoBehaviour
{
    private Vector2 _startSize;
    
    private const float CLICK_ANIM_TIME = 0.1f;
    private const float CLICK_ANIM_SIZE = 5;

    private void Awake()
    {
        _startSize = RectTransform.sizeDelta;
    }
    
    private void OnDisable()
    {
        DefaultState();
    }

    private void DefaultState()
    {
        StopAllCoroutines();
        RectTransform.sizeDelta = _startSize;
    }

    public void StartAnimation()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        StopAllCoroutines();
        StartCoroutine(ClickAnimation());
        
        IEnumerator ClickAnimation()
        {
            RectTransform.sizeDelta = new Vector2(_startSize.x - CLICK_ANIM_SIZE, _startSize.y - CLICK_ANIM_SIZE);
            yield return new WaitForSecondsRealtime(CLICK_ANIM_TIME);
            DefaultState();
        }
    }
}
