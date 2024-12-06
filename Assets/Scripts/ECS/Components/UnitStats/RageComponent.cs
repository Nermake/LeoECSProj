using System;

namespace ECS.Components
{
    [Serializable]
    public struct RageComponent
    {
        public float max;
        public float current;
        public float regeneration;
    }
}