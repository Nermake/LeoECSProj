using System;
using ECS.Components;
using ECS.Events;
using Game.Types;
using Leopotam.Ecs;
using StaticString;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class SetResourceSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ResourceComponent, ChangeSecondaryResourceEvent> _resourceFilter;

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
        
        public void Run()// todo ты тут ддумал про пул, хз короче =)
        {
            foreach (var i in _resourceFilter)
            {
                ref var resourceViewComponent = ref _resourceFilter.Get1(i);
                resourceViewComponent.ResourcePlateView.Health.color = _healthColor;
                
                var secondaryResource = resourceViewComponent.ResourcePlateView.SecondaryResource;

                switch (resourceViewComponent.SecondaryResourcesType)
                {
                    case UnitResourcesType.Mana:
                        secondaryResource.color = _manaColor;
                        break;
                    case UnitResourcesType.Energy:
                        secondaryResource.color = _energyColor;
                        break;
                    case UnitResourcesType.Rage:
                        secondaryResource.color = _rageColor;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _resourceFilter.GetEntity(i).Del<ChangeSecondaryResourceEvent>();
            }
        }
    }
}