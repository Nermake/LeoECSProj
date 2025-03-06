using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using Services.Locator;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<DirectionComponent, PlayerTag> _directionFilter;
        
        private InputController _inputController;

        public void Init()
        {
            _inputController = ServiceLocator.Current.Get<InputController>();
        }
        
        public void Run()
        {
            ref var entity = ref _directionFilter.GetEntity(0);
            ref var directionComponent = ref _directionFilter.Get1(0);
            
            var moveDirection = _inputController.Game.Move.ReadValue<Vector2>();

            if (moveDirection.x != 0 || moveDirection.y != 0)
            {
                //entity.Get<AbilityOwnerComponent>();
            }
            
            directionComponent.Direction = moveDirection;
        }
    }
}