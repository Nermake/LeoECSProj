using Configs;
using Services.Locator;
using UnityEngine;

namespace ECS.Data
{
    [CreateAssetMenu(fileName = "EcsData", menuName = "Game Data/ECS/Static Data", order = 0)]
    public class StaticData : ScriptableObject, IService
    {
        [field: SerializeField] public LevelUpConfig LevelUpConfig { get; private set; }
        [field: SerializeField] public RaceConfig RaceConfig { get; private set; }
    }
}