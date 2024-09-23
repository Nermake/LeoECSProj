using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> _directionFilter = null;
        private readonly InputController _inputController = null;

        public void Run()
        {
            var moveDirection = _inputController.Game.Move.ReadValue<Vector2>();
            
            foreach (var entity in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(entity);

                directionComponent.direction = moveDirection;
            }
        }
    }
}