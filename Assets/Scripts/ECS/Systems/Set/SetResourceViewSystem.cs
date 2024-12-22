using System;
using ECS.Components;
using ECS.Events;
using Game.Types;
using Leopotam.Ecs;
using StaticString;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class SetResourceViewSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ResourceViewComponent, ChangeSecondaryResourceEvent> _filter = null;

        private Color _healthColor;
        private Color _manaColor;
        private Color _energyColor;
        private Color _rageColor;
        
        public void Init()
        {
            ColorUtility.TryParseHtmlString(StringConstants.PROGRESS_BAR_COLLOR_HEALTH, out var health);
            ColorUtility.TryParseHtmlString(StringConstants.PROGRESS_BAR_COLLOR_MANA, out var mana);
            ColorUtility.TryParseHtmlString(StringConstants.PROGRESS_BAR_COLLOR_ENERGY, out var energy);
            ColorUtility.TryParseHtmlString(StringConstants.PROGRESS_BAR_COLLOR_RAGE, out var rage);
            
            _healthColor = health;
            _manaColor = mana;
            _energyColor = energy;
            _rageColor = rage;
        }
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var resourceViewComponent = ref _filter.Get1(i);
                resourceViewComponent.ResourcePanelView.Health.color = _healthColor;
                
                var secondaryResource = resourceViewComponent.ResourcePanelView.SecondaryResource;
                
                secondaryResource.color = resourceViewComponent.SecondaryResourcesType switch
                {
                    UnitResourcesType.Mana => _manaColor,
                    UnitResourcesType.Energy => _energyColor,
                    UnitResourcesType.Rage => _rageColor,
                    _ => throw new ArgumentOutOfRangeException()
                };
                
                _filter.GetEntity(i).Del<ChangeSecondaryResourceEvent>();
            }
        }
    }
}