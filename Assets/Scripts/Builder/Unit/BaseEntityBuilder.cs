using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Builder
{
    public abstract class BaseEntityBuilder
    {
        private EcsWorld _world;
        protected EcsEntity Entity;

        private void CreateEntity()
        {
            _world = WorldHandler.GetWorld();
            
            Entity = _world.NewEntity();
        }

        protected abstract void Setup(GameObject unit);

        public EcsEntity Build(GameObject unit)
        {
            CreateEntity();
            Setup(unit);

            return Entity;
        }
    }
}