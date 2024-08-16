using System;
using UnityEngine;

/// <summary>
/// エフェクト(パーティクルシステム)、BGM、SEを再生する
/// シーン間をまたいでも再生
/// </summary>
public class EffectController : MonoBehaviour
{
    public static EffectController Instance = default;
    [SerializeField] private AudioSource _seAudio = default;
    [SerializeField] private AudioSource _bgmAudio = default;

    [SerializeField, Tooltip("パーティクルシステムなどのエフェクト")]
    private EffectClass[] _effectClass = default;

    [SerializeField] private SeClass[] _seClass = default;
    [SerializeField] private BgmClass[] _bgmClass = default;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void EffectPlay(EffectClass.Effect effect)
    {
        EffectClass data = null;
        foreach (var playEffect in _effectClass)
        {
            if (playEffect.EffectState != effect) continue; //一致するまで以下をスキップして繰り返す
            data = playEffect;
            break;
        }

        //_seAudio?.PlayOneShot(data?.SeClip);
        data?.ParticleSystem.Play();
    }

    public void SePlay(SeClass.SE se)
    {
        SeClass data = null;
        foreach (var playSe in _seClass)
        {
            if (playSe.SeState != se) continue;
            data = playSe;
            break;
        }

        _seAudio?.PlayOneShot(data?.SeClip, data.Volume);
    }

    public void BgmPlay(BgmClass.BGM bgm)
    {
        BgmClass data = null;
        foreach (var playSe in _bgmClass)
        {
            if (playSe.BgmState != bgm) continue;
            data = playSe;
            break;
        }

        _bgmAudio.clip = data?.BgmClip;
        _bgmAudio.volume = data.Volume;
        _bgmAudio.Play();
    }

    [Serializable]
    public class EffectClass
    {
        [SerializeField] private ParticleSystem _particleSystem = default;
        [SerializeField] private Effect _effectState = default;

        #region

        public ParticleSystem ParticleSystem => _particleSystem;
        public Effect EffectState => _effectState;

        #endregion

        public enum Effect
        {
            None
        }
    }

    [Serializable]
    public class SeClass
    {
        [SerializeField] private AudioClip _seClip = default;
        [SerializeField] private SE _seState = default;
        [SerializeField] private float _volume = 1f;

        #region

        public AudioClip SeClip => _seClip;
        public SE SeState => _seState;
        public float Volume => _volume;

        #endregion

        public enum SE
        {
            /// <summary> 電話を取る </summary>
            PickUp,
            
            /// <summary> カーソル </summary>
            Click,
            None
        }
    }

    [Serializable]
    public class BgmClass
    {
        [SerializeField] private AudioClip _bgmClip = default;
        [SerializeField] private BGM _bgmState = default;
        [SerializeField] private float _volume = 1f;

        #region

        public AudioClip BgmClip => _bgmClip;
        public BGM BgmState => _bgmState;
        public float Volume => _volume;

        #endregion

        public enum BGM
        {
            Normal,
            Failure,

            /// <summary> 危機的 </summary>
            Critical,
            None
        }
    }
}