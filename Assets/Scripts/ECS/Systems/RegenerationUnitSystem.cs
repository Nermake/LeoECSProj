using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class RegenerationUnitSystem : IEcsRunSystem //todo
    {
        private readonly EcsFilter<HealthComponent> _healthFilter;
        private readonly EcsFilter<ManaComponent> _manaFilter;
        private readonly EcsFilter<EnergyComponent> _energyFilter;
        private readonly EcsFilter<RageComponent> _rageFilter;

        public void Run()
        {
            foreach (var i in _healthFilter)
            {
                ref var healthComponent = ref _healthFilter.Get1(i);
                healthComponent.Current = Math.Clamp(
                    healthComponent.Current + healthComponent.Regeneration * Time.deltaTime, 0.0f, healthComponent.Max);
            }
            
            foreach (var i in _manaFilter)
            {
                ref var manaComponent = ref _manaFilter.Get1(i);
                manaComponent.Current = Math.Clamp(
                    manaComponent.Current + manaComponent.Regeneration * Time.deltaTime, 0.0f, manaComponent.Max);
            }
            
            foreach (var i in _energyFilter)
            {
                ref var energyComponent = ref _energyFilter.Get1(i);
                energyComponent.Current = Math.Clamp(
                    energyComponent.Current + energyComponent.Regeneration * Time.deltaTime, 0.0f, energyComponent.Max);
            }
            
            foreach (var i in _rageFilter)
            {
                ref var rageComponent = ref _rageFilter.Get1(i);
                rageComponent.Current = Math.Clamp(
                    rageComponent.Current + rageComponent.Regeneration * Time.deltaTime, 0.0f, rageComponent.Max);
            }
        }
    }
}