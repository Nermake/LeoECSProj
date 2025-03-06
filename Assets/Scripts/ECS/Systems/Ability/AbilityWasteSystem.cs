using System;
using ECS.Components;
using ECS.Events;
using ECS.Flags;
using ECS.Mark;
using Game.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class AbilityWasteSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AbilityWasteEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var owner = ref entity.Get<AbilityOwnerComponent>().Owner;
                ref var abilityResource = ref entity.Get<AbilityResourceComponent>();

                if (entity.Has<AbilityEnoughResourceFlag>())
                {
                    switch (abilityResource.ResourceType)
                    {
                        case UnitResourcesType.Health:
                            ref var healthComponent = ref owner.Get<HealthComponent>();
                            healthComponent.Current -= abilityResource.ResourceCost;
                        
                            break;
                        case UnitResourcesType.Mana:
                            ref var manaComponent = ref owner.Get<ManaComponent>();
                            manaComponent.Current -= abilityResource.ResourceCost;
                        
                            break;
                        case UnitResourcesType.Energy:
                            ref var energyComponent = ref owner.Get<EnergyComponent>();
                            energyComponent.Current -= abilityResource.ResourceCost;
                        
                            break;
                        case UnitResourcesType.Rage:
                            ref var rageComponent = ref owner.Get<RageComponent>();
                            rageComponent.Current -= abilityResource.ResourceCost;
                        
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    Debug.Log($"[AbilityWasteSystem]: No resource");
                }
                
                _filter.GetEntity(i).Del<AbilityWasteEvent>();
            }
        }
    }
}