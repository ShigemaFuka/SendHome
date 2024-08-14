using System.Collections.Generic;
using UnityEngine;

public enum GenderType
{
    Male,
    Female,
    Unknown
}

/// <summary>
/// 妖などの情報が入ったデータ
/// </summary>
[CreateAssetMenu(menuName = "Scriptable / AyakashiData")]
public class AyakashiData : ScriptableObject
{
    [SerializeField] private string _nameOfAyakashi = default;
    [SerializeField] private string _where = default;
    [SerializeField] private string _when = default;
    [SerializeField, Header("見た目")] private string _appearance = default;
    [SerializeField, Header("儀式")] private string _ritual = default;
    [SerializeField] private string _target = default;
    [SerializeField] private int _age = default;
    [SerializeField] private GenderType _gender = default;
    [SerializeField][TextArea(1,3)] private List<string> _otherList = default;

    public string NameOfAyakashi => _nameOfAyakashi;
    public string Where => _where;
    public string When => _when;
    public string Appearance => _appearance;
    public string Ritual => _ritual;
    public string Target => _target;
    public int Age => _age;
    public GenderType Gender => _gender;
    public List<string> OtherList => _otherList;
}