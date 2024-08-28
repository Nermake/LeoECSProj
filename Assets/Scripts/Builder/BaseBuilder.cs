using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Builder
{
    public abstract class BaseBuilder
    {
        private EcsWorld _world;
        protected EcsEntity entity;

        private void CreateEntity()
        {
            _world = WorldHandler.GetWorld();
            
            entity = _world.NewEntity();
        }

        protected abstract void Setup(GameObject unit);

        public EcsEntity Build(GameObject unit)
        {
            CreateEntity();
            Setup(unit);

            return entity;
        }
    }
}