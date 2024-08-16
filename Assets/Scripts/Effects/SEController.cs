using System;
using UnityEngine;

public class SEController : MonoBehaviour
{
    public static SEController Instance = default;
    [SerializeField] private AudioSource _seAudio = default;
    [SerializeField] private SeClass[] _seClass = default;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
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
            /// <summary> 電話がかかる プルルルル </summary>
            Call,

            /// <summary> 電話が切れる ブツッ </summary>
            HangUp,

            /// <summary> 電話が切れる ツーツーツー </summary>
            TuuTuu,
        }
    }
}