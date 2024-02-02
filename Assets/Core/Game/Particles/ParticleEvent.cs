using UnityEngine;
using UnityEngine.Events;

public class ParticleEvent : MonoBehaviour
{
    public event UnityAction ParticleStopped;
    private void OnParticleSystemStopped()
    {
        ParticleStopped?.Invoke();
    }
}
