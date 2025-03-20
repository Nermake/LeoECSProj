using ECS.Components;
using ECS.Events;
using Game.Types;
using Leopotam.Ecs;
using QFSW.QC;
using Services.Factory;
using UnityEngine;
using Zenject;

namespace _TestViaQFSW
{
    public class ExampleActorFactory : MonoBehaviour
    {
        [SerializeField] private HeroConfig _config;
        [SerializeField] Transform _spawnPoint;

        [Inject] private EntityFactory _entityFactory; // todo
        private EcsEntity _entity;

        [Command]
        private void af_ch()
        {
            ref var entity = ref _entityFactory.CreateUnitEntity(_config, _spawnPoint.position);
            _entity = entity;
        }

        [Command]
        private void af_get_hp()
        {
            Debug.Log(
                $" Max: {_entity.Get<HealthComponent>().Max} \n Current: {_entity.Get<HealthComponent>().Current}");
        }

        [Command]
        private void af_set_hp(float value)// todo dont work for plate
        {
            _entity.Get<HealthComponent>().Current -= value;
            Debug.Log(
                $" HealthComponent Set: {value} \n Max: {_entity.Get<HealthComponent>().Max} \n Current: {_entity.Get<HealthComponent>().Current}");
        }
        
        [Command]
        private void af_set_mana(float value)// todo dont work for plate
        {
            _entity.Get<ManaComponent>().Current -= value;
            Debug.Log(
                $"ManaComponent Set: {value} \n Max: {_entity.Get<ManaComponent>().Max} \n Current: {_entity.Get<ManaComponent>().Current}");
        }
        

        [Command]
        private void af_change_sr(UnitResourcesType type)
        {
            _entity.Get<SecondaryResourceComponent>().Type = type;
            _entity.Get<ChangeSecondaryResourceEvent>();
        }
    }
}