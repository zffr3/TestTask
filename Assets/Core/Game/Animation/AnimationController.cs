using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private AnimationTrigger _spellCastTrigger;
    [SerializeField]
    private AnimationTrigger _splashCastTrigger;
    [SerializeField]
    private AnimationTrigger _healTrigger;
    [SerializeField]
    private AnimationTrigger _blockTrigger;

    public void PlaySpellCast()
    {
        _spellCastTrigger.ActivateTrigger(_animator);
    }

    public void PlaySplashCast()
    {
        _splashCastTrigger.ActivateTrigger(_animator);
    }

    public void PlayHeal()
    {
        _healTrigger.ActivateTrigger(_animator);
    }

    public void PlayBlock()
    {
        _blockTrigger.ActivateTrigger(_animator);
    }

    public void Initialize(Animator animator)
    {
        _animator = animator;
    }
}
