using System;
using ECS.Components;
using Game.Types;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class ResourceViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthComponent, ResourceViewComponent> _resourceFilter;
        
        public void Run()
        {
            foreach (var i in _resourceFilter)
            {
                ref var entity = ref _resourceFilter.GetEntity(i);
                ref var healthComponent = ref _resourceFilter.Get1(i);
                ref var resourceViewComponent = ref _resourceFilter.Get2(i);

                ref var view = ref resourceViewComponent.ResourcePanelView;
                var secondaryResource = resourceViewComponent.SecondaryResourcesType;
                
                var healthBar = view.Health;
                healthBar.fillAmount = healthComponent.Current / healthComponent.Max;

                //todo 

                switch (secondaryResource)
                {
                    case UnitResourcesType.Mana:
                    {
                        var max = entity.Get<ManaComponent>().Max;
                        var current = entity.Get<ManaComponent>().Current;
                    
                        view.SecondaryResource.fillAmount = current / max;
                        break;
                    }
                    case UnitResourcesType.Energy:
                    {
                        var max = entity.Get<EnergyComponent>().Max;
                        var current = entity.Get<EnergyComponent>().Current;
                    
                        view.SecondaryResource.fillAmount = current / max;
                        break;
                    }
                    case UnitResourcesType.Rage:
                    {
                        var max = entity.Get<RageComponent>().Max;
                        var current = entity.Get<RageComponent>().Current;
                    
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