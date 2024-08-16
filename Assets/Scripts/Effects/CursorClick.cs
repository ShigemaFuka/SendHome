using UnityEngine;

/// <summary>
/// カーソルクリック
/// </summary>
public class CursorClick : MonoBehaviour
{
    private EffectController _effectController = default;

    private void Start()
    {
        _effectController = EffectController.Instance;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _effectController.SePlay(EffectController.SeClass.SE.Click);
        }
    }
}