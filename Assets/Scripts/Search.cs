using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using Object = UnityEngine.Object;

public class Search : MonoBehaviour
{
    [SerializeField] private AyakashiDataBase _ayakashiDataBase = default;
    [SerializeField] private string _searchWord = default;
    [SerializeField] private Text _text = default;

    public string SearchWord
    {
        get => _searchWord;
        set => _searchWord = value;
    }

    private void Start()
    {
        ShowText("\n情報を表示します。");
    }

    private void Update()
    {
        // テスト
        if (Input.GetKeyDown(KeyCode.J))
        {
            DoSearch();
        }
    }

    /// <summary>
    /// ボタン押下時に呼び出す
    /// </summary>
    public void DoSearch()
    {
        var dataBase = _ayakashiDataBase;
        if (dataBase.AyakashiDataList.Count <= 0)
        {
            Debug.Log($"データベースの要素が0です。");
            return;
        }

        ShowText(string.Empty);
        foreach (var data in dataBase.AyakashiDataList)
        {
            // 名前検索の場合、その妖怪の全情報を表示する。
            if (data.Name.Contains(_searchWord))
            {
                PrintScriptableObjectValues(data);
                break;
            }

            // todo: 他の変数でもできるようにする。
            if (data.Age.ToString() == _searchWord)
            {
                // ageが一致するものすべての名前を出力
                ShowText(_text.text += "\n" + data.Name + "\n");
                Debug.Log(data.Name);
            }
            else
            {
                ShowText("\n該当するものが何もありませんでした。\n\nキーワードの変更や項目の変更を検討してください。" +
                         "\n\n依頼人の話にヒントがあるでしょう。\n");
            }
        }
    }

    /// <summary>
    /// データの変数の値をすべて出力する
    /// </summary>
    /// <param name="obj"></param>
    private void PrintScriptableObjectValues(Object obj)
    {
        if (obj == null)
        {
            Debug.LogWarning("data is null");
            return;
        }

        var objType = obj.GetType();
        var fields = objType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        ShowText(string.Empty);
        ShowText("\n"); // レイアウトの調整

        foreach (var field in fields)
        {
            var value = field.GetValue(obj);
            if (value is IList list)
            {
                Debug.Log($"{field.Name} (List) =");
                foreach (var item in list)
                {
                    ShowText(_text.text += item + $"\n\n");
                    Debug.Log($" - {item}");
                }
            }
            else
            {
                ShowText(_text.text += value + $"\n\n");
                Debug.Log(value);
            }
        }
    }

    private void ShowText(string str)
    {
        _text.text = str;
    }
}