using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using Services.Locator;

namespace ECS.Systems
{
    public sealed class SetTargetForEnemySystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<UnitFollowComponent, TransformComponent> _enemyFilter;
        private RuntimeData _runtimeData;
        
        public void Init()
        {
            _runtimeData = ServiceLocator.Current.Get<RuntimeData>();
        }

        public void Run()
        {
            if (_runtimeData.PlayerActor == null) return;
            
            foreach (var entity in _enemyFilter)
            {
                ref var player = ref _runtimeData.PlayerActor.GetEntity();
                
                ref var playerTransformComponent = ref player.Get<TransformComponent>();
                ref var followComponent = ref _enemyFilter.Get1(entity);
                ref var enemyTransformComponent = ref _enemyFilter.Get2(entity);
                
                ref var playerTransform = ref playerTransformComponent.ModelTransform;
                ref var enemyTransform = ref enemyTransformComponent.ModelTransform;
                ref var targetDirection = ref followComponent.TargetDirection;
                
                var playerPosition = playerTransform.position;
                var enemyPosition = enemyTransform.position;

                followComponent.Target.x = playerPosition.x;
                followComponent.Target.y = playerPosition.y;
                
                targetDirection.x = playerPosition.x - enemyPosition.x;
                targetDirection.y = playerPosition.y - enemyPosition.y;
            }
        }
    }
}