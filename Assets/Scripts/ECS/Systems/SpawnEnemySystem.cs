using System.Collections.Generic;
using ECS.Data;
using Leopotam.Ecs;
using Services.Factory;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class SpawnEnemySystem : IEcsRunSystem //todo refactor
    {
        private readonly SceneData _sceneData;
        private readonly RuntimeData _runtimeData;
        //private readonly EntityFactory _entityFactory;
        
        private readonly List<GameObject> _enemies = new();

        private const float _tickDuration = 3f;
        private float _timer;
        
        public void Run()
        {
            if (_enemies.Count == 5) return;
            
            _timer += Time.deltaTime;
            
            if (_timer > _tickDuration)
            {
                var rSpawnPoint = Random.Range(0, _sceneData.SpawnPoints.Count);

                //var enemy = _entityFactory.CreateEntity(_runtimeData.BuilderData.EnemyMileBuilder,
                    //_sceneData.EnemyPrefab, _sceneData.SpawnPoints[rSpawnPoint]);
                //_enemies.Add(enemy);

                _timer = 0;
            }
        }
    }
}