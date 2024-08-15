using UnityEngine;

/// <summary>
/// 祓う対象の妖怪を設定する。 
/// </summary>
public class SetAyakashi : MonoBehaviour
{
    [SerializeField] private AyakashiDataBase _ayakashiDataBase = default;
    [SerializeField] private ReplyDataBase _replyDataBase = default;
    private ShowClientMessage _showClientMessage = default;

    private void Start()
    {
        _showClientMessage = FindObjectOfType<ShowClientMessage>();
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
        _showClientMessage.ReplyData = _replyDataBase.ReplyDataList[random];
    }
}