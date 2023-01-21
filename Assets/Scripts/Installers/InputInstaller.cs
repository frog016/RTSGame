using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Installers/Input", fileName = "InputInstaller")]
public class InputInstaller : ScriptableObjectInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<Input>()
            .AsSingle()
            .OnInstantiated<Input>(EnableActionMaps);
    }

    private void EnableActionMaps(InjectContext context, Input input)
    {
        input.Enable();
    }
}

