using ECS.Components;
using ECS.Events;
using Game.Types;
using Leopotam.Ecs;
using Logic.View;
using QFSW.QC;
using Services.Factory;
using Services.Locator;
using UnityEngine;
using Voody.UniLeo;

namespace _TestViaQFSW
{
    public class ExampleActorFactory : MonoBehaviour
    {
        [SerializeField] private HeroConfig _heroConfig;
        [SerializeField] Transform _spawnPoint;
        
        private IEntityFactory _entityFactory; // todo
        private ActorView _view;
        private EcsEntity _entity;

        private void Start()
        {
            _entityFactory = ServiceLocator.Current.Get<EntityFactory>();
            _entityFactory = new EntityFactory(WorldHandler.GetWorld());
        }
        
        [Command]
        private void af_ch()
        {
            ref var entity =  ref _entityFactory.CreateUnitEntity(_heroConfig, _spawnPoint.position);
            _entity = entity;
        }

        [Command]
        private void af_get_hp()
        {
            Debug.Log($" Max: {_entity.Get<HealthComponent>().Max} \n Current: {_entity.Get<HealthComponent>().Current}");
        }
        
        [Command]
        private void af_set_hp(float value)
        {
            _entity.Get<HealthComponent>().Current -= value;
            Debug.Log($"Set: {value} \n Max: {_entity.Get<HealthComponent>().Max} \n Current: {_entity.Get<HealthComponent>().Current}");
        }
        
        [Command]
        private void af_change_sr(UnitResourcesType type)
        {
            _entity.Get<ResourceComponent>().SecondaryResourcesType = type;
            _entity.Get<ChangeSecondaryResourceEvent>();
        }
    }
}