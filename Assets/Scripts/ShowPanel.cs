using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    [SerializeField] private TextSplitter _textSplitter = default;

    public void OnClick(GameObject go)
    {
        var flag = go.activeSelf;

        _textSplitter.DisplayText();
        go.SetActive(!flag);
    }
}