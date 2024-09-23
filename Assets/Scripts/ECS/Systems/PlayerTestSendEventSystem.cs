using ECS.Components;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerTestSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, TestEventComponent> _playerFilter = null;

        public void Run()
        {
            if (!Input.GetKeyDown(KeyCode.B)) return;

            foreach (var i in _playerFilter)
            {
                ref var entity = ref _playerFilter.GetEntity(i);
                entity.Get<TestEvent>();
            }
        }
    }
}