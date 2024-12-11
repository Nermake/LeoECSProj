using ECS.Events;
using ECS.Requests;
using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class InitializeEntitySystem : IEcsRunSystem // todo delete
    {
        private readonly EcsFilter<InitializeEntityRequest> _initFilter = null;

        public void Run()
        {
            foreach (var i in _initFilter)
            {
                ref var entity = ref _initFilter.GetEntity(i);
                ref var request = ref _initFilter.Get1(i);

                request.entityReference.Entity = entity;
                
                if (entity.Has<PlayerTag>())
                {
                    entity.Get<InitializePlayerEvent>();
                }
                if (entity.Has<EnemyTag>())
                {
                    entity.Get<InitializeEnemyEvent>();
                }
                
                entity.Del<InitializeEntityRequest>();
            }
        }
    }
}