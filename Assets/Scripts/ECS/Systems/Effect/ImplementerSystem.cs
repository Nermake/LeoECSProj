using ECS.Components;
using ECS.Events;
using ECS.Flags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class ImplementerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ImplementerInitEvent> _startFilter;

        private EcsEntity _entity;
        
        public void Run()
        {
            foreach (var i in _startFilter)
            {
                _entity = _startFilter.GetEntity(i);
                _entity.Del<ImplementerInitEvent>();
                
                var implementer = _entity.Copy();
                
                if (implementer.Has<EffectDurationComponent>())
                {
                    implementer.Get<EffectRunDurationEvent>();
                }
                if (implementer.Has<InstantBuffFlag>())
                {
                    implementer.Get<ImplementerOneFrameEvent>();
                }
                
                Debug.Log($"[ImplementerSystem]: Created implementer \n \t{implementer} \n \n on effect \n \t {_entity}");
            }
        }
    }
}