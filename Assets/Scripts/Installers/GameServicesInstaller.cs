using ECS.Data;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameServicesInstaller : MonoInstaller
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private Destroyer _destroyer;
        
        public override void InstallBindings()
        {
            Container
                .Bind<Destroyer>()
                .FromInstance(_destroyer)
                .AsSingle();

            Container
                .Bind<SceneData>()
                .FromInstance(_sceneData)
                .AsSingle()
                .NonLazy();
        }
    }
}