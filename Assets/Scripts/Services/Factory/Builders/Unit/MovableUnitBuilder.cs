using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Services.Factory
{
    public class MovableUnitBuilder : UnitBuilder
    {
        private readonly MovableUnitConfig _config;
        public MovableUnitBuilder(MovableUnitConfig config) : base(config) => _config = config;

        public override void Make()
        {
            base.Make();
            
            _entity.Get<DirectionComponent>();
            
            ref var transformComponent = ref _entity.Get<TransformComponent>();
            transformComponent.ModelTransform = _view.transform;
            
            ref var movableComponent = ref _entity.Get<MovableComponent>();
            movableComponent.Rigidbody2D = _view.GetComponent<Rigidbody2D>();
            movableComponent.Speed = _config.Speed;
        }
    }
}