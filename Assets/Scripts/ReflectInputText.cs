using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// インプットフィールドで入力した文字列が縦書きにできなかった
/// （テキストコンポーネントがRichだとダメだと警告マークが出た）
/// ため、自作スクリプトで直接テキストコンポーネントを指定して表示
/// </summary>
public class ReflectInputText : MonoBehaviour
{
    [SerializeField] private InputField _inputField = default; // 入力フィールド
    [SerializeField] private Text _targetText = default; // テキストを表示する対象のTextコンポーネント

    private void Start()
    {
        // 入力フィールドの値が変更されたときに呼ばれるメソッドを登録
        _inputField.onValueChanged.AddListener(UpdateText);
        // 初期値を反映させる
        UpdateText(_inputField.text);
    }

    private void UpdateText(string newText)
    {
        // 入力フィールドのテキストを対象のTextコンポーネントに反映させる
        _targetText.text = newText;
    }

    private void OnDestroy()
    {
        // スクリプトが破棄されるときにリスナーを解除
        _inputField.onValueChanged.RemoveListener(UpdateText);
    }
}