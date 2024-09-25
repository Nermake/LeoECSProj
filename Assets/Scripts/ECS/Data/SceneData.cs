using System.Collections.Generic;
using UnityEngine;

namespace ECS.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private GameObject _enemyPrefab;

        public List<Transform> SpawnPoints => _spawnPoints;
        public Transform PlayerSpawnPoint => _playerSpawnPoint;
        public GameObject EnemyPrefab => _enemyPrefab;
    }
}