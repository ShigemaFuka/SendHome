using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
/// 依頼人の証言内容を表示する
/// </summary>
public class ShowClientMessage : MonoBehaviour
{
    [SerializeField] private AyakashiData _ayakashiData = default;
    [SerializeField] private ReplyData _replyData = default;
    [SerializeField] private Text _text = default;
    [SerializeField] private List<string> _clientNameList = default;
    private string _message = default;
    private string _clientName = default;
    private TextSplitter _textSplitter = default;

    public AyakashiData AyakashiData
    {
        get => _ayakashiData;
        set => _ayakashiData = value;
    }

    public ReplyData ReplyData
    {
        get => _replyData;
        set => _replyData = value;
    }

    private void Start()
    {
        _clientName = MakeName();
        _textSplitter = FindObjectOfType<TextSplitter>();
    }

    public void OnClick(string str)
    {
        switch (str)
        {
            case "Name":
                var mark = new string('■', _replyData.NameOfAyakashi.Length);
                _message = $"-----【名前】-----\n{mark}という妖怪だと思います。......「ノイズで聞こえない？」そうですか。" +
                           $"名前だけ聞こえないなんて、本当にあれは妖怪なんですね。";
                break;
            case "Age":
                _message = $"-----【年齢】-----\n{_replyData.Age}";
                break;
            case "When":
                _message = $"-----【いつ】-----\n{_replyData.When}";
                break;
            case "Where":
                _message = $"-----【どこで】-----\n{_replyData.Where}";
                break;
            case "Who":
                _message = $"-----【誰が】-----\n{_replyData.Who}";
                break;
            case "Look":
                _message = $"-----【外見】-----\n{_replyData.Appearance}";
                break;
            case "Gender":
                _message = $"-----【性別】-----\n{_replyData.Gender}";
                break;
            case "AboutYou":
                _message = $"-----【依頼人について】-----" +
                           $"\n{_clientName}です。お祓いをしてもらいたくて電話しました。　{_replyData.AboutYou}";
                break;
            case "Other":
                var random = Random.Range(0, _replyData.OtherList.Count);
                _message = $"-----【その他】-----\n{_replyData.OtherList[random]}";
                break;
            case "Ritual":
                _message = $"-----【儀式】-----\n{_replyData.Ritual}";
                break;
            case "Cause":
                _message = $"-----【接触】-----\n{_replyData.Cause}";
                break;
        }

        _text.text = _message;
        _textSplitter.AddMemo(_message);
    }

    private string MakeName()
    {
        var clientName = "";
        var random = Random.Range(0, _clientNameList.Count);
        clientName = _clientNameList[random];

        return clientName;
    }
}