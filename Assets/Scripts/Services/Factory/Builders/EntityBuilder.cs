using System;
using ECS.Components;
using Game.Types;
using Leopotam.Ecs;
using Logic.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Factory.Builders
{
    public class EntityBuilder
    {
        protected EcsEntity _entity;
        protected ActorView _view;
        protected EcsWorld _world;
        //protected GameObject _gameObject;

        private Vector3 _spawnLocation;

        private  readonly EntityConfig _config;

        public EntityBuilder(EntityConfig config) => _config = config;

        public void SetWorld(EcsWorld world) => _world = world;
        public void SetLocation(Vector3 location) => _spawnLocation = location;

        public virtual void Make()
        {
            _entity = _world.NewEntity();
            _view = Object.Instantiate(_config.ActorView, _spawnLocation, Quaternion.identity); //todo по какой-то причине объект не хочет создаваться, хотя при написании без "_view =" всё работает исправно
            //_gameObject = Object.Instantiate(_config.Prefab);//
            //_view = _gameObject.GetComponent<ActorView>();//
            
            foreach (var unit in _config.UnitResources)
            {
                switch (unit.type)
                {
                    case UnitResourcesType.Health:
                    {
                        ref var healthComponent = ref _entity.Get<HealthComponent>();
                        healthComponent.max = unit.max; 
                        healthComponent.current = unit.current; 
                        healthComponent.regeneration = unit.regeneration;
                        break;
                    }
                    case UnitResourcesType.Mana:
                    {
                        ref var manaComponent = ref _entity.Get<ManaComponent>();
                        manaComponent.max = unit.max; 
                        manaComponent.current = unit.current; 
                        manaComponent.regeneration = unit.regeneration;
                        break;
                    }
                    case UnitResourcesType.Energy:
                    {
                        ref var energyComponent = ref _entity.Get<EnergyComponent>();
                        energyComponent.max = unit.max; 
                        energyComponent.current = unit.current; 
                        energyComponent.regeneration = unit.regeneration;
                        break;
                    }
                    case UnitResourcesType.Rage:
                    {
                        ref var rageComponent = ref _entity.Get<RageComponent>();
                        rageComponent.max = unit.max; 
                        rageComponent.current = unit.current; 
                        rageComponent.regeneration = unit.regeneration;
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            

            // ref var viewComponent = ref _entity.Get<ViewComponent>();
            // viewComponent.View = _view;
            // viewComponent.HealthWidgetOffset = _config.WidgetOffset;

            ref var damageableComponent = ref _entity.Get<DamageableComponent>();
            damageableComponent.damageQueue = new();

            // ref var unionsComponent = ref _entity.Get<UnionsComponent>();
            // unionsComponent.EnemyTeams = _config.EnemyTeams;
            // unionsComponent.EnemyLayers = _config.EnemyLayers;

            _view.Init(_entity, _world);
            _view.SetTeam(_config.Team);
        }

        public ActorView GetView() => _view;

        public ref EcsEntity GetResult() => ref _entity;
    }
}