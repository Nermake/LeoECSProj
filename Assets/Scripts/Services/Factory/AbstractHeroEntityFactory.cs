using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Services.Factory
{
    public abstract class AbstractHeroEntityFactory //todo доделай фабрику под конкретныъх героев
    {
        protected GameObject Unit;
        
        public abstract EcsEntity CreateEntity(ClassUnitData classUnitData, RaceUnitData raceUnitData, ModelData modelData);
        public abstract EcsEntity CreateEntity(ClassUnitData classUnitData, RaceUnitData raceUnitData, ModelData modelData, Transform transform);
        public abstract GameObject GetGameObject();
    }
}