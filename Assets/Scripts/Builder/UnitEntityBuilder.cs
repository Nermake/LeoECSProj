using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Builder
{
    public class UnitEntityBuilder : BaseEntityBuilder
    {
        protected override void Setup(GameObject unit)
        {
            entity.Get<AttackCharacteristicComponent>();
            entity.Get<AttributesUnitComponent>();
            entity.Get<DefenseStatUnitComponent>();
            entity.Get<ResourcesUnitComponent>();
        }
    }
}