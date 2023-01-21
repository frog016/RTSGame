using UnityEngine;
using Zenject;

public class BlueprintPlanner : MonoBehaviour
{
    private IFactory _factory;
    private Blueprint _currentBlueprint;

    [Inject]
    public void Constructor(IFactory factory)
    {
        _factory = factory;
    }

    public void CreateBlueprint(Vector3 position, Blueprint blueprintPrefab)
    {
        CheckForExistingBlueprint();

        _currentBlueprint = _factory.CreateFromPrefabForComponent(blueprintPrefab, position, Quaternion.identity);
        _currentBlueprint.ObjectPlacedEvent += OnBuildingCreated;
    }

    private void CheckForExistingBlueprint()
    {
        if (_currentBlueprint == null)
            return;

        Destroy(_currentBlueprint.gameObject);
    }

    private void OnBuildingCreated()
    {
        _currentBlueprint = null;
    }
}
