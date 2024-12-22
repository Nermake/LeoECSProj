using ECS.Components;
using ECS.Events;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class SetTargetForProjectileSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeProjectileEvent, ProjectileTargetComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var request = ref _filter.Get1(i);
                ref var targetComponent = ref _filter.Get2(i);

                ref var target = ref request.Target;
                ref var startPosition = ref request.StartPosition;

                targetComponent.Target.x = target.x - startPosition.x;
                targetComponent.Target.y = target.y - startPosition.y;
                
                _filter.GetEntity(i).Del<InitializeProjectileEvent>();
            }
        }
    }
}