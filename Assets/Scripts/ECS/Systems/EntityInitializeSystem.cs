using ECS.Requests;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class EntityInitializeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityRequest> initFilter = null;

        public void Run()
        {
            foreach (var i in initFilter)
            {
                ref var entity = ref initFilter.GetEntity(i);
                ref var request = ref initFilter.Get1(i);

                request.entityReference.Entity = entity;
                entity.Del<InitializeEntityRequest>();
            }
        }
    }
}