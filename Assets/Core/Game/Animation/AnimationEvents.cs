using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    private UnityAction _animationEnd;
    private UnityAction _spellAchieved;
    private UnityAction _splashAchieved;

    public void OnAnimationEnd()
    {
        _animationEnd?.Invoke();
    }

    public void OnCastFrameAchieved()
    {
        _spellAchieved?.Invoke();
    }

    public void OnSplashFrameAchieved()
    {
        _splashAchieved?.Invoke();
    }

    public void SubscribeToEvents(UnityAction endHandler, UnityAction spellHandler, UnityAction splashHandler)
    {
        _animationEnd += endHandler;
        _spellAchieved += spellHandler;
        _splashAchieved += splashHandler;
    }

    public void UnsubscribeFromEvents(UnityAction endHandler, UnityAction spellHandler, UnityAction splashHandler)
    {
        _animationEnd -= endHandler;
        _spellAchieved -= spellHandler;
        _splashAchieved -= splashHandler;
    }
}
