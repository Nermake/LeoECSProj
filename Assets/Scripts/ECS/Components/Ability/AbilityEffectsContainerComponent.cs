using System.Collections.Generic;
using Leopotam.Ecs;

namespace ECS.Components
{
    public struct AbilityEffectsContainerComponent
    {
        public Queue<EcsEntity> EffectsQueue;
    }
}