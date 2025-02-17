using System;
using System.Collections.Generic;
using ECS.Components;
using ECS.Events;
using ECS.Flags;
using Game.Types;
using Leopotam.Ecs;
using StaticString;
using UnityEngine;
using View;

namespace Services.Factory
{
    public class AbilityBuilder
    {
        protected EcsEntity _entity;
        protected EcsEntity _owner;
        protected List<EcsEntity> _effects;
        protected AbilityView _view;
        protected EcsWorld _world;

        private readonly AbilityConfig _config;

        public AbilityBuilder(AbilityConfig config) => _config = config;

        public void SetWorld(EcsWorld world) => _world = world;
        public void SetOwner(in EcsEntity owner) => _owner = owner;
        public void SetView(AbilityView view) => _view = view;

        public virtual void Make()
        {
            _entity = _world.NewEntity();

            ref var abilityViewComponent = ref _entity.Get<AbilityViewComponent>();
            abilityViewComponent.AbilityView = _view;

            ref var abilityComponent = ref _entity.Get<AbilityComponent>();
            abilityComponent.Title = _config.Title;
            abilityComponent.Description = _config.Description;
            abilityComponent.Icon = _config.Icon;
            
            ref var abilityStateComponent = ref _entity.Get<AbilityStateComponent>();
            
            if (_config.CooldownTime != 0)
            {
                ref var abilityCooldownComponent = ref _entity.Get<AbilityCooldownComponent>();
                abilityCooldownComponent.CooldownTime = _config.CooldownTime;
                abilityCooldownComponent.CooldownTimer = 0;
                
                abilityStateComponent.State = AbilityState.Ready;
                _entity.Get<AbilityReadyEvent>();
            }
            else
            {
                abilityStateComponent.State = AbilityState.NoCooldown;
                _entity.Get<AbilityNoCooldownFlag>();
            }

            if (_config.CastTime != 0)
            {
                ref var abilityCastComponent = ref _entity.Get<AbilityCastComponent>();
                abilityCastComponent.CastTime = _config.CastTime;
                abilityCastComponent.CastTimer = 0;
            }
            
            _owner.Get<AbilityOwnerComponent>().Abilities.Add(_config.ID, _entity);
            
            _view.Init(_owner, _entity);
            _view.SetAbilityImage(_config.Icon);
            _view.SetLevel(1);
            _view.SetResourceCost(Mathf.RoundToInt(_config.ResourceCost));
            
            switch (_config.ResourcesType)
            {
                case UnitResourcesType.Health:
                    ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_HEALTH, out var health);
                    _view.SetResourceColor(health);
                    
                    break;
                
                case UnitResourcesType.Mana:
                    ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_MANA, out var mana);
                    _view.SetResourceColor(mana);
                    
                    break;
                
                case UnitResourcesType.Energy:
                    ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_ENERGY, out var energy);
                    _view.SetResourceColor(energy);
                    
                    break;
                
                case UnitResourcesType.Rage:
                    ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_RAGE, out var rage);
                    _view.SetResourceColor(rage);
                    
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            SetAbilityApplyState(AbilityApplyState.Normal);
        }

        protected void SetAbilityApplyState(AbilityApplyState state)
        {
            _entity.Get<AbilityApplyStateComponent>().State = state;
        }

        public void NewEffect(in EcsEntity entity)
        {
            _entity.Get<AbilityEffectsContainerComponent>().EffectsQueue.Enqueue(entity);
        }

        public AbilityView GetView() => _view;

        public ref EcsEntity GetResult() => ref _entity;
    }
}