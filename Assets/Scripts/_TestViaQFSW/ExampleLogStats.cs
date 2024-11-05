using System;
using ECS;
using ECS.Components;
using Leopotam.Ecs;
using QFSW.QC;
using UnityEngine;

namespace _TestViaQFSW
{
    [RequireComponent(typeof(EntityReference))]
    public class ExampleLogStats : MonoBehaviour
    {
        private EntityReference _entityReference;
        private EcsEntity _entity;
        
        private void Start()
        {
            _entityReference = GetComponent<EntityReference>();
            _entity = _entityReference.Entity;
        }

        [Command]
        private void log_stats()
        {
            Debug.Log($"Entity: {_entity} \n \n" +
                      $"AttackCharacteristicComponent: {_entity.Get<AttackCharacteristicComponent>().ToString()} \n \n" +
                      $"AttributesUnitComponent: {_entity.Get<AttributesUnitComponent>().ToString()} \n \n" +
                      $"DefenseStatUnitComponent: {_entity.Get<DefenseStatUnitComponent>().ToString()} \n \n" +
                      $"ResourcesUnitComponent: {_entity.Get<ResourcesUnitComponent>().ToString()} \n \n");
        }

        [Command]
        private void change_stats(float health, float mana, float energy)
        {
            ref var resourcesUnitComponent = ref _entity.Get<ResourcesUnitComponent>();
            
            resourcesUnitComponent.health = health;
            resourcesUnitComponent.mana = mana;
            resourcesUnitComponent.energy = energy;
        }
    }
}