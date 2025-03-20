using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Systems
{
    public sealed class CameraFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraFollowComponent, CameraComponent> _cameraFilter;
        
        [Inject] private readonly RuntimeData _runtimeData;
        
        public void Run()
        {
            if (_runtimeData.PlayerActor == null) return;
            
            foreach (var i in _cameraFilter)
            {
                ref var cameraFollowComponent = ref _cameraFilter.Get1(i);
                ref var cameraComponent = ref _cameraFilter.Get2(i);
                ref var follower = ref cameraComponent.Camera;
                
                var nextPosition = Vector3.Lerp(
                    follower.transform.position,
                    cameraFollowComponent.Target.position + cameraFollowComponent.Offset, 
                    cameraFollowComponent.Smoothing * Time.deltaTime);
    
                follower.transform.position = nextPosition;
            }
        }
    }
}