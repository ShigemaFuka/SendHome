using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// JSONファイルのデータを表示
/// </summary>
public class ShowNameList : MonoBehaviour
{
    [SerializeField] private Text[] _texts = default;
    private SaveLoadManager _saveLoadManager = default;

    private void Start()
    {
        _saveLoadManager = FindObjectOfType<SaveLoadManager>();
    }

    public void OnClick()
    {
        var list = _saveLoadManager.Load();
        list.Sort();
        DisplayText(list);
    }

    private void DisplayText(List<string> list)
    {
        foreach (var text in _texts)
        {
            text.text = "";
        }

        // 1つのテキストコンポーネントあたりのアイテム数を計算
        var itemsPerText = Mathf.CeilToInt((float)list.Count / _texts.Length);

        // List の要素をテキストコンポーネントごとに分割して表示
        for (var i = 0; i < list.Count; i++)
        {
            var textIndex = i / itemsPerText; // どのテキストコンポーネントに表示するか
            if (textIndex < _texts.Length)
            {
                _texts[textIndex].text += $"[{i + 1}]{list[i]}\n";
            }
        }
    }
}