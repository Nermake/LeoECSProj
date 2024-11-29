using System;

namespace ECS.Components
{
    [Serializable]
    public struct ManaComponent
    {
        public float max;
        public float current;
        public float regeneration;
    }
}