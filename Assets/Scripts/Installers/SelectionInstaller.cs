using UnityEngine;
using Zenject;

public class SelectionInstaller : MonoInstaller
{
    [SerializeField] private PlayerSelector _playerSelector;
    [SerializeField] private AreaSelector _areaSelector;
    [SerializeField] private RectTransform _selectionBox;
    [SerializeField] private LayerMask _selectorLayer;

    public override void InstallBindings()
    {
        BindPlayerSelector();
        BindAreaSelector();
        BindAreaDrawer();
        BindSelector();
    }

    private void BindPlayerSelector()
    {
        Container
            .Bind<PlayerSelector>()
            .FromInstance(_playerSelector)
            .AsSingle();
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
