using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using Services.Locator;

namespace ECS.Systems
{
    public sealed class InitializeCameraSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        
        private SceneData _sceneData;
        
        public void Init()
        {
            _sceneData = ServiceLocator.Current.Get<SceneData>();
            
            var entity = _world.NewEntity();
            entity.Get<CameraComponent>().Camera = _sceneData.Camera;
            
            ref var cameraFollowComponent = ref entity.Get<CameraFollowComponent>();
            cameraFollowComponent.Offset = _sceneData.Offset;
            cameraFollowComponent.Smoothing = _sceneData.Smoothing;
        }
    }
}