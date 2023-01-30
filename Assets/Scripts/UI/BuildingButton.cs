using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class BuildingButton : MonoBehaviour
{
    [SerializeField] private Blueprint _blueprintPrefab;
    [SerializeField] private BlueprintPlanner _blueprintPlanner;

    private Input _input;
    private Button _buildingButton;

    [Inject]
    public void Constructor(Input input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _buildingButton ??= GetComponent<Button>();
        _buildingButton.onClick.AddListener(CreateBlueprint);
    }

    private void CreateBlueprint()
    {
        var mousePosition = _input.Building.Follow.ReadValue<Vector2>();
        Convertor.ScreenToSurface(mousePosition, out var position);
        _blueprintPlanner.CreateBlueprint(position, _blueprintPrefab);
    }

    private void OnDisable()
    {
        _buildingButton.onClick.RemoveListener(CreateBlueprint);
    }
}
