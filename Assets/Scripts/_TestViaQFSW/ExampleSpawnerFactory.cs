using System;
using System.Collections.Generic;
using Builder;
using Configs;
using QFSW.QC;
using Services.Factory;
using Spawner;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _TestViaQFSW
{
    public class ExampleSpawnerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private GameObject _enemyShootPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private List<Transform> _spawnPoints;

        [SerializeField] private EntityConfig _entityConfig;
        
        private AbstractEntityFactory _entityFactory;
        private PlayerEntityBuilder _playerBuilder;
        private EnemyEntityBuilder _enemyMileBuilder;
        private EnemyEntityBuilder _enemyRangeBuilder;

        private EntitySpawner _entitySpawner;

        private void Start()
        {
            _entityFactory = new EntityFactory();
            _playerBuilder = new PlayerEntityBuilder();
            _enemyMileBuilder = new EnemyMileBuilder();
            _enemyRangeBuilder = new EnemyRangeBuilder();
            
            _entitySpawner = new EntitySpawner();
            _entitySpawner.Init(_entityConfig);
        }
        
        [Command("spawn_entity")]
        private void SpawnEntity(Tag tag)
        {
            switch (tag)
            {
                case Tag.Player:
                    _entityFactory.CreateEntity(_playerBuilder, _playerPrefab);
                    break;
                
                case Tag.Enemy:
                    _entityFactory.CreateEntity(_enemyMileBuilder, _enemyPrefab);
                    break;

                case Tag.EnemyShoot:
                    _entityFactory.CreateEntity(_enemyRangeBuilder, _enemyShootPrefab);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
            }
        }

        [Command("spawn_entity_at_point")]
        private void SpawnEntityAtPoint(Tag tag, bool isRandom)
        {
            switch (tag)
            {
                case Tag.Player:
                    Create(_playerBuilder, _playerPrefab, isRandom);
                    break;
                
                case Tag.Enemy:
                    Create(_enemyMileBuilder, _enemyPrefab, isRandom);
                    break;

                case Tag.EnemyShoot:
                    Create(_enemyRangeBuilder, _enemyShootPrefab, isRandom);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
            }
        }

        [Command("spawn_via_entity_spawner")]
        private void SpawnViaEntitySpawner(UnitType type)
        {
            _entitySpawner.Spawn(type);
        }
        
        [Command("spawn_at_point_via_entity_spawner")]
        private void SpawnAtPointViaEntitySpawner(UnitType type)
        {
            _entitySpawner.SpawnAtPoint(type, _spawnPoints[Random.Range(0, _spawnPoints.Count)]);
        }

        private void Create(BaseEntityBuilder builder, GameObject prefab, bool isRandom)
        {
            _entityFactory.CreateEntity(builder, prefab,
                isRandom ? _spawnPoints[Random.Range(0, _spawnPoints.Count)] : _spawnPoint);
        }
    }

    public enum Tag
    {
        Player,
        Enemy,
        EnemyShoot
    }
}