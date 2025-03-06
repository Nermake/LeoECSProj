using System.Collections.Generic;
using Leopotam.Ecs;

namespace ECS.Components
{
    public struct AbilityAreaComponent
    {
        public float Radius;
        public bool IsExternal;
        public float ExternalRadius;
        public List<EcsEntity> Targets;
    }
}