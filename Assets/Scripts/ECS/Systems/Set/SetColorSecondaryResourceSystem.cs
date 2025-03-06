using System;
using ECS.Components;
using ECS.Events;
using Game.Types;
using Leopotam.Ecs;
using StaticString;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class SetColorSecondaryResourceSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ResourceFrameComponent, SecondaryResourceComponent, ChangeSecondaryResourceEvent> _resourceFilter;
        
        private Color _manaColor;
        private Color _energyColor;
        private Color _rageColor;
        
        public void Init()
        {
            ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_MANA, out var mana);
            ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_ENERGY, out var energy);
            ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_RAGE, out var rage);
            
            _manaColor = mana;
            _energyColor = energy;
            _rageColor = rage;
        }
        
        public void Run() //todo в дальнейшем сделать билдер для этого или закинуть в другой поток
        {
            foreach (var i in _resourceFilter)
            {
                ref var resourceFrameComponent = ref _resourceFilter.Get1(i);
                ref var secondaryResourceComponent = ref _resourceFilter.Get2(i);

                ref var secondaryResourceFrame = ref resourceFrameComponent.SecondaryResourceFrame;

                switch (secondaryResourceComponent.Type)
                {
                    case UnitResourcesType.Mana:
                        secondaryResourceFrame.SetColor(_manaColor);
                        break;
                    case UnitResourcesType.Energy:
                        secondaryResourceFrame.SetColor(_energyColor);
                        break;
                    case UnitResourcesType.Rage:
                        secondaryResourceFrame.SetColor(_rageColor);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                _resourceFilter.GetEntity(i).Del<ChangeSecondaryResourceEvent>();
            }
        }
    }
}