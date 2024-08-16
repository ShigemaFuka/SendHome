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
        _text.text = string.Empty;
        _text.text = "依頼人の話が表示されます。ログは「メモウィンドウ」に記載されます。" +
                     "\n依頼人と電話がつながっています。さっそく依頼人に質問をしましょう。";
    }

    public void OnClick(string str)
    {
        switch (str)
        {
            case "Name":
                var mark = new string('■', _replyData.NameOfAyakashi.Length);
                _message = $"ーー【名前】ーー\n{mark}という妖怪だと思います。......「ノイズで聞こえない？」そうですか。" +
                           $"名前だけ聞こえないなんて、本当にあれは妖怪なんですね。";
                break;
            case "Age":
                _message = $"ーー【年齢】ーー\n{_replyData.Age}";
                break;
            case "When":
                _message = $"ーー【いつ】ーー\n{_replyData.When}";
                break;
            case "Where":
                _message = $"ーー【どこで】ーー\n{_replyData.Where}";
                break;
            case "Who":
                _message = $"ーー【誰が】ーー\n{_replyData.Who}";
                break;
            case "Look":
                _message = $"ーー【外見】ーー\n{_replyData.Appearance}";
                break;
            case "Gender":
                _message = $"ーー【性別】ーー\n{_replyData.Gender}";
                break;
            case "AboutYou":
                _message = $"ーー【依頼人について】ーー" +
                           $"\n{_clientName}です。お祓いをしてもらいたくて電話しました。　{_replyData.AboutYou}";
                break;
            case "Other":
                var random = Random.Range(0, _replyData.OtherList.Count);
                _message = $"ーー【その他】ーー\n{_replyData.OtherList[random]}";
                break;
            case "Ritual":
                _message = $"ーー【儀式】ーー\n{_replyData.Ritual}";
                break;
            case "Cause":
                _message = $"ーー【接触】ーー\n{_replyData.Cause}";
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