using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class InitializeCameraSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly SceneData _sceneData = null;
        
        public void Init()
        {
            var entity = _world.NewEntity();
            entity.Get<CameraComponent>().camera = _sceneData.Camera;
            
            ref var cameraFollowComponent = ref entity.Get<CameraFollowComponent>();
            cameraFollowComponent.offset = _sceneData.Offset;
            cameraFollowComponent.smoothing = _sceneData.Smoothing;
        }
    }
}