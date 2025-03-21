using ECS.Components;
using ECS.Data;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;
using View;
using Zenject;

namespace ECS.Systems
{
    public sealed class AbilityRunCastSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AbilityRunCastEvent> _runCastFilter;
        
        private readonly AbilityCastView _view;

        public AbilityRunCastSystem(DiContainer container)
        {
            _view = container.Resolve<SceneData>().AbilityCastView;
        }                                           
        
        public void Run()
        {
            foreach (var i in _runCastFilter)
            {
                ref var entity = ref _runCastFilter.GetEntity(i);
                ref var abilityCastComponent = ref entity.Get<AbilityCastComponent>();
                
                abilityCastComponent.CastTimer += Time.deltaTime;
                _view.SetFillAmount(abilityCastComponent.CastTimer / abilityCastComponent.CastTime);
                _view.SetTimerText(abilityCastComponent.CastTimer.ToString("f1"));

                if (abilityCastComponent.CastTimer >= abilityCastComponent.CastTime)
                {
                    abilityCastComponent.CastTimer = 0;
                    
                    entity.Get<AbilityFinishCastEvent>();
                    entity.Del<AbilityRunCastEvent>();
                }

                if (entity.Has<AbilityCancelCastEvent>())
                {
                    abilityCastComponent.CastTimer = 0;
                    
                    entity.Del<AbilityCancelCastEvent>();
                    entity.Del<AbilityRunCastEvent>();
                    
                    _view.Hide();
                }
            }
        }
    }
}