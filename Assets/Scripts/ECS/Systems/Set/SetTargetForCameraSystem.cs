using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Systems
{
    public sealed class SetTargetForCameraSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraFollowComponent> _cameraFilter = null;

        private readonly RuntimeData _runtimeData;

        public SetTargetForCameraSystem(DiContainer container)
        {
            _runtimeData = container.Resolve<RuntimeData>();
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