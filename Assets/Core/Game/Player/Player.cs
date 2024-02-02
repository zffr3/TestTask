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
        _animEvents.SpellAchieved += () => EventBus.Dispatch(EventType.SPELL_ATTACK_ENEMY, null);
        _animEvents.SplashAchieved += () => EventBus.Dispatch(EventType.SPLASH_ATTACK_ENEMY, null);

        EventBus.SubscribeToEvent(EventType.DICE_VALUE_SETTED_PLAYER, AttackWithSplashCast);
    }

    public void AttackWithSplashCast(object damage)
    {
        _animation.PlaySplashCast();
        Debug.Log($"Damage to enemy: {damage.ToString()}");
    }
    
    public void UseSpellToEnemy()
    {
        _animation.PlaySpellCast();
    }
}
