using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    private UnityAction _animationEnd;
    private UnityAction _castAchieved;

    public void OnAnimationEnd()
    {
        _animationEnd?.Invoke();
    }

    public void OnCastFrameAchieved()
    {
        _castAchieved?.Invoke();
    }

    public void SubscribeToEvents(UnityAction endHandler, UnityAction castHandler)
    {
        _animationEnd += endHandler;
        _castAchieved += castHandler;
    }

    public void UnsubscribeFromEvents(UnityAction endHandler, UnityAction castHandler)
    {
        _animationEnd -= endHandler;
        _castAchieved -= castHandler;
    }
}
