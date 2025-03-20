using ECS;
using ECS.Data;
using Services;
using Services.Factory;
using Zenject;

namespace Installers
{
    public class SystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<EscGameStartup>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CursorTarget>()
                .AsSingle();

            Container
                .Bind<RuntimeData>()
                .AsSingle();

            Container
                .Bind<InputController>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EntityFactory>()
                .AsSingle();
        }
    }
}