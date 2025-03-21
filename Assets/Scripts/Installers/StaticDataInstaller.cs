using Configs;
using UnityEngine;
using Zenject;

namespace ECS.Data
{
    [CreateAssetMenu(fileName = "EcsData", menuName = "Game Data/ECS/Static Data", order = 0)]
    public class StaticDataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LevelUpConfig _levelUpConfig;
        [SerializeField] private RaceConfig _raceConfig;
        
        public override void InstallBindings()
        {
            Container
                .Bind<LevelUpConfig>()
                .FromInstance(_levelUpConfig)
                .AsSingle();

            Container
                .Bind<RaceConfig>()
                .FromInstance(_raceConfig)
                .AsSingle();
        }
    }
}