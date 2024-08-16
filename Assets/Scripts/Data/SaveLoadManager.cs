using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private string _filePath = default;
    private List<string> _stringList = default;

    private void Start()
    {
        _filePath = Path.Combine(Application.persistentDataPath, "listOfAyakashiNames.json");
        Debug.Log("save data path: " + _filePath);
        _stringList = Load(); // ゲーム開始時にリストをロード
    }

    /// <summary>
    /// 新しい文字列をリストに追加して保存
    /// </summary>
    /// <param name="addString"></param>
    public void Save(string addString)
    {
        _stringList.Add(addString); // リストに新しい要素を追加
        RemoveDuplicates(); // 重複を取り除く
        var wrapper = new StringListWrapper { _listOfAyakashiNames = _stringList };
        var json = JsonUtility.ToJson(wrapper);
        File.WriteAllText(_filePath, json); // JSON ファイルに上書き保存
    }

    /// <summary>
    /// ファイルからリストをロード
    /// </summary>
    /// <returns></returns>
    public List<string> Load()
    {
        // Debug.Log("Loading data from: " + _filePath);

        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            // Debug.Log("JSON data: " + json);

            var wrapper = JsonUtility.FromJson<StringListWrapper>(json);
            if (wrapper != null && wrapper._listOfAyakashiNames != null)
            {
                return wrapper._listOfAyakashiNames;
            }

            Debug.LogWarning("Failed to deserialize JSON or list is null");
        }
        else
        {
            Debug.LogWarning("File not found: " + _filePath);
        }

        return new List<string>(); // ファイルが存在しない場合は空のリストを返す
    }


    /// <summary>
    /// データを削除する
    /// </summary>
    public void DeleteData()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath); // JSON ファイルを削除
        }
    }

    /// <summary>
    /// リストから重複を取り除く
    /// </summary>
    private void RemoveDuplicates()
    {
        var set = new HashSet<string>(_stringList);
        _stringList = new List<string>(set);
    }
}