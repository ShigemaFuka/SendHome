using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AyakashiDataBase", menuName = "Scriptable / AyakashiDataBase")]
public class AyakashiDataBase : ScriptableObject
{
    [SerializeField] private List<AyakashiData> _ayakashiDataList = new();
    public List<AyakashiData> AyakashiDataList => _ayakashiDataList;
}