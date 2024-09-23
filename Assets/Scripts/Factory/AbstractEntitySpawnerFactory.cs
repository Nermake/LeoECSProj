using Builder;
using Leopotam.Ecs;
using UnityEngine;

namespace Factory
{
    public abstract class AbstractEntitySpawnerFactory
    {
        public abstract GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab);
    }
}