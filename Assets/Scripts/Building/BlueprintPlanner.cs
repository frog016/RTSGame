using UnityEngine;

public class BlueprintPlanner : MonoBehaviour
{
    [SerializeField] private Blueprint _blueprintPrefab;

    private IFactory _factory;

    public void Constructor(IFactory factory)
    {
        _factory = factory;
    }

    public void CreateBlueprint()
    {
        var blueprint = _factory.Create(_blueprintPrefab);
        blueprint.GetComponent<IDraggable>().BeginDrag();
    }
}
