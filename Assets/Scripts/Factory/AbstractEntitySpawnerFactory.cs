using Builder;
using Leopotam.Ecs;
using UnityEngine;

namespace Factory
{
    public abstract class AbstractEntitySpawnerFactory
    {
        public abstract GameObject CreateEntity(UnitBuilder builder, GameObject prefab);
        public abstract EcsEntity[] CreateEntity(UnitBuilder builder, GameObject prefab, int count);
    }
}