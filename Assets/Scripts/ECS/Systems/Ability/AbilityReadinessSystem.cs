using System;
using ECS.Components;
using ECS.Flags;
using Game.Types;
using Leopotam.Ecs;
using View;

namespace ECS.Systems
{
    public sealed class AbilityReadinessSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AbilityResourceComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var owner = ref entity.Get<AbilityOwnerComponent>().Owner;
                ref var view = ref entity.Get<AbilityViewComponent>().AbilityView;
                
                switch (_filter.Get1(i).ResourceType)
                {
                    case UnitResourcesType.Health:
                        SetAbilityState(i, owner.Get<HealthComponent>().Current, view);
                        
                        break;
                    case UnitResourcesType.Mana:
                        SetAbilityState(i, owner.Get<ManaComponent>().Current, view);
                        
                        break;
                    case UnitResourcesType.Energy:
                        SetAbilityState(i, owner.Get<EnergyComponent>().Current, view);
                        
                        break;
                    case UnitResourcesType.Rage:
                        SetAbilityState(i, owner.Get<RageComponent>().Current, view);
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void SetAbilityState(int i, float resourceCost, AbilityView view)
        {
            ref var entity = ref _filter.GetEntity(i);
            ref var abilityResource = ref _filter.Get1(i);
            
            if (resourceCost >= abilityResource.ResourceCost && !entity.Has<AbilityEnoughResourceFlag>())
            {
                entity.Get<AbilityEnoughResourceFlag>();
                view.SetReadiness(true);
            }
            else if (resourceCost < abilityResource.ResourceCost && entity.Has<AbilityEnoughResourceFlag>())
            {
                entity.Del<AbilityEnoughResourceFlag>();
                view.SetReadiness(false);
            }
            else if (entity.Has<AbilityNoneFlag>())
            {
                if (resourceCost >= abilityResource.ResourceCost)
                {
                    entity.Get<AbilityEnoughResourceFlag>();
                    view.SetReadiness(true);
                }
                else
                {
                    view.SetReadiness(false);
                }
                
                entity.Del<AbilityNoneFlag>();
            }
        }
    }
}