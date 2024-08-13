using UnityEngine;
using UnityEngine.UI;

public class InputFieldHandler : MonoBehaviour
{
    [SerializeField] private InputField _inputField = default;
    [SerializeField] private Search _search = default;

    private void Start()
    {
        // InputFieldの値が変更されたときに呼ばれるメソッドを設定
        _inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string newValue)
    {
        _search.SearchWord = newValue;
        // 入力された値を処理
        Debug.Log("InputField Value: " + newValue);
    }
}