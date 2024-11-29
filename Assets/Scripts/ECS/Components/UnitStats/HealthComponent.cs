using System;

namespace ECS.Components
{
    [Serializable]
    public struct HealthComponent
    {
        public float max;
        public float current;
        public float regeneration;
    }
}