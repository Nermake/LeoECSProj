using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Systems
{
    public sealed class InitializeCameraSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        
        [Inject] private readonly SceneData _sceneData;
        
        public void Init()
        {
            var entity = _world.NewEntity();
            entity.Get<CameraComponent>().Camera = _sceneData.Camera;
            
            ref var cameraFollowComponent = ref entity.Get<CameraFollowComponent>();
            cameraFollowComponent.Offset = _sceneData.Offset;
            cameraFollowComponent.Smoothing = _sceneData.Smoothing;
        }
    }
}