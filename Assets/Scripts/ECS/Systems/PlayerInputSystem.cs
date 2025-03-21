using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DirectionComponent, PlayerTag> _directionFilter;
        
        private readonly InputController _inputController;
        
        public PlayerInputSystem(DiContainer container)
        {
            _inputController = container.Resolve<InputController>();
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