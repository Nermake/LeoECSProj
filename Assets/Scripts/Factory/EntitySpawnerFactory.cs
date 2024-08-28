using Builder;
using Leopotam.Ecs;
using UnityEngine;

namespace Factory
{
    public class EntitySpawnerFactory : AbstractEntitySpawnerFactory
    {
        public override GameObject CreateEntity(UnitBuilder builder, GameObject prefab)
        {
            var unit = GameObject.Instantiate(prefab);
            builder.Build(unit);
            
            return unit;
        }

        public override EcsEntity[] CreateEntity(UnitBuilder builder, GameObject prefab, int count)
        {
            var entities = new EcsEntity[count];
            
            for (var i = 0; i < count; i++)
            {
                
            }

            return entities;
        }
    }
}