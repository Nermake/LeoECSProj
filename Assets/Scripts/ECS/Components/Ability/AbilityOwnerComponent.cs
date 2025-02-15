using System.Collections.Generic;
using Leopotam.Ecs;

namespace ECS.Components
{
    public struct AbilityOwnerComponent
    {
        public Dictionary<string, EcsEntity> Abilities;
    }
}