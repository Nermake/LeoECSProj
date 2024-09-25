using Builder;
using Leopotam.Ecs;

namespace ECS.Data
{
    public class RuntimeData
    {
        public PlayerEntityBuilder PlayerBuilder;
        public EnemyEntityBuilder EntityBuilder;
        public EcsEntity Player;
        
        public void Init()
        {
            PlayerBuilder = new PlayerEntityBuilder();
            EntityBuilder = new EnemyEntityBuilder();
            Player = EcsEntity.Null;
        }
    }
}