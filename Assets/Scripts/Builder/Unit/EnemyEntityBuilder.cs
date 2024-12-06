using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class EnemyEntityBuilder : UnitEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            base.Setup(unit);
            
            Entity.Get<EnemyTag>();

            ref var movableComponent = ref Entity.Get<MovableComponent>();
            ref var transformComponent = ref Entity.Get<TransformComponent>();

            movableComponent.rigidbody2D = unit.GetComponent<Rigidbody2D>();
            movableComponent.speed = 3f;
            
            transformComponent.modelTransform = unit.transform;
        }
    }
}