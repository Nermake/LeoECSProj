using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class RegenerationUnitSystem : IEcsRunSystem //todo
    {
        private readonly EcsFilter<HealthComponent> _healthFilter = null;
        private readonly EcsFilter<ManaComponent> _manaFilter = null;
        private readonly EcsFilter<EnergyComponent> _energyFilter = null;
        private readonly EcsFilter<RageComponent> _rageFilter = null;

        public void Run()
        {
            foreach (var i in _healthFilter)
            {
                ref var healthComponent = ref _healthFilter.Get1(i);
                healthComponent.current = Math.Clamp(
                    healthComponent.current + healthComponent.regeneration * Time.deltaTime, 0.0f, healthComponent.max);
            }
            
            foreach (var i in _manaFilter)
            {
                ref var manaComponent = ref _manaFilter.Get1(i);
                manaComponent.current = Math.Clamp(
                    manaComponent.current + manaComponent.regeneration * Time.deltaTime, 0.0f, manaComponent.max);
            }
            
            foreach (var i in _energyFilter)
            {
                ref var energyComponent = ref _energyFilter.Get1(i);
                energyComponent.current = Math.Clamp(
                    energyComponent.current + energyComponent.regeneration * Time.deltaTime, 0.0f, energyComponent.max);
            }
            
            foreach (var i in _rageFilter)
            {
                ref var rageComponent = ref _rageFilter.Get1(i);
                rageComponent.current = Math.Clamp(
                    rageComponent.current + rageComponent.regeneration * Time.deltaTime, 0.0f, rageComponent.max);
            }
        }
    }
}