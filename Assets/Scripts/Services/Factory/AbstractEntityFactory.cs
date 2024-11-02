using Builder;
using Leopotam.Ecs;
using UnityEngine;

namespace Services.Factory
{
    public abstract class AbstractEntityFactory
    {
        public abstract GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab);
        public abstract GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab, Transform point);

        public abstract EcsEntity CreateEntity(BaseEntityBuilder builder, GameObject prefab, Transform point,
            out GameObject unit);
    }
}