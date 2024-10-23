using ECS.Blocks;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class FollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FollowComponent, MovableComponent>.
            Exclude<BlockMoveDuration> _followFilter = null;
        
        public void Run()
        {
            foreach (var entity in _followFilter)
            {
                ref var followComponent = ref _followFilter.Get1(entity);
                ref var movableComponent = ref _followFilter.Get2(entity);

                ref var targetDirection = ref followComponent.targetDirection;
                ref var distance = ref followComponent.distanceToStop;
                ref var target = ref followComponent.target;
                ref var rigidbody2D = ref movableComponent.rigidbody2D;
                ref var speed = ref movableComponent.speed;

                if (!(distance <= Vector2.Distance(target, rigidbody2D.position))) return;
                
                rigidbody2D.MovePosition(rigidbody2D.position + targetDirection.normalized * speed * Time.deltaTime);
            }
        }
    }
}