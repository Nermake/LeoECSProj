using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class FollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FollowComponent, MovableComponent> followFilter = null;
        
        public void Run()
        {
            foreach (var i in followFilter)
            {
                ref var followComponent = ref followFilter.Get1(i);
                ref var movableComponent = ref followFilter.Get2(i);

                ref var target = ref followComponent.target;
                ref var rigidbody2D = ref movableComponent.rigidbody2D;
                ref var speed = ref movableComponent.speed;
                
                rigidbody2D.MovePosition(target * speed * Time.fixedDeltaTime);
            }
        }
    }
}