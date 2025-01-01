using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class RemovesProhibitionMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockMoveDurationEvent> _blockFilter;
        
        public void Run()
        {
            foreach (var i in _blockFilter)
            {
                ref var entity = ref _blockFilter.GetEntity(i);
                ref var blockMoveComponent = ref _blockFilter.Get1(i);
                
                blockMoveComponent.Time -= Time.deltaTime;
                
                if (blockMoveComponent.Time <= 0)
                {
                    entity.Del<BlockMoveDurationEvent>();
                }
            }
        }
    }
}