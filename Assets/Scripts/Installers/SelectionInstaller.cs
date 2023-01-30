using UnityEngine;
using Zenject;

public class SelectionInstaller : MonoInstaller
{
    [SerializeField] private AreaSelector _areaSelector;
    [SerializeField] private RectTransform _selectionBox;
    [SerializeField] private LayerMask _selectorLayer;

    public override void InstallBindings()
    {
        BindAreaSelector();
        BindAreaDrawer();
        BindSelector();
    }

    private void BindAreaSelector()
    {
        Container
            .Bind<AreaSelector>()
            .FromInstance(_areaSelector)
            .AsSingle();
    }

    private void BindAreaDrawer()
    {
        Container
            .Bind<IAreaDrawer>()
            .To<ScreenAreaDrawer>()
            .AsSingle()
            .WithArguments(_selectionBox);
    }

    private void BindSelector()
    {
        Container
            .Bind<ISelector>()
            .To<PhysicSelector>()
            .AsSingle()
            .WithArguments(_selectorLayer);
    }
}
