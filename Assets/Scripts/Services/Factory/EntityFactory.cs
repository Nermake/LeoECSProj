using Builder;
using Leopotam.Ecs;
using UnityEngine;

namespace Services.Factory
{
    public class EntityFactory : AbstractEntityFactory
    {
        public override GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab)
        {
            var unit = Object.Instantiate(prefab);
            builder.Build(unit);
            
            return unit;
        }

        public override GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab, Transform point)
        {
            var unit = Object.Instantiate(prefab, point.position, point.rotation);
            builder.Build(unit);
            
            return unit;
        }
        
        public EcsEntity CreateEntity(BaseEntityBuilder builder, GameObject prefab, Transform point, out GameObject unit)
        {
            unit = Object.Instantiate(prefab, point.position, point.rotation);
            var entity = builder.Build(unit);
            
            return entity;
        }
    }
}