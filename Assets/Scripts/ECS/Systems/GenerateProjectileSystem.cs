using Builder;
using ECS.Components;
using ECS.Data;
using ECS.Requests;
using Leopotam.Ecs;
using Services.Factory;
using Services.Locator;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class GenerateProjectileSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ShootPointComponent> _shootFilter = null;
        private readonly StaticData _staticData = null;
        private readonly RuntimeData _runtimeData = null;
        private readonly EntityFactory _entityFactory = null; // todo refactor on actorfactory 

        //private PoolMono<EntityReference> _poolMono; todo реализуй пул под данную задачу
        private IActorFactory _actorFactory;
        private BaseEntityBuilder _builder;
        private GameObject _projectile;

        public void Init()
        {
            //_poolMono = new PoolMono<EntityReference>(_staticData.config.entity, 5, true);
            _actorFactory = ServiceLocator.Current.Get<ActorFactory>();
            _builder = _runtimeData.BuilderData.ProjectileBuilder;
            _projectile = _staticData.config.projectile.gameObject;
        }
        
        public void Run()
        {
            if (_runtimeData.PlayerEntity == EcsEntity.Null) return;
            
            foreach (var i in _shootFilter)
            {
                ref var shootPointComponent = ref _shootFilter.Get1(i);
                
                ref var point = ref shootPointComponent.point;
                
                shootPointComponent.timer += Time.deltaTime;

                if (shootPointComponent.timer >= shootPointComponent.tick)
                {
                    //var projectile = _entityFactory.CreateEntity(_builder, _projectile, point);
                    //var entityReference = projectile.GetComponent<EntityReference>();
                    
                    //Debug.Log(entityReference.Entity); // todo тут NULL

                    var entity = _entityFactory.CreateEntity(_builder, _projectile, point, out var unit);
                    ref var request = ref entity.Get<InitializeProjectileRequest>();

                    request.target = _runtimeData.Player.transform.position;
                    request.startPosition = unit.transform.position;
                    
                    Debug.Log(entity);
                    shootPointComponent.timer = 0;
                }
            }
        }
    }
}