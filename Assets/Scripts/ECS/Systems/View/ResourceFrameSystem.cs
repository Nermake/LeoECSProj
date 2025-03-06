using ECS.Components;
using Game.Types;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class ResourceFrameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ResourceFrameComponent, SecondaryResourceComponent> _resourceFilter;
        
        public void Run()
        {
            foreach (var i in _resourceFilter)
            {
                ref var entity = ref _resourceFilter.GetEntity(i);
                ref var resourceFrameComponent = ref _resourceFilter.Get1(i);
                ref var secondaryResourceComponent = ref _resourceFilter.Get2(i);
                
                ref var healthProviderBar = ref resourceFrameComponent.HealthFrame;
                ref var secondaryProviderBar = ref resourceFrameComponent.SecondaryResourceFrame;

                ref var healthComponent = ref entity.Get<HealthComponent>();
                ref var manaComponent = ref entity.Get<ManaComponent>();
                ref var energyComponent = ref entity.Get<EnergyComponent>();
                ref var rageComponent = ref entity.Get<RageComponent>();

                healthProviderBar.SetFillAmount(healthComponent.Current / healthComponent.Max);
                healthProviderBar.SetCurrent(healthComponent.Current);
                healthProviderBar.SetRegeneration(healthComponent.Regeneration);

                switch (secondaryResourceComponent.Type)
                {
                    case UnitResourcesType.Mana:
                        secondaryProviderBar.SetFillAmount(manaComponent.Current / manaComponent.Max);
                        secondaryProviderBar.SetCurrent(manaComponent.Current);
                        secondaryProviderBar.SetRegeneration(manaComponent.Regeneration);
                        break;
                    case UnitResourcesType.Energy:
                        secondaryProviderBar.SetFillAmount(energyComponent.Current / energyComponent.Max);
                        secondaryProviderBar.SetCurrent(energyComponent.Current);
                        secondaryProviderBar.SetRegeneration(energyComponent.Regeneration);
                        break;
                    case UnitResourcesType.Rage:
                        secondaryProviderBar.SetFillAmount(rageComponent.Current / rageComponent.Max);
                        secondaryProviderBar.SetCurrent(rageComponent.Current);
                        secondaryProviderBar.SetRegeneration(rageComponent.Regeneration);
                        break;
                }
            }
        }
    }
}