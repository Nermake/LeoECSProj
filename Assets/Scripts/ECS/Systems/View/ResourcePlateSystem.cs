using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class ResourcePlateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthComponent, HealthPlateComponent> _resourceFilter;
        
        public void Run()
        {
            foreach (var i in _resourceFilter)
            {
                ref var healthComponent = ref _resourceFilter.Get1(i);
                ref var resourceViewComponent = ref _resourceFilter.Get2(i);

                ref var view = ref resourceViewComponent.HealthPlate;
                view.SetFillAmount(healthComponent.Current / healthComponent.Max);
            }
        }
    }
}