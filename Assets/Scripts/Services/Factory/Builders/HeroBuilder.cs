using System.Collections.Generic;
using ECS;
using ECS.Components;
using ECS.Mark;
using ECS.Requests;
using ECS.Tags;
using Game.Types;
using Leopotam.Ecs;
using Logic.View;
using UnityEngine;

namespace Services.Factory.Builders
{
    public class HeroBuilder
    {
        protected EcsEntity _entity;
        protected ActorView _view;
        protected EcsWorld _world;

        private Vector3 _spawnLocation;
        
        private readonly HeroConfig _config;
        
        public HeroBuilder(HeroConfig config) => _config = config;

        public void SetWorld(EcsWorld world) => _world = world;
        public void SetLocation(Vector3 location) => _spawnLocation = location;

        public virtual void Make()
        {
            _entity = _world.NewEntity();
            _view = Object.Instantiate(_config.ActorView, _spawnLocation, Quaternion.identity);
            
            _entity.Get<PlayerTag>();
            _entity.Get<HeroClassMark>().classType = _config.ClassType;
            _entity.Get<HeroRaceMark>().raceType = _config.RaceType;
            _entity.Get<DirectionComponent>();
            _entity.Get<AttackCharacteristicComponent>();
            _entity.Get<DefenseStatUnitComponent>();
            _entity.Get<ResourcesUnitComponent>();
            _entity.Get<AttributesUnitComponent>() += _config.RaceAttributes + _config.ClassAttributes;
            
            ref var movableComponent = ref _entity.Get<MovableComponent>();
            movableComponent.rigidbody2D = _view.GetComponent<Rigidbody2D>();
            movableComponent.speed = 5f;
            
            ref var transformComponent = ref _entity.Get<TransformComponent>();
            transformComponent.modelTransform = _view.transform;
            
            ref var initializeEntityRequest = ref _entity.Get<InitializeEntityRequest>();
            initializeEntityRequest.entityReference = _view.GetComponent<EntityReference>();// todo temporary stub
            
            ref var damageableComponent = ref _entity.Get<DamageableComponent>();
            damageableComponent.damageQueue = new Queue<Damage>();
        }
        
        public ActorView GetView() => _view;

        public ref EcsEntity GetResult() => ref _entity;
    }
}