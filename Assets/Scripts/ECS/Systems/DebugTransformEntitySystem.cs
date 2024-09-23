using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class DebugTransformEntitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent> _transformFilter = null;
        private readonly EcsFilter<FollowComponent> _followFilter = null;
        
        public void Run()
        {
            foreach (var i in _transformFilter)
            {
                ref var entity = ref _transformFilter.GetEntity(i);
                ref var transformComponent = ref _transformFilter.Get1(i);
                ref var transform = ref transformComponent.modelTransform;
                
                Debug.Log($"[Entity: {entity.ToString()}] [Transform: {transform.position}]");
            }

            foreach (var i in _followFilter)
            {
                ref var entity = ref _transformFilter.GetEntity(i);
                ref var followComponent = ref _followFilter.Get1(i);
                ref var follow = ref followComponent.target;
                
                Debug.Log($"[Entity: {entity.ToString()}] [Follow position: {follow}]");
            }
        }
    }
}