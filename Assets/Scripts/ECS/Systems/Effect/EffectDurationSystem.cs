using ECS.Components;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class EffectDurationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EffectDurationComponent, EffectRunDurationEvent> _durationFilter;
        
        public void Run()
        {
            foreach (var i in _durationFilter)
            {
                ref var effectDurationComponent = ref _durationFilter.Get1(i);

                effectDurationComponent.Timer -= Time.deltaTime;
                
                if (effectDurationComponent.Timer <= 0)
                {
                    Debug.Log("[EffectDurationSystem]: Duration Expired");
                    
                    ref var entity = ref _durationFilter.GetEntity(i);
                    entity.Del<EffectRunDurationEvent>();
                    entity.Get<EffectFinishDurationEvent>();
                    
                    effectDurationComponent.Timer = effectDurationComponent.Duration;
                }
            }
        }
    }
}