using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class ProjectileEntityBuilder : BaseEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            entity.Get<ProjectileTargetComponent>();
            
            ref var projectileDamageComponent = ref entity.Get<ProjectileDamageComponent>();
            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var transformComponent = ref entity.Get<TransformComponent>();

            projectileDamageComponent.damage = 5;
            
            movableComponent.rigidbody2D = unit.GetComponent<Rigidbody2D>();
            movableComponent.speed = 7;

            transformComponent.modelTransform = unit.transform;
        }
    }
}