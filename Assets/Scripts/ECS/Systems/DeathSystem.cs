using ECS.Components;
using ECS.Events;
using Leopotam.Ecs;
using Services;
using Zenject;

namespace ECS.Systems
{
    public sealed class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthComponent> _resources;
        private readonly EcsFilter<DeathEvent> _deaths;
        
        private readonly Destroyer _destroyer;

        public DeathSystem(DiContainer container)
        {
            _destroyer = container.Resolve<Destroyer>();
        }
        
        public void Run()
        {
            foreach (var i in _resources)
            {
                ref var resourcesUnitComponent = ref _resources.Get1(i);
                if (resourcesUnitComponent.Current <= 0)
                {
                    _resources.GetEntity(i).Get<DeathEvent>();
                }
            }
            
            foreach (var i in _deaths)
            {
                _destroyer.DestroyUnit(_deaths.GetEntity(i).Get<ActorViewComponent>().ActorView.gameObject);
                _deaths.GetEntity(i).Destroy();
            }
        }
    }
}