using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerMovementSystem : IEcsFixedRunSystem
    {
        private readonly EcsFilter<MovableComponent, DirectionComponent> _movableFilter;
        
        public void FixedRun()
        {
            foreach (var entity in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(entity);
                ref var directionComponent = ref _movableFilter.Get2(entity);

                ref var direction = ref directionComponent.Direction;
                ref var rigidbody2D = ref movableComponent.Rigidbody2D;
                ref var speed = ref movableComponent.Speed;
                
                rigidbody2D.MovePosition(rigidbody2D.position + direction * speed * Time.deltaTime);
            }
        }
    }
}