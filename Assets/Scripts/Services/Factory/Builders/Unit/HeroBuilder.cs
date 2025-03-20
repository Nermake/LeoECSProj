using System.Collections.Generic;
using Configs;
using ECS.Components;
using ECS.Data;
using ECS.Events;
using ECS.Mark;
using ECS.Tags;
using Leopotam.Ecs;
using StaticString;
using UnityEngine;
using Zenject;

namespace Services.Factory
{
    public class HeroBuilder : MovableUnitBuilder
    {
        [Inject] private readonly RaceConfig _raceConfig;
        [Inject] private readonly LevelUpConfig _levelUpConfig;
        [Inject] private readonly SceneData _sceneData;
        [Inject] private readonly RuntimeData _runtimeData;
        
        private readonly HeroConfig _config;
        private Color _healthColor;
        
        public HeroBuilder(HeroConfig config) : base(config) => _config = config;

        public override void Make()
        {
            base.Make();
            
            ColorUtility.TryParseHtmlString(StringConstants.RESOURCE_COLLOR_HEALTH, out var health);
            _healthColor = health;
            
            GetServices();
            AddEvents();
            AddMark();
            
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
            foreach (var raceData in _raceConfig.RaceDats)
            {
                if (raceData.Race == _config.RaceType)
                {
                    _entity.Get<AttributesUnitComponent>() += raceData.Attributes + _config.ClassAttributes;
                }
            } 
            
            ref var resourceProviderComponent = ref _entity.Get<ResourceFrameComponent>();
            resourceProviderComponent.HealthFrame = _sceneData.MainFrameView.HealthBarView;
            resourceProviderComponent.HealthFrame.SetColor(_healthColor);
            resourceProviderComponent.SecondaryResourceFrame = _sceneData.MainFrameView.SecondaryResourceBarView;
            
            ref var experienceComponent = ref _entity.Get<ExperienceComponent>();
            experienceComponent.Level = 1;
            experienceComponent.Current = 0;
            experienceComponent.Limit = _levelUpConfig.Limit[0];
            
            ref var raceViewComponent = ref _entity.Get<RaceComponent>();
            raceViewComponent.View = _sceneData.MainFrameView.RaceView;
            
            _runtimeData.PlayerActor = _view;
        }
        
        private void AddEvents()
        {
            _entity.Get<ChangeSecondaryResourceEvent>();
            _entity.Get<ChangeRaceEvent>();
            _entity.Get<ChangeGoldEvent>();
            _entity.Get<ChangeExperienceEvent>();
            _entity.Get<LevelUpEvent>();
        }

        private void AddMark()
        {
            ref var heroRaceMark = ref _entity.Get<HeroRaceMark>();
            heroRaceMark.RaceType = _config.RaceType;
                        
            ref var heroClassMark = ref _entity.Get<HeroClassMark>();
            heroClassMark.ClassType = _config.ClassType;
        }
    }
}