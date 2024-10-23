using ECS.Blocks;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class RemovesProhibitionMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockMoveDuration> _blockFilter = null;
        
        public void Run()
        {
            foreach (var i in _blockFilter)
            {
                ref var entity = ref _blockFilter.GetEntity(i);
                ref var blockMoveComponent = ref _blockFilter.Get1(i);
                
                blockMoveComponent.time -= Time.deltaTime;
                
                if (blockMoveComponent.time <= 0)
                {
                    entity.Del<BlockMoveDuration>();
                }
            }
        }
    }
}