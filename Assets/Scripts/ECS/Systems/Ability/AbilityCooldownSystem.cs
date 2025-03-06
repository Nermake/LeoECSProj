using ECS.Components;
using ECS.Flags;
using Game.Types;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class AbilityCooldownSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AbilityCooldownComponent>.Exclude<AbilityNoCooldownFlag> _cooldownFilter;
        
        public void Run()
        {
            foreach (var i in _cooldownFilter)
            {
                ref var entity = ref _cooldownFilter.GetEntity(i);
                
                if (entity.Has<AbilityCooldownFlag>())
                {
                    ref var abilityView = ref entity.Get<AbilityViewComponent>().AbilityView;
                    ref var abilityCooldownComponent = ref _cooldownFilter.Get1(i);
                
                    abilityCooldownComponent.CooldownTimer -= Time.deltaTime;
                    
                    abilityView.SetCooldownFillAmount(abilityCooldownComponent.CooldownTimer / abilityCooldownComponent.CooldownTime);
                    abilityView.SetCooldownTimer(abilityCooldownComponent.CooldownTimer < 60
                        ? $"{Mathf.RoundToInt(abilityCooldownComponent.CooldownTimer)}s"
                        : $"{Mathf.RoundToInt(abilityCooldownComponent.CooldownTimer / 60)}m");

                    if (abilityCooldownComponent.CooldownTimer <= 0)
                    {
                        abilityView.SetCooldownFillAmount(0);
                        abilityView.SetCooldownTimer(string.Empty);
                        
                        entity.Del<AbilityCooldownFlag>();
                        entity.Get<AbilityReadyFlag>();

                        abilityCooldownComponent.CooldownTimer = abilityCooldownComponent.CooldownTime;
                    }
                }
            }
        }
    }
}