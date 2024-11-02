using Builder;
using Data;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Services.Factory
{
    public class HeroEntityFactory : AbstractHeroEntityFactory
    {
        private readonly BaseEntityBuilder _entityBuilder = new HeroEntityBuilder();

        public override EcsEntity CreateEntity(ClassUnitData classUnitData, RaceUnitData raceUnitData, ModelData modelData)
        {
            Unit = Object.Instantiate(modelData.Prefab);
            var entity = _entityBuilder.Build(Unit);

            var attributes = classUnitData.Attributes + raceUnitData.Attributes;
            var resources = raceUnitData.Resources; 
            
            entity.Get<AttributesUnitComponent>() = attributes;
            entity.Get<ResourcesUnitComponent>() = resources;

            return entity;
        }
        
        public override EcsEntity CreateEntity(ClassUnitData classUnitData, RaceUnitData raceUnitData, ModelData modelData, Transform transform)
        {
            var entity = CreateEntity(classUnitData, raceUnitData, modelData);
            Unit.transform.position = transform.position;

            return entity;
        }

        public override GameObject GetGameObject() => Unit;
    }
}