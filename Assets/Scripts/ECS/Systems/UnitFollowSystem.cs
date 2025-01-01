using ECS.Events;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class UnitFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnitFollowComponent, MovableComponent>.
            Exclude<BlockMoveDurationEvent> _followFilter;
        
        public void Run()
        {
            foreach (var entity in _followFilter)
            {
                ref var followComponent = ref _followFilter.Get1(entity);
                ref var movableComponent = ref _followFilter.Get2(entity);

                ref var targetDirection = ref followComponent.TargetDirection;
                ref var distance = ref followComponent.DistanceToStop;
                ref var target = ref followComponent.Target;
                ref var rigidbody2D = ref movableComponent.Rigidbody2D;
                ref var speed = ref movableComponent.Speed;

                if (!(distance <= Vector2.Distance(target, rigidbody2D.position))) return;
                
                rigidbody2D.MovePosition(rigidbody2D.position + targetDirection.normalized * speed * Time.deltaTime);
            }
        }
    }
}