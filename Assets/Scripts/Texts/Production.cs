using UnityEngine;

/// <summary>
/// 表示するリストのインデックス番号に
/// 応じて演出を切り替える
/// </summary>
public class Production : MonoBehaviour
{
    [SerializeField, Header("0:非表示にする電波　" +
                            "\n1:切り替える前のTelObj　2:切り替えた後のTelObj　" +
                            "\n3:ノーマル背景Obj　4:危機的背景Obj")]
    private GameObject[] _gameObjects = default;

    private DisplayListText _displayListText = default;
    private int _oldNum = default; // ひとつ前のインデックス番号
    private int _currenNum = default; // ひとつ前のインデックス番号

    private void Start()
    {
        _displayListText = FindObjectOfType<DisplayListText>();
        _currenNum = _displayListText.CurrentIndex;
        _oldNum = _currenNum - 1;
        _gameObjects[0].SetActive(true);
        _gameObjects[1].SetActive(true);
        _gameObjects[2].SetActive(false);
        _gameObjects[3].SetActive(true);
        _gameObjects[4].SetActive(false);
    }

    private void Update()
    {
        // インデックスが切り替わったかどうかをチェック
        if (_currenNum != _oldNum)
        {
            DoPlay();
            Debug.Log("切り替わった"); // インデックスが変わった瞬間に出力
            _oldNum = _currenNum; // 前回のインデックスを更新
        }

        _currenNum = _displayListText.CurrentIndex;
    }

    private void DoPlay()
    {
        switch (_currenNum)
        {
            case 5:
                // 背景 normal->critical
                _gameObjects[3].SetActive(false);
                _gameObjects[4].SetActive(true);
                break;
            case 11:
                // 「...」　電話　SE：ブツッ　ツーツー　電波：非表示
                SEController.Instance.SePlay(SEController.SeClass.SE.HangUp);
                _gameObjects[0].SetActive(false);

                break;
            case 13:
                // 「電話が切れた」
                EffectController.Instance.BgmStop();
                // 背景 critical->normal
                _gameObjects[3].SetActive(true);
                _gameObjects[4].SetActive(false);
                break;
            case 14:
                // 「先の件は～～」　電話UI回転　SE:カシャン　背景：デフォルトのバックグラウンドに。＆　色を黒にする (無音?)
                // 電話
                _gameObjects[1].SetActive(false);
                _gameObjects[2].SetActive(true);
                EffectController.Instance.BgmPlay(EffectController.BgmClass.BGM.Normal);
                EffectController.Instance.SePlay(EffectController.SeClass.SE.PickUp);
                break;
        }
    }
}