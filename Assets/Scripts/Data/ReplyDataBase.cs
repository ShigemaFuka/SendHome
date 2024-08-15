using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReplyDataBase", menuName = "Scriptable / ReplyDataBase")]
public class ReplyDataBase : ScriptableObject
{
    [SerializeField] private List<ReplyData> _replyDataList = new();
    public List<ReplyData> ReplyDataList => _replyDataList;
}