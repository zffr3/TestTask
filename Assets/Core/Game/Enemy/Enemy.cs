using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AnimationController _animation;

    [SerializeField]
    private ParticleController _particleController;

    private void Awake()
    {
        _particleController.SplashEvent.ParticleStopped += () => _animation.PlayBlock();
        EventBus.SubscribeToEvent(EventType.SPLASH_ATTACK_ENEMY, ActivateSplashParticle);
        EventBus.SubscribeToEvent(EventType.SPELL_ATTACK_ENEMY, ActivateSpellParticle);
    }

    private void OnDestroy()
    {
        _particleController.SplashEvent.ParticleStopped -= () => _animation.PlayBlock();
        EventBus.UnsubscribeFromEvent(EventType.SPLASH_ATTACK_ENEMY, ActivateSplashParticle);
        EventBus.UnsubscribeFromEvent(EventType.SPELL_ATTACK_ENEMY, ActivateSpellParticle);
    }

    private void ActivateSplashParticle(object param)
    {
        _particleController.PlaySplashParticle();
    }

    private void ActivateSpellParticle(object param)
    {
        _particleController?.PlaySpellParticle();
    }
}
