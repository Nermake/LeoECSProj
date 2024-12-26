using Configs;
using ECS.Components;
using ECS.Data;
using ECS.Events;
using ECS.Mark;
using Leopotam.Ecs;
using Services.Locator;
using View;

namespace ECS.Systems
{
    public sealed class SetRaceSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<HeroRaceMark, ChangeRaceEvent> _filter;
        
        private RaceConfig _raceConfig;
        
        public void Init()
        {
            _raceConfig = ServiceLocator.Current.Get<StaticData>().RaceConfig;
        }
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var heroRaceMark = ref _filter.Get1(i);
                ref var changeRaceEvent = ref _filter.Get2(i);

                heroRaceMark.RaceType = changeRaceEvent.NewRace;

                if (_filter.GetEntity(i).Has<RaceViewComponent>())
                {
                    ref var raceViewComponent = ref _filter.GetEntity(i).Get<RaceViewComponent>();

                    foreach (var current in _raceConfig.Races)
                    {
                        if (changeRaceEvent.NewRace == current.Race)
                        {
                            raceViewComponent.Provider.Image.sprite = current.Sprite;
                        }
                    }
                }
                
                _filter.GetEntity(i).Del<ChangeRaceEvent>();
            }
        }
    }
}