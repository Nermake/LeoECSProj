using ECS.Components;
using ECS.Data;
using ECS.Events;
using Leopotam.Ecs;
using Services.Factory;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class GenerateProjectileSystem// : IEcsInitSystem, IEcsRunSystem
    {
        /*private readonly EcsFilter<ShootPointComponent> _shootFilter;
        //private readonly EntityFactory _entityFactory; // todo refactor on actorfactory 

        //private PoolMono<EntityReference> _poolMono; todo реализуй пул под данную задачу
        private IEntityFactory _entityFactory;
        private StaticDataInstaller _staticDataInstaller;
        private RuntimeData _runtimeData;
        //private BaseEntityBuilder _builder;
        private GameObject _projectile;

        public void Init()
        {
            //_poolMono = new PoolMono<EntityReference>(_staticData.config.entity, 5, true);
            _entityFactory = ServiceLocator.Current.Get<EntityFactory>();
            _staticDataInstaller = ServiceLocator.Current.Get<StaticDataInstaller>();
            _runtimeData = ServiceLocator.Current.Get<RuntimeData>();
            
            //_builder = _runtimeData.BuilderData.ProjectileBuilder;
            //_projectile = _staticData.EntityConfig.projectile.gameObject; todo переделай тк ты уддалил данный из статик даты(для отладки ниже дебаг)
            Debug.Log("GenerateProjectileSystem: невозможно произвести выстрел ты не исправил код!");
        }
        
        public void Run()
        {
            if (_runtimeData.PlayerActor == null) return;
            
            foreach (var i in _shootFilter)
            {
                ref var shootPointComponent = ref _shootFilter.Get1(i);
                
                ref var point = ref shootPointComponent.Point;
                
                shootPointComponent.Timer += Time.deltaTime;

                if (shootPointComponent.Timer >= shootPointComponent.Tick)
                {
                    //var projectile = _entityFactory.CreateEntity(_builder, _projectile, Point);
                    //var EntityReference = projectile.GetComponent<EntityReference>();
                    
                    //Debug.Log(EntityReference.Entity); // todo тут NULL

                    //var entity = _entityFactory.CreateEntity(_builder, _projectile, Point, out var unit);
                    //ref var request = ref entity.Get<InitializeProjectileEvent>();

                    //request.Target = _runtimeData.PlayerActor.transform.position;
                    //request.StartPosition = unit.transform.position;
                    
                    //Debug.Log(entity);
                    //shootPointComponent.Timer = 0;
                }
            }
        }*/
    }
}