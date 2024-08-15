using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSplitter : MonoBehaviour
{
    [SerializeField] private Text[] _textBoxes = default;

    [SerializeField, Header("各テキストボックスに表示する文字数の制限")]
    private int _charactersPerBox = 100;

    // [SerializeField] [TextArea(1, 10)] private string _textMessage = default;
    [SerializeField] private List<string> _textMessageList = default;

    // public string TextMessage
    // {
    //     get => _textMessage;
    //     set => _textMessage = value;
    // }

    private void Start()
    {
        // _textMessage = string.Empty;
        foreach (var text in _textBoxes) text.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayText();
        }
    }

    public void AddMemo(string str)
    {
        // 重複させない
        if (!_textMessageList.Contains(str))
            _textMessageList.Add(str);
    }

    // リストの内容をテキストボックスに表示するメソッド
    public void DisplayText()
    {
        if (_textBoxes.Length == 0 || _textMessageList.Count == 0)
            return;

        string combinedText = string.Join("\n", _textMessageList);
        int boxIndex = 0;

        // 各テキストボックスにテキストを設定
        while (boxIndex < _textBoxes.Length && combinedText.Length > 0)
        {
            // 現在のテキストボックスに表示するテキストを取得
            string textToDisplay = GetTextForBox(ref combinedText);
            _textBoxes[boxIndex].text = textToDisplay;
            boxIndex++;
        }
    }

    // テキストを指定された文字数制限で分割するメソッド
    private string GetTextForBox(ref string text)
    {
        // テキストボックスに設定するテキストの長さを決定
        int displayLength = Mathf.Min(_charactersPerBox, text.Length);
        string textToDisplay = text.Substring(0, displayLength);

        // 残りのテキストを更新
        text = text.Substring(displayLength).Trim();

        return textToDisplay;
    }
}