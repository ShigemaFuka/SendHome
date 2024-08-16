using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

/// <summary>
/// 失敗時の依頼人のセリフ
/// 次の依頼を受けるかどうかの選択ボタンを表示
/// </summary>
public class DisplayListText : MonoBehaviour
{
    [SerializeField, Header("文字送りの速度")] private float _speed = 1f;
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
            //2秒でテキスト表示(表示間隔は一定)
            // _displayText.DOText(_messages[_currentIndex], 2).SetEase(Ease.Linear);
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

        // _displayText.text = _messages[_currentIndex];
        // 2秒でテキスト表示(表示間隔は一定)
        _displayText.text = string.Empty;
        _displayText.DOText(_messages[_currentIndex], _speed).SetEase(Ease.Linear);
    }
}