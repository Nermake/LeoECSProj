using System;

namespace ECS.Components
{
    [Serializable]
    public struct EnergyComponent
    {
        public float max;
        public float current;
        public float regeneration;
    }
}