using UnityEngine;

public class SampleUi : MonoBehaviour
{
    [SerializeField] private MyButton _buttonDefault;
    [SerializeField] private MyButton _buttonSpecial;


    private void Start()
    {
        _buttonDefault.IconWithLabel.SetLabelText("Default Button");
        _buttonDefault.OnClick += () => { Debug.Log("click default"); };

        _buttonSpecial.IconWithLabel.SetLabelText("Special Button");
        _buttonSpecial.OnClick += () => { Debug.Log("click special"); };
    }
}
