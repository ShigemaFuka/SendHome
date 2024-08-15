using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable / ReplyData")]
public class ReplyData : ScriptableObject
{
    [SerializeField][TextArea(1,3)]  private string _nameOfAyakashi = default;
    [SerializeField][TextArea(1,3)]  private string _where = default;
    [SerializeField][TextArea(1,3)]  private string _when = default;
    [SerializeField, Header("見た目")][TextArea(1,3)]  private string _appearance = default;
    [SerializeField, Header("儀式")][TextArea(1,3)]  private string _ritual = default;
    [SerializeField][TextArea(1,3)]  private string _who = default;
    [SerializeField][TextArea(1,3)]  private string _age = default;
    [SerializeField][TextArea(1,3)]  private string _gender = default;
    [SerializeField][TextArea(1,3)]  private List<string> _otherList = default;
    [SerializeField, Header("あなたについて")][TextArea(1,3)]  private string _aboutYou = default;
    [SerializeField, Header("接触原因")][TextArea(1,3)]  private string _cause = default;

    public string NameOfAyakashi => _nameOfAyakashi;
    public string Where => _where;
    public string When => _when;
    public string Appearance => _appearance;
    public string Ritual => _ritual;
    public string Who => _who;
    public string Age => _age;
    public string Gender => _gender;
    public List<string> OtherList => _otherList;
    public string AboutYou => _aboutYou;
    public string Cause => _cause;
}