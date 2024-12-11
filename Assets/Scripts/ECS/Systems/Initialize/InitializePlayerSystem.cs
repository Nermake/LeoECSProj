using ECS.Data;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class InitializePlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, InitializePlayerEvent> _playerFilter = null;
        private readonly RuntimeData _runtimeData = null;

        private EcsEntity _player;
        
        public void Run()
        {
            foreach (var entity in _playerFilter)
            {
                _player = _playerFilter.GetEntity(entity);
                _player.Del<InitializePlayerEvent>();
                
                _runtimeData.PlayerEntity = _player;
            }
        }
    }
}