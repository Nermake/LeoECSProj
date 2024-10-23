using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class ProjectileMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, ProjectileTargetComponent> _filter = null;
        private readonly RuntimeData _runtimeData = null;

        public void Run()
        {
            if (_runtimeData.PlayerEntity == EcsEntity.Null) return;
            
            foreach (var i in _filter)
            {
                ref var movableComponent = ref _filter.Get1(i);
                ref var projectileTargetComponent = ref _filter.Get2(i);

                ref var rigidbody2D = ref movableComponent.rigidbody2D;
                ref var speed = ref movableComponent.speed;
                ref var target = ref projectileTargetComponent.target;
                
                rigidbody2D.MovePosition(rigidbody2D.position + target.normalized * speed * Time.deltaTime);
            }
        }
    }
}