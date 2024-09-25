using ECS.Data;
using Factory;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class SpawnEnemySystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData = null;
        private readonly RuntimeData _runtimeData = null;
        private readonly EntityFactory _entityFactory = null;

        private float _tickDuration = 3f;
        private float _timer;
        
        public void Run()
        {
            _timer += Time.deltaTime;

            if (_timer > _tickDuration)
            {
                var rSpawnPoint = Random.Range(0, _sceneData.SpawnPoints.Count);

                _entityFactory.CreateEntity(_runtimeData.EntityBuilder,
                    _sceneData.EnemyPrefab, _sceneData.SpawnPoints[rSpawnPoint]);

                _timer = 0;
            }
        }
    }
}