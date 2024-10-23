using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, DirectionComponent> _movableFilter = null;
        
        public void Run()
        {
            foreach (var entity in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(entity);
                ref var directionComponent = ref _movableFilter.Get2(entity);

                ref var direction = ref directionComponent.direction;
                ref var rigidbody2D = ref movableComponent.rigidbody2D;
                ref var speed = ref movableComponent.speed;
                
                rigidbody2D.MovePosition(rigidbody2D.position + direction * speed * Time.deltaTime);
            }
        }
    }
}