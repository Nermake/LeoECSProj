using ECS.Components;
using ECS.Data;
using ECS.Events;
using Leopotam.Ecs;
using Services.Locator;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class UnitLevelSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ExperienceComponent, AddExperienceEvent> _addExperienceFilter = null;

        private StaticData _staticData;
        private SceneData _sceneData;
        
        public void Init()
        {
            _staticData = ServiceLocator.Current.Get<StaticData>();
        }
        
        public void Run()
        {
            foreach (var i in _addExperienceFilter)
            {
                ref var entity = ref _addExperienceFilter.GetEntity(i);
                
                ref var experienceComponent = ref _addExperienceFilter.Get1(i);
                ref var addExperienceEvent = ref _addExperienceFilter.Get2(i);

                experienceComponent.Current = Mathf.Clamp(
                    experienceComponent.Current + addExperienceEvent.Amount, 0,
                    experienceComponent.Limit);

                if (Mathf.Approximately(experienceComponent.Current, experienceComponent.Limit))
                {
                    experienceComponent.Level++;
                    experienceComponent.Current = 0;
                    experienceComponent.Limit =
                        _staticData.LevelUpConfig.Limit[experienceComponent.Level - 1];
                    
                    entity.Get<LevelUpEvent>();
                }

                entity.Get<ChangeExperienceEvent>();
                entity.Del<AddExperienceEvent>();
            }
        }
    }
}