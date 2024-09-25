using System;
using Builder;
using Factory;
using QFSW.QC;
using UnityEngine;

namespace _TestViaQFSW
{
    public class ExampleSpawnerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _spawnPoint;
        
        private AbstractEntityFactory _entityFactory;
        private PlayerEntityBuilder _playerBuilder;
        private EnemyEntityBuilder _enemyBuilder;

        private void Start()
        {
            _entityFactory = new EntityFactory();
            _playerBuilder = new PlayerEntityBuilder();
            _enemyBuilder = new EnemyEntityBuilder();
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
                    _entityFactory.CreateEntity(_enemyBuilder, _enemyPrefab);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
            }
        }

        [Command("spawn_entity_at_point")]
        private void SpawnEntityAtPoint(Tag tag)
        {
            switch (tag)
            {
                case Tag.Player:
                    _entityFactory.CreateEntity(_playerBuilder, _playerPrefab, _spawnPoint);
                    break;
                
                case Tag.Enemy:
                    _entityFactory.CreateEntity(_enemyBuilder, _enemyPrefab, _spawnPoint);
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(tag), tag, null);
            }
        }
    }

    public enum Tag
    {
        Player,
        Enemy
    }
}