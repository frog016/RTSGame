using UnityEngine;

public class AttackCommand : ICommand
{
    public bool IsCompleted { get; private set; }

    private readonly Damageable _target;

    public AttackCommand(Damageable target)
    {
        _target = target;
    }

    public void Execute(GameObject actor)
    {
        var attacker = actor.GetComponent<IAttacker>();
        attacker.Attack(_target);
        IsCompleted = _target.Health <= 0;
    }
}