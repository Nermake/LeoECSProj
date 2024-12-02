using ECS.Components;
using ECS.Events;
using Leopotam.Ecs;
using Services;
using Services.Locator;

namespace ECS.Systems
{
    public sealed class DeathSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ResourcesUnitComponent> _resources = null;
        private readonly EcsFilter<DeathEvent> _deaths = null;
        
        private Destroyer _destroyer;

        public void Init()
        {
            _destroyer = ServiceLocator.Current.Get<Destroyer>();
        }
        
        public void Run()
        {
            foreach (var i in _resources)
            {
                ref var resourcesUnitComponent = ref _resources.Get1(i);
                if (resourcesUnitComponent.health <= 0)
                {
                    _resources.GetEntity(i).Get<DeathEvent>();
                }
            }
            
            foreach (var i in _deaths)
            {
                _destroyer.DestroyUnit(_deaths.GetEntity(i).Get<TransformComponent>().modelTransform.gameObject);
                _deaths.GetEntity(i).Destroy();
            }
        }
    }
}