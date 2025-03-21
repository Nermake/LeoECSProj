using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Systems
{
    public sealed class ProjectileMovementSystem : IEcsFixedRunSystem
    {
        private readonly EcsFilter<MovableComponent, ProjectileTargetComponent> _filter;
        
        private readonly RuntimeData _runtimeData;

        public ProjectileMovementSystem(DiContainer container)
        {
            _runtimeData = container.Resolve<RuntimeData>();
        }
        
        public void FixedRun()
        {
            if (_runtimeData.PlayerActor == null) return;
            
            foreach (var i in _filter)
            {
                ref var movableComponent = ref _filter.Get1(i);
                ref var projectileTargetComponent = ref _filter.Get2(i);

                ref var rigidbody2D = ref movableComponent.Rigidbody2D;
                ref var speed = ref movableComponent.Speed;
                ref var target = ref projectileTargetComponent.Target;
                
                rigidbody2D.MovePosition(rigidbody2D.position + target.normalized * speed * Time.deltaTime);
            }
        }
    }
}