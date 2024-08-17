using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMChanger : MonoBehaviour
{
    [SerializeField] private string _name = default;
    private EffectController _effectController = default;

    private void Start()
    {
        _effectController = EffectController.Instance;
        _name = SceneManager.GetActiveScene().name;
        if (_name == "Failure")
        {
            _effectController.BgmPlay(EffectController.BgmClass.BGM.Failure);
        }
        else if(_name == "Opening")
        {
            _effectController.BgmPlay(EffectController.BgmClass.BGM.Opening);
        }
        else
        {
            _effectController.BgmPlay(EffectController.BgmClass.BGM.Normal);
        }
    }

    public void PlayNormalBGM()
    {
        _effectController.BgmPlay(EffectController.BgmClass.BGM.Normal);
    }
}