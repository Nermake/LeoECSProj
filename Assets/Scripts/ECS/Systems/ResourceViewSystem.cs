using System;
using ECS.Components;
using Game.Types;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class ResourceViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthComponent, ResourceViewComponent> _resourceFilter = null;
        
        public void Run()
        {
            foreach (var i in _resourceFilter)
            {
                ref var entity = ref _resourceFilter.GetEntity(i);
                ref var healthComponent = ref _resourceFilter.Get1(i);
                ref var resourceViewComponent = ref _resourceFilter.Get2(i);

                ref var view = ref resourceViewComponent.resourcePanelView;
                var secondaryResource = resourceViewComponent.secondaryResourcesType;
                
                var healthBar = view.Health;
                healthBar.fillAmount = healthComponent.current / healthComponent.max;

                //todo 

                switch (secondaryResource)
                {
                    case UnitResourcesType.Mana:
                    {
                        var max = entity.Get<ManaComponent>().max;
                        var current = entity.Get<ManaComponent>().current;
                    
                        view.SecondaryResource.fillAmount = current / max;
                        break;
                    }
                    case UnitResourcesType.Energy:
                    {
                        var max = entity.Get<EnergyComponent>().max;
                        var current = entity.Get<EnergyComponent>().current;
                    
                        view.SecondaryResource.fillAmount = current / max;
                        break;
                    }
                    case UnitResourcesType.Rage:
                    {
                        var max = entity.Get<RageComponent>().max;
                        var current = entity.Get<RageComponent>().current;
                    
                        view.SecondaryResource.fillAmount = current / max;
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}