using Builder;
using ECS.Data;
using Leopotam.Ecs;
using Services.Factory;

namespace ECS.Systems
{
    public sealed class T_SpawnPlayerSystem : IEcsInitSystem
    {
        private readonly PlayerEntityBuilder _entityBuilder = new();
        private readonly EntityFactory _entityFactory = null;
        private readonly SceneData _sceneData = null;
        private readonly StaticData _staticData = null;
        private readonly RuntimeData _runtimeData = null;

        public void Init()
        {
            _entityFactory.CreateEntity(_entityBuilder, _staticData.config.player.gameObject,
                _sceneData.PlayerSpawnPoint, out var unit);
            _runtimeData.Player = unit;
        }
    }
}