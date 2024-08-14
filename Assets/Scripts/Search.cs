using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
/// <summary>
/// 名前検索でヒットした場合は、対象の情報をすべて表示する。
/// 名前以外で一部でも一致していたら、対象となるすべての名前を出力する。
/// </summary>
public class Search : MonoBehaviour
{
    [SerializeField] private AyakashiDataBase _ayakashiDataBase = default;
    [SerializeField] private string _searchWord = default;
    [SerializeField] private Text _text = default;
    private bool _notFound = default;

    public string SearchWord
    {
        get => _searchWord;
        set => _searchWord = value;
    }

    private void Start()
    {
        ShowText("\n情報を表示します。");
    }

    /// <summary>
    /// ボタン押下時に呼び出す
    /// </summary>
    public void DoSearch()
    {
        var dataBase = _ayakashiDataBase;
        if (dataBase.AyakashiDataList.Count <= 0)
        {
            Debug.Log("データベースの要素が0です。");
            return;
        }

        ShowText(string.Empty);
        ShowText("\n"); // レイアウト調整
        _notFound = true;
        foreach (var data in dataBase.AyakashiDataList)
        {
            var matchFound = false;
            // フィールド全取得
            var fields = typeof(AyakashiData).GetFields(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (data.NameOfAyakashi == _searchWord)
                {
                    // 全FieldのValueを出力
                    NameEqual(data, fields);
                    return;
                }

                // 該当する対象の名前をすべて出力
                if (field.Name == "_nameOfAyakashi") continue; // myNameフィールドはスキップ
                var flag = FieldEqual(matchFound, field, data);
                if (flag) break;
            }
        }

        if (_notFound)
        {
            ShowText("\n該当するものが何もありませんでした。\n\nキーワードの変更や項目の変更を検討してください。" +
                     "\n\n依頼人の話にヒントがあるでしょう。\n");
        }
    }

    /// <summary>
    /// 名前検索でヒットした場合は、対象の情報をすべて表示する。
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="fields"></param>
    private void NameEqual(object obj, FieldInfo[] fields)
    {
        foreach (var field in fields)
        {
            var value = field.GetValue(obj);
            if (value is IList list)
            {
                // Debug.Log($"{field.Name} (List) =");
                foreach (var item in list)
                {
                    ShowText(_text.text += item + $"\n\n");
                    // Debug.Log($" - {item}");
                }
            }
            else
            {
                ShowText(_text.text += value + $"\n\n");
                // Debug.Log(value);
            }
        }
    }

    /// <summary>
    /// 名前以外で一部でも一致していたら、対象となるすべての妖怪の名前を出力する。
    /// </summary>
    private bool FieldEqual(bool flag, FieldInfo field, AyakashiData data)
    {
        var fieldValue = field.GetValue(data);
        // リストかどうかをチェック
        if (fieldValue is IList list)
        {
            // リストの各要素をチェック
            foreach (var item in list)
            {
                if (item != null && item.ToString().Contains(_searchWord))
                {
                    flag = true;
                    // Debug.Log("item: " + item);
                    break;
                }
            }
        }
        else
        {
            // 通常のフィールド値のチェック
            if (fieldValue.ToString().Contains(_searchWord))
            {
                flag = true;
                // Debug.Log("fieldValue: " + fieldValue);
            }
        }

        if (flag)
        {
            // 一致した場合、myNameを出力
            var myNameField = typeof(AyakashiData).GetField("_nameOfAyakashi",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            var myNameValue = (string)myNameField.GetValue(data);
            ShowText(_text.text += myNameValue + "\n\n");
            _notFound = false;
            return true; // 一致が見つかったら、次のデータへ移行
        }

        return false;
    }


    private void ShowText(string str)
    {
        _text.text = str;
    }
}