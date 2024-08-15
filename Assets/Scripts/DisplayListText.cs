using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayListText : MonoBehaviour
{
    [SerializeField] private Text _displayText = default; // 表示するテキストコンポーネント
    [SerializeField] [TextArea(1, 3)] private List<string> _messages = default;
    [SerializeField, Header("表示したいObj")] private GameObject[] _gameObjects = default;
    private int _currentIndex = 0; // 現在表示しているリストのインデックス

    private void Start()
    {
        // 初期表示
        if (_messages.Count > 0)
        {
            _displayText.text = _messages[_currentIndex];
        }
    }

    public void OnClick()
    {
        _currentIndex++;
        if (_currentIndex >= _messages.Count)
        {
            foreach (var go in _gameObjects) go.SetActive(true);
            return;
        }

        _displayText.text = _messages[_currentIndex];
    }
}