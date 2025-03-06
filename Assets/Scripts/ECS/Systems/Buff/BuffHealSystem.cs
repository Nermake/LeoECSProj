using ECS.Components;
using ECS.Events;
using ECS.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class BuffHealSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BuffHeal, EffectTargetComponent, ImplementerOneFrameEvent> _instantFilter;
        private readonly EcsFilter<BuffHeal, EffectTargetComponent, EffectTickEvent> _tickFilter;
        
        public void Run()
        {
            foreach (var i in _instantFilter)
            {
                ref var entity = ref _instantFilter.GetEntity(i);
                ref var healAmount = ref _instantFilter.Get1(i).Amount;
                ref var target = ref _instantFilter.Get2(i).Target;

                if (entity.Has<BuffFlag>())
                {
                    ref var healthComponent = ref target.Get<HealthComponent>();
                    healthComponent.Current += healAmount;

                    entity.Del<ImplementerOneFrameEvent>();
                }

                if (entity.Has<DebuffFlag>())
                {
                    Debug.LogError("[BuffHealSystem] : BuffHeal - cant be a debuff!");
                }
            }

            foreach (var i in _tickFilter)
            {
                ref var entity = ref _tickFilter.GetEntity(i);
                ref var target = ref _tickFilter.Get2(i).Target;
                
                if (entity.Has<BuffFlag>())
                {
                    ref var amountPerTick = ref entity.Get<AmountPerTickComponent>().Amount;
                    ref var healthComponent = ref target.Get<HealthComponent>();
                    healthComponent.Current += amountPerTick;

                    entity.Del<EffectTickEvent>();
                }

                if (entity.Has<DebuffFlag>())
                {
                    Debug.LogError("[BuffHealSystem] : BuffHeal - cant be a debuff!");
                }
            }
        }
    }
}