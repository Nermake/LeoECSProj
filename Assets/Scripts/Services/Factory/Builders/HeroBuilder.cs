using ECS.Components;
using ECS.Data;
using ECS.Events;
using ECS.Mark;
using ECS.Tags;
using Game.Types;
using Leopotam.Ecs;
using Services.Locator;
using View;

namespace Services.Factory
{
    public class HeroBuilder : EntityBuilder
    {
        private readonly HeroConfig _config;
        
        public HeroBuilder(HeroConfig config) : base(config) => _config = config;

        public override void Make()
        {
            base.Make();
            
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
            
            ref var resourceViewComponent = ref _entity.Get<ResourceComponent>();
            resourceViewComponent.ResourcePanelView = _view.ResourcePanel;
            resourceViewComponent.SecondaryResourcesType = _config.SecondaryResource;
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
            
            ref var resourceProviderComponent = ref _entity.Get<ResourceProviderComponent>();
            resourceProviderComponent.ResourceProvider = serviceLocator.Get<SceneData>().MainFrameView.ResourceProvider;
            
            ref var experienceComponent = ref _entity.Get<ExperienceComponent>();
            experienceComponent.Level = 1;
            experienceComponent.Current = 0;
            experienceComponent.Limit = serviceLocator.Get<StaticData>().LevelUpConfig.Limit[0];
            
            ref var raceViewComponent = ref _entity.Get<RaceComponent>();
            raceViewComponent.Provider = serviceLocator.Get<SceneData>().MainFrameView.RaceProvider;
            
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