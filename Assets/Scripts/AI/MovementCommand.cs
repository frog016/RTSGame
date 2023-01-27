using System.Linq;
using UnityEngine;

public class MovementCommand : ICommand
{
    private readonly IFormation _formation;

    public MovementCommand(IFormation formation)
    {
        _formation = formation;
    }

    public void Execute(Vector3 target, UnitSelector unitSelector)
    {
        var units = unitSelector.GetSelectedUnits<IMovement>();
        var positions = _formation.GetFormationPositions(target, units.Length, 1);

        var unitPositionPairs = positions
            .Zip(units, (position, unit) => (position, unit));
        foreach (var (position, movement) in unitPositionPairs)
            movement.MoveTo(position);
    }
}
