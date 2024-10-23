using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class DeathSystem : IEcsRunSystem 
    {
        private readonly EcsFilter<DeathComponent> _deathFilter = null;
        
        public void Run()
        {
            foreach (var i in _deathFilter)
            {
                _deathFilter.GetEntity(i).Destroy();
            }
        }
    }
}