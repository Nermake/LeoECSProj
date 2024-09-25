using Builder;
using UnityEngine;

namespace Factory
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
    }
}