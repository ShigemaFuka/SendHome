using UnityEngine;

public class PlaySEByButton : MonoBehaviour
{
    [SerializeField, Header("シーン間をまたぐ再生")] private EffectController.SeClass.SE _se = default;
    private EffectController _effectController = default;
    [SerializeField, Header("シーン間をまたがない再生")] private SEController.SeClass.SE _normalSe = default;
    private SEController _seController = default;

    private void Start()
    {
        _effectController = EffectController.Instance;
        _seController = SEController.Instance;
    }

    /// <summary>
    /// シーン間をまたぐSEの再生
    /// </summary>
    public void OnClickEffectControllerSE()
    {
        _effectController.SePlay(_se);
    }
    /// <summary>
    /// シーン間をまたがない再生
    /// </summary>
    public void OnClickSeControllerSE()
    {
        _seController.SePlay(_normalSe);
    }
}