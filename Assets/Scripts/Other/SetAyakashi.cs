using UnityEngine;

/// <summary>
/// 祓う対象の妖怪を設定する。
/// </summary>
public class SetAyakashi : MonoBehaviour
{
    [SerializeField] private AyakashiDataBase _ayakashiDataBase = default;
    [SerializeField] private ReplyDataBase _replyDataBase = default;
    private ShowClientMessage _showClientMessage = default;
    private JudgeName _judgeName　= default;

    private void Start()
    {
        _showClientMessage = FindObjectOfType<ShowClientMessage>();
        _judgeName = FindObjectOfType<JudgeName>();
        SetAyakashiData();
    }

    private void SetAyakashiData()
    {
        if (_ayakashiDataBase.AyakashiDataList.Count <= 0)
        {
            Debug.Log($"{_ayakashiDataBase.AyakashiDataList}の要素数が0です。");
            return;
        }

        if (_replyDataBase.ReplyDataList.Count <= 0)
        {
            Debug.Log($"{_replyDataBase.ReplyDataList}の要素数が0です。");
            return;
        }

        var random = Random.Range(0, _ayakashiDataBase.AyakashiDataList.Count);
        _showClientMessage.AyakashiData = _ayakashiDataBase.AyakashiDataList[random];
        // 妖怪のデータを決める➡その妖怪の名前で探す➡一致したものの証言データを決める
        foreach (var replyData in _replyDataBase.ReplyDataList)
        {
            if (replyData.NameOfAyakashi == _ayakashiDataBase.AyakashiDataList[random].NameOfAyakashi)
            {
                _showClientMessage.ReplyData = replyData;
                break;
            }
        }

        if (_showClientMessage.ReplyData == null)
        {
            Debug.LogWarning("証言データが見つかりませんでした。");
        }

        // _showClientMessage.ReplyData = _replyDataBase.ReplyDataList[random];
        _judgeName.NameOfAyakashi = _ayakashiDataBase.AyakashiDataList[random].NameOfAyakashi;
        Debug.Log("name: " + _judgeName.NameOfAyakashi);
    }
}