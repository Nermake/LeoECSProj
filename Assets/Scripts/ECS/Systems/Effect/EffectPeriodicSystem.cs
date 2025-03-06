using ECS.Components;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class EffectPeriodicSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EffectPeriodicComponent, EffectRunDurationEvent>.Exclude<EffectFinishDurationEvent> _periodicFilter;

        public void Run()
        {
            foreach (var i in _periodicFilter)
            {
                ref var entity = ref _periodicFilter.GetEntity(i);
                ref var effectPeriodicComponent = ref _periodicFilter.Get1(i);
                
                effectPeriodicComponent.Timer -= Time.deltaTime;

                if (effectPeriodicComponent.Timer <= 0)
                {
                    Debug.Log("[EffectPeriodicSystem]: tick");
                    var miss = effectPeriodicComponent.Timer;
                    effectPeriodicComponent.Timer = effectPeriodicComponent.TickInterval + miss;

                    entity.Get<EffectTickEvent>();
                }
            }
        }
    }
}