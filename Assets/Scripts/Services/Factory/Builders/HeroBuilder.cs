using ECS.Components;
using ECS.Mark;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Services.Factory.Builders
{
    public class HeroBuilder : EntityBuilder
    {
        private readonly HeroConfig _config;
        
        public HeroBuilder(HeroConfig config) : base(config) => _config = config;

        public override void Make()
        {
            base.Make();
            
            _entity.Get<PlayerTag>();
            _entity.Get<ActorViewComponent>().actorView = _view;
            _entity.Get<HeroClassMark>().classType = _config.ClassType;
            _entity.Get<HeroRaceMark>().raceType = _config.RaceType;
            _entity.Get<DirectionComponent>();
            _entity.Get<AttackCharacteristicComponent>();
            _entity.Get<DefenseStatUnitComponent>();
            _entity.Get<AttributesUnitComponent>() += _config.RaceAttributes + _config.ClassAttributes;
            
            ref var movableComponent = ref _entity.Get<MovableComponent>();
            movableComponent.rigidbody2D = _view.GetComponent<Rigidbody2D>();
            movableComponent.speed = 5f;
            
            ref var transformComponent = ref _entity.Get<TransformComponent>();
            transformComponent.modelTransform = _view.transform;
            
            //ref var initializeEntityRequest = ref _entity.Get<InitializeEntityRequest>();
            //initializeEntityRequest.entityReference = _view.GetComponent<EntityReference>();// todo temporary stub
        }
    }
}