using ECS;
using ECS.Components;
using ECS.Requests;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class UnitEntityBuilder : BaseEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            ref var initializeEntityRequest = ref Entity.Get<InitializeEntityRequest>();
            initializeEntityRequest.entityReference = unit.GetComponent<EntityReference>();
            
            Entity.Get<AttackCharacteristicComponent>();
            Entity.Get<AttributesUnitComponent>();
            Entity.Get<DefenseStatUnitComponent>();
            Entity.Get<ResourcesUnitComponent>();
        }
    }
}