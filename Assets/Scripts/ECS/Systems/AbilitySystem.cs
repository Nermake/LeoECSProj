using ECS.Components;
using ECS.Events;
using ECS.Flags;
using Game.Types;
using Leopotam.Ecs;
using Services.Factory;
using Services.Locator;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class AbilitySystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<AbilityCooldownComponent>.Exclude<AbilityNoCooldownFlag> _cooldownFilter;
        private readonly EcsFilter<AbilityCastComponent, AbilityStartCastEvent>.Exclude<AbilityNoCastFlag> _castFilter; //todo возможно фильтр надо будет переработать
        private readonly EcsFilter<BuffHeal> _buffHealFilter;
        
        private EntityFactory _entityFactory;
        
        public void Init()
        {
            _entityFactory = ServiceLocator.Current.Get<EntityFactory>();
        }

        public void Run()
        {
            foreach (var i in _cooldownFilter)
            {
                ref var entity = ref _cooldownFilter.GetEntity(i);
                ref var abilityView = ref entity.Get<AbilityViewComponent>().AbilityView;
                ref var abilityCooldownComponent = ref _cooldownFilter.Get1(i);
                
                abilityCooldownComponent.CooldownTimer -= Time.deltaTime;
                //abilityView.SetCooldownTimer(); todo

                if (abilityCooldownComponent.CooldownTimer >= abilityCooldownComponent.CooldownTime)
                {
                    entity.Get<AbilityReadyEvent>();
                    entity.Get<AbilityStateComponent>().State = AbilityState.Ready;
                }
            }

            foreach (var i in _castFilter)
            {
                ref var entity = ref _castFilter.GetEntity(i);
                ref var abilityCastComponent = ref _castFilter.Get1(i);

                if (entity.Has<AbilityFreeCastEvent>())
                {
                    entity.Get<AbilityFinishCastEvent>();
                    entity.Del<AbilityStartCastEvent>();
                    
                    abilityCastComponent.CastTimer = 0;
                }
                
                abilityCastComponent.CastTimer += Time.deltaTime;

                if (abilityCastComponent.CastTimer >= abilityCastComponent.CastTime)
                {
                    entity.Get<AbilityFinishCastEvent>();
                    entity.Del<AbilityStartCastEvent>();
                    
                    abilityCastComponent.CastTimer = 0;
                }
            }

            foreach (var i in _buffHealFilter)
            {
                ref var entity = ref _buffHealFilter.GetEntity(i);
                ref var buffHeal = ref _buffHealFilter.Get1(i);
                
                
            }
        }
    }
}