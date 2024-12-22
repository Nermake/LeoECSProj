using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using Services.Locator;

namespace ECS.Systems
{
    public sealed class SetTargetForCameraSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<CameraFollowComponent> _cameraFilter = null;
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
                ref var camera = ref _cameraFilter.Get1(i);
                var target = _runtimeData.PlayerActor.transform;

                camera.Target = target;
            }
        }
    }
}