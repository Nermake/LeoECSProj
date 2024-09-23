using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class SetTargetForEnemySystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<FollowComponent, TransformComponent> _enemyFilter = null;
        private readonly EcsFilter<PlayerTag> _targetFilter = null;

        private EcsEntity _player;
        
        public void Init()
        {
            foreach (var entity in _targetFilter)
            {
                _player = _targetFilter.GetEntity(entity);
            }
        }

        public void Run()
        {
            foreach (var entity in _enemyFilter)
            {
                ref var playerTransformComponent = ref _player.Get<TransformComponent>();
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