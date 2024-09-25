using System.Collections.Generic;
using UnityEngine;

namespace ECS.Data
{
    [CreateAssetMenu(fileName = "EcsData", menuName = "Game Data/ECS/Static Data", order = 0)]
    public class StaticData : ScriptableObject
    {
        public List<Transform> spawnPoints;
        public GameObject playerPrefab;
    }
}