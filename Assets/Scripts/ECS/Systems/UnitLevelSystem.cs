using Configs;
using ECS.Components;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

namespace ECS.Systems
{
    public sealed class UnitLevelSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ExperienceComponent, AddExperienceEvent> _addExperienceFilter = null;
        
        [Inject] private readonly LevelUpConfig _levelUpConfig;
        
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
                    experienceComponent.Limit = _levelUpConfig.Limit[experienceComponent.Level - 1];
                    
                    entity.Get<LevelUpEvent>();
                }

                entity.Get<ChangeExperienceEvent>();
                entity.Del<AddExperienceEvent>();
            }
        }
    }
}