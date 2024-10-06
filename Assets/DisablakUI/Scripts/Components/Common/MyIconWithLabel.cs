using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(MyHorizontalLayout))]
public class MyIconWithLabel : MonoBehaviour
{
    [SerializeField] private Image              _imgIcon;
    [SerializeField] private TextMeshProUGUI    _txtLabel;
    [SerializeField] private MyHorizontalLayout _horizontalLayout;


    public void SetIconSprite(Sprite sprite)
    {
        if (_imgIcon)
            _imgIcon.sprite = sprite;
    }
    
    public void SetLabelText(string text)
    {
        _txtLabel.SetText(text);
        _horizontalLayout.Layout();
    }
    
    public void SetIconActive(bool active)
    {
        _imgIcon.gameObject.SetActive(active);
        _horizontalLayout.Layout();
    }

    public string GetLabel()
    {
        return _txtLabel.text;
    }
}
