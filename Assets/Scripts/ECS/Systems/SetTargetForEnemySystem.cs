using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class SetTargetForEnemySystem : IEcsRunSystem
    {
        private readonly EcsFilter<FollowComponent, TransformComponent> _enemyFilter = null;
        private readonly RuntimeData _runtimeData = null;

        public void Run()
        {
            foreach (var entity in _enemyFilter)
            {
                if (_runtimeData.Player == EcsEntity.Null) return;

                ref var player = ref _runtimeData.Player;
                
                ref var playerTransformComponent = ref player.Get<TransformComponent>();
                ref var followComponent = ref _enemyFilter.Get1(entity);
                ref var enemyTransformComponent = ref _enemyFilter.Get2(entity);
                
                ref var playerTransform = ref playerTransformComponent.modelTransform;
                ref var enemyTransform = ref enemyTransformComponent.modelTransform;
                ref var target = ref followComponent.target;

                var playerPosition = playerTransform.position;
                var enemyPosition = enemyTransform.position;
                
                target.x = playerPosition.x - enemyPosition.x;
                target.y = playerPosition.y - enemyPosition.y;
            }
        }
    }
}