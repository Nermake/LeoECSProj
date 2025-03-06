using System.Collections.Generic;
using ECS.Components;
using ECS.Data;
using ECS.Events;
using ECS.Mark;
using ECS.Tags;
using Leopotam.Ecs;
using Services.Locator;
using StaticString;
using UnityEngine;

namespace Services.Factory
{
    public class HeroBuilder : MovableUnitBuilder
    {
        private readonly HeroConfig _config;
        private Color _healthColor;
        
        public HeroBuilder(HeroConfig config) : base(config) => _config = config;

        public override void Make()
        {
            base.Make();
            
            ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_HEALTH, out var health);
            _healthColor = health;
            
            GetServices();
            GetEvents();
            GetMark();
            
            _entity.Get<PlayerTag>();
            _entity.Get<AttackCharacteristicComponent>();
            _entity.Get<DefenseStatUnitComponent>();
            
            ref var goldComponent = ref _entity.Get<GoldComponent>();
            goldComponent.Amount = _config.Gold;
            
            ref var actorViewComponent = ref _entity.Get<ActorViewComponent>();
            actorViewComponent.ActorView = _view;
            
            ref var resourceViewComponent = ref _entity.Get<HealthPlateComponent>();
            resourceViewComponent.HealthPlate = _view.Health;
            resourceViewComponent.HealthPlate.SetColor(_healthColor);
            
            ref var secondaryResourceComponent = ref _entity.Get<SecondaryResourceComponent>();
            secondaryResourceComponent.Type = _config.SecondaryResource;
            
            ref var abilityContainerComponent = ref _entity.Get<AbilityContainerComponent>();
            abilityContainerComponent.Abilities = new Dictionary<string, EcsEntity>();
        }

        private void GetServices() // todo передалать, создай тут команду на отправку в какой нить ViewController
        {
            var serviceLocator = ServiceLocator.Current;
            
            var raceDats = serviceLocator.Get<StaticData>().RaceConfig.RaceDats;
            foreach (var raceData in raceDats)
            {
                if (raceData.Race == _config.RaceType)
                {
                    _entity.Get<AttributesUnitComponent>() += raceData.Attributes + _config.ClassAttributes;
                }
            } 
            
            ref var resourceProviderComponent = ref _entity.Get<ResourceFrameComponent>();
            resourceProviderComponent.HealthFrame = serviceLocator.Get<SceneData>().MainFrameView.HealthBarView;
            resourceProviderComponent.HealthFrame.SetColor(_healthColor);
            resourceProviderComponent.SecondaryResourceFrame = serviceLocator.Get<SceneData>().MainFrameView.SecondaryResourceBarView;
            
            ref var experienceComponent = ref _entity.Get<ExperienceComponent>();
            experienceComponent.Level = 1;
            experienceComponent.Current = 0;
            experienceComponent.Limit = serviceLocator.Get<StaticData>().LevelUpConfig.Limit[0];
            
            ref var raceViewComponent = ref _entity.Get<RaceComponent>();
            raceViewComponent.View = serviceLocator.Get<SceneData>().MainFrameView.RaceView;
            
            serviceLocator.Get<RuntimeData>().PlayerActor = _view;
        }
        
        private void GetEvents()
        {
            _entity.Get<ChangeSecondaryResourceEvent>();
            _entity.Get<ChangeRaceEvent>();
            _entity.Get<ChangeGoldEvent>();
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