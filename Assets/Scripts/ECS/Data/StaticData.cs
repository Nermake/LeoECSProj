using System.Collections.Generic;
using Data.Configs;
using UnityEngine;

namespace ECS.Data
{
    [CreateAssetMenu(fileName = "EcsData", menuName = "Game Data/ECS/Static Data", order = 0)]
    public class StaticData : ScriptableObject
    {
        [field: SerializeField] public List<Transform> spawnPoints { get; set; }
        [field: SerializeField] public GameObject playerPrefab { get; private set; }
        [field: SerializeField] public EntityConfig config { get; private set; }
    }
}