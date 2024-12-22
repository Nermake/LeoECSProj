using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using Services.Locator;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter;
        
        private InputController _inputController;

        public void Init()
        {
            _inputController = ServiceLocator.Current.Get<InputController>();
        }
        
        public void Run()
        {
            var moveDirection = _inputController.Game.Move.ReadValue<Vector2>();
            
            foreach (var entity in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(entity);

                directionComponent.Direction = moveDirection;
            }
        }
    }
}