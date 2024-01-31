using UnityEngine;
using UnityEngine.Events;

public class ParticleEvent : MonoBehaviour
{
    private UnityAction _particleStopped;
    private void OnParticleSystemStopped()
    {
        _particleStopped?.Invoke();
    }

    public void SubscribeToEvent(UnityAction handler)
    {
        _particleStopped += handler;
    }

    public void UnsubscribeFromEvent(UnityAction handler) 
    {
        _particleStopped -= handler;
    }
}
