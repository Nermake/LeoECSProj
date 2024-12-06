using System;

namespace ECS.Components
{
    [Serializable]
    public class AbilityTickDamageComponent
    {
        public float damage;
        public float scaleDamage;
        
        public float duration;
        public float tickInterval;
    }
}