using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class ProjectileEntityBuilder : BaseEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            Entity.Get<ProjectileTargetComponent>();
            
            ref var projectileDamageComponent = ref Entity.Get<ProjectileDamageComponent>();
            ref var movableComponent = ref Entity.Get<MovableComponent>();
            ref var transformComponent = ref Entity.Get<TransformComponent>();

            projectileDamageComponent.damage = 5;
            
            movableComponent.rigidbody2D = unit.GetComponent<Rigidbody2D>();
            movableComponent.speed = 7;

            transformComponent.modelTransform = unit.transform;
        }
    }
}