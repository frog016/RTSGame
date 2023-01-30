using UnityEngine;

public class MovementCommand : ICommand
{
    public bool IsCompleted { get; private set; }

    private readonly Vector3 _position;

    public MovementCommand(Vector3 position)
    {
        _position = position;
    }

    public void Execute(GameObject actor)
    {
        actor.GetComponent<IMovement>().Move(_position);
        IsCompleted = Vector3.Distance(actor.transform.position.ToXZPlane(), _position) <= 1e-3;
    }
}
