using ECS;
using ECS.Requests;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Builder
{
    public abstract class BaseEntityBuilder
    {
        private EcsWorld _world;
        protected EcsEntity entity;

        private void CreateEntity(GameObject unit)
        {
            _world = WorldHandler.GetWorld();
            
            entity = _world.NewEntity();
            
            ref var initializeEntityRequest = ref entity.Get<InitializeEntityRequest>();
            
            initializeEntityRequest.entityReference = unit.GetComponent<EntityReference>();
        }

        protected abstract void Setup(GameObject unit);

        public EcsEntity Build(GameObject unit)
        {
            CreateEntity(unit);
            Setup(unit);

            return entity;
        }
    }
}