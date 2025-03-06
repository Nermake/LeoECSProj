using System.Collections.Generic;
using Leopotam.Ecs;

namespace ECS.Components
{
    public struct AbilityContainerComponent
    {
        public Dictionary<string, EcsEntity> Abilities;
    }
}