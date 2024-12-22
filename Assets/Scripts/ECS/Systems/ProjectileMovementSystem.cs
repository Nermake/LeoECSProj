using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using Services.Locator;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class ProjectileMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, ProjectileTargetComponent> _filter;
        
        private RuntimeData _runtimeData;

        public void Init()
        {
            _runtimeData = ServiceLocator.Current.Get<RuntimeData>();
        }
        
        public void Run()
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