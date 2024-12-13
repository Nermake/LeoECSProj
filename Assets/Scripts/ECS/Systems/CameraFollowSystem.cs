using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class CameraFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraFollowComponent, CameraComponent> _cameraFilter = null;
        private readonly RuntimeData _runtimeData = null;
        
        public void Run()
        {
            if (_runtimeData.PlayerActor == null) return;
            
            foreach (var i in _cameraFilter)
            {
                ref var cameraFollowComponent = ref _cameraFilter.Get1(i);
                ref var cameraComponent = ref _cameraFilter.Get2(i);
                ref var follower = ref cameraComponent.camera;
                
                var nextPosition = Vector3.Lerp(
                    follower.transform.position,
                    cameraFollowComponent.target.position + cameraFollowComponent.offset, 
                    cameraFollowComponent.smoothing * Time.deltaTime);
    
                follower.transform.position = nextPosition;
            }
        }
    }
}