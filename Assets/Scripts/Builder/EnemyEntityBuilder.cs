using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class EnemyEntityBuilder : BaseEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            entity.Get<EnemyTag>();

            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var transformComponent = ref entity.Get<TransformComponent>();

            movableComponent.rigidbody2D = unit.GetComponent<Rigidbody2D>();
            movableComponent.speed = 3f;
            
            transformComponent.modelTransform = unit.transform;
        }
    }
}