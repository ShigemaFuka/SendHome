using System.Collections.Generic;

/// <summary>
/// JSONがListを直接保存できないため、ラッパークラスを作成
/// </summary>
[System.Serializable]
public class StringListWrapper
{
    public List<string> _listOfAyakashiNames = default;
}