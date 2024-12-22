using Ability;
using UnityEngine;

namespace ECS.Components
{
    public struct AbilityComponent
    {
        public string Title;
        public string Description;
        public Sprite Icon;

        public float CooldownTime;
        public float CooldownTimer;

        public float ResourceCost;
        public ResourceCostType ResourceType;
    }
}

