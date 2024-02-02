using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    public event UnityAction AnimationEnd;
    public event UnityAction SpellAchieved;
    public event UnityAction SplashAchieved;

    public void OnAnimationEnd()
    {
        AnimationEnd?.Invoke();
    }

    public void OnCastFrameAchieved()
    {
        SpellAchieved?.Invoke();
    }

    public void OnSplashFrameAchieved()
    {
        SplashAchieved?.Invoke();
    }
}
