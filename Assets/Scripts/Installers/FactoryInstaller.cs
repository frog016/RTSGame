using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/Factory", fileName = "FactoryInstaller")]
public class FactoryInstaller : ScriptableObjectInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IFactory>()
            .To<DiFactory>()
            .AsSingle();
    }
}

