using System;
using Leopotam.Ecs;
using Zenject;

namespace Installers
{
    public class EcsInstaller : MonoInstaller
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
        }

        public override void InstallBindings()
        {
            Container
                .Bind<EcsWorld>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EcsSystems>()
                .AsSingle()
                .NonLazy();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}