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
        
        private AbstractEntitySpawnerFactory _entitySpawnerFactory;
        private PlayerEntityBuilder _playerBuilder;
        private EnemyEntityBuilder _enemyBuilder;

        private void Start()
        {
            _entitySpawnerFactory = new EntitySpawnerFactory();
            _playerBuilder = new PlayerEntityBuilder();
            _enemyBuilder = new EnemyEntityBuilder();
        }
        
        [Command("spawn_entity")]
        private void SpawnEntity(Tag tag)
        {
            switch (tag)
            {
                case Tag.Player:
                    _entitySpawnerFactory.CreateEntity(_playerBuilder, _playerPrefab);
                    break;
                
                case Tag.Enemy:
                    _entitySpawnerFactory.CreateEntity(_enemyBuilder, _enemyPrefab);
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