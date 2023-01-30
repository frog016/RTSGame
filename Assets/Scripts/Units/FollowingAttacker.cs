using UnityEngine;

[RequireComponent(typeof(IMovement), typeof(Cooldown))]
public class FollowingAttacker : MonoBehaviour, IAttacker
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRange;

    private IMovement _movement;
    private Cooldown _cooldown;

    private void Awake()
    {
        _movement = GetComponent<IMovement>();
        _cooldown = GetComponent<Cooldown>();
    }
    
    public void Attack(Damageable damageable)
    {
        if (damageable.gameObject == gameObject)    // TODO: Убрать костыль. Сделать систему определения фракций (какому игроку принадлежит юнит).
            return;

        if (!_cooldown.TryRestart())
            return;

        if (IsTargetNear(damageable.transform.position))
        {
            damageable.ApplyDamage(_damage);
        }
        else
        {
            var direction = (damageable.transform.position - transform.position).normalized;
            _movement.Move(damageable.transform.position - direction * _attackRange);
        }
    }

    private bool IsTargetNear(Vector3 target)
    {
        return Vector3.Distance(transform.position, target) < _attackRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.white;
    }
}