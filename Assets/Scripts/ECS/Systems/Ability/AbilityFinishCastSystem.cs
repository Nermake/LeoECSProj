using ECS.Components;
using ECS.Data;
using ECS.Events;
using ECS.Flags;
using ECS.Mark;
using Leopotam.Ecs;
using Services.Locator;
using View;

namespace ECS.Systems
{
    public sealed class AbilityFinishCastSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<AbilityFinishCastEvent> _finishCastFilter;
        
        private AbilityCastView _view;

        public void Init()
        {
            _view = ServiceLocator.Current.Get<SceneData>().AbilityCastView;
        }
        
        public void Run()
        {
            foreach (var i in _finishCastFilter)
            {
                ref var entity = ref _finishCastFilter.GetEntity(i);
                ref var effects = ref entity.Get<AbilityEffectsContainerComponent>().Effects;
                ref var target = ref entity.Get<AbilityTargetComponent>().Target;

                if (entity.Has<AbilityEnoughResourceFlag>())
                {
                    foreach (var effect in effects)
                    {
                        effect.Get<ImplementerInitEvent>();
                        effect.Get<EffectTargetComponent>().Target = target;
                    }
                    
                    entity.Get<AbilityWasteEvent>();
                    entity.Get<AbilityCooldownFlag>();
                    entity.Del<AbilityReadyFlag>();
                }
                
                entity.Del<AbilityFinishCastEvent>();
                
                _view.Hide();
            }
        }
    }
}