using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class FollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FollowComponent, MovableComponent> _followFilter = null;
        
        public void Run()
        {
            foreach (var entity in _followFilter)
            {
                ref var followComponent = ref _followFilter.Get1(entity);
                ref var movableComponent = ref _followFilter.Get2(entity);

                ref var target = ref followComponent.target;
                ref var rigidbody2D = ref movableComponent.rigidbody2D;
                ref var speed = ref movableComponent.speed;

                rigidbody2D.MovePosition(target.normalized * speed * Time.fixedDeltaTime);
            }
        }
    }
}