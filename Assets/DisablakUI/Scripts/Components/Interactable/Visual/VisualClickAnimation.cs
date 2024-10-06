using System.Collections;
using UnityEngine;


public class VisualClickAnimation : MonoBehaviour
{
    private Vector2 _startSize;
    
    private const float CLICK_ANIM_TIME = 0.1f;
    private const float CLICK_ANIM_SIZE = 5;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startSize     = _rectTransform.sizeDelta;
    }
    
    private void OnDisable()
    {
        DefaultState();
    }

    private void DefaultState()
    {
        StopAllCoroutines();
        _rectTransform.sizeDelta = _startSize;
    }

    public void StartAnimation()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        StopAllCoroutines();
        StartCoroutine(clickAnimation());
        
        IEnumerator clickAnimation()
        {
            _rectTransform.sizeDelta = new Vector2(_startSize.x - CLICK_ANIM_SIZE, _startSize.y - CLICK_ANIM_SIZE);
            yield return new WaitForSecondsRealtime(CLICK_ANIM_TIME);
            DefaultState();
        }
    }
}
