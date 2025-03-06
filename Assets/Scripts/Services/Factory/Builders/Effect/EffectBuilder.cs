using System.ComponentModel;
using ECS.Components;
using Leopotam.Ecs;

namespace Services.Factory
{
    public class EffectBuilder
    {
        protected EcsEntity _entity;
        //protected EcsEntity _owner;
        protected EcsWorld _world;

        private readonly EffectConfig _config;

        public EffectBuilder(EffectConfig config) => _config = config;

        public void SetWorld(EcsWorld world) => _world = world;
        //public void SetOwner(EcsEntity owner) => _owner = owner;

        public virtual void Make()
        {
            _entity = _world.NewEntity();

            ref var effectComponent = ref _entity.Get<EffectComponent>();
            effectComponent.Title = _config.Title;
            effectComponent.Description = _config.Description;
        }

        public ref EcsEntity GetResult() => ref _entity;
    }
}