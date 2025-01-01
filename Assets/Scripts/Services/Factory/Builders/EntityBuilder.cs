using System;
using ECS.Components;
using Game.Types;
using Leopotam.Ecs;
using Logic.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory
{
    public class EntityBuilder
    {
        protected EcsEntity _entity;
        protected ActorView _view;
        protected EcsWorld _world;

        private Vector3 _spawnLocation;

        private readonly EntityConfig _config;

        public EntityBuilder(EntityConfig config) => _config = config;

        public void SetWorld(EcsWorld world) => _world = world;
        public void SetLocation(Vector3 location) => _spawnLocation = location;

        public virtual void Make()
        {
            _entity = _world.NewEntity();
            _view = Object.Instantiate(_config.ActorView, _spawnLocation, Quaternion.identity);
            
            foreach (var unit in _config.UnitResources)
            {
                switch (unit.type)
                {
                    case UnitResourcesType.Health:
                    {
                        ref var healthComponent = ref _entity.Get<HealthComponent>();
                        healthComponent.Max = unit.max; 
                        healthComponent.Current = unit.current; 
                        healthComponent.Regeneration = unit.regeneration;
                        
                        break;
                    }
                    case UnitResourcesType.Mana:
                    {
                        ref var manaComponent = ref _entity.Get<ManaComponent>();
                        manaComponent.Max = unit.max; 
                        manaComponent.Current = unit.current; 
                        manaComponent.Regeneration = unit.regeneration;
                        
                        break;
                    }
                    case UnitResourcesType.Energy:
                    {
                        ref var energyComponent = ref _entity.Get<EnergyComponent>();
                        energyComponent.Max = unit.max; 
                        energyComponent.Current = unit.current; 
                        energyComponent.Regeneration = unit.regeneration;
                        
                        break;
                    }
                    case UnitResourcesType.Rage:
                    {
                        ref var rageComponent = ref _entity.Get<RageComponent>();
                        rageComponent.Max = unit.max; 
                        rageComponent.Current = unit.current; 
                        rageComponent.Regeneration = unit.regeneration;
                        
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            ref var damageableComponent = ref _entity.Get<DamageableComponent>();
            damageableComponent.DamageQueue = new();

            _view.Init(_entity, _world);
            _view.SetTeam(_config.Team);
        }

        public ActorView GetView() => _view;

        public ref EcsEntity GetResult() => ref _entity;
    }
}