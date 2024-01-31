using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ParticleEvent _splashEvent;

    [SerializeField]
    private ParticleSystem _splashParticle;
    [SerializeField]
    private ParticleSystem _spellParticle;

    private void Awake()
    {
        _splashEvent.SubscribeToEvent(() => Debug.Log("enemy hit"));
        EventBus.SubscribeToEvent(EventType.SPLASH_ATTACK_ENEMY, ActivateSplashParticle);
        EventBus.SubscribeToEvent(EventType.SPELL_ATTACK_ENEMY, ActivateSpellParticle);
    }

    private void OnDestroy()
    {
        _splashEvent.UnsubscribeFromEvent(() => Debug.Log("enemy hit"));
        EventBus.UnsubscribeFromEvent(EventType.SPLASH_ATTACK_ENEMY, ActivateSplashParticle);
        EventBus.UnsubscribeFromEvent(EventType.SPELL_ATTACK_ENEMY, ActivateSpellParticle);
    }

    private void ActivateSplashParticle(object param)
    {
        if (_splashParticle != null)
        {
            _splashParticle.Play();
        }
    }

    private void ActivateSpellParticle(object param)
    {
        if (_spellParticle != null)
        {
            _spellParticle.Play();
        }
    }
}
