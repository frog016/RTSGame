using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public class BuildingInstaller : MonoInstaller
{
    [SerializeField] private BuildingArea _area;
    [SerializeField] private Tilemap _tilemap;

    public override void InstallBindings()
    {
        BindBuildingArea();
        BindTilemap();
    }

    private void BindTilemap()
    {
        Container
            .Bind<Tilemap>()
            .FromInstance(_tilemap)
            .AsSingle();
    }

    private void BindBuildingArea()
    {
        Container
            .Bind<BuildingArea>()
            .FromInstance(_area)
            .AsSingle();
    }
}