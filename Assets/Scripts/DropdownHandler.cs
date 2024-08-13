using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ドロップダウンで選択された項目の文字列を取得
/// </summary>
public class DropdownHandler : MonoBehaviour
{
    [SerializeField] private Dropdown _dropdown = default;

    private void Start()
    {
        // Dropdownの値が変更されたときに呼ばれるメソッドを設定
        _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // 初期選択されたアイテムの文字列を取得
        UpdateSelectedItemText(_dropdown.value);
    }

    private void OnDropdownValueChanged(int index)
    {
        // 選択されたアイテムの文字列を取得
        UpdateSelectedItemText(index);
    }

    /// <summary>
    /// 初期選択されている項目も記録
    /// </summary>
    /// <param name="index"></param>
    private void UpdateSelectedItemText(int index)
    {
        if (_dropdown.options.Count > index)
        {
            var selectedItemText = _dropdown.options[index].text;
            Debug.Log("Selected Item: " + selectedItemText);
        }
    }
}