using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem = default;

    public void PlayParticleSystem()
    {
        _particleSystem.Play();
    }
}