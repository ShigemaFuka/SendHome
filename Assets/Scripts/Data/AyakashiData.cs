using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 妖などの情報が入ったデータ
/// </summary>
[CreateAssetMenu(menuName = "Scriptable / AyakashiData")]
public class AyakashiData : ScriptableObject
{
    [SerializeField] private string _nameOfAyakashi = default;
    [SerializeField][TextArea(1,3)] private string _where = default;
    [SerializeField][TextArea(1,3)] private string _when = default;
    [SerializeField, Header("見た目")][TextArea(1,3)] private string _appearance = default;
    [SerializeField, Header("儀式")][TextArea(1,3)] private string _ritual = default;
    [SerializeField][TextArea(1,3)] private string _target = default;
    [SerializeField] private string _age = default;
    [SerializeField] private string _gender = default;
    [SerializeField][TextArea(1,3)] private List<string> _otherList = default;

    public string NameOfAyakashi => _nameOfAyakashi;
    public string Where => _where;
    public string When => _when;
    public string Appearance => _appearance;
    public string Ritual => _ritual;
    public string Target => _target;
    public string Age => _age;
    public string Gender => _gender;
    public List<string> OtherList => _otherList;
}