using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health => _health;
    public int MaxHealth { get; private set; }
    public event Action<int> HealthChangedEvent;
    public event Action DestroyedEvent; 

    private void Awake()
    {
        MaxHealth = _health;
    }

    public void ApplyDamage(int amount)
    {
        _health -= amount;
        HealthChangedEvent?.Invoke(_health);

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        DestroyedEvent?.Invoke();
    }
}