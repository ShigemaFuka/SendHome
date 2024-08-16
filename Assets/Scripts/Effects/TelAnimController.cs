using System.Collections;
using UnityEngine;

/// <summary>
/// 受話器のアニメーション
/// N秒おきにアニメーション再生
/// </summary>
public class TelAnimController : MonoBehaviour
{
    [SerializeField] private float _intervalAnim = default;
    [SerializeField] private float _intervalCallSe = default;
    [SerializeField] private Animator _animator = default;
    private SEController _seController = default;
    private static readonly int Shake = Animator.StringToHash("Shake");
    private WaitForSeconds _waitForSecondsAnim = default;
    private WaitForSeconds _waitForSecondsCallSe = default;

    private void Start()
    {
        _waitForSecondsAnim = new WaitForSeconds(_intervalAnim);
        _waitForSecondsCallSe = new WaitForSeconds(_intervalCallSe);
        _animator.SetTrigger(Shake);
        _seController = SEController.Instance;
        _seController.SePlay(SEController.SeClass.SE.Call);
        StartCoroutine(PlayAnim());
        StartCoroutine(PlayCallSE());
    }

    private IEnumerator PlayAnim()
    {
        while (true)
        {
            yield return _waitForSecondsAnim;
            _animator.SetTrigger(Shake);
        }
    }

    private IEnumerator PlayCallSE()
    {
        while (true)
        {
            yield return _waitForSecondsCallSe;
            _seController.SePlay(SEController.SeClass.SE.Call);
            // _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}