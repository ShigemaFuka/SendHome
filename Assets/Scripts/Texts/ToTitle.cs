using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// テキストがすべて終わったら
/// オープニングからタイトルへ遷移
/// </summary>
public class ToTitle : MonoBehaviour
{
    [SerializeField] private DisplayListText _displayListText = default;
    private bool _called = default; // すでに呼んだか

    private void Update()
    {
        if (_displayListText.CurrentIndex == _displayListText.LengthOfMessages - 1)
        {
            if (!_called) StartCoroutine(Late());
        }
    }

    private IEnumerator Late()
    {
        _called = true;
        yield return new WaitForSeconds(3.0f);
        Debug.Log("title");
        EffectController.Instance.BgmPlay(EffectController.BgmClass.BGM.Normal);
        SceneManager.LoadScene("Title");
    }
}