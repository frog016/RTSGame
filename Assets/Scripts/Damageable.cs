using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;
    public event Action<int> HealthChangedEvent;

    public void ApplyDamage(int amount)
    {
        _health -= amount;
        HealthChangedEvent?.Invoke(_health);

        if (_health <= 0)
            Destroy(gameObject);
    }
}