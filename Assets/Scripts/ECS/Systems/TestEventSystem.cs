using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class TestEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TestEvent> _testFilter = null;
        
        public void Run()
        {
            foreach (var i in _testFilter)
            {
                ref var entity = ref _testFilter.GetEntity(i);
                
                
                
            }
        }
    }
}