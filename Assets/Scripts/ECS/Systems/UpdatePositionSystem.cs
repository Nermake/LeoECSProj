using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class UpdatePositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent> _transform = null;
        
        public void Run()
        {
            foreach (var entity in _transform)
            {
                ref var transformComponent = ref _transform.Get1(entity);
                
            }
        }
    }
}