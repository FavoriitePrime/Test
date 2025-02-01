using UnityEngine.InputSystem;
using Zenject;

public class GamePlaySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().FromComponentOn(this.gameObject).AsSingle();
        Container.Bind<Input>().FromNew().AsSingle();
    }
}