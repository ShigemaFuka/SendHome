using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JudgeName : MonoBehaviour
{
    [SerializeField] private ParticleSystemController _particleSystemController = default;
    [SerializeField] private GameObject _uiObject = default;
    private string _nameOfAyakashi = default; // 祓う妖怪の名前
    private FudaController _fudaController = default;
    private bool _isGameOver = default;
    private SaveLoadManager _saveLoadManager = default;

    /// <summary> 祓う妖怪の名前 </summary>
    public string NameOfAyakashi
    {
        get => _nameOfAyakashi;
        set => _nameOfAyakashi = value;
    }

    private void Start()
    {
        _fudaController = FindObjectOfType<FudaController>();
        _saveLoadManager = FindObjectOfType<SaveLoadManager>();
    }

    private void Judge(string name)
    {
        if (name == "") return;
        _uiObject.SetActive(true);
        _particleSystemController.PlayParticleSystem();

        if (name == NameOfAyakashi)
        {
            var child = _uiObject.transform.GetChild(0).gameObject;
            child.SetActive(true);
            _saveLoadManager.Save(name);
            StartCoroutine(Late(child, 0));
            SEController.Instance.SePlay(SEController.SeClass.SE.Success);
            Debug.Log("一致");
        }
        else
        {
            var child = _uiObject.transform.GetChild(1).gameObject;
            child.SetActive(true);
            StartCoroutine(Late(child, 1));
            _isGameOver = _fudaController.Decrease();
            SEController.Instance.SePlay(SEController.SeClass.SE.Failure);
            Debug.Log("不一致");
        }
    }

    public void OnClick(Text text)
    {
        Judge(text.text);
    }

    /// <summary>
    /// ■成功
    /// シーンリロード、依頼を受けるところからスタート
    /// ■失敗
    /// 失敗のUIを非表示にする。
    /// 御札windowを閉じる。
    /// </summary>
    /// <param name="go"></param>
    /// <param name="n"> 0:成功 1:失敗 </param>
    /// <returns></returns>
    private IEnumerator Late(GameObject go, int n)
    {
        yield return new WaitForSeconds(1.0f);
        if (n == 0)
        {
            yield return new WaitForSeconds(1.0f);
            // todo: メッセージ表示
            go.SetActive(false);
            _uiObject.transform.GetChild(2).gameObject.SetActive(true);
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene("TakeMission");
        }
        else
        {
            go.SetActive(false);
            _uiObject.SetActive(false);
            if (_isGameOver) SceneManager.LoadScene("Failure");
        }
    }
}