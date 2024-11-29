using System;

namespace ECS.Components
{
    [Serializable]
    public struct AbilityDamageComponent
    {
        public float baseDamage;
        public float scaleDamage;
    }
}