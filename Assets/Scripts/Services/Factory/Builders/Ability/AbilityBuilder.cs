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
        protected AbilityView _view;
        protected EcsWorld _world;

        private readonly AbilityConfig _config;

        public AbilityBuilder(AbilityConfig config) => _config = config;

        public void SetWorld(EcsWorld world) => _world = world;
        public void SetOwner(EcsEntity owner) => _owner = owner;
        public void SetView(AbilityView view) => _view = view;

        public virtual void Make()
        {
            _entity = _world.NewEntity();

            _entity.Get<AbilityTargetComponent>();
            _entity.Get<AbilityChangeEnoughResourceEvent>();
            
            ref var abilityViewComponent = ref _entity.Get<AbilityViewComponent>();
            abilityViewComponent.AbilityView = _view;
            
            ref var abilityOwner = ref _entity.Get<AbilityOwnerComponent>();
            abilityOwner.Owner = _owner;
            
            ref var abilityEffectsContainerComponent = ref _entity.Get<AbilityEffectsContainerComponent>();
            abilityEffectsContainerComponent.Effects = new List<EcsEntity>();

            ref var abilityComponent = ref _entity.Get<AbilityComponent>();
            abilityComponent.Title = _config.Title;
            abilityComponent.Description = _config.Description;
            abilityComponent.Icon = _config.Icon;
            
            ref var abilityResourceComponent = ref _entity.Get<AbilityResourceComponent>();
            abilityResourceComponent.ResourceCost = _config.ResourceCost;
            abilityResourceComponent.ResourceType = _config.ResourcesType;

            _entity.Get<AbilityNoneFlag>();
            
            if (_owner.Get<SecondaryResourceComponent>().Type != _config.ResourcesType)
            {
                Debug.LogError("[AbilityBuilder]: an attempt to add an ability that wastes a resource that the Owner does not possess! \n \t" +
                               $"Owner resource type: {_owner.Get<SecondaryResourceComponent>().Type} \n \t" +
                               $"Ability resource type: {abilityResourceComponent.ResourceType} \n");
            }
            
            if (_config.CooldownTime != 0)
            {
                ref var abilityCooldownComponent = ref _entity.Get<AbilityCooldownComponent>();
                abilityCooldownComponent.CooldownTime = _config.CooldownTime;
                abilityCooldownComponent.CooldownTimer = 0;
                
                _entity.Get<AbilityCooldownFlag>();
            }
            else
            {
                _entity.Get<AbilityNoCooldownFlag>();
            }

            if (_config.CastTime != 0)
            {
                ref var abilityCastComponent = ref _entity.Get<AbilityCastComponent>();
                abilityCastComponent.CastTime = _config.CastTime;
                abilityCastComponent.CastTimer = 0;
            }
            
            _owner.Get<AbilityContainerComponent>().Abilities.Add(_config.ID, _entity);
            
            _view.Init(_entity, _owner);
            _view.SetAbilityImage(_config.Icon);
            _view.SetCooldownFillAmount(0);
            _view.SetReadiness(true);
            _view.SetLevel(1);
            _view.SetCooldownTimer(string.Empty);
            _view.SetResourceCost(Mathf.RoundToInt(_config.ResourceCost));

            switch (_config.KeyCode)
            {
                case KeyCode.Alpha1:
                    _view.SetKeyCode("1");
                    break;
                case KeyCode.Alpha2:
                    _view.SetKeyCode("2");
                    break;
                case KeyCode.Alpha3:
                    _view.SetKeyCode("3");
                    break;
                case KeyCode.Alpha4:
                    _view.SetKeyCode("4");
                    break;
                case KeyCode.Alpha5:
                    _view.SetKeyCode("5");
                    break;
                case KeyCode.Alpha6:
                    _view.SetKeyCode("6");
                    break;
            }
            
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
            _entity.Get<AbilityEffectsContainerComponent>().Effects.Add(entity);
        }

        public AbilityView GetView() => _view;

        public ref EcsEntity GetResult() => ref _entity;
    }
}