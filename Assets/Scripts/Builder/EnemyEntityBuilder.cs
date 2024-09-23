using ECS;
using ECS.Components;
using ECS.Requests;
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
            entity.Get<FollowComponent>();
            
            ref var movableComponent = ref entity.Get<MovableComponent>();
            ref var initializeEntityRequest = ref entity.Get<InitializeEntityRequest>();

            movableComponent.rigidbody2D = unit.GetComponent<Rigidbody2D>();
            movableComponent.speed = 3f;
            
            initializeEntityRequest.entityReference = unit.GetComponent<EntityReference>();
        }
    }
}