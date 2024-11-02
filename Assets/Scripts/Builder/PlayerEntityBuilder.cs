using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class PlayerEntityBuilder : UnitEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            base.Setup(unit);
            
            entity.Get<PlayerTag>();
            entity.Get<DirectionComponent>();

            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var transformComponent = ref entity.Get<TransformComponent>();
            
            movableComponent.rigidbody2D = unit.GetComponent<Rigidbody2D>();
            movableComponent.speed = 5f;
            
            transformComponent.modelTransform = unit.transform;
        }
    }
}