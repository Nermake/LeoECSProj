using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class TestEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TestEvent> testFilter = null;
        
        public void Run()
        {
            foreach (var i in testFilter)
            {
                ref var entity = ref testFilter.GetEntity(i);
                
                
                
            }
        }
    }
}