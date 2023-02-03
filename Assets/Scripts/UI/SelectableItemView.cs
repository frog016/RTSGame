using UnityEngine;
using UnityEngine.UI;

public class SelectableItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _healthBar;

    private Damageable _damageable;

    public void Initialize(Sprite sprite, Damageable damageable)
    {
        _icon.sprite = sprite;
        _damageable = damageable;
        ChangeHealthBarValue(damageable.Health);
        damageable.HealthChangedEvent += ChangeHealthBarValue;
        damageable.DestroyedEvent += OnDestroyed;
    }

    private void OnDisable()
    {
        _damageable.HealthChangedEvent -= ChangeHealthBarValue;
        _damageable.DestroyedEvent -= OnDestroyed;
    }

    private void ChangeHealthBarValue(int value)
    {
        _healthBar.fillAmount = (float)value / _damageable.MaxHealth;
    }

    private void OnDestroyed()
    {
        Destroy(gameObject);
    }
}
