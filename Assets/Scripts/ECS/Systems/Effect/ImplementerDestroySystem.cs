using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class ImplementerDestroySystem : IEcsRunSystem // todo в будущем желательно реализовать пулл имплементоров
    {
        private readonly EcsFilter<EffectFinishDurationEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                Debug.Log($"[ImplementerDestroySystem]: Destroy \n \t {_filter.GetEntity(i)}");
                
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}