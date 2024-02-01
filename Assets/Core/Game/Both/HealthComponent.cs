using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private int _maxHealthCount;
    [SerializeField]
    private int _currentHealthCount;

    public event UnityAction HealthEndEvent;
    public void AddHealth(int healthCount)
    {
        _currentHealthCount += healthCount;
        if (_currentHealthCount > _maxHealthCount)
        {
            _currentHealthCount = _maxHealthCount;
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealthCount -= damage;
        if (_currentHealthCount < 0)
        {
            HealthEndEvent?.Invoke();
        }
    }
}
