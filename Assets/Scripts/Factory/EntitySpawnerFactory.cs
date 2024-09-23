using Builder;
using Leopotam.Ecs;
using UnityEngine;

namespace Factory
{
    public class EntitySpawnerFactory : AbstractEntitySpawnerFactory
    {
        public override GameObject CreateEntity(BaseEntityBuilder builder, GameObject prefab)
        {
            var unit = Object.Instantiate(prefab);
            builder.Build(unit);
            
            return unit;
        }
    }
}