using Builder;
using UnityEngine;

namespace Services.Factory
{
    public abstract class AbstractEntityFactory
    {
        public abstract GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab);
        public abstract GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab, Transform point);
    }
}