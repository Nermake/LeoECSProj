using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;
        private readonly InputController inputController = null;

        public void Run()
        {
            var moveDirection = inputController.Game.Move.ReadValue<Vector2>();
            
            foreach (var entity in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(entity);

                directionComponent.direction = moveDirection;
            }
        }
    }
}