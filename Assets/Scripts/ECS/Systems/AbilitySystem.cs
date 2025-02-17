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
        private readonly EcsFilter<AbilityApplyEvent> _abilityApplyFilter;
        
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
                
                if (entity.Get<AbilityStateComponent>().State == AbilityState.Cooldown)
                {
                    ref var abilityView = ref entity.Get<AbilityViewComponent>().AbilityView;
                    ref var abilityCooldownComponent = ref _cooldownFilter.Get1(i);
                
                    abilityCooldownComponent.CooldownTimer -= Time.deltaTime;
                    
                    abilityView.SetCooldownTimer(abilityCooldownComponent.CooldownTimer < 60
                        ? $"{Mathf.RoundToInt(abilityCooldownComponent.CooldownTimer)}s"
                        : $"{Mathf.RoundToInt(abilityCooldownComponent.CooldownTimer / 60)}m");

                    if (abilityCooldownComponent.CooldownTimer <= 0)
                    {
                        abilityView.SetCooldownTimer(string.Empty);
                        
                        entity.Get<AbilityReadyEvent>();
                        entity.Get<AbilityStateComponent>().State = AbilityState.Ready;

                        abilityCooldownComponent.CooldownTimer = abilityCooldownComponent.CooldownTime;
                    }
                }
            }

            foreach (var i in _castFilter)
            {
                ref var entity = ref _castFilter.GetEntity(i);

                if (entity.Get<AbilityApplyStateComponent>().State == AbilityApplyState.Free
                    || entity.Get<AbilityApplyStateComponent>().State == AbilityApplyState.Instant) continue;
                
                ref var abilityCastComponent = ref _castFilter.Get1(i);
                
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

            foreach (var i in _abilityApplyFilter)
            {
                ref var entity = ref _abilityApplyFilter.GetEntity(i);
                
                // todo пока неясно как но задумка такая, перебрать все еффекты которые находядся в способности
                // и добавить им компонент который их обработает
                // вопрос как прокинуть нужные настройки для каждого из еффектов(цель и что нить ещё)
                // todo logic of applying the ability
                
                entity.Del<AbilityApplyEvent>();
            }
        }
        
        public string FormatTime(float time)
        {
            if (time < 60)
            {
                return $"{Mathf.RoundToInt(time)}s";
            }
            else
            {
                return $"{Mathf.RoundToInt(time / 60)}m";
            }
        }
    }
}