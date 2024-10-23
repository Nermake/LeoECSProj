using ECS.Components;
using ECS.Requests;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class SetTargetForProjectileSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeProjectileRequest, ProjectileTargetComponent> _filter = null;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var request = ref _filter.Get1(i);
                ref var targetComponent = ref _filter.Get2(i);

                ref var target = ref request.target;
                ref var startPosition = ref request.startPosition;

                targetComponent.target.x = target.x - startPosition.x;
                targetComponent.target.y = target.y - startPosition.y;
                
                _filter.GetEntity(i).Del<InitializeProjectileRequest>();
            }
        }
    }
}