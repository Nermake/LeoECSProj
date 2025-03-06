using ECS.Components;
using ECS.Events;
using ECS.Flags;
using Game.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class AbilityApplySystem : IEcsRunSystem
    {
        private readonly EcsFilter<AbilityApplyStartEvent>.Exclude<AbilityLockFlag> _abilityApplyFilter;

        public void Run()
        {
            foreach (var i in _abilityApplyFilter)
            {
                ref var entity = ref _abilityApplyFilter.GetEntity(i);
                
                if (entity.Has<AbilityReadyFlag>() && entity.Has<AbilityEnoughResourceFlag>())
                {
                    if (entity.Has<AbilityTargetComponent>())
                    {
                        ref var abilityTargetComponent = ref entity.Get<AbilityTargetComponent>();

                        if (abilityTargetComponent.Target == EcsEntity.Null)
                        {
                            abilityTargetComponent.Target = entity.Get<AbilityOwnerComponent>().Owner;
                        }

                        if (entity.Has<AbilityCastComponent>())
                        {
                            entity.Get<AbilityStartCastEvent>();
                        }
                        else
                        {
                            entity.Get<AbilityFinishCastEvent>();
                        }
                    }
                    
                    if (entity.Has<AbilityAreaComponent>())
                    {
                        Debug.Log("Ability Area Component");
                    }
                }
                
                entity.Del<AbilityApplyStartEvent>();
            }
        }
    }
}