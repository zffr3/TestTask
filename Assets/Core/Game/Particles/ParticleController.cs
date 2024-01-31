using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private ParticleEvent _splashEvent;
    public ParticleEvent SplashEvent {  get { return _splashEvent; } }

    [SerializeField]
    private ParticleSystem _splashParticle;
    [SerializeField]
    private ParticleSystem _spellParticle;
    [SerializeField]
    private ParticleSystem _healParticle;


    public void PlaySplashParticle()
    {
        _splashParticle.Play();
    }

    public void PlaySpellParticle()
    {
        _spellParticle.Play();
    }

    public void PlayHealParticle()
    {
        _healParticle.Play();
    }

    public void StopSpellParticle()
    {
        _spellParticle.Stop();
    }

    public void StopHealParticle()
    {
        _healParticle.Stop();
    }
}
