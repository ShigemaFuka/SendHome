using UnityEngine;

public class PlaySEByButton : MonoBehaviour
{
    [SerializeField] private EffectController.SeClass.SE _se = default;
    private EffectController _effectController = default;

    private void Start()
    {
        _effectController = EffectController.Instance;
    }

    /// <summary>
    /// シーン間をまたぐSEの再生
    /// </summary>
    public void OnClickEffectControllerSE()
    {
        _effectController.SePlay(_se);
    }
}