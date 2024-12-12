using ECS.Components;
using ECS.Events;
using ECS.Mark;
using ECS.Tags;
using Game.Types;
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
            _entity.Get<ChangeSecondaryResourceEvent>();
            _entity.Get<DirectionComponent>();
            _entity.Get<AttackCharacteristicComponent>();
            _entity.Get<DefenseStatUnitComponent>();
            _entity.Get<AttributesUnitComponent>() += _config.RaceAttributes + _config.ClassAttributes;
            
            ref var actorViewComponent = ref _entity.Get<ActorViewComponent>();
            actorViewComponent.actorView = _view;
            
            ref var heroRaceMark = ref _entity.Get<HeroRaceMark>();
            heroRaceMark.raceType = _config.RaceType;
            
            ref var heroClassMark = ref _entity.Get<HeroClassMark>();
            heroClassMark.classType = _config.ClassType;
            
            ref var resourceViewComponent = ref _entity.Get<ResourceViewComponent>();
            resourceViewComponent.secondaryResourcesType = UnitResourcesType.Mana;
            
            ref var movableComponent = ref _entity.Get<MovableComponent>();
            movableComponent.rigidbody2D = _view.GetComponent<Rigidbody2D>();
            movableComponent.speed = 5f;
            
            ref var transformComponent = ref _entity.Get<TransformComponent>();
            transformComponent.modelTransform = _view.transform;
        }
    }
}