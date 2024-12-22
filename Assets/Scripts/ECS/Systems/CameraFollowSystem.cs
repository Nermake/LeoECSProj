using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using Services.Locator;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<CameraFollowComponent, CameraComponent> _cameraFilter;
        
        private RuntimeData _runtimeData;
        
        public void Init()
        {
            _runtimeData = ServiceLocator.Current.Get<RuntimeData>();
        }
        
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