using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    [SerializeField] private TextSplitter _textSplitter = default;

    public void OnClick(GameObject go)
    {
        var flag = go.activeSelf;

        if (_textSplitter) _textSplitter.DisplayText();
        go.SetActive(!flag);
    }
}