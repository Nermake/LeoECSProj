using ECS.Components;
using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class SetTargetForEnemySystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<FollowComponent> enemyFilter = null;
        private readonly EcsFilter<PlayerTag> targetFilter = null;

        private EcsEntity _player;
        

        public void Init()
        {
            foreach (var i in targetFilter)
            {
                _player = targetFilter.GetEntity(i);
            }
        }

        public void Run()
        {
            foreach (var i in enemyFilter)
            {
                //todo
            }
        }
    }
}