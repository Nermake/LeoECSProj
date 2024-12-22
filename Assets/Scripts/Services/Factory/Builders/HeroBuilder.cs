using ECS.Components;
using ECS.Data;
using ECS.Events;
using ECS.Mark;
using ECS.Tags;
using Game.Types;
using Leopotam.Ecs;
using Services.Locator;
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
            
            GetEvents();
            GetMark();
            
            _entity.Get<PlayerTag>();
            _entity.Get<DirectionComponent>();
            _entity.Get<AttackCharacteristicComponent>();
            _entity.Get<DefenseStatUnitComponent>();
            _entity.Get<AttributesUnitComponent>() += _config.RaceAttributes + _config.ClassAttributes;
            
            ref var experienceComponent = ref _entity.Get<ExperienceComponent>();
            experienceComponent.Level = 1;
            experienceComponent.Current = 0;
            experienceComponent.Limit = ServiceLocator.Current.Get<StaticData>().LevelUpConfig.Limit[0];
            
            ref var actorViewComponent = ref _entity.Get<ActorViewComponent>();
            actorViewComponent.ActorView = _view;
            
            ref var resourceViewComponent = ref _entity.Get<ResourceViewComponent>();
            resourceViewComponent.ResourcePanelView = _view.ResourcePanel;
            resourceViewComponent.SecondaryResourcesType = UnitResourcesType.Mana;
            
            ref var transformComponent = ref _entity.Get<TransformComponent>();
            transformComponent.ModelTransform = _view.transform;
            
            ref var movableComponent = ref _entity.Get<MovableComponent>();
            movableComponent.Rigidbody2D = _view.GetComponent<Rigidbody2D>();
            movableComponent.Speed = 5f;
        }
        
        private void GetEvents()
        {
            _entity.Get<ChangeSecondaryResourceEvent>();
            _entity.Get<ChangeExperienceEvent>();
            _entity.Get<LevelUpEvent>();
        }

        private void GetMark()
        {
            ref var heroRaceMark = ref _entity.Get<HeroRaceMark>();
            heroRaceMark.RaceType = _config.RaceType;
                        
            ref var heroClassMark = ref _entity.Get<HeroClassMark>();
            heroClassMark.ClassType = _config.ClassType;
        }
    }
}