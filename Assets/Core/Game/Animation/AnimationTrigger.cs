using UnityEngine;

[System.Serializable]
public class AnimationTrigger 
{
    [SerializeField]
    private string _triggerKey;

    public void ActivateTrigger(Animator animator)
    {
        animator.SetTrigger(_triggerKey);
    }
}
