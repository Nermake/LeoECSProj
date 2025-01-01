using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Services.Factory
{
    public class MovableEntityBuilder : EntityBuilder
    {
        private readonly MovableEntityConfig _config;
        public MovableEntityBuilder(MovableEntityConfig config) : base(config) => _config = config;

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