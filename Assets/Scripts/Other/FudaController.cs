using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 御札の枚数管理
/// 減算処理
/// 0枚時に還すのを失敗した時の処理
/// </summary>
public class FudaController : MonoBehaviour
{
    [SerializeField, Header("最大数")] private int _maxAmount = default;
    [SerializeField, Header("現在の枚数")] private int _currenAmount = default;
    [SerializeField] private Text _text = default;

    private void Start()
    {
        _currenAmount = _maxAmount;
        _text.text = $"残り {_currenAmount} 枚";
    }

    /// <summary>
    /// 枚数減らす
    /// </summary>
    public bool Decrease()
    {
        if (_currenAmount > 0)
        {
            _currenAmount--;
            _text.text = $"残り {_currenAmount} 枚";
        }

        return _currenAmount <= 0;
    }
}