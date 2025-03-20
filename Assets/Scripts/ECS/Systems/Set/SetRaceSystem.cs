using Configs;
using ECS.Components;
using ECS.Events;
using ECS.Mark;
using Leopotam.Ecs;
using Zenject;

namespace ECS.Systems
{
    public sealed class SetRaceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HeroRaceMark, ChangeRaceEvent> _filter;
        
        [Inject] private readonly RaceConfig _raceConfig;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var heroRaceMark = ref _filter.Get1(i);
                ref var changeRaceEvent = ref _filter.Get2(i);

                heroRaceMark.RaceType = changeRaceEvent.NewRace;

                if (_filter.GetEntity(i).Has<RaceComponent>())
                {
                    ref var raceViewComponent = ref _filter.GetEntity(i).Get<RaceComponent>();

                    foreach (var current in _raceConfig.RaceDats)
                    {
                        if (changeRaceEvent.NewRace == current.Race)
                        {
                            raceViewComponent.View.SetSprite(current.Sprite);
                        }
                    }
                }
                
                _filter.GetEntity(i).Del<ChangeRaceEvent>();
            }
        }
    }
}