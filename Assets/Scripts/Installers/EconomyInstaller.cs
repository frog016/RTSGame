using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/Economy", fileName = "EconomyInstaller")]
public class EconomyInstaller : ScriptableObjectInstaller
{
    [SerializeField] private ResourceStorage _storage;

    public override void InstallBindings()
    {
        Container
            .BindInstance(_storage)
            .AsSingle();
    }
}