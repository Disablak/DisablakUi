using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class MySliderWithLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtValue;
    
    private Slider _slider;
    
    public Slider Slider
    {
        get
        {
            if (_slider)
                return _slider;
            
            _slider = GetComponent<Slider>();
            return _slider; 
        }
    }

    private void Awake()
    {
        Slider.onValueChanged.AddListener(OnValueChange);
    }

    private void OnValueChange(float value)
    {
        SetTextValue(value);
    }

    public void Init(float minValue, float maxValue, float value)
    {
        Slider.minValue = minValue;
        Slider.maxValue = maxValue;
        Slider.SetValueWithoutNotify(value);
        SetTextValue(value);
    }
    
    private void SetTextValue(float value)
    {
        txtValue.text = $"{value:0.##}";
    }
}
