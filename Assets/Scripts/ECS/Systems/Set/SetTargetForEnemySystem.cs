using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class SetTargetForEnemySystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnitFollowComponent, TransformComponent> _enemyFilter = null;
        private readonly RuntimeData _runtimeData = null;

        public void Run()
        {
            if (_runtimeData.PlayerActor == null) return;
            
            foreach (var entity in _enemyFilter)
            {
                ref var player = ref _runtimeData.PlayerActor.GetEntity();
                
                ref var playerTransformComponent = ref player.Get<TransformComponent>();
                ref var followComponent = ref _enemyFilter.Get1(entity);
                ref var enemyTransformComponent = ref _enemyFilter.Get2(entity);
                
                ref var playerTransform = ref playerTransformComponent.modelTransform;
                ref var enemyTransform = ref enemyTransformComponent.modelTransform;
                ref var targetDirection = ref followComponent.targetDirection;
                
                var playerPosition = playerTransform.position;
                var enemyPosition = enemyTransform.position;

                followComponent.target.x = playerPosition.x;
                followComponent.target.y = playerPosition.y;
                
                targetDirection.x = playerPosition.x - enemyPosition.x;
                targetDirection.y = playerPosition.y - enemyPosition.y;
            }
        }
    }
}