using ECS.Components;
using ECS.Data;
using ECS.Events;
using Leopotam.Ecs;
using Services.Locator;
using View;

namespace ECS.Systems
{
    public sealed class UnitLevelViewSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ChangeExperienceEvent> _changeExperienceFilter;
        private readonly EcsFilter<LevelUpEvent> _levelUpFilter;
        
        private LevelView _levelView;
        
        public void Init()
        {
            _levelView = ServiceLocator.Current.Get<SceneData>().MainFrameView.LevelView;
        }

        public void Run()
        {
            foreach (var i in _changeExperienceFilter)
            {
                ref var entity = ref _changeExperienceFilter.GetEntity(i);
                ref var experienceComponent = ref entity.Get<ExperienceComponent>();
                
                _levelView.SetPercent(experienceComponent.Current / experienceComponent.Limit);
                
                entity.Del<ChangeExperienceEvent>();
            }
            
            foreach (var i in _levelUpFilter)
            {
                ref var entity = ref _changeExperienceFilter.GetEntity(i);
                
                _levelView.SetLevel(entity.Get<ExperienceComponent>().Level);
                
                entity.Del<LevelUpEvent>();
            }
        }
    }
}