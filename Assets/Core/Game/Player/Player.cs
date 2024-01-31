using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private AnimationController _animation;
    [SerializeField]
    private AnimationEvents _animEvents;

    private void Start()
    {
        _animEvents.SubscribeToEvents(() => { }, ()=> EventBus.Dispatch(EventType.SPELL_ATTACK_ENEMY, null), ()=> EventBus.Dispatch(EventType.SPLASH_ATTACK_ENEMY, null));
    }

    public void AttackWithSplashCast()
    {
        _animation.PlaySplashCast();
    }
    
    public void UseSpellToEnemy()
    {
        _animation.PlaySpellCast();
    }
}
