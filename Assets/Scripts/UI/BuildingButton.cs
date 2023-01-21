using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class BuildingButton : MonoBehaviour
{
    [SerializeField] private Blueprint _blueprintPrefab;
    [SerializeField] private BlueprintPlanner _blueprintPlanner;
    [SerializeField] private Camera _activeCamera;
    
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
        _buildingButton.onClick.AddListener(CreateBlueprintOnClick);
    }

    private void CreateBlueprintOnClick()
    {
        var mousePosition = _input.Building.Follow.ReadValue<Vector2>();
        var position = _activeCamera.ScreenToWorldPoint(mousePosition);
        _blueprintPlanner.CreateBlueprint(position, _blueprintPrefab);
    }

    private void OnDisable()
    {
        _buildingButton.onClick.RemoveListener(CreateBlueprintOnClick);
    }
}
